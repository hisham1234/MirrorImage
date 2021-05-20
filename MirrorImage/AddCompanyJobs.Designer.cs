namespace MirrorImage
{
    partial class AddCompanyJobs
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
            this.cmpCmb = new System.Windows.Forms.ComboBox();
            this.jobCmb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Job = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.serviceGrdVw = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serviceGrdVw)).BeginInit();
            this.SuspendLayout();
            // 
            // cmpCmb
            // 
            this.cmpCmb.FormattingEnabled = true;
            this.cmpCmb.Location = new System.Drawing.Point(78, 25);
            this.cmpCmb.Name = "cmpCmb";
            this.cmpCmb.Size = new System.Drawing.Size(194, 21);
            this.cmpCmb.TabIndex = 0;
            // 
            // jobCmb
            // 
            this.jobCmb.FormattingEnabled = true;
            this.jobCmb.Location = new System.Drawing.Point(78, 69);
            this.jobCmb.Name = "jobCmb";
            this.jobCmb.Size = new System.Drawing.Size(194, 21);
            this.jobCmb.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Company";
            // 
            // Job
            // 
            this.Job.AutoSize = true;
            this.Job.Location = new System.Drawing.Point(3, 74);
            this.Job.Name = "Job";
            this.Job.Size = new System.Drawing.Size(24, 13);
            this.Job.TabIndex = 3;
            this.Job.Text = "Job";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(403, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Price";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.jobCmb);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmpCmb);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Job);
            this.panel1.Location = new System.Drawing.Point(3, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 110);
            this.panel1.TabIndex = 6;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(477, 22);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(109, 20);
            this.txtPrice.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(328, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // serviceGrdVw
            // 
            this.serviceGrdVw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.serviceGrdVw.Location = new System.Drawing.Point(3, 128);
            this.serviceGrdVw.Name = "serviceGrdVw";
            this.serviceGrdVw.Size = new System.Drawing.Size(589, 211);
            this.serviceGrdVw.TabIndex = 7;
            this.serviceGrdVw.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.serviceGrdVw_RowHeaderMouseClick_1);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(406, 74);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 23);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(499, 74);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // AddCompanyJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(704, 401);
            this.Controls.Add(this.serviceGrdVw);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AddCompanyJobs";
            this.Text = "AddCompanyJobs";
            this.Load += new System.EventHandler(this.AddCompanyJobs_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serviceGrdVw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmpCmb;
        private System.Windows.Forms.ComboBox jobCmb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Job;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView serviceGrdVw;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}