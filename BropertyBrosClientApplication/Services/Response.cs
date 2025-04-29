namespace BropertyBrosClientApplication.Services
{
    public class ApiResponse<T>
    {
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; } = false;
        public T Data { get; set; } = default!;
        public string ValidationErrors { get; set; } = string.Empty;
    }
}
