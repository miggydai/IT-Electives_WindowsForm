
namespace WindowsFormsApp1
{
    partial class OrderPrint
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.GetRecieptData = new WindowsFormsApp1.GetRecieptData();
            this.getRecieptBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.getRecieptTableAdapter = new WindowsFormsApp1.GetRecieptDataTableAdapters.getRecieptTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.GetRecieptData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getRecieptBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.getRecieptBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApp1.PurchaseReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(794, 359);
            this.reportViewer1.TabIndex = 0;
            // 
            // GetRecieptData
            // 
            this.GetRecieptData.DataSetName = "GetRecieptData";
            this.GetRecieptData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getRecieptBindingSource
            // 
            this.getRecieptBindingSource.DataMember = "getReciept";
            this.getRecieptBindingSource.DataSource = this.GetRecieptData;
            // 
            // getRecieptTableAdapter
            // 
            this.getRecieptTableAdapter.ClearBeforeFill = true;
            // 
            // OrderPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 359);
            this.Controls.Add(this.reportViewer1);
            this.Name = "OrderPrint";
            this.Text = "OrderPrint";
            this.Load += new System.EventHandler(this.OrderPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GetRecieptData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getRecieptBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource getRecieptBindingSource;
        private GetRecieptData GetRecieptData;
        private GetRecieptDataTableAdapters.getRecieptTableAdapter getRecieptTableAdapter;
    }
}