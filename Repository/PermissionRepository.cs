using Beadando.Data;
using Beadando.Model;
using System.Collections.Generic;
using System.Linq;

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
