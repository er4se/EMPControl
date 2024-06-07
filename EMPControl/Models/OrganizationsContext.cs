using Microsoft.EntityFrameworkCore;

namespace EMPControl.Models
{

    //Класс контекста базы данных, подключается к БД (MSSQL)

    class OrganizationsContext : DbContext
    {
        public DbSet<OrganizationModel> Organizations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-42P08Q2;DataBase=EMPDataBase;Trusted_Connection=Yes;TrustServerCertificate=True;");
        }
    }
}
