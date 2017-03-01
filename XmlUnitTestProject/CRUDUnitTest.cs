using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XmlClassLibrary;

namespace XmlUnitTestProject
{
    [TestClass]
    public class CRUDUnitTest
    {
        ContactsXmlHelper contactsXmlHelper = new ContactsXmlHelper(@"Contacts.xml");

        [TestMethod]
        public void CreateTest()
        {
            contactsXmlHelper.Create("Chris", "Wong", "chriswong@gmail.com");
        }
    }
}
