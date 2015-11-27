namespace PersonManagementTool.Contracts
{
    using Prism.Events;

    public class PersonSelectionEvent : PubSubEvent<Person>
    {
    }
}