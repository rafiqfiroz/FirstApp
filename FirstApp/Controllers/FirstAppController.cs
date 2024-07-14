using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    public class FirstAppController : Controller
    {
        public IActionResult Index()
        {
            return View(Repository.AllEmployees);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            Repository.Create(employee);

            return View("Thanks",employee);
        }
        [HttpGet]
        public IActionResult Update(string empname)
        {
            Employee employee=Repository.AllEmployees.Where(e=>e.Name==empname).FirstOrDefault();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Update(Employee employee, string empname)
        {
            Repository.AllEmployees.Where(e=>e.Name==empname).FirstOrDefault().Age = employee.Age;
            Repository.AllEmployees.Where(e=>e.Name==empname).FirstOrDefault().Salary=employee.Salary;
            Repository.AllEmployees.Where(e => e.Name == empname).FirstOrDefault().Department = employee.Department;
            Repository.AllEmployees.Where(e => e.Name == empname).FirstOrDefault().Sex = employee.Sex;
            Repository.AllEmployees.Where(e => e.Name == empname).FirstOrDefault().Name = employee.Name;

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(string empname)
        {
            Employee employee = Repository.AllEmployees.Where(e => e.Name == empname).FirstOrDefault();
            Repository.Delete(employee);
            return RedirectToAction("Index");
        }
    }
}
