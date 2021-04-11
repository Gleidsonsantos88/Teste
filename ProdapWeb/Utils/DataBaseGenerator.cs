using Repository.EfCore;

namespace ProdapWeb.Utils
{
    public static class DataBaseGenerator
    {
        public static void CreateDataBase()
        {
            using (var ctx = new ProdapDbContext())
            {
                ctx.Database.EnsureCreated();
            }
        }
    }
}
