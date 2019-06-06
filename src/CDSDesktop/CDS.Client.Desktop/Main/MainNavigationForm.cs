using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using DevExpress.XtraEditors;
using System.Linq;
using System.Reflection;

namespace CDS.Client.Desktop.Main
{
    public partial class MainNavigationForm : CDS.Client.Desktop.Essential.BaseForm
    {
        int counter = 0;
        XElement element = null;
        XDocument doc = XDocument.Parse(CDS.Client.Desktop.Properties.Resources.MainNav);

        public MainNavigationForm()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            base.OnStart();
            AllowExport = false;
            AllowSave = false;
            AllowNavigateBackOnly = true;

            tileNavigation.AllowSelectedItem = true;
            //tileNavigation.AllowDrag = false;
            tileNavigation.ItemCheckMode = TileItemCheckMode.Single;
            element = doc.Element("Main");

            PopulateMainNav(element, 0);
        }

        protected override void OnPreviousRecord()
        {
            if (element == null || element.Equals(doc.Element("Main")))
                return;

            base.OnPreviousRecord();
            Int16 parent = Convert.ToInt16(element.Attribute("Parent").Value);

            element = element.Parent;
            PopulateMainNav(element, parent);
        }

        private void PopulateMainNav(XElement currentElement, Int16 parentId)
        {
            if (currentElement == null)
                return;



            if (currentElement.Elements().First().Name.LocalName.Equals("Screen"))
            {
                try
                {
                    String formNamespace = currentElement.Elements().First().Value;
                    if (formNamespace.Equals(String.Empty))
                        return;

                    ShowForm(formNamespace, currentElement.Attribute("Tag").Value, currentElement.Attribute("Color").Value);

                }
                catch (Exception ex)
                {
                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                }
            }
            else
            {
                IEnumerable<XElement> elements =
                   from el in currentElement.Elements()
                   where (string)el.Attribute("Parent") == parentId.ToString()
                   select el;

                if (elements.Count() != 0)
                    tileGroup.Items.Clear();

                foreach (var element in elements)
                {
                    Bitmap bmp = new Bitmap(
                    System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("CDS.Client.Desktop.Resources.Navigation." + element.Attribute("Image").Value + ".png"));

                    String[] colorRGB = element.Attribute("Color").Value.Split(',');
                    Color color = Color.FromArgb(Convert.ToInt16(colorRGB[0]), Convert.ToInt16(colorRGB[1]), Convert.ToInt16(colorRGB[2]));
                    String keycode = element.Elements().First().Name.LocalName.Equals("Screen") ? "" : String.Format("({0})", element.Elements().Count().ToString());
                    TileItem currentTile = CreateDashTile(element.Name.LocalName, String.Format("{0} {1}", element.Attribute("Tag").Value, keycode), element.Attribute("Key").Value, bmp, color, new DevExpress.XtraEditors.TileItemClickEventHandler(TileItem_ItemPress));
                    currentTile.Tag = element;

                    tileGroup.Items.Add(currentTile);
                }

                tileGroup.Items[0].Checked = true;
                tileNavigation.SelectedItem = tileGroup.Items[0];
            }
        }

        private void PopulateMainNav(XElement currentElement, char key)
        {
            if (currentElement == null)
                return;

            IEnumerable<XElement> elements =
                    from el in currentElement.Elements()
                    where (string)el.Attribute("Key") == key.ToString()
                    select el;

            if (elements.First().Elements().First().Name.LocalName.Equals("Screen"))
            {
                try
                {
                    String formNamespace = elements.First().Elements().First().Value;
                    if (formNamespace.Equals(String.Empty))
                        return;

                    ShowForm(formNamespace, currentElement.Attribute("Tag").Value, currentElement.Attribute("Color").Value);
                }
                catch (Exception ex)
                {
                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                }
            }
            else
            {



                if (elements.Count() != 0)
                {
                    tileGroup.Items.Clear();
                    element = elements.First();
                }

                foreach (var element in elements.Elements())
                {
                    Bitmap bmp = new Bitmap(
                    System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("CDS.Client.Desktop.Resources.Navigation." + element.Attribute("Image").Value + ".png"));

                    String[] colorRGB = element.Attribute("Color").Value.Split(',');
                    Color color = Color.FromArgb(Convert.ToInt16(colorRGB[0]), Convert.ToInt16(colorRGB[1]), Convert.ToInt16(colorRGB[2]));
                    String keycode = element.Elements().First().Name.LocalName.Equals("Screen") ? "" : String.Format("({0})", element.Elements().Count().ToString());
                    TileItem currentTile = CreateDashTile(element.Name.LocalName, String.Format("{0} {1}", element.Attribute("Tag").Value, keycode), element.Attribute("Key").Value, bmp, color, new DevExpress.XtraEditors.TileItemClickEventHandler(TileItem_ItemPress));
                    currentTile.Tag = element;

                    tileGroup.Items.Add(currentTile);
                }
                tileGroup.Items[0].Checked = true;

            }
        }
        //TODO : FIX THIS
        private void ShowForm(string formNamespace, string title, string colorstring)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetType(formNamespace);
            ConstructorInfo ci = type.GetConstructor(new Type[0]);
            DevExpress.XtraEditors.XtraForm frm = (DevExpress.XtraEditors.XtraForm)ci.Invoke(new Type[0]);
            //if (frm is CDS.Client.Desktop.Document.BaseDocument)
            //{
            //    string[] colorRGB = colorstring.Split(',');
            //    Color color = Color.FromArgb(Convert.ToInt16(colorRGB[0]), Convert.ToInt16(colorRGB[1]), Convert.ToInt16(colorRGB[2]));
            //    (frm as CDS.Client.Desktop.Document.BaseDocument).TabColor = color;
            //}
            frm.Text = title;

