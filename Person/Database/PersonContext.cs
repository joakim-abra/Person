using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using People.Models;

namespace People.Database
{
    internal class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {

        }

    }
}
