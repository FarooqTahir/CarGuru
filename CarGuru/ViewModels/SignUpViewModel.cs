using System.Collections.Generic;
using CarGuru.Database.Dtos.RequestDto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarGuru.ViewModels
{
    public class SignUpViewModel
    {
        public SignUpViewModel()
        {
            SecurityQuestions= new List<SelectListItem>();
        }
        public List<SelectListItem> SecurityQuestions { get; set; }

        public  UserRequestDto Customer { get; set; }
        public  UserRequestDto Technician { get; set; }

        public bool IsCustomer { get; set; }
    }
}