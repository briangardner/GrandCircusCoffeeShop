using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrandCircusCoffeeShop.Models
{
    public class Registration
    {
        [MinLength(2)]
        [Required]
        [MaxLength(50)]
        [Display(Name = "First Name")]
        [RegularExpression("\\D+", ErrorMessage = "Cannot have digits")]
        public string FirstName { get; set; }

        [MinLength(2)]
        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        [RegularExpression("\\D+", ErrorMessage = "Cannot have digits")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [MinLength(6)]
        [Compare("Password")]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Favorite Coffee")]
        public string FavoriteCoffee { get; set; }

        [Required]
        [Display(Name = "Day you were born")]
        public string BirthDate { get; set; }
    }
}