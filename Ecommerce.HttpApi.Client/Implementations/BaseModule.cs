using Ecommerce.Responses;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Ecommerce.HttpApi.Client.Implementations
{
    public class BaseModule
    {
        protected HttpClient _httpClient;
        public BaseModule(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        protected async Task<T> Post<T,B>(string url, B body)
        {
            var request = await this._httpClient.PostAsync(url, JsonContent.Create<B>(body));
            request.EnsureSuccessStatusCode();
            var response = await request.Content.ReadFromJsonAsync<BaseResponse<T>>();
            if(response.StatusCode>=200 && response.StatusCode < 300)
            {
                return response.Result;
            }
            throw new HttpRequestException(response.Message, new Exception(response.Details??""));
        }

        protected async Task<T> Get<T>(string url)
        {
            var request = await this._httpClient.GetAsync(url);
            request.EnsureSuccessStatusCode();
            var response = await request.Content.ReadFromJsonAsync<BaseResponse<T>>();
            if (response.StatusCode >= 200 && response.StatusCode < 300)
            {
                return response.Result;
            }
            throw new HttpRequestException(response.Message, new Exception(response.Details ?? ""));
        }
    }
}
