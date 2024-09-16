using System;
using System.Net.Http.Json;
using Coupon.Shared.Contracts;
using Product.Shared.Responses;
using Shared.Core.ProductShared.Dto;

namespace Coupon.Shared.ApiClients;

public class ProductHttpClient : IProductHttpClient
{
    private readonly HttpClient _httpClient;

    public ProductHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException();
    }

    public async Task<double> GetProductPrice(Guid id)
    {
        var request = new
        {
            Url = $"Product/{id}",
        };
        var response = await _httpClient.GetAsync(request.Url);

        if (response.IsSuccessStatusCode)
        {
            var responseData = await response.Content.ReadFromJsonAsync<Response<ProductDto>>();
            if (responseData != null && responseData.IsSuccess)
            {
                return responseData.Content.PrNetto;
            }
            throw new Exception($"Error to convert response in Product get price method: {responseData!.Message}");

        }
        throw new Exception($"Status code: {response.StatusCode}, Get Product Price response error!!!");
    }
}
