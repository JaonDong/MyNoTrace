using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using Microsoft.AspNet.Identity;
using MyAbp.Core.MultiTenancy;
using MyAbp.Core.Roles;

namespace MyAbp.Core.Users
{
    public class MyAbpUserStore<TTenant, TRole, TUser> : 
        IUserStore<TUser,long>,
        IUserPasswordStore<TUser,long>,
        IUserEmailStore<TUser,long> ,
        IUserLockoutStore<TUser,long>,
        IUserLoginStore<TUser,long> ,
        IQueryableUserStore<TUser,long> ,
        IUserRoleStore<TUser,long>,
        ITransientDependency
        where TUser : MyAbpUser<TTenant, TUser>
        where TTenant : MyAbpTenant<TTenant, TUser>
        where TRole:MyAbpRole<TTenant,TUser>
    {
        #region Fields
        private readonly IRepository<TUser, long> _userRepository;
        private readonly IRepository<TRole> _roleRepository;
        private readonly IAbpSession _abpSession;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        #endregion

        #region Constructor
        public MyAbpUserStore(
           IRepository<TUser, long> userRepository,
           IRepository<TRole> roleRepository,
           IAbpSession abpSession,
           IUnitOfWorkManager unitOfWorkManager
           )
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _abpSession = abpSession;
            _unitOfWorkManager = unitOfWorkManager;
        }  
        #endregion

        #region QueryableUser
        public IQueryable<TUser> Users
        {
            get { throw new NotImplementedException(); }
        } 
        #endregion

        #region User
        public Task CreateAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<TUser> FindByIdAsync(long userId)
        {
            throw new NotImplementedException();
        }

        public Task<TUser> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TUser user)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Password
        public Task SetPasswordHashAsync(TUser user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(TUser user)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Email
        public Task SetEmailAsync(TUser user, string email)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetEmailConfirmedAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(TUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task<TUser> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Lockout
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
        public Task AddLoginAsync(TUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(TUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task<TUser> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Role
        public Task AddToRoleAsync(TUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(TUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(TUser user, string roleName)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}