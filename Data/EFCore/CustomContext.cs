using Data.EFCore.Configurations;
using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Data.EFCore
{
    public class CustomContext : DbContext
    {
        public CustomContext(DbContextOptions options) : base(options)
        {

        }



        #region DbSets

        public DbSet<City> Cities { get; set; }
        public DbSet<Town> Towns { get; set; }

        #endregion

        //for create migration folder Type this path => Add-Migration Initial -OutputDir "EFCore/Migrations"

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Configurations
            modelBuilder.ApplyConfiguration(new TownConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            #endregion

            /*Before migration right click json file, select properties from menu and Copy To Output Directory set Copy Always and execute migration */

            #region City And Town DataSeed

            string cityJson = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JsonFiles", "City.json"));

            List<City> cityList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<City>>(cityJson);


            modelBuilder.Entity<City>().HasData(cityList);

            string townJson = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JsonFiles", "Town.json"));
            List<Town> townList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Town>>(townJson);

            modelBuilder.Entity<Town>().HasData(townList);
            #endregion

        }
    }
}
