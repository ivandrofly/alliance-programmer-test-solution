using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammertSolution;
using ProgrammertSolution.Models;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("foo", "bar", new Address("madina", "bissau", "gb", "123412"));
            var business = new Business("software", new Address("madina", "bissau", "gb", "12341"));
            //business.Save();
            person.Save();
        }
    }
}
