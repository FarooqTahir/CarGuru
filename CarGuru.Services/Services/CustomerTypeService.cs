using System.Collections.Generic;
using System.Globalization;
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
    public class CustomerTypeService:ICustomerTypeService

    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CustomerTypeService(ApplicationDbContext dbContext, IMapper mapper
        )
        {
            _db = dbContext;
            _mapper = mapper;
        }
      

        public async Task<ResponseDto<List<CustomerTypeResponseDto>>> GetAllAsync()
        {
            var dbObject = await _db.CustomerTypes.ToListAsync();
            var mappedObject = _mapper.Map<List<CustomerTypeResponseDto>>(dbObject);

            return new ResponseDto<List<CustomerTypeResponseDto>>() { Data = mappedObject };
        }
    }
}