using RaceTrackMVC5.Models.Composition;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RaceTrackMVC5.Models
{
    public class Vehicles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleId { get; set; }
        [Required]
        [Display (Name = "Vehicle Name")]
        public string VehicleName { get; set; }
        [Required]
        [Display (Name ="Vahicle Type")]
        public string VehicleType { get; set; }


        /// <summary>
        /// Properties of claases which will be composed 
        /// Composit classes life time will depend on the parent class life(VehicleInspection)
        /// </summary>
        //public CarInspection CarInspection { get; set; }
        //public TruckInspection TruckInspection { get; set; }

        ///// <summary>
        ///// Initializing composite object
        ///// </summary>
        ///// <param name="vehicleType"></param>
        ///// <param name="tierWear"></param>
        ///// <param name="hasTowStrap"></param>
        //public void InitializeCarInspection(int tierWear, bool hasTowStrap)
        //{

        //    this.CarInspection.AcceptableTireWear = tierWear;
        //    this.CarInspection.HasTowStrap = hasTowStrap;
        //}

        ///// <summary>
        ///// Initializing composite object
        ///// </summary>
        ///// <param name="vehicleType"></param>
        ///// <param name="lift"></param>
        ///// <param name="hasTowStrap"></param>
        //public void InitializeTruckInspection(int lift, bool hasTowStrap)
        //{

        //    this.TruckInspection.AcceptableLift = lift;
        //    this.TruckInspection.HasTowStrap = hasTowStrap;
        //}






        //public IList<VehiclesTrack> VehicleTracks { get; set; }

    }


}
