using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Main
{
    partial class MainForm
    {

        /// <summary>
        /// Updates the Messenger’s grid
        /// </summary>
        public void UpdateMessagesGrid()
        {
            InstantFeedbackSourceMessages.Refresh();
        }

        /// <summary>
        /// Retrieve unread messages
        /// </summary>
        public void UpdateMessages()
        {
            if (SelectedUser == null)
                return;

            BL.DataContext msgdatacontext = new BL.DataContext();
            ////THIS IS WRONG BUT CANT GET GRID TO PULL DATA
            messageList.Clear();
            Parallel.ForEach(msgdatacontext.EntitySystemContext.SYS_MSG_Message.Where(n => (n.FromId == BL.ApplicationDataContext.Instance.LoggedInUser.PersonId && n.ToId == SelectedUser.Id) || (n.ToId == BL.ApplicationDataContext.Instance.LoggedInUser.PersonId && n.FromId == SelectedUser.Id)), message =>
            {

                if (message.ToId == BL.ApplicationDataContext.Instance.LoggedInUser.PersonId && message.ReceivedOn == null)
                {
                    message.Received = true;
                    message.ReceivedOn = BL.ApplicationDataContext.Instance.ServerDateTime;
                }
                messageList.Add(message);
            });

            //messageList = msgdatacontext.EntitySystemContext.SYS_MSG_Message.Where(n => (n.FromId == BL.ApplicationDataContext.Instance.LoggedInUser.PersonId && n.ToId == SelectedUser.Id) || (n.ToId == BL.ApplicationDataContext.Instance.LoggedInUser.PersonId && n.FromId == SelectedUser.Id)).ToList();
            //messageList.Where(n => n.ToId == BL.ApplicationDataContext.Instance.LoggedInUser.PersonId && n.ReceivedOn == null).ToList().ForEach(n => n.Received = true);
            //messageList.Where(n => n.ToId == BL.ApplicationDataContext.Instance.LoggedInUser.PersonId && n.ReceivedOn == null).ToList().ForEach(n => n.ReceivedOn = BL.ApplicationDataContext.Instance.ServerDateTime);

            try
            {
                using (TransactionScope transaction = DataContext.GetTransactionScope())
                {
                    msgdatacontext.SaveChangesEntitySystemContext();
                    DataContext.CompleteTransaction(transaction);
                }
                msgdatacontext.EntitySystemContext.AcceptAllChanges();
            }
            catch (Exception ex)
            {
                msgdatacontext.EntitySystemContext.RejectChanges();
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
            this.Invoke(new Action(() => UpdateMessagesGrid()));
            //grdMessage.Invoke(new Action(() => grdMessage.DataSource = messageList));
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                Essential.MSG.MessengerUsers selectedUser = (Essential.MSG.MessengerUsers)grvMessengerUsers.GetFocusedRow();
                DB.SYS_MSG_Message message = BL.SYS.SYS_MSG_Message.New;
                message.Message = txtMessage.Text;
                message.ToId = selectedUser.Id;
                string sent = Essential.MSG.Messenger.Connect(selectedUser, message.Message);
                if (sent.StartsWith("Sent") || sent.StartsWith("Received"))
                {
                    message.Sent = sent.StartsWith("Sent") || sent.StartsWith("Received");
                    message.Received = sent.StartsWith("Received");
                    message.SentOn = BL.ApplicationDataContext.Instance.ServerDateTime;
                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            BL.EntityController.SaveSYS_MSG_Message(message, DataContext);
                            DataContext.SaveChangesEntitySystemContext();
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntitySystemContext.AcceptAllChanges();
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntitySystemContext.RejectChanges();
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                    }

                    txtMessage.Text = string.Empty;
                    UpdateMessages();
                }
            }
        }

        private void grvMessengerUsers_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ServerModeSourceMessages.QueryableSource = (IQueryable)DataContext.EntitySystemContext.SYS_MSG_Message.Where(n => (n.FromId == BL.ApplicationDataContext.Instance.LoggedInUser.PersonId && n.ToId == SelectedUser.Id) || (n.ToId == BL.ApplicationDataContext.Instance.LoggedInUser.PersonId && n.FromId == SelectedUser.Id));

            List<DB.SYS_MSG_Message> messages = DataContext.EntitySystemContext.SYS_MSG_Message.Where(n => (n.FromId == BL.ApplicationDataContext.Instance.LoggedInUser.PersonId && n.ToId == SelectedUser.Id) || (n.ToId == BL.ApplicationDataContext.Instance.LoggedInUser.PersonId && n.FromId == SelectedUser.Id)).ToList();
            UpdateMessages();
        }

        private void InstantFeedbackSourceMessages_GetQueryable(object sender, DevExpress.Data.Linq.GetQueryableEventArgs e)
        {
            DateTime DateAfter = BL.ApplicationDataContext.Instance.ServerDateTime.AddDays(-7);
            e.QueryableSource = (new BL.DataContext()).EntitySystemContext.SYS_MSG_Message.Where(n => n.SentOn > DateAfter && (n.FromId == BL.ApplicationDataContext.Instance.LoggedInUser.PersonId && n.ToId == SelectedUser.Id) || (n.ToId == BL.ApplicationDataContext.Instance.LoggedInUser.PersonId && n.FromId == SelectedUser.Id)).OrderBy(o => o.SentOn).ThenBy(o => o.Id);
        }

    }
}
