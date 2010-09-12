using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace jonezy.org.BackpackAPI.Interfaces
{
    public interface IJournalService
    {

        XmlDocument ListEveryone(string returnCount);
        XmlDocument ListUser(string userId, string returnCount);
        XmlDocument Show(string journalEntryId);
        XmlDocument Update(string journalEntryId, string journalEntry);
        XmlDocument Create(string userId, string journalEntry);
        XmlDocument Delete(string journalEntryId);

    }
}
