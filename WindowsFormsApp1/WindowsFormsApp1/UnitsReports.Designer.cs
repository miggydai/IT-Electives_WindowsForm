
namespace WindowsFormsApp1
{
    partial class UnitsReports
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
            this.UnitsDataSet1 = new WindowsFormsApp1.UnitsDataSet1();
            this.unitsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.unitsTableAdapter = new WindowsFormsApp1.UnitsDataSet1TableAdapters.unitsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.UnitsDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.unitsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApp1.UnitReports.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(730, 290);
            this.reportViewer1.TabIndex = 0;
            // 
            // UnitsDataSet1
            // 
            this.UnitsDataSet1.DataSetName = "UnitsDataSet1";
            this.UnitsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // unitsBindingSource
            // 
            this.unitsBindingSource.DataMember = "units";
            this.unitsBindingSource.DataSource = this.UnitsDataSet1;
            // 
            // unitsTableAdapter
            // 
            this.unitsTableAdapter.ClearBeforeFill = true;
            // 
            // UnitsReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 290);
            this.Controls.Add(this.reportViewer1);
            this.Name = "UnitsReports";
            this.Text = "UnitsReports";
            this.Load += new System.EventHandler(this.UnitsReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UnitsDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource unitsBindingSource;
        private UnitsDataSet1 UnitsDataSet1;
        private UnitsDataSet1TableAdapters.unitsTableAdapter unitsTableAdapter;
    }
}