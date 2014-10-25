using System.Security.Cryptography.X509Certificates;
using Core.Models;

namespace Core.Authentication
{
    public interface IAuthenticationService
    {
        void SignOut();
        CurrentUser GetCurrentUser();
        T GetCurrent<T>() where T : User;
        bool IsAuthenticated();
        void SetCurrent<T>(T user) where T : User;
    }

}
