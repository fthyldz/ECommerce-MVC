using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Presentation.WebUI.Middlewares;

public class CustomAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly UserManager<User> _userManager;
    
    public CustomAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger,
        UrlEncoder encoder, ISystemClock clock, UserManager<User> userManager) : base(options, logger, encoder, clock)
    {
        _userManager = userManager;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        string authorizationHeader = Request.Headers["Authorization"];

        if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Basic "))
        {
            return AuthenticateResult.Fail("Missing or invalid Authorization header");
        }

        // Decode and validate user credentials
        var encodedCredentials = authorizationHeader.Substring("Basic ".Length).Trim();
        var credentialBytes = Convert.FromBase64String(encodedCredentials);
        var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
        var email = credentials[0];
        var password = credentials[1];

        // Validate user credentials against your data store (database, etc.)
        var user = await _userManager.FindByEmailAsync(email);

        var roles = await _userManager.GetRolesAsync(user);

        // Create claims
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName)
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
}