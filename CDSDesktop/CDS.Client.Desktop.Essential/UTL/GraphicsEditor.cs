using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using System.ComponentModel;
using System.Drawing;
 
/// http://www.devexpress.com/Support/Center/p/E3025.aspx
///  how to customize the default PictureEdit editor so that it can accept a path to a graphic file as an EditValue and display a corresponding image.
namespace CDS.Client.Desktop.Essential.UTL
{
    //The attribute that points to the registration method 
    [UserRepositoryItem("RegisterGraphicsEditor")]
    public class RepositoryItemGraphicsEdit : RepositoryItemPictureEdit
    {
        // Static constructor should call registration method
        static RepositoryItemGraphicsEdit() { RegisterGraphicsEditor(); }

        public const string GraphicsEditorName = "GraphicsEdit";
        public override string EditorTypeName { get { return GraphicsEditorName; } }

        public static void RegisterGraphicsEditor()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(
                GraphicsEditorName, typeof(GraphicsEdit), typeof(RepositoryItemGraphicsEdit),
                typeof(GraphicsEditViewInfo), new PictureEditPainter(), true));
        }
    }


    public class GraphicsEdit : PictureEdit
    {
        static GraphicsEdit() { RepositoryItemGraphicsEdit.RegisterGraphicsEditor(); }

        public override string EditorTypeName { get { return RepositoryItemGraphicsEdit.GraphicsEditorName; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemGraphicsEdit Properties
        { get { return base.Properties as RepositoryItemGraphicsEdit; } }

        protected override DevExpress.XtraEditors.Controls.PictureMenu Menu { get { return null; } }
    }

    class GraphicsEditViewInfo : PictureEditViewInfo
    {
        public GraphicsEditViewInfo(RepositoryItem item) : base(item) { }

        public override object EditValue
        {
            get
            {
                return base.EditValue;
            }
            set
            {
                if (value != null && value.GetType() == typeof(System.String))
                {
                    try { if (System.IO.File.Exists(value.ToString())) base.EditValue = new Bitmap(value.ToString()); else base.EditValue = null; }
                    catch { base.EditValue = Item.ErrorImage; }
                }
                else
                    base.EditValue = value;
            }
        }
    }
}
