namespace PersonManagementTool.Contracts
{
    using System.Collections.Generic;

    public interface IPersonRepository
    {
        IEnumerable<Person> GetAllPersons();
    }
}