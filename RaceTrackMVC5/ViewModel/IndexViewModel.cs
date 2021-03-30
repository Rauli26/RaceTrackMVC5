using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using RaceTrackMVC5.Models;
using RaceTrackMVC5.Models.Composition;

namespace RaceTrackMVC5.ViewModel
{
    public class IndexViewModel
    {
        //public IEnumerable<Vehicles> GetAllVehicle { get; set; }
        //public IEnumerable<CarInspection> GetCarInspection { get; set; }

        //public IEnumerable<TruckInspection> GetTruckInspection { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleId { get; set; }
        [Required]
        [Display(Name = "Vehicle Name")]
        public string VehicleName { get; set; }
        [Required]
        [Display(Name = "Vahicle Type")]
        public string VehicleType { get; set; }

        [Range(0, 85)]
        [Required]
        [Display(Name = "Tire Wear")]
        public int AcceptableTireWear { get; set; }

        [Range(0, 5)]
        [Required]
        public int AcceptableLift { get; set; }

        public bool IsTrue => true;

        [Required]
        [Display(Name = "Tow Strap")]
        [System.ComponentModel.DataAnnotations.Compare(nameof(IsTrue), ErrorMessage = "Vehicle must have tow strap for the towing of a freely-moving vehicle behind another vehicle.")]
        public bool HasTowStrap { get; set; }



        public IEnumerable<Vehicles> Vehicles { get; set; }
        public IEnumerable<CarInspection> CarInspection { get; set; }

        public IEnumerable<TruckInspection> TruckInspection { get; set; }
    }
}