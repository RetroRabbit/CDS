namespace authenticate.cdsonline.co.za.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using authenticate.cdsonline.co.za.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<authenticate.cdsonline.co.za.AuthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "authenticate.cdsonline.co.za.AuthContext";
        }

        protected override void Seed(authenticate.cdsonline.co.za.AuthContext context)
        {
            //  This method will be called after migrating to the latest version.

            if (context.Clients.Count() > 0)
            {
                return;
            }

            context.Clients.AddRange(BuildClientsList());
            context.SaveChanges();
        }

        private static List<Client> BuildClientsList()
        {

            List<Client> ClientsList = new List<Client> 
            {
                new Client
                { Id = "cdsonline.co.za", 
                    Secret= Helper.GetHash("CDSweb_CD$0nl1n3"), 
                    Name="C2A CDS hosted Application", 
                    ApplicationType =  Models.ApplicationTypes.JavaScript, 
                    Active = true, 
                    RefreshTokenLifeTime = 1440, // Timespan in minutes - 1440 = 1 Days
                    AllowedOrigin = "http://accounting.cdsonline.co.za"
                },
                new Client
                { Id = "CDS.Client.Desktop", 
                    Secret=Helper.GetHash("CDSDesktop_CD$0nl1n3"), 
                    Name="CDS Desktop Application", 
                    ApplicationType = Models.ApplicationTypes.NativeConfidential, 
                    Active = true, 
                    RefreshTokenLifeTime = 525600, // Timespan in minutes - 525600 = 1 Year
                    AllowedOrigin = "*"
                }
            };

            return ClientsList;
        }
    }
}
