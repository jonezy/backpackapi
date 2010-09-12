using System.Configuration;
using System.Xml;

using jonezy.org.BackpackAPI;
using NUnit.Framework;
using jonezy.org.BackpackAPI.Interfaces;

namespace BackpackTests
{
    [TestFixture]
    public class PageServiceTests : TestBase
    {
        
        private XmlDocument page = null;
        private string pageId = string.Empty;

        [SetUp]
        public void Setup()
        {
            base.TestSetup();

        }
        [TearDown]
        public void TearDown()
        {
            if (!pageId.Equals(string.Empty))
                DestroyPage();
        }

        // Show tests
        [Test]
        public void ShowPageShouldReturnXml()
        {
            XmlDocument actual = pageService.Show(testPageId);
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got null");
        }

        [Test]
        public void ShowPageShouldNotBeNull()
        {
            XmlDocument actual = pageService.Show(testPageId);
            Assert.AreNotEqual(null, actual, "Got null");
        }

        [Test]
        public void ShowPageShouldReturnResponseOfTrue()
        {
            XmlDocument actual = pageService.Show(testPageId);
            Assert.AreEqual("true", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected a response of true, got something else.");
        }

        [Test]
        public void ShowPageShouldReturnXmlWithAPageElement()
        {
            XmlDocument actual = pageService.Show(testPageId);
            Assert.AreEqual("page", actual.SelectSingleNode("/response").FirstChild.Name, "Expected a response of true, got something else.");
        }


        // List tests
        [Test]
        public void ListPagesShouldReturnXml()
        {
            XmlDocument actual = pageService.List();
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got null");
        }

        [Test]
        public void ListPagesShouldNotBeNull()
        {
            XmlDocument actual = pageService.Show(testPageId);
            Assert.AreNotEqual(null, actual, "Got null");
        }

        [Test]
        public void ListPagesShouldReturnResponseOfTrue()
        {
            XmlDocument actual = pageService.List();
            Assert.AreEqual("true", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected a response of true, got something else.");
        }

        [Test]
        public void ListPagesShouldReturnAListOfPages()
        {
            XmlDocument actual = pageService.List();
            Assert.AreNotEqual(0, actual.SelectSingleNode("/response/pages").ChildNodes.Count, "Expected a response of true, got something else.");
        }

        // search tests
        [Test]
        public void SearchingPagesShouldReturnXml()
        {
            XmlDocument actual = pageService.Search("test");
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got something else.");
        }

        [Test]
        public void SearchingPagesShouldReturnAPagesElement()
        {
            XmlDocument actual = pageService.Search("test");
            Assert.AreNotEqual(null, actual.SelectSingleNode("/response/pages"), "Expected a response of true, got something else.");
        }

        [Test]
        public void SearchingPagesShouldReturnTrue()
        {
            XmlDocument actual = pageService.Search("test");
            Assert.AreEqual("true", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected a response of true, got something else.");
        }

        // email tests
        [Test]
        public void EmailingAValidPageShouldReturnXml()
        {
            XmlDocument actual = pageService.Email(testPageId);
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got something else.");
        }

        [Test]
        public void EmailingAValidPageShouldReturnTrue()
        {
            XmlDocument actual = pageService.Email(testPageId);
            Assert.AreEqual("true", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected a response of true, got something else.");
        }

        [Test]
        public void EmailingAnInvalidPageShouldReturnXml()
        {
            XmlDocument actual = pageService.Email("99999");
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got something else.");
        }

        [Test]
        public void EmailingAnInvalidPageShouldReturnFalse()
        {
            XmlDocument actual = pageService.Email("99999");
            Assert.AreEqual("false", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected a response of true, got something else.");
        }

        // Create tests
        [Test]
        public void CreatePageWithPageTitleShouldNotBeNull()
        {
            XmlDocument actual = CreatePage();
            Assert.AreNotEqual(null, actual, "Got null");
        }

        [Test]
        public void CreatePageWithPageTitleShouldReturnXml()
        {
            XmlDocument actual = CreatePage();
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected xml, got something else.");
        }

        [Test]
        public void CreatePageWithPageTitleShouldReturnTrue()
        {
            XmlDocument actual = CreatePage();
            Assert.AreEqual("true", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected a response of true, got something else.");
        }

        [Test]
        public void CreatePageWithPageTitleShouldReturnXmlWithAPageElement()
        {
            XmlDocument actual = CreatePage();
            Assert.AreEqual("page", actual.SelectSingleNode("/response").FirstChild.Name, "Expected a response of true, got something else.");
        }

        // Delete tests
        [Test]
        public void DeleteAValidPageShouldReturnXml()
        {
            CreatePage();
            XmlDocument actual = DestroyPage();
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Got null");
        }

        [Test]
        public void DeleteAValidPageShouldReturnTrue()
        {
            CreatePage();
            XmlDocument actual = DestroyPage();
            Assert.AreEqual("true", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected a response of true, got something else.");
        }

        [Test]
        public void DeleteAnInValidPageShouldReturnFalse()
        {
            pageId = string.Empty;
            XmlDocument actual = pageService.Destroy("666");
            Assert.AreEqual("false", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected a response of true, got something else.");
        }


        // Update title tests
        [Test]
        public void UpdateTitleShouldNotBeNull()
        {
            CreatePage();
            XmlDocument actual = UpdateTitle();
            Assert.AreNotEqual(null, actual, "Got null");
        }

        [Test]
        public void UpdateTitleShouldReturnXml()
        {
            CreatePage();
            XmlDocument actual = UpdateTitle();
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected xml, got something else.");
        }

        [Test]
        public void UpdateTitleShouldReturnTrue()
        {
            CreatePage();
            XmlDocument actual = UpdateTitle();
            Assert.AreEqual("true", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected a response of true, got something else.");
        }


        // helper methods
        private XmlDocument CreatePage()
        {
            page = pageService.Create(testPageTitle);
            pageId = page.SelectSingleNode("/response/page").Attributes["id"].Value;

            return page;
        }

        private XmlDocument DestroyPage()
        {
            XmlDocument results = pageService.Destroy(pageId);
            pageId = string.Empty;

            return results;
        }

        private XmlDocument UpdateTitle()
        {
            XmlDocument updatedPage = pageService.UpdateTitle(pageId, "Updated from test");

            return updatedPage;
        }
    }
}
