using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitites;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class AccountsDbContext : DbContext 
    {
        public AccountsDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
            
        }
       
        public DbSet<Account> AccountName { get; set; }
        public DbSet<Account> password { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>().ToTable("Account"); //truong account se anh xa toi bang Account

            //seed to Account
            //.....
            // print in database: Add-Migration Initial.
        }

    }
}


