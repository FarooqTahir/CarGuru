using AutoMapper;
using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.RequestDto;
using CarGuru.Database.Dtos.ResponseDto;
using CarGuru.Database.Models;
using CarGuru.Services.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public FeedbackService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _db = dbContext;
            _mapper = mapper;
        }
        public async Task<ResponseDto<FeedbackRequestDto>> CreateAsync(FeedbackRequestDto model)
        {
            var order = _db.ServiceOrders.Where(x => x.Id == model.ServiceOrderNo).FirstOrDefault();
            var mappedObject = new Feedback();

            if (order.AssignedToId==null)
            {
                return new ResponseDto<FeedbackRequestDto>() { Data = model, Message = "No Technicain was assigned" };
            }
            mappedObject.TechnicianId = order.AssignedToId.Value;
            mappedObject.CustomerId = order.CustomerId.Value;
            mappedObject.Rating = model.Rating;
            mappedObject.OrderId = model.ServiceOrderNo;
            mappedObject.Comments = model.Comments;
            
            _db.Feedback.Add(mappedObject);
            var result = await _db.SaveChangesAsync();
            if (result > 0)
            {
                return new ResponseDto<FeedbackRequestDto>() { Data = model, Message = "Feedback Updated Successfully" };
            }
            else 
            {
                return new ResponseDto<FeedbackRequestDto>() { Data = model, Message = "Something Went Wrong" };
            }
        }
        public async Task<ResponseDto<List<FeedBackListDto>>> TechnicianFeedbak(long Id)
        {
            using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<FeedBackListDto>(sql: "[dbo].[spGetFeedbackListByTecnician]", param: new { TechnicianId = Id},
                   commandType: CommandType.StoredProcedure);
                var ResultByUser = result.ToList();
                if (!(result is null))
                {
                    return new ResponseDto<List<FeedBackListDto>>()
                    {
                        Data = ResultByUser
                    };
                }
                return new ResponseDto<List<FeedBackListDto>>();
            }
        }

    }
}
