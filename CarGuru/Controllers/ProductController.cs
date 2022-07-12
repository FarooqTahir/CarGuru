using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CarGuru.Services.Interfaces;
using CarGuru.Utilities;
using CarGuru.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Net.Http.Headers;
using CarGuru.Extensions;
namespace CarGuru.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly IVendorService _vendorService;
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _webHost;


        public ProductController(IProductCategoryService productCategoryService, IVendorService vendorService,IProductService productService,IWebHostEnvironment webHost)
        {
            _productCategoryService = productCategoryService;
            _vendorService = vendorService;
            _productService = productService;
            _webHost = webHost;
        }
        public async Task<IActionResult> ProductDashboard()
        {
            var vm = new ProductViewModel();
            var types = _productCategoryService.GetAllAsync();
            var vendors = await _vendorService.GetAllAsync();
            if (types.Status is 1)
                if (vendors.Data.Any())
                    vm.Vendors.AddRange(vendors.Data.Select(item => new SelectListItem { Text = item.FirstName + " " + item.LastName, Value = item.Id.ToString() }));
            if (types.Status is 1)
                if (types.Data.Any())
                    vm.ProductCategories.AddRange(types.Data.Select(item => new SelectListItem { Text = item.Title, Value = item.Id.ToString() }));

            var dbList = await _productService.GetAllAsync("");
            var ListResult = _productCategoryService.GetAllAsync();
            vm.Categories = ListResult.Data;
            vm.Products = dbList.Data.OrderByDescending(d => d.CreatedDate).ToList();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductViewModel model)
        {
            var files = Request.Form.Files;
            if (files.Count > 0)
            {
                foreach (var source in files)
                {
                    string filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.ToString();
                    filename = DateTime.UtcNow.ToString("ddMMyyyyhhmmss") + "_" + System.IO.Path.GetFileName(filename);
                    string extension = System.IO.Path.GetExtension(filename);

                    string filePath = _webHost.ContentRootPath + "\\wwwroot\\resources\\" + filename;
                    await using (FileStream output = System.IO.File.Create(this.GetFullPath(filename))) 
                    {
                        await source.CopyToAsync(output);
                        await output.FlushAsync();
                        model.ProductRequestDto.ImageUrl = EnviromentUrls.Url + "resources/" + filename;
                    }
                };
            }
            if (model.ProductRequestDto.Id == 0) 
            {
                var List = await _productService.CreateAsync(model.ProductRequestDto);
                model.Products = List.Data;
                return PartialView("~/Views/Management/_InventoryList.cshtml", model);
            }
            else 
            {
                var ProductList = await _productService.UpdateAsync(model.ProductRequestDto);
                model.Products = ProductList.Data;
                return PartialView("~/Views/Management/_InventoryList.cshtml", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetProductListByCategory(int categoryId)
        {
            var vm = new ProductViewModel();
            var dbList = await _productService.GetAllByCategoryIdAsync(categoryId);
            vm.Products = dbList.Data;
            return PartialView("~/Views/Product/_ProductList.cshtml", vm);
        }
        [HttpPost]
        public async Task<IActionResult> SearchProduct(string ProductName)
        {
            var vm = new ProductViewModel();
            var dbList = await _productService.SearchProductByName(ProductName);
            vm.Products = dbList.Data;
            return PartialView("~/Views/Product/_ProductList.cshtml", vm);
        }

        [HttpPost]
        public async Task<IActionResult> GetProductListByFilter(string query)
        {   
            if (query == "0") 
            {
                var List = await _productService.GetAllAsync("");
                List.Data = List.Data.OrderByDescending(d => d.CreatedDate).ToList();
                return PartialView("~/Views/Management/_InventoryList.cshtml", List.Data);
            }
            var dbList = await _productService.GetAllByFilterAsync(query);
            return PartialView("~/Views/Management/_InventoryList.cshtml", dbList.Data);
        }

        [HttpPost]
        public async Task<IActionResult> GetProductById(long productId)
        {
            if (productId > 0) { 
             var dbObject = await _productService.GetByIdAsync(productId);
                //if(!dbObject.Data.ProductCategoryId.HasValue) return Json("-1");
                var dbList = await _productCategoryService.GetAllSubCategoryIdCategoryIdAsync(dbObject.Data.ProductCategoryId);
                if (dbList.Status == 1)
                {
                    dbObject.Data.SubCategories = dbList.Data;
                }
                return Json(dbObject.Data);
            }
            return Json("-1");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(long productId)
        {
            var dbList = await _productService.DeleteProduct(productId);
            var model = new ProductViewModel();
            model.Products = dbList.Data;
            return PartialView("~/Views/Management/_InventoryList.cshtml", model);
        }

        private string GetFullPath(string filename)
        {
            return this._webHost.WebRootPath + "\\resources\\" + filename;
        }
    }
}