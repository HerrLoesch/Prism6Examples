namespace PersonManagementTool.ViewModels
{
    using System;

    using PersonManagementTool.Contracts;

    public interface IPersonDetailsViewModel
    {
        Person SelectedPerson { get; set; }
    }

    public class PersonDetailsDesignViewModel : IPersonDetailsViewModel
    {
        public Person SelectedPerson { get; set; }

        public PersonDetailsDesignViewModel()
        {
            var person = new Person();
            person.FirstName = "Hendrik";
            person.LastName = "Lösch";
            person.BirthDate = DateTime.Now;

            this.SelectedPerson = person;
        }
    }
}