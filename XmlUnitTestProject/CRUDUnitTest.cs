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
            contactsXmlHelper.Create();
            contactsXmlHelper.Add("Chris", "Wong", "chriswong@gmail.com");
            contactsXmlHelper.Add("Bill", "Gates", "billdates@gmail.com");
            contactsXmlHelper.Add("Steve", "Jobs", "stevejobs@gmail.com");
        }
    }
}
