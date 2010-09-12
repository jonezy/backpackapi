using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using jonezy.org.BackpackAPI;
using System.Xml;

namespace BackpackTests
{
    [TestFixture]
    public class JournalObjectTests
    {
        Journal journal = null;
        //ListRequest testListRequest = null;
        XmlDocument journalXml = null;
        //XmlDocument listRequestXml = null;

        [SetUp]
        public void Setup()
        {
            journal = new Journal();
            journal.Id = "1";
            journal.Body = "Test";
            journal.CreatedAt = "10/11/2008";

            journalXml = journal.ToXml();
        }


        [Test]
        public void ConvertJournalToXml()
        {
            Assert.AreEqual("System.Xml.XmlDocument", journalXml.GetType().FullName);
        }

        [Test]
        public void ConvertJournalXmllToJournal()
        {
            Assert.AreEqual("Journal", journalXml.ToBackpackObject(typeof(Journal)).GetType().Name);
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
