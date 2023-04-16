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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom8_QLTV.src.views
{
    public partial class CategoryManager : Form
    {
        private Action action;
        private long selectedCategory;

        public CategoryManager()
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

        private void setFormControlStatus(bool status)
        {
            this.name.Enabled = status;
        }

        private void setFormActionStatus(bool status)
        {
            this.editBtn.Enabled = status;
            this.saveBtn.Enabled = status;
            this.delBtn.Enabled = status;
            this.editBtn.Enabled = status;
        }

        private void formatTable()
        {
            this.dataGridView1.Columns["name"].HeaderText = "Tên danh mục";
            this.dataGridView1.Columns["created_at"].HeaderText = "Ngày tạo";
            this.dataGridView1.Columns["updated_at"].HeaderText = "Ngày cập nhật";
        }

        private void loadData()
        {
            var categories = CategoryController.index();
            this.dataGridView1.DataSource = categories;
        }

        private void CategoryManager_Load(object sender, EventArgs e)
        {
            this.loadTheme();
            this.setFormControlStatus(false);
            this.setFormActionStatus(false);
            this.loadData();
            this.formatTable();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            this.setFormControlStatus(true);
            this.saveBtn.Enabled = true;
            this.cancelBtn.Enabled = true;
            this.action = Action.Add;
        }

        private bool validated()
        {
            if (String.IsNullOrEmpty(this.name.Text))
            {
                MessageBox.Show("Vui lòng điền tên danh mục", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void addNewCategory()
        {
            var category = new category
            {
                name = this.name.Text,
            };
            CategoryController.store(category);
            MessageBox.Show("Thêm danh mục mới thành công.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void editCategory()
        {
            var category = new category { name = this.name.Text };
            CategoryController.update(this.selectedCategory, category);
            MessageBox.Show("Cập nhật thông tin thành công.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!this.validated()) return;

            switch (this.action)
            {
                case Action.Add:
                    this.addNewCategory();
                    break;

                case Action.Edit:
                    this.editCategory();
                    break;
            }

            this.loadData();
            this.name.Text = "";
            this.setFormControlStatus(false);
            this.setFormActionStatus(false);
            this.addBtn.Enabled = true;
            this.selectedCategory = 0;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView tmp = (DataGridView)sender;
            if (tmp.CurrentRow == null) return;

            this.editBtn.Enabled = true;
            this.delBtn.Enabled = true;
            this.saveBtn.Enabled = false;

            this.name.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.selectedCategory = Convert.ToInt64(this.dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            this.saveBtn.Enabled = true;
            this.addBtn.Enabled = false;
            this.setFormControlStatus(true);
            this.action = Action.Edit;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.name.Text = "";
            this.setFormControlStatus(false);
            this.setFormActionStatus(false);
            this.selectedCategory = 0;
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có chắc muốn xóa không?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                CategoryController.destroy(this.selectedCategory);
                MessageBox.Show("Xóa thành công.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.name.Text = "";
                this.setFormControlStatus(false);
                this.setFormActionStatus(false);
                this.loadData();
            }
            else
            {
                return;
            }
        }
    }
}
