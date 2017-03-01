using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace XmlClassLibrary
{
    public class ContactsXmlHelper
    {
        private string filePath;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filePath"></param>
        public ContactsXmlHelper(string filePath)
        {
            // there
            Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
            this.filePath = filePath;
        }

        // create
        public void Create(string firstName, string lastName, string email)
        {
            if (System.IO.File.Exists(filePath))
            {
                // if the file exists, add directly
                XDocument doc = XDocument.Load(filePath);
                XElement contacts = doc.Element("Contacts");

                contacts.Add(new XElement("Contact",
                                new XElement("FirstName", firstName),
                                new XElement("LastName", lastName),
                                new XElement("Email", email)
                             )
                );
                doc.Save(filePath);
            }
            else
            {
                // if the file does not exist, create it first
                using (XmlWriter writer = XmlWriter.Create(filePath))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Contacts");

                    #region Session
                    writer.WriteStartElement("Contact");
                    writer.WriteElementString("FirstName", firstName);
                    writer.WriteElementString("LastName", lastName);
                    writer.WriteElementString("Email", email);
                    writer.WriteEndElement();
                    #endregion // end Contact

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }

        // read
        // update
        // delete

    }
}
