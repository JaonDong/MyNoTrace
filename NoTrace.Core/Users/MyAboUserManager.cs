using System.Security.Claims;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Uow;
using Microsoft.AspNet.Identity;
using NoTrace.Authorization;
using NoTrace.MultiTenancy;

namespace NoTrace.Users
{
    public abstract class MyAboUserManager<TTenant, TUser, TRole> : UserManager<TUser, long>,ITransientDependency
        where TUser : MyAbpUser<TTenant, TUser>
        where TTenant : MyAbpTenant<TTenant, TUser>
        where TRole : MyAbpRole<TTenant, TUser>
    {
        private readonly MyAbpUserStore<TTenant, TRole, TUser> _myAbpUserStore;  

        protected MyAboUserManager(MyAbpUserStore<TTenant, TRole, TUser> store)
            : base(store)
        {
            _myAbpUserStore = store;
        }

        public override async Task<IdentityResult> CreateAsync(TUser user)
        {
            //添加验证逻辑
            //.......
            //密码加密，是在这里加密吗？还是在JS加密？
            user.Password = new PasswordHasher().HashPassword(user.Password);
            return await base.CreateAsync(user);
        }
        [UnitOfWork]
        public virtual async Task<NoTraceLoginResult> LoginAsyn(string userName,string password,string email=null)
        {
            var user =  await _myAbpUserStore.FindByNameAsync(userName);

            if (user == null)
            {
                return await Task.FromResult(new NoTraceLoginResult(null,null,NoTraceLoginResultType.Failed));
            }
            var passwordVerificationResult = new PasswordHasher().VerifyHashedPassword(user.Password, password);
            if (passwordVerificationResult == PasswordVerificationResult.Success)
            {
                var identity = await CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

                return await Task.FromResult(new NoTraceLoginResult(user,identity));
            }
            return await Task.FromResult(new NoTraceLoginResult(user, null, NoTraceLoginResultType.Failed));
        }

        public class NoTraceLoginResult
        {
            public TUser User { get;private set; }
            public ClaimsIdentity ClaimsIdentity { get; private set; }
            public NoTraceLoginResultType ResultType { get; private set; }

            public NoTraceLoginResult(TUser user,ClaimsIdentity claimsIdentity,NoTraceLoginResultType resultType)
            {
                this.User = user;
                this.ClaimsIdentity = claimsIdentity;
                this.ResultType = resultType;
            }

            public NoTraceLoginResult(TUser user,ClaimsIdentity claimsIdentity
                ):this(user,claimsIdentity,NoTraceLoginResultType.Sucessed)
            {
                
            }
        }
    }

   
}