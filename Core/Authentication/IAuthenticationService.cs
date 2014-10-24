namespace Core.Authentication
{
    public interface IAuthenticationService
    {
        void SignOut();
        CurrentUser GetCurrentUser();
        bool IsAuthenticated();
    }

}
