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

        private void LoadAllPersons()
        {
            this.AvailablePersons = this.personRepository.GetAllPersons();
        }

        public PersonSelectionViewModel(IPersonRepository repository, IEventAggregator eventAggregator)
        {
            this.personRepository = repository;
            this.eventAggregator = eventAggregator;

            this.eventAggregator.GetEvent<PersonDataChangedEvent>().Subscribe(this.Update);

            this.InitializationCommand = new DelegateCommand(this.LoadAllPersons);
        }

        private void Update(Person person)
        {
            // I know it's dirty but I just want to show prism... 
            this.LoadAllPersons();
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