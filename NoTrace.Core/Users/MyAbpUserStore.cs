using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using Microsoft.AspNet.Identity;
using NoTrace.Authorization;
using NoTrace.MultiTenancy;

namespace NoTrace.Users
{
    public abstract class MyAbpUserStore<TTenant, TRole, TUser> :
        IUserStore<TUser, long>,
        IUserPasswordStore<TUser, long>,
        IUserEmailStore<TUser, long>,
        IUserLockoutStore<TUser, long>,
        IUserLoginStore<TUser, long>,
        IQueryableUserStore<TUser, long>,
        IUserRoleStore<TUser, long>,
        ITransientDependency
        where TUser : MyAbpUser<TTenant, TUser>
        where TTenant : MyAbpTenant<TTenant, TUser>
        where TRole : MyAbpRole<TTenant, TUser>
    {
        #region Fields
        private readonly IRepository<TUser, long> _userRepository;
        private readonly IRepository<TRole> _roleRepository;
        private readonly IAbpSession _abpSession;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<UserLogin, long> _userLoginRepository;
        private readonly IRepository<UserRole, long> _userRolerRepository;
        #endregion

        #region Constructor

        protected MyAbpUserStore(
           IRepository<TUser, long> userRepository,
           IRepository<TRole> roleRepository,
           IAbpSession abpSession,
           IUnitOfWorkManager unitOfWorkManager,
           IRepository<UserLogin, long> userLoginRepository,
           IRepository<UserRole, long> userRoleRepository
           )
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _abpSession = abpSession;
            _unitOfWorkManager = unitOfWorkManager;
            _userLoginRepository = userLoginRepository;
            _userRolerRepository = userRoleRepository;
        }
        #endregion

        #region QueryableUser

        public virtual IQueryable<TUser> Users
        {
            get { return _userRepository.GetAll(); }
        }


        #endregion

        #region User
        public virtual async Task CreateAsync(TUser user)
        {
            await _userRepository.InsertAsync(user);
        }

        public virtual async Task DeleteAsync(TUser user)
        {
            await _userRepository.DeleteAsync(user.Id);
        }

        public void Dispose()
        {
            // use ioc manage life 
        }

        public virtual async Task<TUser> FindByIdAsync(long userId)
        {
            return await _userRepository.FirstOrDefaultAsync(userId);
        }

        public virtual async Task<TUser> FindByNameAsync(string userName)
        {
            return await _userRepository.SingleAsync(u => u.UserName == userName);
        }

        public virtual async Task UpdateAsync(TUser user)
        {
            await _userRepository.UpdateAsync(user);
        }
        #endregion

        #region Password
        public virtual Task SetPasswordHashAsync(TUser user, string passwordHash)
        {
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        public virtual Task<string> GetPasswordHashAsync(TUser user)
        {
            return Task.FromResult(user.Password);
        }

        public virtual Task<bool> HasPasswordAsync(TUser user)
        {
            return Task.FromResult(string.IsNullOrEmpty(user.Password));
        }
        #endregion

        #region Email
        public virtual Task SetEmailAsync(TUser user, string email)
        {
            user.EmailAddress = email;
            return Task.FromResult(0);
        }

        public virtual Task<string> GetEmailAsync(TUser user)
        {
            return Task.FromResult(user.EmailAddress);
        }

        public virtual Task<bool> GetEmailConfirmedAsync(TUser user)
        {
            return Task.FromResult(user.IsEmailConfirmed);
        }

        public virtual Task SetEmailConfirmedAsync(TUser user, bool confirmed)
        {
            user.IsEmailConfirmed = confirmed;
            return Task.FromResult(0);
        }

        public virtual async Task<TUser> FindByEmailAsync(string email)
        {
            return await _userRepository.SingleAsync(u => u.EmailAddress == email);
        }
        #endregion

        #region Lockout //Temporarily not implement
        public Task<DateTimeOffset> GetLockoutEndDateAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(TUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAccessFailedCountAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetLockoutEnabledAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEnabledAsync(TUser user, bool enabled)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Login
        /// <summary>
        /// Add login info
        /// </summary>
        /// <param name="user"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        public virtual async Task AddLoginAsync(TUser user, UserLoginInfo login)
        {
            await _userLoginRepository.InsertAsync(new UserLogin()
            {
                UserId = user.Id,
                LoginProvider = login.LoginProvider,
                ProviderKey = login.ProviderKey
            });
        }

        public virtual async Task RemoveLoginAsync(TUser user, UserLoginInfo login)
        {
            await _userLoginRepository.DeleteAsync(
                ul => ul.UserId == user.Id &&
                      ul.LoginProvider == login.LoginProvider &&
                      ul.ProviderKey == login.ProviderKey);
        }

        public virtual async Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user)
        {
            return (await _userLoginRepository.GetAllListAsync(ul => ul.UserId == user.Id))
                .Select(ul => new UserLoginInfo(ul.LoginProvider, ul.ProviderKey))
                .ToList();
        }

        public virtual async Task<TUser> FindAsync(UserLoginInfo login)
        {
            var userLogin = _userLoginRepository.SingleAsync(ul => ul.LoginProvider == login.LoginProvider &&
                                                                   ul.ProviderKey == login.ProviderKey);
            if (userLogin == null)
            {
                return null;
            }

            return await _userRepository.SingleAsync(u => u.Id == userLogin.Id);
        }
        #endregion

        #region Role
        public virtual async Task AddToRoleAsync(TUser user, string roleName)
        {
            var role = await _roleRepository.SingleAsync(r => r.Name == roleName);
            await _userRolerRepository.InsertAsync(new UserRole(user.Id, role.Id));
        }

        public virtual async Task RemoveFromRoleAsync(TUser user, string roleName)
        {
            var role = await _roleRepository.SingleAsync(r => r.Name == roleName);
            var userRole = await _userRolerRepository.SingleAsync(ur => ur.RoleId == role.Id && ur.UserId == user.Id);

            if (userRole == null)
                return;

            await _userRolerRepository.DeleteAsync(userRole);
        }

        public virtual Task<IList<string>> GetRolesAsync(TUser user)
        {
            var roleNameList = _userRolerRepository.Query(userRoles => (
                from userRole in userRoles
                join role in _roleRepository.GetAll()
                    on userRole.RoleId equals role.Id
                where userRole.UserId == user.Id
                select role.Name
                )).ToList();

            return Task.FromResult<IList<string>>(roleNameList);
        }

        public virtual async Task<bool> IsInRoleAsync(TUser user, string roleName)
        {
            var role = await _roleRepository.SingleAsync(r => r.Name == roleName);
            return role != null &&
                   (await _userRolerRepository.SingleAsync(ur => ur.RoleId == role.Id && ur.UserId == user.Id) != null);
        }
        #endregion
    }
}