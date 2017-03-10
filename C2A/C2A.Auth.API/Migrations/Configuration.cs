namespace CDS.C2A.Auth.API.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CDS.C2A.Auth.API.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<CDS.C2A.Auth.API.AuthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "CDS.C2A.Auth.API.AuthContext";
        }

        protected override void Seed(CDS.C2A.Auth.API.AuthContext context)
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
                { Id = "ngC2AAuthApp", 
                    Secret= Helper.GetHash("web_CD$0nl1n3"), 
                    Name="C2A front-end Application", 
                    ApplicationType =  Models.ApplicationTypes.JavaScript, 
                    Active = true, 
                    RefreshTokenLifeTime = 7200, 
                    AllowedOrigin = "http://accounting.cdsonline.co.za"
                },
                new Client
                { Id = "consoleApp", 
                    Secret=Helper.GetHash("console_CD$0nl1n3"), 
                    Name="Console Application", 
                    ApplicationType =Models.ApplicationTypes.NativeConfidential, 
                    Active = true, 
                    RefreshTokenLifeTime = 14400, 
                    AllowedOrigin = "*"
                }
            };

            return ClientsList;
        }
    }
}
