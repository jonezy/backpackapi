using System.Xml;
using jonezy.org.BackpackAPI;
using NUnit.Framework;
using System.Configuration;

namespace BackpackTests
{
    [TestFixture]
    public class TokenObjectTests
    {
        Token testToken = null;
        XmlDocument tokenXml = null;
        
        [SetUp]
        public void Setup()
        {
            testToken = new Token();
            testToken.AuthenticationToken = ConfigurationSettings.AppSettings["backpack.account.token"].ToString();

            tokenXml = testToken.ToXml();
        }


        [Test]
        public void ConvertTokenToXml()
        {
            Assert.AreEqual("System.Xml.XmlDocument", tokenXml.GetType().FullName);
        }

        [Test]
        public void ConvertTokenXmlToToken()
        {
            Assert.AreEqual("Token", tokenXml.ToBackpackObject(typeof(Token)).GetType().Name);
        }
    }
}
