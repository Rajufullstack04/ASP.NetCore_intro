using ASP.NetCore_intro.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;

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
        // https://localhost:7049/api/Railway/getrailwaydetails
        [HttpGet]
        [Route("getrailwaydetails")]
        public IActionResult GetRailwayDetails()
        {
            return Ok(new
            {
                Message = "Railway bookings are 25"
            });
        }

        [HttpGet]
        [Route("GetDECRailwaydetails")]
        [Authorize(Roles = "RailwayOficer")]
        // endpoint :https://localhost:7049/api/Railway/GetDECRailwaydetails
        public IActionResult GetDECRailwaydetails()
        {
            return Ok(new
            {
                Message ="Railway bookings in Dec 100000 keep this very sencitive data...."

            });
        }



        // https://localhost:7049/api/Railway/MyBookings
        [HttpGet]
        [Route("MyBookings")]
        public IActionResult MyBookings()
        {
            var Bookings = new[]
            {
                 new { PNR = "4567891230", Train = "Vande Bharat", Date = "2026-01-10", Status = "Confirmed" },
                 new { PNR = "9876543210", Train = "Godavari Express", Date = "2026-02-02", Status = "Waiting List" }
            };
            return Ok(Bookings);
        }









    }
} 
