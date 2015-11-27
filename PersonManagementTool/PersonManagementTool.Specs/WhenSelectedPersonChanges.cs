namespace PersonManagementTool.Specs
{
    using System.Collections.Generic;
    using System.Linq;

    using DynamicSpecs.MSTest;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Contracts;

    using DynamicSpecs.Core;

    using ViewModels;

    using Preconditions;

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
            var id = this.SUT.SelectedPerson.ID;
            Assert.AreEqual(this.selectedPerson.ID, id);
        }
    }
}