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
            if(ModelState.IsValid)
            {
                var registeredUser = loginDAL.GetUsername(model.Username);
                //if (registeredUser == null)
                //{
                //    ModelState.AddModelError("Username", "This username is not available, please create another username.");
                //    return View("Registration", model);
                //}
                var user = new LoginViewModel();
                loginDAL.RegisterUser(user);
                return RedirectToAction("Index", "Home");
            }
            return View("Registration", model);
        }
        
    }
}