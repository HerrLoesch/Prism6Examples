namespace PersonManagementTool.Specs.PersonDetails
{
    using System.Collections.Generic;
    using System.Linq;

    using DynamicSpecs.Core;
    using DynamicSpecs.MSTest;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PersonManagementTool.Contracts;
    using PersonManagementTool.Specs.Preconditions;
    using PersonManagementTool.ViewModels;

    using Prism.Events;

    [TestClass]
    public class WhenSelectedPersonChanges : Specifies<PersonDetailsViewModel>
    {
        private IEnumerable<Person> availablePersons;

        private Person selectedPerson;

        protected override void RegisterTypes(IRegisterTypes typeRegistration)
        {
            base.RegisterTypes(typeRegistration);
            typeRegistration.Register<EventAggregator, IEventAggregator>();
        }

        public override void Given()
        {
            this.availablePersons = this.Given<PersonsAreAvailable>().AvailablePersons;
            this.selectedPerson = this.availablePersons.First();
        }

        public override void When()
        {
            this.GetInstance<IEventAggregator>().GetEvent<PersonSelectionEvent>().Publish(this.selectedPerson);
        }

        [TestMethod]
        public void ThenItShallBeShownInTheDetailsView()
        {
            var id = this.SUT.SelectedPerson.Id;
            Assert.AreEqual(this.selectedPerson.Id, id);
        }
    }
}