using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuffaloTungsten.Models
{
    public class UploadViewModel
    {
        public List<ProductCategory> ProductCategories { get; set; }

        [Display(Name = "Select Product Category")]
        public int SelectedCategoryId { get; set; }

        public IEnumerable<SelectListItem> Products
        {
            get
            {
                var allProducts = ProductCategories.Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = f.Name
                });
                return allProducts;

            }
        }
    }

    /// <summary>
    /// These are the final categories, which are really product names although the products are more lot numbers with BTI
    /// </summary>
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}