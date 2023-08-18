using BlogProjectWebUI.Core.DTO.Login;
using BlogProjectWebUI.Helper;
using BlogProjectWebUI.Helper.SessionHelper;
using Microsoft.AspNetCore.Http;



namespace BlogProjectWebUI.Helper.SessionHelper
{
    public class SessionManager
    {

        public static LoginDTO? LoggedUser
        {
            get => AppHttpContext.Current.Session.GetObject<LoginDTO>("LoginDTO");
            set => AppHttpContext.Current.Session.SetObject("LoginDTO", value);
        }
        public static string? Token

        {
            get => AppHttpContext.Current.Session.GetObject<string>("Token");

            set => AppHttpContext.Current.Session.SetObject("Token", value);
        }

    }
}