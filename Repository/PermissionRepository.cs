using MoldovanMilanBeadando.Data;
using MoldovanMilanBeadando.Model;
using System.Collections.Generic;
using System.Linq;

namespace MoldovanMilanBeadando.Repository
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
