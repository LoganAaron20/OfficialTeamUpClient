using OfficialTeamUpClient.Models;
using OfficialTeamUpClient.ViewModels;
using System.Security.Claims;

namespace OfficialTeamUpClient.User
{
    public interface IUserService
    {
        UserProfile User { get; }
        Task<bool> LoginAsync(LoginViewModel loginModel);
        Task LogoutAsync();
        bool IsUserAuthenticated { get; }
    }
}
