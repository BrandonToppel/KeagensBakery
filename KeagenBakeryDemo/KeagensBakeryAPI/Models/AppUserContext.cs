using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeagensBakeryAPI.Models
{
    public class AppUserContext : IdentityDbContext
    {
        public AppUserContext(DbContextOptions<AppUserContext> options)
            :base(options)
        {

        }

    }
}
