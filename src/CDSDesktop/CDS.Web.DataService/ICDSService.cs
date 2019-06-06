using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Web.DataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICDSService" in both code and config file together.
    [ServiceContract]
    public interface ICDSService
    {

        [OperationContract]
        String SaveDocument(DB.SYS_DOC_Header entry, long printer);

        [OperationContract]
        String PrintDocument(long id, long printerBy, long printer);

        [OperationContract]
        String ApproveDocument(long entryId, long personId);

        [OperationContract]
        String CancelDocument(long entryId, long personId);

        [OperationContract]
        String RejectDocument(long entryId, long personId);

        [OperationContract]
        String SaveJobLines(long headerid, List<DB.SYS_DOC_Line> lines, long printer);

        [OperationContract]
        String GenerateOrder(long orderId, long createdBy, long printer);

        [OperationContract]
        List<string> GetAvailablePrinter(string excludeLocation);

        [OperationContract]
        bool DistributedTransactionServiceRunning();

        [OperationContract]
        void ProcessStatements(long personId, long periodId, long? printerId, List<CDS.Client.DataAccessLayer.Types.Statement> statements);

        [OperationContract]
        List<CDS.Client.DataAccessLayer.Types.Statement> ProcessStatementsUpdate();

    }
}
