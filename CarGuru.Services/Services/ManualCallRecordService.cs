using AutoMapper;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Models;
using CarGuru.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Services
{
    public class ManualCallRecordService:IManualCallRecordService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ManualCallRecordService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _db = dbContext;
            _mapper = mapper;
        }
        public async Task<ResponseDto<ManualCallRecordDto>> Create(ManualCallRecordDto model)
        {
            var mappedObject = _mapper.Map<ManualCallRecordDto, ManualCallRecords>(model);
            mappedObject.CreatedDate = DateTime.UtcNow;
            mappedObject.IsActive = true;
            _db.ManualCallRecords.Add(mappedObject);
            var result = await _db.SaveChangesAsync();
            if (result > 0)
            {
                return new ResponseDto<ManualCallRecordDto>() { Data = model, Status = 1, Message = "Success" };
            }
            return new ResponseDto<ManualCallRecordDto>() { Data = null, Status = 0, Message = "Error" };
        }
        public async Task<ResponseDto<List<ManualCallRecordDto>>> List(string name)
        {
            if (name==""||name==null) 
            {
                var Recordx = from Record in _db.ManualCallRecords
                               where Record.CustomerName.Contains(name)|| Record.PhoneNumber.Contains(name)
                               select Record;
                var List = _mapper.Map<List<ManualCallRecords>, List<ManualCallRecordDto>>(Recordx.Where(x=>x.IsActive==true).ToList());
                return new ResponseDto<List<ManualCallRecordDto>>() { Data = List };
            }
            else
            {
                var DbList = await _db.ManualCallRecords.Where(x => x.IsActive == true).ToListAsync();
                var mappedList = _mapper.Map<List<ManualCallRecordDto>>(DbList);
                return new ResponseDto<List<ManualCallRecordDto>>() { Data = mappedList };
            }
            
        }
        public async Task<ResponseDto<List<ManualCallRecordDto>>> UpdateAsync(ManualCallRecordDto model)
        {
            var dbObject = await _db.ManualCallRecords.Where(x=>x.Id==model.Id).FirstOrDefaultAsync();
            if (!(dbObject is null))
            {
                dbObject.Make = model.Make;
                dbObject.Year = model.Year;
                dbObject.CustomerName = model.CustomerName;
                dbObject.PhoneNumber = model.PhoneNumber;
                dbObject.CarModel = model.CarModel;
                dbObject.ReceivedDate = model.ReceivedDate;
                dbObject.IsActive = true;

                _db.Entry(dbObject).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                var RecordsList = await _db.ManualCallRecords.Where(x => x.IsActive == true).ToListAsync();
                if (RecordsList is null) return new ResponseDto<List<ManualCallRecordDto>>() { Status = 0, Data = null };
                var mappedList = _mapper.Map<List<ManualCallRecordDto>>(RecordsList);
                return new ResponseDto<List<ManualCallRecordDto>>() { Data = mappedList };
            }
            var Records = await _db.ManualCallRecords.Where(x => x.IsActive == true).ToListAsync();
            if (Records is null) return new ResponseDto<List<ManualCallRecordDto>>() { Status = 0, Data = null };
            var mappedObject = _mapper.Map<List<ManualCallRecordDto>>(Records);
            return new ResponseDto<List<ManualCallRecordDto>>() { Data = mappedObject };
        }
        public async Task<ResponseDto<List<ManualCallRecordDto>>> CreateAsync(ManualCallRecordDto model)
        {
            var mappedObject = _mapper.Map<ManualCallRecordDto, ManualCallRecords>(model);
            mappedObject.CreatedDate = DateTime.UtcNow;
            mappedObject.IsActive = true;
            _db.ManualCallRecords.Add(mappedObject);
            await _db.SaveChangesAsync();
            
            var Records = await _db.ManualCallRecords.Where(x => x.IsActive == true).ToListAsync();
            if (Records is null) return new ResponseDto<List<ManualCallRecordDto>>() { Status = 0, Data = null };
            var mappedList = _mapper.Map<List<ManualCallRecordDto>>(Records);
            return new ResponseDto<List<ManualCallRecordDto>>() { Data = mappedList };
        }
        public async Task<ResponseDto<List<ManualCallRecordDto>>> DeleteRecord(long Id)
        {
            var dbObject = await _db.ManualCallRecords.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (!(dbObject is null))
            {
                dbObject.IsActive = false;
                _db.Entry(dbObject).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                var Records = await _db.ManualCallRecords.Where(x => x.IsActive == true).ToListAsync();
                if (Records is null) return new ResponseDto<List<ManualCallRecordDto>>() { Status = 0, Data = null };
                var mappedList = _mapper.Map<List<ManualCallRecordDto>>(Records);
                return new ResponseDto<List<ManualCallRecordDto>>() { Data = mappedList };
            }
            var RecordsList = await _db.ManualCallRecords.Where(x => x.IsActive == true).ToListAsync();
            if (RecordsList is null) return new ResponseDto<List<ManualCallRecordDto>>() { Status = 0, Data = null };
            var mappedLi = _mapper.Map<List<ManualCallRecordDto>>(RecordsList);
            return new ResponseDto<List<ManualCallRecordDto>>() { Data = mappedLi };
        }
        public async Task<ResponseDto<ManualCallRecordDto>> GetByIdAsync(long Id)
        {
            var dbObject = await _db.ManualCallRecords.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (dbObject is null) return new ResponseDto<ManualCallRecordDto>() { Status = 0, Data = null };
            var mappedObject = _mapper.Map<ManualCallRecordDto>(dbObject);
            return new ResponseDto<ManualCallRecordDto>() { Data = mappedObject };
        }

    }
}
