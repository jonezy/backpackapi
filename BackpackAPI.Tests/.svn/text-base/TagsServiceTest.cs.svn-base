using System;
using System.Configuration;
using jonezy.org.BackpackAPI;
using jonezy.org.BackpackAPI.Interfaces;
using NUnit.Framework;
using System.Xml;

namespace BackpackTests
{
    [TestFixture]
    public class TagsServiceTests : TestBase
    {

        [SetUp]
        public void Setup()
        {
            base.TestSetup();
        }

        // match page tests
        [Test]
        public void MatchingAValidPageShouldReturnXml()
        {
            XmlDocument actual = tagsService.MatchPage(testTagId);
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got null");
        }

        [Test]
        public void MatchingAValidPageShouldReturnTrue()
        {
            XmlDocument actual = tagsService.MatchPage(testTagId);
            Assert.AreEqual("true", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected Xml, got null");
        }

        [Test]
        public void MatchingAValidPageShouldReturnAPagesElement()
        {
            XmlDocument actual = tagsService.MatchPage(testTagId);
            Assert.AreNotEqual(null, actual.SelectSingleNode("/response/pages"), "Expected Xml, got null");
        }

        public void MatchingAnInvalidPageShouldReturnXml()
        {
            XmlDocument actual = tagsService.MatchPage("99999");
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got null");
        }

        [Test]
        public void MatchingAnInvalidPageShouldReturnFalse()
        {
            XmlDocument actual = tagsService.MatchPage("99999");
            Assert.AreEqual("false", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected Xml, got null");
        }

        [Test]
        public void MatchingAnInvalidPageShouldReturn404()
        {
            XmlDocument actual = tagsService.MatchPage("99999");
            Assert.AreEqual("404", actual.SelectSingleNode("/response/error").Attributes["code"].Value, "Expected Xml, got null");
        }

        // tag pages tests
        [Test]
        public void TaggingAValidPageShouldReturnXml()
        {
            XmlDocument actual = tagsService.TagPage(testPageId, "testtag");
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got null");
        }

        [Test]
        public void TaggingAValidPageShouldReturnTrue()
        {
            XmlDocument actual = tagsService.TagPage(testPageId, "testtag");
            Assert.AreEqual("true", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected Xml, got null");
        }

        [Test]
        public void TaggingAnInvalidPageShouldReturnXml()
        {
            XmlDocument actual = tagsService.TagPage("99999", "testtag");
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got null");
        }

        [Test]
        public void TaggingAnInvalidPageShouldReturnFalse()
        {
            XmlDocument actual = tagsService.TagPage("99999", "testtag");
            Assert.AreEqual("false", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected Xml, got null");
        }
    }
}
