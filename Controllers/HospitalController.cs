using HospitalManagementSystem.Models;
using HospitalManagementSystem.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Controllers
{
    public class HospitalController : Controller
    {
        private readonly IHospitalRepositiory hospitalRepositiory;
        private readonly IHostingEnvironment hostingEnvironment;

        public HospitalController(IHospitalRepositiory hospitalRepositiory,
            IHostingEnvironment hostingEnvironment)
        {
            this.hospitalRepositiory = hospitalRepositiory;
            this.hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult Index(string name)
        {
            var lsthos = hospitalRepositiory.GetHospitals(name);
            ViewBag.HosName = name;
            return View(lsthos);
        }

        [HttpGet]
        public IActionResult Details(int? HospitalId)
        {
            Hospital hos = hospitalRepositiory.getHospital(HospitalId.Value);
            return View(hos);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(HospitalAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);

                Hospital newHospital = new Hospital
                {
                    Name = model.Name,
                    Email = model.Email,
                    Mobile = model.Mobile,
                    City = model.City,
                    Description = model.Description,
                    Photo = uniqueFileName
                };
                hospitalRepositiory.Add(newHospital);
               
                return RedirectToAction("details", new { HospitalId = newHospital.HospitalId });
            }

            return View();
        }
        private string ProcessUploadedFile(HospitalAddViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Hospital hospital = hospitalRepositiory.getHospital(id);
            HospitalEditViewModel employeeEditViewModel = new HospitalEditViewModel
            {
                Id = hospital.HospitalId,
                Name = hospital.Name,
                Email = hospital.Email,
                Mobile= hospital.Mobile,
                City= hospital.City,
                Description = hospital.Description,
                ExistingPhotoPath = hospital.Photo
            };
            return View(employeeEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(HospitalEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Hospital hospital = hospitalRepositiory.getHospital(model.Id);
                hospital.Name = model.Name;
                hospital.Email = model.Email;
                hospital.City = model.City;
                hospital.Description = model.Description;
                hospital.Mobile = model.Mobile;
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                            "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    hospital.Photo = ProcessUploadedFile(model);

                }

                hospitalRepositiory.Update(hospital);
                return RedirectToAction("index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult delete(int id)
        {
            //Employee employee = _employeeRepository.GetEmployee(id);
            hospitalRepositiory.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
