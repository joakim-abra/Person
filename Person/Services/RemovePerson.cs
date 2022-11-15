using People.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace People.Services
{
    internal class RemovePerson : IRemovePerson
    {
        private readonly PersonContext _context;
        private readonly IReadPerson _read;

        public RemovePerson(PersonContext context, IReadPerson read)
        {
            _context = context;
            _read = read;
        }

        public void DeletePerson()
        {
            var toDelete = _read.GetPerson();
            _context.Persons.Remove(toDelete);
            _context.SaveChanges();
        }


    }
}
