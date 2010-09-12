using System.Configuration;
using System.Xml;

using jonezy.org.BackpackAPI;
using NUnit.Framework;
using jonezy.org.BackpackAPI.Interfaces;

namespace BackpackTests
{
    [TestFixture]
    public class StatusServiceTests : TestBase
    {
        
        private string statusEntryId = string.Empty;

        [SetUp]
        public void Setup()
        {
            base.TestSetup();
        }


        // extension method tests
        [Test]
        public void ConvertListStatusesResponseXmlToStatusesObjectShouldBeOfStatusesType()
        {
            XmlDocument actual = statusService.List();
            Assert.AreEqual("Statuses", actual.ToBackpackObject(typeof(Statuses)).GetType().Name);
        }

        [Test]
        public void ConvertShowStatusResponseXmlToStatusObjectShouldBeOfStatusType()
        {
            XmlDocument actual = statusService.Show(testUserId);
            Assert.AreEqual("Status", actual.ToBackpackObject(typeof(Status)).GetType().Name);
        }

        // list tests
        [Test]
        public void ListShouldReturnXml()
        {
            XmlDocument actual = statusService.List();
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got null");
        }

        [Test]
        public void ListShouldReturnXmlWithAStatusesElement()
        {
            XmlDocument actual = statusService.List();
            Assert.AreNotEqual(null, actual.SelectSingleNode("/statuses"), "Expected a statuses element");
        }

        // show tests
        [Test]
        public void ShowStatusShouldReturnXml()
        {
            XmlDocument actual = statusService.Show(testUserId);
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got null");
        }

        [Test]
        public void ShowStatusShouldReturnXmlWithAStatusElement()
        {
            XmlDocument actual = statusService.Show(testUserId);
            Assert.AreNotEqual(null, actual.SelectSingleNode("/status"), "Expected a statuses element");
        }

        [Test]
        public void ShowStatusShouldReturnXmlWithStatusForTheSpecifiedUser()
        {
            XmlDocument actual = statusService.Show(testUserId);
            Assert.AreEqual(testUserId, actual.SelectSingleNode("/status/user-id").InnerText, "Expected a statuses element");
        }

        [Test]
        public void ShowStatusForInvalidUserShouldReturnACodeOf404()
        {
            XmlDocument actual = statusService.Show("0");
            Assert.AreEqual("404", actual.SelectSingleNode("/response/error").Attributes["code"].Value, "Expected a return status of 200, got something else.");
        }

        // update tests
        [Test]
        public void UpdatingAStatusForAValidUserShouldReturnXml()
        {
            XmlDocument actual = UpdateStatus();
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got null");
        }

        [Test]
        public void UpdatingAStatusForAValidUserShouldReturnACodeOf200()
        {
            XmlDocument actual = UpdateStatus();
            Assert.AreEqual("200", actual.SelectSingleNode("/response/status").Attributes["code"].Value, "Expected a return status of 200, got something else.");
        }

        [Test]
        public void UpdatingStatusForAnInvalidUserShouldReturnACodeOf404()
        {
            XmlDocument actual = statusService.Update(testInvalidUserId, "Updated from test");
            Assert.AreEqual("404", actual.SelectSingleNode("/response/error").Attributes["code"].Value, "Expected a return status of 200, got something else.");
        }

        [Test]
        public void UpdatingStatusForAUserNotInAccountShouldReturnACodeOf404()
        {
            XmlDocument actual = statusService.Update("0", "Updated from test");
            Assert.AreEqual("404", actual.SelectSingleNode("/response/error").Attributes["code"].Value, "Expected a return status of 200, got something else.");
        }

        // helper methods
        private XmlDocument UpdateStatus()
        {
            XmlDocument updatedTitle = statusService.Update(testUserId, "Updated from test");

            return updatedTitle;
        }
    }
}
