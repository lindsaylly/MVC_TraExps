using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address*")]
        public string Email { get; set; }

        [Display(Name = "Password*")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must at least be 8 characters.")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password*")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The Password and Confirm Password must match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "First Name*")]
        [Required(ErrorMessage = "Required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name*")]
        [Required(ErrorMessage = "Required")]
        public string LastName { get; set; }

        [Display(Name = "Address*")]
        [Required(ErrorMessage = "Required")]
        public string Address { get; set; }

        [Display(Name = "City*")]
        [Required(ErrorMessage = "Required")]
        public string City { get; set; }

        [Display(Name = "Province*")]
        [Required(ErrorMessage = "Required")]
        public string Province { get; set; }

        [Display(Name = "Postal Code*")]
        [DataType(DataType.PostalCode)]
        [RegularExpression(@"^\\d{5}(-{0,1}\\d{4})?$|^([ABCEGHJKLMNPRSTVXYabceghjklmnprstvxy]\d[ABCEGHJKLMNPRSTVWXYZabceghjklmnprstvxy])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZabceghjklmnprstvxy]\d)$", ErrorMessage = "Invalid postal code.")]
        [Required(ErrorMessage = "Required")]
        public string Postal { get; set; }

        [Display(Name = "Country*")]
        [Required(ErrorMessage = "Required")]
        public string Country { get; set; }

        [Display(Name = "Home Phone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid phone number.")]
        public string HomePhone { get; set; }

        [Display(Name = "Business Phone*")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid phone number.")]
        public string BusinessPhone { get; set; }

        public int? AgentId { get; set; }

    }

}