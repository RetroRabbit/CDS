using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CDS.Client.Desktop.Main
{
    public partial class RecoveryDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        List<RecoveryItem> recoveryItems = new List<RecoveryItem>();

        public RecoveryDialogue()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            try
            {
                base.OnStart();
                BindingSource.DataSource = recoveryItems;

                foreach (string item in System.IO.Directory.EnumerateFileSystemEntries(Environment.CurrentDirectory + @"\Recovery"))
                {
                    try
                    {
                        List<BindingSource> bindingSources = new List<BindingSource>();
               
                        int lineCount = 0;
                        string description = string.Empty;
                        string assemblyName = string.Empty;
                        foreach (string line in System.IO.File.ReadLines(item))
                        {
                            //Skip blank lines
                            if (line == string.Empty)
                                continue;

                            switch (lineCount)
                            {
                                //First line should hav the Form Assembly Name
                                case 0:
                                    assemblyName = line;
                                    lineCount++;
                                    continue;
                                //Second line should hafe the Forms Namespace
                                case 1:
                                     description = line;
                                    lineCount++;
                                    continue;
                            }
                             

                            if (line == string.Empty)
                                continue;

                            var dassembly = System.Reflection.Assembly.Load("CDS.Client.DataAccessLayer");
                            Type dtype;
                            if (line.Split('|')[0].StartsWith("System.Collections.Generic.List"))
                            {
                                dtype = typeof(List<>);
                                Type typeArg = dassembly.GetType(line.Split('|')[0].Split(new char[] { '[', ']' })[1]);
                                dtype = dtype.MakeGenericType(typeArg);
                                var bs = new System.Windows.Forms.BindingSource();
                                bs.DataSource = Newtonsoft.Json.JsonConvert.DeserializeObject(line.Split('|')[1], dtype);
                                //bs.DataSource = (System.Collections.IList)Activator.CreateInstance(dtype);
                                bindingSources.Add(bs);
                                //bindingSources.AddRange(Newtonsoft.Json.JsonConvert.DeserializeObject(line.Split('|')[1], dtype));
                                //System.Collections.IList list = (System.Collections.IList)Activator.CreateInstance(dtype);
                            }
                            else
                            {
                                dtype = dassembly.GetType(line.Split('|')[0], true);
                                var bs = new System.Windows.Forms.BindingSource();
                                //bs.DataSource = ((System.Collections.IList)Newtonsoft.Json.JsonConvert.DeserializeObject(line.Split('|')[1], (typeof(System.Collections.Generic.List<>)).MakeGenericType(dtype)))[0];
                                //Werner : Try this on monday (2014-10-17)
                                bs.DataSource = Newtonsoft.Json.JsonConvert.DeserializeObject(line.Split('|')[1], dtype);
                                bindingSources.Add(bs);
                            }



                        }

                        if (assemblyName == string.Empty)
                            continue;

                        //item.Split(',')[1]
                        var assembly = System.Reflection.Assembly.Load(assemblyName);
                        var type = assembly.GetType(item.Split(',')[1], true);

                        Essential.BaseForm form = Activator.CreateInstance(type) as Essential.BaseForm;
                        recoveryItems.Add(new RecoveryItem() { Recover = false, Description = description, BindingSources = bindingSources, Form = form });

                    }
                    catch (Exception ex)
                    {

                    }

                    //List<BindingSource> BindingSources = item.Split('/n');


                    // BindingSource.Add(new RecoveryItem() { Recover = false, Description = "", BindingSources = bindingSources });
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        private void ClearFiles()
        {
            foreach (FileInfo file in (new System.IO.DirectoryInfo(Environment.CurrentDirectory + @"\Recovery")).GetFiles())
            {
                file.Delete();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            ClearFiles();
        } 

        private void btnOk_Click(object sender, EventArgs e)
        {
            foreach (RecoveryItem item in (BindingSource.DataSource as List<RecoveryItem>).Where(n => n.Recover))
            {
                item.Form.Recover(item.BindingSources);
                ShowForm(item.Form);
            } 
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (recoveryItems.Count == 0)
                this.Close();
        }

        public class RecoveryItem
        {
            public bool Recover { get; set; }
            public string Description { get; set; }
            public List<BindingSource> BindingSources { get; set; }
            public Essential.BaseForm Form { get; set; }
        }
    }
}
