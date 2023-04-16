using Nhom8_QLTV.src.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom8_QLTV.src.controllers
{
    internal class CategoryController
    {
        private static libraryManagementEntities db = new libraryManagementEntities();

        public static dynamic index()
        {
            var categories = from c in db.categories
                             select new
                             {
                                 id = c.id,
                                 name = c.name,
                                 created_at = c.created_at,
                                 updated_at = c.updated_at,
                             };

            return categories.ToArray();
        }

        public static void store(category category)
        {
            var c = new category
            {
                name = category.name,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };

            db.categories.Add(c);
            db.SaveChanges();
        }

        public static void update(long id, category category)
        {
            var c = db.categories.Where(x => x.id == id).First();
            c.name = category.name;
            c.updated_at = DateTime.Now;
            db.SaveChanges();
        }

        public static void destroy(long id)
        {
            var c = db.categories.Where(x => x.id == id).First();
            c.category_book.FirstOrDefault().category_id = null;
            db.categories.Remove(c);
            db.SaveChanges();
        }
    }
}
