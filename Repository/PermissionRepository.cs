using Beadando.Data;
using Beadando.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando.Repository
{
    internal class PermissionRepository
    {
        private Context context;

        public PermissionRepository(Context context)
        {
            this.context = context;
        }

        public List<Permission> GetPermissions()
        {
            return context.Permissions.ToList();
        }
    }
}
