﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarSystemProjectAdmin.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CarSystemEntities1 : DbContext
    {
        public CarSystemEntities1()
            : base("name=CarSystemEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdminUser> AdminUsers { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarSoldHistory> CarSoldHistories { get; set; }
        public virtual DbSet<UserData> UserDatas { get; set; }
    }
}
