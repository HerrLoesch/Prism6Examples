namespace PersonManagementTool.SystemTests
{
    using System.Transactions;

    using DynamicSpecs.Core.WorkflowExtensions;

    using PersonManagementTool.Data;

    public class DatabaseProvider : IExtend<INeedDataBaseContext>
    {
        private TransactionScope transactionScope;

        public void Extend(INeedDataBaseContext target, WorkflowPosition currentPosition)
        {
            if (currentPosition == WorkflowPosition.SUTCreation)
            {
                this.CreateContext(target);
            }
            else if (currentPosition == WorkflowPosition.Then)
            {
                this.Cleanup();
            }
        }

        private void CreateContext(INeedDataBaseContext target)
        {
            var transactionOptions = new TransactionOptions();
            transactionOptions.IsolationLevel = IsolationLevel.ReadCommitted;
            transactionOptions.Timeout = TransactionManager.MaximumTimeout;

            this.transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);

            target.Context = this.Context = new PersonContext();
        }

        private void Cleanup()
        {
            this.Context?.Dispose();

            this.transactionScope?.Dispose();
        }

        public PersonContext Context { get; set; }
    }
}
