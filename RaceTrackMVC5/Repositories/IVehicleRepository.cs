using RaceTrackMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceTrackMVC5.Models.Composition;

namespace RaceTrack.Models
{
    public interface IVehicleRepository
    {
        //Vehicles GetVehicle(int Id);
        Vehicles GetAllSelectedVehicle(int[] Id);
        string PrintHelloWorld();
        IEnumerable<Vehicles> GetAllVehicle();
        IEnumerable<CarInspection> GetCarInspection();
        IEnumerable<TruckInspection> GetTruckInspection();

        Vehicles AddVehicle(Vehicles vehicles);
        CarInspection AddCarInspection(CarInspection carInspection);


        TruckInspection AddTruckInspection(TruckInspection truckInspection);
        
    }
}
