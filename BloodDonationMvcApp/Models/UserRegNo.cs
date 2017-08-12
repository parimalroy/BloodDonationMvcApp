using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodDonationMvcApp.Models
{
    public class UserRegNo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Gender { get; set; }
        public int DivisionId { get; set; }
        public int DistrictsId { get; set; }
        public int BloodId { get; set; }
        public virtual Division Division { get; set; }
        public virtual Districts Districts { get; set; }
        public virtual BloodGroup Blood { get; set; }
    }
}