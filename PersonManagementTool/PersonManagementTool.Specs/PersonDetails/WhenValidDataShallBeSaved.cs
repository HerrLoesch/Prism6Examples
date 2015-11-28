namespace PersonManagementTool.Specs.PersonDetails
{
    using System;

    using DynamicSpecs.MSTest;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PersonManagementTool.Contracts;
    using PersonManagementTool.ViewModels;

    using Tynamix.ObjectFiller;
    using FakeItEasy;

    using Prism.Events;

    [TestClass]
    public class WhenValidDataShallBeSaved : Specifies<PersonDetailsViewModel>
    {
        private Person personToSave;

        public override void Given()
        {
            var filler = new Filler<Person>();
            filler.Setup()
                .OnProperty(x => x.Error)
                .IgnoreIt()
                .OnProperty(x => x.Id)
                .IgnoreIt()
                .OnProperty(x => x.BirthDate)
                .Use(new DateTimeRange(new DateTime(1851,1,1), DateTime.Now));

            this.personToSave = filler.Create();

            this.SUT.SelectedPerson = this.personToSave;
        }

        public override void When()
        {
            this.SUT.SaveCommand.Execute();
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
