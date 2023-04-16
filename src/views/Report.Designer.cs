namespace Nhom8_QLTV.src.views
{
    partial class Report
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.allBtn = new System.Windows.Forms.Button();
            this.byAuthor = new System.Windows.Forms.Button();
            this.byCategory = new System.Windows.Forms.Button();
            this.byPublisher = new System.Windows.Forms.Button();
            this.borrowBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.mainPanel.Controls.Add(this.dataGridView1);
            this.mainPanel.Controls.Add(this.endDate);
            this.mainPanel.Controls.Add(this.startDate);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.borrowBtn);
            this.mainPanel.Controls.Add(this.byPublisher);
            this.mainPanel.Controls.Add(this.byCategory);
            this.mainPanel.Controls.Add(this.byAuthor);
            this.mainPanel.Controls.Add(this.allBtn);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.ForeColor = System.Drawing.Color.Black;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(966, 616);
            this.mainPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("JetBrains Mono", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(437, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thống kê";
            // 
            // allBtn
            // 
            this.allBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(114)))), ((int)(((byte)(255)))));
            this.allBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.allBtn.Font = new System.Drawing.Font("JetBrains Mono", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.allBtn.ForeColor = System.Drawing.Color.White;
            this.allBtn.Location = new System.Drawing.Point(26, 112);
            this.allBtn.Name = "allBtn";
            this.allBtn.Size = new System.Drawing.Size(284, 49);
            this.allBtn.TabIndex = 1;
            this.allBtn.Text = "Tổng số lượng sách";
            this.allBtn.UseVisualStyleBackColor = false;
            this.allBtn.Click += new System.EventHandler(this.allBtn_Click);
            // 
            // byAuthor
            // 
            this.byAuthor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(114)))), ((int)(((byte)(255)))));
            this.byAuthor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.byAuthor.Font = new System.Drawing.Font("JetBrains Mono", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.byAuthor.ForeColor = System.Drawing.Color.White;
            this.byAuthor.Location = new System.Drawing.Point(331, 112);
            this.byAuthor.Name = "byAuthor";
            this.byAuthor.Size = new System.Drawing.Size(172, 49);
            this.byAuthor.TabIndex = 2;
            this.byAuthor.Text = "Theo tác giả";
            this.byAuthor.UseVisualStyleBackColor = false;
            this.byAuthor.Click += new System.EventHandler(this.byAuthor_Click);
            // 
            // byCategory
            // 
            this.byCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(114)))), ((int)(((byte)(255)))));
            this.byCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.byCategory.Font = new System.Drawing.Font("JetBrains Mono", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.byCategory.ForeColor = System.Drawing.Color.White;
            this.byCategory.Location = new System.Drawing.Point(524, 112);
            this.byCategory.Name = "byCategory";
            this.byCategory.Size = new System.Drawing.Size(172, 49);
            this.byCategory.TabIndex = 3;
            this.byCategory.Text = "Theo thể loại";
            this.byCategory.UseVisualStyleBackColor = false;
            this.byCategory.Click += new System.EventHandler(this.byCategory_Click);
            // 
            // byPublisher
            // 
            this.byPublisher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(114)))), ((int)(((byte)(255)))));
            this.byPublisher.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.byPublisher.Font = new System.Drawing.Font("JetBrains Mono", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.byPublisher.ForeColor = System.Drawing.Color.White;
            this.byPublisher.Location = new System.Drawing.Point(716, 112);
            this.byPublisher.Name = "byPublisher";
            this.byPublisher.Size = new System.Drawing.Size(207, 49);
            this.byPublisher.TabIndex = 4;
            this.byPublisher.Text = "Theo nhà xuất bản";
            this.byPublisher.UseVisualStyleBackColor = false;
            this.byPublisher.Click += new System.EventHandler(this.byPublisher_Click);
            // 
            // borrowBtn
            // 
            this.borrowBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(114)))), ((int)(((byte)(255)))));
            this.borrowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.borrowBtn.Font = new System.Drawing.Font("JetBrains Mono", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.borrowBtn.ForeColor = System.Drawing.Color.White;
            this.borrowBtn.Location = new System.Drawing.Point(618, 294);
            this.borrowBtn.Name = "borrowBtn";
            this.borrowBtn.Size = new System.Drawing.Size(284, 49);
            this.borrowBtn.TabIndex = 5;
            this.borrowBtn.Text = "Tình trạng mượn trả";
            this.borrowBtn.UseVisualStyleBackColor = false;
            this.borrowBtn.Click += new System.EventHandler(this.borrowBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("JetBrains Mono", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(22, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ngày bắt đầu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("JetBrains Mono", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(406, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ngày kết thúc";
            // 
            // startDate
            // 
            this.startDate.CalendarFont = new System.Drawing.Font("JetBrains Mono", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.startDate.Location = new System.Drawing.Point(158, 237);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(205, 22);
            this.startDate.TabIndex = 8;
            // 
            // endDate
            // 
            this.endDate.CalendarFont = new System.Drawing.Font("JetBrains Mono", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.endDate.Location = new System.Drawing.Point(552, 237);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(205, 22);
            this.endDate.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 376);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(960, 237);
            this.dataGridView1.TabIndex = 10;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 616);
            this.Controls.Add(this.mainPanel);
            this.Name = "Report";
            this.Text = "Thống kê";
            this.Load += new System.EventHandler(this.Report_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button allBtn;
        private System.Windows.Forms.Button byAuthor;
        private System.Windows.Forms.Button byCategory;
        private System.Windows.Forms.Button byPublisher;
        private System.Windows.Forms.Button borrowBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}