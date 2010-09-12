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
    public class ListsServiceTests : TestBase
    {
        String listId = string.Empty;
        XmlDocument list = null;

        [SetUp]
        public void Setup()
        {
            base.TestSetup();
        }

        [TearDown]
        public void TearDown()
        {
            if (!listId.Equals(string.Empty))
                DestroyList();
        }

        // extension method tests
        [Test]
        public void ConvertCreateListResponseXmlToListResponseObjectShouldBeOfListResponseType()
        {
            CreateList();
            Assert.AreEqual("ListResponse", list.ToBackpackObject(typeof(ListResponse)).GetType().Name);
        }

        [Test]
        public void ConvertListNoteResponseXmlToListNoteResponseObjectShouldBeOfListNoteResponseType()
        {
            CreateList();
            Assert.AreEqual("ListsListResponse", list.ToBackpackObject(typeof(ListsListResponse)).GetType().Name);
        }

        // list tests
        [Test]
        public void ListingListsShouldReturnXml()
        {
            XmlDocument actual = listsService.List(testPageId);
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got something else");
        }

        [Test]
        public void ListingListsShouldReturnTrue()
        {
            XmlDocument actual = listsService.List(testPageId);
            Assert.AreEqual("true", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected a success code of true, got something else");
        }

        [Test]
        public void ListingListsShouldReturnNotes()
        {
            XmlDocument actual = listsService.List(testPageId);
            Assert.AreNotEqual(null, actual.SelectSingleNode("/response/lists"), "Expected notes element");
        }

        // create tests
        [Test]
        public void CreatingAListShouldReturnXml()
        {
            CreateList();
            Assert.AreEqual("System.Xml.XmlDocument", list.GetType().FullName, "Expected Xml, got something else");
        }

        [Test]
        public void CreatingAListShouldReturnTrue()
        {
            CreateList();
            Assert.AreEqual("true", list.SelectSingleNode("/response").Attributes["success"].Value, "Expected a success code of true, got something else");
        }

        [Test]
        public void CreatingAListShouldReturnList()
        {
            CreateList();
            Assert.AreNotEqual(null, list.SelectSingleNode("/response/list"), "Expected list element");
        }

        [Test]
        public void CreatedListShouldHaveSameDataAsThatUsedToCreateIt()
        {
            CreateList();

            ListResponse listResponse = (ListResponse)list.ToBackpackObject(typeof(ListResponse));
            List createdList = listResponse.CreatedList;

            Assert.AreEqual(createdList.Name, "Created from test", "Expected the same name that was created");
        }
        
        // update tests
        [Test]
        public void UpdatingAListShouldReturnXml()
        {
            CreateList();
            XmlDocument actual = UpdateList();
            Assert.AreEqual("System.Xml.XmlDocument", list.GetType().FullName, "Expected Xml, got something else");
        }

        [Test]
        public void UpdatingAListShouldReturnTrue()
        {
            CreateList();
            XmlDocument actual = UpdateList();
            Assert.AreEqual("true", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected a success code of true, got something else");
        }

        // destroy tests
        [Test]
        public void DeletingAListShouldReturnXml()
        {
            CreateList();
            XmlDocument actual = DestroyList();
            Assert.AreEqual("System.Xml.XmlDocument", list.GetType().FullName, "Expected Xml, got something else");
        }

        [Test]
        public void DeletingAListShouldReturnTrue()
        {
            CreateList();
            XmlDocument actual = DestroyList();
            Assert.AreEqual("true", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected a success code of true, got something else");
        }

        // helper methods
        private XmlDocument CreateList()
        {
            list = listsService.Create(testPageId, "Created from test");
            listId = list.SelectSingleNode("/response/list").Attributes["id"].Value;

            return list;
        }

        private XmlDocument UpdateList()
        {
            XmlDocument updatedNote = listsService.Update(testPageId, listId, "Updated from test");

            return updatedNote;
        }

        private XmlDocument DestroyList()
        {
            XmlDocument results = listsService.Destroy(testPageId, listId);
            listId = string.Empty;

            return results;
        }
    }
}
