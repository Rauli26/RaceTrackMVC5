
using RaceTrackMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RaceTrackMVC5.Models.Composition;

namespace RaceTrack.Models
{
    //Question: Why we are using this IVehicleRepository in between why we dont directly programmed against SQLVehicleRepository?

    //Answer: We can use SQLVehicleRepository without the Interface if we want but if we do that we can not use dependency injection 
    //and as a result our application will be extremely difficult to change and maintained. Unit testing also become very difficult.

    //Throughout our application we will be programming against the interface IVehicleRepository and not the concrete implementation SQLVehicleRepository.
    //This interface abstraction allows us to use dependency injection which in turn makes our application flexible and easily unit testable.
    public class SQLVehicleRepository : IVehicleRepository
    {
        private List<Vehicles> _vehicleList;

        private readonly RaceTrackDBContext context;
        public SQLVehicleRepository(RaceTrackDBContext context)
        {
            this.context = context;
        }
        //public Vehicles GetVehicle(int Id)
        //{
        //    return context.Vehicles.Find(Id);
        //}

        public IEnumerable<Vehicles> GetAllVehicle()
        {
            return context.Vehicles;
          //return json(new { data = context.Vehicles.ToList() }, JsonRequestBehavior.AllowGet);
        }

        public IEnumerable<CarInspection> GetCarInspection()
        {
            return context.CarInspection;
        }

        public IEnumerable<TruckInspection> GetTruckInspection()
        {
            return context.TruckInspection;
        }

        public string PrintHelloWorld()
        {
            return "Hello World";
        }

        public Vehicles AddVehicle(Vehicles vehicles)
        {
            context.Vehicles.Add(vehicles);
            context.SaveChanges();
            return vehicles;
        }

        public CarInspection AddCarInspection(CarInspection carInspection)
        {
            context.CarInspection.Add(carInspection);
            context.SaveChanges();
            return carInspection;
        }

        public TruckInspection AddTruckInspection(TruckInspection truckInspection)
        {
            context.TruckInspection.Add(truckInspection);
            context.SaveChanges();
            return truckInspection;
        }

        public Vehicles GetAllSelectedVehicle(int[] Id)
        {
            throw new NotImplementedException();
        }
    }
}