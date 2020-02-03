using BlazorExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorExample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        // GET api/settings/user
        [HttpGet("user")]
        public AuthorizedUser GetUser()
        {
            // User not signed in:
            return new AuthorizedUser();

            // User signed in:
            //return new AuthorizedUser { Name = "John Doe" };
        }
    }
}
