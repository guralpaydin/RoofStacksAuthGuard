using AuthGuard.Entities;
using AuthGuard.Model;
using AuthGuard.Services;
using Moq;
using Xunit;

namespace AuthGuardTest.ServiceTest
{
    public class UserServiceTest
    {
        private readonly Mock<IUserService> userService;
        public UserServiceTest()
        {
            userService = new Mock<IUserService>();
        }

        [Fact]
        public void User_Authenticate_ShouldReturnAuthenticateResponse()
        {
            ///Arrange
            AuthenticateRequest request = new AuthenticateRequest();
            User user = new User();
            AuthenticateResponse expectedValue = new AuthenticateResponse(user, "", "");
            userService.Setup(e => e.Authenticate(request)).Returns(expectedValue);

            ///Act
            var result = userService.Object.Authenticate(request);

            ///Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void User_Authenticate_ShouldReturnNull()
        {
            ///Arrange
            AuthenticateResponse expectedValue = null;
            userService.Setup(e => e.Authenticate(null)).Returns(expectedValue);

            ///Act
            var result = userService.Object.Authenticate(null);

            ///Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void User_RefreshToken_ShouldReturnAuthenticateResponse()
        {
            ///Arrange
            string token = "";
            User user = new User();
            AuthenticateResponse expectedValue = new AuthenticateResponse(user, "", "");
            userService.Setup(e => e.RefreshToken(token)).Returns(expectedValue);

            ///Act
            var result = userService.Object.RefreshToken(token);

            ///Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void User_ValidateToken_ShouldReturnValidateTokenResponse()
        {
            ///Arrange            
            ValidateTokenRequest request = new ValidateTokenRequest();
            ValidateTokenResponse expectedValue = new ValidateTokenResponse(true);
            userService.Setup(e => e.ValidateToken(request)).Returns(expectedValue);

            ///Act
            var result = userService.Object.ValidateToken(request);

            ///Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void User_ValidateToken_ShouldReturnNull()
        {
            ///Arrange            
            ValidateTokenRequest request = new ValidateTokenRequest();
            request.Token = null;
            ValidateTokenResponse expectedValue = null;
            userService.Setup(e => e.ValidateToken(request)).Returns(expectedValue);

            ///Act
            var result = userService.Object.ValidateToken(request);

            ///Assert
            Assert.Equal(expectedValue, result);
        }
    }
}
