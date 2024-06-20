using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Common
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BaseController : Controller
    {
    }
}