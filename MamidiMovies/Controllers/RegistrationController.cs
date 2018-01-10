using MamidiMovies.DAL;
using MamidiMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MamidiMovies.Controllers
{
    public class RegistrationController : MamidiMoviesController
    {
        private readonly ILoginDAL loginDAL;
        private const string UsernameKey = "UsernameKey";
        public RegistrationController(ILoginDAL loginDAL)
        {
            this.loginDAL = loginDAL;
        }
        public RegistrationController()
        {

        }

        [HttpGet]
        public ActionResult Registration()
        {
            if (IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var model = new RegistrationViewModel();
                return View("Registration", model);
            }
        }
        [HttpPost]
        public ActionResult Registration(RegistrationViewModel model)
        {
            if (IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                var user = loginDAL.GetUsername(model.Username);
                var registeredUser = new LoginViewModel
                {
                    Username = model.Username,
                    Password = model.Password,

                };

                loginDAL.RegisterUser(registeredUser);
                return RedirectToAction("Login", "Login");
            }
            return View("Registration", model);
        }

    }
}