using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using HiWork.Models.CompanyInformation;
using HiWork.Models.Order;
using HiWork.Models.Product;
using HiWork.Models.SP_User;


namespace HiWork.Models
{
    public class HiWorkDbContext : DbContext
    {
        public HiWorkDbContext() : base("Cn")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<PCSMSDbContext, Migrations.Configuration>("Cn"));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        #region User DbSet
        public DbSet<User> User { get; set; }
        //public DbSet<CP_Device_Group> CP_Device_Group { get; set; }
        //public DbSet<CP_Device_License> CP_Device_License { get; set; }
        //public DbSet<CP_Device_Schedule> CP_Device_Schedule { get; set; }
        //public DbSet<CP_License> CP_License { get; set; }
        //public DbSet<CP_License_Period> CP_License_Period { get; set; }
        //public DbSet<CP_Profile> CP_Profile { get; set; }
        //public DbSet<CP_ScreenCapture> CP_ScreenCapture { get; set; }
        //public DbSet<CP_Token> CP_Token { get; set; }
        //public DbSet<CP_User> CP_User { get; set; }
        //public DbSet<CP_User_LSession> CP_User_LSession { get; set; }
        #endregion

        #region Customer Related
        public DbSet<ProductInfo> Product { get; set; }
        public DbSet<Order.Order> Order { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        #endregion

        #region Company Information

        public DbSet<IndustryCategory> IndustryCategory { get; set; }
        public DbSet<Industry> Industry { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyCities> CompanyCities { get; set; }
        public DbSet<CompanyIndustries> CompanyIndustries { get; set; }

        #endregion
    }
}
