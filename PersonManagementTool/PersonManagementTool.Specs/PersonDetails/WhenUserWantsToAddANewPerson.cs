namespace PersonManagementTool.Specs.PersonDetails
{
    using System.Collections.Generic;
    using System.Linq;

    using DynamicSpecs.MSTest;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PersonManagementTool.Contracts;
    using PersonManagementTool.Specs.Preconditions;
    using PersonManagementTool.ViewModels;

    [TestClass]
    public class WhenUserWantsToAddANewPerson : Specifies<PersonDetailsViewModel>
    {
        private IEnumerable<Person> availablePersons;

        public override void Given()
        {
            this.availablePersons = this.Given<PersonsAreAvailable>().AvailablePersons;
            this.SUT.SelectedPerson = this.availablePersons.First();
        }

        public override void When()
        {
            this.SUT.CreateNewCommand.Execute().Wait();
        }

        [TestMethod]
        public void ThenAPersonObjectWithoutAnIdIsSelected()
        {
            Assert.IsNull(this.SUT.SelectedPerson.Id);
        }
    }
}
