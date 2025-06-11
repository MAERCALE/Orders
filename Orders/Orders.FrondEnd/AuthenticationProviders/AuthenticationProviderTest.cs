using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace Orders.FrondEnd.AuthenticationProviders
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await Task.Delay(500); 
            var anonimous = new ClaimsIdentity();
            var user = new ClaimsIdentity(authenticationType: "test");
            var admin = new ClaimsIdentity(new List<Claim>
            {
                new Claim("FirstName", "Mario"),
                new Claim("LastName", "Lazo"),
                new Claim(ClaimTypes.Name, "mlazo@yopmail.com"),
                new Claim(ClaimTypes.Role, "Admin")
            },
    authenticationType: "test");

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(user)));
        }
    }
}
 