using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using WebApiPrueba;
using WebApiPrueba.Services;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void IsValid_UserNameAndLastNameIsRequired()
        {
            UserService userService = new UserService();
            BOUser objUser = new BOUser() { Name = "  ", LastName = " " };

            var resp = userService.IsValid(objUser);

            Assert.IsFalse(resp);
        }

        [Test]
        public void CreateUser_IfObjectIsInvalid_AssignResulObject()
        {
            BOUser objUser = new BOUser();
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(us => us.IsValid(objUser)).Returns(false);
            mockUserService.SetupGet(x => x.Errors).Returns(new List<string>() { "Error" });

            UserCO userCO = new UserCO(mockUserService.Object);

            var resp = userCO.CreateUser(objUser);

            Assert.IsNotNull(resp);
        }
    }
}