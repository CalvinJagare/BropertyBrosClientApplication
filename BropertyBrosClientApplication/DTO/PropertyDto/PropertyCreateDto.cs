namespace BropertyBrosClientApplication.DTO.Properties
{
    //Author: Calvin, Daniel, Emil
    public class PropertyCreateDto
    {
        public string? Address { get; set; }
        public int Price { get; set; }
        public int MonthlyFee { get; set; }
        public int YearlyFee { get; set; }
        public int LivingAreaKvm { get; set; }
        public int AncillaryAreaKvm { get; set; } // garage, balkong, källare etc
        public int LandAreaKvm { get; set; }
        public string? Description { get; set; }
        public int NumberOfRooms { get; set; }
        public int BuildYear { get; set; }
        public virtual List<string> ImageUrls { get; set; } = new List<string>();

        public int RealtorId { get; set; }
        public int CityId { get; set; }
        public int CategoryId { get; set; }
    }
}
