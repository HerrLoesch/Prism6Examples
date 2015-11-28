namespace PersonManagementTool.Specs.PersonDetails
{
    using System;

    using DynamicSpecs.MSTest;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PersonManagementTool.Contracts;

    [TestClass]
    public class WhenPersonHasWrongDataForEachProperty : Specifies<Person>
    {
        public override void Given()
        {
            this.SUT.FirstName = string.Empty;
            this.SUT.LastName = string.Empty;
            this.SUT.BirthDate = DateTime.MinValue;
        }

        [TestMethod]
        public void ThenThereShouldBeAnErrorTextForFirstName()
        {
            Assert.IsNotNull(this.SUT["FirstName"]);
        }

        [TestMethod]
        public void ThenThereShouldBeAnErrorTextForLastName()
        {
            Assert.IsNotNull(this.SUT["LastName"]);
        }

        [TestMethod]
        public void ThenThereShouldBeAnErrorTextForBirthDate()
        {
            Assert.IsNotNull(this.SUT["BirthDate"]);
        }

        [TestMethod]
        public void ThenThereShouldBeAGeneralErrorMessage()
        {
            Assert.IsNotNull(this.SUT.Error);
        }
    }
}
