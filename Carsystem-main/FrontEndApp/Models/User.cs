using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace FrontEndApp.Models
{
    public class User
    {
        
        public int UserId { get; set; }
        [Required(ErrorMessage = "This Field is Required.")]

        public string UserName { get; set; }
        [Required(ErrorMessage = "This Field is Required.")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "This Field is Required.")]
        [DataType(DataType.PhoneNumber)]
        public string UserContact { get; set; }
        [Required(ErrorMessage = "This Field is Required.")]
        [DataType(DataType.Password)]

        public string UserPassword { get; set; }
        [Required(ErrorMessage = "This Field is Required.")]
        [Compare("UserPassword",ErrorMessage ="Password doesn't match.")]
        public string UserConfirmPassword { get; set; }
        [Required(ErrorMessage = "This Field is Required.")]

        public string UserCity { get; set; }

    }
}