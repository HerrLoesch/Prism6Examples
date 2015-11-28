namespace PersonManagementTool.Specs.Preconditions
{
    using System.Collections.Generic;
    using System.Linq;

    using DynamicSpecs.Core;

    using FakeItEasy;

    using PersonManagementTool.Contracts;

    using Tynamix.ObjectFiller;

    public class PersonsAreAvailable : ISupport
    {
        public IEnumerable<Person> AvailablePersons { get; private set; }

        public void Support(ISpecify specification)
        {
            var filler = new Filler<Person>();
            filler.Setup().OnProperty(x => x.Numbers).IgnoreIt();

            this.AvailablePersons = filler.Create(2);
            var personRepository = specification.GetInstance<IPersonRepository>();

            A.CallTo(() => personRepository.GetAllPersons()).Returns(this.AvailablePersons);

            A.CallTo(() => personRepository.GetPerson(A<int>.Ignored))
                .ReturnsLazily((int id) => this.AvailablePersons.First(p => p.Id == id));
        }
    }
}