using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL
{
    public partial class ApplicationContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<User> User { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<Tag> Tag { get; set; }

        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) :base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) optionsBuilder.UseNpgsql("DataBase");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }        
        
    }
}
