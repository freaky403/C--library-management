using Nhom8_QLTV.src.models;
using System.Linq;
using System.Windows.Forms;

namespace Nhom8_QLTV.src.controllers
{
    internal class UserController
    {
        private static libraryManagementEntities db = new libraryManagementEntities();

        public static dynamic index()
        {
            var users = from user in db.users
                        join uRole in db.role_user
                        on user.id
                        equals uRole.user_id
                        join role in db.roles
                        on uRole.role_id
                        equals role.id
                        select new
                        {
                            id = user.id,
                            username = user.username,
                            email = user.email,
                            role = role.key,
                            createdAt = user.created_at,
                            updatedAt = user.updated_at,
                        };

            return users.ToArray();
                        
        }

        public static user show(long id)
        {
            return db.users.Find(id);
        }

        public static bool isExistedUsername(string username)
        {
            return db.users.Any(u => u.username.Equals(username));
        }

        public static bool isExistedEmail(string email)
        {
            return db.users.Any(u => u.email.Equals(email));
        }

        public static void update(long id, user user)
        {
            var u = db.users.FirstOrDefault(us => us.id == id);
            u.username = user.username;
            u.email = user.email;
            u.updated_at = user.updated_at;

            db.SaveChanges();
        }
    }
}
