namespace ASP.NetCore_intro.Contracts
{
    public interface IJWTAuthentication
    {

        string GenareteJWTToken(string Username, string Password);

        bool ValidateJWTToken(string token);






    }
}
