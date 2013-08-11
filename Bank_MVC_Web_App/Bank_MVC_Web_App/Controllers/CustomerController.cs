using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bank_MVC_Web_App.Models;
using Bank_MVC_Web_App.Models.Dto;
using Bank_MVC_Web_App.Services;

namespace Bank_MVC_Web_App.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        public ActionResult CreateCustomer()
        {
            NewCustomerDto model = new NewCustomerDto();
            ContractNumberGenerator generator = ContractNumberGenerator.Instance();
            model.ContractNumber = generator.GetContractNumber();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateCustomer(NewCustomerDto model)
        {
            DataManager db = new DataManager();
            int currentCustomerId = db.AddNewCustomer(model);

            return RedirectToAction("ShowCustomer", new { id = currentCustomerId});
        }

        [HttpGet]
        public ActionResult FindCustomer()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ShowCustomer(int id)
        {
            DataManager db = new DataManager();
            CustomerDto model = new CustomerDto();
            
            model = db.GetCustomerDto(id);
            return View(model);    
        }

        public JsonResult GetCustomerByContractNumber(int contractNumber)
        {
            DataManager db = new DataManager();
            var customer = db.GetCustomerByContractNumber(contractNumber);
            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCustomersByLastName(string lastName)
        {
            DataManager db = new DataManager();
            var customers = db.GetCustomersByLastName(lastName);
            return Json(customers, JsonRequestBehavior.AllowGet);
        }
    }
}
