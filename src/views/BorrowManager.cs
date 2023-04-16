using Nhom8_QLTV.src.controllers;
using Nhom8_QLTV.src.models;
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
    public partial class BorrowManager : Form
    {
        public BorrowManager()
        {
            InitializeComponent();
        }

        private void loadData()
        {
            var borrows = BorrowController.index();
            var brNotReturn = BorrowController.notReturnsYet();
            this.dataGridView1.DataSource = borrows;
            this.dataGridView2.DataSource = brNotReturn;
        }

        private void formatTable()
        {
            this.dataGridView1.Columns["bookID"].HeaderText = "Mã sách";
            this.dataGridView1.Columns["bookTitle"].HeaderText = "Tên sách";
            this.dataGridView1.Columns["bookCategory"].HeaderText = "Danh mục sách";
            this.dataGridView1.Columns["readerID"].HeaderText = "Mã độc giả";
            this.dataGridView1.Columns["readerName"].HeaderText = "Tên độc giả";
            this.dataGridView1.Columns["librarianName"].HeaderText = "Thủ thư";
            this.dataGridView1.Columns["borrowedDate"].HeaderText = "Ngày mượn";
            this.dataGridView1.Columns["expiresAt"].HeaderText = "Ngày hẹn trả";
            this.dataGridView1.Columns["returnAt"].HeaderText = "Ngày trả";
            this.dataGridView1.Columns["quantity"].HeaderText = "Số lượng mượn";
            this.dataGridView1.Columns["createdAt"].HeaderText = "Ngày tạo";
            this.dataGridView1.Columns["updatedAt"].HeaderText = "Ngày cập nhật";

            this.dataGridView2.Columns["bookID"].HeaderText = "Mã sách";
            this.dataGridView2.Columns["bookTitle"].HeaderText = "Tên sách";
            this.dataGridView2.Columns["bookCategory"].HeaderText = "Danh mục sách";
            this.dataGridView2.Columns["readerID"].HeaderText = "Mã độc giả";
            this.dataGridView2.Columns["readerName"].HeaderText = "Tên độc giả";
            this.dataGridView2.Columns["librarianName"].HeaderText = "Thủ thư";
            this.dataGridView2.Columns["borrowedDate"].HeaderText = "Ngày mượn";
            this.dataGridView2.Columns["expiresAt"].HeaderText = "Ngày hẹn trả";
            this.dataGridView2.Columns["returnAt"].HeaderText = "Ngày trả";
            this.dataGridView2.Columns["quantity"].HeaderText = "Số lượng mượn";
            this.dataGridView2.Columns["createdAt"].HeaderText = "Ngày tạo";
            this.dataGridView2.Columns["updatedAt"].HeaderText = "Ngày cập nhật";
        }

        private void BorrowManager_Load(object sender, EventArgs e)
        {
            this.loadData();
            this.formatTable();
            this.cancelBtn.Enabled = false;
        }

        private void resetForm()
        {
            this.bookID.Text = "";
            this.readerID.Text = "";
            this.label2.Text = "Tên sách";
            this.label3.Text = "Tác giả";
            this.label4.Text = "Nhà xuất bản";
            this.label5.Text = "Năm xuất bản";
            this.label6.Text = "Số lượng";
            this.label8.Text = "Tên độc giả";
        }

        private bool validated()
        {
            if (String.IsNullOrEmpty(this.bookID.Text))
            {
                MessageBox.Show("Vui lòng điền mã sách.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(this.readerID.Text))
            {
                MessageBox.Show("Vui lòng điền mã độc giả.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            if (!this.validated()) return;

            long bookID = Convert.ToInt64(this.bookID.Text);
            var book = BookController.show(bookID);

            if (book == null)
            {
                MessageBox.Show("Không tìm thấy sách.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.label2.Text = "Tên sách: " + book.name;
            this.label3.Text = "Tác giả: " + book.author;
            this.label4.Text = "Nhà xuất bản: " + book.publisher;
            this.label5.Text = "Năm xuất bản: " + Convert.ToString(book.published);
            this.label6.Text = "Số lượng: " + Convert.ToString(book.quantity);

            long readerID = Convert.ToInt64(this.readerID.Text);
            var reader = ReaderController.show(readerID);

            if (reader == null)
            {
                MessageBox.Show("Không tìm thấy độc giả.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.label8.Text = "Tên độc giả: " + reader.name;
            this.cancelBtn.Enabled = true;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.resetForm();
        }

        private void borrowBtn_Click(object sender, EventArgs e)
        {
            if (!this.validated()) return;

            if (String.IsNullOrEmpty(this.expiresAt.Text))
            {
                MessageBox.Show("Vui lòng điền ngày hẹn trả.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.quantity.Value == 0 || this.quantity.Value < 0)
            {
                MessageBox.Show("Vui lòng điền số lượng mượn.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var isPastExpires = (DateTime.Now - this.expiresAt.Value).TotalDays > 0;

            if (isPastExpires)
            {
                MessageBox.Show("Ngày hẹn trả không hợp lệ.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var borrow = new borrow
            {
                expires_at = this.expiresAt.Value,
            };
            var bookBorrow = new book_borrow
            {
                book_id = Convert.ToInt64(this.bookID.Text),
                reader_id = Convert.ToInt64(this.readerID.Text),
                quantity = Convert.ToInt32(this.quantity.Value),
            };
            
            if (BorrowController.store(borrow, bookBorrow))
            {
                MessageBox.Show("Đã thêm vào danh sách mượn.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.loadData();
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.borrowID.Text) && String.IsNullOrEmpty(this.readerRID.Text))
            {
                MessageBox.Show("Vui lòng điền mã độc giả hoặc mã mượn/trả.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (this.readerRID.Text == String.Empty)
            {
                long brID = Convert.ToInt64(this.borrowID.Text);
                var a = BorrowController.searchByID(brID);
                if (a != null)
                {
                    this.dataGridView2.DataSource = a;
                }
                return;
            }

            if (this.borrowID.Text == String.Empty)
            {
                long rdID = Convert.ToInt64(this.readerRID.Text);
                var b = BorrowController.searchByReaderID(rdID);
                if (b != null)
                {
                    this.dataGridView2.DataSource = b;
                }
                return;
            }

            long borrowID = Convert.ToInt64(this.borrowID.Text);
            long readerID = Convert.ToInt64(this.readerRID.Text);
            var borrow = BorrowController.searchByIDAndReaderID(borrowID, readerID);
            if (borrow != null)
            {
                this.dataGridView2.DataSource = borrow;
            }
            return;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView tmp = (DataGridView)sender;
            if (tmp.CurrentRow == null) return;

            long bookID = Convert.ToInt64(this.dataGridView2.CurrentRow.Cells[1].Value);
            this.label20.Text = "Mã sách: " + this.dataGridView2.CurrentRow.Cells[1].Value.ToString();
            var book = BookController.show(bookID);
            if (book != null)
            {
                this.label19.Text = "Tên sách: " + book.name;
                this.label18.Text = "Tác giả: " + book.author;
                this.label17.Text = "Nhà xuất bản: " + book.publisher;
                this.label16.Text = "Năm xuất bản: " + Convert.ToString(book.published);
                this.label15.Text = "Số lượng: " + Convert.ToString(book.quantity);
            }

            this.readerRID.Text = this.dataGridView2.CurrentRow.Cells[4].Value.ToString();
            this.borrowID.Text = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
            this.label13.Text = "Tên độc giả: " + this.dataGridView2.CurrentRow.Cells[5].Value.ToString();
            this.label12.Text = "Ngày hẹn trả: " + this.dataGridView2.CurrentRow.Cells[8].Value.ToString();
            this.label11.Text = "Số lượng: " + this.dataGridView2.CurrentRow.Cells[10].Value.ToString();

            this.cancelBtn.Enabled = true;
        }

        private void cancelRBtn_Click(object sender, EventArgs e)
        {
            this.label20.Text = "Mã sách";
            this.label19.Text = "Tên sách";
            this.label18.Text = "Tác giả";
            this.label17.Text = "Nhà xuất bản";
            this.label16.Text = "Năm xuất bản";
            this.label15.Text = "Số lượng";
            this.readerRID.Text = "";
            this.borrowID.Text = "";
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.borrowID.Text) && String.IsNullOrEmpty(this.readerRID.Text))
            {
                MessageBox.Show("Vui lòng điền mã độc giả hoặc mã mượn/trả.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialog = MessageBox.Show("Xác nhận trả?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialog == DialogResult.Yes)
            {
                long borrowID = Convert.ToInt64(this.borrowID.Text);
                BorrowController.returns(borrowID);
                MessageBox.Show("Đã trả sách.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.loadData();
                this.label20.Text = "Mã sách";
                this.label19.Text = "Tên sách";
                this.label18.Text = "Tác giả";
                this.label17.Text = "Nhà xuất bản";
                this.label16.Text = "Năm xuất bản";
                this.label15.Text = "Số lượng";
                this.readerRID.Text = "";
                this.borrowID.Text = "";
            } else
            {
                return;
            }
        }
    }
}
