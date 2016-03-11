
using XamarinDemo8.Attibutes;

namespace XamarinDemo8.Services
{
    [Preserve(AllMembers = true)]
    public class LoginService
    {
        public LoginService()
        {
        }

        public bool Login(string userName, string password)
        {
            return userName == "Test" && password == "Password";
        }
    }
}

