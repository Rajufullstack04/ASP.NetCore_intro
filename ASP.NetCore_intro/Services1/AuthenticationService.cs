

namespace ASP.NetCore_intro.Services1
{
    public class AuthenticationService : IAuthenticateService

    {
        private static readonly string myToken = "rajudfnehfi3@^&BUHOfjvjnn&&hhs";

        //Token generation method
        public string GenerateToken(string username, string password)
        {
            // In a real application, you would generate a JWT or similar token here

            // return "rajudfnehfi3@^&BUHOfjvjnn&&hhs";
            if (username == "Raju" && password == "raju$52141")
            {

                return myToken;

            }
            else
            {
                return "Invalid user credentials";
            }

            // throw new NotImplementedException();

        }
        //User validation method
        public bool ValidateUser(string username, string password)
        {
            // In a real application, you would validate against a database
            // return username == "Raju" && password == "raju$52141";

            bool isValid = myToken.Contains(username);


            if (!isValid)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ValidateToken(string validateToken)
        {

            //bool isValid = myToken.Contains(username);

            if (validateToken == myToken)
            {
                return true;
            }
            else
            {
                return false;


                //throw new NotImplementedException();
            }

        }

        public bool ValidaToken(string token)
        {
            throw new NotImplementedException();
        }
    }
   
}
