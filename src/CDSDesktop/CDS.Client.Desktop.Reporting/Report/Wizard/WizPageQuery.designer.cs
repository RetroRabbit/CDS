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
    partial class WizPageQuery
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
            this.Query_memoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.Test_simpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnBuildQuery = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddParameter = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.headerPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Query_memoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Location = new System.Drawing.Point(15, 8);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLabel.Size = new System.Drawing.Size(308, 11);
            this.titleLabel.Text = "Query Setup";
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.Location = new System.Drawing.Point(31, 20);
            this.subtitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.subtitleLabel.Size = new System.Drawing.Size(292, 21);
            this.subtitleLabel.Text = "Enter your database query";
            // 
            // headerPanel
            // 
            this.headerPanel.Margin = new System.Windows.Forms.Padding(2);
            this.headerPanel.Size = new System.Drawing.Size(497, 47);
            // 
            // headerPicture
            // 
            this.headerPicture.Location = new System.Drawing.Point(456, 4);
            this.headerPicture.Margin = new System.Windows.Forms.Padding(2);
            this.headerPicture.Size = new System.Drawing.Size(37, 40);
            // 
            // headerSeparator
            // 
            this.headerSeparator.Location = new System.Drawing.Point(0, 47);
            this.headerSeparator.Margin = new System.Windows.Forms.Padding(2);
            this.headerSeparator.Padding = new System.Windows.Forms.Padding(2);
            this.headerSeparator.Size = new System.Drawing.Size(492, 2);
            // 
            // Query_memoEdit
            // 
            this.Query_memoEdit.EditValue = "";
            this.Query_memoEdit.Location = new System.Drawing.Point(12, 54);
            this.Query_memoEdit.Margin = new System.Windows.Forms.Padding(2);
            this.Query_memoEdit.Name = "Query_memoEdit";
            this.Query_memoEdit.Size = new System.Drawing.Size(471, 50);
            this.Query_memoEdit.TabIndex = 5;
            this.Query_memoEdit.EditValueChanged += new System.EventHandler(this.Query_memoEdit_EditValueChanged);
            // 
            // Test_simpleButton
            // 
            this.Test_simpleButton.Location = new System.Drawing.Point(12, 108);
            this.Test_simpleButton.Margin = new System.Windows.Forms.Padding(2);
            this.Test_simpleButton.Name = "Test_simpleButton";
            this.Test_simpleButton.Size = new System.Drawing.Size(75, 25);
            this.Test_simpleButton.TabIndex = 6;
            this.Test_simpleButton.Text = "&Apply";
            this.Test_simpleButton.Click += new System.EventHandler(this.Test_simpleButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 138);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(492, 162);
            this.dataGridView1.TabIndex = 7;
            // 
            // btnBuildQuery
            // 
            this.btnBuildQuery.Location = new System.Drawing.Point(93, 108);
            this.btnBuildQuery.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuildQuery.Name = "btnBuildQuery";
            this.btnBuildQuery.Size = new System.Drawing.Size(75, 25);
            this.btnBuildQuery.TabIndex = 8;
            this.btnBuildQuery.Text = "&Build";
            this.btnBuildQuery.Click += new System.EventHandler(this.btnBuildQuery_Click);
            // 
            // btnAddParameter
            // 
            this.btnAddParameter.Location = new System.Drawing.Point(382, 108);
            this.btnAddParameter.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddParameter.Name = "btnAddParameter";
            this.btnAddParameter.Size = new System.Drawing.Size(101, 25);
            this.btnAddParameter.TabIndex = 9;
            this.btnAddParameter.Text = "Define &Parameters";
            this.btnAddParameter.Click += new System.EventHandler(this.btnAddParameter_Click);
            // 
            // WizPageQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddParameter);
            this.Controls.Add(this.btnBuildQuery);
            this.Controls.Add(this.Query_memoEdit);
            this.Controls.Add(this.Test_simpleButton);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WizPageQuery";
            this.Size = new System.Drawing.Size(497, 303);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.Test_simpleButton, 0);
            this.Controls.SetChildIndex(this.Query_memoEdit, 0);
            this.Controls.SetChildIndex(this.btnBuildQuery, 0);
            this.Controls.SetChildIndex(this.headerPanel, 0);
            this.Controls.SetChildIndex(this.headerSeparator, 0);
            this.Controls.SetChildIndex(this.titleLabel, 0);
            this.Controls.SetChildIndex(this.subtitleLabel, 0);
            this.Controls.SetChildIndex(this.headerPicture, 0);
            this.Controls.SetChildIndex(this.btnAddParameter, 0);
            ((System.ComponentModel.ISupportInitialize)(this.headerPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Query_memoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit Query_memoEdit;
        private DevExpress.XtraEditors.SimpleButton Test_simpleButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevExpress.XtraEditors.SimpleButton btnBuildQuery;
        private DevExpress.XtraEditors.SimpleButton btnAddParameter;
    }
}