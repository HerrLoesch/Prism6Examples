namespace PersonManagementTool.ViewModels
{
    using Contracts;

    using Prism.Events;
    using Prism.Mvvm;

    public class PersonDetailsViewModel : BindableBase
    {
        private readonly IPersonRepository repository;

        public PersonDetailsViewModel(IEventAggregator eventAggregator, IPersonRepository repository)
        {
            this.repository = repository;
            eventAggregator.GetEvent<PersonSelectionEvent>().Subscribe(this.OnPersonSelected, ThreadOption.PublisherThread);
        }

        private void OnPersonSelected(Person person)
        {
            this.SelectedPerson = person;

            this.repository.GetPerson(person.ID);
        }

        private Person selectedPerson;

        public Person SelectedPerson
        {
            get
            {
                return this.selectedPerson;
            }
            set
            {
                this.SetProperty(ref this.selectedPerson, value);
            }
        }
    }
}