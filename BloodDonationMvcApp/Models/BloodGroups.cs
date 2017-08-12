using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodDonationMvcApp.Models
{
    public class BloodGroups
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar")]
        [Required(ErrorMessage="Please Provide Your Blood Groups")]
        [DisplayName("Blood Group")]
        [Remote("CheakBlood", "Blood")]
        public string BloodName { get; set; }

        public virtual List<UserReg> UserRegno { get; set; }
    }
}