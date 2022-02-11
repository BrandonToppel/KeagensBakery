using System;
using System.Collections.Generic;
using System.Text;
using KeagensBakeryWebAPI.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KeagensBakeryWebAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUsers, AppRoles, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<Microsoft.AspNetCore.Identity.IdentityUser>().ToTable("MyUsers").Property(p => p.Id).HasColumnName("UserId");
            //builder.Entity<AppUsers>().ToTable("MyUsers").Property(p => p.Id).HasColumnName("UserId");
            //builder.Entity<IdentityUserRole>().ToTable("MyUserRoles");
            //builder.Entity<IdentityUserLogin>().ToTable("MyUserLogins");
            //builder.Entity<IdentityUserClaim>().ToTable("MyUserClaims");
            //builder.Entity<Microsoft.AspNetCore.Identity.IdentityRole>().ToTable("MyRoles");
        }
    }
}
