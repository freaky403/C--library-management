using Nhom8_QLTV.src.controllers;
using Nhom8_QLTV.src.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom8_QLTV.src.views
{
    public partial class BookSearch : Form
    {
        public BookSearch()
        {
            InitializeComponent();
        }

        private void BookSearch_Load(object sender, EventArgs e)
        {
            this.loadCategoriesData();
        }

        private void loadCategoriesData()
        {
            var categories = CategoryController.index();
            foreach (var category in categories)
            {
                this.categories.Items.Add(new ComboBoxItem { Name = category.name, Value = category.id });
            }
        }

        private void formatTable()
        {
            this.dataGridView1.Columns["title"].HeaderText = "Tiêu đề";
            this.dataGridView1.Columns["author"].HeaderText = "Tác giả";
            this.dataGridView1.Columns["publisher"].HeaderText = "Nhà xuất bản";
            this.dataGridView1.Columns["published"].HeaderText = "Năm xuất bản";
            this.dataGridView1.Columns["categories"].HeaderText = "Danh mục";
            this.dataGridView1.Columns["created_at"].HeaderText = "Ngày tạo";
            this.dataGridView1.Columns["updated_at"].HeaderText = "Ngày cập nhật";
            this.dataGridView1.Columns["stock"].HeaderText = "Số lượng";
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            var name = this.bookTitle.Text;
            var author = this.author.Text;
            var publisher = this.publisher.Text;
            var published = this.published.Text != String.Empty ? Convert.ToInt32(this.published.Text) : 0;
            var category = this.categories.Text != String.Empty ? ((ComboBoxItem)this.categories.SelectedItem).Value : 0;

            if (this.checkBox1.Checked)
            {
                var a = BookController.searchByName(name);
                this.dataGridView1.DataSource = a;
            } else if (this.checkBox2.Checked)
            {

                var b = BookController.searchByAuthor(author);
                this.dataGridView1.DataSource = b;
            } else if (this.checkBox3.Checked)
            {
                var c = BookController.searchByPublisher(publisher);
                this.dataGridView1.DataSource = c;
            } else if (this.checkBox4.Checked)
            {
                var d = BookController.searchByPublished(published);
                this.dataGridView1.DataSource = d;
            } else
            {
                var f = BookController.searchByCategory(category);
                this.dataGridView1.DataSource = f;
            }

            this.formatTable();
        }
    }
}
