namespace CDS.Client.Desktop.Main
{
    partial class MainNavigationForm
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
            this.tileNavigation = new DevExpress.XtraEditors.TileControl();
            this.tileGroup = new DevExpress.XtraEditors.TileGroup();
            this.itmMainNav = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tbcRed = new DevExpress.XtraEditors.TrackBarControl();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tbcGreen = new DevExpress.XtraEditors.TrackBarControl();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tbcBlue = new DevExpress.XtraEditors.TrackBarControl();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtColor = new DevExpress.XtraEditors.TextEdit();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).BeginInit();
            this.LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMainNav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcRed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcGreen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcBlue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutControl
            // 
            this.LayoutControl.Controls.Add(this.txtColor);
            this.LayoutControl.Controls.Add(this.tbcBlue);
            this.LayoutControl.Controls.Add(this.tbcGreen);
            this.LayoutControl.Controls.Add(this.tbcRed);
            this.LayoutControl.Controls.Add(this.tileNavigation);
            this.LayoutControl.Size = new System.Drawing.Size(778, 414);
            // 
            // LayoutGroup
            // 
            this.LayoutGroup.AppearanceGroup.BackColor = System.Drawing.Color.Transparent;
            this.LayoutGroup.AppearanceGroup.Options.UseBackColor = true;
            this.LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.itmMainNav,
            this.layoutControlGroup1});
            this.LayoutGroup.Size = new System.Drawing.Size(778, 414);
            // 
            // RibbonControl
            // 
            this.RibbonControl.ExpandCollapseItem.Id = 0;
            this.RibbonControl.Size = new System.Drawing.Size(778, 142);
            // 
            // tileNavigation
            // 
            this.tileNavigation.BackColor = System.Drawing.Color.Transparent;
            this.tileNavigation.Groups.Add(this.tileGroup);
            this.tileNavigation.Location = new System.Drawing.Point(12, 202);
            this.tileNavigation.MaxId = 9;
            this.tileNavigation.Name = "tileNavigation";
            this.tileNavigation.Size = new System.Drawing.Size(754, 200);
            this.tileNavigation.TabIndex = 4;
            this.tileNavigation.Text = "tileControl1";
            this.tileNavigation.SelectedItemChanged += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileNavigation_SelectedItemChanged);
            this.tileNavigation.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tileNavigation_KeyUp);
            // 
            // tileGroup
            // 
            this.tileGroup.Name = "tileGroup";
            this.tileGroup.Text = "Main Tile Group";
            // 
            // itmMainNav
            // 
            this.itmMainNav.Control = this.tileNavigation;
            this.itmMainNav.CustomizationFormText = "itmMainNav";
            this.itmMainNav.Location = new System.Drawing.Point(0, 190);
            this.itmMainNav.Name = "itmMainNav";
            this.itmMainNav.Size = new System.Drawing.Size(758, 204);
            this.itmMainNav.Text = "itmMainNav";
            this.itmMainNav.TextSize = new System.Drawing.Size(0, 0);
            this.itmMainNav.TextToControlDistance = 0;
            this.itmMainNav.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(440, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(294, 147);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(758, 190);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.tbcRed;
            this.layoutControlItem1.CustomizationFormText = "Red";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(146, 49);
            this.layoutControlItem1.Text = "Red";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(29, 13);
            // 
            // tbcRed
            // 
            this.tbcRed.EditValue = null;
            this.tbcRed.Location = new System.Drawing.Point(57, 43);
            this.tbcRed.MenuManager = this.RibbonControl;
            this.tbcRed.Name = "tbcRed";
            this.tbcRed.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.tbcRed.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tbcRed.Properties.Maximum = 255;
            this.tbcRed.Size = new System.Drawing.Size(109, 45);
            this.tbcRed.StyleController = this.LayoutControl;
            this.tbcRed.TabIndex = 5;
            this.tbcRed.ValueChanged += new System.EventHandler(this.tbcRed_ValueChanged);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.tbcGreen;
            this.layoutControlItem2.CustomizationFormText = "Green";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 49);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(146, 49);
            this.layoutControlItem2.Text = "Green";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(29, 13);
            // 
            // tbcGreen
            // 
            this.tbcGreen.EditValue = null;
            this.tbcGreen.Location = new System.Drawing.Point(57, 92);
            this.tbcGreen.MenuManager = this.RibbonControl;
            this.tbcGreen.Name = "tbcGreen";
            this.tbcGreen.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.tbcGreen.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tbcGreen.Properties.Maximum = 255;
            this.tbcGreen.Size = new System.Drawing.Size(109, 45);
            this.tbcGreen.StyleController = this.LayoutControl;
            this.tbcGreen.TabIndex = 6;
            this.tbcGreen.ValueChanged += new System.EventHandler(this.tbcRed_ValueChanged);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.tbcBlue;
            this.layoutControlItem3.CustomizationFormText = "Blue";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 98);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(146, 49);
            this.layoutControlItem3.Text = "Blue";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(29, 13);
            // 
            // tbcBlue
            // 
            this.tbcBlue.EditValue = null;
            this.tbcBlue.Location = new System.Drawing.Point(57, 141);
            this.tbcBlue.MenuManager = this.RibbonControl;
            this.tbcBlue.Name = "tbcBlue";
            this.tbcBlue.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.tbcBlue.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tbcBlue.Properties.Maximum = 255;
            this.tbcBlue.Size = new System.Drawing.Size(109, 45);
            this.tbcBlue.StyleController = this.LayoutControl;
            this.tbcBlue.TabIndex = 7;
            this.tbcBlue.ValueChanged += new System.EventHandler(this.tbcRed_ValueChanged);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtColor;
            this.layoutControlItem4.CustomizationFormText = "Color";
            this.layoutControlItem4.Location = new System.Drawing.Point(146, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(294, 24);
            this.layoutControlItem4.Text = "Color";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(29, 13);
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(203, 43);
            this.txtColor.MenuManager = this.RibbonControl;
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(257, 20);
            this.txtColor.StyleController = this.LayoutControl;
            this.txtColor.TabIndex = 8;
            this.txtColor.EditValueChanged += new System.EventHandler(this.txtColor_EditValueChanged);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(146, 24);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(294, 123);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // MainNavigationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(790, 568);
            this.ControlBox = false;
            this.Name = "MainNavigationForm";
            this.Text = "Main Menu";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainNavigationForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutControl)).EndInit();
            this.LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itmMainNav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcRed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcGreen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcBlue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TileControl tileNavigation;
        private DevExpress.XtraLayout.LayoutControlItem itmMainNav;
        private DevExpress.XtraEditors.TileGroup tileGroup;
        private DevExpress.XtraEditors.TextEdit txtColor;
        private DevExpress.XtraEditors.TrackBarControl tbcBlue;
        private DevExpress.XtraEditors.TrackBarControl tbcGreen;
        private DevExpress.XtraEditors.TrackBarControl tbcRed;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}
