namespace CarGuru.Database.Dtos.BaseDto
{
    public class CustomerTypeBaseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool? IsActive { get; set; }
        public short? Margin { get; set; }
    }
}