            using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
            {
                MainForm.Instance.ShowForm(frm);
            }

        }

        private void TileItem_ItemPress(object sender, TileItemEventArgs e)
        {
            TileItem currentTile = (TileItem)sender;
            XElement clickedElement = (XElement)currentTile.Tag;
            /*
           if (clickedElement.Elements().First().Name.LocalName.Equals("Screen"))
           {
               try
               {
                   if (clickedElement.Elements().First().Value.Equals(String.Empty))
                       return;

                   Assembly assembly = Assembly.GetExecutingAssembly();
                   Type type = assembly.GetType(clickedElement.Elements().First().Value);
                   ConstructorInfo ci = type.GetConstructor(new Type[0]);
                   Form frm = (Form)ci.Invoke(new Type[0]);

                   //frm.Show();
                   using (new UTL.WaitCursor())
                   {
                       MainForm.Instance.ShowForm(frm);
                   }
                   //Form frmConta = (Form)Activator.CreateInstance(element.Elements().First().Value, typeof(Form).Namespace).Unwrap();
               }
               catch (Exception ex)
               {
               }
           }
           else
           {
               
*/
            element = clickedElement;
            PopulateMainNav(element, Convert.ToInt16(element.Attribute("Id").Value));
            // }
        }

        public TileItem CreateDashTile(string name, string text, string key, Image image, Color color, DevExpress.XtraEditors.TileItemClickEventHandler eventHandler)
        {
            TileItem newTile = new TileItem();
            /*
            //First Frame - Image only
            TileItemFrame logoDXFrame = new TileItemFrame();
            logoDXFrame.UseImage = true;
            logoDXFrame.UseText = true;
            logoDXFrame.AnimateImage = true;
            logoDXFrame.AnimateText = true;
            TileItemElement logoEl = new TileItemElement();
            logoEl.Image = image; logoEl.ImageAlignment = TileItemContentAlignment.MiddleCenter;
            logoDXFrame.Elements.Add(logoEl);
            logoDXFrame.Elements[0].AnimateTransition = DevExpress.Utils.DefaultBoolean.True;
            //Second Frame - Text only
            TileItemFrame mottoDXFrame = new TileItemFrame();
            TileItemElement mottoEl = new TileItemElement();
            mottoEl.Text = "<Size=+2><Color=Sienna><b>" + text + "</b></Color></Size>";
            mottoEl.TextAlignment = TileItemContentAlignment.MiddleCenter;
            mottoDXFrame.Elements.Add(mottoEl);
            mottoDXFrame.Elements[0].AnimateTransition = DevExpress.Utils.DefaultBoolean.True;
            mottoDXFrame.UseImage = true;
            mottoDXFrame.UseText = true;
            mottoDXFrame.AnimateImage = true;
            mottoDXFrame.AnimateText = true;
            //Global Tile Item Settings
            newTile.Frames.Add(logoDXFrame);
            newTile.Frames.Add(mottoDXFrame);
            newTile.Appearance.BackColor = System.Drawing.Color.LightBlue;
            newTile.Appearance.BackColor2 = System.Drawing.Color.WhiteSmoke;
            newTile.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            newTile.Appearance.BorderColor = System.Drawing.Color.LightBlue;
            newTile.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            newTile.FrameAnimationInterval = 2500;
            newTile.IsLarge = false;*/

            DevExpress.XtraEditors.TileItemElement tileItemElementKey = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElementText = new DevExpress.XtraEditors.TileItemElement();

            tileItemElementKey.Appearance.Normal.BorderColor = Color.Transparent;
            tileItemElementKey.Text = key;
            tileItemElementKey.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;

            tileItemElementText.Image = image;
            tileItemElementText.ImageAlignment = TileItemContentAlignment.TopRight;
            tileItemElementText.ImageScaleMode = TileItemImageScaleMode.NoScale;
            tileItemElementText.Text = text;
            tileItemElementText.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft;

            newTile.AppearanceItem.Normal.BackColor = color;
            newTile.AppearanceItem.Normal.Options.UseBackColor = true;
            newTile.AppearanceItem.Normal.BorderColor = Color.Transparent;
            Color selectedColor = Color.FromArgb(color.R < 0 ? 0 : color.R, color.G < 0 ? 0 : color.G, color.B - 30 < 0 ? 0 : color.B - 30);
            newTile.AppearanceItem.Selected.BackColor = selectedColor;
            newTile.AppearanceItem.Selected.Options.UseBackColor = true;
            newTile.AppearanceItem.Selected.BorderColor = Color.Transparent;
            newTile.Elements.Add(tileItemElementKey);
            newTile.Elements.Add(tileItemElementText);

            newTile.Id = counter;
            newTile.Name = Name;

            newTile.ItemClick += eventHandler;
            newTile.CheckedChanged += new TileItemClickEventHandler(newTile_CheckedChanged);
            counter++;

            return newTile;
        }
        TileItem prevItem = null;
        void newTile_CheckedChanged(object sender, TileItemEventArgs e)
        {
            if (prevItem != null && prevItem != e.Item)
            {
                Color colorRange = e.Item.AppearanceItem.Normal.BackColor;
                tbcRed.Value = colorRange.R;
                tbcGreen.Value = colorRange.G;
                tbcBlue.Value = colorRange.B;

            }
            prevItem = e.Item;
        }

        private void MainNavigationForm_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void tileNavigation_KeyUp(object sender, KeyEventArgs e)
        {


            switch (e.KeyCode)
            {
                case Keys.F6: OnPreviousRecord();
                    break;
                case Keys.F8: PopulateMainNav(doc.Element("Main"), 0);
                    break;
            }

            switch (e.KeyData)
            {
                case Keys.D1:
                    PopulateMainNav(element, Keys.D1.ToString()[1]);
                    break;
                case Keys.D2:
                    PopulateMainNav(element, Keys.D2.ToString()[1]);
                    break;
                case Keys.D3:
                    PopulateMainNav(element, Keys.D3.ToString()[1]);
                    break;
                case Keys.D4:
                    PopulateMainNav(element, Keys.D4.ToString()[1]);
                    break;
                case Keys.D5:
                    PopulateMainNav(element, Keys.D5.ToString()[1]);
                    break;
                case Keys.D6:
                    PopulateMainNav(element, Keys.D6.ToString()[1]);
                    break;
                case Keys.D7:
                    PopulateMainNav(element, Keys.D7.ToString()[1]);
                    break;
                case Keys.D8:
                    PopulateMainNav(element, Keys.D8.ToString()[1]);
                    break;
                case Keys.D9:
                    PopulateMainNav(element, Keys.D9.ToString()[1]);
                    break;
                case Keys.NumPad1:
                    PopulateMainNav(element, Keys.NumPad1.ToString()[6]);
                    break;
                case Keys.NumPad2:
                    PopulateMainNav(element, Keys.NumPad2.ToString()[6]);
                    break;
                case Keys.NumPad3:
                    PopulateMainNav(element, Keys.NumPad3.ToString()[6]);
                    break;
                case Keys.NumPad4:
                    PopulateMainNav(element, Keys.NumPad4.ToString()[6]);
                    break;
                case Keys.NumPad5:
                    PopulateMainNav(element, Keys.NumPad5.ToString()[6]);
                    break;
                case Keys.NumPad6:
                    PopulateMainNav(element, Keys.NumPad6.ToString()[6]);
                    break;
                case Keys.NumPad7:
                    PopulateMainNav(element, Keys.NumPad7.ToString()[6]);
                    break;
                case Keys.NumPad8:
                    PopulateMainNav(element, Keys.NumPad8.ToString()[6]);
                    break;
                case Keys.NumPad9:
                    PopulateMainNav(element, Keys.NumPad9.ToString()[6]);
                    break;

            }

        }

        private void tileNavigation_SelectedItemChanged(object sender, TileItemEventArgs e)
        {
            e.Item.Checked = true;
        }

        private void txtColor_EditValueChanged(object sender, EventArgs e)
        {
            Color rangeColor = Color.FromArgb(tbcRed.Value, tbcGreen.Value, tbcBlue.Value);
            if (tileNavigation.SelectedItem != null)
            {
                tileNavigation.SelectedItem.AppearanceItem.Normal.BackColor = rangeColor;
                Color selectedColor = Color.FromArgb(rangeColor.R < 0 ? 0 : rangeColor.R, rangeColor.G < 0 ? 0 : rangeColor.G, rangeColor.B - 30 < 0 ? 0 : rangeColor.B - 30);
                tileNavigation.SelectedItem.AppearanceItem.Selected.BackColor = selectedColor;
            }
        }

        private void tbcRed_ValueChanged(object sender, EventArgs e)
        {
            txtColor.Text = String.Format("{0},{1},{2}", tbcRed.Value.ToString(), tbcGreen.Value.ToString(), tbcBlue.Value.ToString());
        }


    }
}//2013/07/18

