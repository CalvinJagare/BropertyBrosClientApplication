using BropertyBrosApi2._0.DTOs.Realtor;

namespace BropertyBrosApi2._0.DTOs.RealtorFirm
{
    //Author: Calvin, Daniel, Emil
    public class RealtorFirmReadDto
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }
        public string? WebsiteUrl { get; set; }
        public virtual List<RealtorReadDto> Realtors { get; set; } = new List<RealtorReadDto>();
    }
}
