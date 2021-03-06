﻿namespace PersonManagementTool.Specs.PersonDetails
{
    using DynamicSpecs.MSTest;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PersonManagementTool.Contracts;
    using PersonManagementTool.ViewModels;

    using FakeItEasy;

    using Prism.Events;
    using Prism.Interactivity.InteractionRequest;

    [TestClass]
    public class WhenValidDataShallBeSaved : Specifies<PersonDetailsViewModel>
    {
        private Person personToSave;

        public override void Given()
        {
            this.personToSave = this.Given<ValidPersonData>().Person;

            this.SUT.SelectedPerson = this.personToSave;
        }

        public override void When()
        {
            var confirmation = A.Fake<IConfirmation>();
            A.CallTo(() => confirmation.Confirmed).Returns(true);

            this.SUT.OnSaveConfirmed(confirmation);
        }

        [TestMethod]
        public void ThenItIsStoredInTheDataBase()
        {
            var personRepository = this.GetInstance<IPersonRepository>();
            A.CallTo(() => personRepository.Update(A<Person>.That.Matches(person => person.FirstName == this.personToSave.FirstName))).MustHaveHappened();
        }

        [TestMethod]
        public void ThenItCanBeSaved()
        {
            Assert.IsTrue(this.SUT.SaveCommand.CanExecute());
        }

        [TestMethod]
        public void TheAPersonDataChangedEventIsRaised()
        {
            var eventAggregator = this.GetInstance<IEventAggregator>();
            A.CallTo(() => eventAggregator.GetEvent<PersonDataChangedEvent>()).MustHaveHappened();
        }
    }
}
