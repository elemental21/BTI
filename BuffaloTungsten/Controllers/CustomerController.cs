using BuffaloTungsten.Domain.Abstract;
using BuffaloTungsten.Domain.Entities;
using BuffaloTungsten.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuffaloTungsten.Controllers
{
    public class CustomerController : Controller
    {

        private ICustomerRepository _customerRepository; 

        public CustomerController(ICustomerRepository custRepo)
        {
            _customerRepository = custRepo;
        }

        // GET: Customer
        public ActionResult Index()
        {
            CustomerViewModel viewModel = new CustomerViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index",model);
            }
            Contact customer = new Contact();
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.Email = model.Email;
            customer.PhoneNumber = model.PhoneNumber;
            customer.Extension = model.Extention;
            customer.Notes = model.Notes;

            _customerRepository.AddCustomer(customer);
            _customerRepository.Save();
            return RedirectToAction("Index");
        }

    }
}