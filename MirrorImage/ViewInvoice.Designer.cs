namespace MirrorImage
{
    partial class ViewInvoice
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
            this.reportInvoice = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnShowInvoice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportInvoice
            // 
            this.reportInvoice.LocalReport.ReportEmbeddedResource = "MirrorImage.Reports.Invoice.rdlc";
            this.reportInvoice.Location = new System.Drawing.Point(12, 46);
            this.reportInvoice.Name = "reportInvoice";
            this.reportInvoice.Size = new System.Drawing.Size(670, 512);
            this.reportInvoice.TabIndex = 0;
            // 
            // btnShowInvoice
            // 
            this.btnShowInvoice.Location = new System.Drawing.Point(314, 13);
            this.btnShowInvoice.Name = "btnShowInvoice";
            this.btnShowInvoice.Size = new System.Drawing.Size(75, 23);
            this.btnShowInvoice.TabIndex = 1;
            this.btnShowInvoice.Text = "Show Invoice";
            this.btnShowInvoice.UseVisualStyleBackColor = true;
            this.btnShowInvoice.Click += new System.EventHandler(this.btnShowInvoice_Click);
            // 
            // ViewInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 570);
            this.Controls.Add(this.btnShowInvoice);
            this.Controls.Add(this.reportInvoice);
            this.Name = "ViewInvoice";
            this.Text = "ViewInvoice";
            this.Load += new System.EventHandler(this.ViewInvoice_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportInvoice;
        private System.Windows.Forms.Button btnShowInvoice;
    }
}