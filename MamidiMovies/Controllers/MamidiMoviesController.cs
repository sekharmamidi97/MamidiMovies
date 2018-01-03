using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MamidiMovies.Controllers
{
    public class MamidiMoviesController : Controller
    {
        private const string UsernameKey = "UsernameKey";

        // GET: MamidiMovies
        public bool IsAuthenticated
        {
            get
            {
                return Session[UsernameKey] != null;
            }
        }

        public string CurrentUser
        {
            get
            {
                string username = string.Empty;

                //Check to see if user cookie exists, if not create it
                if (Session[UsernameKey] != null)
                {
                    username = (string)Session[UsernameKey];
                }
                return username;
            }

        }

        public void LoginUser(string username)
        {
            Session[UsernameKey] = username;
        }

        public void LogoutUser()
        {
            Session.Abandon();
        }
    }
}