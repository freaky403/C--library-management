using Nhom8_QLTV.src.controllers;
using Nhom8_QLTV.src.models;
using Nhom8_QLTV.src.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom8_QLTV.src.views
{
    public partial class ReaderManager : Form
    {
        private Action action;
        private long selectedReader;

        public ReaderManager()
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
            var readers = ReaderController.index();
            this.dataGridView1.DataSource = readers;
        }

        private void setFormControlStatus(bool status)
        {
            this.readerName.Enabled = status;
            this.femaleGender.Enabled = status;
            this.maleGender.Enabled = status;
            this.dateOfBirth.Enabled = status;
            this.phoneNumber.Enabled = status;
            this.expiresAt.Enabled = status;
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
            this.readerName.Text = "";
            this.femaleGender.Checked = false;
            this.maleGender.Checked = false;
            this.dateOfBirth.Text = "";
            this.expiresAt.Text = "";
            this.phoneNumber.Text = "";
        }

        private void formatTable()
        {
            this.dataGridView1.Columns["name"].HeaderText = "Tên độc giả";
            this.dataGridView1.Columns["gender"].HeaderText = "Giới tính";
            this.dataGridView1.Columns["dateOfBirth"].HeaderText = "Ngày sinh";
            this.dataGridView1.Columns["phoneNumber"].HeaderText = "Số điện thoại";
            this.dataGridView1.Columns["expiresAt"].HeaderText = "Ngày hết hạn thẻ";
            this.dataGridView1.Columns["createdAt"].HeaderText = "Ngày tạo";
            this.dataGridView1.Columns["updatedAt"].HeaderText = "Ngày cập nhật";
        }

        private void ReaderManager_Load(object sender, EventArgs e)
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

        private void editBtn_Click(object sender, EventArgs e)
        {
            this.setFormControlStatus(true);
            this.action = Action.Edit;
            this.cancelBtn.Enabled = true;
            this.addBtn.Enabled = false;
            this.saveBtn.Enabled = true;
        }

        private bool validated()
        {
            if (String.IsNullOrEmpty(this.readerName.Text))
            {
                MessageBox.Show("Vui lòng điền tên độc giả", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!(this.maleGender.Checked || this.femaleGender.Checked))
            {
                MessageBox.Show("Vui lòng chọn giới tính", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(this.dateOfBirth.Text))
            {
                MessageBox.Show("Vui lòng điền ngày sinh", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(this.phoneNumber.Text))
            {
                MessageBox.Show("Vui lòng điền số điện thoại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(this.expiresAt.Text))
            {
                MessageBox.Show("Vui lòng điền thời hạn thẻ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var isFutureDob = (DateTime.Now - this.dateOfBirth.Value).TotalDays < 0;

            if (isFutureDob)
            {
                MessageBox.Show("Ngày sinh không hợp lệ. Cỗ máy thời gian chưa được phát minh :))", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var isPastExpires = (DateTime.Now - this.expiresAt.Value).TotalDays > 0;

            if (isPastExpires)
            {
                MessageBox.Show("Ngày hết hạn thẻ không hợp lệ.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var phonePattern = @"^0[0-9]{9}$";
            Regex phoneRegex = new Regex(phonePattern);

            if (!phoneRegex.IsMatch(this.phoneNumber.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }

        private void addNewReader()
        {
            var reader = new reader
            {
                name = this.readerName.Text,
                gender = (short?)(this.maleGender.Checked ? 1 : 0),
                date_of_birth = this.dateOfBirth.Value,
                phone_number = this.phoneNumber.Text,
                expires_at = this.expiresAt.Value,
            };
            ReaderController.store(reader);
            MessageBox.Show("Thêm độc giả mới thành công.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void editReader()
        {
            var reader = new reader
            {
                name = this.readerName.Text,
                gender = (short?)(this.maleGender.Checked ? 1 : 0),
                date_of_birth = this.dateOfBirth.Value,
                phone_number = this.phoneNumber.Text,
                expires_at = this.expiresAt.Value,
            };
            ReaderController.update(this.selectedReader, reader);
            MessageBox.Show("Cập nhật thông tin thành công.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!this.validated()) return;

            switch (this.action)
            {
                case Action.Add:
                    this.addNewReader();
                    break;

                case Action.Edit:
                    this.editReader();
                    break;

                default:
                    break;
            }

            this.setFormControlStatus(false);
            this.setFormActionStatus(false);
            this.resetForm();
            this.loadData();
            this.addBtn.Enabled = true;
            this.selectedReader = 0;
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có chắc muốn xóa không?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                if (ReaderController.destroy(this.selectedReader))
                {
                    MessageBox.Show("Xóa thành công.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.resetForm();
                    this.setFormControlStatus(false);
                    this.setFormActionStatus(false);
                    this.loadData();
                }
            }
            else
            {
                return;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.resetForm();
            this.setFormControlStatus(false);
            this.setFormActionStatus(false);
            this.addBtn.Enabled = true;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView tmp = (DataGridView)sender;
            if (tmp.CurrentRow == null) return;

            this.editBtn.Enabled = true;
            this.delBtn.Enabled = true;
            this.saveBtn.Enabled = false;

            this.selectedReader = Convert.ToInt64(this.dataGridView1.CurrentRow.Cells[0].Value);
            this.readerName.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.maleGender.Checked = this.dataGridView1.CurrentRow.Cells[2].Value.ToString() == "Nam";
            this.femaleGender.Checked = this.dataGridView1.CurrentRow.Cells[2].Value.ToString() == "Nữ";
            this.dateOfBirth.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells[3].Value);
            this.phoneNumber.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            this.expiresAt.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells[5].Value);
        }
    }
}
