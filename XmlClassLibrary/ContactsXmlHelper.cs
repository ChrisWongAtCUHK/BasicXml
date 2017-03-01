using System;
using System.Collections.Generic;
using System.IO;
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
            this.filePath = filePath;
        }

        /// <summary>
        /// Create the xml with root element
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        public void Create()
        {
            // for simlicity, clean up
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // if the file does not exist, create it first
            using (XmlWriter writer = XmlWriter.Create(filePath))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Contacts");

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

        }

        public void Add(string firstName, string lastName, string email)
        {
            if (File.Exists(filePath))
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
        }

        // read
        // update
        // delete

    }
}
