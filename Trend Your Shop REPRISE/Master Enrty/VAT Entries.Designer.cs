namespace Trend_Your_Shop_REPRISE.Master_Enrty
{
    partial class VAT_Entries
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VAT_Entries));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtVatPerc = new System.Windows.Forms.ComboBox();
            this.dtEndVat = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtStatVat = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVatProdNm = new System.Windows.Forms.ComboBox();
            this.txtVatProdModNm = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbGrpNam = new System.Windows.Forms.ComboBox();
            this.cmbSubGrpNam = new System.Windows.Forms.ComboBox();
            this.VATDelBtn = new System.Windows.Forms.Button();
            this.VATmodfyBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtVatPerc
            // 
            this.txtVatPerc.FormattingEnabled = true;
            this.txtVatPerc.Location = new System.Drawing.Point(173, 202);
            this.txtVatPerc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVatPerc.Name = "txtVatPerc";
            this.txtVatPerc.Size = new System.Drawing.Size(222, 21);
            this.txtVatPerc.TabIndex = 32;
            // 
            // dtEndVat
            // 
            this.dtEndVat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEndVat.Location = new System.Drawing.Point(648, 203);
            this.dtEndVat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtEndVat.Name = "dtEndVat";
            this.dtEndVat.Size = new System.Drawing.Size(111, 20);
            this.dtEndVat.TabIndex = 34;
            this.dtEndVat.Value = new System.DateTime(2018, 12, 31, 14, 21, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(620, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 17);
            this.label5.TabIndex = 42;
            this.label5.Text = "to";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(459, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 41;
            this.label4.Text = "Date";
            // 
            // dtStatVat
            // 
            this.dtStatVat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtStatVat.Location = new System.Drawing.Point(503, 203);
            this.dtStatVat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtStatVat.Name = "dtStatVat";
            this.dtStatVat.Size = new System.Drawing.Size(111, 20);
            this.dtStatVat.TabIndex = 33;
            this.dtStatVat.Value = new System.DateTime(2018, 1, 1, 18, 6, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(119, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 40;
            this.label1.Text = "VAT %";
            // 
            // txtVatProdNm
            // 
            this.txtVatProdNm.FormattingEnabled = true;
            this.txtVatProdNm.Location = new System.Drawing.Point(218, 132);
            this.txtVatProdNm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVatProdNm.Name = "txtVatProdNm";
            this.txtVatProdNm.Size = new System.Drawing.Size(199, 21);
            this.txtVatProdNm.TabIndex = 26;
            this.txtVatProdNm.TextChanged += new System.EventHandler(this.txtVatProdNm_SelectedIndexChanged);
            // 
            // txtVatProdModNm
            // 
            this.txtVatProdModNm.FormattingEnabled = true;
            this.txtVatProdModNm.Location = new System.Drawing.Point(566, 133);
            this.txtVatProdModNm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVatProdModNm.Name = "txtVatProdModNm";
            this.txtVatProdModNm.Size = new System.Drawing.Size(193, 21);
            this.txtVatProdModNm.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(467, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 17);
            this.label6.TabIndex = 39;
            this.label6.Text = "Model Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(117, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 17);
            this.label7.TabIndex = 38;
            this.label7.Text = "Product Name";
            // 
            // cmbGrpNam
            // 
            this.cmbGrpNam.FormattingEnabled = true;
            this.cmbGrpNam.Location = new System.Drawing.Point(173, 167);
            this.cmbGrpNam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbGrpNam.Name = "cmbGrpNam";
            this.cmbGrpNam.Size = new System.Drawing.Size(244, 21);
            this.cmbGrpNam.TabIndex = 29;
            // 
            // cmbSubGrpNam
            // 
            this.cmbSubGrpNam.FormattingEnabled = true;
            this.cmbSubGrpNam.Location = new System.Drawing.Point(565, 167);
            this.cmbSubGrpNam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbSubGrpNam.Name = "cmbSubGrpNam";
            this.cmbSubGrpNam.Size = new System.Drawing.Size(194, 21);
            this.cmbSubGrpNam.TabIndex = 31;
            // 
            // VATDelBtn
            // 
            this.VATDelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(153)))));
            this.VATDelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VATDelBtn.Font = new System.Drawing.Font("Century Gothic", 10.25F, System.Drawing.FontStyle.Bold);
            this.VATDelBtn.Image = ((System.Drawing.Image)(resources.GetObject("VATDelBtn.Image")));
            this.VATDelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VATDelBtn.Location = new System.Drawing.Point(680, 248);
            this.VATDelBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.VATDelBtn.Name = "VATDelBtn";
            this.VATDelBtn.Size = new System.Drawing.Size(97, 37);
            this.VATDelBtn.TabIndex = 36;
            this.VATDelBtn.Text = "Delete";
            this.VATDelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.VATDelBtn.UseVisualStyleBackColor = false;
            this.VATDelBtn.Click += new System.EventHandler(this.VATDelBtn_Click);
            // 
            // VATmodfyBtn
            // 
            this.VATmodfyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(153)))));
            this.VATmodfyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VATmodfyBtn.Font = new System.Drawing.Font("Century Gothic", 10.25F, System.Drawing.FontStyle.Bold);
            this.VATmodfyBtn.Image = ((System.Drawing.Image)(resources.GetObject("VATmodfyBtn.Image")));
            this.VATmodfyBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VATmodfyBtn.Location = new System.Drawing.Point(544, 248);
            this.VATmodfyBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.VATmodfyBtn.Name = "VATmodfyBtn";
            this.VATmodfyBtn.Size = new System.Drawing.Size(114, 37);
            this.VATmodfyBtn.TabIndex = 35;
            this.VATmodfyBtn.Text = "Modify";
            this.VATmodfyBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.VATmodfyBtn.UseVisualStyleBackColor = false;
            this.VATmodfyBtn.Click += new System.EventHandler(this.VATmodfyBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(482, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 30;
            this.label3.Text = "Sub Group";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(118, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "Group";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DoubleBuffered = true;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.HeaderBgColor = System.Drawing.Color.Tomato;
            this.dataGridView1.HeaderForeColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(89, 292);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(710, 202);
            this.dataGridView1.TabIndex = 43;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // VAT_Entries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(184)))), ((int)(((byte)(234)))));
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtVatPerc);
            this.Controls.Add(this.dtEndVat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtStatVat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVatProdNm);
            this.Controls.Add(this.txtVatProdModNm);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbGrpNam);
            this.Controls.Add(this.cmbSubGrpNam);
            this.Controls.Add(this.VATDelBtn);
            this.Controls.Add(this.VATmodfyBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "VAT_Entries";
            this.Size = new System.Drawing.Size(913, 572);
            this.Load += new System.EventHandler(this.VAT_Entries_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox txtVatPerc;
        private System.Windows.Forms.DateTimePicker dtEndVat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtStatVat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtVatProdNm;
        private System.Windows.Forms.ComboBox txtVatProdModNm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbGrpNam;
        private System.Windows.Forms.ComboBox cmbSubGrpNam;
        private System.Windows.Forms.Button VATDelBtn;
        private System.Windows.Forms.Button VATmodfyBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dataGridView1;
    }
}
