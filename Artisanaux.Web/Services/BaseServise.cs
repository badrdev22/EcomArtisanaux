using Artisanaux.Web.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Artisanaux.Web.Services.IServices
{
    public class BaseServise : IBaseServise
    {
        public ResponseDto ResponseModel { get; set; }
        public IHttpClientFactory _clientFactory { get;}

        public BaseServise(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            ResponseModel = new ResponseDto();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = _clientFactory.CreateClient("ArtisanauxAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept","application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if(apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8,
                        "application/json"
                        );
                }
                if (!string.IsNullOrEmpty(apiRequest.Token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",apiRequest.Token);
                }
                HttpResponseMessage apiResponse = null;

                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;

                }
                apiResponse = await client.SendAsync(message);
                var apiConent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiConent);
                return apiResponseDto;

            }
            catch (Exception ex)
            {
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string> { Convert.ToString(ex.Message) },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;
            }
        }
    }
}