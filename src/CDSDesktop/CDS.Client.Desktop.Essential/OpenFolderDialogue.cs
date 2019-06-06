using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CDS.Client.Desktop.Essential
{
    public partial class OpenFolderDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        public string FolderLocation { get; set; }
        List<Directory> directoryList = new List<Directory>();

        public OpenFolderDialogue()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            try
            {
                base.OnStart();

                string[] drives = System.Environment.GetLogicalDrives();

                for (int i = 0; i < drives.Length; i++)
                {
                    if (!new DirectoryInfo(drives[i]).Exists)
                        continue;

                    var rootDirectoryInfo = new DirectoryInfo(drives[i]);
                    Directory rootDirectory = new Directory { Id = (i + 1).ToString(), ParentId = null, Name = drives[i], DirectoryInfo = new DirectoryInfo(drives[i]) };
                    directoryList.Add(rootDirectory);

                    var directory = (new DirectoryInfo(drives[i])).GetDirectories();
                    for (int j = 0; j < directory.Length; j++)
                    {
                        if (directory[j].Name.StartsWith("$") || directory[j].Name.StartsWith("."))
                            continue;

                        Directory childDirectory = new Directory { Id = ((i + 1).ToString() + j.ToString()), ParentId = rootDirectory.Id, Name = directory[j].Name, DirectoryInfo = directory[j] };
                        directoryList.Add(childDirectory);
                    }
                }
                BindingSource.DataSource = directoryList;
                //tlFolders.Refresh();
            }
            catch (Exception ex)
            {
 
            }
        }
         
        private void ListDirectory(string path, int position)
        {
            //tlFolders.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            Directory rootDirectory = new Directory { Id = position.ToString(), ParentId = null, Name = path, DirectoryInfo = rootDirectoryInfo };
            directoryList.Add(CreateDirectoryNode(rootDirectoryInfo,rootDirectory));
        }

        private Directory CreateDirectoryNode(DirectoryInfo directoryInfo, Directory rootDirectory)
        {
            Directory folder = new Directory() { ParentId = rootDirectory.Id, Name = directoryInfo.Name };
            var directory = directoryInfo.GetDirectories();
            for (int i = 0; i < directory.Length; i++)
            {
                folder.Id = (rootDirectory.Id.ToString() + (i+1).ToString());
                directoryList.Add(CreateDirectoryNode(directory[i], folder));
            } 
            return folder;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FolderLocation = string.Empty;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Directory selectedFolder = (Directory)tlFolders.GetDataRecordByNode(tlFolders.FocusedNode);
            FolderLocation = selectedFolder.DirectoryInfo.FullName;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void tlFolders_BeforeExpand(object sender, DevExpress.XtraTreeList.BeforeExpandEventArgs e)
        {
            try
            {
                Directory selectedFolder = (Directory)tlFolders.GetDataRecordByNode(e.Node);

                if (selectedFolder.Expanded)
                    return;

                selectedFolder.Expanded = true;

                for (int i = 0; i < e.Node.Nodes.Count; i++)
                {
                    Directory subFolder = (Directory)tlFolders.GetDataRecordByNode(e.Node.Nodes[i]);

                    DirectoryInfo[] directory = null;
                    try
                    {
                        directory = subFolder.DirectoryInfo.GetDirectories();
                    }
                    catch
                    {
                        e.Node.Nodes[i].Visible = false;
                    }

                    if (directory == null)
                        continue;

                    for (int j = 0; j < directory.Length; j++)
                    {
                        if (directory[j].Name.StartsWith("$") || directory[j].Name.StartsWith("."))
                            continue;

                        Directory childDirectory = new Directory { Id = (subFolder.Id.ToString() + "_"+ (j+1).ToString()), ParentId = subFolder.Id, Name = directory[j].Name, DirectoryInfo = directory[j] };
                        directoryList.Add(childDirectory);
                    }
                }
                tlFolders.RefreshDataSource();
                e.Node.Expanded = true;
                //tlFolders.RefreshNode(e.Node);
            }
            catch (Exception ex)
            {
                DataTable asdas = ConvertListToDataTable(directoryList);

                DataView ddddd = asdas.AsDataView();
                ddddd.RowFilter = "Column1 = 410";
            }


        }

        private static DataTable ConvertListToDataTable(List<Directory> list)
        {
            // New table.
            DataTable table = new DataTable(); 
            // Add columns.
            for (int i = 0; i < 5; i++)
            {
                table.Columns.Add();
            }

            // Add rows.
            foreach (var array in list)
            {
                table.Rows.Add(new object[] { array.Id, array.ParentId, array.Name, array.DirectoryInfo.Name, array.Expanded });
            }

            return table;
        }

        public class Directory
        {
            public String Id { get; set; }
            public String ParentId { get; set; }
            public String Name { get; set; }
            public DirectoryInfo DirectoryInfo { get; set; }
            public bool Expanded { get; set; }
        }
    }
}
