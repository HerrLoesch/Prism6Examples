namespace PersonManagementTool.SystemTests.Specs
{
    using System.Collections.Generic;
    using System.Linq;

    using DynamicSpecs.Core;
    using DynamicSpecs.MSTest;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PersonManagementTool.Contracts;
    using PersonManagementTool.Data;
    using PersonManagementTool.ViewModels;

    using Tynamix.ObjectFiller;

    [TestClass]
    [Ignore]
    public class WhenApplicationIsInitialized : Specifies<PersonSelectionViewModel>, INeedDataBaseContext
    {
        private IEnumerable<Person> persons;

        protected override void RegisterTypes(IRegisterTypes typeRegistration)
        {
            base.RegisterTypes(typeRegistration);
            typeRegistration.Register<Repository, IPersonRepository>();
        }

        public override void Given()
        {
            var personFiller = new Filler<Person>();

            personFiller.Setup().OnProperty(x => x.Id).IgnoreIt();

            this.persons = personFiller.Create(2);

            this.Context.Persons.AddRange(this.persons);
            this.Context.SaveChanges();
        }

        public override void When()
        {
            this.SUT.InitializationCommand.Execute().Wait();
        }

        [TestMethod]
        public void ThenAllAvailablePersonsShallBeShown()
        {
            Assert.AreEqual(this.persons.First().FirstName, this.SUT.AvailablePersons.First().FirstName);
            Assert.AreEqual(this.persons.Last().FirstName, this.SUT.AvailablePersons.Last().FirstName);
        }

        public PersonContext Context { get; set; }
    }
}