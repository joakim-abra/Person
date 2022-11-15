using Microsoft.EntityFrameworkCore;
using People.Database;
using People.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace People.Service
{
    internal class AddPerson : IAddPerson
    {
        private readonly PersonContext _context;

        public AddPerson(PersonContext context)
        {
            _context = context;
        }

        public void AddNewPerson()
        {
            Console.WriteLine("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter last name: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter Adrees: ");
            string adress = Console.ReadLine();

            _context.Persons.Add(new Person { FirstName=firstName, LastName = lastName, Adress = adress});
            _context.SaveChanges();
        }
    }
}
