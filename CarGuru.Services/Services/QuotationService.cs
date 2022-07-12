using AutoMapper;
using CarGuru.Database.ApisDtos;
using CarGuru.Database.Dtos;
using CarGuru.Database.Dtos.BaseDto;
using CarGuru.Database.Dtos.ResponseDto;
using CarGuru.Database.Models;
using CarGuru.Services.Interfaces;
using CarGuru.Utilities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGuru.Services.Services
{
    public class QuotationService : IQuotationService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public QuotationService(ApplicationDbContext dbContext, IMapper mapper
        )
        {
            _db = dbContext;
            _mapper = mapper;
        }
        public async Task<ResponseDto<QuotationResponseDto>> AddQuotationRequest(QuotationRequestDto model)
        {
            long customerId = _db.Customers.Where(x => x.UserId == model.CustomerId).FirstOrDefault().Id;
            var quotation = _mapper.Map<QuotationRequestDto, Qoutations>(model);
            quotation.CreatedDate = DateTime.UtcNow;
            quotation.CustomerId = customerId;
            if (quotation.CustomerId.HasValue) quotation.CreatedById = quotation.CustomerId.Value;
            if (!(model.Services is null) && model.Services.Any())
            {
                foreach (var prod in model.Services)
                {
                    var quotProduct = _mapper.Map<QuotationProduct, ProductsInQoutations>(prod);
                    quotation.ProductsInQoutations.Add(quotProduct);
                }
            }
            var Agents = _db.Users.Where(x => x.RoleId == 2).ToList();
            Random Ram = new Random();
            var index = Ram.Next(Agents.Count);
            var randomAgent = Agents[index];
            Notifications noti = new Notifications();
            var Notification = new Notifications()
            {
                NotificationTo = randomAgent.UserId,
                NotificationFrom = model.CustomerId,
                CreatedDate = DateTime.UtcNow,
                Message = "New Quotation Request",
                TypeId = Convert.ToInt32(NotificationTypes.NewQuotationRequest)
            };

            _db.Notifications.Add(Notification);
            _db.Qoutations.Add(quotation);
            await _db.SaveChangesAsync();
            var response = _mapper.Map<Qoutations, QuotationResponseDto>(quotation);
            return new ResponseDto<QuotationResponseDto>() {
                Data = response
            };
        }
        public ResponseDto<QuotationResponseDto> AddQuotationRequestW(QuotationDto model)
        {
            var quotation = _mapper.Map<QuotationDto, Qoutations>(model);
            quotation.CreatedDate = DateTime.UtcNow;
            if (quotation.CustomerId.HasValue) quotation.CreatedById = quotation.CustomerId.Value;
            model.Products = model.Products.GroupBy(a => a.ProductId).Select(g => g.First()).Where(a => a.ProductId != 0).ToList();
            if (!(model.Products is null) && model.Products.Any())
            {
                foreach (var prod in model.Products)
                {
                    var quotProduct = _mapper.Map<ProductInQuotationDto, ProductsInQoutations>(prod);
                    quotation.ProductsInQoutations.Add(quotProduct);
                }
            }
            _db.Qoutations.Add(quotation);
            _db.SaveChanges();
            var response = _mapper.Map<Qoutations, QuotationResponseDto>(quotation);
            return new ResponseDto<QuotationResponseDto>()
            {
                Data = response
            };
        }
        public async Task<ResponseDto<List<QuotationRequestListSpResponseDto>>> GetQuotationRequestList(string Name)
        {
            using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<QuotationRequestListSpResponseDto>(sql: "[dbo].[spGetQuotationRequest]", param: new { name = Name },
                   commandType: CommandType.StoredProcedure);
                var List = result.ToList().OrderBy(x => x.QuotationId).ToList();
                if (!(result is null))
                {
                    return new ResponseDto<List<QuotationRequestListSpResponseDto>>()
                    {
                        Data = List
                    };
                }
                return new ResponseDto<List<QuotationRequestListSpResponseDto>>();
            }
        }
        public async Task<ResponseDto<List<QuotationRequestListSpResponseDto>>> GetQuotationRequestListByCustomerId(long UserId)
        {
            using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<QuotationRequestListSpResponseDto>(sql: "[dbo].[spGetQuotationRequest]",
                   commandType: CommandType.StoredProcedure);
                var ResultByUser = result.ToList();
                ResultByUser = ResultByUser.Where(x => x.CustomerUserId == UserId).ToList();
                if (!(result is null))
                {
                    return new ResponseDto<List<QuotationRequestListSpResponseDto>>()
                    {
                        Data = ResultByUser
                    };
                }
                return new ResponseDto<List<QuotationRequestListSpResponseDto>>();
            }
        }
        public async Task<ResponseDto<QuotationDetailSpResponseDto>> GetQuotationDetailByQuotationId(long quotationId)
        {
            await using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<string>(sql: "[dbo].[spGetQuotationDetailByQuotationId]", param: new { QuotationId = quotationId },
                commandType: CommandType.StoredProcedure);
                StringBuilder builder = new StringBuilder();
                foreach (var r in result)
                {
                    builder.Append(r);
                }
                var response = JsonConvert.DeserializeObject<QuotationDetailSpResponseDto>(builder.ToString());
                //var projects = _mapper.Map<GetProjectsWithMembersByUserDto>(response.Projects);

                return new ResponseDto<QuotationDetailSpResponseDto>()
                {
                    Data = response
                };

            }
        }
        public async Task<ResponseDto<UpdateQuotationResponseDto>> UpdateQuotationProduct(long quotationId, long quotationDetailId = 0, long productId = 0)
        {
            if (quotationDetailId > 0 && productId > 0)
            {
                var quotation = _db.ProductsInQoutations.FirstOrDefault(a => a.Id == quotationDetailId);
                if (!(quotation is null))
                {
                    quotation.ProductId = productId;
                    _db.Entry(quotation).State = EntityState.Modified;
                    _db.SaveChanges();
                    var product = _db.Products.FirstOrDefault(a => a.Id == productId);
                    if (!(product is null))
                    {
                        var response = new UpdateQuotationResponseDto();
                        if(product.SalePrice.HasValue) response.SalePrice = product.SalePrice.Value;
                        response.TotalPrice = 0;
                        response.Margin = 0;
                        response.DiscountPrice = 0;

                        await using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
                        {
                            var result = await conn.QueryAsync<string>(sql: "[dbo].[spGetQuotationDetailByQuotationId]", param: new { QuotationId = quotation.QoutationId },
                            commandType: CommandType.StoredProcedure);
                            StringBuilder builder = new StringBuilder();
                            foreach (var r in result)
                            {
                                builder.Append(r);
                            }
                            var data = JsonConvert.DeserializeObject<QuotationDetailSpResponseDto>(builder.ToString());
                            foreach (var quo in data.QuotationProducts)
                            {
                                if (!(quo.ProductPrice == null))
                                {
                                    response.TotalPrice = response.TotalPrice + quo.ProductPrice.Value;
                                }
                                response.Margin = response.Margin + Convert.ToDouble(quo.ProductDiscount);
                            }
                            response.Margin = response.Margin / data.QuotationProducts.Count;
                        }

                        double MarginPrice = response.TotalPrice * (response.Margin / 100);
                        response.DiscountPrice = response.TotalPrice - MarginPrice;
                        var DbQuotation = _db.Qoutations.Where(a => a.Id == quotationId).FirstOrDefault();
                        DbQuotation.TotalPrice = Convert.ToDecimal(response.DiscountPrice);
                        _db.Entry(DbQuotation).State = EntityState.Modified;
                        var re = _db.SaveChanges();

                        return new ResponseDto<UpdateQuotationResponseDto>()
                        {
                            Data = response
                        };
                    }
                }

            }
            return new ResponseDto<UpdateQuotationResponseDto>()
            {
                Data = new UpdateQuotationResponseDto(),
                Status = 0
            };


        }
        public bool AddDescription(string description, long QuotationId) 
        {
            var dbQuotation = _db.Qoutations.Where(x => x.Id == QuotationId).FirstOrDefault();
            dbQuotation.Description = description;
            _db.Entry(dbQuotation).State = EntityState.Modified;
            var result = _db.SaveChanges();
            if (result > 0) return true;
            return false;
        }
        public async Task<ResponseDto<List<QuotationListApiDto>>> QuotationsListM()
        {
            using (var conn = new SqlConnection(_db.Database.GetDbConnection().ConnectionString))
            {
                var result = await conn.QueryAsync<QuotationListApiDto>(sql: "[dbo].[spGetQuotationListForManagement]",
                   commandType: CommandType.StoredProcedure);
                var List = result.ToList().OrderBy(x => x.QuotationId).ToList();
                if (!(result is null))
                {
                    return new ResponseDto<List<QuotationListApiDto>>()
                    {
                        Data = List
                    };
                }
                return new ResponseDto<List<QuotationListApiDto>>();
            }
        }
    }
}
