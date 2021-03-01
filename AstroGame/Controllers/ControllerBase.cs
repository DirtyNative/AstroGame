using Microsoft.AspNetCore.Mvc;

namespace AstroGame.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public abstract class ControllerBase : Controller
    {
    }
}