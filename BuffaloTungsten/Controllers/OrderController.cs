using BuffaloTungsten.Domain.Abstract;
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

        public OrderController(ICustomerRepository custRepo)
        {
            _custRepo = custRepo;
        }
        // GET: Order
        public ActionResult Index()
        {
            OrderIndexViewModel viewModel = new OrderIndexViewModel();
            viewModel.CustomerList = _custRepo.Customers.Select(x => x.Customer).ToList();
            return View(viewModel);
        }
    }
}