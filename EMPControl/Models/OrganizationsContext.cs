using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace EMPControl.Models
{
    class OrganizationsContext : DbContext
    {
        public DbSet<OrganizationModel> Organizations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-42P08Q2;DataBase=EMPDataBase;Trusted_Connection=Yes;TrustServerCertificate=True;");
        }
    }
}
