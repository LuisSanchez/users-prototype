using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using User.Application.DTOs;
using User.Application.Interfaces;

namespace User.Infrastructure.Services
{
    public class KeycloakAuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;

        public KeycloakAuthService(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            _config = config;
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task RegisterUser(RegisterDto registerDto)
        {
            var keycloakSettings = _config.GetSection("Keycloak");
            var adminToken = await GetAdminToken();

            var user = new
            {
                username = registerDto.Email, // Use email as username
                email = registerDto.Email,
                enabled = true,
                credentials = new[] 
                {
                    new 
                    {
                        type = "password",
                        value = registerDto.Password,
                        temporary = false
                    }
                }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, 
                $"{keycloakSettings["ServerUrl"]}/admin/realms/{keycloakSettings["Realm"]}/users");
            request.Headers.Add("Authorization", $"Bearer {adminToken}");
            request.Content = new StringContent(JsonSerializer.Serialize(user), 
                Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var keycloakSettings = _config.GetSection("Keycloak");
            
            var formData = new Dictionary<string, string>
            {
                {"client_id", keycloakSettings["ClientId"]},
                {"client_secret", keycloakSettings["ClientSecret"]},
                {"grant_type", "password"},
                {"username", loginDto.Email}, // Use email for login
                {"password", loginDto.Password}
            };

            var response = await _httpClient.PostAsync(
                $"{keycloakSettings["ServerUrl"]}/realms/{keycloakSettings["Realm"]}/protocol/openid-connect/token",
                new FormUrlEncodedContent(formData));

            response.EnsureSuccessStatusCode();
            
            var tokenResponse = await response.Content.ReadFromJsonAsync<KeycloakTokenResponse>();
            return tokenResponse?.AccessToken ?? throw new Exception("Invalid token response");
        }

        private async Task<string> GetAdminToken()
        {
            var keycloakSettings = _config.GetSection("Keycloak");
            var formData = new Dictionary<string, string>
            {
                {"client_id", "admin-cli"},
                {"grant_type", "password"},
                {"username", keycloakSettings["AdminUser"]},
                {"password", keycloakSettings["AdminPassword"]}
            };

            var response = await _httpClient.PostAsync(
                $"{keycloakSettings["ServerUrl"]}/realms/master/protocol/openid-connect/token",
                new FormUrlEncodedContent(formData));

            response.EnsureSuccessStatusCode();
            
            var tokenResponse = await response.Content.ReadFromJsonAsync<KeycloakTokenResponse>();
            return tokenResponse?.AccessToken ?? throw new Exception("Failed to get admin token");
        }

        public Task RequestPasswordReset(string email)
        {
            // Implement password reset logic using Keycloak's API
            throw new NotImplementedException();
        }
    }

    public class KeycloakTokenResponse
    {
        public string AccessToken { get; set; }
    }
}
