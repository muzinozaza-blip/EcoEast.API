using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;
namespace EcoEast.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private static readonly ConcurrentDictionary<string, DemoAccount> Accounts = new(StringComparer.OrdinalIgnoreCase)
    {
        ["resident@ecoeast.demo"] = new("Resident Demo", "resident@ecoeast.demo", "EcoEast123!", "resident", "Southernwood", "Active"),
        ["manager@ecoeast.demo"] = new("Manager Demo", "manager@ecoeast.demo", "EcoEast123!", "manager", "BCMM", "Active"),
        ["worker@ecoeast.demo"] = new("Field Worker Demo", "worker@ecoeast.demo", "EcoEast123!", "worker", "Quigney", "Active"),
        ["admin@ecoeast.demo"] = new("IT Admin Demo", "admin@ecoeast.demo", "EcoEast123!", "admin", "System", "Active")
    };

    [HttpPost("login")]
    public IActionResult Login(LoginInput input)
    {
        if (string.IsNullOrWhiteSpace(input.Email) || string.IsNullOrEmpty(input.Password)) return BadRequest(new { message = "Email and password are required." });
        if (!Accounts.TryGetValue(input.Email.Trim(), out var account) || account.Password != input.Password || account.Role != input.Role || account.Status != "Active")
            return Unauthorized(new { message = "Email, password, account type is incorrect, or account is disabled." });
        return Ok(account.Public());
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterInput input)
    {
        if (string.IsNullOrWhiteSpace(input.Name) || string.IsNullOrWhiteSpace(input.Email) || string.IsNullOrWhiteSpace(input.Area) || input.Password.Length < 8)
            return BadRequest(new { message = "Name, email, area and a password of at least 8 characters are required." });
        var email = input.Email.Trim();
        var account = new DemoAccount(input.Name.Trim(), email, input.Password, "resident", input.Area.Trim(), "Active");
        if (!Accounts.TryAdd(email, account)) return Conflict(new { message = "An account with this email already exists." });
        return Ok(account.Public());
    }

    [HttpGet("accounts")]
    public IActionResult GetAccounts() => Ok(Accounts.Values.Select(x => x.Public()).OrderBy(x => x.Name));

    [HttpPost("accounts")]
    public IActionResult CreateAccount(CreateAccountInput input)
    {
        if (string.IsNullOrWhiteSpace(input.Name) || string.IsNullOrWhiteSpace(input.Email) || string.IsNullOrWhiteSpace(input.Area) || input.Password.Length < 8 || !new[] { "resident", "manager", "worker", "admin" }.Contains(input.Role))
            return BadRequest(new { message = "Provide a name, valid email, role, area and password of at least 8 characters." });
        var email = input.Email.Trim();
        var account = new DemoAccount(input.Name.Trim(), email, input.Password, input.Role, input.Area.Trim(), "Active");
        if (!Accounts.TryAdd(email, account)) return Conflict(new { message = "An account with this email already exists." });
        return Ok(account.Public());
    }

    [HttpPatch("accounts/{email}/status")]
    public IActionResult UpdateStatus(string email, StatusInput input)
    {
        if (!Accounts.TryGetValue(email, out var account)) return NotFound(new { message = "Account not found." });
        if (input.Status is not ("Active" or "Disabled")) return BadRequest(new { message = "Status must be Active or Disabled." });
        var updated = account with { Status = input.Status };
        Accounts[email] = updated;
        return Ok(updated.Public());
    }

    public record LoginInput(string Email, string Password, string Role);
    public record RegisterInput(string Name, string Email, string Password, string Area);
    public record CreateAccountInput(string Name, string Email, string Password, string Role, string Area);
    public record StatusInput(string Status);
    public record PublicAccount(string Name, string Email, string Role, string Area, string Status);
    private record DemoAccount(string Name, string Email, string Password, string Role, string Area, string Status)
    { public PublicAccount Public() => new(Name, Email, Role, Area, Status); }
}
