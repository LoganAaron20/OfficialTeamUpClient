using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using OfficialTeamUpClient.Models;
using OfficialTeamUpClient.Services;
using OfficialTeamUpClient.StateProviders;
using OfficialTeamUpClient.ViewModels;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace OfficialTeamUpClient.User
{
    public class UserService : IUserService
    {
        private readonly NavigationManager NavigationManager;

        public UserService(NavigationManager navigationManager)
        {
            NavigationManager = navigationManager;
        }

        private UserProfile _user;

        public UserProfile User => _user;

        public bool IsUserAuthenticated { get; private set; } = false;

        public async Task<bool> LoginAsync(LoginViewModel loginModel)
        {
            try
            {
                if (string.IsNullOrEmpty(loginModel.Username))
                {
                    Console.WriteLine("Invalid username...");
                    return false;
                }

                if (string.IsNullOrEmpty(loginModel.Password))
                {
                    Console.WriteLine("Invalid password...");
                    return false;
                }

                using var httpClient = new HttpClient
                {
                    BaseAddress = new Uri("https://localhost:7065"),
                };

                //var response = await httpClient.PostAsJsonAsync<LoginViewModel>("/login", loginModel);

                var response = await httpClient.PostAsJsonAsync<LoginViewModel>("/api/account/login", loginModel);

                if (response.IsSuccessStatusCode)
                {
                    var userContent = await response.Content.ReadAsStringAsync();
                    UserProfile CurrentUser = Newtonsoft.Json.JsonConvert.DeserializeObject<UserProfile>(userContent);

                    this._user = CurrentUser;

                    IsUserAuthenticated = true;

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return false;
            }
        }

        public async Task<bool> RegisterAsync(RegisterViewModel registerModel)
        {
            try
            {
                if (string.IsNullOrEmpty(registerModel.DisplayName))
                {
                    Console.WriteLine("Invalid username...");
                    return false;
                }

                using var httpClient = new HttpClient
                {
                    BaseAddress = new Uri("https://localhost:7065"),
                };

                var response = await httpClient.PostAsJsonAsync<RegisterViewModel>("/api/users/CreateUser", registerModel);

                if (response != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return false;
            }
        }

        public async Task LogoutAsync()
        {
            IsUserAuthenticated = false;
            _user = null;

            NavigationManager.NavigateTo("/login");
        }
    }
}
