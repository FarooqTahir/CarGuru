using AutoMapper;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;
using CarGuru.Database.Models;
using CarGuru.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Services
{
    public class FleetService : IFleetService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public FleetService(ApplicationDbContext dbContext, IMapper mapper
        )
        {
            _db = dbContext;
            _mapper = mapper;
        }
        public async Task<ResponseDto<List<FleetResponseDto>>> CreateAsync(FleetRequestDto model)
        {
            var mappedObject = _mapper.Map<FleetRequestDto, Fleets>(model);
            mappedObject.CreatedDate = DateTime.UtcNow;
            mappedObject.IsActive = true;
            _db.Fleets.Add(mappedObject);
            await _db.SaveChangesAsync();
            
            var FleetsList = _db.Fleets.Where(x => x.IsActive == true).ToList();
            if (FleetsList is null) return new ResponseDto<List<FleetResponseDto>>() { Status = 0, Data = null };
            var mappedList = _mapper.Map<List<FleetResponseDto>>(FleetsList);
            return new ResponseDto<List<FleetResponseDto>>() { Data = mappedList };
        }
        public async Task<ResponseDto<List<FleetResponseDto>>> UpdateAsync(FleetRequestDto model)
        {
            var dbObject = await _db.Fleets.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (!(dbObject is null))
            {
                dbObject.Address = model.Address;
                dbObject.Code = model.Code;
                dbObject.Contact = model.Contact;
                dbObject.Name = model.Name;
                dbObject.Mulkia = model.Mulkia;
                dbObject.Vin = model.Vin;
                dbObject.PlateNo = model.PlateNo;
                dbObject.UpdatedDate = DateTime.UtcNow;

                _db.Entry(dbObject).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                var FleetsList = _db.Fleets.Where(x => x.IsActive == true).ToList();
                if (FleetsList is null) return new ResponseDto<List<FleetResponseDto>>() { Status = 0, Data = null };
                var mappedList = _mapper.Map<List<FleetResponseDto>>(FleetsList);
                return new ResponseDto<List<FleetResponseDto>>() { Data = mappedList };
            }
            var FleetsLists = _db.Fleets.Where(x => x.IsActive == true).ToList();
            if (FleetsLists is null) return new ResponseDto<List<FleetResponseDto>>() { Status = 0, Data = null };
            var mappedLists = _mapper.Map<List<FleetResponseDto>>(FleetsLists);
            return new ResponseDto<List<FleetResponseDto>>() { Data = mappedLists };
        }
        public async Task<ResponseDto<List<FleetResponseDto>>> DeleteAsync(long Id)
        {
            var dbObject = await _db.Fleets.FirstOrDefaultAsync(x => x.Id == Id);
            if (!(dbObject is null))
            {
                dbObject.IsActive = false;

                _db.Entry(dbObject).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                var FleetsList = _db.Fleets.Where(x=>x.IsActive==true).ToList();
                if (FleetsList is null) return new ResponseDto<List<FleetResponseDto>>() { Status = 0, Data = null };
                var mappedList = _mapper.Map<List<FleetResponseDto>>(FleetsList);
                return new ResponseDto<List<FleetResponseDto>>() { Data = mappedList };
            }
            var FleetsLists = _db.Fleets.Where(x => x.IsActive == true).ToList();
            if (FleetsLists is null) return new ResponseDto<List<FleetResponseDto>>() { Status = 0, Data = null };
            var mappedLists = _mapper.Map<List<FleetResponseDto>>(FleetsLists);
            return new ResponseDto<List<FleetResponseDto>>() { Data = mappedLists };
        }
        public async Task<ResponseDto<FleetResponseDto>> GetByIdAsync(long id)
        {
            var dbObject = await _db.Fleets.FirstOrDefaultAsync(x => x.Id == id);
            if (dbObject is null) return new ResponseDto<FleetResponseDto>() { Status = 0, Data = null };
            var mappedObject = _mapper.Map<FleetResponseDto>(dbObject);
            return new ResponseDto<FleetResponseDto>() { Data = mappedObject };
        }

        public async Task<ResponseDto<List<FleetResponseDto>>> GetAllAsync()
        {
            var dbObject = await _db.Fleets.Where(x=>x.IsActive == true).ToListAsync();
            if (dbObject is null) return new ResponseDto<List<FleetResponseDto>>() { Status = 0, Data = null };
            var mappedObject = _mapper.Map<List<FleetResponseDto>>(dbObject);
            return new ResponseDto<List<FleetResponseDto>>() { Data = mappedObject };
        }
    }
}
