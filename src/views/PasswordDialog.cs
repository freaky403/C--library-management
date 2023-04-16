using Nhom8_QLTV.src.controllers;
using Nhom8_QLTV.src.utils;
using System;
using System.Windows.Forms;

namespace Nhom8_QLTV.src.views
{
    public partial class PasswordDialog : Form
    {
        private Action action;
        private long userID;
        private string username;
        private string oldUsername;
        private string email;

        public PasswordDialog(Action action, long userID)
        {
            InitializeComponent();
            this.action = action;
            this.userID = userID;
        }

        public void setUsername(string username)
        {
            this.username = username;
        }

        public void setOldUsername(string oldUsername)
        {
            this.oldUsername = oldUsername;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }
        
        private void validated()
        {
            if (String.IsNullOrEmpty(this.password.Text)) throw new Exception("Vui lòng nhập mật khẩu.");

            var user = UserController.show(this.userID);
            var isValidPassword = HashPassword.Verify(this.password.Text, user.password);

            if (!isValidPassword) throw new Exception("Mật khẩu không chính xác. Vui lòng thử lại.");
        }

        private void submitBtn_Click(object sender, System.EventArgs e)
        {
            switch (this.action)
            {
                case Action.Edit:
                    try
                    {
                        this.validated();

                        var user = new models.user
                        {
                            username = this.username,
                            email = this.email,
                        };

                        UserController.update(this.userID, user);

                        MessageBox.Show("Cập nhật thông tin thành công.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    } catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case Action.Delete:
                    try
                    {
                        this.validated();

                        DialogResult dialog = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (dialog == DialogResult.Yes)
                        {
                            UserController.destroy(this.userID);

                            MessageBox.Show("Xóa tài khoản thành công.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }

                    } catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        private void PasswordDialog_Load(object sender, EventArgs e)
        {
            this.label2.Text = "Tên tài khoản: " + this.oldUsername;
        }
    }
}
