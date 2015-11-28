namespace PersonManagementTool.Data
{
    using System.Data.Entity;

    using PersonManagementTool.Contracts;

    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Ignore(c => c.Error);
        }

        public PersonContext() : base("Persons")
        {
        }
    }
}
