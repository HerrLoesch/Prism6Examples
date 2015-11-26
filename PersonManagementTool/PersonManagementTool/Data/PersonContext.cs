namespace PersonManagementTool.Data
{
    using System.Data.Entity;

    using PersonManagementTool.Contracts;

    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public PersonContext() : base("Persons")
        {
        }
    }
}
