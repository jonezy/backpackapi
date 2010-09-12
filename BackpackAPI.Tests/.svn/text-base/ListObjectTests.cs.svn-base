using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using jonezy.org.BackpackAPI;
using System.Xml;

namespace BackpackTests
{
    [TestFixture]
    public class ListObjectTests
    {
        List testList = null;
        ListRequest testListRequest = null;
        XmlDocument listXml = null;
        XmlDocument listRequestXml = null;

        [SetUp]
        public void Setup()
        {
            testList = new List();
            testList.Id = "1";
            testList.Name = "Test List";

            listXml = testList.ToXml();

            testListRequest = new ListRequest();
            testListRequest.Name = "Test Note";

            listRequestXml = testListRequest.ToXml();
        }


        [Test]
        public void ConvertNoteToXml()
        {
            Assert.AreEqual("System.Xml.XmlDocument", listXml.GetType().FullName);
        }

        [Test]
        public void ConvertNoteXmlToNote()
        {
            Assert.AreEqual("List", listXml.ToBackpackObject(typeof(List)).GetType().Name);
        }

        [Test]
        public void ConvertNoteRequestToXml()
        {
            Assert.AreEqual("System.Xml.XmlDocument", listRequestXml.GetType().FullName);
        }

        [Test]
        public void ConvertNoteRequestXmlToNoteRequest()
        {
            Assert.AreEqual("ListRequest", listRequestXml.ToBackpackObject(typeof(ListRequest)).GetType().Name);
        }
    }
}
