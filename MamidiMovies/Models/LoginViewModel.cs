using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MamidiMovies.Models
{
    public class LoginViewModel
    { 
            public int LoginId { get; set; }
            [Required(ErrorMessage = "Your username is required.")]
            [Display(Name = "User Name:")]
            public string Username { get; set; }
            [Required(ErrorMessage = "Your password is required.")]
            [Display(Name = "Password:")]
            public string Password { get; set; }
       
    }
}