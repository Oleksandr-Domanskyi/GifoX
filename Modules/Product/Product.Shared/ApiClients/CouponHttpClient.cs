using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Product.Shared.Contracts;
using Product.Shared.Dtos;
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

        public async Task<CouponeResponse<CouponeDtoResponse>> ApplyCouponeAsync(string couponCode)
        {
            if (string.IsNullOrWhiteSpace(couponCode))
            {
                throw new ArgumentException("Coupon code cannot be null or empty.", nameof(couponCode));
            }
            var request = new CouponeRequest
            {
                Url = $"/UseCupone/{couponCode}",
                Data = new StringContent(string.Empty)
            };
            var response = await _httpClient.PutAsync(request.Url, request.Data);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadFromJsonAsync<CouponeResponse<CouponeDtoResponse>>();

                if (responseData == null)
                {
                    throw new Exception("Received empty response data");
                }

                return responseData;
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"CouponHttpClient response error: {response.StatusCode} - {errorMessage}");
            }
        }
    }
}
