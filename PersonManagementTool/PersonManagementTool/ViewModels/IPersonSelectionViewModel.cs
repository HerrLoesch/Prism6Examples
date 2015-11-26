using System.Collections.Generic;
using PersonManagementTool.Contracts;

namespace PersonManagementTool.ViewModels
{
    using Tynamix.ObjectFiller;

    public interface IPersonSelectionViewModel
    {
        IEnumerable<Person> AvailablePersons { get; set; }

        void Initialize();
    }

    public class PersonSelectionDesignViewModel : IPersonSelectionViewModel
    {
        public IEnumerable<Person> AvailablePersons { get; set; }

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

        public void Initialize()
        {
        }
    }
}