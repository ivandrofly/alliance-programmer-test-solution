using ProgrammertSolution.Helpers;
using System;
using System.IO;
using System.Xml.Linq;

namespace ProgrammertSolution.Models
{
    public class Business : ModelBase<Business>
    {

        #region << Static Members >>

        #endregion
        /// <summary>
        /// Business Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Business Address.
        /// </summary>
        public Address Address { get; set; }

        public Business(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        public override void Save()
        {
            // business cannot be saved if deleted.
            if (_isDeleted)
            {
                throw new InvalidOperationException();
            }

            _dictionary.Add(Id, this);

            var xe = new XElement("business",
               new XElement("id", Id),
               new XElement("name", Name),
               // Address 
               new XElement("address",
                   new XElement("name", Address.Name),
                   new XElement("city", Address.City),
                   new XElement("postaabbrev", Address.PostalAbbreviation),
                   new XElement("postalcode", Address.PostalCode)
               )
            );

            string file = "businesses.xml";
            Configurations.SaveToFile(file, xe);
            /*
            if (File.Exists(file))
            {
                var xdoc = XDocument.Load(file);
                foreach (XElement e in xdoc.Root.Elements("business"))
                {
                    // element found.
                    if (e.Element("id").Value.Equals(Id, StringComparison.Ordinal))
                    {
                        e.Remove();
                        break;
                    }
                }
                xdoc.Root.Add(xe);
                xdoc.Save(file);
            }
            else
            {
                try
                {
                    var root = new XElement("businesses", xe);
                    root.Save(file);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            */
        }

        public override void Delete()
        {
            Name = null;
            Address = null;
            _dictionary.Remove(Id);

            Id = null;
            _isDeleted = true;
        }

        public override int GetHashCode()
        {
            // allow overflow
            unchecked
            {
                int hash = 17;
                hash = (hash * 23) + Name.GetHashCode();
                hash = (hash * 23) + Address.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            Business other = obj as Business;
            if (other == null)
            {
                return false;
            }
            return Name.Equals(other.Name, StringComparison.Ordinal) && Address.Equals(other.Address);
        }
    }
}
