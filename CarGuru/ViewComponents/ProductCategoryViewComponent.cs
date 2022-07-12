using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarGuru.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarGuru.ViewComponents
{
    public class ProductCategoryViewComponent:ViewComponent
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryViewComponent(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }
        public IViewComponentResult InvokeAsync()
        {
            var dbObject =_productCategoryService.GetAllAsync();
            return View("ProductCategory", dbObject.Data);
        }
    }
}
