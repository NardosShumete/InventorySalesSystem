using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InventorySales.Desktop
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7069/api";

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/{endpoint}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PostAsync($"{BaseUrl}/{endpoint}", content);
            response.EnsureSuccessStatusCode();
            
            var resultJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(resultJson);
        }

        public async Task DeleteAsync(string endpoint)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{endpoint}");
            response.EnsureSuccessStatusCode();
        }
    }

    public class RegisterDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }

    public class DashboardDto
    {
        public decimal DailySales { get; set; }
        public int LowStockCount { get; set; }
        public int TotalProducts { get; set; }
    }

    public class SaleDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Tax { get; set; }
        public List<SalesDetailDto> SalesDetails { get; set; }
    }

    public class SalesDetailDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }
    }
}
