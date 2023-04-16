using Nhom8_QLTV.src.models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Nhom8_QLTV.src.controllers
{
    internal class BookController
    {
        private static libraryManagementEntities db = new libraryManagementEntities();

        public static dynamic index()
        {
            var books = from b in db.books
                        select new
                        {
                            id = b.id,
                            title = b.name,
                            author = b.author,
                            publisher = b.publisher,
                            published = b.published,
                            stock = b.quantity,
                            categories = b.category_book.Select(x => x.category.name).FirstOrDefault(),
                            created_at = b.created_at,
                            updated_at = b.updated_at,
                        };

            return books.ToArray();
        }

        public static book show(long id)
        {
            return db.books.Find(id);
        }

        public static void store(book book, long categoryID)
        {
            var b = new book
            {
                name = book.name,
                author = book.author,
                publisher = book.publisher,
                published = book.published,
                quantity = book.quantity,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };
            var category = db.categories.Where(c => c.id == categoryID).First();
            var c_b = new category_book
            {
                book = b,
                category = category,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };

            db.books.Add(b);
            db.category_book.AddOrUpdate(c_b);
            db.SaveChanges();
        }

        public static void update(long id, book book, long categoryID)
        {
            var b = db.books.FirstOrDefault(x => x.id == id);
            b.name = book.name;
            b.author = book.author;
            b.publisher = book.publisher;
            b.published = book.published;
            b.quantity = book.quantity;
            b.updated_at = DateTime.Now;

            var category = db.categories.FirstOrDefault(c => c.id == categoryID);
            var c_b = db.category_book.FirstOrDefault(a => a.book_id == b.id);
            c_b.category = category;
            c_b.updated_at = DateTime.Now;
            db.SaveChanges();
        }

        public static void destroy(long id)
        {
            var b = db.books.FirstOrDefault(x => x.id == id);

            if (b.book_borrow.FirstOrDefault().borrow.return_at == null)
            {
                MessageBox.Show("Sách này đang được cho mượn. Vui lòng yêu cầu trả trước khi xóa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            db.category_book.RemoveRange(b.category_book);
            db.books.Remove(b);
            db.SaveChanges();
        }

        public static dynamic searchByName(string name)
        {
            var books = db.books
                        .Where(b => b.name.Contains(name)).Select(b => new
                        {
                            id = b.id,
                            title = b.name,
                            author = b.author,
                            publisher = b.publisher,
                            published = b.published,
                            stock = b.quantity,
                            categories = b.category_book.Select(x => x.category.name).FirstOrDefault(),
                            created_at = b.created_at,
                            updated_at = b.updated_at,
                        }).ToArray();

            return books;
        }

        public static dynamic searchByAuthor(string author)
        {
            var books = db.books
                        .Where(b => b.author.Contains(author)).Select(b => new
                        {
                            id = b.id,
                            title = b.name,
                            author = b.author,
                            publisher = b.publisher,
                            published = b.published,
                            stock = b.quantity,
                            categories = b.category_book.Select(x => x.category.name).FirstOrDefault(),
                            created_at = b.created_at,
                            updated_at = b.updated_at,
                        }).ToArray();

            return books;
        }

        public static dynamic searchByPublisher(string publisher)
        {
            var books = db.books
                        .Where(b => b.publisher.Contains(publisher)).Select(b => new
                        {
                            id = b.id,
                            title = b.name,
                            author = b.author,
                            publisher = b.publisher,
                            published = b.published,
                            stock = b.quantity,
                            categories = b.category_book.Select(x => x.category.name).FirstOrDefault(),
                            created_at = b.created_at,
                            updated_at = b.updated_at,
                        }).ToArray();

            return books;
        }

        public static dynamic searchByPublished(int published)
        {
            var books = db.books
                        .Where(b => b.published == published).Select(b => new
                        {
                            id = b.id,
                            title = b.name,
                            author = b.author,
                            publisher = b.publisher,
                            published = b.published,
                            stock = b.quantity,
                            categories = b.category_book.Select(x => x.category.name).FirstOrDefault(),
                            created_at = b.created_at,
                            updated_at = b.updated_at,
                        }).ToArray();

            return books;
        }

        public static dynamic searchByCategory(long categoryID)
        {
            var books = db.books
                        .Where(b => b.category_book.FirstOrDefault().category_id == categoryID).Select(b => new
                        {
                            id = b.id,
                            title = b.name,
                            author = b.author,
                            publisher = b.publisher,
                            published = b.published,
                            stock = b.quantity,
                            categories = b.category_book.Select(x => x.category.name).FirstOrDefault(),
                            created_at = b.created_at,
                            updated_at = b.updated_at,
                        }).ToArray();

            return books;
        }
    }
}
