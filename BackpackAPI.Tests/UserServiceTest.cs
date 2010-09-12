using System.Configuration;
using System.Xml;

using jonezy.org.BackpackAPI;
using NUnit.Framework;
using jonezy.org.BackpackAPI.Interfaces;

namespace BackpackTests
{
    [TestFixture]
    public class UserServiceTests : TestBase
    {

        [SetUp]
        public void Setup()
        {
            base.TestSetup();
        }

        // show tests
        [Test]
        public void ShowUserShouldReturnXml()
        {
            XmlDocument actual = userService.Show(testUserId);
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got null");
        }

        [Test]
        public void ShowUserShouldNotBeNull()
        {
            XmlDocument actual = userService.Show(testUserId);
            Assert.AreNotEqual(null, actual, "Got null");
        }

        [Test]
        public void ShowUserShouldReturnValidUser()
        {
            XmlDocument actual = userService.Show(testUserId);
            Assert.AreNotEqual("0", actual.SelectSingleNode("/user").Attributes["id"].Value, "Expected a valid user id but got 0");
        }

        // list tests
        [Test]
        public void ListUsersShouldReturnXml()
        {
            XmlDocument actual = userService.List();
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got null");
        }

        [Test]
        public void ListUsersShouldNotBeNull()
        {
            XmlDocument actual = userService.List();
            Assert.AreNotEqual(null, actual, "Got null");
        }

        [Test]
        public void ListUsersShouldReturnResponseTypeOfArray()
        {
            XmlDocument actual = userService.List();
            Assert.AreEqual("array", actual.SelectSingleNode("/users").Attributes["type"].Value, "Expected a response type of array, got something else");
        }

        [Test]
        public void ListUsersShouldReturnAListOfUsers()
        {
            XmlDocument actual = userService.List();
            Assert.AreNotEqual(0, actual.SelectSingleNode("/users").ChildNodes.Count, "Expected a response type of array, got something else");
        }
    }
}
