using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XmlClassLibrary;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

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

        [TestMethod]
        public void ReadTest()
        {
            IEnumerable<XElement> contactList = contactsXmlHelper.Read();

            foreach (var contact in contactList)
            {
                var elements = contact.Elements();
                foreach (var element in elements)
                {
                    Console.WriteLine(element.Name + ": " + element.Value);
                }
                Console.WriteLine();
            }
        }

        [TestMethod]
        public void UpdateTest()
        {
            contactsXmlHelper.UpdateByEmail("Chris", "WWW", "chriswong@gmail.com");
        }
    }
}
