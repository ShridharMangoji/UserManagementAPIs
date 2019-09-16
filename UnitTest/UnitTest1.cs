using DAL.DbModels;
using UserManagementAPIs.Models;
using Xunit;

namespace UnitTest
{
    public class UnitTest1
    {
        [Theory(DisplayName = "Add User")]
        [InlineData("s1", 12, "s@s.com", "1234567890")]
        [InlineData("s2", 12, "s1@s.com", "1234567890")]

        public void TestAddUser(string name, int age, string email, string mobileNumber)
        {
            var con = new UserManagementAPIs.Controllers.UsersController();
            var userReq = new UserRequest()
            {
                User = new User()
                {
                    Age = age,
                    Email = email,
                    Name = name,
                    PhoneNumber = mobileNumber
                }
            };
            var result = con.AddUser(userReq);
            Assert.Equal(System.Net.HttpStatusCode.OK, result.HttpStatusCode);
        }

        [Theory(DisplayName = "Add Kid")]
        [InlineData(1, "s1", 12, "s")]
        [InlineData(2, "s2", 12, "s1")]

        public void TestAddKid(long userId, string firstName, int age, string lastName)
        {
            var con = new UserManagementAPIs.Controllers.KidController();
            var kidReq = new KidRequest()
            {
                Kid = new Kid()
                {
                    Age = age,
                    FirstName = firstName,
                    LastName = lastName,
                }

            };
            var result = con.AddKid(userId, kidReq);
            Assert.Equal(System.Net.HttpStatusCode.OK, result.HttpStatusCode);
        }

        [Theory(DisplayName = "Add Home")]
        [InlineData(1, "s1", "s", "s2", "s3")]
        [InlineData(1, "s123", "s", "s2", "s3")]

        public void TestAddHome(long userId, string homeType, string address, string state, string zipCode)
        {
            var con = new UserManagementAPIs.Controllers.HomeController();
            var komeReq = new HomeRequest()
            {
                Home = new Home()
                {
                    Address = address,
                    HomeType = homeType,
                    State = state,
                    Zipcode = zipCode,
                }

            };
            var result = con.AddHome(userId, komeReq);
            Assert.Equal(System.Net.HttpStatusCode.OK, result.HttpStatusCode);
        }



        [Theory(DisplayName = "Update User")]
        [InlineData(1, "s1", 12, "s@s.com", "1234567890")]
        [InlineData(2, "s2", 12, "s1@s.com", "1234567890")]

        public void TestUpdateUser(long userID, string name, int age, string email, string mobileNumber)
        {
            var con = new UserManagementAPIs.Controllers.UsersController();
            var userReq = new UserRequest()
            {
                User = new User()
                {
                    Id = userID,
                    Age = age,
                    Email = email,
                    Name = name,
                    PhoneNumber = mobileNumber
                }
            };
            var result = con.UpdateUser(userReq);
            Assert.Equal(System.Net.HttpStatusCode.OK, result.HttpStatusCode);
        }

        [Theory(DisplayName = "Update Kid")]
        [InlineData(1, 1, "s1", 12, "s")]
        [InlineData(2, 2, "s2", 12, "s1")]

        public void TestUpdateKid(long userId, long kidId, string firstName, int age, string lastName)
        {
            var con = new UserManagementAPIs.Controllers.KidController();
            var kidReq = new KidRequest()
            {
                Kid = new Kid()
                {
                    Id = kidId,
                    Age = age,
                    FirstName = firstName,
                    LastName = lastName,
                }

            };
            var result = con.UpdateKid(userId, kidReq);
            Assert.Equal(System.Net.HttpStatusCode.OK, result.HttpStatusCode);
        }

        [Theory(DisplayName = "Update Home")]
        [InlineData(1, 1, "s1", "s", "s2", "s3")]
        [InlineData(1, 2, "s123", "s", "s2", "s3")]

        public void TestUpdateHome(long userId, long homeId, string homeType, string address, string state, string zipCode)
        {
            var con = new UserManagementAPIs.Controllers.HomeController();
            var komeReq = new HomeRequest()
            {
                Home = new Home()
                {
                    Id = homeId,
                    Address = address,
                    HomeType = homeType,
                    State = state,
                    Zipcode = zipCode,
                }

            };
            var result = con.UpdateHome(userId, komeReq);
            Assert.Equal(System.Net.HttpStatusCode.OK, result.HttpStatusCode);
        }



        [Theory(DisplayName = "Get User")]
        [InlineData(1, 1)]
        [InlineData(2, 2)]

        public void TestGetUser(long userId, long count)
        {
            var con = new UserManagementAPIs.Controllers.UsersController();
            
            var result = con.GetUser(userId);
            Assert.Equal(System.Net.HttpStatusCode.OK, result.HttpStatusCode);
        }

        [Theory(DisplayName = "Get all User")]
        [InlineData(1)]
        [InlineData(2)]

        public void TestGetAllUser(long count)
        {
            var con = new UserManagementAPIs.Controllers.UsersController();
            
            var result = con.GetUser();
            Assert.Equal(System.Net.HttpStatusCode.OK, result.HttpStatusCode);
        }




    }
}
