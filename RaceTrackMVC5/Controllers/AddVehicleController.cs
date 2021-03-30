using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RaceTrack.Models;
using RaceTrackMVC5.Models;
using RaceTrackMVC5.Models.Composition;
using RaceTrackMVC5.ViewModel;

namespace RaceTrackMVC5.Controllers
{

    //AddVehicleController is dependant on IVehicleRepository for retrieving Vehicle data.
    public class AddVehicleController : Controller
    {
        //Get /home/index
        //public ActionResult Index()
        //{
        //    return View();
        //}



        private IVehicleRepository _vehicleRepository;

        //Instead of the AddVehicleController creating a new instance of an implemention of IVehicleRepository, we are injecting IVehicleRepository instance into the HomeController using the constructor.
        //This is called constructor injection, as we are using the constructor to inject the dependency.

        //Question: Why can't we simply create an instance of SQLVehicleRepository class in the AddVehicleController using the new keyword?
        //Answer: Using the new keyword to create instances of dependencies creates tight coupling and as a result our application will be difficult to change. With dependency injection we will not have this tight coupling. 

        // Inject IVehicleRepository using Constructor Injection
        public AddVehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        // GET: Vehicle
        [HttpGet]
        public ActionResult Index()
        {
            //return _vehicleRepository.PrintHelloWorld();
            //return View();
            //return _vehicleRepository.GetVehicle(1).Name;
            //var model = _vehicleRepository.GetAllVehicle();
            //return View(model);

            IndexViewModel mymodel = new IndexViewModel();
            mymodel.Vehicles = _vehicleRepository.GetAllVehicle();
            mymodel.CarInspection = _vehicleRepository.GetCarInspection();
            mymodel.TruckInspection = _vehicleRepository.GetTruckInspection();
            return View(mymodel);

            //var model = _vehicleRepository.GetAllVehicle();
            //return View(model);
        }


        //GET: AddVehicle/Create
       public ActionResult Create()
        {
            return View();
            //var model = _vehicleRepository.GetAllVehicle();
            //return View(model);
        }

        // POST: AddVehicle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "VehicleId,VehicleName,VehicleType,AcceptableTireWear,AcceptableLift,HasTowStrap")] AddVehicleViewModel addVehicleViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _vehicleRepository.AddVehicleViewModels.Add(addVehicleViewModel);
        //        _vehicleRepository.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(addVehicleViewModel);
        //}

        [HttpPost]
        public ActionResult Create(AddVehicleViewModel addVehicleViewModel)
        {
            //if (ModelState.IsValid)
            //{

                Vehicles newVehicles = new Vehicles
                {
                    //Id = model.Id,
                    VehicleName = addVehicleViewModel.VehicleName,
                    VehicleType = addVehicleViewModel.VehicleType,
                    
                };
                _vehicleRepository.AddVehicle(newVehicles);

                int latestVehicleId =  newVehicles.VehicleId;
                string vehicleType = newVehicles.VehicleType;

                if(vehicleType == "Car")
                {
                    CarInspection carInspection = new CarInspection()
                    {
                         AcceptableTireWear = addVehicleViewModel.AcceptableTireWear,
                         HasTowStrap = addVehicleViewModel.HasTowStrap,
                         VehicleId = latestVehicleId
                    };
                    _vehicleRepository.AddCarInspection(carInspection);
                }
                else
                {
                    TruckInspection truckInspection = new TruckInspection()
                    { 
                        AcceptableLift = addVehicleViewModel.AcceptableLift,
                        HasTowStrap = addVehicleViewModel.HasTowStrap,
                        VehicleId = latestVehicleId
                    };
                    _vehicleRepository.AddTruckInspection(truckInspection);
                }

                return RedirectToAction("List", new { id = newVehicles.VehicleId });

                


            }

            //else
            //    return View();
        //}






    }





    //    public class AddVehicleController : Controller
    //    {
    //        private RaceTrackDBContext db = new RaceTrackDBContext();


    //        // GET: AddVehicle
    //        public ActionResult Index()
    //        {
    //            return View(db.AddVehicleViewModels.ToList());

    //        }

    //        // GET: AddVehicle/Details/5
    //        public ActionResult Details(int? id)
    //        {
    //            if (id == null)
    //            {
    //                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //            }
    //            AddVehicleViewModel addVehicleViewModel = db.AddVehicleViewModels.Find(id);
    //            if (addVehicleViewModel == null)
    //            {
    //                return HttpNotFound();
    //            }
    //            return View(addVehicleViewModel);
    //        }

    //        // GET: AddVehicle/Create
    //        public ActionResult Create()
    //        {
    //            return View();
    //            //var model = _vehicleRepository.GetAllVehicle();
    //            //return View(model);
    //        }

    //        // POST: AddVehicle/Create
    //        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    //        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    //        [HttpPost]
    //        [ValidateAntiForgeryToken]
    //        public ActionResult Create([Bind(Include = "VehicleId,VehicleName,VehicleType,AcceptableTireWear,AcceptableLift,HasTowStrap")] AddVehicleViewModel addVehicleViewModel)
    //        {
    //            if (ModelState.IsValid)
    //            {
    //                db.AddVehicleViewModels.Add(addVehicleViewModel);
    //                db.SaveChanges();
    //                return RedirectToAction("Index");
    //            }

    //            return View(addVehicleViewModel);
    //        }

    //        // GET: AddVehicle/Edit/5
    //        public ActionResult Edit(int? id)
    //        {
    //            if (id == null)
    //            {
    //                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //            }
    //            AddVehicleViewModel addVehicleViewModel = db.AddVehicleViewModels.Find(id);
    //            if (addVehicleViewModel == null)
    //            {
    //                return HttpNotFound();
    //            }
    //            return View(addVehicleViewModel);
    //        }

    //        // POST: AddVehicle/Edit/5
    //        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    //        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    //        [HttpPost]
    //        [ValidateAntiForgeryToken]
    //        public ActionResult Edit([Bind(Include = "VehicleId,VehicleName,VehicleType,AcceptableTireWear,AcceptableLift,HasTowStrap")] AddVehicleViewModel addVehicleViewModel)
    //        {
    //            if (ModelState.IsValid)
    //            {
    //                db.Entry(addVehicleViewModel).State = EntityState.Modified;
    //                db.SaveChanges();
    //                return RedirectToAction("Index");
    //            }
    //            return View(addVehicleViewModel);
    //        }

    //        // GET: AddVehicle/Delete/5
    //        public ActionResult Delete(int? id)
    //        {
    //            if (id == null)
    //            {
    //                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //            }
    //            AddVehicleViewModel addVehicleViewModel = db.AddVehicleViewModels.Find(id);
    //            if (addVehicleViewModel == null)
    //            {
    //                return HttpNotFound();
    //            }
    //            return View(addVehicleViewModel);
    //        }

    //        // POST: AddVehicle/Delete/5
    //        [HttpPost, ActionName("Delete")]
    //        [ValidateAntiForgeryToken]
    //        public ActionResult DeleteConfirmed(int id)
    //        {
    //            AddVehicleViewModel addVehicleViewModel = db.AddVehicleViewModels.Find(id);
    //            db.AddVehicleViewModels.Remove(addVehicleViewModel);
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }

    //        protected override void Dispose(bool disposing)
    //        {
    //            if (disposing)
    //            {
    //                db.Dispose();
    //            }
    //            base.Dispose(disposing);
    //        }
    //    }
}
