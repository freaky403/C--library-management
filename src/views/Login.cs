using Nhom8_QLTV.src.controllers;
using Nhom8_QLTV.src.models;
using Nhom8_QLTV.src.utils;
using Nhom8_QLTV.src.views;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Nhom8_QLTV
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void createSession(user user)
        {
            var session = Session.getInstance();
            session.setEmail(user.email);
            session.setUsername(user.username);
            session.setPassword(user.password);
        }

        private void onLoginBtnClicked(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }

            try
            {
                var user = AuthController.login(this.username.Text, this.password.Text);
                this.createSession(user);
                MessageBox.Show("Đăng nhập thành công.");
                this.Hide();
                new Home().Show();
            }
            catch (UnauthorizedAccessException ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void onUsernameValidating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(this.username.Text))
            {
                e.Cancel = true;
                this.username.Focus();
                errorProvider.SetError(this.username, "Vui lòng điền tên người dùng.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(this.username, null);
            }
        }

        private void onPasswordValidating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(this.password.Text))
            {
                e.Cancel = true;
                this.password.Focus();
                errorProvider.SetError(this.password, "Vui lòng điền mật khẩu.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(this.password, null);
            }
        }
    }
}
