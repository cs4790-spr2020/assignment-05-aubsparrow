using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain;

namespace BlabberApp.DomainTest
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestSetEmailNewUser()
        {
            //arragne
            string email = "foobar@example.com";
            User harness = new User(email);
            //act
            string actual = harness.Email;
            Assert.AreEqual(actual, email);
        }

        [TestMethod]
        public void TestGetUserID_Fail_0()
        {
            //arrange
            User harness = new User();
            //act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("foobar"));
            //assert
            Assert.AreEqual("Email Invalid", ex.Message);
        }

        [TestMethod]
        public void TestGetUserID_Fail_1()
        {
             // Arrange
            User harness = new User(); 
            // Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("foobar.example"));
            // Assert
            Assert.AreEqual("Email Invalid", ex.Message.ToString());
        }

         [TestMethod]
        public void TestGetSysId()
        {
            User harness = new User();
            string expected = harness.getSysId();
            //act & assert
            string actual = harness.getSysId();
            Assert.AreEqual(actual, expected);
            Assert.IsInstanceOfType(harness.getSysId(), typeof(string));
        }


    }

}