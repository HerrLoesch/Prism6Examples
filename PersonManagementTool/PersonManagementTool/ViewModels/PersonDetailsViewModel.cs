namespace PersonManagementTool.ViewModels
{
    using Contracts;

    using Prism.Commands;
    using Prism.Events;
    using Prism.Mvvm;

    public class PersonDetailsViewModel : BindableBase, IPersonDetailsViewModel
    {
        private readonly IPersonRepository repository;

        public PersonDetailsViewModel(IEventAggregator eventAggregator, IPersonRepository repository, IApplicationCommands applicationCommands)
        {
            this.repository = repository;
            eventAggregator.GetEvent<PersonSelectionEvent>().Subscribe(this.OnPersonSelected, ThreadOption.PublisherThread);

            this.CreateNewCommand = new DelegateCommand(() => this.SelectedPerson = new Person());

            applicationCommands.NewCommand.RegisterCommand(this.CreateNewCommand);
        }

        private void OnPersonSelected(Person person)
        {
            if (person.ID.HasValue)
            {
                this.SelectedPerson = this.repository.GetPerson(person.ID.Value);
            }
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

        public DelegateCommand CreateNewCommand { get; set; }
    }
}