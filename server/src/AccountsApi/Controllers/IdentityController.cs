using System.Linq;
using HotChocolate.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Workshop.Accounts.Api.Controllers
{
    [Route("identity")]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        public IActionResult Get()
        {
            var header = HttpContext.Request.Headers["Authorization"];

            var claims = from c in User.Claims select new { c.Type, c.Value };
            
            return new JsonResult(new
            {
                header = header,
                claims = claims
            });
        }
    }
}