using Lib.Entity;
using Lib.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Invoice> Invoice { get; set; }

        public DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public DbSet<Topping> Topping { get; set; }
        public DbSet<ToppingDetailInvoice> ToppingDetail { get; set; }
        public DbSet<ToppingDetailCart> ToppingDetailCart { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<InvoiceDetail>().HasKey(table => new {
                table.ID_invoice,
                table.ID_Food
            });
            builder.Entity<Cart>().HasKey(table => new {
                table.SDT,
                table.ID_Food
            });
            builder.Entity<ToppingDetailInvoice>().HasKey(table => new {
                table.ID_invoice,
                table.ID_Food,
                table.ID_Topping
            });
            builder.Entity<ToppingDetailCart>().HasKey(table => new {
                table.SDT,
                table.ID_Food,
                table.ID_Topping
            }); 
            
            base.OnModelCreating(builder);
        }
    }
}
