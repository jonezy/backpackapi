using System;
using System.Collections.Generic;
using System.Text;
using jonezy.org.BackpackAPI;
using jonezy.org.BackpackAPI.Interfaces;
using NUnit.Framework;
using System.Xml;
using System.Configuration;


namespace BackpackTests
{
    [TestFixture]
    public class NotesServiceTests : TestBase
    {
        String noteId = string.Empty;
        XmlDocument note = null;

        [SetUp]
        public void Setup()
        {
            base.TestSetup();
        }

        [TearDown]
        public void TearDown()
        {
            if (!noteId.Equals(string.Empty))
                DestroyNote();
        }

        // extension method tests
        [Test]
        public void ConvertCreateNoteResponseXmlToNoteResponseObjectShouldBeOfNoteResponseType()
        {
            CreateNote();
            Assert.AreEqual("NoteResponse", note.ToBackpackObject(typeof(NoteResponse)).GetType().Name);
        }

        [Test]
        public void ConvertListNoteResponseXmlToListNoteResponseObjectShouldBeOfListNoteResponseType()
        {
            CreateNote();
            Assert.AreEqual("NotesListResponse", note.ToBackpackObject(typeof(NotesListResponse)).GetType().Name);
        }

        [Test]
        public void ConvertUpdateNoteResponseXmlToResponseObjectShouldBeOfResponseType()
        {
            CreateNote();
            XmlDocument actual = UpdateNote();
            Assert.AreEqual("BackpackResponse", actual.ToBackpackObject(typeof(BackpackResponse)).GetType().Name);
        }

        // list tests
        [Test]
        public void ListingNotesShouldReturnXml()
        {
            XmlDocument actual = notesService.List(testPageId);
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got something else");
        }

        [Test]
        public void ListingNotesShouldReturnTrue()
        {
            XmlDocument actual = notesService.List(testPageId);
            Assert.AreEqual("true", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected a success code of true, got something else");
        }

        [Test]
        public void ListingNotesShouldReturnNotes()
        {
            XmlDocument actual = notesService.List(testPageId);
            Assert.AreNotEqual(null, actual.SelectSingleNode("/response/notes"), "Expected notes element");
        }

        // create tests
        [Test]
        public void CreatingANoteShouldReturnXml()
        {
            CreateNote();
            Assert.AreEqual("System.Xml.XmlDocument", note.GetType().FullName, "Expected Xml, got something else");
        }

        [Test]
        public void CreatingANoteShouldReturnTrue()
        {
            CreateNote();
            Assert.AreEqual("true", note.SelectSingleNode("/response").Attributes["success"].Value, "Expected a success code of true, got something else");
        }

        [Test]
        public void CreatingANoteShouldReturnNote()
        {
            CreateNote();
            Assert.AreNotEqual(null, note.SelectSingleNode("/response/note"), "Expected notes element");
        }
        
        [Test]
        public void CreatedNoteShouldHaveSameDataAsThatUsedToCreateIt()
        {
            CreateNote();

            NoteResponse noteResponse = (NoteResponse)note.ToBackpackObject(typeof(NoteResponse));
            Note createdNote = noteResponse.CreatedNote;


            Assert.AreEqual(createdNote.Title, "Created from test", "Expected the same title that was created");
            Assert.AreEqual(createdNote.NoteBody, "Created from test", "Expected the same body that was created");
        }
        
        // update tests
        [Test]
        public void UpdatingANoteShouldReturnXml()
        {
            CreateNote();
            XmlDocument actual = UpdateNote();
            Assert.AreEqual("System.Xml.XmlDocument", note.GetType().FullName, "Expected Xml, got something else");
        }

        [Test]
        public void UpdatingANoteShouldReturnTrue()
        {
            CreateNote();
            XmlDocument actual = UpdateNote();
            Assert.AreEqual("true", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected a success code of true, got something else");
        }

        // destroy tests
        [Test]
        public void DeletingANoteShouldReturnXml()
        {
            CreateNote();
            XmlDocument actual = DestroyNote();
            Assert.AreEqual("System.Xml.XmlDocument", note.GetType().FullName, "Expected Xml, got something else");
        }

        [Test]
        public void DeletingANoteShouldReturnTrue()
        {
            CreateNote();
            XmlDocument actual = DestroyNote();
            Assert.AreEqual("true", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected a success code of true, got something else");
        }

        // helper methods
        private XmlDocument CreateNote()
        {
            note = notesService.Create(testPageId, "Created from test", "Created from test");
            noteId = note.SelectSingleNode("/response/note").Attributes["id"].Value;

            return note;
        }

        private XmlDocument UpdateNote()
        {
            XmlDocument updatedNote = notesService.Update(testPageId, noteId, "Updated from test", "Updated from test");

            return updatedNote;
        }

        private XmlDocument DestroyNote()
        {
            XmlDocument results = notesService.Destroy(testPageId, noteId);
            noteId = string.Empty;

            return results;
        }
    }
}
