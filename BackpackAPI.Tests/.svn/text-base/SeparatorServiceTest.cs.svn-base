
using System.Configuration;
using System.Xml;
using jonezy.org.BackpackAPI;
using jonezy.org.BackpackAPI.Interfaces;
using NUnit.Framework;

namespace BackpackTests
{
    [TestFixture]
    public class SeparatorServiceTests : TestBase
    {
        
        private string separatorId = string.Empty;
        private XmlDocument separatorResponse = null;

        [SetUp]
        public void Setup()
        {
            base.TestSetup();
        }

        [TearDown]
        public void TearDown()
        {
            if (!separatorId.Equals(string.Empty))
                DeleteSeparator();
        }

        // create tests
        [Test]
        public void CreatingASeparatorShouldReturnXml()
        {
            CreateSeparator();
            Assert.AreEqual("System.Xml.XmlDocument", separatorResponse.GetType().FullName, "Expected Xml, got null");
        }
        
        [Test]
        public void CreatingASeparatorShouldReturnThePageIdItWasCreatedOn()
        {
            CreateSeparator();
            Assert.AreEqual(testPageId, separatorResponse.SelectSingleNode("/separator/page-id").InnerText, "Expected the page id the separator was created on.");
        }

        [Test]
        public void CreatingASeparatorShouldReturnXmlWithASeparatorElement()
        {
            CreateSeparator();
            Assert.AreNotEqual(null, separatorResponse.SelectSingleNode("/separator"), "Expected a separator element, got null");
        }
        
        [Test]
        public void CreatingASeparatorOnAPageThatDoesntExistShouldReturn404()
        {
            XmlDocument actual = separatorService.Create("0", "Test Separator");
            Assert.AreEqual("404", actual.SelectSingleNode("/response/error").Attributes["code"].Value, "Expected a separator element, got null");
        }
        
        // update tests
        [Test]
        public void UpdatingASeparatorShouldReturnXml()
        {
            CreateSeparator();
            XmlDocument actual = UpdateSeparator();
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got something else");
        }

        [Test]
        public void UpdatingASeparatorShouldReturnAStatusCodeOf200()
        {
            CreateSeparator();
            XmlDocument actual = UpdateSeparator();
            Assert.AreEqual("200", actual.SelectSingleNode("/response/status").Attributes["code"].Value, "Expected a separator element, got null");
        }

        // destroy test
        public void DestroyingASeparatorShouldRemoveItemFromPage()
        {
            Assert.Fail("Not implemented");
        }

        [Test]
        public void DestroyingASeparatorShouldReturnAStatusCodeof204()
        {
            CreateSeparator();
            XmlDocument actual = DeleteSeparator();
            Assert.AreEqual("204", actual.SelectSingleNode("/response/status").Attributes["code"].Value, "Expected a separator element, got null");
        }


        // helper methods
        private XmlDocument CreateSeparator()
        {
            XmlDocument returnXml = separatorService.Create(testPageId, "Test Separator");
            separatorResponse = returnXml;
            separatorId = separatorResponse.SelectSingleNode("/separator/id").InnerText;

            return returnXml;
        }

        private XmlDocument DeleteSeparator()
        {
            XmlDocument results = separatorService.Destroy(testPageId, separatorId);
            separatorId = string.Empty;

            return results;
        }

        private XmlDocument UpdateSeparator()
        {
            XmlDocument updatedSeparator = separatorService.Update(testPageId, "Updated from test", separatorId);

            return updatedSeparator;
        }
    }
}
