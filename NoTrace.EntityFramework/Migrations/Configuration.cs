using System.Data.Entity.Migrations;

namespace NoTrace.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<NoTrace.EntityFramework.NoTraceDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "NoTrace";
        }

        protected override void Seed(NoTrace.EntityFramework.NoTraceDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
        }
    }
}
