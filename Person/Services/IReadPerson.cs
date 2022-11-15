using System.Collections.Generic;
using People.Models;

namespace People.Services
{
    internal interface IReadPerson
    {
        void GetPersons();

        Person GetPerson();
    }
}