using MamidiMovies.DAL;
using MamidiMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MamidiMovies.Controllers
{
    public class LoginController : MamidiMoviesController
    {
        private readonly ILoginDAL loginDAL;
        private const string UsernameKey = "UsernameKey";
        public LoginController(ILoginDAL loginDAL)
        {
            this.loginDAL = loginDAL;
        }
        public LoginController()
        {

        }

        //[HttpGet]
        //public ActionResult Login()
        //{
        //    if (IsAuthenticated)
        //    {
        //        return RedirectToAction("MoviePage", "MoviePage");
        //    }
        //    else
        //    {
        //        var model = new LoginViewModel();
        //        return View("Login", model);
        //    }

        //}

        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            //if (IsAuthenticated)
            //{
            //    return RedirectToAction("MoviePage", "MoviePage");
            //}

            if (ModelState.IsValid)
            {
                var currentUser = loginDAL.GetUsernamePassword(model.Username, model.Password);
                if (currentUser == null)
                {
                    ModelState.AddModelError("Username", "The username or password is not correct. Please try again.");
                    return View("Login", model);
                }
                LoginUser(currentUser.Username);

                return RedirectToAction("MoviePage", "MoviePage");
            }
            return View("Login", model);
        }
        public ActionResult Logout()
        {
            LogoutUser();
            return RedirectToAction("Index", "Home");
        }

        [ChildActionOnly]
        public ActionResult GetAuthenticatedUser()
        {
            LoginViewModel model = null;

            if (IsAuthenticated)
            {
                model = loginDAL.GetUsername(CurrentUser);
            }

            return PartialView("_PartialLoginLogoutView", model);
        }
    }
}