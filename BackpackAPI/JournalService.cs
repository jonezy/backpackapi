using System;
using System.Collections.Generic;
using System.Text;
using jonezy.org.BackpackAPI.Interfaces;
using jonezy.org.BackpackAPI;
using System.Xml;

namespace jonezy.org.BackpackAPI
{
    public class JournalService :  BackpackBase, IJournalService
    {
        public JournalService(string username, string token) 
            : base(username, token)
        {
           
        }
        
        public XmlDocument ListEveryone(string returnCount)
        {
            return bpDispatcher.ExecuteRequest(String.Format("journal_entries.xml?n=0&count={0}&token={1}", returnCount, this._token), "GET", null);
        }

        public XmlDocument ListUser(string userId, string returnCount)
        {
            return bpDispatcher.ExecuteRequest(String.Format("users/{0}/journal_entries.xml?n=0&count={1}&token={2}", userId, returnCount, this._token), "GET", null);
        }

        public XmlDocument Show(string journalEntryId)
        {
            return bpDispatcher.ExecuteRequest(String.Format("journal_entries/{0}.xml?token={1}", journalEntryId, this._token), "GET", null);
        }

        public XmlDocument Create(string userId, string journalEntry)
        {
            return bpDispatcher.ExecuteRequest(String.Format("users/{0}/journal_entries.xml?token={1}", userId, this._token), "POST", CreateJournalEntry(journalEntry));
        }

        public XmlDocument Update(string journalEntryId, string journalEntry)
        {
            return bpDispatcher.ExecuteRequest(String.Format("journal_entries/{0}.xml?token={1}", journalEntryId, this._token), "PUT", CreateJournalEntry(journalEntry));
        }

        public XmlDocument Delete(string journalEntryId)
        {
            return bpDispatcher.ExecuteRequest(String.Format("journal_entries/{0}.xml?token={1}", journalEntryId, this._token), "DELETE", null);
        }


        private XmlNode CreateJournalEntry(string journalEntry)
        {
            XmlDocument journalXml = new XmlDocument();
            Journal journal = new Journal();
            journal.Body = journalEntry;

            journalXml = journal.ToXml();
            //XmlDocument requestXml = new XmlDocument();
            //XmlElement pageEl = requestXml.CreateElement("journal-entry");
            //XmlElement titleEl = requestXml.CreateElement("body");

            //titleEl.InnerText = journalEntry;

            //pageEl.AppendChild(titleEl);
            //requestXml.AppendChild(pageEl);

            return journalXml.SelectSingleNode("/*"); // root
        }

    }
}
