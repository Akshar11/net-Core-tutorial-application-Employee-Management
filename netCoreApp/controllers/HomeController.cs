using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using netCoreApp.models;
using netCoreApp.viewModels;

namespace netCoreApp.controllers
{

    //[Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository,
            IWebHostEnvironment hostEnvironment)

        {
            _employeeRepository = employeeRepository;
            _hostingEnvironment = hostEnvironment;
        }

        //  [Route("~/Home")]// Home
        //  [Route("~/")] //   starting ignored
        //    [Route("[action]")] // Home/Index
        public ViewResult Index()
        {
            IEnumerable<Employee> emps = _employeeRepository.getAllEmployee();
            return View(emps);
        }

        //   [Route("{id?}")]
        public ViewResult Detail(int? id)
        {
            Employee model = _employeeRepository.GetEmployeeById(id ?? 1);
            HomeDetailViewModel homeDetailViewModel = new HomeDetailViewModel() { Employee = model, title = "BAPS" };
            return View(homeDetailViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFilename = GetImage(model);

                Employee newEmp = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFilename
                };

                _employeeRepository.Add(newEmp);
                return RedirectToAction("detail", new { id = newEmp.Id });
            }

            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployeeById(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
            {
                Id = employee.Id,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotoPath = employee.PhotoPath,
                Name = employee.Name
            };
            return View(employeeEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel employeeEditViewModel)
        {
            if (ModelState.IsValid)
            {
                Employee emp = _employeeRepository.GetEmployeeById(employeeEditViewModel.Id);
                emp.Name = employeeEditViewModel.Name;
                emp.Email = employeeEditViewModel.Email;
                emp.Department = employeeEditViewModel.Department;

                if (employeeEditViewModel.Photo != null)
                {
                    if (employeeEditViewModel.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", employeeEditViewModel.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    emp.PhotoPath = GetImage(employeeEditViewModel);
                }
                _employeeRepository.Update(emp);
                return RedirectToAction("detail", new { id = emp.Id });
            }

            return View();
        }

        private string GetImage(EmployeeCreateViewModel employeeEditViewModel)
        {
            string uniqueFilename = null;
            if (employeeEditViewModel.Photo != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFilename = Guid.NewGuid().ToString() + "_" + employeeEditViewModel.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFilename);
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    employeeEditViewModel.Photo.CopyTo(fs);
                }

            }

            return uniqueFilename;
        }
    }
}