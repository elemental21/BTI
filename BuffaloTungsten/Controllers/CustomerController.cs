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
            CustomerIndexViewModel viewModel = new CustomerIndexViewModel();
            if (TempData.ContainsKey("SubmitSuccess") && (Boolean)TempData["SubmitSuccess"] == true)
            { viewModel.SubmitSuccess = true; }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CustomerIndexViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.SubmitSuccess = false;
                return View("Index",model);
            }

            TempData["SubmitSuccess"] = true;
            Customer customer = new Customer();
            Contact contact = new Contact();

            customer.CompanyName = model.CompanyName;



            //_customerRepository.AddContact(contact);
            //_customerRepository.Save();

            //customer.PrimaryContact = contact;


            //customer.PrimaryContact.Customer = customer;
            
            //ADD ADDRESSES
            Address shippingAddress = new Address();
            shippingAddress.Address1 = model.ShippingAddress.Address1;
            shippingAddress.Address2 = model.ShippingAddress.Address2;
            shippingAddress.Address3 = model.ShippingAddress.Address3;
            shippingAddress.City = model.ShippingAddress.City;
            shippingAddress.State = model.ShippingAddress.State;
            shippingAddress.PostalCode = model.ShippingAddress.PostalCode;
            shippingAddress.Country = model.ShippingAddress.Country;

            customer.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.Address1 = model.BillingAddress.Address1;
            billingAddress.Address2 = model.BillingAddress.Address2;
            billingAddress.Address3 = model.BillingAddress.Address3;
            billingAddress.City = model.BillingAddress.City;
            billingAddress.State = model.BillingAddress.State;
            billingAddress.PostalCode = model.BillingAddress.PostalCode;
            billingAddress.Country = model.BillingAddress.Country;

            customer.BillingAddress = billingAddress;

            //_customerRepository.AddContact(contact);
            //_customerRepository.Save();
            _customerRepository.AddCustomer(customer);
            _customerRepository.Save();

            contact.FirstName = model.FirstName;
            contact.LastName = model.LastName;
            contact.Title = model.Title;
            contact.Email = model.Email;
            contact.PhoneNumber = model.PhoneNumber;
            contact.Extension = model.Extention;
            contact.Notes = model.Notes;
            contact.IsPrimary = true;
            contact.Customer_Id = customer.Id;
            _customerRepository.AddContact(contact);
            _customerRepository.Save();

            return RedirectToAction("Index");
        }

    }
}