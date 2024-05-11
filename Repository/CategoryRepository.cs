using Beadando.Data;
using Beadando.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
