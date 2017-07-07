using ProgrammertSolution.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProgrammertSolution.Models
{
    public class Person : ModelBase<Person>
    {
        #region << Person Statics >>

        static Person()
        {
            // load already saved person and store them into list
            // XDocument xdoc;
        }

        #endregion
        public Person(string firstName, string lastName, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }

        public override void Save()
        {
            // person cannot be saved if deleted.
            if (_isDeleted)
            {
                throw new InvalidOperationException();
            }

            // store current person in list
            _dictionary.Add(Id, this);

            var xe = new XElement("person",

                new XElement("id", Id),
                new XElement("firstName", FirstName),
                new XElement("lastName", LastName),

                // Address 
                new XElement("address",
                    new XElement("name", Address.Name),
                    new XElement("city", Address.City),
                    new XElement("postaabbrev", Address.PostalAbbreviation),
                    new XElement("postalcode", Address.PostalCode)
                )
             );

            Configurations.SaveToFile("persons.xml", xe);
        }

        /// <summary>
        /// Delete current person infos.
        /// </summary>
        public override void Delete()
        {
            FirstName = null;
            LastName = null;
            Address = null;

            // remove current user from dictionary
            _dictionary.Remove(Id);
            Id = null;

            _isDeleted = true;
        }

        public override string ToString()
        {
            return "{FirstName} - {LastName} ";
        }

        public override int GetHashCode()
        {
            // allow overflow
            unchecked
            {
                int hash = 17;
                hash = (hash * 23) + FirstName.GetHashCode();
                hash = (hash * 23) + LastName.GetHashCode();
                hash = (hash * 23) + Address.GetHashCode();
                return hash; 
            }
        }

        public override bool Equals(object obj)
        {
            Person other = obj as Person;
            if (other == null)
            {
                return false;
            }
            if (!Address.Equals(other.Address))
            {
                return false;
            }
            return FirstName.Equals(other.FirstName, StringComparison.Ordinal) &&
                LastName.Equals(other.LastName, StringComparison.Ordinal);
        }
    }
}


// http://www.alliancereservations.com/programmer-test.html