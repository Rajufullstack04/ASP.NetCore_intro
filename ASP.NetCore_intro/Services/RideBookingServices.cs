using ASP.NetCore_intro.Interfaces;
using ASP.NetCore_intro.Interfaces;

namespace ASP.NetCore_intro.Services
{
    public class SingletonVehicle : ISingletonVehicle
    {
        private readonly string _id;

        public SingletonVehicle()
        {
            _id = "VEH-" + Guid.NewGuid().ToString();
        }

        public string GetVehicleId() => _id;
    }

    public class ScopedRide : IScopedRide
    {
        private readonly string _id;

        public ScopedRide()
        {
            _id = "RIDE-" + Guid.NewGuid().ToString();
        }

        public string GetRideId() => _id;
    }

    public class TransientTicket : ITransientTicket
    {
        private readonly string _id;

        public TransientTicket()
        {
            _id = "TKT-" + Guid.NewGuid().ToString();
        }

        public string GetVehicleId() => _id;
    }
}
