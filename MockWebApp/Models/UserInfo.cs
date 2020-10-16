using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MockWebApp.Models
{
    public class UserInfo
    {
       
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Enter username")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Password not long enough")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Enter email address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }


        [Display(Name = "Confirm Email")]
        [Compare("Email", ErrorMessage = "Emails do not match")]
        public string ConfirmEmail { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Enter first name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Enter last name")]
        public string LastName { get; set; }

        [Display(Name = "Street")]
        [Required(ErrorMessage = "Enter street or P.O. box")]
        public string Street { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "Enter state")]
        public string State { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Enter city")]
        public string City { get; set; }

        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "Enter zip code")]
        public int ZipCode { get; set; }

        [Display(Name = "Birthday")]
        [Required(ErrorMessage = "Enter birthday")]
        public string Bday { get; set; }
       
    }
}