using System.ComponentModel.DataAnnotations;

namespace CarGuru.Database.Dtos.BaseDto
{
    public class UserBaseDto
    {
        public long UserId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public int GenderId { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        public int SecurityQuestionId { get; set; }
        [Required]
        public string Answer { get; set; }
        [Required]
        [Display(Name = "Type")]
        public int RoleId { get; set; }
        public string ProfileUrl { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        
    }
}