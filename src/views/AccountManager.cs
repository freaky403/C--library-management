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
    public partial class AccountManager : Form
    {
        private Action action;
        private long selectedUser;

        public AccountManager()
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
            var users = UserController.index();
            this.dataGridView1.DataSource = users;
        }

        private void formatTable()
        {
            this.dataGridView1.Columns["username"].HeaderText = "Tên người dùng";
            this.dataGridView1.Columns["email"].HeaderText = "Email";
            this.dataGridView1.Columns["role"].HeaderText = "Vai trò";
            this.dataGridView1.Columns["createdAt"].HeaderText = "Ngày tạo";
            this.dataGridView1.Columns["updatedAt"].HeaderText = "Ngày cập nhật";
        }

        private void setFormControlStatus(bool status)
        {
            this.username.Enabled = status;
            this.email.Enabled = status;
        }

        private void setFormActionStatus(bool status)
        {
            this.editBtn.Enabled = status;
            this.delBtn.Enabled = status;
            this.saveBtn.Enabled = status;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            this.saveBtn.Enabled = true;
            this.setFormControlStatus(true);
            this.action = Action.Edit;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            new Register().ShowDialog();
            this.loadData();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            PasswordDialog dialog = new PasswordDialog(this.action, this.selectedUser);
            dialog.setUsername(this.username.Text);
            dialog.setEmail(this.email.Text);
            dialog.ShowDialog();
            this.loadData();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            this.action = Action.Delete;
            PasswordDialog dialog = new PasswordDialog(this.action, this.selectedUser);
            dialog.setUsername(this.username.Text);
            dialog.setEmail(this.email.Text);
            dialog.ShowDialog();
            this.loadData();
        }

        private void AccountManager_Load(object sender, EventArgs e)
        {
            this.loadTheme();
            this.loadData();
            this.formatTable();
            this.setFormControlStatus(false);
            this.setFormActionStatus(false);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView tmp = (DataGridView)sender;
            if (tmp.CurrentRow == null) return;

            this.editBtn.Enabled = true;
            this.delBtn.Enabled = true;

            this.username.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.email.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.selectedUser = Convert.ToInt64(this.dataGridView1.CurrentRow.Cells[0].Value);
        }
    }
}
