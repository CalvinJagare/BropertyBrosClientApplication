namespace BropertyBrosClientApplication.Services
{
    public partial class Client : IClient
    {
        public HttpClient Httpclient
        {
            get
            {
                return _httpClient;
            }
        }

    }
}
