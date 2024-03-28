using LegacyApp;

namespace LegacyAppTest
{
    public class UserServiceTests
    {
        [Fact]
        public void AddUser_DoesntAdd_WhenNoNameWasProvided()
        {
            // Arrange
            var service = new UserService();

            // Act
            var result = service.AddUser(null, null, "kowalski@wp.pl", new DateTime(1990, 1, 1), 1);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void AddUser_DoesntAdd_WhenUserProvidesInvalidEmail()
        {
            var service = new UserService();

            var result = service.AddUser("Jan", "Kowalski", "jankowlaskwppl", new DateTime(1990, 1, 1), 1);

            Assert.False(result);
        }

        [Fact]
        public void AddUser_DoesntAdd_WhenUserIsTooYoung()
        {
            var service = new UserService();

            var result = service.AddUser("Jan", "Kowalski", "jankowlaski.wp.pl", DateTime.Now, 1);

            Assert.False(result);
        }

        [Fact]
        public void AddUser_ThrowsException_WhenUserDoesNotExist()
        {
            var service = new UserService();

            Assert.Throws<ArgumentException>(() =>
            {
                var result = service.AddUser("Jan", "Kowalski", "jankowlaski.wp.pl", new DateTime(1990, 1, 1), 100);
            });
        }
    }
}