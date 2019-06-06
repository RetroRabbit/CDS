using DevExpress.XtraEditors;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Core.Backup
{
    public partial class BackupDialogue : CDS.Client.Desktop.Essential.BaseDialogue
    {
        private Server server;
        public BackupDialogue()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            base.OnStart();
            server = new Server(new ServerConnection(BL.ApplicationDataContext.Instance.SqlConnectionString));

            if (BL.ApplicationDataContext.Instance.CompanySite.BackupLocation != null && BL.ApplicationDataContext.Instance.CompanySite.BackupLocation.Contains("\\"))
            {
                var location = BL.ApplicationDataContext.Instance.CompanySite.BackupLocation.Split('\\')[0];

                if(server.EnumDirectories(location).Rows.Count > 0)
                    bceServerPath.Path = BL.ApplicationDataContext.Instance.CompanySite.BackupLocation;
            }

            DataTable tblRoot = server.EnumAvailableMedia();
            //bceServerPath.Path = tblRoot.Rows[0][0].ToString();
            
            foreach (DataRow driveInfo in tblRoot.Rows)
            {
                bceServerPath.Properties.History.Add(new BreadCrumbHistoryItem(driveInfo[0].ToString()));
            } 
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            using (new Essential.UTL.WaitCursor())
            {
                Task<int> t = DataContext.EntitySystemContext.Database.ExecuteSqlCommandAsync(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, string.Format(@"BACKUP DATABASE [{1}] TO  DISK = N'{0}\{1}{2}.bak' WITH NOFORMAT, NOINIT,  NAME = N'cds_pegasus-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10;", bceServerPath.Path, DataContext.EntitySystemContext.Database.Connection.Database,BL.ApplicationDataContext.Instance.ServerDateTime.ToString("_yyyy_MM_dd_HH_mm_ss")), new object[] { });
                //int t = DataContext.EntitySystemContext.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, string.Format(@"BACKUP DATABASE [cds_pegasus] TO  DISK = N'{0}\{1}.bak' WITH NOFORMAT, NOINIT,  NAME = N'cds_pegasus-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10;", bceServerPath.Path, BL.ApplicationDataContext.Instance.ServerDateTime.ToString(DataContext.EntitySystemContext.Database.Connection.DataSource + "_yyyy_mm_dd_HH_mm_ss")), new object[] { });

                this.Invoke(new Action(() =>
                {
                    while (!t.IsCompleted)
                    {

                        decimal progress = Convert.ToDecimal(DataContext.ReadonlyContext.Database.SqlQuery(typeof(decimal), string.Format(@"SELECT percent_complete FROM sys.dm_exec_requests r CROSS APPLY sys.dm_exec_sql_text(r.sql_handle) a WHERE r.command in ('BACKUP DATABASE')"), new object[] { }).GetEnumerator().Current);
                        System.Threading.Thread.Sleep(1000);
                        btnOk.Text = string.Format("OK ({0}/100)", progress);
                    }
                    btnOk.Text = string.Format("OK (100/100)");
                    Essential.BaseAlert.ShowAlert("Backup", "Backup Complete", Essential.BaseAlert.Buttons.Ok, Essential.BaseAlert.Icons.Information);
                    this.Close();
                }));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bceServerPath_Properties_NewNodeAdding(object sender, DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventArgs e)
        {
            e.Node.PopulateOnDemand = true;
        }

        private void bceServerPath_Properties_QueryChildNodes(object sender, BreadCrumbQueryChildNodesEventArgs e)
        {
            DataTable tblDirectories = server.EnumDirectories(bceServerPath.Path);
            foreach (DataRow driveInfo in tblDirectories.Rows)
            {
                e.Node.ChildNodes.Add(new BreadCrumbNode(driveInfo[0].ToString(), driveInfo[0].ToString(), true));
            }         
        }
    }
}
