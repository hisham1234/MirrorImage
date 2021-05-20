namespace MirrorImage
{
    partial class AddJobs
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
            this.jobGrid = new System.Windows.Forms.DataGridView();
            this.AddJob = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJob = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtJobId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.jobGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // jobGrid
            // 
            this.jobGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.jobGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jobGrid.Location = new System.Drawing.Point(35, 72);
            this.jobGrid.Name = "jobGrid";
            this.jobGrid.Size = new System.Drawing.Size(557, 208);
            this.jobGrid.TabIndex = 16;
            this.jobGrid.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.jobGrid_RowHeaderMouseClick);
            // 
            // AddJob
            // 
            this.AddJob.Location = new System.Drawing.Point(337, 23);
            this.AddJob.Name = "AddJob";
            this.AddJob.Size = new System.Drawing.Size(81, 23);
            this.AddJob.TabIndex = 15;
            this.AddJob.Text = "Add";
            this.AddJob.UseVisualStyleBackColor = true;
            this.AddJob.Click += new System.EventHandler(this.AddJob_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Job Name";
            // 
            // txtJob
            // 
            this.txtJob.Location = new System.Drawing.Point(123, 25);
            this.txtJob.Name = "txtJob";
            this.txtJob.Size = new System.Drawing.Size(187, 20);
            this.txtJob.TabIndex = 13;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(424, 22);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(81, 23);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(511, 22);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(81, 23);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtJobId
            // 
            this.txtJobId.Location = new System.Drawing.Point(123, 51);
            this.txtJobId.Name = "txtJobId";
            this.txtJobId.Size = new System.Drawing.Size(187, 20);
            this.txtJobId.TabIndex = 19;
            // 
            // AddJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(608, 302);
            this.Controls.Add(this.txtJobId);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.jobGrid);
            this.Controls.Add(this.AddJob);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtJob);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AddJobs";
            this.Text = "AddJobs";
            this.Load += new System.EventHandler(this.AddJobs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jobGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView jobGrid;
        private System.Windows.Forms.Button AddJob;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJob;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtJobId;
    }
}