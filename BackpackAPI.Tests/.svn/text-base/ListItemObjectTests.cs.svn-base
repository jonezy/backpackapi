using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using jonezy.org.BackpackAPI;
using System.Xml;

namespace BackpackTests
{
    [TestFixture]
    public class ListItemObjectTests
    {
        ListItem testListItem = null;
        ListItemCreateRequest testListItemCreateRequest = null;
        ListItemMoveRequest testListItemMoveRequest = null;
        XmlDocument listItemXml = null;
        XmlDocument listItemCreateRequestXml = null;
        XmlDocument listItemMoveRequestXml = null;

        [SetUp]
        public void Setup()
        {
            // individual
            testListItem = new ListItem();
            testListItem.Id = "1";
            testListItem.ItemText = "List item";
            testListItem.Completed = "false";
            testListItem.ListId = "20";

            listItemXml = testListItem.ToXml();

            // create 
            testListItemCreateRequest = new ListItemCreateRequest();
            testListItemCreateRequest.Content = "Test item";

            listItemCreateRequestXml = testListItemCreateRequest.ToXml();

            testListItemMoveRequest = new ListItemMoveRequest();
            testListItemMoveRequest.Direction= "move_higher";

            listItemMoveRequestXml = testListItemMoveRequest.ToXml();
        }


        [Test]
        public void ConvertListItemToXml()
        {
            Assert.AreEqual("System.Xml.XmlDocument", listItemXml.GetType().FullName);
        }

        [Test]
        public void ConvertListItemXmlToListItem()
        {
            Assert.AreEqual("ListItem", listItemXml.ToBackpackObject(typeof(ListItem)).GetType().Name);
        }

        [Test]
        public void ConvertListItemCreateRequestToXml()
        {
            Assert.AreEqual("System.Xml.XmlDocument", listItemCreateRequestXml.GetType().FullName);
        }

        [Test]
        public void ConvertListItemCreateRequestXmlToListItemCreateRequest()
        {
            Assert.AreEqual("ListItemCreateRequest", listItemCreateRequestXml.ToBackpackObject(typeof(ListItemCreateRequest)).GetType().Name);
        }

        [Test]
        public void ConvertListItemMoveRequestToXml()
        {
            Assert.AreEqual("System.Xml.XmlDocument", listItemMoveRequestXml.GetType().FullName);
        }

        [Test]
        public void ConvertListItemMoveRequestXmlToListItemMoveRequest()
        {
            Assert.AreEqual("ListItemMoveRequest", listItemMoveRequestXml.ToBackpackObject(typeof(ListItemMoveRequest)).GetType().Name);
        }
    }
}
