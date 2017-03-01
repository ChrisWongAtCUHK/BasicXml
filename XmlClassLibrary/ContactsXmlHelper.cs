﻿using System;
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
        private XDocument doc;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filePath"></param>
        public ContactsXmlHelper(string filePath)
        {
            this.filePath = filePath;
            if (!File.Exists(filePath))
            {
                // if the file does not exist, create it first
                using (XmlWriter writer = XmlWriter.Create(filePath))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Contacts");

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }

            // if the file exists, add directly
            this.doc = XDocument.Load(filePath);

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

        /// <summary>
        /// Add node
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        public void Add(string firstName, string lastName, string email)
        {
            XElement contacts = doc.Element("Contacts");

            contacts.Add(new XElement("Contact",
                            new XElement("FirstName", firstName),
                            new XElement("LastName", lastName),
                            new XElement("Email", email)
                            )
            );
            doc.Save(filePath);
        }

        /// <summary>
        /// Iterate all nodes, get the elements
        /// </summary>
        public IEnumerable<XElement> Read()
        {
            XElement contacts = doc.Element("Contacts");

            // linq query
            return from contact in contacts.Descendants()
                    select contact;
        }

        /// <summary>
        /// Read node value by searching it with email address
        /// </summary>
        public XElement Read(string email)
        {
            XElement contacts = doc.Element("Contacts");

            // linq extension
            return contacts.Descendants()
                .FirstOrDefault(node => node.Element("Email").Value == email);
        }

        /// <summary>
        /// Update a node value by searching it with email address
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        public void UpdateByEmail(string firstName, string lastName, string email)
        {
            if (System.IO.File.Exists(filePath))
            {

                // Note: invoke Read(string email) could not update the node
                var contact = Read(email);

                contact.Element("FirstName").Value = firstName;
                contact.Element("LastName").Value = lastName;
                doc.Save(filePath);
            }

        }
        // delete

    }
}
