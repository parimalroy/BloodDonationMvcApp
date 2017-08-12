using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BloodDonationMvcApp.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Please provide Your Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Column(TypeName = "varchar")]
        [StringLength(50, MinimumLength = 4)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please provide Your Subject")]
        [Column(TypeName = "varchar")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Please provide Your Message")]
        [Column(TypeName = "varchar")]
        [StringLength(500, MinimumLength = 10)]
        public string Message { get; set; }
    }
}