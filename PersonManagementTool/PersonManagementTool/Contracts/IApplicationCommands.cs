namespace PersonManagementTool.Contracts
{
    using Prism.Commands;

    public interface IApplicationCommands
    {
        CompositeCommand NewCommand { get; }

        CompositeCommand SaveCommand { get; }
    }
}