namespace PersonManagementTool.ViewModels
{
    using System.Collections.Generic;

    using Contracts;

    using Prism.Commands;
    using Prism.Events;
    using Prism.Mvvm;

    public class PersonSelectionViewModel : BindableBase, IPersonSelectionViewModel
    {
        private IPersonRepository personRepository;

        private readonly IEventAggregator eventAggregator;

        private void Initialize()
        {
            this.AvailablePersons = this.personRepository.GetAllPersons();
        }

        public PersonSelectionViewModel(IPersonRepository repository, IEventAggregator eventAggregator)
        {
            this.personRepository = repository;
            this.eventAggregator = eventAggregator;

            this.InitializationCommand = new DelegateCommand(this.Initialize);
        }

        private IEnumerable<Person> availablePersons;

        public IEnumerable<Person> AvailablePersons
        {
            get
            {
                return this.availablePersons;
            }
            set
            {
                this.SetProperty(ref this.availablePersons, value);
            }
        }

        public DelegateCommand InitializationCommand { get; set; }

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
                this.PublishSelectedPerson(value);
            }
        }

        private void PublishSelectedPerson(Person person)
        {
            this.eventAggregator.GetEvent<PersonSelectionEvent>().Publish(person);
        }
    }
}