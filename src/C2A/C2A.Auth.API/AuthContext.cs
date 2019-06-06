using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CDS.C2A.Auth.API.Entities;
using CDS.C2A.Auth.API.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CDS.C2A.Auth.API
{
    public class AuthContext : IdentityDbContext<ApplicationUser>
    {
        static AuthContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CDS.C2A.Auth.API.AuthContext, Migrations.Configuration>());
        }

        public AuthContext()
            : base("AuthContext")
        { 
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}