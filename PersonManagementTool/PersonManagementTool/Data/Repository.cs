
namespace PersonManagementTool.Data
{
    using System;

    using PersonManagementTool.Contracts;

    using System.Collections.Generic;
    using System.Linq;

    public class Repository : IPersonRepository, IDisposable
    {
        private readonly PersonContext context;

        public Repository()
        {
            this.context = new PersonContext();
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return this.context.Persons.ToList();
        }

        public Person GetPerson(int id)
        {
            return this.context.Persons.First(x => x.ID == id);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
