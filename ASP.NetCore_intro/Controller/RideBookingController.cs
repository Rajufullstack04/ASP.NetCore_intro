using ASP.NetCore_intro.Interfaces;
using ASP.NetCore_intro.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Introduction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // https://localhost:7049/api/RideBooking
    public class RideBookingController : ControllerBase
    {
        private ISingletonVehicle _vehicle1;
        private ISingletonVehicle _vehicle2;

        private IScopedRide _ride1;
        private IScopedRide _ride2;

        private ITransientTicket _ticket1;
        private ITransientTicket _ticket2;

        public RideBookingController(
            ISingletonVehicle vehicle1,
            ISingletonVehicle vehicle2,
            IScopedRide ride1,
            IScopedRide ride2,
            ITransientTicket ticket1,
            ITransientTicket ticket2)
        {
            _vehicle1 = vehicle1;
            _vehicle2 = vehicle2;

            _ride1 = ride1;
            _ride2 = ride2;

            _ticket1 = ticket1;
            _ticket2 = ticket2;
        }

        [HttpGet("GetRide")]
        // https://localhost:7049/api/RideBooking/GetRide
        public IActionResult GetRide()
        {
            var result = new
            {
                Singleton = new RideType
                {
                    id1 = _vehicle1.GetVehicleId(),
                    id2 = _vehicle2.GetVehicleId()
                },
                Scoped = new RideType
                {
                    id1 = _ride1.GetRideId(),
                    id2 = _ride2.GetRideId()
                },
                Transient = new RideType
                {
                    id1 = _ticket1.GetVehicleId(),
                    id2 = _ticket2.GetVehicleId()
                }
            };

            return Ok(result);
        }
    }

    public class RideType
    {
        public string id1 { get; set; }
        public string id2 { get; set; }
    }
}
