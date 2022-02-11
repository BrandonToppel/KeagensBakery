using KeagensBakeryApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeagensBakeryApi
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUsers, ApplicationRoles, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Defining relationships using the Builder API
            builder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductsId, pc.CategoriesId });
            builder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductsId);
            builder.Entity<ProductCategory>()
                .HasOne(pc => pc.Categories)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(pc => pc.CategoriesId);
        }
    }
}
