namespace PersonManagementTool.Specs.PersonSelection
{
    using System.Collections.Generic;
    using System.Linq;

    using DynamicSpecs.MSTest;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PersonManagementTool.Contracts;
    using PersonManagementTool.Specs.Preconditions;
    using PersonManagementTool.ViewModels;

    using Prism.Events;

    [TestClass]
    public class WhenPersonDataHasChanged : Specifies<PersonSelectionViewModel>
    {
        private IEnumerable<Person> avalablePersons;

        private Person changedPerson;

        public override void Given()
        {
            this.avalablePersons = base.Given<PersonsAreAvailable>().AvailablePersons;
            this.changedPerson = this.avalablePersons.First();
            this.SUT.InitializationCommand.Execute();
        }

        public override void When()
        {
            this.changedPerson.FirstName = "Karl";
            this.GetInstance<IEventAggregator>().GetEvent<PersonDataChangedEvent>().Publish(this.changedPerson);
        }

        [TestMethod]
        public void ThenTheChangedDataIsAvailable()
        {
            var foundPerson = this.SUT.AvailablePersons.FirstOrDefault(x => x.FirstName == this.changedPerson.FirstName);
            Assert.IsNotNull(foundPerson);
        }
    }
}
