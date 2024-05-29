using MoldovanMilanBeadando.Repository;
using System.Configuration;

namespace MoldovanMilanBeadando.Data
{
    static class GlobalVariables
    {
        private static readonly Context context = new Context(ConfigurationManager.AppSettings.Get("dbconnString"));
        private static readonly CartRepository cartRepository = new CartRepository(context);
        private static readonly ProductRepository productRepository = new ProductRepository(context);
        private static readonly CategoryRepository categoryRepository = new CategoryRepository(context);
        private static readonly OpinionRepository opinionRepository = new OpinionRepository(context);

        public static Context GetContext() { return context; }

        public static CartRepository GetCartRepository() { return cartRepository; }
        public static ProductRepository GetProductRepository() { return productRepository; }
        public static CategoryRepository GetCategoryRepository() { return categoryRepository; }
        public static OpinionRepository GetOpinionRepository() { return opinionRepository; }
    }
}
