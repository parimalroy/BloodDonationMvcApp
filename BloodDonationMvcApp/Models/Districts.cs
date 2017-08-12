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
    public class Districts
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Provide Division Name")]
        [DisplayName("Department Name")]
        public int DivisionId { get; set; }
         [Required(ErrorMessage = "Please Provide Districts Name")]
         [Column(TypeName = "varchar")]
         [DisplayName("Districts Name")]
         [Remote("CheakDistricts", "Distircts")]
        public string DistrictsName { get; set; }
        public virtual Division Division { get; set; }
        public virtual List<UserReg> UserRegno { get; set; }
    }
}