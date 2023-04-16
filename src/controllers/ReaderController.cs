using Nhom8_QLTV.src.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom8_QLTV.src.controllers
{
    internal class ReaderController
    {
        private static libraryManagementEntities db = new libraryManagementEntities();

        public static dynamic index()
        {
            var readers = from r in db.readers
                          select new
                          {
                              id = r.id,
                              name = r.name,
                              gender = r.gender == 1 ? "Nam" : "Nữ",
                              dateOfBirth = r.date_of_birth,
                              phoneNumber = r.phone_number,
                              expiresAt = r.expires_at,
                              createdAt = r.created_at,
                              updatedAt = r.updated_at,
                          };

            return readers.ToArray();
        }

        public static reader show(long id)
        {
            return db.readers.Find(id);
        }

        public static void store(reader reader)
        {
            var r = new reader
            {
                name = reader.name,
                gender = reader.gender,
                date_of_birth = reader.date_of_birth,
                phone_number = reader.phone_number,
                expires_at = reader.expires_at,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };

            db.readers.Add(r);
            db.SaveChanges();
        }

        public static void update(long id, reader reader)
        {
            var r = db.readers.Where(x => x.id == id).First();
            r.name = reader.name;
            r.gender = reader.gender;
            r.date_of_birth = reader.date_of_birth;
            r.phone_number = reader.phone_number;
            r.updated_at = DateTime.Now;

            db.SaveChanges();
        }

        public static bool destroy(long id)
        {
            var r = db.readers.Where(x => x.id == id).First();

            if (r.book_borrow.FirstOrDefault().borrow.return_at != null)
            {
                db.book_borrow.RemoveRange(r.book_borrow);
                db.borrows.Remove(r.book_borrow.FirstOrDefault().borrow);
            }

            db.readers.Remove(r);
            
            try
            {
                db.SaveChanges();
            } catch (Exception)
            {
                MessageBox.Show("Độc giả này đang mượn sách. Hãy yêu cầu trả sách trước khi tiến hành xóa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
