using System;
using System.Xml;
using jonezy.org.BackpackAPI;
using NUnit.Framework;
using jonezy.org.BackpackAPI.Tests.Helpers;

namespace BackpackTests
{
    [TestFixture]
    public class ListItemsServiceTests : TestBase
    {
        String listItemId = string.Empty;
        String listId = string.Empty;
        XmlDocument listItem = null;

        [SetUp]
        public void Setup()
        {
            base.TestSetup();
            CreateListItem();
        }

        [TearDown]
        public void TearDown()
        {
            if (!listItemId.Equals(string.Empty))
                DestroyListItem();

            if (!listId.Equals(string.Empty))
                TestHelperMethods.DeleteList(listsService, testPageId, listId);
        }

        // extension method tests
        [Test]
        public void ConvertCreateListItemResponseXmlToListItemResponseObjectShouldBeOfListItemResponseType()
        {
            Assert.AreEqual("ListItemsCreateResponse", listItem.ToBackpackObject(typeof(ListItemsCreateResponse)).GetType().Name);
        }

        [Test]
        public void ConvertListItemsListResponseXmlToListItemsListResponseObjectShouldBeOfListItemsListResponseType()
        {
            Assert.AreEqual("ListItemsListResponse", listItem.ToBackpackObject(typeof(ListItemsListResponse)).GetType().Name);
        }

        // list tests
        [Test]
        public void ListingListItemsShouldReturnXml()
        {
            XmlDocument actual = listItemsService.List(testPageId, listId);
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got something else");
        }

        [Test]
        public void ListingListItemsShouldReturnTrue()
        {
            XmlDocument actual = listItemsService.List(testPageId, listId);
            Assert.AreEqual("true", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected a success code of true, got something else");
        }

        [Test]
        public void ListingListItemsShouldReturnListItems()
        {
            XmlDocument actual = listItemsService.List(testPageId, listId);
            Assert.AreNotEqual(null, actual.SelectSingleNode("/response/items"), "Expected notes element");
        }

        // create tests
        [Test]
        public void CreatingAListItemShouldReturnXml()
        {
            Assert.AreEqual("System.Xml.XmlDocument", listItem.GetType().FullName, "Expected Xml, got something else");
        }

        [Test]
        public void CreatingAListItemShouldReturnTrue()
        {
            Assert.AreEqual("true", listItem.SelectSingleNode("/response").Attributes["success"].Value, "Expected a success code of true, got something else");
        }

        [Test]
        public void CreatingAListItemShouldReturnListItem()
        {
            Assert.AreNotEqual(null, listItem.SelectSingleNode("/response/item"), "Expected item element");
        }

        [Test]
        public void CreatedListItemShouldHaveSameDataAsThatUsedToCreateIt()
        {
            ListItemsCreateResponse listItemResponse = (ListItemsCreateResponse)listItem.ToBackpackObject(typeof(ListItemsCreateResponse));
            ListItem createdListItem = listItemResponse.CreatedListItem;

            Assert.AreEqual(createdListItem.ItemText, "Created from test", "Expected the same name that was created");
        }
        
        // update tests
        [Test]
        public void UpdatingAListItemShouldReturnXml()
        {
            XmlDocument actual = UpdateListItem();
            Assert.AreEqual("System.Xml.XmlDocument", listItem.GetType().FullName, "Expected Xml, got something else");
        }

        [Test]
        public void UpdatingAListItemShouldReturnTrue()
        {
            XmlDocument actual = UpdateListItem();
            Assert.AreEqual("true", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected a success code of true, got something else");
        }

        // toggle tests
        [Test]
        public void TogglingAListItemShouldReturnXml()
        {
            XmlDocument actual = listItemsService.Toggle(testPageId, listId, listItemId);
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got something else");
        }
        
        [Test]
        public void TogglingAListItemShouldReturnTrue()
        {
            XmlDocument actual = listItemsService.Toggle(testPageId, listId, listItemId);
            Assert.AreEqual("true", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected Xml, got something else");
        }

        // destroy tests
        [Test]
        public void DeletingAListItemShouldReturnXml()
        {
            XmlDocument actual = DestroyListItem();
            Assert.AreEqual("System.Xml.XmlDocument", listItem.GetType().FullName, "Expected Xml, got something else");
        }

        [Test]
        public void DeletingAListItemShouldReturnTrue()
        {
            XmlDocument actual = DestroyListItem();
            Assert.AreEqual("true", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected a success code of true, got something else");
        }
        
        // move tests
        [Test]
        public void MovingAListItemHigherShouldReturnXml()
        {
            XmlDocument actual = listItemsService.Move(testPageId, listId, listItemId, "move_higher");
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got something else");
        }

        [Test]
        public void MovingAListItemHigherShouldReturnTrue()
        {
            XmlDocument actual = listItemsService.Move(testPageId, listId, listItemId, "move_higher");
            Assert.AreEqual("true", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected Xml, got something else");
        }

        [Test]
        public void MovingAListItemLowerShouldReturnXml()
        {
            XmlDocument actual = listItemsService.Move(testPageId, listId, listItemId, "move_lower");
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got something else");
        }

        [Test]
        public void MovingAListItemLowerShouldReturnTrue()
        {
            XmlDocument actual = listItemsService.Move(testPageId, listId, listItemId, "move_lower");
            Assert.AreEqual("true", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected Xml, got something else");
        }

        [Test]
        public void MovingAListItemToTheTopShouldReturnXml()
        {
            XmlDocument actual = listItemsService.Move(testPageId, listId, listItemId, "move_to_top");
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got something else");
        }

        [Test]
        public void MovingAListItemToTheTopShouldReturnTrue()
        {
            XmlDocument actual = listItemsService.Move(testPageId, listId, listItemId, "move_to_top");
            Assert.AreEqual("true", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected Xml, got something else");
        }

        [Test]
        public void MovingAListItemToTheBottomShouldReturnXml()
        {
            XmlDocument actual = listItemsService.Move(testPageId, listId, listItemId, "move_to_bottom");
            Assert.AreEqual("System.Xml.XmlDocument", actual.GetType().FullName, "Expected Xml, got something else");
        }

        [Test]
        public void MovingAListItemToTheBottomShouldReturnTrue()
        {
            XmlDocument actual = listItemsService.Move(testPageId, listId, listItemId, "move_to_bottom");
            Assert.AreEqual("true", actual.SelectSingleNode("/response").Attributes["success"].Value, "Expected Xml, got something else");
        }

        // helper methods
        private XmlDocument CreateListItem()
        {
            XmlDocument createResponse = null;
            ListResponse listResponse = null;
            List list = null;

            createResponse = TestHelperMethods.CreateList(listsService, testPageId, "Created from test");
            listResponse = createResponse.ToBackpackObject(typeof(ListResponse)) as ListResponse;
            list = listResponse.CreatedList;
            listId = list.Id;

            listItem = listItemsService.Create(testPageId, listId, "Created from test");
            listItemId = listItem.SelectSingleNode("/response/item").Attributes["id"].Value;

            return listItem;
        }

        private XmlDocument UpdateListItem()
        {
            XmlDocument updatedListItem = listItemsService.Update(testPageId, listId, listItemId, "Updated from test");

            return updatedListItem;
        }

        private XmlDocument DestroyListItem()
        {
            XmlDocument results = listItemsService.Destroy(testPageId, listId, listItemId);
            listItemId = string.Empty;

            return results;
        }
    }
}
