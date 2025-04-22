using BropertyBrosClientApplication.DTO.Properties;

namespace BropertyBrosClientApplication.DTO.Realtor
{
    //Author: Calvin, Daniel, Emil
    //Co-Author: Arlind
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
