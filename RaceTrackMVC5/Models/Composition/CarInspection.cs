using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RaceTrackMVC5.Models.Composition
{

    /// <summary>
    /// I am using composition for vehicle inspection as that will Allow a class to contain object instances in other classes so they can be used to perform actions related to the class (an “has a” relationship)
    /// </summary>

    //Question:Why to choose composition over inheritance?

    //Answer: I prefer composioon over inheritance because, In Inheritance One class can use features from another class to extend its functionality (an “Is a” relationship) On the other hand
    //Composition Allow a class to contain object instances in other classes so they can be used to perform actions related to the class (an “has a” relationship).
    //Life of CarInspection or TruckInspection will depend on life of Vehicle.
    //Composioon uses one to many relation(Polymorphism). So in future If we have some other Vehicle type with some different kind of inspection or
    //if I have to add some more criteria just for one type of vehicle, I can change particular vehicle class, I dont need to make changes to base class.  
    //It will be easy to add as our code will be loosely coupled. 
    public class CarInspection 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarInspectionId { get; set; }

        [Range(0, 85)]
        [Required]
        [Display(Name = "Tire Wear")]
        public int AcceptableTireWear { get; set; }


        public bool IsTrue => true;

        [Required]
        [Display(Name = "Tow Strap")]
        [System.ComponentModel.DataAnnotations.Compare(nameof(IsTrue), ErrorMessage = "Vehicle must have tow strap for the towing of a freely-moving vehicle behind another vehicle.")]
        public bool HasTowStrap { get; set; }

        public int VehicleId { get; set; }

        public Vehicles vehicles { get; set; }

        public void InitializeVehicles(string vehicleName, string vehicleType)
        {

            this.vehicles.VehicleName = vehicleName;
            this.vehicles.VehicleType = vehicleType;
        }


    }
}