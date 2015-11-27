namespace PersonManagementTool.Specs
{
    using System.Collections.Generic;
    using System.Linq;

    using DynamicSpecs.MSTest;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Contracts;

    using PersonManagementTool.Specs.Preconditions;

    using ViewModels;

    [TestClass]
    public class WhenApplicationIsInitialized : Specifies<PersonSelectionViewModel>
    {
        private IEnumerable<Person> persons;

        public override void Given()
        {
            this.persons = this.Given<PersonsAreAvailable>().AvailablePersons;
        }

        public override void When()
        {
            this.SUT.InitializationCommand.Execute().Wait();
        }

        [TestMethod]
        public void ThenAllAvailablePersonsShallBeShown()
        {
            Assert.AreEqual(this.persons.First().FirstName, this.SUT.AvailablePersons.First().FirstName);
            Assert.AreEqual(this.persons.Last().FirstName, this.SUT.AvailablePersons.Last().FirstName);
        }
    }
}