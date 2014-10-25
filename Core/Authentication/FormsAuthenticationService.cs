using System.Web;
using System.Web.Security;
using Core.Models;
using Core.Storage;
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
        Animateur,
        Player
    }

    public class FormsAuthenticationService : IAuthenticationService
    {
        private readonly ISession _session;

        public FormsAuthenticationService(ISession session)
        {
            _session = session;
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

        public T GetCurrent<T>() where T : User
        {
            var data = HttpContext.Current.User.Identity.Name;
            var user = JsonConvert.DeserializeObject<CurrentUser>(data);
            return _session.SingleById<T>(user.UserId);
        }

        public bool IsAuthenticated()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated; 
        }

        public void SetCurrent<T>(T user) where T : User
        {
            var type = user.GetType() == typeof(Animateur) ? UserType.Animateur : UserType.Player;

            var cookieContent = JsonConvert.SerializeObject(new CurrentUser
            {
                UserId = user.Id,
                Type = type,
                DisplayName = user.Name
            });

            FormsAuthentication.SetAuthCookie(cookieContent, true);

        }
    }
}
