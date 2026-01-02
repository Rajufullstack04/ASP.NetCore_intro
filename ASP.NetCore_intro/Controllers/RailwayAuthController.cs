using ASP.NetCore_intro.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ASP.NetCore_intro.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RailwayController : ControllerBase
    {
        IJWTAuthentication _jWTAuthenticatoin;

        public RailwayController(IJWTAuthentication jWTAuthenticatoin)
        {
            _jWTAuthenticatoin = jWTAuthenticatoin;
        }

        [HttpGet]
        [Route("/getrailwaydetails")]
        public IActionResult GetRailwayDetails()
        {
            return Ok(new
            {
                Message = "Railway bookings are 25"
            });
        }
    }
}
