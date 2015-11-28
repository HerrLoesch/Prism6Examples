namespace PersonManagementTool.Specs.PersonSelection
{
    using System.Collections.Generic;
    using System.Linq;

    using DynamicSpecs.MSTest;

    using FakeItEasy;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PersonManagementTool.Contracts;
    using PersonManagementTool.Specs.Preconditions;
    using PersonManagementTool.ViewModels;

    using Prism.Events;

    [TestClass]
    public class WhenPersonIsSelected : Specifies<PersonSelectionViewModel>
    {
        private IEnumerable<Person> availablePersons;

        public override void Given()
        {
            this.availablePersons = this.Given<PersonsAreAvailable>().AvailablePersons;
        }

        public override void When()
        {
            this.SUT.SelectedPerson = this.availablePersons.First();
        }

        [TestMethod]
        public void ThenTheSelectedPersonDataIsPublished()
        {
            var eventAggregator = this.GetInstance<IEventAggregator>();
            A.CallTo(() => eventAggregator.GetEvent<PersonSelectionEvent>()).MustHaveHappened();
        }
    }
}