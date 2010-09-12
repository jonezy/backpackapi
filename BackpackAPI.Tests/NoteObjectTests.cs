using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using jonezy.org.BackpackAPI;
using System.Xml;

namespace BackpackTests
{
    [TestFixture]
    public class NoteObjectTests
    {
        Note testNote = null;
        NoteRequest testNoteRequest = null;
        XmlDocument noteXml = null;
        XmlDocument noteRequestXml = null;

        [SetUp]
        public void Setup()
        {
            testNote = new Note();
            testNote.Id = "1";
            testNote.Title = "Test Note";
            testNote.CreatedAt = "Today";
            testNote.NoteBody = "This is a test note";

            noteXml = testNote.ToXml();

            testNoteRequest = new NoteRequest();
            testNoteRequest.Title = "Test Note";
            testNoteRequest.Body = "This is a test note";

            noteRequestXml = testNoteRequest.ToXml();
        }


        [Test]
        public void ConvertNoteToXml()
        {
            Assert.AreEqual("System.Xml.XmlDocument", noteXml.GetType().FullName);
        }

        [Test]
        public void ConvertNoteXmlToNote()
        {
            Assert.AreEqual("Note", noteXml.ToBackpackObject(typeof(Note)).GetType().Name);
        }

        [Test]
        public void ConvertNoteRequestToXml()
        {
            Assert.AreEqual("System.Xml.XmlDocument", noteRequestXml.GetType().FullName);
        }

        [Test]
        public void ConvertNoteRequestXmlToNoteRequest()
        {
            Assert.AreEqual("NoteRequest", noteRequestXml.ToBackpackObject(typeof(NoteRequest)).GetType().Name);
        }
    }
}
