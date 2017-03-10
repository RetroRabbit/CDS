using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using authenticate.cdsonline.co.za.Entities;
using authenticate.cdsonline.co.za.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace authenticate.cdsonline.co.za
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        static AuthContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<authenticate.cdsonline.co.za.AuthContext, Migrations.Configuration>());
        }

        public AuthContext()
            : base("AuthContext")
        { 
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<ClientUsers> ClientUsers { get; set; }
    }
}