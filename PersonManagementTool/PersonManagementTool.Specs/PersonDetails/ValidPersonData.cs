namespace PersonManagementTool.Specs.PersonDetails
{
    using System;

    using DynamicSpecs.Core;

    using PersonManagementTool.Contracts;

    using Tynamix.ObjectFiller;

    public class ValidPersonData : ISupport
    {
        public void Support(ISpecify specification)
        {
            var filler = new Filler<Person>();
            filler.Setup()
                .OnProperty(x => x.Error)
                .IgnoreIt()
                .OnProperty(x => x.Id)
                .IgnoreIt()
                .OnProperty(x => x.Numbers)
                .IgnoreIt()
                .OnProperty(x => x.BirthDate)
                .Use(new DateTimeRange(new DateTime(1851, 1, 1), DateTime.Now));

            this.Person = filler.Create();
        }

        public Person Person { get; set; }
    }
}