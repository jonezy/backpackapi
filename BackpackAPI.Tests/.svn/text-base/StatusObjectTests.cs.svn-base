using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using jonezy.org.BackpackAPI;
using System.Xml;

namespace BackpackTests
{
    [TestFixture]
    public class StatusObjectTests
    {
        Status status = null;
        //ListRequest testListRequest = null;
        XmlDocument statusXml = null;
        //XmlDocument listRequestXml = null;

        [SetUp]
        public void Setup()
        {
            status = new Status();
            status.Id = "1";
            status.Message = "Status Update";
            status.UpdatedAtType = "datetime";
            status.UpdatedAt = "10/11/2008";

            statusXml = status.ToXml();

        }


        [Test]
        public void ConvertStatusToXml()
        {
            Assert.AreEqual("System.Xml.XmlDocument", statusXml.GetType().FullName);
        }

        [Test]
        public void ConvertStatusXmllToStatus()
        {
            Assert.AreEqual("Status", statusXml.ToBackpackObject(typeof(Status)).GetType().Name);
        }

        //[Test]
        //public void ConvertNoteRequestToXml()
        //{
        //    Assert.AreEqual("System.Xml.XmlDocument", listRequestXml.GetType().FullName);
        //}

        //[Test]
        //public void ConvertNoteRequestXmlToNoteRequest()
        //{
        //    Assert.AreEqual("ListRequest", listRequestXml.ToBackpackObject(typeof(ListRequest)).GetType().Name);
        //}
    }
}
