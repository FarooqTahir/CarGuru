using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Services.Interfaces;
using CarGuru.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarGuru.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryService _service;
        private readonly IMapper _mapper;

        public ProductCategoryController(IProductCategoryService productCategoryService,IMapper mapper)
        {
            _service = productCategoryService;
            _mapper = mapper;
        }

        public IActionResult ProductCategories()
        {
            var model = new ProductViewModel();
            var List = _service.GetAllAsync();
            model.Categories = List.Data;
            return View(model);
        }

        public async Task<IActionResult> CategoryAddOrEdit(ProductViewModel model)
        {
            if (model.Category.Id == 0)
            {
                var List = await _service.CreateAsync(model.Category);
                model.Categories = List.Data;
                return PartialView("~/Views/ProductCategory/_ProductCategoryListing.cshtml", model);
            }
            else 
            {
                var result =  await _service.UpdateAsync(model.Category);
                model.Categories = result.Data;
                return PartialView("~/Views/ProductCategory/_ProductCategoryListing.cshtml", model);
            }
        }

        public async Task<IActionResult> GetCategoryById(long CategoryId)
        {
            var model = new ProductViewModel();
            var Cat = await _service.GetByIdAsync(CategoryId);
            var request = _mapper.Map<ProductCategoryRequestDto>(Cat.Data);
            model.Category = request;
            return PartialView("~/Views/ProductCategory/_patialUpdateProductCategory.cshtml", model);
        }
        public async Task<IActionResult> DeleteSubCategory(long subCategoryId)
        {
            var model = new ProductViewModel();
            var Cat = await _service.DeleteSubCategoryAsync(subCategoryId);
            var request = _mapper.Map<ProductCategoryRequestDto>(Cat.Data);
            model.Category = request;
            return PartialView("~/Views/ProductCategory/_patialUpdateProductCategory.cshtml", model);
        }
        public async Task<IActionResult> DeleteCategory(long Id)
        {
            var vm = new ProductViewModel();
            var List = await _service.DeleteAsync(Id);
            vm.Categories = List.Data;
            return PartialView("~/Views/ProductCategory/_ProductCategoryListing.cshtml", vm);
        }

    }
}