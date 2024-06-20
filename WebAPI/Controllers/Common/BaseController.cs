using Microsoft.AspNetCore.Mvc;
using WebAPI.Infrastructure.Interfaces;

namespace WebAPI.Controllers.Common
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BaseController : Controller
    {
        private ICandidateService _candidateService;

        protected ICandidateService Profile => _candidateService ??= HttpContext.RequestServices.GetService<ICandidateService>();
    }
}