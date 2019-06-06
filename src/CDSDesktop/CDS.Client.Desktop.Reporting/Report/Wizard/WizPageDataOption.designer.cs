// Developer Express Code Central Example:
// How to customize a Report Wizard
// 
// This example demonstrates how to create a Custom Report Wizard with the
// capability to define the SQL query, based on which the resulting report's data
// source will be generated (see the corresponding suggestion:
// http://www.devexpress.com/scid=AS4685).
// 
// In order to run you custom wizard in
// the corresponding handler, override the ReportCommand.NewReportWizard,
// ReportCommand.AddNewDataSource, and ReportCommand.VerbReportWizard commands (as
// described in this documentation article: How to: Override Commands in the
// End-User Designer (Custom Saving)
// (ms-help://DevExpress.NETv9.1/DevExpress.XtraReports/CustomDocument2211.htm). A
// Custom Report Wizard inherits from the XRWizardRunnerBase class, custom wizard
// pages are inherited from the InteriorWizardPage class.
// 
// Note that for most
// custom wizard pages, you should override the InteriorWizardPage.OnWizardBack()
// and InteriorWizardPage.OnWizardNext() virtual methods, to provide proper wizard
// navigation logic.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E1538

namespace CDS.Client.Desktop.Reporting.Report.Wizard
{
    partial class WizPageDataOption
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
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.headerPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Location = new System.Drawing.Point(15, 8);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLabel.Size = new System.Drawing.Size(308, 18);
            this.titleLabel.Text = "Choose Data Source";
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.Location = new System.Drawing.Point(38, 21);
            this.subtitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.subtitleLabel.Size = new System.Drawing.Size(284, 15);
            this.subtitleLabel.Text = "Select Query or Table/View";
            // 
            // headerPanel
            // 
            this.headerPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            // 
            // headerPicture
            // 
            this.headerPicture.Location = new System.Drawing.Point(443, 4);
            this.headerPicture.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.headerPicture.Size = new System.Drawing.Size(37, 40);
            // 
            // headerSeparator
            // 
            this.headerSeparator.Location = new System.Drawing.Point(0, 54);
            this.headerSeparator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.headerSeparator.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.headerSeparator.Size = new System.Drawing.Size(490, 2);
            // 
            // radioGroup1
            // 
            this.radioGroup1.EditValue = "Query";
            this.radioGroup1.Location = new System.Drawing.Point(206, 127);
            this.radioGroup1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Query", "Query"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Table", "Table/View")});
            this.radioGroup1.Size = new System.Drawing.Size(84, 49);
            this.radioGroup1.TabIndex = 5;
            // 
            // WizPageDataOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radioGroup1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "WizPageDataOption";
            this.Size = new System.Drawing.Size(497, 303);
            this.Controls.SetChildIndex(this.radioGroup1, 0);
            this.Controls.SetChildIndex(this.headerPanel, 0);
            this.Controls.SetChildIndex(this.headerSeparator, 0);
            this.Controls.SetChildIndex(this.titleLabel, 0);
            this.Controls.SetChildIndex(this.subtitleLabel, 0);
            this.Controls.SetChildIndex(this.headerPicture, 0);
            ((System.ComponentModel.ISupportInitialize)(this.headerPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup radioGroup1;
    }
}