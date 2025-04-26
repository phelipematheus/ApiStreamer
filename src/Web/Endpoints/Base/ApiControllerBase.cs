using System.Security.Claims;
using CrossCutting.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Web.Endpoints.Base;

public abstract class ApiControllerBase : ControllerBase
{
    protected string UserId => HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new UnauthorizedException();
}
