using Microsoft.AspNetCore.Mvc;

namespace StayGreen.Controllers.Common
{
    [Route("api/{controller}")]
    [ApiController]
    public class BaseApiController : ControllerBase 
    {
    }
}
