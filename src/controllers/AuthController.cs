using Nhom8_QLTV.src.models;
using Nhom8_QLTV.src.utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom8_QLTV.src.controllers
{
    internal class AuthController
    {
        private static libraryManagementEntities db = new libraryManagementEntities();

        public static user login(string username, string password)
        {
            var user = db.users.FirstOrDefault(u => u.username.Equals(username));
            var isAuth = HashPassword.Verify(password, user.password);

            if (!isAuth || user == null)
            {
                throw new UnauthorizedAccessException("Tên người dùng hoặc mật khẩu không chính xác.");
            }

            return user;
        }

        public static user register(user requests)
        {
            var user = new user
            {
                username = requests.username,
                email = requests.email,
                password = HashPassword.Hash(requests.password),
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };


            if (UserController.isExistedUsername(user.username)) throw new Exception("Tên người dùng này đã được sử dụng.");

            if (UserController.isExistedEmail(user.email)) throw new Exception("Địa chỉ Email này đã tồn tại.");


            db.users.Add(user);

            var role = db.roles.Where(r => r.role1 == (int) Role.Librarian).First();
            var roleUser = new role_user
            {
                user = user,
                role = role,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };

            db.role_user.AddOrUpdate(roleUser);
            db.SaveChanges();

            return user;
        }
    }
}
