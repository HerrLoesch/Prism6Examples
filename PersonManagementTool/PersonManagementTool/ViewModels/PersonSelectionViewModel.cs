namespace PersonManagementTool.ViewModels
{
    using System.Collections.Generic;

    using PersonManagementTool.Contracts;

    public class PersonSelectionViewModel
    {
        private IPersonRepository personRepository;

        public void Initialize()
        {
            this.AvailablePersons = this.personRepository.GetAllPersons();
        }

        public PersonSelectionViewModel(IPersonRepository repository)
        {
            this.personRepository = repository;
        }

        public IEnumerable<Person> AvailablePersons { get; set; }
    }
}