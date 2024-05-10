using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using PortfolioNoIdentityAPI.Models;

namespace PortfolioNoIdentityAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<PortairLogistixContact> PortairLogistixContacts { get; set; }

        public DbSet<PortfolioContact> PortfolioContacts { get; set; }

        public DbSet<TroubleshootingService> TroubleshootingServices { get; set; }

        public DbSet<TroubleshootingServiceType> TroubleshootingServiceTypes { get; set; }

        public DbSet<TroubleshootingCustomerIssue> TroubleshootingCustomerIssues { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected string SeedJSONData(string JSONData)
        {
            string converted = "";
            using (StreamReader r = new StreamReader(@"JSONSeedData/" + JSONData))
            {
                string json = r.ReadToEnd();
                converted = JsonConvert.SerializeObject(json);
            }
            return converted;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TroubleshootingService>().ToTable(nameof(TroubleshootingService));

            //Start seed Troubleshootingservice Table
            modelBuilder.Entity<TroubleshootingService>().HasData(
                new TroubleshootingService
                {
                    Id = 1,
                    ServiceName = "TV"
                },
                new TroubleshootingService 
                {
                    Id = 2,
                    ServiceName = "Internet"
                },
                new TroubleshootingService
                {
                    Id = 3,
                    ServiceName = "Phone"
                },
                new TroubleshootingService
                {
                    Id = 4,
                    ServiceName = "Mobile"
                });
            //End Troubleshootingservice seed

            modelBuilder.Entity<PortairLogistixContact>().Property(x => x.DateInsertedTimestamp).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<PortfolioContact>().Property(x => x.DateInsertedTimestamp).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TroubleshootingCustomerIssue>().Property(x => x.DateInsertedTimestamp).HasDefaultValueSql("GETDATE()");

            // 1:1 Relationship Definition start          
            modelBuilder.Entity<TroubleshootingServiceType>(
                entity => {
                    entity.HasOne(d => d.TroubleshootingServices)
                          .WithOne(p => p.TroubleshootingServiceTypes)
                          .HasForeignKey<TroubleshootingServiceType>(f => f.ServiceId);
                });
            //RelationShip Definition End

            //Seed JSON Data Start
            modelBuilder.Entity<TroubleshootingServiceType>().HasData(
                new TroubleshootingServiceType
                {
                    Id = 1,
                    ServiceId = 1,
                    ServiceTypeDescription = SeedJSONData("tv.json")
                },
                new TroubleshootingServiceType
                {
                    Id = 2,
                    ServiceId = 2,
                    ServiceTypeDescription = SeedJSONData("internet.json")
                },
                new TroubleshootingServiceType
                {
                    Id = 3,
                    ServiceId = 3,
                    ServiceTypeDescription = SeedJSONData("phone.json")
                },
                new TroubleshootingServiceType
                {
                    Id = 4,
                    ServiceId = 4,
                    ServiceTypeDescription = SeedJSONData("mobile.json")   
                }
                );
            //Seed JSON Data End
        }
    }
}
