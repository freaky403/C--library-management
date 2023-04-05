using Nhom8_QLTV.src.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom8_QLTV.src.utils
{
    internal class Authorization
    {
        protected permission[] permissionList = null;
        protected long userID;
        private static libraryManagementEntities db = new libraryManagementEntities();

        public void SetUser(long id)
        {
           this.userID = id;
        }

        private ICollection<role_user> Roles()
        {
            var user = db.users.FirstOrDefault(u => u.id == this.userID);

            return user.role_user;
        }

        public bool HasRole(Role role)
        {
            return this.Roles().Any(r => r.role.role1 == (int)role);
        }

        public bool HasPermission(Permission permission)
        {
            return this.GetPermissions().Any(p => p.permission1 == (int)permission);
        }

        public permission[] GetPermissions()
        {
            var role = this.Roles().First();

            if (role != null)
            {
                this.permissionList = role.role.permission_role.Select(x => x.permission).ToArray();
            }

            return permissionList;
        }

        public bool IsAdministrator()
        {
            return this.HasRole(Role.Administrator);
        }

        public bool CanUpdateUser(user authUser, user updateUser)
        {
            var authUserAuthorize = new Authorization();
            authUserAuthorize.SetUser(authUser.id);

            var updateUserAuthorize = new Authorization();
            updateUserAuthorize.SetUser(updateUser.id);

            if (!authUserAuthorize.IsAdministrator() && updateUserAuthorize.IsAdministrator())
            {
                throw new Exception("Bạn không thể thực hiện đều này. (You are not administrator)");
            }

            return authUserAuthorize.HasRole(Role.Librarian) ||
                authUserAuthorize.IsAdministrator() ||
                authUserAuthorize.HasPermission(Permission.ManageAuthorize);
        }

        public bool CanDeleteUser(user authUser, user deleteUser)
        {
            var authUserAuthorize = new Authorization();
            authUserAuthorize.SetUser(authUser.id);

            var deleteUserAuthorize = new Authorization();
            deleteUserAuthorize.SetUser(deleteUser.id);

            if (!authUserAuthorize.IsAdministrator() && deleteUserAuthorize.IsAdministrator())
            {
                throw new Exception("Bạn không thể thực hiện đều này. (You are not administrator)");
            }

            return authUserAuthorize.HasRole(Role.Librarian) ||
                authUserAuthorize.IsAdministrator() ||
                authUserAuthorize.HasPermission(Permission.ManageAuthorize);
        }
    }
}
