using Microsoft.AspNetCore.Mvc;

namespace ASP.NetCore_intro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // endpoint
    // https://localhost:7049/api/BankCoustmarsV1
    // https://localhost:7049/api/BankCoustmarsV1/GetAllCustmars
    public class BankCoustmarsV1Controller : ControllerBase
    {
        [HttpGet("GetAllCustmars")]
        public async Task<IActionResult> GetAllCustmars()
        {
            CusmorRepository repo = new CusmorRepository();
            var result = repo._Custmars();
            await Task.Delay(1000);
            return Ok(result);
        }
    }

    public class CusmorRepository
    {
        public List<Custmar> _Custmars()
        {
            return new List<Custmar>
            {
                new Custmar { CustACNO = 243253466, CustName = "Raju", CustAmount = 5800000 },
                new Custmar { CustACNO = 44844154, CustName = "Venky", CustAmount = 10265200 },
            };
        }
    }

    public class Custmar
    {
        public required string CustName { get; set; }
        public int CustACNO { get; set; }
        public double CustAmount { get; set; }
    }
}
