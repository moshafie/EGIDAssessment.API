using EGIDAssessment.Core.Domain.Entity;
using EGIDAssessment.Infrastructure.InitialDataInitializer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Infrastructure.DataContext
{
    public class EGIDAssessmentDbContext :DbContext
    {
        private readonly IConfiguration _configuration;
        DataInitializer _dataInitializer =new DataInitializer();
        public DbSet<Broker> Brokers { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public EGIDAssessmentDbContext()
        {
           
        }
        public EGIDAssessmentDbContext(IConfiguration _configuration)
        {
            
            this._configuration = _configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(
                 conectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seed Data
            modelBuilder.Entity<Stock>().HasData(_dataInitializer.GetInitialStoks());
            modelBuilder.Entity<Broker>().HasData(_dataInitializer.getInitialBroker());
            modelBuilder.Entity<Person>().HasData(_dataInitializer.getInitialPerson());

            #endregion
        }
    }
}
