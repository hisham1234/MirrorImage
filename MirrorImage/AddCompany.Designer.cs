namespace MirrorImage
{
    partial class AddCompany
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
            this.cmpnyGrid = new System.Windows.Forms.DataGridView();
            this.AddCmpny = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CmpnyTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhn = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.RichTextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtCmpId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.cmpnyGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // cmpnyGrid
            // 
            this.cmpnyGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.cmpnyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cmpnyGrid.Location = new System.Drawing.Point(45, 132);
            this.cmpnyGrid.Name = "cmpnyGrid";
            this.cmpnyGrid.Size = new System.Drawing.Size(604, 168);
            this.cmpnyGrid.TabIndex = 12;
            this.cmpnyGrid.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.cmpnyGrid_RowHeaderMouseClick);
            // 
            // AddCmpny
            // 
            this.AddCmpny.Location = new System.Drawing.Point(130, 103);
            this.AddCmpny.Name = "AddCmpny";
            this.AddCmpny.Size = new System.Drawing.Size(100, 23);
            this.AddCmpny.TabIndex = 10;
            this.AddCmpny.Text = "Add";
            this.AddCmpny.UseVisualStyleBackColor = true;
            this.AddCmpny.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Company Name";
            // 
            // CmpnyTxt
            // 
            this.CmpnyTxt.Location = new System.Drawing.Point(130, 23);
            this.CmpnyTxt.Name = "CmpnyTxt";
            this.CmpnyTxt.Size = new System.Drawing.Size(187, 20);
            this.CmpnyTxt.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Phone Number";
            // 
            // txtPhn
            // 
            this.txtPhn.Location = new System.Drawing.Point(130, 74);
            this.txtPhn.Name = "txtPhn";
            this.txtPhn.Size = new System.Drawing.Size(187, 20);
            this.txtPhn.TabIndex = 16;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(408, 23);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(187, 36);
            this.txtAddress.TabIndex = 17;
            this.txtAddress.Text = "";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(260, 103);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 23);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(388, 103);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 23);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtCmpId
            // 
            this.txtCmpId.Location = new System.Drawing.Point(0, 3);
            this.txtCmpId.Name = "txtCmpId";
            this.txtCmpId.Size = new System.Drawing.Size(120, 20);
            this.txtCmpId.TabIndex = 20;
            // 
            // AddCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(681, 335);
            this.Controls.Add(this.txtCmpId);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtPhn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmpnyGrid);
            this.Controls.Add(this.AddCmpny);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmpnyTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AddCompany";
            this.Text = "Company";
            this.Load += new System.EventHandler(this.AddCompany_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmpnyGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView cmpnyGrid;
        private System.Windows.Forms.Button AddCmpny;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CmpnyTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPhn;
        private System.Windows.Forms.RichTextBox txtAddress;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtCmpId;
    }
}