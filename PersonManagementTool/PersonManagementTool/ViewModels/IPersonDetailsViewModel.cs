namespace PersonManagementTool.ViewModels
{
    using System;

    using PersonManagementTool.Contracts;

    using Prism.Commands;
    using Prism.Interactivity.InteractionRequest;

    public interface IPersonDetailsViewModel
    {
        DelegateCommand CreateNewCommand { get; }

        DelegateCommand SaveCommand { get; }

        Person SelectedPerson { get; set; }

        InteractionRequest<IConfirmation> SaveConfirmation { get; }
    }

    public class PersonDetailsDesignViewModel : IPersonDetailsViewModel
    {
        public DelegateCommand CreateNewCommand { get; set; }

        public DelegateCommand SaveCommand { get; set; }

        public InteractionRequest<IConfirmation> SaveConfirmation { get; private set; }

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