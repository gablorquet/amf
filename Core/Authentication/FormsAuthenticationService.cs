using System.Web;
using System.Web.Security;
using Newtonsoft.Json;

namespace Core.Authentication
{
    public class CurrentUser
    {
        public UserType Type { get; set; }
        public int UserId { get; set; }
        public string DisplayName { get; set; }
    }

    public enum UserType
    {
        Prospector,
        Administrator,
        Provider
    }

    public class FormsAuthenticationService : IAuthenticationService
    {
        public FormsAuthenticationService()
        {
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }


        public CurrentUser GetCurrentUser()
        {
            var data = HttpContext.Current.User.Identity.Name;
            var user = JsonConvert.DeserializeObject<CurrentUser>(data);
            return user;
        }

        public bool IsAuthenticated()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated; 
        }
    }
}
