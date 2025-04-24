using Blazored.LocalStorage;

namespace BropertyBrosClientApplication.Services.Base2
{
    public class BaseHttpService
    {
        private readonly IClient client;
        private readonly ILocalStorageService localStorage;

        public BaseHttpService(IClient client, ILocalStorageService localStorage)
        {
            this.client = client;
            this.localStorage = localStorage;
        }

        protected Response<Guid> ConvertApiExeptions<Guid>(ApiException apiException)
        {
            
        }
    }
}
