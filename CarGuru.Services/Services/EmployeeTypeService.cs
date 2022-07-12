using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.ResponseDto;
using CarGuru.Database.Models;
using CarGuru.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarGuru.Services.Services
{
    public class EmployeeTypeService:IEmployeeTypeService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public EmployeeTypeService(ApplicationDbContext dbContext, IMapper mapper
        )
        {
            _db = dbContext;
            _mapper = mapper;
        }
    }
}