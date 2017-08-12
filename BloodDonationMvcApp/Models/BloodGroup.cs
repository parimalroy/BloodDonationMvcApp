using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodDonationMvcApp.Models
{
    public class BloodGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<UserRegNo> UserRegno { get; set; }
    }
}