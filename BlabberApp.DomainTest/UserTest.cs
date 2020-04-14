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
        public void TestChangeEmail_Fail00()
        {
            //arrange
            User harness = new User();
            //act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("foobar"));
            //assert
            Assert.AreEqual("Email Invalid", ex.Message);
        }

        [TestMethod]
        public void TestGetUserID_Fail_01()
        {
             // Arrange
            User harness = new User(); 
            // Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.ChangeEmail("foobar.example"));
            // Assert
            Assert.AreEqual("Email Invalid", ex.Message.ToString());
        }

         [TestMethod]
         public void TestChangeEmailExistingUser()
         {
             User user = new User("foobar@example.com");
             string newEmail = "barfoo@example.com";
             user.ChangeEmail(newEmail);
            Assert.AreEqual(newEmail, user.Email);
         }


    }

}