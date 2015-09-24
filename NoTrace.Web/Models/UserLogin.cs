using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace NoTrace.Web.Models
{
    public class UserLogin
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}