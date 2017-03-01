using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XmlClassLibrary;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace XmlUnitTestProject
{
    [TestClass]
    public class CRUDUnitTest
    {
        const string filePath = @"Contacts.xml";
        ContactsXmlHelper contactsXmlHelper = new ContactsXmlHelper(filePath);

        [TestMethod]
        public void CreateTest()
        {
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

        [TestMethod]
        public void DeleteTest()
        {
            contactsXmlHelper.Delete("chriswong@gmail.com");
        }

        [TestMethod]
        public void Cleanup()
        {
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
