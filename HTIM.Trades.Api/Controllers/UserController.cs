
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HTIM.Trades.Api.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Produces(MediaTypeNames.Application.Json)]
    //[Authorize]
    public class UserController : Controller
    {
        public UserController()
        { 


        }
        [HttpGet]
        [Route("user/profile")]
        public  async Task<ActionResult> GetUserProfile()
        {
            var response = User.Identities.FirstOrDefault().Name.Split('@')[0].Replace('.',' ');
            return Ok(response);
        }
    }
}
