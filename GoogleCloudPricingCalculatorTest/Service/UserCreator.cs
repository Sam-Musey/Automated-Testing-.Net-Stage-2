using GoogleCloudPricingCalculatorTest.Model;

namespace GoogleCloudPricingCalculatorTest.Service
{
    public class UserCreator
    {
        public static User CreateUserWithCredentialsFromProperty()
        {
            string username = TestDataReader.GetUsername();
            string password = TestDataReader.GetPassword();
            return new User(username, password);
        }
    }
}

