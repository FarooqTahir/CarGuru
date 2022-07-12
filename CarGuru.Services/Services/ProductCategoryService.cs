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
    public class ProductCategoryService:IProductCategoryService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductCategoryService(ApplicationDbContext dbContext, IMapper mapper
        )
        {
            _db = dbContext;
            _mapper = mapper;
        }
        public async Task<ResponseDto<List<ProductCategoryResponseDto>>> CreateAsync(ProductCategoryRequestDto model)
        {
            var mappedObject = _mapper.Map<ProductCategoryRequestDto, ProductCategories>(model);
            mappedObject.CreatedDate = DateTime.UtcNow;
            mappedObject.IsActive = true;
            foreach (var item in mappedObject.ProductSubCategories)
            {
                item.CreatedDate = DateTime.UtcNow;
                item.CreatedById = 3;
                item.IsActive = true;
            }
            _db.ProductCategories.Add(mappedObject);
            await _db.SaveChangesAsync();

            var dbObject = _db.ProductCategories.Include(a => a.ProductSubCategories).Where(x => x.IsActive == true).ToList();
            if (dbObject is null) return new ResponseDto<List<ProductCategoryResponseDto>>() { Status = 0, Data = null };
            var Result = _mapper.Map<List<ProductCategoryResponseDto>>(dbObject);
            return new ResponseDto<List<ProductCategoryResponseDto>>() { Data = Result };
        }
        public async Task<ResponseDto<List<ProductCategoryResponseDto>>> UpdateAsync(ProductCategoryRequestDto model)
        {
            var dbObject = await _db.ProductCategories.Include(a => a.ProductSubCategories).FirstOrDefaultAsync(x => x.Id == model.Id);
            if (!(dbObject is null))
            {
                _db.Entry(dbObject).CurrentValues.SetValues(model);
                var newCategories = _mapper.Map<List<ProductSubCategories>>(model.ProductSubCategories);
                // Delete children
                foreach (var existingChild in dbObject.ProductSubCategories.ToList())
                {
                    if (!model.ProductSubCategories.Any(c => c.Id == existingChild.Id))
                        _db.ProductSubCategories.Remove(existingChild);
                }
                // Update and Insert children
                foreach (var childModel in model.ProductSubCategories)
                {
                    var existingChild = dbObject.ProductSubCategories
                        .Where(c => c.Id == childModel.Id)
                        .SingleOrDefault();

                    if (existingChild != null)
                        // Update child
                        _db.Entry(existingChild).CurrentValues.SetValues(childModel);
                    else
                    {
                        // Insert child
                        var newChild = new ProductSubCategories
                        {
                            Title = childModel.Title,
                            Id = childModel.Id,
                            CreatedById = 3,
                            IsActive = true,
                            CreatedDate = DateTime.UtcNow,
                            ProductCategoryId = model.Id
                        };
                        dbObject.ProductSubCategories.Add(newChild);
                    }
                }
                dbObject.Title = model.Title;
                dbObject.CreatedDate = DateTime.UtcNow;
                dbObject.CreatedById = 3;
                _db.Entry(dbObject).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                var dbLists = _db.ProductCategories.Where(x => x.IsActive == true).ToList();
                if (dbLists is null) return new ResponseDto<List<ProductCategoryResponseDto>>() { Status = 0, Data = null };
                var Results = _mapper.Map<List<ProductCategoryResponseDto>>(dbLists);
                return new ResponseDto<List<ProductCategoryResponseDto>>() { Data = Results };
            }
            var dbList = _db.ProductCategories.Where(x => x.IsActive == true).ToList();
            if (dbList is null) return new ResponseDto<List<ProductCategoryResponseDto>>() { Status = 0, Data = null };
            var Result = _mapper.Map<List<ProductCategoryResponseDto>>(dbList);
            return new ResponseDto<List<ProductCategoryResponseDto>>() { Data = Result };
        }
        public async Task<ResponseDto<ProductCategoryResponseDto>> GetByIdAsync(long id)
        {
            var dbObject = await _db.ProductCategories.Include(a => a.ProductSubCategories).FirstOrDefaultAsync(x => x.Id == id);
            dbObject.ProductSubCategories = dbObject.ProductSubCategories.Where(x => x.IsActive.Value).ToList();
            if (dbObject is null) return new ResponseDto<ProductCategoryResponseDto>() { Status = 0, Data = null };
            var mappedObject = _mapper.Map<ProductCategoryResponseDto>(dbObject);
            return new ResponseDto<ProductCategoryResponseDto>() { Data = mappedObject };
        }
        public ResponseDto<List<ProductCategoryResponseDto>> GetAllAsync()
        {
            var dbObject = _db.ProductCategories.Include(a => a.ProductSubCategories).Where(x=>x.IsActive==true).ToList();
            if (dbObject is null) return new ResponseDto<List<ProductCategoryResponseDto>>() { Status = 0, Data = null };
            var mappedObject = _mapper.Map<List<ProductCategoryResponseDto>>(dbObject);
            return new ResponseDto<List<ProductCategoryResponseDto>>() { Data = mappedObject };
        }
        public async Task<ResponseDto<List<ProductCategoryResponseDto>>> DeleteAsync(long Id)
        {
            var dbObject = await _db.ProductCategories.FirstOrDefaultAsync(x => x.Id == Id);
            if (!(dbObject is null))
            {
                dbObject.IsActive=false;

                _db.Entry(dbObject).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                var dbLists = _db.ProductCategories.Where(x => x.IsActive == true).ToList();
                if (dbLists is null) return new ResponseDto<List<ProductCategoryResponseDto>>() { Status = 0, Data = null };
                var Results = _mapper.Map<List<ProductCategoryResponseDto>>(dbLists);
                return new ResponseDto<List<ProductCategoryResponseDto>>() { Data = Results };
            }
            var dbList = _db.ProductCategories.Where(x => x.IsActive == true).ToList();
            if (dbList is null) return new ResponseDto<List<ProductCategoryResponseDto>>() { Status = 0, Data = null };
            var Result = _mapper.Map<List<ProductCategoryResponseDto>>(dbList);
            return new ResponseDto<List<ProductCategoryResponseDto>>() { Data = Result };
        }

        public async Task<ResponseDto<List<ProductSubCategoryRequestDto>>> GetAllSubCategoryIdCategoryIdAsync(int categoryId)
        {
            var SubCategories = await _db.ProductSubCategories.Where(a => a.ProductCategoryId == categoryId).ToListAsync();
            var Result = _mapper.Map<List<ProductSubCategoryRequestDto>>(SubCategories);
            return new ResponseDto<List<ProductSubCategoryRequestDto>>() { Data = Result };
        }

        public async Task<ResponseDto<ProductCategoryResponseDto>> DeleteSubCategoryAsync(long Id)
        {
            var categoryId = 0;
            var subCategory = await _db.ProductSubCategories.FirstOrDefaultAsync(x => x.Id == Id);
            if(!(subCategory is null))
            {
                subCategory.IsActive = false;
                categoryId = subCategory.ProductCategoryId;
                _db.Entry(subCategory).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            var dbObject = await _db.ProductCategories.Include(a => a.ProductSubCategories).FirstOrDefaultAsync(x => x.Id == categoryId);
            dbObject.ProductSubCategories = dbObject.ProductSubCategories.Where(x => x.IsActive.Value).ToList();
            if (dbObject is null) return new ResponseDto<ProductCategoryResponseDto>() { Status = 0, Data = null };
            var mappedObject = _mapper.Map<ProductCategoryResponseDto>(dbObject);
            return new ResponseDto<ProductCategoryResponseDto>() { Data = mappedObject };
        }
    }
}