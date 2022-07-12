using CarGuru.Services.Interfaces;
using CarGuru.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarGuru
{
    public static class CommonData
    {
        public static string GetUserLayoutByRoleId(int roleId)
        {
            if (roleId == Convert.ToInt32(UserRoles.Management))
            {
                return "~/Views/Shared/_Layout.cshtml";
            }
            else if (roleId == Convert.ToInt32(UserRoles.Agent))
            {
                return "~/Views/Shared/_LayoutCallCenter.cshtml";
            }
            else if (roleId == Convert.ToInt32(UserRoles.Supervisor))
            {
                return "~/Views/Shared/_LayoutSupervisor.cshtml";
            }
            return " ";

        }
    }
}
