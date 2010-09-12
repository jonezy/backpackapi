using System;
using System.Collections.Generic;
using System.Text;
using jonezy.org.BackpackAPI.Interfaces;
using System.Xml;

namespace jonezy.org.BackpackAPI
{
    public class NotesService : BackpackBase, INotesService
    {
        public NotesService(string username, string token)
            : base (username, token)
        {
        }

        public XmlDocument List(string pageId)
        {
            return bpDispatcher.ExecuteRequest(String.Format("ws/page/{0}/notes/list", pageId));
        }

        public XmlDocument Create(string pageId, string noteTitle, string noteBody)
        {
            return bpDispatcher.ExecuteRequest(String.Format("ws/page/{0}/notes/create", pageId), "POST", CreateNoteRequestElement(noteTitle, noteBody));
        }

        public XmlDocument Update(string pageId, string noteId, string noteTitle, string noteBody)
        {
            return bpDispatcher.ExecuteRequest(String.Format("ws/page/{0}/notes/update/{1}", pageId, noteId), "POST", CreateNoteRequestElement(noteTitle, noteBody));
        }

        public XmlDocument Destroy(string pageId, string noteId)
        {
            return bpDispatcher.ExecuteRequest(String.Format("ws/page/{0}/notes/destroy/{1}", pageId, noteId));
        }

        private XmlNode CreateNoteRequestElement(string noteTitle, string noteBody)
        {
            XmlDocument noteXml = new XmlDocument();
            NoteRequest noteRequest = new NoteRequest();
            noteRequest.Title = noteTitle;
            noteRequest.Body = noteBody;

            noteXml = noteRequest.ToXml();

            return noteXml.SelectSingleNode("/*");
        }
    }
}
