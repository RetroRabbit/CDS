using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CDS.Client.Desktop.Catalogue.CAT
{
    public partial class ViewImageDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        public Image Image { get; set; }

        public ViewImageDialogue()
        {
            InitializeComponent();
        }

        private void ViewImageDialogue_Load(object sender, EventArgs e)
        {
            peImage.Image = Image;
        }
    }
}
