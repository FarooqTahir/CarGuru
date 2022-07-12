using System.ComponentModel.DataAnnotations;
using CarGuru.Database.Dtos.BaseDto;

namespace CarGuru.Database.Dtos.RequestDto
{
    public class UserRequestDto:UserBaseDto
    {
        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password mismatch")]
        public string ConfirmPassword { get; set; }
    }
}