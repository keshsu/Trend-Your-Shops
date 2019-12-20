using Bunifu.Framework.UI;

namespace Trend_Your_Shop_REPRISE.Master_Enrty
{
    partial class Groups
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Groups));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtsubgroupname = new System.Windows.Forms.TextBox();
            this.txtgroupname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Groupdeletbtn = new System.Windows.Forms.Button();
            this.Groupeditbtn = new System.Windows.Forms.Button();
            this.Groupsavbtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtsearch
            // 
            this.txtsearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtsearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtsearch.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearch.Location = new System.Drawing.Point(294, 216);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(5);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(368, 22);
            this.txtsearch.TabIndex = 107;
            this.txtsearch.Tag = "";
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(218, 216);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 19);
            this.label3.TabIndex = 106;
            this.label3.Text = "Search";
            // 
            // txtsubgroupname
            // 
            this.txtsubgroupname.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsubgroupname.Location = new System.Drawing.Point(334, 137);
            this.txtsubgroupname.Margin = new System.Windows.Forms.Padding(5);
            this.txtsubgroupname.Name = "txtsubgroupname";
            this.txtsubgroupname.Size = new System.Drawing.Size(328, 22);
            this.txtsubgroupname.TabIndex = 102;
            // 
            // txtgroupname
            // 
            this.txtgroupname.AutoCompleteCustomSource.AddRange(new string[] {
            "Electronics",
            "Cosmetics",
            "Bakery",
            "Food",
            "Others"});
            this.txtgroupname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtgroupname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtgroupname.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgroupname.Location = new System.Drawing.Point(334, 101);
            this.txtgroupname.Margin = new System.Windows.Forms.Padding(5);
            this.txtgroupname.Name = "txtgroupname";
            this.txtgroupname.Size = new System.Drawing.Size(328, 22);
            this.txtgroupname.TabIndex = 101;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(218, 137);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 19);
            this.label2.TabIndex = 100;
            this.label2.Text = "Sub Category";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(218, 101);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 99;
            this.label1.Text = "Category";
            // 
            // Groupdeletbtn
            // 
            this.Groupdeletbtn.BackColor = System.Drawing.Color.Teal;
            this.Groupdeletbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Groupdeletbtn.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Groupdeletbtn.Image = ((System.Drawing.Image)(resources.GetObject("Groupdeletbtn.Image")));
            this.Groupdeletbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Groupdeletbtn.Location = new System.Drawing.Point(577, 167);
            this.Groupdeletbtn.Margin = new System.Windows.Forms.Padding(5);
            this.Groupdeletbtn.Name = "Groupdeletbtn";
            this.Groupdeletbtn.Size = new System.Drawing.Size(85, 37);
            this.Groupdeletbtn.TabIndex = 105;
            this.Groupdeletbtn.Text = "Delete";
            this.Groupdeletbtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Groupdeletbtn.UseVisualStyleBackColor = false;
            this.Groupdeletbtn.Click += new System.EventHandler(this.Groupdeletbtn_Click);
            // 
            // Groupeditbtn
            // 
            this.Groupeditbtn.BackColor = System.Drawing.Color.Teal;
            this.Groupeditbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Groupeditbtn.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Groupeditbtn.Image = ((System.Drawing.Image)(resources.GetObject("Groupeditbtn.Image")));
            this.Groupeditbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Groupeditbtn.Location = new System.Drawing.Point(466, 167);
            this.Groupeditbtn.Margin = new System.Windows.Forms.Padding(5);
            this.Groupeditbtn.Name = "Groupeditbtn";
            this.Groupeditbtn.Size = new System.Drawing.Size(101, 37);
            this.Groupeditbtn.TabIndex = 104;
            this.Groupeditbtn.Text = "Modify";
            this.Groupeditbtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Groupeditbtn.UseVisualStyleBackColor = false;
            this.Groupeditbtn.Click += new System.EventHandler(this.Groupeditbtn_Click);
            // 
            // Groupsavbtn
            // 
            this.Groupsavbtn.BackColor = System.Drawing.Color.Teal;
            this.Groupsavbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Groupsavbtn.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Groupsavbtn.Image = ((System.Drawing.Image)(resources.GetObject("Groupsavbtn.Image")));
            this.Groupsavbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Groupsavbtn.Location = new System.Drawing.Point(364, 167);
            this.Groupsavbtn.Margin = new System.Windows.Forms.Padding(5);
            this.Groupsavbtn.Name = "Groupsavbtn";
            this.Groupsavbtn.Size = new System.Drawing.Size(92, 37);
            this.Groupsavbtn.TabIndex = 103;
            this.Groupsavbtn.Text = "Save";
            this.Groupsavbtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Groupsavbtn.UseVisualStyleBackColor = false;
            this.Groupsavbtn.Click += new System.EventHandler(this.Groupsavbtn_Click);
            // 
            // dataGridView1
            // 
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
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.HeaderBgColor = System.Drawing.Color.Tomato;
            this.dataGridView1.HeaderForeColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(222, 269);
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
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(440, 180);
            this.dataGridView1.TabIndex = 109;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Groups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(183)))), ((int)(((byte)(235)))));
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Groupdeletbtn);
            this.Controls.Add(this.Groupeditbtn);
            this.Controls.Add(this.Groupsavbtn);
            this.Controls.Add(this.txtsubgroupname);
            this.Controls.Add(this.txtgroupname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Groups";
            this.Size = new System.Drawing.Size(913, 572);
            this.Load += new System.EventHandler(this.Groups_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Groupdeletbtn;
        private System.Windows.Forms.Button Groupeditbtn;
        private System.Windows.Forms.Button Groupsavbtn;
        private System.Windows.Forms.TextBox txtsubgroupname;
        private System.Windows.Forms.TextBox txtgroupname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private BunifuCustomDataGrid dataGridView1;
    }
}
