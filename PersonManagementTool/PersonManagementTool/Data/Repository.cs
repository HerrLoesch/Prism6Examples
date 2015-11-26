
namespace PersonManagementTool.Data
{
    using PersonManagementTool.Contracts;

    using System.Collections.Generic;
    
    using Tynamix.ObjectFiller;

    public class Repository : IPersonRepository
    {
        public IEnumerable<Person> GetAllPersons()
        {
            var filler = new Filler<Person>();

            filler.Setup()
                    .OnProperty(x => x.FirstName)
                    .Use(new RealNames(NameStyle.FirstName))
                    .OnProperty(x => x.LastName)
                    .Use(new RealNames(NameStyle.LastName));

            return filler.Create(5);
        }
    }
}
