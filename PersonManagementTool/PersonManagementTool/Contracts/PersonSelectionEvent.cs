namespace PersonManagementTool.Contracts
{
    using Prism.Events;

    /// <summary>
    /// Indicates that the person with the given ID is selected.
    /// </summary>
    public class PersonSelectionEvent : PubSubEvent<Person>
    {
    }
}