using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammertSolution.Models
{
    public class Address
    {

        public string Name { get; }
        public string City { get; }
        public string PostalCode { get; }
        public string PostalAbbreviation { get; }

        public Address(string name, string city, string postalAbbrev, string zipCode)
        {

            // note: city = city/town.

            // address name 
            Name = name;

            // e.g: Hunstville
            City = city;

            //e.g: Zip code: 35801 thru 35816
            PostalCode = zipCode;

            //e.g: AL: Alabama, AK: Alaska; GA: Georgia...
            PostalAbbreviation = postalAbbrev;
        }

        public override int GetHashCode()
        {
            // allow overflow
            unchecked
            {
                int hash = 17;
                hash = (hash * 23) + Name.GetHashCode();
                hash = (hash * 23) + City.GetHashCode();
                hash = (hash * 23) + PostalCode.GetHashCode();
                hash = (hash * 23) + PostalAbbreviation.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            Address other = obj as Address;
            if(other == null)
            {
                return false;
            }
            return Name.Equals(other.Name, StringComparison.Ordinal) &&
                City.Equals(other.City, StringComparison.Ordinal) &&
                PostalCode.Equals(other.PostalCode, StringComparison.Ordinal) &&
                PostalAbbreviation.Equals(other.PostalAbbreviation, StringComparison.Ordinal);

        }
    }
}
