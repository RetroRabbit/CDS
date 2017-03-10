using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Core.Message
{
    public partial class MessageList : CDS.Client.Desktop.Essential.BaseListEdit2
    {
        public MessageList()
        {
            InitializeComponent();
        } 

        protected override void OnStart()
        {
            base.OnStart();
            ReadonlyColumns.Add(colShortName);
        }

        protected override void BindData()
        {
            base.BindData();
            BindingSource.DataSource = DataContext.EntitySystemContext.SYS_Entity.Where(n => n.TypeId == (byte)BL.SYS.SYS_Type.Message).ToList();
        }

        protected override bool AllowEdit()
        {
            //return base.IsNew();
            return (DataContext.EntitySystemContext.GetEntityState(GridView.GetFocusedRow() as DB.SYS_Entity) != System.Data.Entity.EntityState.Added
                && DataContext.EntitySystemContext.GetEntityState(GridView.GetFocusedRow() as DB.SYS_Entity) != System.Data.Entity.EntityState.Detached)
                && !ReadonlyColumns.Contains(GridView.FocusedColumn);
        }

        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();
                BindingSource.Add(BL.SYS.SYS_Entity.NewMessage);
            }
            catch (Exception ex)
            {
                HasErrors = true;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void OnSaveRecord()
        {
            using (new Essential.UTL.WaitCursor())
            {
                try
                {
                    base.OnSaveRecord();
                    using (TransactionScope transaction = DataContext.GetTransactionScope())
                    {
                        ((List<DB.SYS_Entity>)BindingSource.DataSource).ForEach(n => { n.Name = n.ShortName; BL.EntityController.SaveSYS_Entity(n, DataContext); });
                        DataContext.SaveChangesEntitySystemContext();
                        DataContext.CompleteTransaction(transaction);
                    }
                    DataContext.EntitySystemContext.AcceptAllChanges();
                    DataContext.EntityAccountingContext.AcceptAllChanges();
                    EditableRows.Clear();
                }
                catch (Exception ex)
                {
                    DataContext.EntitySystemContext.RejectChanges();
                    DataContext.EntityAccountingContext.RejectChanges();
                    HasErrors = true;
                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                }
            }
        }

        protected override void OnUndo()
        {
            try
            {
                layoutControl1.Validate();
                base.OnUndo();
                
                if (DataContext.EntitySystemContext.GetEntityState(GridView.GetFocusedRow()) == System.Data.Entity.EntityState.Modified &&                    
                    Essential.BaseAlert.ShowAlert("Undo Changes", "You are about to restore the selected line to it original values.\nDo you want to continue ?", Essential.BaseAlert.Buttons.OkCancel, Essential.BaseAlert.Icons.Question) == System.Windows.Forms.DialogResult.OK)
                    DataContext.EntitySystemContext.Entry(GridView.GetFocusedRow()).Reload();
            }
            catch (Exception ex)
            {
                HasErrors = true;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
        }
    }
}
