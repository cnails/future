
using Microsoft.EntityFrameworkCore;

namespace SignalR_Vuejs__Demo.Models
{
    public class AppDbContext : DbContext
    {
        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PredZapBD> PredZapBD { get; set; }
        public DbSet<Times> Times { get; set; }
        public DbSet<windows> Windows { get; set; }

        public DbSet<Holiday> Holidays { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        /*UID=PredUser; PWD=1qaz@WSX;*/
        

        {

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PredzapDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        //protected override void onmodelcreating(Modelbuilder modelbuilder)
        //{
        //    base.onmodelcreating(modelbuilder);

        //    modelbuilder.entity<predzapbd>().hasdata(new predzapbd
        //    {
        //        id = 1,
        //        fio = "петров иван",
        //        time = "8:30",
        //        leading = "лукашенко",
        //        date = "17.01.2020",
        //        edit = "create: 15:30, user: yubelyushin"
        //    });
        //}
    }
}
