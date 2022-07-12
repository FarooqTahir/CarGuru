namespace CarGuru.Services.Interfaces
{
    public interface ISessionManager
    {
       
        string GetProfilePicture();
        string GetRole();
        long GetUserId();
        string GetUsername();
        int GetUserRoleId();
        string GetTokenSession();
        string GetSessionId();
        void SetProfilePicture(string Url);
        void SetUserName(string Name);
        //string GetConnectionString();
    }
}
