namespace ASP.NetCore_intro.Services1
{
    public interface IAuthenticateService
    {


        //Token generation method
        string GenerateToken(string username, string password);
        bool ValidateToken(string token);



        //User validation method
        bool ValidateUser(string username, string password);


        bool ValidaToken(string token);


    }
}
