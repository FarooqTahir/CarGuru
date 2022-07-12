using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;
using CarGuru.Database.Models;
using CarGuru.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarGuru.Services.Services
{
    public class ProductService:IProductService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductService(ApplicationDbContext dbContext, IMapper mapper
        )
        {
            _db = dbContext;
            _mapper = mapper;
        }
        public async Task<ResponseDto<List<ProductResponseDto>>> CreateAsync(ProductRequestDto model)
        {
            var DbObject = _mapper.Map<ProductRequestDto, Products>(model);
            DbObject.CreatedDate = DateTime.UtcNow;
            _db.Products.Add(DbObject);
            await _db.SaveChangesAsync();

            var dbObject = await _db.Products.Where(x => x.IsActive == true).ToListAsync();
            if (dbObject is null) return new ResponseDto<List<ProductResponseDto>>() { Status = 0, Data = null };
            var mappedObject = _mapper.Map<List<ProductResponseDto>>(dbObject);
            return new ResponseDto<List<ProductResponseDto>>() { Data = mappedObject };
        }
        public async Task<ResponseDto<List<ProductResponseDto>>> UpdateAsync(ProductRequestDto model)
        {
            var DbObject = _mapper.Map<ProductRequestDto, Products>(model);
            var dbObject = await _db.Products.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (!(dbObject is null))
            {
                dbObject.Name = DbObject.Name;
                dbObject.SalePrice = DbObject.SalePrice;
                dbObject.RegularPrice = DbObject.RegularPrice;
                dbObject.StockStatus = DbObject.StockStatus;
                dbObject.Manufacturer = DbObject.Manufacturer;
                dbObject.VendorId = DbObject.VendorId;
                dbObject.ProductDiscount = DbObject.ProductDiscount;
                dbObject.SkuNo = DbObject.SkuNo;
                dbObject.Description = DbObject.Description;
                dbObject.LeastPrice = DbObject.LeastPrice;
                dbObject.ProductCategoryId = DbObject.ProductCategoryId;
                dbObject.ProductSubCategoryId = DbObject.ProductSubCategoryId;
                if (DbObject.ImageUrl != null) 
                {
                    dbObject.ImageUrl = DbObject.ImageUrl;
                }
                dbObject.IsActive = true;
                dbObject.UpdatedDate = DateTime.UtcNow;
                dbObject.DeadStock = DbObject.DeadStock;
                dbObject.QrCode = DbObject.QrCode;

                _db.Entry(dbObject).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                var ProductsList = await _db.Products.Where(x => x.IsActive == true).ToListAsync();
                if (ProductsList is null) return new ResponseDto<List<ProductResponseDto>>() { Status = 0, Data = null };
                var mappList = _mapper.Map<List<ProductResponseDto>>(ProductsList);
                return new ResponseDto<List<ProductResponseDto>>() { Data = mappList };
            }

            var List = await _db.Products.Where(x => x.IsActive == true).ToListAsync();
            if (List is null) return new ResponseDto<List<ProductResponseDto>>() { Status = 0, Data = null };
            var mappedList = _mapper.Map<List<ProductResponseDto>>(List);
            return new ResponseDto<List<ProductResponseDto>>() { Data = mappedList };
        }
        public async Task<ResponseDto<List<ProductResponseDto>>> DeleteProduct(long ProductId)
        {
            var dbObject = await _db.Products.FirstOrDefaultAsync(x => x.Id == ProductId);
            if (!(dbObject is null))
            {
                dbObject.IsActive = false;
                dbObject.UpdatedDate = DateTime.UtcNow;

                _db.Entry(dbObject).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                var ProductsList = await _db.Products.Where(x => x.IsActive == true).ToListAsync();
                if (ProductsList is null) return new ResponseDto<List<ProductResponseDto>>() { Status = 0, Data = null };
                var mappList = _mapper.Map<List<ProductResponseDto>>(ProductsList);
                return new ResponseDto<List<ProductResponseDto>>() { Data = mappList };
            }

            var List = await _db.Products.Where(x => x.IsActive == true).ToListAsync();
            if (List is null) return new ResponseDto<List<ProductResponseDto>>() { Status = 0, Data = null };
            var mappedList = _mapper.Map<List<ProductResponseDto>>(List);
            return new ResponseDto<List<ProductResponseDto>>() { Data = mappedList };
        }

        public async Task<ResponseDto<ProductResponseDto>> GetByIdAsync(long id)
        {
            var dbObject = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (dbObject is null) return new ResponseDto<ProductResponseDto>() { Status = 0, Data = null };
            var mappedObject = _mapper.Map<ProductResponseDto>(dbObject);
            return new ResponseDto<ProductResponseDto>() { Data = mappedObject };
        }

        public async Task<ResponseDto<List<ProductResponseDto>>> GetAllAsync(string name)
        {
            if (name == "" || name == null)
            {
                var dbObject = await _db.Products.Where(x => x.IsActive == true).ToListAsync();
                if (dbObject is null) return new ResponseDto<List<ProductResponseDto>>() { Status = 0, Data = null };
                var mappedObject = _mapper.Map<List<ProductResponseDto>>(dbObject);
                return new ResponseDto<List<ProductResponseDto>>() { Data = mappedObject };
            }
            else 
            {
                var Products = from Product in _db.Products
                               where Product.Name.Contains(name) && Product.IsActive == true
                               select Product;

                var List = _mapper.Map<List<Products>, List<ProductResponseDto>>(Products.ToList());
                if (List is null) return new ResponseDto<List<ProductResponseDto>>() { Status = 0, Data = null };

                return new ResponseDto<List<ProductResponseDto>>() { Data = List };
            }
        }

        public async Task<ResponseDto<List<ProductResponseDto>>> GetAllByCategoryIdAsync(int categoryId)
        {
            if (categoryId == 0) 
            {
                var DbData = await _db.Products.Where(x => x.IsActive == true ).ToListAsync();
                if (DbData is null) return new ResponseDto<List<ProductResponseDto>>() { Status = 0, Data = null };
                var mapObject = _mapper.Map<List<ProductResponseDto>>(DbData);
                return new ResponseDto<List<ProductResponseDto>>() { Data = mapObject };
            }
            var dbObject = await _db.Products.Where(x => x.IsActive == true&&x.ProductCategoryId== categoryId).ToListAsync();
            if (dbObject is null) return new ResponseDto<List<ProductResponseDto>>() { Status = 0, Data = null };
            var mappedObject = _mapper.Map<List<ProductResponseDto>>(dbObject);
            return new ResponseDto<List<ProductResponseDto>>() { Data = mappedObject };
        }
        public async Task<ResponseDto<List<ProductResponseDto>>> SearchProductByName(string Name)
        {
            if (Name == "" || Name == null)
            {
                var DbData = await _db.Products.Where(x => x.IsActive == true).ToListAsync();
                if (DbData is null) return new ResponseDto<List<ProductResponseDto>>() { Status = 0, Data = null };
                var mapObject = _mapper.Map<List<ProductResponseDto>>(DbData);
                return new ResponseDto<List<ProductResponseDto>>() { Data = mapObject };
            }
            else 
            {
                var Products = from Product in _db.Products
                            where Product.Name.Contains(Name)&& Product.IsActive==true
                               select Product;
                var List = _mapper.Map<List<Products>, List<ProductResponseDto>>(Products.ToList());
                if (List is null) return new ResponseDto<List<ProductResponseDto>>() { Status = 0, Data = null };
               
                return new ResponseDto<List<ProductResponseDto>>() { Data = List };
            }
        }
        public async Task<ResponseDto<List<ProductResponseDto>>> GetAllByFilterAsync(string query)
        {
            query ??= "";
            var dbObject = await _db.Products.Where(x => x.IsActive == true && (x.Name.Contains(query.Trim())||string.IsNullOrEmpty(query))).ToListAsync();
            if (dbObject is null) return new ResponseDto<List<ProductResponseDto>>() { Status = 0, Data = null };
            var mappedObject = _mapper.Map<List<ProductResponseDto>>(dbObject);
            return new ResponseDto<List<ProductResponseDto>>() { Data = mappedObject };
        }
        public ResponseDto<List<FleetResponseDto>> GetAllFleets()
        {
            var FleetList = _db.Fleets.Where(x => x.IsActive == true).ToList();
            if (FleetList is null) return new ResponseDto<List<FleetResponseDto>>() { Status = 0, Data = null };
            var mappedObject = _mapper.Map<List<FleetResponseDto>>(FleetList);
            return new ResponseDto<List<FleetResponseDto>>() { Data = mappedObject };
        }
    }
}