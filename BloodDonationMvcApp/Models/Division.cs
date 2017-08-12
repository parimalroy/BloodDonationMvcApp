using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodDonationMvcApp.Models
{
    public class Division
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Provide Division")]
        [Column(TypeName="varchar")]
        [Remote("CheakDivision", "Division")]
        public string DivisionName { get; set; }
        public virtual List<Districts> Districts { get; set; }
        //public virtual List<UserRegNo> UserRegno { get; set; }
    }
}