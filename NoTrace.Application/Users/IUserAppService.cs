namespace NoTrace.Users
{
    public interface IUserAppService
    {
        void CreateUser();
        //密码加密
        void Login();

        void GetUsers();
    }
}