using AutoMapper;
using CarGuru.Database.Models;
using CarGuru.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.ResponseDto;
using CarGuru.Database.ApisDtos;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarGuru.Database.Dtos.RequestDto;
using System.Linq.Expressions;

namespace CarGuru.Services.Services
{
    public class LookupService : ILookUpsService
    {

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IProductCategoryService _productCategoryService;

        public LookupService( ApplicationDbContext dbContext, IMapper mapper, IProductCategoryService productCategoryService
        )
        {
            _db = dbContext;
            _mapper = mapper;
            _productCategoryService = productCategoryService;
        }

        public ResponseDto<List<LookupResponseDto>> GetLookupValueWithType(string type)
        {
            var securityQuestions = _db.Lookups.Where(v => v.LookupType == type).ToList();
            var mappedObject = _mapper.Map<List<LookupResponseDto>>(securityQuestions);

            return new ResponseDto<List<LookupResponseDto>>(){Data = mappedObject};
        } 
        public async Task<ResponseDto<List<ServiceTypeDto>>> GetServiceTypesAsync()
        {
            var serviceTypes = await _db.ServiceType.Where(v => v.IsActive.Value).OrderBy(x => x.Priority).ToListAsync();
            var mappedObject = _mapper.Map<List<ServiceTypeDto>>(serviceTypes);

            return new ResponseDto<List<ServiceTypeDto>>(){Data = mappedObject};
        }
        public ResponseDto<List<ProductResponseDto>> GetAllProductsList()
        {
            var securityQuestions = _db.Products.Where(v => v.IsActive == true).ToList();
            var mappedObject = _mapper.Map<List<ProductResponseDto>>(securityQuestions);
           
            return new ResponseDto<List<ProductResponseDto>>() { Data = mappedObject };
        }
        public ResponseDto<List<ProductListDto>> GetAllProductsListApi(long CategoryId)
        {
            if (CategoryId == 0)
            {
                var securityQuestions = _db.Products.Include(a => a.Vendor).Include(a => a.ProductCategory).Include(a => a.ProductSubCategory).Where(v => v.IsActive == true).ToList();
                var mappedObject = _mapper.Map<List<ProductListDto>>(securityQuestions);

                return new ResponseDto<List<ProductListDto>>() { Data = mappedObject };
            }
            else 
            {
                var securityQuestions = _db.Products.Where(v => v.IsActive == true && v.ProductCategoryId == CategoryId).ToList();
                var mappedObject = _mapper.Map<List<ProductListDto>>(securityQuestions);

                return new ResponseDto<List<ProductListDto>>() { Data = mappedObject };
            }
        }
        public async Task<ResponseDto<GetAllProductsListFilter>> GetAllProductsListFilterApi(ProductListFilter filter)
        {
            Expression<Func<CarGuru.Database.Models.Products, bool>> predicate;
            if (filter.CategoryId == 0)
            {
                predicate = x => x.IsActive.Value;
            }
            else
            {
                if (filter.SubCategoryId.HasValue && filter.SubCategoryId.Value > 0)
                {
                    predicate = x => x.ProductCategoryId == filter.CategoryId && x.ProductSubCategoryId.Value == filter.SubCategoryId.Value && x.IsActive.Value;
                }
                else
                {
                    predicate = x => x.ProductCategoryId == filter.CategoryId && x.IsActive.Value;
                }
                
            }
           
                var securityQuestions = await _db.Products.Include(a => a.ProductCategory).Include(a => a.ProductSubCategory).Where(predicate).ToListAsync();
                var mappedObject = _mapper.Map<List<ProductListDto>>(securityQuestions);
            var subcategories = await _productCategoryService.GetAllSubCategoryIdCategoryIdAsync(filter.CategoryId);
            var response = new GetAllProductsListFilter() { 
            Products = mappedObject,
                SubCategoryList = subcategories.Data

            };
                return new ResponseDto<GetAllProductsListFilter>() { Data = response };
        }
        public ResponseDto<List<ProductCategoriesApiDto>> GetAllCategories()
        {
            var securityQuestions = _db.ProductCategories.Where(x=>x.IsActive==true);
            var mappedObject = _mapper.Map<List<ProductCategoriesApiDto>>(securityQuestions);

            return new ResponseDto<List<ProductCategoriesApiDto>>() { Data = mappedObject };
        }
        public ResponseDto<bool> EmailCheck(string Email)
        { 
            var User = _db.Users.Where(v => v.IsActive == true && v.Email==Email).ToList();
            if (!(User.Count == 0)) 
            {
                return new ResponseDto<bool>() { Data = true };
            }
            return new ResponseDto<bool>() { Data = false };
        }
        public ResponseDto<List<RolesResponseDto>> GetAllRoles()
        {
            var Roles = _db.Roles.ToList();
            var mappedObject = _mapper.Map<List<RolesResponseDto>>(Roles);

            return new ResponseDto<List<RolesResponseDto>>() { Data = mappedObject };
        }
        public ResponseDto<UserResponseDto> GetUserByUserId(long UserId)
        {
            var User = _db.Users.Where(x => x.UserId == UserId).FirstOrDefault();
            var mappedObject = _mapper.Map<UserResponseDto>(User);
            return new ResponseDto<UserResponseDto>() { Data = mappedObject };
        }
        public ResponseDto<CustomerResponseDto> GetCustomerByUserId(long UserId)
        {
            var Customer = _db.Customers.Where(x=>x.Id == UserId).FirstOrDefault();
            Customer.User = _db.Users.Where(x => x.UserId == UserId).FirstOrDefault();
            var mappedObject = _mapper.Map<CustomerResponseDto>(Customer);

            return new ResponseDto<CustomerResponseDto>() { Data = mappedObject };
        }
    }
}
