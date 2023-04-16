using Nhom8_QLTV.src.controllers;
using Nhom8_QLTV.src.models;
using Nhom8_QLTV.src.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom8_QLTV.src.views
{
    public partial class BookManager : Form
    {
        private Action action;
        private long selectedBook;

        public BookManager()
        {
            InitializeComponent();
        }

        private void loadTheme()
        {
            foreach (Control btns in this.actionPanel.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }

        private void loadData()
        {
            var books = BookController.index();
            this.dataGridView1.DataSource = books;
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

        private void setFormControlStatus(bool status)
        {
            this.bookTitle.Enabled = status;
            this.bookAuthor.Enabled = status;
            this.bookPublisher.Enabled = status;
            this.bookPublished.Enabled = status;
            this.bookStock.Enabled = status;
            this.categories.Enabled= status;
        }

        private void setFormActionStatus(bool status)
        {
            this.editBtn.Enabled = status;
            this.saveBtn.Enabled = status;
            this.delBtn.Enabled = status;
            this.cancelBtn.Enabled = status;
        }

        private void resetForm()
        {
            this.bookTitle.Text = "";
            this.bookAuthor.Text = "";
            this.bookPublisher.Text = "";
            this.bookPublished.Text = "";
            this.bookStock.Text = "";
            this.categories.Text = "";
        }

        private void BookManager_Load(object sender, EventArgs e)
        {
            this.loadTheme();
            this.loadData();
            this.loadCategoriesData();
            this.formatTable();
            this.setFormControlStatus(false);
            this.setFormActionStatus(false);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            this.saveBtn.Enabled = true;
            this.setFormControlStatus(true);
            this.cancelBtn.Enabled = true;
            this.action = Action.Add;
        }

        private bool validated()
        {
            if (String.IsNullOrEmpty(this.bookTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sách.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(this.bookAuthor.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tác giả.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(this.bookPublisher.Text))
            {
                MessageBox.Show("Vui lòng nhập nhà xuất bản.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(this.bookPublished.Text))
            {
                MessageBox.Show("Vui lòng nhập năm xuất bản.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else
            {
                var pbPattern = @"^[0-9]{4}$";
                Regex pbRegex = new Regex(pbPattern);

                if (!pbRegex.IsMatch(this.bookPublished.Text))
                {
                    MessageBox.Show("Năm xuất bản không hợp lệ.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (String.IsNullOrEmpty(this.bookStock.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng sách.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } else
            {
                var sPattern = @"[0-9]+";
                Regex sRegex = new Regex(sPattern);

                if (!sRegex.IsMatch(this.bookStock.Text))
                {
                    MessageBox.Show("Số lượng sách không hợp lệ.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (String.IsNullOrEmpty(this.categories.Text))
            {
                MessageBox.Show("Vui lòng chọn danh mục sách.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void addNewBook()
        {
            var book = new book
            {
                name = this.bookTitle.Text,
                author = this.bookAuthor.Text,
                publisher = this.bookPublisher.Text,
                published = Convert.ToInt32(this.bookPublished.Text),
                quantity = Convert.ToInt32(this.bookStock.Text),
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };
            var categoryID = ((ComboBoxItem)this.categories.SelectedItem).Value;

            BookController.store(book, categoryID);
            MessageBox.Show("Thêm sách mới thành công.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void editBook()
        {
            var book = new book
            {
                name = this.bookTitle.Text,
                author = this.bookAuthor.Text,
                publisher = this.bookPublisher.Text,
                published = Convert.ToInt32(this.bookPublished.Text),
                quantity = Convert.ToInt32(this.bookStock.Text),
            };
            var categoryID = ((ComboBoxItem)this.categories.SelectedItem).Value;

            BookController.update(this.selectedBook, book, categoryID);
            MessageBox.Show("Cập nhật thông tin sách thành công.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!this.validated()) return;

            switch (action)
            {
                case Action.Add:
                    this.addNewBook();
                    break;

                case Action.Edit:
                    this.editBook();
                    break;

                default:
                    break;
            }

            this.resetForm();
            this.setFormControlStatus(false);
            this.setFormActionStatus(false);
            this.addBtn.Enabled = true;
            this.loadData();
            this.selectedBook = 0;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView tmp = (DataGridView)sender;
            if (tmp.CurrentRow == null) return;

            this.editBtn.Enabled = true;
            this.delBtn.Enabled = true;
            this.saveBtn.Enabled = false;

            this.bookTitle.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.bookAuthor.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.bookPublisher.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.bookPublished.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            this.bookStock.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            this.selectedBook = Convert.ToInt64(this.dataGridView1.CurrentRow.Cells[0].Value);
            
            if (this.dataGridView1.CurrentRow.Cells[6].Value != null)
            {
                this.categories.SelectedIndex = this.categories.FindStringExact(this.dataGridView1.CurrentRow.Cells[6].Value.ToString());
            } else
            {
                this.categories.Text = "";
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            this.setFormControlStatus(true);
            this.action = Action.Edit;
            this.cancelBtn.Enabled = true;
            this.addBtn.Enabled = false;
            this.saveBtn.Enabled = true;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.resetForm();
            this.setFormControlStatus(false);
            this.setFormActionStatus(false);
            this.addBtn.Enabled = true;
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có chắc muốn xóa không?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                BookController.destroy(this.selectedBook);
                MessageBox.Show("Xóa thành công.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.resetForm();
                this.setFormControlStatus(false);
                this.setFormActionStatus(false);
                this.loadData();
            } else
            {
                return;
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            new BookSearch().ShowDialog();
        }
    }
}
