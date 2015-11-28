namespace PersonManagementTool.ViewModels
{
    using PersonManagementTool.Contracts;

    public class MainViewModel
    {
        public IApplicationCommands ApplicationCommands { get; }

        public MainViewModel(IApplicationCommands applicationCommands)
        {
            this.ApplicationCommands = applicationCommands;
        }
    }
}
