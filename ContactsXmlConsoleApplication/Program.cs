using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XmlClassLibrary;

namespace ContactsXmlConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactsXmlHelper contactsXmlHelper = new ContactsXmlHelper(@"Contacts.xml");


            contactsXmlHelper.Create("Chris", "Wong", "chriswong@gmail.com");

        }
    }
}
