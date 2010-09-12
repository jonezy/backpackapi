using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using jonezy.org.BackpackAPI.Interfaces;

namespace jonezy.org.BackpackAPI.Tests.Helpers
{
    /// <summary>
    /// static class to do some of the repetitive calls to the service api.
    /// will help when writing tests for classes that depend on other services (List items depends on lists etc)
    /// </summary>
    public static class TestHelperMethods
    {
        // journal
        public static XmlDocument CreateJournalEntry(IJournalService service, string testUserId, string journalEntry)
        {
            return service.Create(testUserId, journalEntry);
        }

        public static XmlDocument DeleteJournalEntry(IJournalService service, string journalEntryId)
        {
            return service.Delete(journalEntryId);
        }

        public static XmlDocument UpdateJournalEntry(IJournalService service, string journalEntryId, string updatedJournalEntry)
        {
            return service.Update(journalEntryId, updatedJournalEntry);
        }


        // list items
        public static XmlDocument CreateList(IListsService service, string pageId, string journalEntry)
        {
            return service.Create(pageId, "Created from test");
        }

        public static XmlDocument DeleteList(IListsService service, string pageId, string listId)
        {
            return service.Destroy(pageId, listId);
        }

    }
}
