namespace PersonManagementTool.Specs
{
    using System.Collections.Generic;
    using System.Linq;

    using DynamicSpecs.MSTest;

    using FakeItEasy;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PersonManagementTool.Contracts;
    using PersonManagementTool.ViewModels;

    using Tynamix.ObjectFiller;

    [TestClass]
    public class WhenApplicationIsInitialized : Specifies<PersonSelectionViewModel>
    {
        private IEnumerable<Person> persons;

        public override void Given()
        {
            this.persons = Randomizer<Person>.Create(2);
            var personRepository = this.GetInstance<IPersonRepository>();

            A.CallTo(() => personRepository.GetAllPersons()).Returns(this.persons);
        }

        public override void When()
        {
            this.SUT.Initialize();
        }

        [TestMethod]
        public void ThenAllAvailablePersonsShallBeShown()
        {
            Assert.AreEqual(this.persons.First().Name, this.SUT.AvailablePersons.First().Name);
            Assert.AreEqual(this.persons.Last().Name, this.SUT.AvailablePersons.Last().Name);
        }
    }
}