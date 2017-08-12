using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodDonationMvcApp.Models
{
    public class UserReg
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50, MinimumLength = 4)]
        [Required(ErrorMessage = "Please Provide Your Name")]
        public string Name { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please Provide Your Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Remote("CheakEmail", "UserReg")]
        public string Email { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please Provide Your Phone")]
        public string Phone { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(500)]
        public string Address { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(10)]
        [Required(ErrorMessage = "Please Provide Your Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please Provide Your Division")]
        public int DivisionId { get; set; }
        public int DistrictsId { get; set; }
        [Required(ErrorMessage = "Please Provide Your Blood Group")]
        public int BloodId { get; set; }
        public virtual Division Division { get; set; }
        public Districts Districts { get; set; }

        public virtual BloodGroups Blood { get; set; }
    }
}