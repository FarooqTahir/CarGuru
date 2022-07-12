using CarGuru.Database.Dtos.RequestDto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarGuru.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel() 
        {
            Genders = new List<SelectListItem>();
        }
        public UserUpdateDto User { get; set; }
        public List<SelectListItem> Genders { get; set; }
    }
}
