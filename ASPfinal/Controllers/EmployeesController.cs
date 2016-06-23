using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ASPfinal.Models;


namespace ASPfinal.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index(Models.SelectSearch selectitem)
        {
            EmployeesService EmployeesService = new EmployeesService();
            List<Employees> result = EmployeesService.GetEmployeesName();

            List<SelectListItem> EmployeesData = new List<SelectListItem>();
            EmployeesData.Add(new SelectListItem()
            {
                Text = "",
                Value = null
            });
            foreach (var item in result)
            {
                EmployeesData.Add(new SelectListItem()
                {
                    Text = item.LastName,
                    Value = item.EmployeeID.ToString()
                });
                ViewData["EmpData"] = EmployeesData;
            }

            


            return View();

        }


       
    }
}