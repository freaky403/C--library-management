using Nhom8_QLTV.src.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom8_QLTV.src.controllers
{
    internal class ReportController
    {
        private static libraryManagementEntities db = new libraryManagementEntities();

        public static dynamic allBook()
        {
            var books = from b in db.books
                        select new
                        {
                            id = b.id,
                            name = b.name,
                            quantity = b.quantity,
                        };

            return books.ToArray();
        }

        public static dynamic byAuthor()
        {
            var books = from b in db.books
                        group b by new { b.author } into g
                        select new
                        {
                            author = g.Key.author,
                            total = g.Sum(x => x.quantity)
                        }; 

            return books.ToArray();
        }

        public static dynamic byCategory()
        {
            var books = from b in db.books
                        join cb in db.category_book
                        on b.id equals cb.book_id
                        join c in db.categories
                        on cb.category_id equals c.id
                        group b by new
                        {
                            c.name
                        } into g
                        select new
                        {
                            category = g.Key.name,
                            total = g.Sum(x => x.quantity)
                        };

            return books.ToArray();
        }

        public static dynamic byPublisher()
        {
            var books = from b in db.books
                        group b by new
                        {
                            b.publisher
                        } into g
                        select new
                        {
                            publisher = g.Key.publisher,
                            total = g.Sum(x => x.quantity)
                        };

            return books.ToArray();
        }
        
        public static dynamic borrowStatus(DateTime startDate, DateTime endDate)
        {
            var borrows = from br in db.borrows
                          join b_br in db.book_borrow
                          on br.id equals b_br.borrow_id
                          join b in db.books
                          on b_br.book_id equals b.id
                          where br.borrowed_date >= startDate && br.borrowed_date < endDate
                          select new
                          {
                              bookTitle = b.name,
                              quantity = b_br.quantity,
                              borrowedDate = br.borrowed_date,
                              expiresAt = br.expires_at,
                              status = br.return_at != null ? "Đã trả" : "Chưa trả"
                          };

            return borrows.ToArray();
        }
    }
}
