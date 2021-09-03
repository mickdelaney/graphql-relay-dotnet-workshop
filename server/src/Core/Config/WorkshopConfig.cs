namespace Workshop.Core.Config
{
    public static class WorkshopConfig
    {
        public const string RedisConnectionString = "localhost:5706";
        public const string PostgresConnectionString = "Server=localhost;Port=5705;Database=workshop;User Id=workshop;Password=workshop";
        
        public const string EfMigrationsTable = "__EFMigrationsHistory";
        public const string AccountsSchemaName = "accounts";
        public const string ContentSchemaName = "content";
    }
}