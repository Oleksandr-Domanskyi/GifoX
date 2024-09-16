using System.Net.Http.Json;
using Coupons.Service.Core.Dto;
using Product.Shared.Contracts;
using Product.Shared.Requests;
using Product.Shared.Responses;

namespace Product.Shared.ApiClients
{
    public class CouponHttpClient : ICouponHttpClient
    {
        private readonly HttpClient _httpClient;

        public CouponHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<CouponDto> GetSharedCouponeByCode(string couponCode)
        {
            var request = new Request
            {
                Url = $"Coupone/UseCupone/{couponCode}",
                Data = new StringContent(string.Empty)
            };
            var response = await _httpClient.PutAsync(request.Url, request.Data);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadFromJsonAsync<Response<CouponDto>>();

                if (responseData!.IsSuccess || responseData.Content != null)
                {
                    return responseData!.Content;
                }
                throw new Exception($"Parsing error: {responseData.Message}");
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"CouponHttpClient response error: {response.StatusCode} - {errorMessage}");
            }
        }
    }
}
