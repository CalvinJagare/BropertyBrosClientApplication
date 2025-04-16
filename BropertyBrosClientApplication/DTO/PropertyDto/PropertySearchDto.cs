namespace BropertyBrosClientApplication.DTO.Properties
{
    public class PropertySearchDto
    {
        public int? MinPrice { get; set; } = null;
        public int? MaxPrice { get; set; } = null;
        public int? MinMonthlyFee { get; set; } = null;
        public int? MaxMonthlyFee { get; set; } = null;
        public int? MinYearlyFee { get; set; } = null;
        public int? MaxYearlyFee { get; set; } = null;
        public int? MinLivingAreaKvm { get; set; } = null;
        public int? MaxLivingAreaKvm { get; set; } = null;
        public int? MinAncillaryAreaKvm { get; set; } = null;
        public int? MaxAncillaryAreaKvm { get; set; } = null;
        public int? MinLandAreaKvm { get; set; } = null;
        public int? MaxLandAreaKvm { get; set; } = null;
        public int? MinNumberOfRooms { get; set; } = null;
        public int? MaxNumberOfRooms { get; set; } = null;
        public int? MinBuildYear { get; set; } = null;
        public int? MaxBuildYear { get; set; } = null;
        public int? CityId { get; set; } = null;
        public int? CategoryId { get; set; } = null;
    }
}
