namespace PersonManagementTool.Specs.PersonDetails
{
    using DynamicSpecs.MSTest;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PersonManagementTool.ViewModels;

    [TestClass]
    public class WhenPersonCreatesNumbers : Specifies<PersonDetailsViewModel>
    {
        public override void Given()
        {
            var person = this.Given<ValidPersonData>().Person;

            this.SUT.SelectedPerson = person;
        }

        public override void When()
        {
            this.SUT.GenerateNumbersCommand.Execute();
        }

        [TestMethod]
        public void ASetOfNumbersIsAvailable()
        {
            Assert.IsTrue(this.SUT.SelectedPerson.Numbers.Count > 0);
        }
    }
}
