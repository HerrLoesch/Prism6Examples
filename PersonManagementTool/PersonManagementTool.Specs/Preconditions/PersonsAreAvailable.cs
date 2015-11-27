namespace PersonManagementTool.Specs.Preconditions
{
    using System.Collections.Generic;

    using DynamicSpecs.Core;

    using FakeItEasy;

    using PersonManagementTool.Contracts;

    using Tynamix.ObjectFiller;

    public class PersonsAreAvailable : ISupport
    {
        public IEnumerable<Person> AvailablePersons { get; private set; }

        public void Support(ISpecify specification)
        {
            this.AvailablePersons = Randomizer<Person>.Create(2);
            var personRepository = specification.GetInstance<IPersonRepository>();

            A.CallTo(() => personRepository.GetAllPersons()).Returns(this.AvailablePersons);
        }
    }
}