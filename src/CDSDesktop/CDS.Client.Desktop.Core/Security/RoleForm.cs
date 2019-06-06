using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Windows.Forms;
using CDS.Client.Desktop.Essential;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Nodes.Operations;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using SECL = CDS.Client.BusinessLayer.SEC;


namespace CDS.Client.Desktop.Core.Security
{
    public partial class RoleForm : CDS.Client.Desktop.Essential.BaseForm
    {
        private List<Int32> autoCheckParentList;
        private DB.SEC_Role secRole;

        private bool AccessHasChanged = false;

        public RoleForm()
        {
            InitializeComponent();
        }

        public RoleForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        protected override void OnStart()
        {
            try
            {
                base.OnStart();
                ServerModeSourceCreatedBy.QueryableSource = DataContext.EntitySystemContext.SYS_Person; 
                BindingSourceAccess.DataSource = DataContext.EntitySecurityContext.SEC_Access.ToList();
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void BindData()
        {
            base.BindData();
            try
            {
                BindingSource.DataSource = secRole;
                if (BindingSource.DataSource != null)
                {
                    grdAccess.UncheckAll();
                    foreach (DB.SEC_RoleAccess ra in (BindingSource.DataSource as DB.SEC_Role).SEC_RoleAccess)
                    {
                        //if (ra.SEC_Access.SEC_Access_Children.Count == 0)
                            GetNodeByRoleAccessId(ra.AccessId).CheckState = CheckState.Checked;
                    }


                   //foreach (DB.SEC_RoleAccess ra in ((BindingSource.DataSource as DB.SEC_Role).SEC_RoleAccess).Where(n=>n.SEC_Access.SEC_Access_Children.Count == 0))
                   //{
                   //    var node = GetNodeByRoleAccessId(ra.AccessId);
                   //
                   //    if (node.CheckState == CheckState.Checked || node.CheckState == CheckState.Indeterminate)
                   //        CheckParent(node);
                   //}

                    // Get all users that have been assigned this role
                    List<Int64> userids = DataContext.EntitySecurityContext.SEC_UserRole.Where(m => m.RoleId == secRole.Id).Select(n => n.UserId).ToList();
                    ServerModeSourceUser.QueryableSource = DataContext.EntitySecurityContext.SEC_User.Where(n => userids.Contains(n.Id));
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        void CheckParent(TreeListNode node)
        {

            if (node.HasChildren)
            {
                var item = (grdAccess.GetDataRecordByNode(node) as DB.SEC_Access).Code;

                if (node.Nodes.Count == node.Nodes.Count(n => n.CheckState == CheckState.Checked))
                {
                    node.CheckState = CheckState.Checked;
                }
                else if (node.Nodes.Count(n => n.CheckState == CheckState.Checked) > 0)
                {
                    node.CheckState = CheckState.Indeterminate;
                }
                else if (node.Nodes.Count(n => n.CheckState == CheckState.Indeterminate) > 0)
                {
                    node.CheckState = CheckState.Indeterminate;
                }
            }

            if (node.ParentNode != null)
                CheckParent(node.ParentNode);             
        }

        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();
                secRole = BL.SEC.SEC_Role.New;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        public override void OpenRecord(Int64 Id)
        {
            try
            {
                secRole = BL.SEC.SEC_Role.Load(Id, DataContext, new List<String>() { "SEC_RoleAccess" });
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override bool SaveSuccessful()
        {
            try
            {
                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    this.OnSaveRecord(); 
                    if (!IsValid)
                        return false; 
                    //Get all the selected nodes
                    List<DB.SEC_Access> accesses = GetAllSelectedAccess();
                    List<DB.SEC_RoleAccess> current = secRole.SEC_RoleAccess.ToList();
                    // Add the accesses that are in the chekced nodes and not yet in the role
                    List<Int64> accessidsrequired = accesses.Where(n => !current.Select(m => m.AccessId).Contains(n.Id)).Select(n => n.Id).ToList();
                    foreach (Int64 id in accessidsrequired)
                    {
                        DB.SEC_RoleAccess roleacc = BL.SEC.SEC_RoleAccess.New;
                        roleacc.AccessId = id;
                        roleacc.RoleId = secRole.Id;
                        secRole.SEC_RoleAccess.Add(roleacc);
                    }
                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            BL.EntityController.SaveSEC_Role(secRole, DataContext);
                            DataContext.EntitySecurityContext.SaveChanges();

                            if (AccessHasChanged)
                            {
                                // Remove the accesses that are on the role and not in the checked nodes.
                                List<DB.SEC_RoleAccess> accessidsdeleted = current.Where(n => !accesses.Select(m => m.Id).Contains(n.AccessId)).ToList();

                                foreach (DB.SEC_RoleAccess ra in accessidsdeleted)
                                {
                                    BL.SEC.SEC_RoleAccess.DeleteRoleAccess(ra, DataContext);
                                }
                                //TODO : Remove this when log system is added
                                BL.SEC.SEC_Role.UpdateAccessModifiedFlags(secRole);
                            }
                            DataContext.EntitySecurityContext.SaveChanges();
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntitySecurityContext.AcceptAllChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntitySecurityContext.RejectChanges();
                        HasErrors = true;
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                HasErrors = true;
                CurrentException = ex;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        protected override void OnSaveRecord()
        {
            base.OnSaveRecord();

            IsValid = ValidateBeforeSave();
        }

        /// <summary>
        /// Loads and opens the next Role record. The current record is not saved.
        /// </summary>
        /// <remarks>Created: Theo Crous 23/07/2012</remarks>
        protected override void OnNextRecord()
        {
            try
            {
                base.OnNextRecord();

                DB.SEC_Role secRole = BL.SEC.SEC_Role.GetNextItem((DB.SEC_Role)BindingSource.DataSource, DataContext);
                if (secRole != null)
                {
                    BindingSource.DataSource = secRole;
                    BindData();
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Loads and opens the previous Role record. The current record is not saved.
        /// </summary>
        /// <remarks>Created: Theo Crous 23/07/2012</remarks>
        protected override void OnPreviousRecord()
        {
            try
            {
                base.OnPreviousRecord();


                DB.SEC_Role secRole = BL.SEC.SEC_Role.GetPreviousItem((DB.SEC_Role)BindingSource.DataSource, DataContext);
                if (secRole != null)
                {
                    BindingSource.DataSource = secRole;
                    BindData();
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowSave = SECL.SecurityLibrary.AccessGranted(BL.SEC.AccessCodes.SYSERLREED)
                     || SECL.SecurityLibrary.AccessGranted(BL.SEC.AccessCodes.SYSERLRECR); 
        }

        private bool ValidateBeforeSave()
        {
            try
            {
                if (!IsValid)
                    return IsValid;
                 bool isValid = true;
                 isValid = IsCodeValid();
                 return isValid; 
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        /// <summary>
        /// Checks if Code exists.
        /// </summary>
        /// <returns>Boolean values indicating weather conditions have been met.</returns>
        /// <remarks>Created: Werner Scheffer 23/05/2012</remarks>
        private bool IsCodeValid()
        {
            try
            {
                bool isValid = true;
                isValid = !DataContext.EntitySecurityContext.SEC_Role.Any(n => n.Id != ((DB.SEC_Role)BindingSource.DataSource).Id && n.Code == ((DB.SEC_Role)BindingSource.DataSource).Code);
                if (!isValid)
                    BaseAlert.ShowAlert("Invalid Code", "The code you have entered already exists enter another Code.", BaseAlert.Buttons.Ok, BaseAlert.Icons.Error);

                return isValid;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }
         
        private List<DB.SEC_Access> GetAllSelectedAccess()
        {
            try
            {
                //Call the operation:
                GetCheckedNodesOperation op = new GetCheckedNodesOperation();
                grdAccess.NodesIterator.DoOperation(op);

                return op.CheckedAccessess;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return null;
            }
        }

        private TreeListNode GetNodeByRoleAccessId(Int64 id)
        {
            try
            {
                FindNodesOperation op = new FindNodesOperation(id);
                grdAccess.NodesIterator.DoOperation(op);
                return op.Node;
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return null;
            }
        }

        //The operation class that collects checked nodes
        private class GetCheckedNodesOperation : TreeListOperation
        {
            public List<TreeListNode> CheckedNodes = new List<TreeListNode>();
            public List<DB.SEC_Access> CheckedAccessess = new List<DB.SEC_Access>();

            public GetCheckedNodesOperation() : base() { }
            public override void Execute(TreeListNode node)
            {
                if (node.CheckState != CheckState.Unchecked)
                {
                    CheckedNodes.Add(node);
                    CheckedAccessess.Add((DB.SEC_Access)node.TreeList.GetDataRecordByNode(node));
                }
            }
        }

        private class FindNodesOperation : TreeListOperation
        {
            private TreeListNode foundNode;
            private Int64 id;

            public FindNodesOperation(Int64 id)
            {
                this.foundNode = null;
                this.id = id;
            }

            public override void Execute(TreeListNode node)
            {
                try
                {
                    if (((DB.SEC_Access)node.TreeList.GetDataRecordByNode(node)).Id == id)
                        this.foundNode = node;
                }
                catch (Exception ex)
                {
                    if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                }
            }

            public TreeListNode Node { get { return foundNode; } }
        }

        //TODO : Remove this when log system is added
        /// <summary>
        /// Sets boolean to true that identifies that access has been changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Created: Werner Scheffer 28/02/2013</remarks>        
        private void grdAccess_NodeChanged(object sender, DevExpress.XtraTreeList.NodeChangedEventArgs e)
        {
            if (e.ChangeType == DevExpress.XtraTreeList.NodeChangeTypeEnum.CheckedState)
            {
                AccessHasChanged = true;

                DB.SEC_Access acc = (DB.SEC_Access)e.Node.TreeList.GetDataRecordByNode(e.Node);
                List<DB.SEC_RoleAccess> current = secRole.SEC_RoleAccess.ToList();
                TreeListNode node;
                //CheckParent(e.Node);
                switch (acc.Code)
                {
                    case "ORCURE03":  // Organisations - Customers - Change Cost Category
                        node = GetNodeByRoleAccessId(DataContext.EntitySecurityContext.SEC_Access.Where(n => n.Code == "ORCURECR").Select(n => n.Id).FirstOrDefault());
                        if (!e.Node.Checked)
                        {
                            node.Checked = false;
                        }
                        break;
                    case "ORCURE04":  // Organisations - Customers - Change Payment Terms
                        node = GetNodeByRoleAccessId(DataContext.EntitySecurityContext.SEC_Access.Where(n => n.Code == "ORCURECR").Select(n => n.Id).FirstOrDefault());
                        if (!e.Node.Checked)
                        {
                            node.Checked = false;
                        }
                        break;
                    case "ORCURECR":  // Organisations - Customers - Create
                        if (e.Node.Checked)
                        {
                            node = GetNodeByRoleAccessId(DataContext.EntitySecurityContext.SEC_Access.Where(n => n.Code == "ORCURE03").Select(n => n.Id).FirstOrDefault());
                            node.Checked = true;
                            node = GetNodeByRoleAccessId(DataContext.EntitySecurityContext.SEC_Access.Where(n => n.Code == "ORCURE04").Select(n => n.Id).FirstOrDefault());
                            node.Checked = true;
                        }
                        break;
                    case "ORSURE03":  // Organisations - Suppliers - Change Cost Category
                        node = GetNodeByRoleAccessId(DataContext.EntitySecurityContext.SEC_Access.Where(n => n.Code == "ORSURECR").Select(n => n.Id).FirstOrDefault());
                        if (!e.Node.Checked)
                        {
                            node.Checked = false;
                        }
                        break;
                    case "ORSURE04":  // Organisations - Suppliers - Change Payment Terms
                        node = GetNodeByRoleAccessId(DataContext.EntitySecurityContext.SEC_Access.Where(n => n.Code == "ORSURECR").Select(n => n.Id).FirstOrDefault());
                        if (!e.Node.Checked)
                        {
                            node.Checked = false;
                        }
                        break;
                    case "ORSURECR":  // Organisations - Suppliers - Create
                        if (e.Node.Checked)
                        {
                            node = GetNodeByRoleAccessId(DataContext.EntitySecurityContext.SEC_Access.Where(n => n.Code == "ORSURE03").Select(n => n.Id).FirstOrDefault());
                            node.Checked = true;
                            node = GetNodeByRoleAccessId(DataContext.EntitySecurityContext.SEC_Access.Where(n => n.Code == "ORSURE04").Select(n => n.Id).FirstOrDefault());
                            node.Checked = true;
                        }
                        break;
                }
            }
        }
    }
}