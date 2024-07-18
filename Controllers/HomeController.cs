using EmpInterview.Models;
using EmpInterview.select;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace EmpInterview.Controllers
{
    public class HomeController : Controller
    {
        private readonly empinterviewEntities1 empEntity = new empinterviewEntities1();

        public ActionResult Index()
        {
            var employee = from emp in empEntity.TblEmps join dsg in empEntity.TblDsgs on emp.Dsg equals dsg.Id
                           join dept in empEntity.TblDepts on emp.Dept equals dept.Id
                           join gen in empEntity.Genders on emp.Gender equals gen.Id
                           select new EmployeeViewModel{
                               Sr_No_ = emp.Sr_No_,
                               Name = emp.Name,
                               Dsg = dsg.Dsg,
                               Dept = dept.Dept,
                               Gender = gen.Gender1,
                               Salary = (decimal)emp.Salary,
                           };
            return View(employee.ToList());
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Dsg = new SelectList(empEntity.TblDsgs, "Id", "Dsg");
            ViewBag.Dept = new SelectList(empEntity.TblDepts, "Id", "Dept");
            ViewBag.Gender = new SelectList(empEntity.Genders, "Id", "Gender1");
            return View();
        }

        [HttpPost]
        public ActionResult Add(TblEmp viewModel)
        {
            empEntity.TblEmps.Add(viewModel);
            empEntity.SaveChanges();
            ViewBag.Dsg = new SelectList(empEntity.TblDsgs, "Id", "Dsg", viewModel.Dsg);
            ViewBag.Dept = new SelectList(empEntity.TblDepts, "Id", "Dept", viewModel.Dept);
            ViewBag.Gender = new SelectList(empEntity.Genders, "Id", "Gender1", viewModel.Gender);
            ViewBag.Message = "Employee Registered Successfully!";

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Dsg = new SelectList(empEntity.TblDsgs, "Id", "Dsg");
            ViewBag.Dept = new SelectList(empEntity.TblDepts, "Id", "Dept");
            ViewBag.Gender = new SelectList(empEntity.Genders, "Id", "Gender1");
            var employee = empEntity.TblEmps.Where(x => x.Sr_No_ == id).FirstOrDefault();
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(TblEmp viewModel)
        {
            var data = empEntity.TblEmps.Where(x => x.Sr_No_ == viewModel.Sr_No_).FirstOrDefault();
            data.Name = viewModel.Name;
            data.Dsg = viewModel.Dsg;
            data.Dept = viewModel.Dept;
            data.Gender = viewModel.Gender;
            data.Salary = viewModel.Salary;
            empEntity.SaveChanges();
            ViewBag.Dsg = new SelectList(empEntity.TblDsgs, "Id", "Dsg", viewModel.Dsg);
            ViewBag.Dept = new SelectList(empEntity.TblDepts, "Id", "Dept", viewModel.Dept);
            ViewBag.Gender = new SelectList(empEntity.Genders, "Id", "Gender1", viewModel.Gender);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var employee = empEntity.TblEmps.Where(x => x.Sr_No_ == id).FirstOrDefault();
            empEntity.TblEmps.Remove(employee);
            empEntity.SaveChanges();
            return RedirectToAction("Index");
        }
        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}