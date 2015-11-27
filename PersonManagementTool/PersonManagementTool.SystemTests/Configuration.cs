namespace PersonManagementTool.SystemTests
{
    using DynamicSpecs.Core.WorkflowExtensions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PersonManagementTool.Data;

    [TestClass]
    public class Configuration : Extensions
    {
        [AssemblyInitialize]
        public static void RegisterExtensions(TestContext context)
        {
            CreateDataBase();

            Extend<INeedDataBaseContext>().With<DatabaseProvider>().Before(WorkflowPosition.SUTCreation | WorkflowPosition.Then);
        }

        [AssemblyCleanup]
        public static void CleanUp()
        {
            using (var context = new PersonContext())
            {
                context.Database.Delete();
            }
        }

        private static void CreateDataBase()
        {
            using (var context = new PersonContext())
            {
                
                context.Database.CreateIfNotExists();
            }
        }
    }
}
