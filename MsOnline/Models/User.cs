using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MsOnline.Models
{
    //Stanley Backlund & Jacob Hushaw
    //26 January 2020
    //CST-247
    //This is my own code
    public class User
    {
        //First Name, Last Name, Sex, Age, State, Email Address, Username, and Password

        public int id { get; set; }
        [StringLength(60,MinimumLength = 3)]
        [Required]
        public string username { get; set; }

        [StringLength(60, MinimumLength = 8)]
        [Required]
        public string password { get; set; }
        
        [Required]
        public string firstname { get; set; }

        [Required]
        public string lastname { get; set; }

        [Required]
        public string gender { get; set; }

        [Required]
        public int age { get; set; }

        [Required]
        public string state { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

    }
}