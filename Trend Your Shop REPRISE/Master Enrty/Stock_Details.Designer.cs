namespace Trend_Your_Shop_REPRISE.Master_Enrty
{
    partial class Stock_Details
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Close = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.UpdtBtn = new System.Windows.Forms.Button();
            this.QtyNm = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label4 = new System.Windows.Forms.Label();
            this.ModNm = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.ProdNm = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.DasStkView = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DasStkView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(153)))));
            this.Close.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.ForeColor = System.Drawing.SystemColors.Control;
            this.Close.Location = new System.Drawing.Point(790, 32);
            this.Close.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(109, 27);
            this.Close.TabIndex = 12;
            this.Close.Text = "Search";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(184)))), ((int)(((byte)(234)))));
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.Close);
            this.panel2.Controls.Add(this.UpdtBtn);
            this.panel2.Controls.Add(this.QtyNm);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.ModNm);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.ProdNm);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.DasStkView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(913, 572);
            this.panel2.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Bahnschrift", 12.25F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(605, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(179, 27);
            this.comboBox1.TabIndex = 13;
            // 
            // UpdtBtn
            // 
            this.UpdtBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(153)))));
            this.UpdtBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.UpdtBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdtBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.UpdtBtn.Location = new System.Drawing.Point(153, 344);
            this.UpdtBtn.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.UpdtBtn.Name = "UpdtBtn";
            this.UpdtBtn.Size = new System.Drawing.Size(109, 34);
            this.UpdtBtn.TabIndex = 12;
            this.UpdtBtn.Text = "Update";
            this.UpdtBtn.UseVisualStyleBackColor = false;
            this.UpdtBtn.Click += new System.EventHandler(this.UpdtBtn_Click);
            // 
            // QtyNm
            // 
            this.QtyNm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.QtyNm.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QtyNm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.QtyNm.HintForeColor = System.Drawing.Color.Empty;
            this.QtyNm.HintText = "Quantity";
            this.QtyNm.isPassword = false;
            this.QtyNm.LineFocusedColor = System.Drawing.Color.Blue;
            this.QtyNm.LineIdleColor = System.Drawing.Color.White;
            this.QtyNm.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.QtyNm.LineThickness = 3;
            this.QtyNm.Location = new System.Drawing.Point(40, 307);
            this.QtyNm.Margin = new System.Windows.Forms.Padding(5);
            this.QtyNm.Name = "QtyNm";
            this.QtyNm.Size = new System.Drawing.Size(222, 28);
            this.QtyNm.TabIndex = 2;
            this.QtyNm.Text = "0";
            this.QtyNm.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(40, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Quantity";
            // 
            // ModNm
            // 
            this.ModNm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ModNm.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModNm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ModNm.HintForeColor = System.Drawing.Color.Empty;
            this.ModNm.HintText = "";
            this.ModNm.isPassword = false;
            this.ModNm.LineFocusedColor = System.Drawing.Color.Blue;
            this.ModNm.LineIdleColor = System.Drawing.Color.White;
            this.ModNm.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.ModNm.LineThickness = 3;
            this.ModNm.Location = new System.Drawing.Point(40, 238);
            this.ModNm.Margin = new System.Windows.Forms.Padding(5);
            this.ModNm.Name = "ModNm";
            this.ModNm.Size = new System.Drawing.Size(222, 28);
            this.ModNm.TabIndex = 2;
            this.ModNm.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(40, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Model Name";
            // 
            // ProdNm
            // 
            this.ProdNm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ProdNm.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProdNm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ProdNm.HintForeColor = System.Drawing.Color.Empty;
            this.ProdNm.HintText = "";
            this.ProdNm.isPassword = false;
            this.ProdNm.LineFocusedColor = System.Drawing.Color.Blue;
            this.ProdNm.LineIdleColor = System.Drawing.Color.White;
            this.ProdNm.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.ProdNm.LineThickness = 3;
            this.ProdNm.Location = new System.Drawing.Point(40, 167);
            this.ProdNm.Margin = new System.Windows.Forms.Padding(5);
            this.ProdNm.Name = "ProdNm";
            this.ProdNm.Size = new System.Drawing.Size(222, 28);
            this.ProdNm.TabIndex = 2;
            this.ProdNm.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(40, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Product Name";
            // 
            // DasStkView
            // 
            this.DasStkView.AllowUserToAddRows = false;
            this.DasStkView.AllowUserToDeleteRows = false;
            this.DasStkView.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.DasStkView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DasStkView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DasStkView.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DasStkView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DasStkView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DasStkView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DasStkView.DoubleBuffered = true;
            this.DasStkView.EnableHeadersVisualStyles = false;
            this.DasStkView.HeaderBgColor = System.Drawing.Color.Tomato;
            this.DasStkView.HeaderForeColor = System.Drawing.Color.Black;
            this.DasStkView.Location = new System.Drawing.Point(314, 65);
            this.DasStkView.Name = "DasStkView";
            this.DasStkView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DasStkView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DasStkView.RowTemplate.Height = 30;
            this.DasStkView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DasStkView.Size = new System.Drawing.Size(587, 466);
            this.DasStkView.TabIndex = 0;
            this.DasStkView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DasStkView_CellClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Stock_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Stock_Details";
            this.Size = new System.Drawing.Size(913, 572);
            this.Load += new System.EventHandler(this.Stock_Details_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DasStkView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuCustomDataGrid DasStkView;
        private Bunifu.Framework.UI.BunifuMaterialTextbox QtyNm;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuMaterialTextbox ModNm;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuMaterialTextbox ProdNm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button UpdtBtn;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
