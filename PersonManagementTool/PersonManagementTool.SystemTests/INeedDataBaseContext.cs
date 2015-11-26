namespace PersonManagementTool.SystemTests
{
    using PersonManagementTool.Data;

    public interface INeedDataBaseContext
    {
        PersonContext Context { get; set; }
    }
}