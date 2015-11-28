namespace PersonManagementTool.Contracts
{
    using Prism.Events;

    public class PersonDataChangedEvent : PubSubEvent<Person>
    {
    }
}