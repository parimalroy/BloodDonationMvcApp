using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodDonationMvcApp.Models
{
    public class UserAccount
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please Provide Your Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Remote("CheakEmail", "UserReg")]
        public string Email { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50, MinimumLength = 4)]
        [Required(ErrorMessage = "Please Provide Your Name")]
        public string Name { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50, MinimumLength = 4)]
        [Required(ErrorMessage = "Please Provide Your Password")]
        public string Password { get; set; }
    }
}