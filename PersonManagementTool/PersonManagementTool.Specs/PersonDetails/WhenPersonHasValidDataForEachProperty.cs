namespace PersonManagementTool.Specs.PersonDetails
{
    using System;

    using DynamicSpecs.MSTest;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PersonManagementTool.Contracts;

    [TestClass]
    public class WhenPersonHasValidDataForEachProperty : Specifies<Person>
    {
        public override void Given()
        {
            this.SUT.FirstName = "Karl";
            this.SUT.LastName = "Meier";
            this.SUT.BirthDate = DateTime.Now;
        }

        [TestMethod]
        public void ThenThereShouldBeNoErrorTextForFirstName()
        {
            Assert.IsNull(this.SUT["FirstName"]);
        }

        [TestMethod]
        public void ThenThereShouldBeNoErrorTextForLastName()
        {
            var lastName = this.SUT["LastName"];
            Assert.IsNull(lastName);
        }

        [TestMethod]
        public void ThenThereShouldBeNoErrorTextForBirthDate()
        {
            Assert.IsNull(this.SUT["BirthDate"]);
        }

        [TestMethod]
        public void ThenThereShouldBeNoGeneralError()
        {
            Assert.IsNull(this.SUT.Error);
        }
    }
}