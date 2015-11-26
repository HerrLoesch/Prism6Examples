namespace PersonManagementTool.ViewModels
{
    using System.Collections.Generic;

    using PersonManagementTool.Contracts;

    using Prism.Commands;
    using Prism.Mvvm;

    public class PersonSelectionViewModel : BindableBase, IPersonSelectionViewModel
    {
        private IPersonRepository personRepository;

        private void Initialize()
        {
            this.AvailablePersons = this.personRepository.GetAllPersons();
        }

        public PersonSelectionViewModel(IPersonRepository repository)
        {
            this.personRepository = repository;

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
    }
}