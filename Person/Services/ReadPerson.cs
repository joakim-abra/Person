using Microsoft.EntityFrameworkCore;
using People.Database;
using People.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace People.Services
{
    internal class ReadPerson : IReadPerson
    {
        private readonly PersonContext _context;

        public ReadPerson(PersonContext context)
        {
            _context = context;
        }

        public void GetPersons()
        {
            var all = _context.Persons.ToList();
            foreach (var person in all)
            {
                Console.WriteLine("ID: " + person.Id +"\n");
                Console.WriteLine("First Name: " + person.FirstName + "\n");
                Console.WriteLine("Last Name: " + person.LastName + "\n");
                Console.WriteLine("Adress: " + person.Adress + "\n");
            }
        }

        public Person GetPerson()
        {
            int id;
            bool ok = false;
            do
            {
                Console.WriteLine("Enter id: ");
                ok = int.TryParse(Console.ReadLine(), out id);
            }
            while (!ok);
            return _context.Persons.FromSqlInterpolated($"SELECT * FROM dbo.Persons p WHERE p.Id = {id}").FirstOrDefault();
        }
    }
}
