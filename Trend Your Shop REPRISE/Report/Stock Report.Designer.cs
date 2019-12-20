namespace Trend_Your_Shop_REPRISE
{
    partial class Stock_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stock_Report));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.StockAllRepBtn = new System.Windows.Forms.Button();
            this.StockprintBtn = new System.Windows.Forms.Button();
            this.StockRepBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.combProductname = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(181, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(288, 78);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter Date Wise";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(165, 27);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(113, 23);
            this.dateTimePicker2.TabIndex = 5;
            this.dateTimePicker2.Value = new System.DateTime(2018, 12, 31, 0, 0, 0, 0);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(8, 25);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(113, 23);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.Value = new System.DateTime(2018, 1, 1, 12, 1, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "To";
            // 
            // StockAllRepBtn
            // 
            this.StockAllRepBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.StockAllRepBtn.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockAllRepBtn.ForeColor = System.Drawing.Color.White;
            this.StockAllRepBtn.Image = ((System.Drawing.Image)(resources.GetObject("StockAllRepBtn.Image")));
            this.StockAllRepBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StockAllRepBtn.Location = new System.Drawing.Point(568, 41);
            this.StockAllRepBtn.Margin = new System.Windows.Forms.Padding(4);
            this.StockAllRepBtn.Name = "StockAllRepBtn";
            this.StockAllRepBtn.Size = new System.Drawing.Size(91, 43);
            this.StockAllRepBtn.TabIndex = 9;
            this.StockAllRepBtn.Text = "All Report";
            this.StockAllRepBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.StockAllRepBtn.UseVisualStyleBackColor = false;
            this.StockAllRepBtn.Click += new System.EventHandler(this.StockAllRepBtn_Click);
            // 
            // StockprintBtn
            // 
            this.StockprintBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.StockprintBtn.Enabled = false;
            this.StockprintBtn.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockprintBtn.ForeColor = System.Drawing.Color.White;
            this.StockprintBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StockprintBtn.Location = new System.Drawing.Point(667, 41);
            this.StockprintBtn.Margin = new System.Windows.Forms.Padding(4);
            this.StockprintBtn.Name = "StockprintBtn";
            this.StockprintBtn.Size = new System.Drawing.Size(67, 43);
            this.StockprintBtn.TabIndex = 10;
            this.StockprintBtn.Text = "Print";
            this.StockprintBtn.UseVisualStyleBackColor = false;
            this.StockprintBtn.Click += new System.EventHandler(this.StockprintBtn_Click);
            // 
            // StockRepBtn
            // 
            this.StockRepBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.StockRepBtn.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockRepBtn.ForeColor = System.Drawing.Color.White;
            this.StockRepBtn.Image = ((System.Drawing.Image)(resources.GetObject("StockRepBtn.Image")));
            this.StockRepBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StockRepBtn.Location = new System.Drawing.Point(477, 41);
            this.StockRepBtn.Margin = new System.Windows.Forms.Padding(4);
            this.StockRepBtn.Name = "StockRepBtn";
            this.StockRepBtn.Size = new System.Drawing.Size(83, 43);
            this.StockRepBtn.TabIndex = 9;
            this.StockRepBtn.Text = "Report";
            this.StockRepBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.StockRepBtn.UseVisualStyleBackColor = false;
            this.StockRepBtn.Click += new System.EventHandler(this.StockRepBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 92);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(735, 496);
            this.dataGridView1.TabIndex = 11;
            // 
            // combProductname
            // 
            this.combProductname.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combProductname.FormattingEnabled = true;
            this.combProductname.Location = new System.Drawing.Point(13, 41);
            this.combProductname.Margin = new System.Windows.Forms.Padding(4);
            this.combProductname.Name = "combProductname";
            this.combProductname.Size = new System.Drawing.Size(160, 25);
            this.combProductname.TabIndex = 12;
            this.combProductname.TextChanged += new System.EventHandler(this.combProductname_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Product Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(557, 604);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Total Quantity :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(664, 604);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "0";
            // 
            // Stock_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(184)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(739, 655);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combProductname);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.StockprintBtn);
            this.Controls.Add(this.StockRepBtn);
            this.Controls.Add(this.StockAllRepBtn);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Stock_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Report";
            this.Load += new System.EventHandler(this.Stock_Report_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StockAllRepBtn;
        private System.Windows.Forms.Button StockprintBtn;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button StockRepBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox combProductname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}