﻿using Microsoft.AspNetCore.Mvc;

namespace StayGreen.Controllers.Common
{
    [Route("api/{controller}")]
    [Produces("application/json")]
    [ApiController]
    public class BaseApiController : ControllerBase 
    {
    }
}
