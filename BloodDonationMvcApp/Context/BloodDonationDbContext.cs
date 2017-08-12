using BloodDonationMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BloodDonationMvcApp.Context
{
    public class BloodDonationDbContext:DbContext
    {
        public DbSet<Division> aDivision { get; set; }
        public DbSet<Districts> aDistricts { get; set; }
        public DbSet<BloodGroups> aBlood { get; set; }
        public DbSet<UserReg> aUserReg { get; set; }
        public DbSet<Contact> aContact { get; set; }
        public DbSet<UserAccount> aUserAccount { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}