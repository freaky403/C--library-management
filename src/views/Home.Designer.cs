namespace Nhom8_QLTV.src.views
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titlePanel = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.menuHeadingPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.reportbtn = new System.Windows.Forms.Button();
            this.borrowBtn = new System.Windows.Forms.Button();
            this.accountBtn = new System.Windows.Forms.Button();
            this.readerBtn = new System.Windows.Forms.Button();
            this.categoryBtn = new System.Windows.Forms.Button();
            this.bookBtn = new System.Windows.Forms.Button();
            this.homeBtn = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.titlePanel.SuspendLayout();
            this.menuHeadingPanel.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.titlePanel.Controls.Add(this.title);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.Location = new System.Drawing.Point(360, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(1095, 90);
            this.titlePanel.TabIndex = 1;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("JetBrains Mono", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(500, 27);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(159, 36);
            this.title.TabIndex = 0;
            this.title.Text = "Trang Chủ";
            // 
            // menuHeadingPanel
            // 
            this.menuHeadingPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.menuHeadingPanel.Controls.Add(this.label1);
            this.menuHeadingPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuHeadingPanel.ForeColor = System.Drawing.Color.White;
            this.menuHeadingPanel.Location = new System.Drawing.Point(0, 0);
            this.menuHeadingPanel.Name = "menuHeadingPanel";
            this.menuHeadingPanel.Size = new System.Drawing.Size(360, 90);
            this.menuHeadingPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("JetBrains Mono", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(42, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý thư viện";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.menuPanel.Controls.Add(this.reportbtn);
            this.menuPanel.Controls.Add(this.borrowBtn);
            this.menuPanel.Controls.Add(this.accountBtn);
            this.menuPanel.Controls.Add(this.readerBtn);
            this.menuPanel.Controls.Add(this.categoryBtn);
            this.menuPanel.Controls.Add(this.bookBtn);
            this.menuPanel.Controls.Add(this.homeBtn);
            this.menuPanel.Controls.Add(this.menuHeadingPanel);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(360, 802);
            this.menuPanel.TabIndex = 0;
            // 
            // reportbtn
            // 
            this.reportbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(114)))), ((int)(((byte)(255)))));
            this.reportbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reportbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.reportbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportbtn.Font = new System.Drawing.Font("JetBrains Mono Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.reportbtn.Image = global::Nhom8_QLTV.Properties.Resources.Heartbeat;
            this.reportbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reportbtn.Location = new System.Drawing.Point(0, 510);
            this.reportbtn.Name = "reportbtn";
            this.reportbtn.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.reportbtn.Size = new System.Drawing.Size(360, 70);
            this.reportbtn.TabIndex = 7;
            this.reportbtn.Text = "     Thống kê";
            this.reportbtn.UseVisualStyleBackColor = false;
            this.reportbtn.Click += new System.EventHandler(this.reportbtn_Click);
            // 
            // borrowBtn
            // 
            this.borrowBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(114)))), ((int)(((byte)(255)))));
            this.borrowBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.borrowBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.borrowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.borrowBtn.Font = new System.Drawing.Font("JetBrains Mono Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.borrowBtn.Image = global::Nhom8_QLTV.Properties.Resources.Document_2;
            this.borrowBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.borrowBtn.Location = new System.Drawing.Point(0, 440);
            this.borrowBtn.Name = "borrowBtn";
            this.borrowBtn.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.borrowBtn.Size = new System.Drawing.Size(360, 70);
            this.borrowBtn.TabIndex = 6;
            this.borrowBtn.Text = "     Quản lý mượn trả";
            this.borrowBtn.UseVisualStyleBackColor = false;
            this.borrowBtn.Click += new System.EventHandler(this.borrowBtn_Click);
            // 
            // accountBtn
            // 
            this.accountBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(114)))), ((int)(((byte)(255)))));
            this.accountBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.accountBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.accountBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accountBtn.Font = new System.Drawing.Font("JetBrains Mono Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.accountBtn.Image = global::Nhom8_QLTV.Properties.Resources.User;
            this.accountBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.accountBtn.Location = new System.Drawing.Point(0, 370);
            this.accountBtn.Name = "accountBtn";
            this.accountBtn.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.accountBtn.Size = new System.Drawing.Size(360, 70);
            this.accountBtn.TabIndex = 5;
            this.accountBtn.Text = "     Quản lý tài khoản";
            this.accountBtn.UseVisualStyleBackColor = false;
            this.accountBtn.Click += new System.EventHandler(this.accountBtn_Click);
            // 
            // readerBtn
            // 
            this.readerBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(114)))), ((int)(((byte)(255)))));
            this.readerBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.readerBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.readerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readerBtn.Font = new System.Drawing.Font("JetBrains Mono Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.readerBtn.Image = global::Nhom8_QLTV.Properties.Resources.Users;
            this.readerBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.readerBtn.Location = new System.Drawing.Point(0, 300);
            this.readerBtn.Name = "readerBtn";
            this.readerBtn.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.readerBtn.Size = new System.Drawing.Size(360, 70);
            this.readerBtn.TabIndex = 4;
            this.readerBtn.Text = "     Quản lý độc giả";
            this.readerBtn.UseVisualStyleBackColor = false;
            this.readerBtn.Click += new System.EventHandler(this.readerBtn_Click);
            // 
            // categoryBtn
            // 
            this.categoryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(114)))), ((int)(((byte)(255)))));
            this.categoryBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.categoryBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.categoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.categoryBtn.Font = new System.Drawing.Font("JetBrains Mono Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.categoryBtn.Image = global::Nhom8_QLTV.Properties.Resources.Color_Palette;
            this.categoryBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.categoryBtn.Location = new System.Drawing.Point(0, 230);
            this.categoryBtn.Name = "categoryBtn";
            this.categoryBtn.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.categoryBtn.Size = new System.Drawing.Size(360, 70);
            this.categoryBtn.TabIndex = 3;
            this.categoryBtn.Text = "     Quản lý DM sách";
            this.categoryBtn.UseVisualStyleBackColor = false;
            this.categoryBtn.Click += new System.EventHandler(this.categoryBtn_Click);
            // 
            // bookBtn
            // 
            this.bookBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(114)))), ((int)(((byte)(255)))));
            this.bookBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bookBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.bookBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bookBtn.Font = new System.Drawing.Font("JetBrains Mono Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.bookBtn.Image = global::Nhom8_QLTV.Properties.Resources.Box_1;
            this.bookBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bookBtn.Location = new System.Drawing.Point(0, 160);
            this.bookBtn.Name = "bookBtn";
            this.bookBtn.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.bookBtn.Size = new System.Drawing.Size(360, 70);
            this.bookBtn.TabIndex = 2;
            this.bookBtn.Text = "     Quản lý sách";
            this.bookBtn.UseVisualStyleBackColor = false;
            this.bookBtn.Click += new System.EventHandler(this.bookBtn_Click);
            // 
            // homeBtn
            // 
            this.homeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(114)))), ((int)(((byte)(255)))));
            this.homeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.homeBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.homeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeBtn.Font = new System.Drawing.Font("JetBrains Mono Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.homeBtn.Image = global::Nhom8_QLTV.Properties.Resources.Home;
            this.homeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.homeBtn.Location = new System.Drawing.Point(0, 90);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.homeBtn.Size = new System.Drawing.Size(360, 70);
            this.homeBtn.TabIndex = 1;
            this.homeBtn.Text = "     Trang chủ";
            this.homeBtn.UseVisualStyleBackColor = false;
            this.homeBtn.Click += new System.EventHandler(this.homeBtn_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(360, 90);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1095, 712);
            this.mainPanel.TabIndex = 2;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1455, 802);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.titlePanel);
            this.Controls.Add(this.menuPanel);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Home";
            this.Text = "Quản lý thư viện";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onFormClosed);
            this.Load += new System.EventHandler(this.onFormLoad);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.menuHeadingPanel.ResumeLayout(false);
            this.menuHeadingPanel.PerformLayout();
            this.menuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Panel menuHeadingPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button homeBtn;
        private System.Windows.Forms.Button bookBtn;
        private System.Windows.Forms.Button categoryBtn;
        private System.Windows.Forms.Button readerBtn;
        private System.Windows.Forms.Button accountBtn;
        private System.Windows.Forms.Button borrowBtn;
        private System.Windows.Forms.Button reportbtn;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label title;
    }
}