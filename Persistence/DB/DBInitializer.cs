namespace Persistence.DB
{
    public class DBInitializer
    {
        public static void Initialize(AppDBContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
