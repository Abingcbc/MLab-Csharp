using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using community.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Net.Http.Headers;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace community.Controllers
{

    [Route("user")]
    [ApiController]
    [ApiVersion(ApiVersionName.V1)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "The MIME type in the Accept HTTP header is not acceptable.", typeof(ProblemDetails))]
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CA1062 // Validate arguments of public methods
    public class UserController : ControllerBase
    {

    }
}
