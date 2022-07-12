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
    public class VendorService:IVendorService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public VendorService(ApplicationDbContext dbContext, IMapper mapper
        )
        {
            _db = dbContext;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<VendorResponseDto>>> CreateAsync(VendorRequestDto model)
        {
            var mappedObject = _mapper.Map<VendorRequestDto, Vendors>(model);
            mappedObject.CreatedDate = DateTime.UtcNow;
            _db.Vendors.Add(mappedObject);
            await _db.SaveChangesAsync();

            var dbObject = await _db.Vendors.Where(a => a.IsActive.Value).ToListAsync();
            if (dbObject is null) return new ResponseDto<List<VendorResponseDto>>() { Status = 0, Data = null };
            var vendors = _mapper.Map<List<VendorResponseDto>>(dbObject);
            return new ResponseDto<List<VendorResponseDto>>() { Data = vendors };
        }


        public async Task<ResponseDto<VendorResponseDto>> GetByIdAsync(long id)
        {
            var dbObject = await _db.Vendors.FirstOrDefaultAsync(x => x.Id == id);
            if (dbObject is null) return new ResponseDto<VendorResponseDto>() { Status = 0, Data = null };
            var mappedObject = _mapper.Map<VendorResponseDto>(dbObject);
            return new ResponseDto<VendorResponseDto>() { Data = mappedObject };
        }

        public async Task<ResponseDto<List<VendorResponseDto>>> GetAllAsync()
        {
            var dbObject = await _db.Vendors.Where(a => a.IsActive.Value).ToListAsync();
            if (dbObject is null) return new ResponseDto<List<VendorResponseDto>>() { Status = 0, Data = null };
            var mappedObject = _mapper.Map<List<VendorResponseDto>>(dbObject);
            return new ResponseDto<List<VendorResponseDto>>() { Data = mappedObject };
        }
        public async Task<ResponseDto<List<VendorResponseDto>>> UpdateAsync(VendorRequestDto model)
        {
            var vendor = await _db.Vendors.FirstOrDefaultAsync(v => v.Id == model.Id);
            if (!(vendor is null))
            {
                vendor.FirstName = model.FirstName;
                vendor.LastName = model.LastName;
                vendor.PhoneNumber = model.PhoneNumber;
                vendor.BusinessAddress = model.BusinessAddress;
                vendor.CreditCardLimit = model.CreditCardLimit;
                vendor.UpdateById = model.UpdateById;
                vendor.UpdatedDate = DateTime.UtcNow;
                _db.Entry(vendor).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                
            }
            var dbObject = await _db.Vendors.Where(a => a.IsActive.Value).ToListAsync();
            if (dbObject is null) return new ResponseDto<List<VendorResponseDto>>() { Status = 0, Data = null };
            var mappedObject = _mapper.Map<List<VendorResponseDto>>(dbObject);
            return new ResponseDto<List<VendorResponseDto>>() { Data = mappedObject };
        }

        public async Task<ResponseDto<List<VendorResponseDto>>> DeleteAsync(long vendorId)
        {
            var vendor = await _db.Vendors.FirstOrDefaultAsync(v => v.Id == vendorId);
            if(!(vendor is null))
            {
                vendor.IsActive = false;
                _db.Entry(vendor).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            var dbObject = await _db.Vendors.Where(a => a.IsActive.Value).ToListAsync();
            if (dbObject is null) return new ResponseDto<List<VendorResponseDto>>() { Status = 0, Data = null };
            var mappedObject = _mapper.Map<List<VendorResponseDto>>(dbObject);
            return new ResponseDto<List<VendorResponseDto>>() { Data = mappedObject };
        }
    }
}