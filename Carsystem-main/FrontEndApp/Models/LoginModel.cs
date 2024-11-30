using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace FrontEndApp.Models
{
    public class LoginModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="This Field is Required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "This Field is Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "This Field is Required.")]

        public string name { get; set; }
    }
}