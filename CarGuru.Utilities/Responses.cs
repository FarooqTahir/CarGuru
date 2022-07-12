using CarGuru.Database.Dtos;
using System;
using System.Net;

namespace CarGuru.Utilities
{
    public static class Responses
    {
        public static ResponseDto<dynamic> NotFound()
        {
            return new ResponseDto<dynamic>()
            {
                Status = Convert.ToInt32(HttpStatusCode.NotFound),
                Message = ResponseStrings.NotFound,
                Data = null
            };
        }

        public static ResponseDto<dynamic> Unauthorized()
        {
            return new ResponseDto<dynamic>()
            {
                Status = Convert.ToInt32(HttpStatusCode.Unauthorized),
                Message = ResponseStrings.Unauthorized,
                Data = null
            };
        }
    }
}
