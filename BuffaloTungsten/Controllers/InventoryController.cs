using BuffaloTungsten.Domain.Abstract;
using BuffaloTungsten.Models;
using BuffaloTungsten.Domain.Entities;
using Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace BuffaloTungsten.Controllers
{
    public class InventoryController : Controller
    {
        private ICategoryRepository _categoryRepo;
        private IInventoryRepository _inventoryRepo; 

        public InventoryController(ICategoryRepository categoryRepo, IInventoryRepository inventoryRepo)
        {
            _categoryRepo = categoryRepo;
            _inventoryRepo = inventoryRepo;
        }

        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Upload()
        {
            return View(uploadModelCreation(new UploadViewModel()));
        }

        [HttpPost]
        public ViewResult Upload(UploadViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(uploadModelCreation(model));
            }
            var file = model.ExcelFile;
            //FileStream stream = System.IO.File.Open(@"c:\W_LotInv.xlsx", FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(file.InputStream);
            List<Inventory> items = new List<Inventory>();
            Inventory item = new Inventory();
            List<string> header = new List<string>();
            for (var x = 0; excelReader.Read(); x++)
            {  
                for (var y = 0; y < excelReader.FieldCount; y++)
                {
                    // Header, determins columns
                    if (x == 0)
                    { header.Add(excelReader.GetString(y)); }
                    if (x > 0)
                    {
                        if (header[y] == "Date")
                        { item.Date = DateTime.Parse(excelReader.GetString(y));  }

                        if (header[y] == "Lot No")
                        { item.LotNumber = excelReader.GetString(y); }

                        if (header[y] == "Lot No")
                        { item.LotNumber = excelReader.GetString(y); }

                        if (header[y] == "BegQuantity")
                        { item.StartBalance = int.Parse(excelReader.GetString(y)); }

                        if (header[y] == "ToBeUsed")
                        { continue; }

                        if (header[y] == "CurQuantity")
                        { item.Balance = int.Parse(excelReader.GetString(y)); }

                        if (header[y] == "ActualFSSS")
                        {
                            if (excelReader.GetString(y) == null || excelReader.GetString(y).Trim() == "")
                            { item.FSSS = 0; }
                            else
                            { item.FSSS = excelReader.GetDecimal(y); }
                        }

                        if (header[y] == "ActualScott")
                        {
                            if (excelReader.GetString(y) == null ||  excelReader.GetString(y).Trim() == "")
                            { item.Scott = 0; }
                            else
                            { item.Scott = excelReader.GetDecimal(y); }
                        }

                        if (header[y] == "Notes")
                        { item.Notes = excelReader.GetString(y); }
                    }
                }
                if (x > 0)
                { items.Add(item); }
                item = new Inventory();
            }
            excelReader.Close();
            _inventoryRepo.AddOrUpdateInventory(items);

            return View(uploadModelCreation(model));
        }

        private UploadViewModel uploadModelCreation(UploadViewModel viewModel)
        {
            // need to cache
            var categories = _categoryRepo.Categories.Where(x => x.Parent_Id != null).ToList();
            Mapper.CreateMap<Category, ProductCategory>();
            //List<DepartmentVM> depts = Mapper.Map<List<DepartmentVM>>(departments);
            viewModel.ProductCategories = Mapper.Map<List<ProductCategory>>(categories);
            return viewModel;
        }

    }
}