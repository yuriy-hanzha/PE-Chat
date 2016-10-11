using Microsoft.AspNet.Identity.EntityFramework;
using PE_Chat.Data.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PE_Chat
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
             :base("AppConnString")
        {

        }

        public DbSet<Message> Messages { get; set; }

        static ApplicationDbContext()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}