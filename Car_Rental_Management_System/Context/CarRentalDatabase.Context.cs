//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Car_Rental_Management_System.Context
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CarRentalManagementsystemEntities : DbContext
    {
        public CarRentalManagementsystemEntities()
            : base("name=CarRentalManagementsystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CAR> CARs { get; set; }
        public virtual DbSet<CARMAKE> CARMAKEs { get; set; }
        public virtual DbSet<CARMODEL> CARMODELs { get; set; }
        public virtual DbSet<CARRENT> CARRENTs { get; set; }
        public virtual DbSet<CARRENTAL> CARRENTALs { get; set; }
        public virtual DbSet<CARTYPE> CARTYPEs { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMERs { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENTs { get; set; }
        public virtual DbSet<MANAGER> MANAGERs { get; set; }
    }
}
