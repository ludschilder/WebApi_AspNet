namespace Impacta.Tarefas.EF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Impacta.Tarefas.EF.RealBooksContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Impacta.Tarefas.EF.RealBooksContexto";
        }

        protected override void Seed(Impacta.Tarefas.EF.RealBooksContexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
