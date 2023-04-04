using Nhom8_QLTV.src.controllers;
using Nhom8_QLTV.src.models;
using Nhom8_QLTV.src.utils;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Nhom8_QLTV.src.views
{
    public partial class Register : Form
    {
        public Register()
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

        private void onUsernameValidating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(this.username.Text))
            {
                e.Cancel = true;
                this.username.Focus();
                errorProvider.SetError(this.username, "Vui lòng điền tên người dùng.");

            }
            else if (!(this.username.Text.Length > 5 && this.username.Text.Length <= 20))
            {
                e.Cancel = true;
                this.username.Focus();
                errorProvider.SetError(this.username, "Tên người dùng phải từ 6 - 20 ký tự.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(this.username, null);
            }
        }

        private void onEmailValidating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(this.email.Text))
            {
                e.Cancel = true;
                this.email.Focus();
                errorProvider.SetError(this.email, "Vui lòng điền email.");
            }
            else
            {
                var pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
                Regex regex = new Regex(pattern);

                if (!regex.IsMatch(this.email.Text))
                {
                    e.Cancel = true;
                    this.email.Focus();
                    errorProvider.SetError(this.email, "Địa chỉ email không hợp lệ.");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(this.email, null);
                }
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
                var pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*.,])[A-Za-z0-9!@#$%^&*.,]{6,20}$";
                Regex regex = new Regex(pattern);

                if (!regex.IsMatch(this.password.Text))
                {
                    e.Cancel = true;
                    this.password.Focus();
                    errorProvider.SetError(this.password, "Mật khẩu phải từ 6 - 20 ký tự, bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt.");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(this.password, null);
                }
            }
        }

        private void onConfimationPasswordValidating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(this.confirmationPassword.Text))
            {
                e.Cancel = true;
                this.password.Focus();
                errorProvider.SetError(this.confirmationPassword, "Vui lòng xác nhận mật khẩu.");
            }
            else if (!this.confirmationPassword.Text.Equals(this.password.Text))
            {
                e.Cancel = true;
                this.password.Focus();
                errorProvider.SetError(this.confirmationPassword, "Mật khẩu không khớp.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(this.confirmationPassword, null);
            }
        }

        private void clearForm()
        {
            this.username.Text = "";
            this.email.Text = "";
            this.password.Text = "";
            this.confirmationPassword.Text = "";
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren()) return;

            var user = new user
            {
                username = this.username.Text,
                email = this.email.Text,
                password = this.password.Text,
                created_at = DateTime.Now,
                updated_at = DateTime.Now,
            };

            try
            {
                var created = AuthController.register(user);
                MessageBox.Show("Thêm tài khoản mới thành công.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.clearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {
            this.loadTheme();
        }
    }
}
