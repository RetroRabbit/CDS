using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB = CDS.Client.DataAccessLayer.DB;
using BL = CDS.Client.BusinessLayer;

namespace CDS.Client.BusinessLayer.GLX
{
    public class GLX_Header
    {
        public static DB.GLX_Header New
        {
            get
            {
                DB.GLX_Header entry = new DB.GLX_Header();
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;
                entry.Date = DateTime.Today;
                entry.StatusId = (byte)SYS.SYS_Status.Unposted;
                entry.Title = "New Entry";
                return entry;
            }
        }

        public static DB.GLX_Header Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityAccountingContext.GLX_Header.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.GLX_Header Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }  

        internal static String Save(DB.GLX_Header entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityAccountingContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                {
                    dataContext.EntityAccountingContext.GLX_Header.Add(entry);
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        //TODO: Make this work
        public static void UpdateTrackNumber(Int64 oldTrackingNumber, long newTrackingNumber, DataContext dataContext)
        {
            foreach (var header in dataContext.EntityAccountingContext.GLX_Header.Where(n => n.TrackId == oldTrackingNumber))
            {
                header.TrackId = newTrackingNumber;
            }            
        } 

        //TODO: Make this work
        public static System.Data.DataTable GetPayable(DB.SYS_Period period, DataContext dataContext)
        {
            //Check for master accountant
            String query = "";
            if (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAARE))
            {
                query = "SELECT Type, AccountId, Title, Reference, Description, Date, Balance, Period, Aging, TrackNumber, LineId FROM CDS_GLX.VW_PayableItems WHERE (Type='OI') OR (Type='BBF' AND PeriodId=" + period.Id + ") ORDER BY Date";
            }
            else
            {
                query = "SELECT Type, AccountId, Title, Reference, Description, Date, Balance, Period, Aging, TrackNumber, LineId FROM CDS_GLX.VW_PayableItems WHERE ((Type='OI') OR (Type='BBF' AND PeriodId=" + period.Id + ")) AND SiteId="+ BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId +" ORDER BY Date";
            }
            System.Data.SqlClient.SqlDataAdapter adapter = ApplicationDataContext.Instance.GetAdapter(query);
            System.Data.DataTable tblResult = new System.Data.DataTable();
            adapter.Fill(tblResult);
            return tblResult;
        }

        public static System.Data.DataTable GetPayable(DB.SYS_Period period, string filter, DataContext dataContext)
        {
            String query = "";
            if (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAARE))
            {
                query = "SELECT Type, AccountId, Title, Reference, Description, Date, Balance, Period, Aging, TrackNumber, LineId FROM CDS_GLX.VW_PayableItems WHERE ((Type='OI') OR (Type='BBF' AND PeriodId=" + period.Id + ")) AND " + filter + " ORDER BY Date";
            }
            else
            {
                query = "SELECT Type, AccountId, Title, Reference, Description, Date, Balance, Period, Aging, TrackNumber, LineId FROM CDS_GLX.VW_PayableItems WHERE ((Type='OI') OR (Type='BBF' AND PeriodId=" + period.Id + ")) AND " + filter + ") AND SiteId=" + BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId + " ORDER BY Date";
            }
            System.Data.SqlClient.SqlDataAdapter adapter = ApplicationDataContext.Instance.GetAdapter("SELECT Type, AccountId, Title, Reference, Description, Date, Balance, Period, Aging, TrackNumber, LineId FROM CDS_GLX.VW_PayableItems WHERE ((Type='OI') OR (Type='BBF' AND PeriodId=" + period.Id + ")) AND " + filter + " ORDER BY Date");
            System.Data.DataTable tblResult = new System.Data.DataTable();
            adapter.Fill(tblResult);
            return tblResult;
        } 

        public static System.Data.DataTable GetReceivable(DB.SYS_Period period, DataContext dataContext)
        {
            String query = "";
            if (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAARE))
            {
                query = "SELECT Type, AccountId, Title, Reference, Description, Date, Balance, Period, Aging, TrackNumber, LineId FROM CDS_GLX.VW_ReceivableItems WHERE (Type='OI') OR (Type='BBF' AND PeriodId=" + period.Id + ") ORDER BY Date";
            }
            else
            {
                query = "SELECT Type, AccountId, Title, Reference, Description, Date, Balance, Period, Aging, TrackNumber, LineId FROM CDS_GLX.VW_ReceivableItems WHERE ((Type='OI') OR (Type='BBF' AND PeriodId=" + period.Id + ")) AND SiteId= " + BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId + " ORDER BY Date";
            }

