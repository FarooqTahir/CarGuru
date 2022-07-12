using System;
using System.Linq;
using System.Security.Claims;
using CarGuru.Services.Interfaces;
using CarGuru.Utilities;
using Microsoft.AspNetCore.Http;

namespace CarGuru.Services.Services
{
    public class SessionManager : ISessionManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

        }
        public string GetProfilePicture()
        {
            return _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == SessionStrings.ProfilePicture)?.Value;
        }

        public string GetRole()
        {
            return _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
        }

        public string GetSessionId()
        {
            return _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == SessionStrings.SessionId)?.Value;
        }

        public string GetTokenSession()
        {
            return _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == SessionStrings.TokenSession)?.Value;
        }

        public long GetUserId()
        {
            var UserId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == SessionStrings.UserId)?.Value;
            return Convert.ToInt64(UserId);
        }
        public void SetProfilePicture(string Url) 
        {
            var Identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            Identity.RemoveClaim(Identity.FindFirst(SessionStrings.ProfilePicture));
            Identity.AddClaim(new Claim(SessionStrings.ProfilePicture, Url));
        }

        public string GetUsername()
        {
            return _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == SessionStrings.UserName)?.Value;
        }

        public int GetUserRoleId()
        {
            var Id = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == SessionStrings.UserRoleId)?.Value;
            var RoleId = Convert.ToInt32(Id);
            return RoleId;
        }

        public void SetUserName(string Name)
        {
            var Identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            Identity.RemoveClaim(Identity.FindFirst(SessionStrings.UserName));
            Identity.AddClaim(new Claim(SessionStrings.UserName, Name));
        }

    }
}
