namespace CarGuru.Database.Dtos.BaseDto
{
    public class EmployeeBaseDto
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public int? EmployeeTypeId { get; set; }

    }
}