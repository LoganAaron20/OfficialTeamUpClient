using System.Net.Http.Json;

namespace OfficialTeamUpClient.Services
{
    public static class ApiClient
    {
        private static HttpClient _httpClient;

        public static void Initialize(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public static async Task<TResponse> GetAsync<TResponse>(string endpoint)
        {
            EnsureHttpClientInitialized();
            var response = await _httpClient.GetFromJsonAsync<TResponse>(endpoint);
            return response;
        }

        public static async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest request)
        {
            EnsureHttpClientInitialized();
            var response = await _httpClient.PostAsJsonAsync(endpoint, request);
            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

        private static void EnsureHttpClientInitialized()
        {
            if (_httpClient == null)
            {
                throw new InvalidOperationException($"{nameof(ApiClient)} has not been initialized. Call {nameof(Initialize)} with a valid HttpClient instance.");
            }
        }
    }
}
