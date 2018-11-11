using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CORE_ADO_CRUD.DAL;
using CORE_ADO_CRUD.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CORE_ADO_CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();

        // GET: /<controller>/

        #region Index

        public IActionResult Index()
        {
            List<Employee> listEmployee = new List<Employee>();
            listEmployee = objemployee.GetAllEmployees().ToList();

            return View(listEmployee);

        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Employee employee)
        {
            if (ModelState.IsValid)
            {
                objemployee.AddEmployee(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            Employee employee = objemployee.GetEmployeeData(id);
            if (employee==null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Employee employee)
        {
            if (id!= employee.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objemployee.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        #endregion

        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id== null)
            {
                return NotFound();
            }
            Employee employee = objemployee.GetEmployeeData(id);
            if (employee==null)
            {
                return NotFound();
            }
            return View(employee);
        }
        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();             
            }
            Employee employee = objemployee.GetEmployeeData(id);

            if (employee==null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            objemployee.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        #endregion

    }
}
