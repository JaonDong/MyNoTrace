using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using NoTrace.Authorization;
using NoTrace.MultiTenancy;

namespace NoTrace.Users
{
    public class NoTraceUserStore : MyAbpUserStore<Tenant, Role, User>
    {
        public NoTraceUserStore(
            IRepository<User, long> userRepository,
            IRepository<Role> roleRepository,
            IAbpSession abpSession,
            IUnitOfWorkManager unitOfWorkManager,
            IRepository<UserLogin, long> userLoginRepository,
            IRepository<UserRole, long> userRoleRepository)
            : base(userRepository, roleRepository, abpSession, unitOfWorkManager, userLoginRepository, userRoleRepository)
        {
        }
    }
}