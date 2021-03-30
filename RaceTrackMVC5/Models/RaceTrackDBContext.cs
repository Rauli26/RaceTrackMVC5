namespace RaceTrackMVC5.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using RaceTrackMVC5.Models;
    using RaceTrackMVC5.Models.Composition;

    public class RaceTrackDBContext : DbContext
    {
        // Your context has been configured to use a 'RaceTrackDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'RaceTrackMVC5.Models.RaceTrackDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'RaceTrackDBContext' 
        // connection string in the application configuration file.
        public RaceTrackDBContext()
            : base("name=RaceTrackDBContext")
        {
            //Database.SetInitializer(new RaceTrackDBContextSeeder());
            //Database.SetInitializer<RaceTrackDBContext>(new RaceTrackDBContextSeeder());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }


        

        public virtual DbSet<Vehicles> Vehicles { get; set; }
        
        public virtual DbSet<Composition.CarInspection> CarInspection { get; set; }

        public virtual DbSet<Composition.TruckInspection> TruckInspection { get; set; }

        public System.Data.Entity.DbSet<RaceTrackMVC5.ViewModel.AddVehicleViewModel> AddVehicleViewModels { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}





    





}