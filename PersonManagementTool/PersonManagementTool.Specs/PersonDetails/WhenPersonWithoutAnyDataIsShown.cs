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
    }

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
    }
}
