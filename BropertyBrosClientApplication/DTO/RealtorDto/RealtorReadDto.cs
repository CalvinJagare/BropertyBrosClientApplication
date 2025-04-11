namespace BropertyBrosApi2._0.DTOs.Realtor
{
    //Author: Calvin, Daniel, Emil
    public class RealtorReadDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? ProfileUrl { get; set; }
        public int RealtorFirmId { get; set; }
        public virtual string? CompanyName { get; set; } = string.Empty;
        public virtual string? LogoUrl { get; set; } = string.Empty;
        public virtual string? WebsiteUrl { get; set; } = string.Empty;
    }
}
