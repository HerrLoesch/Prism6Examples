namespace PersonManagementTool.ViewModels
{
    using System.ComponentModel;

    using PersonManagementTool.Contracts;

    using Prism.Commands;
    using Prism.Events;
    using Prism.Interactivity.InteractionRequest;
    using Prism.Mvvm;

    public class PersonDetailsViewModel : BindableBase, IPersonDetailsViewModel
    {
        private readonly IPersonRepository repository;

        private readonly IEventAggregator eventAggregator;

        private Person selectedPerson;

        public PersonDetailsViewModel(
            IEventAggregator eventAggregator,
            IPersonRepository repository,
            IApplicationCommands applicationCommands)
        {
            this.eventAggregator = eventAggregator;
            this.repository = repository;
            this.SaveConfirmation = new InteractionRequest<IConfirmation>(); ;

            eventAggregator.GetEvent<PersonSelectionEvent>()
                .Subscribe(this.OnPersonSelected, ThreadOption.PublisherThread);

            this.CreateNewCommand = new DelegateCommand(() => this.SelectedPerson = new Person());
            applicationCommands.NewCommand.RegisterCommand(this.CreateNewCommand);

            this.SaveCommand = new DelegateCommand(this.Save, this.CanSave);
            applicationCommands.SaveCommand.RegisterCommand(this.SaveCommand);
        }

        public DelegateCommand CreateNewCommand { get; set; }

        public DelegateCommand SaveCommand { get; set; }

        public Person SelectedPerson
        {
            get
            {
                return this.selectedPerson;
            }
            set
            {
                if (this.selectedPerson != null)
                {
                    this.selectedPerson.PropertyChanged -= this.ValidateCanSave;
                }

                this.SetProperty(ref this.selectedPerson, value);

                if (this.selectedPerson != null)
                {
                    this.selectedPerson.PropertyChanged += this.ValidateCanSave;
                }

                this.SelectedPerson.ValidateInput();
            }
        }

        private void ValidateCanSave(object sender, PropertyChangedEventArgs e)
        {
            this.SaveCommand.RaiseCanExecuteChanged();
        }

        private bool CanSave()
        {
            if (this.SelectedPerson != null)
            {
                return string.IsNullOrEmpty(this.SelectedPerson.Error);
            }

            return false;
        }

        public InteractionRequest<IConfirmation> SaveConfirmation { get; private set; }

        private void Save()
        {
            this.SaveConfirmation.Raise(new Confirmation() {Content = "Wollen Sie wirklich speichen?", Title = "Speichern?"}, this.OnSaveConfirmed);
        }

        public void OnSaveConfirmed(IConfirmation confirmation)
        {
            if (confirmation.Confirmed)
            {
                this.repository.Update(this.SelectedPerson);
                this.eventAggregator.GetEvent<PersonDataChangedEvent>().Publish(this.SelectedPerson);
            }
        }

        private void OnPersonSelected(Person person)
        {
            if (person.Id != 0)
            {
                this.SelectedPerson = this.repository.GetPerson(person.Id);
            }
        }
    }
}