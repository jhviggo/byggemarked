using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace byggemarked.Model
{
    public class HardwareStoreDbContext : DbContext
    {
        public HardwareStoreDbContext() : base("name=HardwareStoreDbContext") { }
        public DbSet<Hardware> Hardware { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
    }
}
