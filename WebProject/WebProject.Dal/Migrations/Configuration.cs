
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace WebProject.Dal.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<WebProject.Dal.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}