using CRUD_Operation_withASP.NET.DAL;
using CRUD_Operation_withASP.NET.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Operation_withASP.NET.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDal db = new EmployeeDal();
        // GET: EmployeeController
        public ActionResult Index()
        {
            var model = db.GetAllEmployees();
            return View(model);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var model = db.GetEmployeeById(id);
            return View(model);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                var result = db.AddEmployee(emp);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = db.GetEmployeeById(id);
            return View(result);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                var result = db.UpdateEmployee(emp);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = db.GetEmployeeById(id);
            return View(result);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                var result = db.DeleteEmployee(id);
                if(result==1)
                return RedirectToAction(nameof(Index));
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
