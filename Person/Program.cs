using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using People.Database;
using People.Service;
using People.Services;
using System;

namespace People
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IAddPerson, AddPerson>()
                .AddScoped<IReadPerson, ReadPerson>()
                .AddScoped<IUpdatePerson, UpdatePerson>()
                .AddScoped<IRemovePerson, RemovePerson>()
                .AddDbContext<PersonContext>(option => option.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Persons;Trusted_Connection=True"))
                .BuildServiceProvider();

            void Helper()
            {
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
            }

            int choice;
            bool run = true;
            do
            {
                bool valid = false;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Select option: \n 1) Add new Person\n 2) Get persons\n 3) Update person\n 4) Delete person\n 0)Exit");
                    valid = int.TryParse(Console.ReadLine(), out choice);
                    if (!valid)
                    {
                        Console.WriteLine("Invalid selection");
                    }
                } while (!valid);
                switch(choice)
                {
                    case 1:
                        var add = serviceProvider.GetService<IAddPerson>();
                        add.AddNewPerson();
                        Helper();
                        break;
                   case 2:
                        var read = serviceProvider.GetService<IReadPerson>();
                        read.GetPersons();
                        Helper();
                        break;
                    case 3:
                        var update = serviceProvider.GetService<IUpdatePerson>();
                        update.Update();
                        Helper();
                        break;
                    case 4:
                        var delete = serviceProvider.GetService<IRemovePerson>();
                        delete.DeletePerson();
                        Helper();
                        break;
                    default:
                        run = false;
                        break;
                }

            }
            while (run);
        }
    }
}
