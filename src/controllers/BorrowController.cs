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
    internal class BorrowController
    {
        private static libraryManagementEntities db = new libraryManagementEntities();

        public static dynamic index()
        {
            var borrows = from br in db.borrows
                          select new
                          {
                              id = br.id,
                              bookID = br.book_borrow.FirstOrDefault().book_id,
                              bookTitle = br.book_borrow.FirstOrDefault().book.name,
                              bookCategory = br.book_borrow.FirstOrDefault().book.category_book.FirstOrDefault().category.name,
                              readerID = br.book_borrow.FirstOrDefault().reader_id,
                              readerName = br.book_borrow.FirstOrDefault().reader.name,
                              librarianName = br.user.username,
                              borrowedDate = br.borrowed_date,
                              expiresAt = br.expires_at,
                              returnAt = br.return_at,
                              quantity = br.book_borrow.FirstOrDefault().quantity,
                              createdAt = br.created_at,
                              updatedAt = br.updated_at,
                          };

            return borrows.ToArray();
        }

        public static bool store(borrow borrow, book_borrow bookBorrow)
        {
            var reader = ReaderController.show((long)bookBorrow.reader_id);

            var isExpired = (DateTime.Now - (DateTime)reader.expires_at).TotalDays == 0;

            if (isExpired)
            {
                MessageBox.Show("Thẻ độc giả đã hết hạn.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            var br = new borrow
            {
                user_id = Session.getInstance().getUser().id,
                borrowed_date = DateTime.Now,
                expires_at = borrow.expires_at,
                return_at = null,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };

            var b_br = new book_borrow
            {
                book_id = bookBorrow.book_id,
                borrow = br,
                reader_id = reader.id,
                quantity = bookBorrow.quantity,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };

            var book = BookController.show((long)bookBorrow.book_id);

            if (book != null)
            {
                if (book.quantity == 0 || bookBorrow.quantity > book.quantity)
                {
                    MessageBox.Show("Sách này hiện đã hết hoặc không đủ số lượng mà bạn yêu cầu.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                book.quantity -= bookBorrow.quantity;
                book.updated_at = DateTime.Now;
            };

            db.books.AddOrUpdate(book);
            db.borrows.Add(br);
            db.book_borrow.Add(b_br);
            db.SaveChanges();

            return true;
        }

        public static dynamic searchByID(long id)
        {
            var borrow = from br in db.borrows
                         where br.id == id
                         select new
                         {
                             id = br.id,
                             bookID = br.book_borrow.FirstOrDefault().book_id,
                             bookTitle = br.book_borrow.FirstOrDefault().book.name,
                             bookCategory = br.book_borrow.FirstOrDefault().book.category_book.FirstOrDefault().category.name,
                             readerID = br.book_borrow.FirstOrDefault().reader_id,
                             readerName = br.book_borrow.FirstOrDefault().reader.name,
                             librarianName = br.user.username,
                             borrowedDate = br.borrowed_date,
                             expiresAt = br.expires_at,
                             returnAt = br.return_at,
                             quantity = br.book_borrow.FirstOrDefault().quantity,
                             createdAt = br.created_at,
                             updatedAt = br.updated_at,
                         };

            if (borrow.Count() == 0)
            {
                MessageBox.Show("Không có sách nào đang mượn.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }


            return borrow.ToList();
        }

        public static dynamic searchByReaderID(long id)
        {
            var borrow = from br in db.borrows
                         where br.book_borrow.FirstOrDefault().reader_id == id && br.expires_at == null
                         select new
                         {
                             id = br.id,
                             bookID = br.book_borrow.FirstOrDefault().book_id,
                             bookTitle = br.book_borrow.FirstOrDefault().book.name,
                             bookCategory = br.book_borrow.FirstOrDefault().book.category_book.FirstOrDefault().category.name,
                             readerID = br.book_borrow.FirstOrDefault().reader_id,
                             readerName = br.book_borrow.FirstOrDefault().reader.name,
                             librarianName = br.user.username,
                             borrowedDate = br.borrowed_date,
                             expiresAt = br.expires_at,
                             returnAt = br.return_at,
                             quantity = br.book_borrow.FirstOrDefault().quantity,
                             createdAt = br.created_at,
                             updatedAt = br.updated_at,
                         };

            if (borrow.Count() == 0)
            {
                MessageBox.Show("Không có sách nào đang mượn.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            return borrow.ToList();
        }

        public static dynamic searchByIDAndReaderID(long id, long readerID)
        {
            var borrow = from br in db.borrows
                         where br.id == id
                         where br.book_borrow.FirstOrDefault().reader_id == readerID && br.expires_at == null
                         select new
                         {
                             id = br.id,
                             bookID = br.book_borrow.FirstOrDefault().book_id,
                             bookTitle = br.book_borrow.FirstOrDefault().book.name,
                             bookCategory = br.book_borrow.FirstOrDefault().book.category_book.FirstOrDefault().category.name,
                             readerID = br.book_borrow.FirstOrDefault().reader_id,
                             readerName = br.book_borrow.FirstOrDefault().reader.name,
                             librarianName = br.user.username,
                             borrowedDate = br.borrowed_date,
                             expiresAt = br.expires_at,
                             returnAt = br.return_at,
                             quantity = br.book_borrow.FirstOrDefault().quantity,
                             createdAt = br.created_at,
                             updatedAt = br.updated_at,
                         };

            if (borrow.Count() == 0)
            {
                MessageBox.Show("Không có sách nào đang mượn.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            return borrow.ToList();
        }

        public static void returns(long id)
        {
            var borrow = db.borrows.Where(x => x.id == id).First();
            borrow.return_at = DateTime.Now;
            borrow.updated_at = DateTime.Now;
            borrow.book_borrow.FirstOrDefault().updated_at = DateTime.Now;

            var book = BookController.show((long)borrow.book_borrow.FirstOrDefault().book_id);

            if (book != null)
            {
                book.quantity += borrow.book_borrow.FirstOrDefault().quantity;
                book.updated_at = DateTime.Now;
            };

            db.books.AddOrUpdate(book);
            db.SaveChanges();
        }

        public static dynamic notReturnsYet()
        {
            var borrows = from br in db.borrows
                          where br.return_at == null
                          select new
                          {
                              id = br.id,
                              bookID = br.book_borrow.FirstOrDefault().book_id,
                              bookTitle = br.book_borrow.FirstOrDefault().book.name,
                              bookCategory = br.book_borrow.FirstOrDefault().book.category_book.FirstOrDefault().category.name,
                              readerID = br.book_borrow.FirstOrDefault().reader_id,
                              readerName = br.book_borrow.FirstOrDefault().reader.name,
                              librarianName = br.user.username,
                              borrowedDate = br.borrowed_date,
                              expiresAt = br.expires_at,
                              returnAt = br.return_at,
                              quantity = br.book_borrow.FirstOrDefault().quantity,
                              createdAt = br.created_at,
                              updatedAt = br.updated_at,
                          };

            return borrows.ToArray();
        }
    }
}
