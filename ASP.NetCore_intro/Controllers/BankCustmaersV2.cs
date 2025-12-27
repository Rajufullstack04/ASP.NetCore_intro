using Microsoft.AspNetCore.Mvc;

namespace ASP.NetCore_intro.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    // endpoint
    // https://localhost:7049/api/BankCoustmarsV2
    // https://localhost:7049/api/BankCoustmarsV2/GetAllCustmars
    public class BankCoustmarsV2Controller : ControllerBase
    {

        // Addscoped ,Addsinglton ,Addtransient




        private ICustmarRepository _ICustRepo;


        public BankCoustmarsV2Controller(ICustmarRepository repo)
        {
                       _ICustRepo = repo;
        }


        //---------------------------------------------



        [HttpGet("GetAllCustmarsV2")]
        public async Task<IActionResult> GetAllCustmarsV2()
        {
            //CusmorRepository repo = new CusmorRepository();
            var result = _ICustRepo._Custmars();
            await Task.Delay(1000);
            return Ok(result);
        }
    }

    public interface ICustmarRepository
    {
               List<CustmarV2> _Custmars();
    }








    public class InMemoryCusmorRepository : ICustmarRepository
    {  

        public List<CustmarV2> _Custmars()
        {
            return new List<CustmarV2>
            {
                new CustmarV2 { CustACNO = 243253466, CustName = "Raju", CustAmount = 5800000 },
                new CustmarV2 { CustACNO = 44844154, CustName = "Venky", CustAmount = 10265200 },
            };
        }
    }

    public class CustmarV2
    {
        public required string CustName { get; set; }
        public int CustACNO { get; set; }
        public double CustAmount { get; set; }
    }
}
