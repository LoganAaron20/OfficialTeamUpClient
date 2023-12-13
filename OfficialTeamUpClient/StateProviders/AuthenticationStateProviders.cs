using Microsoft.AspNetCore.Components.Authorization;
using OfficialTeamUpClient.User;
using System.Security.Claims;

namespace OfficialTeamUpClient.StateProviders
{
    public class CustomAuthenticationStateProviders : AuthenticationStateProvider
    {
        private readonly IUserService User;

        public CustomAuthenticationStateProviders(IUserService user)
        {
            User = user;    
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = User.IsUserAuthenticated
                ? new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, User.User.DisplayName) }, "custom")
                : new ClaimsIdentity();

            var user = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(user));
        }

        public void NotifyAuthenticationStateChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
