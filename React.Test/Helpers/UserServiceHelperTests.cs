using Moq;
using React.Helpers;
using React.Repository.Interfaces;
using Xunit;

namespace React.Test.Helpers
{
    public class UserServiceHelperTests
    {
        public UserServiceHelperTests()
        {

        }


        [Fact]
        public void TestIsUniqueUser()
        {
            string name = "Janitha";
            var moqrepo = new Mock<IUserRepository>();
            moqrepo.Setup(x => x.isUsernameUnique(name)).Returns(true);
            UserServiceHelper userServiceHelper = new UserServiceHelper(moqrepo.Object);

            bool isUnique = userServiceHelper.IsUniqueName("Janitha");

            Assert.True(isUnique);
        }

        [Fact]
        public void TestIsUniqueEmail()
        {
            string email = "JanithaT";
            var moqrepo = new Mock<IUserRepository>();
            moqrepo.Setup(x => x.isEmailUnique(email)).Returns(true);
            UserServiceHelper userServiceHelper = new UserServiceHelper(moqrepo.Object);

            bool isUnique = userServiceHelper.IsUniqueEmail("JanithaT");

            Assert.True(isUnique);
        }
    }
}
