namespace Trend_Your_Shop_REPRISE
{
    partial class VAT_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VAT_Report));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.VATDetailsbtn = new System.Windows.Forms.Button();
            this.VATClosebtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "To";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(220, 13);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 2;
            // 
            // VATDetailsbtn
            // 
            this.VATDetailsbtn.Image = ((System.Drawing.Image)(resources.GetObject("VATDetailsbtn.Image")));
            this.VATDetailsbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VATDetailsbtn.Location = new System.Drawing.Point(168, 55);
            this.VATDetailsbtn.Name = "VATDetailsbtn";
            this.VATDetailsbtn.Size = new System.Drawing.Size(75, 29);
            this.VATDetailsbtn.TabIndex = 3;
            this.VATDetailsbtn.Text = "Detail";
            this.VATDetailsbtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.VATDetailsbtn.UseVisualStyleBackColor = true;
            this.VATDetailsbtn.Click += new System.EventHandler(this.VATDetailsbtn_Click);
            // 
            // VATClosebtn
            // 
            this.VATClosebtn.Image = ((System.Drawing.Image)(resources.GetObject("VATClosebtn.Image")));
            this.VATClosebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VATClosebtn.Location = new System.Drawing.Point(249, 55);
            this.VATClosebtn.Name = "VATClosebtn";
            this.VATClosebtn.Size = new System.Drawing.Size(70, 29);
            this.VATClosebtn.TabIndex = 4;
            this.VATClosebtn.Text = "Close";
            this.VATClosebtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.VATClosebtn.UseVisualStyleBackColor = true;
            this.VATClosebtn.Click += new System.EventHandler(this.VATClosebtn_Click);
            // 
            // VAT_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(184)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(358, 98);
            this.Controls.Add(this.VATClosebtn);
            this.Controls.Add(this.VATDetailsbtn);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VAT_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VAT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button VATDetailsbtn;
        private System.Windows.Forms.Button VATClosebtn;
    }
}