using System.Collections.Generic;
using PersonManagementTool.Contracts;

namespace PersonManagementTool.ViewModels
{
    using Prism.Commands;

    using Tynamix.ObjectFiller;

    public interface IPersonSelectionViewModel
    {
        IEnumerable<Person> AvailablePersons { get; set; }

        DelegateCommand InitializationCommand { get; set; }

        Person SelectedPerson { get; set; }
    }

    public class PersonSelectionDesignViewModel : IPersonSelectionViewModel
    {
        public IEnumerable<Person> AvailablePersons { get; set; }

        public DelegateCommand InitializationCommand { get; set; }

        public Person SelectedPerson { get; set; }

        public PersonSelectionDesignViewModel()
        {
            var filler = new Filler<Person>();
            
            filler.Setup()
                    .OnProperty(x => x.FirstName)
                    .Use(new RealNames(NameStyle.FirstName))
                    .OnProperty(x => x.LastName)
                    .Use(new RealNames(NameStyle.LastName));

            this.AvailablePersons = filler.Create(5);
        }
    }
}