using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MamidiMovies.Models
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "You must create a username.")]
        [Display(Name = "User Name")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Your password must contain at least 8 characters that consist of an upper-case letter, a lower-case letter, a number, and a symbol.")]
        [Display(Name = "Password")]
        [RegularExpression(@"(?=^.{8,}$)(?=.*\d)(?=.*[!@#$%^&*]+)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Your password does not meet the requirements.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "You must confirm your password.")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Your passwords do not match.")]
        [Display(Name = "Password Confirmation")]
        public string ConfirmPassword { get; set; }

    }
}