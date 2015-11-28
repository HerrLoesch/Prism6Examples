namespace PersonManagementTool.ViewModels
{
    using System;

    using PersonManagementTool.Contracts;

    using Prism.Commands;

    public interface IPersonDetailsViewModel
    {
        DelegateCommand CreateNewCommand { get; set; }

        DelegateCommand SaveCommand { get; set; }

        Person SelectedPerson { get; set; }
    }

    public class PersonDetailsDesignViewModel : IPersonDetailsViewModel
    {
        public DelegateCommand CreateNewCommand { get; set; }

        public DelegateCommand SaveCommand { get; set; }

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