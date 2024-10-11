using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using PhoneBook.Application.Security;

namespace PhoneBook.Application.UserFilters;

public class UserContext:IUserContext
{
    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        var token = httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
        if (!string.IsNullOrEmpty(token))
        {
            var claimPrinciple = TokenGenerator.ValidateToken(token);
            if (claimPrinciple != null)
            {
                var userId = claimPrinciple.Claims.FirstOrDefault(x => x.Type == "userid")?.Value;
                var userName = claimPrinciple.Claims.FirstOrDefault(x => x.Type == "userName")?.Value;
                UserId = Guid.Parse(userId);
                UserName = userName;
            }
        }
        else
        {
           // throw new AuthenticationException();
        }
    }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
}