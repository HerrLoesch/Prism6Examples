namespace PersonManagementTool.Infrastructure
{
    using PersonManagementTool.Contracts;

    using Prism.Commands;

    public class ApplicationCommands : IApplicationCommands
    {
        public CompositeCommand NewCommand { get; private set; }
        
        public CompositeCommand SaveCommand { get; private set; }

        public ApplicationCommands()
        {
            this.NewCommand = new CompositeCommand();

            this.SaveCommand = new CompositeCommand();
        }
    }
}
