using Beadando.Data;
using Beadando.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando.Repository
{
    internal class ImageRepository
    {
        private Context context;

        public ImageRepository(Context context)
        {
            this.context = context;
        }

        public List<Images> GetAllImages()
        {
            return context.Images.ToList();
        }
    }
}