            System.Data.SqlClient.SqlDataAdapter adapter = ApplicationDataContext.Instance.GetAdapter(query);
            System.Data.DataTable tblResult = new System.Data.DataTable();
            adapter.Fill(tblResult);
            return tblResult;
        }

        public static System.Data.DataTable GetReceivable(DB.SYS_Period period, string filter, DataContext dataContext)
        {
            String query = "";
            if (BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIAARE))
            {
                query = "SELECT Type, AccountId, Title, Reference, Description, Date, Balance, Period, Aging, TrackNumber, LineId FROM CDS_GLX.VW_ReceivableItems WHERE ((Type='OI') OR (Type='BBF' AND PeriodId=" + period.Id + ")) AND " + filter + ") ORDER BY Date";
            }
            else
            {
                query = "SELECT Type, AccountId, Title, Reference, Description, Date, Balance, Period, Aging, TrackNumber, LineId FROM CDS_GLX.VW_ReceivableItems WHERE ((Type='OI') OR (Type='BBF' AND PeriodId=" + period.Id + ")) AND " + filter + ")) AND SiteId=" + BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId + " ORDER BY Date";
            }

            System.Data.SqlClient.SqlDataAdapter adapter = ApplicationDataContext.Instance.GetAdapter(query);
            System.Data.DataTable tblResult = new System.Data.DataTable();
            adapter.Fill(tblResult);
            return tblResult;
        }

        public static void InsertProfitDistributionEntries(DB.GLX_Header glx_header,DataContext dataContext)
        {
            decimal total = 0;
            decimal currentProfitTotal = 0;
            decimal currentDistributionTotal = 0;

            foreach (DB.GLX_Line line in glx_header.GLX_Line)
            {
                if (ApplicationDataContext.Instance.ProfitDistributionEntriesRequired.Contains(line.EntityId))
                {
                    total += line.Amount;
                }

                //Total of current headers Profit Amount
                if (line.EntityId == ApplicationDataContext.Instance.SiteAccounts.Profit.EntityId)
                {
                    currentProfitTotal += line.Amount;
                }

                //Total of current headers Distribution Amount
                if (line.EntityId == ApplicationDataContext.Instance.SiteAccounts.DistributedReserves.EntityId)
                {
                    currentDistributionTotal += line.Amount;
                }
            }

            if ((total - currentDistributionTotal) != 0 || (total + currentProfitTotal) != 0)
            {
                // DISTRIBUTION ENTRY
                DB.GLX_Line glx_line_distribution = GLX.GLX_Line.New;
                glx_line_distribution.EntityId = ApplicationDataContext.Instance.SiteAccounts.DistributedReserves.EntityId;
                //CURRENT
                glx_line_distribution.AgingId = 1;
                glx_line_distribution.Amount = total - currentDistributionTotal;
                glx_line_distribution.CenterId = GLX_Account.LoadByEntityId(glx_line_distribution.EntityId, dataContext).CenterId;
                glx_header.GLX_Line.Add(glx_line_distribution);

                // PROFIT ENTRY
                DB.GLX_Line glx_line_profit = GLX.GLX_Line.New;
                glx_line_profit.EntityId = ApplicationDataContext.Instance.SiteAccounts.Profit.EntityId;
                //CURRENT
                glx_line_profit.AgingId = 1;
                glx_line_profit.Amount = -(total + currentProfitTotal);
                glx_line_profit.CenterId = GLX_Account.LoadByEntityId(glx_line_profit.EntityId, dataContext).CenterId;    
                glx_header.GLX_Line.Add(glx_line_profit);
            }
        }

        //public static DB.GLX_Header GetNextItem(DB.GLX_Header glx_header, DataContext dataContext)
        //{
        //    return dataContext.EntitySystemContext.SYS_Header.OrderBy(o => o.Date).FirstOrDefault(n => n.Date > glx_header.Date && n.Date != glx_header.Date);
        //}

        //public static DB.GLX_Header GetPreviousItem(DB.GLX_Header glx_header, DataContext dataContext)
        //{
        //    return dataContext.EntitySystemContext.SYS_Header.OrderByDescending(o => o.Date).FirstOrDefault(n => n.Date > glx_header.Date && n.Date != glx_header.Date);
        //}

        public static System.Data.DataTable GetCashierReceived(Int64 periodId, Int64 companyid, string reference, DateTime date, string accountspivot)
        {
            throw new NotImplementedException();
        }

        public static DB.GLX_Header CreateReversalEntry(DB.GLX_Header glx_header, DataContext dataContext)
        {
            DB.GLX_Header glx_header_reversal = GLX.GLX_Header.New;
            glx_header_reversal.JournalTypeId = (byte)GLX.GLX_JournalType.Reversal;
            glx_header_reversal.Reference = glx_header.Reference;
            glx_header_reversal.Description = String.Format("Reverse {0}", glx_header.Description);
            glx_header_reversal.TrackId = glx_header.TrackId;
            glx_header_reversal.Date = DateTime.Now;
            //TODO: Fix this
            //glx_header_reversal.InternalReference = (glx_header.InternalReference ?? "") + ".REV";

            // Check if entry period is still open
            DB.SYS_Period period = SYS.SYS_Period.Load(glx_header.PeriodId, dataContext);
            if (period.StatusId == (byte)SYS.SYS_Status.Open)
            {
                glx_header_reversal.Date = glx_header.Date;
                glx_header_reversal.PeriodId = period.Id;
            }

            // Add reversal lines - they currently default to aging 00 though
            foreach (DB.GLX_Line line in glx_header.GLX_Line)
            {
                DB.GLX_Line glx_line_reversal = GLX.GLX_Line.New;
                glx_line_reversal.EntityId = line.EntityId;
                glx_line_reversal.Amount = -line.Amount;
                glx_line_reversal.CenterId = line.CenterId;
                glx_line_reversal.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;
                glx_line_reversal.CreatedOn = DateTime.Now;
                glx_line_reversal.AgingId = line.AgingId;

                glx_header_reversal.GLX_Line.Add(glx_line_reversal);
            }

            return glx_header_reversal;
        }

        public static void UpdateLedgerAccountBalance(DB.GLX_Header glx_header, DataContext dataContext)
        {
            foreach (DB.GLX_Line line in glx_header.GLX_Line)
            {
                dataContext.EntityAccountingContext.ExecuteSqlCommand(String.Format("EXEC CDS_SYS.spUpdateAccountBalance {0},{1},{2},{3},{4},{5}", line.EntityId, glx_header.ReferencePeriodId, glx_header.PeriodId, line.AgingId, line.Amount, ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId));
            }
        }

        public static void Approve(DB.GLX_Header glx_header, DataContext dataContext)
        {
            GLX.GLX_Header.UpdateLedgerAccountBalance(glx_header, dataContext);
        }

        public static List<DB.GLX_Header> CreatePayments(DataRow[] rows, Dictionary<Int64, String> accountsColumns, Dictionary<string, GLX.PaymentAccount> paymentAccounts, DataContext dataContext)
        {
            List<DB.GLX_Header> headers = new List<DB.GLX_Header>();

            foreach (DataRow row in rows)
            {
                // Make a new header entry
                DB.GLX_Header header = GLX.GLX_Header.New;
                //GET PERIOD FROM DATE
                header.PeriodId = SYS.SYS_Period.Load(Convert.ToDateTime(row["colEntryDate"]), dataContext).Id;
                header.Date = Convert.ToDateTime(row["colEntryDate"]);
                header.PostedDate = ApplicationDataContext.Instance.ServerDateTime.Date;
                header.Reference = Convert.ToString(row["colEntryReference"]);
                header.StatusId = (byte)SYS.SYS_Status.Posted;
                if (Convert.ToDecimal(row["colTotal"]) <= 0)
                {
                    header.Description = "CREDITOR PAYMENT RECEIVED";
                    header.JournalTypeId = (byte)GLX.GLX_JournalType.Payment;
                }
                else
                {
                    header.Description = "CREDITOR PAYMENT REVERSAL";
                    header.JournalTypeId = (byte)GLX.GLX_JournalType.Reversal;
                }
                if (row["TrackNumber"] != DBNull.Value && Convert.ToInt64(row["TrackNumber"]) != -1)
                    header.TrackId = Convert.ToInt64(row["TrackNumber"]);
                else
                    header.TrackId = -1;

                // Add the lines
                DB.GLX_Line linecreditor = GLX.GLX_Line.New;
                linecreditor.EntityId = Convert.ToInt64(row["AccountId"]);
                header.ReferencePeriodId = header.PeriodId;
                linecreditor.AgingId = Convert.ToByte(row["colEntryAging"]);
                linecreditor.Amount = 0;
                header.GLX_Line.Add(linecreditor);
                Dictionary<Int64, Decimal> taxAccounts = new Dictionary<Int64, Decimal>();
                foreach (var pair in accountsColumns)
                {
                    GLX.PaymentAccount pa = paymentAccounts[pair.Value];
                    Decimal val = Convert.ToDecimal(row[pair.Value]);
                    if (val != 0)
                    {
                        DB.GLX_Line line = GLX.GLX_Line.New;
                        header.GLX_Line.Add(line);
                        line.EntityId = pair.Key;
                        //If the Payment Account is not a Aging account change aging id to current
                        line.AgingId = !dataContext.ReadonlyContext.VW_Account.Where(n => n.Id.Equals(pair.Key)).Select(n => n.AgingAccount).FirstOrDefault() ? (byte)1 : linecreditor.AgingId;
                        DB.GLX_Tax taxType = dataContext.EntityAccountingContext.GLX_Tax.FirstOrDefault(n => n.Id == pa.TaxId);
                        if (taxType != null && taxType.Percentage != 0)
                        {
                            line.Amount = Math.Round(val / (1 + taxType.Percentage), 2, MidpointRounding.AwayFromZero);
                            taxAccounts.Add(taxType.EntityId.Value, Math.Round(val - line.Amount, 2, MidpointRounding.AwayFromZero));
                        }
                        else
                        {
                            line.Amount = val;
                        }

                        linecreditor.Amount -= val; // Credit the debtor with the indicated amount
                    }
                }

                foreach (var account in taxAccounts.GroupBy(account => account.Key).Select(amount => new { id = amount.Key, amount = amount.Sum(account => account.Value) }))
                {
                    DB.GLX_Line line = GLX.GLX_Line.New;
                    line.EntityId = account.id;
                    line.AgingId = linecreditor.AgingId;
                    line.Amount = account.amount;
                    header.GLX_Line.Add(line);
                }
                headers.Add(header);
            }

            return headers;
        }

        public static List<DB.GLX_Header> CreateReceipts(DataRow[] rows, Dictionary<Int64, String> accountsColumns, Dictionary<string, GLX.PaymentAccount> paymentAccounts, DataContext dataContext)
        {
            List<DB.GLX_Header> headers = new List<DB.GLX_Header>();

            foreach (DataRow row in rows)
            {
                // Make a new header entry
                DB.GLX_Header header = GLX.GLX_Header.New;
                //GET PERIOD FROM DATE
                header.PeriodId = SYS.SYS_Period.Load(Convert.ToDateTime(row["colEntryDate"]), dataContext).Id;
                header.Date = Convert.ToDateTime(row["colEntryDate"]);
                header.PostedDate = Convert.ToDateTime(row["colEntryDate"]).Date;
                header.Reference = Convert.ToString(row["colEntryReference"]);
                header.StatusId = (byte)SYS.SYS_Status.Posted;
                if (Convert.ToDecimal(row["colTotal"]) >= 0)
                {
                    header.Description = "DEBTOR PAYMENT RECEIVED";
                    header.JournalTypeId = (byte)GLX.GLX_JournalType.Receipts;
                }
                else
                {
                    header.Description = "DEBTOR PAYMENT REVERSAL";
                    header.JournalTypeId = (byte)GLX.GLX_JournalType.Reversal;
                }
                if (row["TrackNumber"] != DBNull.Value && Convert.ToInt64(row["TrackNumber"]) != -1)
                    header.TrackId = Convert.ToInt64(row["TrackNumber"]);
                else 
                    header.TrackId = -1;
              

                // Add the lines
                DB.GLX_Line linedebtor = GLX.GLX_Line.New;
                linedebtor.EntityId = Convert.ToInt64(row["AccountId"]);
                header.ReferencePeriodId = header.PeriodId;
                linedebtor.AgingId = Convert.ToByte(row["colEntryAging"]);
                linedebtor.Amount = 0;
                header.GLX_Line.Add(linedebtor);
                Dictionary<Int64, Decimal> taxAccounts = new Dictionary<Int64, Decimal>();
                foreach (var pair in accountsColumns)
                {
                    GLX.PaymentAccount pa = paymentAccounts[pair.Value];
                    Decimal val = Convert.ToDecimal(row[pair.Value]);
                    if (val != 0)
                    {
                        DB.GLX_Line line = GLX.GLX_Line.New;
                        header.GLX_Line.Add(line);
                        line.EntityId = pair.Key;
                        line.AgingId = !dataContext.EntityAccountingContext.GLX_Account.Where(n => n.Id.Equals(pair.Key)).Select(n => n.AgingAccount).FirstOrDefault() ? (byte)1 : linedebtor.AgingId;
                        DB.GLX_Tax taxType = dataContext.EntityAccountingContext.GLX_Tax.FirstOrDefault(n => n.Id == pa.TaxId);
                        if (taxType != null && taxType.Percentage != 0)
                        {
                            line.Amount = Math.Round(val / (1 + taxType.Percentage), 2, MidpointRounding.AwayFromZero);
                            taxAccounts.Add(taxType.EntityId.Value, Math.Round(val - line.Amount, 2, MidpointRounding.AwayFromZero));
                        }
                        else
                        {
                            line.Amount = val;
                        }

                        linedebtor.Amount -= val; // Credit the debtor with the indicated amount
                    }
                }

                foreach (var account in taxAccounts.GroupBy(account => account.Key).Select(amount => new { id = amount.Key, amount = amount.Sum(account => account.Value) }))
                {
                    DB.GLX_Line line = GLX.GLX_Line.New;
                    line.EntityId = account.id;
                    line.AgingId = linedebtor.AgingId;
                    line.Amount = account.amount;
                    header.GLX_Line.Add(line);
                }
                headers.Add(header);
            }
            return headers;
        }
    }
}
