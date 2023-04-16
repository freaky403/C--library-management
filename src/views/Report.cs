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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void loadTheme()
        {
            foreach (Control btns in this.mainPanel.Controls)
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

        private void Report_Load(object sender, EventArgs e)
        {
            this.loadTheme();
        }

        private void allBtn_Click(object sender, EventArgs e)
        {
            var books = ReportController.allBook();
            this.dataGridView1.DataSource = books;
            this.dataGridView1.Columns["name"].HeaderText = "Tên sách";
            this.dataGridView1.Columns["quantity"].HeaderText = "Số lượng";
        }

        private void byAuthor_Click(object sender, EventArgs e)
        {
            var books = ReportController.byAuthor();
            this.dataGridView1.DataSource = books;
            this.dataGridView1.Columns["author"].HeaderText = "Tác giả";
            this.dataGridView1.Columns["total"].HeaderText = "Số lượng sách";
        }

        private void byCategory_Click(object sender, EventArgs e)
        {
            var books = ReportController.byCategory();
            this.dataGridView1.DataSource = books;
            this.dataGridView1.Columns["category"].HeaderText = "Thể loại";
            this.dataGridView1.Columns["total"].HeaderText = "Số lượng sách";
        }

        private void byPublisher_Click(object sender, EventArgs e)
        {
            var books = ReportController.byPublisher();
            this.dataGridView1.DataSource = books;
            this.dataGridView1.Columns["publisher"].HeaderText = "Nhà xuất bản";
            this.dataGridView1.Columns["total"].HeaderText = "Số lượng sách";
        }

        private void borrowBtn_Click(object sender, EventArgs e)
        {
            var borrows = ReportController.borrowStatus(this.startDate.Value, this.endDate.Value);
            this.dataGridView1.DataSource = borrows;
            this.dataGridView1.Columns["bookTitle"].HeaderText = "Tên sách";
            this.dataGridView1.Columns["quantity"].HeaderText = "Số lượng";
            this.dataGridView1.Columns["borrowedDate"].HeaderText = "Ngày mượn";
            this.dataGridView1.Columns["expiresAt"].HeaderText = "Ngày hẹn trả";
            this.dataGridView1.Columns["status"].HeaderText = "Tình trạng";
        }
    }
}
