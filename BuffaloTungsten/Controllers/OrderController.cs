using AutoMapper;
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
    public class OrderController : Controller
    {
        private ICustomerRepository _custRepo;
        private ICategoryRepository _categoryRepo;

        public OrderController(ICustomerRepository custRepo, ICategoryRepository categoryRepo)
        {
            _custRepo = custRepo;
            _categoryRepo = categoryRepo;
        }
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewOrder()
        {
            OrderIndexViewModel viewModel = new OrderIndexViewModel();
            
            return View(newOrderModelCreation(viewModel));
        }


        private OrderIndexViewModel newOrderModelCreation(OrderIndexViewModel viewModel)
        {
            viewModel.CustomerList = _custRepo.Customers.Select(x => x.Customer).ToList();
            return viewModel;
        }

    }

}