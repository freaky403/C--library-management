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
    public partial class Home : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        public Home()
        {
            InitializeComponent();
            this.random = new Random();
        }

        private Color selectThemeColor()
        {
            int index = this.random.Next(ThemeColor.ColorList.Count);
            while(this.tempIndex == index)
            {
                index = this.random.Next(ThemeColor.ColorList.Count);
            }

            this.tempIndex = index;
            string color = ThemeColor.ColorList[index];

            return ColorTranslator.FromHtml(color);
        }

        private void activeButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (this.currentButton != (Button)btnSender)
                {
                    this.disableButton();
                    Color color = selectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("JetBrains Mono", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
                    this.titlePanel.BackColor = color;
                    this.menuHeadingPanel.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }

        private void disableButton()
        {
            foreach (Control previousBtn in this.menuPanel.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(141, 114, 255);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("JetBrains Mono", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
                }
            }
        }

        private void openChildForm(Form childForm, object btnSender)
        {
            if (this.activeForm != null)
            {
                activeForm.Close();
            }

            this.activeButton(btnSender);
            this.activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(childForm);
            this.mainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            this.title.Text = childForm.Text;
        }

        private void onFormLoad(object sender, EventArgs e)
        {
            
        }

        private void onFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void bookBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void categoryBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void accountBtn_Click(object sender, EventArgs e)
        {
            this.openChildForm(new AccountManager(), sender);
        }

        private void readerBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void borrowBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void reportbtn_Click(object sender, EventArgs e)
        {
            
        }
    }
}
