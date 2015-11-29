namespace PersonManagementTool.ViewModels
{
    using System;
    using System.Collections.Generic;

    using PersonManagementTool.Contracts;

    using Prism.Commands;
    using Prism.Interactivity.InteractionRequest;

    public interface IPersonDetailsViewModel
    {
        DelegateCommand CreateNewCommand { get; }

        DelegateCommand SaveCommand { get; }

        Person SelectedPerson { get; set; }

        InteractionRequest<IConfirmation> SaveConfirmation { get; }

        DelegateCommand GenerateNumbersCommand { get; set; }

        DelegateCommand ShowAnalyzationCommand { get; }
    }

    public class PersonDetailsDesignViewModel : IPersonDetailsViewModel
    {
        public DelegateCommand CreateNewCommand { get; set; }

        public DelegateCommand SaveCommand { get; set; }

        public InteractionRequest<IConfirmation> SaveConfirmation { get; private set; }

        public DelegateCommand GenerateNumbersCommand { get; set; }

        public Person SelectedPerson { get; set; }

        public DelegateCommand ShowAnalyzationCommand { get; private set; }

        public PersonDetailsDesignViewModel()
        {
            var person = new Person();
            person.FirstName = "Hendrik";
            person.LastName = "Lösch";
            person.BirthDate = DateTime.Now;

            for (int i = 0; i < 20; i++)
            {
                person.Numbers.Add(new KeyValuePair<int,int>(i,i));
            }

            this.SelectedPerson = person;
        }
    }
}