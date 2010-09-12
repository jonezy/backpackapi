using System.Configuration;
using System.Xml;

using jonezy.org.BackpackAPI;
using jonezy.org.BackpackAPI.Interfaces;
using jonezy.org.BackpackAPI.Tests.Helpers;
using NUnit.Framework;

namespace BackpackTests
{
    [TestFixture]
    public class JournalServiceTests : TestBase
    {
        private string journalEntryId = string.Empty;
        private XmlDocument journalEntryResponse = null;

        [SetUp]
        public void Setup()
        {
            base.TestSetup();
        }

        [TearDown]
        public void TearDown()
        {
            if (!journalEntryId.Equals(string.Empty))
                DeleteJournalEntry();
        }

        // extension method tests
        [Test]
        public void ConvertCreateJournalResponseXmlToJournalObjectShouldBeOfJournalType()
        {
            CreateJournalEntry();
            Assert.AreEqual("JournalCreateResponse", journalEntryResponse.ToBackpackObject(typeof(JournalCreateResponse)).GetType().Name);
        }

        [Test]
        public void ConvertListJournalResponseXmlToJournalsObjectShouldBeOfJournalsType()
        {
            XmlDocument actual = journalService.ListEveryone("100");
            Assert.AreEqual("Journals", actual.ToBackpackObject(typeof(Journals)).GetType().Name);
        }

        [Test]
        public void ConvertShowJournalResponseXmlToJournalObjectShouldBeOfJournalType()
        {
            CreateJournalEntry();
            XmlDocument actual = journalService.Show(journalEntryId);
            Assert.AreEqual("Journal", actual.ToBackpackObject(typeof(Journal)).GetType().Name);
        }

        // list tests
        [Test]
        public void ListEveryoneShouldReturnXml()
        {
            XmlDocument actual = journalService.ListEveryone("100");
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got null");
        }

        [Test]
        public void ListEveryoneShouldReturnXmlWithAJournalEntriesElement()
        {
            XmlDocument actual = journalService.ListEveryone("100");
            Assert.AreNotEqual(null, actual.SelectSingleNode("/journal-entries"), "Expected a journal-entries element");
        }

        [Test]
        public void ListUserShouldReturnXmlWithAJournalEntriesElement()
        {
            XmlDocument actual = journalService.ListUser(testUserId, "100");
            Assert.AreNotEqual(null, actual.SelectSingleNode("/journal-entries"), "Expected a journal-entries element");
        }

        [Test]
        public void ListUserShouldReturnXml()
        {
            XmlDocument actual = journalService.ListUser(testUserId, "100");
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got null");
        }

        // show tests
        [Test]
        public void ShowJournalEntryShouldReturnXml()
        {
            CreateJournalEntry();
            XmlDocument actual = journalService.Show(journalEntryId);
            Assert.AreEqual("System.Xml.XmlDocument", journalEntryResponse.GetType().FullName, "Expected Xml, got null");
        }

        [Test]
        public void ShowJournalEntryShouldReturnXmlWithAJournalEntryElement()
        {
            CreateJournalEntry();
            XmlDocument actual = journalService.Show(journalEntryId);
            Assert.AreNotEqual(null, actual.SelectSingleNode("/journal-entry"), "Expected a journal-entries element");
        }

        // creation tests
        [Test]
        public void CreatingAJournalEntryShouldReturnXml()
        {
            CreateJournalEntry();
            Assert.AreEqual("System.Xml.XmlDocument", journalEntryResponse.GetType().FullName, "Expected Xml, got null");
        }
        
        [Test]
        public void CreatingAJournalEntryShouldReturnACodeOf201()
        {
            CreateJournalEntry();
            Assert.AreEqual("201", journalEntryResponse.SelectSingleNode("/response/status").Attributes["code"].Value, "Expected a return status of 201, got something else");
        }

        [Test]
        public void CreatedJournalShouldHaveSameDataAsThatUsedToCreateIt()
        {
            CreateJournalEntry();

            XmlDocument actual = journalService.Show(journalEntryId);
            Journal createdJournal = (Journal) actual.ToBackpackObject(typeof(Journal));

            Assert.AreEqual(createdJournal.Body, "Test Journal Update", "Expected the same name that was created");
        }

        // update tests
        [Test]
        public void UpdatingAJournalEntryShouldReturnXml()
        {
            CreateJournalEntry();
            XmlDocument actual = TestHelperMethods.UpdateJournalEntry(journalService, journalEntryId, "Updated from test");
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got null");
        }

        [Test]
        public void UpdatingAJournalEntryShouldReturnAJournalEntry()
        {
            CreateJournalEntry();
            XmlDocument actual = TestHelperMethods.UpdateJournalEntry(journalService, journalEntryId, "Updated from test");
            Assert.AreEqual("journal-entry", actual.SelectSingleNode("/journal-entry").Name, "Expected a journal entry");
        }

        // delete tests
        [Test]
        public void DeletingAJournalEntryShouldReturnXml()
        {
            CreateJournalEntry();
            XmlDocument actual = DeleteJournalEntry();
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got null");
        }

        [Test]
        public void DeletingAJournalEntryShouldReturnACodeOf200()
        {
            CreateJournalEntry();
            XmlDocument actual = DeleteJournalEntry();
            Assert.AreEqual("200", actual.SelectSingleNode("/response/status").Attributes["code"].Value, "Expected a return status of 200, got something else.");
        }

        // helper methods
        private XmlDocument CreateJournalEntry()
        {
            string respsonseLocation = string.Empty;

            journalEntryResponse = TestHelperMethods.CreateJournalEntry(journalService, testUserId, "Test Journal Update");
            respsonseLocation = journalEntryResponse.SelectSingleNode("/response/status").Attributes["location"].Value;
            journalEntryId = respsonseLocation.Remove(0, respsonseLocation.LastIndexOf("/") + 1);

            return journalEntryResponse;
        }

        private XmlDocument DeleteJournalEntry()
        {
            XmlDocument results = TestHelperMethods.DeleteJournalEntry(journalService,journalEntryId);
            journalEntryId = string.Empty;

            return results;
        }

    }
}
