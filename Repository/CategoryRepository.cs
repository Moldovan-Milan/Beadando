using Beadando.Data;
using Beadando.Model;
using System.Collections.Generic;
using System.Linq;

namespace Beadando.Repository
{
    class CategoryRepository
    {
        private Context context;

        public CategoryRepository(Context context)
        {
            this.context = context;
        }

        public List<Category> GetAll()
        {
            return context.Categories.ToList();
        }
    }
}
