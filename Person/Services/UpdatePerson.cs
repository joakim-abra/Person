using Microsoft.EntityFrameworkCore;
using People.Database;
using People.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace People.Services
{
    internal class UpdatePerson : IUpdatePerson
    {
        private readonly PersonContext _context;
        private readonly IReadPerson _read;

        public UpdatePerson(PersonContext context, IReadPerson read)
        {
            _context = context;
            _read = read;
        }

        public void Update()
        {

            var toUpdatePerson = _read.GetPerson();
            Console.WriteLine("Current ID: " + toUpdatePerson.Id + "\n");
            Console.WriteLine("Current first name: " + toUpdatePerson.FirstName + "\n");
            Console.WriteLine("Current last name: " + toUpdatePerson.LastName + "\n");
            Console.WriteLine("Current address: " + toUpdatePerson.Adress + "\n");

            Console.WriteLine("Enter new first name: ");
            string newInfo = string.Empty;
            do
            {
                newInfo = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(newInfo));
            toUpdatePerson.FirstName = newInfo;
            Console.Clear();

            Console.WriteLine("Enter new last name: ");
            newInfo = string.Empty;
            do
            {
                newInfo = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(newInfo));
            toUpdatePerson.LastName = newInfo;

            Console.WriteLine("Enter new address: ");
            newInfo = string.Empty;
            do
            {
                newInfo = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(newInfo));
            toUpdatePerson.LastName = newInfo;
            Console.Clear();
            _context.Update(toUpdatePerson);
            _context.SaveChanges();
            Console.WriteLine("New ínfo saved:+\n");
            Console.WriteLine("ID: " + toUpdatePerson.Id + "\n");
            Console.WriteLine("First name: "+ toUpdatePerson.FirstName + "\n");
            Console.WriteLine("Last name: " + toUpdatePerson.LastName + "\n");
            Console.WriteLine("Address " + toUpdatePerson.Adress + "\n");

        }
    }
}
