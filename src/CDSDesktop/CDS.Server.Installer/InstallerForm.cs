using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using CDL = CompleteDataLayer;
using System.Transactions;

namespace CDS.Server.Installer
{
    public partial class InstallerForm : DevExpress.XtraEditors.XtraForm
    {

        private BL.Configuration.RegisteredCompany selectedCompany;

        private BL.DataContext dataContext;

        private Microsoft.SqlServer.Management.Smo.Server server;

        private List<Entities.SYS_Entity> SiteEntities = new List<Entities.SYS_Entity>();

        private List<Entities.SYS_Person> Persons = new List<Entities.SYS_Person>();

        private bool ImportCDSData;

        private bool ImportChimera;

        private List<SQL.SQLWorkItem> ImportWorkItems = new List<SQL.SQLWorkItem>();

        bool ImportComplete = false;

        public InstallerForm()
        {
            InitializeComponent();
        }

        private void wcInstaller_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            e.Page.AllowBack = false;
            if (e.Page == wpSqlInstall)
            {
                e.Handled = !ValidationProvider.Validate();
            }
            //NEXT ON CONNECTION PAGE
            else if (e.Page == wpConnection)
            {
                e.Handled = SetupBusinesslayerConnection();
            }
            //NEXT ON DATA DIRECTORIES PAGE
            else if (e.Page == wpDataDirectories)
            {
                e.Handled = CreateSystemDatabase();

            }
            else if (e.Page == wpImportConnection)
            {
                if (!e.Handled && ImportCDSData)
                    e.Handled = SetupSitesToImport();
            }
            else if (e.Page == wpNewOrImport)
            {
                if (!e.Handled && !ImportCDSData)
                    e.Handled = CreateNewSitesToImport();
            }
            else if (e.Page == wpSiteSetup)
            {
                e.Handled = SaveSites();
                if (!e.Handled && ImportCDSData)
                    e.Handled = SetupUsersToImport();
            }
            else if (e.Page == wpSetupUsers)
            {
                e.Handled = SaveUsers();
                if (!e.Handled && ImportCDSData)
                {
                    if (!ImportChimera)
                        e.Handled = SetupPeriodsImportCDSData();
                    if (!e.Handled)
                        e.Handled = StartImportCDSData();

                }
            }
            else if (e.Page == wpImportOldData)
            {
                if (!ImportComplete)
                {

                    //System.Threading.Tasks.Task.Factory.StartNew(() =>
                    //{
                    //    try
                    //    {
                    //        var file = AppDomain.CurrentDomain.BaseDirectory + @"SQL\Split Address.sql";

                    //        SQL.SQLWorkItem workItem = new SQL.SQLWorkItem() { Description = file.Split('\\').Last().Split('.')[1], Command = System.IO.File.ReadAllText(file), Image = ImageCollectionState.Images[0] };
                    //        workItem.Command = workItem.Command.Replace("IMPORT_DB", txtDatabaseNameMasked.Text);
                    //        workItem.Command = workItem.Command.Replace("EXPORT_DB", txtOldCDSDatabase.Text);
                    //        workItem.Command = workItem.Command.Replace("EXPORT_INSTANCE", server.ConnectionContext.ServerInstance);

                    //        Microsoft.SqlServer.Management.Smo.Server serverA = new Microsoft.SqlServer.Management.Smo.Server(new Microsoft.SqlServer.Management.Common.ServerConnection(BL.ApplicationDataContext.Instance.SqlConnectionString));
                    //        serverA.ConnectionContext.InfoMessage += ConnectionContext_InfoMessage;

                    //        serverA.ConnectionContext.StatementTimeout = 0;
                    //        workItem.Rows = server.ConnectionContext.ExecuteNonQuery(workItem.Command);
                    //        workItem.Image = ImageCollectionState.Images[1];

                    //    }
                    //    catch (Exception ex)
                    //    {

                    //    }
                    //});

                    System.Threading.Tasks.Task.Factory.StartNew(() =>
                    {
                        wcInstaller.Invoke((Action)(() => { wcInstaller.SelectedPage.AllowNext = false; grvImportCDS.ShowLoadingPanel(); }));
                        //using (new WaitCursor(SplashManager))
                        {
                            foreach (SQL.SQLWorkItem item in ImportWorkItems)
                            {
                                try
                                {
                                    server = new Microsoft.SqlServer.Management.Smo.Server(new Microsoft.SqlServer.Management.Common.ServerConnection(BL.ApplicationDataContext.Instance.SqlConnectionString));
                                    server.ConnectionContext.InfoMessage += ConnectionContext_InfoMessage;

                                    server.ConnectionContext.StatementTimeout = 0;
                                    item.Rows = server.ConnectionContext.ExecuteNonQuery(item.Command);
                                    item.Image = ImageCollectionState.Images[1];
                                    wcInstaller.Invoke((Action)(() => { grdImportCDS.RefreshDataSource(); }));
                                }
                                catch (Exception ex)
                                {
                                    item.Image = ImageCollectionState.Images[2];
                                    wcInstaller.Invoke((Action)(() =>
                                    {
                                        lock (meConsole)
                                        {
                                            meConsoleErrors.Text += ex.ToString() + Environment.NewLine; grdImportCDS.RefreshDataSource();
                                            meConsoleErrors.SelectionStart = meConsoleErrors.Text.Length;
                                            meConsoleErrors.ScrollToCaret();
                                        }
                                    }));
                                }
                            }
                            wcInstaller.Invoke((Action)(() => { wcInstaller.SelectedPage.AllowNext = true; grvImportCDS.HideLoadingPanel(); }));
                            ImportComplete = true;
                            wcInstaller_NextClick(wcInstaller, new DevExpress.XtraWizard.WizardCommandButtonClickEventArgs(wpImportOldData));
                        }
                    });
                }
                if (!ImportComplete)
                    e.Handled = true;
                else
                    e.Handled = false;
            }
        }

        void ConnectionContext_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            wcInstaller.Invoke((Action)(() =>
            {
                if (!meConsole.Text.Contains(e.ToString()))
                    meConsole.Text += e.ToString() + Environment.NewLine;

                meConsole.SelectionStart = meConsole.Text.Length;
                meConsole.ScrollToCaret();
            }));
        }

        private bool SetupPeriodsImportCDSData()
        {
            //TODO: Need to allow add drop down
            int year = 2009;
            int month = 2;
            using (new WaitCursor(SplashManager))
            {
                try
                {

                    SplashManager.SetWaitFormDescription("Setting up your new Periods ...");
                    using (TransactionScope transaction = dataContext.GetTransactionScope())
                    {

                        List<DB.SYS_Period> periods = new List<DB.SYS_Period>();

                        DateTime start = new DateTime(year - 1, month, 1);
                        int months = ((DateTime.Now.Year + 1) - start.Year) * 12;
                        int countYear = year;
                        short countQuarter = 1;

                        for (int i = 1; i <= months; i++)
                        {
                            start = start.AddMonths(1);
                            DB.SYS_Period item = new DB.SYS_Period();
                            item.StartDate = start;
                            item.EndDate = start.AddMonths(1).AddSeconds(-1);
                            item.Code = item.EndDate.ToString("yyyy-MM (MMM)").ToUpper();
                            item.Name = item.EndDate.ToString("MMMM yyyy");
                            item.FinancialYear = Convert.ToInt16(countYear);
                            item.FinancialQuarter = countQuarter;// Convert.ToInt16((i / 3) + 1);
                            item.StatusId = (byte)BL.SYS.SYS_Status.Open;
                            periods.Add(item);

                            if (i % 12 == 0)
                                countYear++;

                            if (i % 3 == 0)
                                countQuarter++;

                            if (i % 12 == 0)
                                countQuarter = 1;
                            BL.EntityController.SaveSYS_Period(item, dataContext);

                        }
                        dataContext.SaveChangesEntitySystemContext();
                        dataContext.CompleteTransaction(transaction);
                    }

                    dataContext.EntitySystemContext.AcceptAllChanges();
                    return false;
                }
                catch (Exception ex)
                {
                    dataContext.EntityAccountingContext.RejectChanges();
                    dataContext.EntitySystemContext.RejectChanges();
                    return true;
                }
            }
        }

        private bool StartImportCDSData()
        {
            grdImportCDS.DataSource = ImportWorkItems;

            if (!ImportChimera)
                foreach (var file in System.IO.Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory + @"Scripts\Scripts"))
                {
                    SQL.SQLWorkItem workItem = workItem = new SQL.SQLWorkItem() { Description = file.Split('\\').Last().Split('.')[1], Command = System.IO.File.ReadAllText(file), Image = ImageCollectionState.Images[0] };
                    workItem.Command = workItem.Command.Replace("IMPORT_DB", txtDatabaseNameMasked.Text);
                    workItem.Command = workItem.Command.Replace("EXPORT_DB", txtOldCDSDatabase.Text);
                    workItem.Command = workItem.Command.Replace("EXPORT_INSTANCE", server.ConnectionContext.ServerInstance);
                    workItem.Command = workItem.Command.Replace("FORMAT_LOCATION", AppDomain.CurrentDomain.BaseDirectory + @"Scripts\Format");
                    workItem.Command = workItem.Command.Replace("BCPDIR", bceDefaultDirectory.Path);

                    ImportWorkItems.Add(workItem);
                }
            else
            {
                foreach (var file in System.IO.Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory + @"Scripts\Scripts\Chimera"))
                {
                    SQL.SQLWorkItem workItem = workItem = new SQL.SQLWorkItem() { Description = file.Split('\\').Last().Split('.')[1], Command = System.IO.File.ReadAllText(file), Image = ImageCollectionState.Images[0] };
                    workItem.Command = workItem.Command.Replace("IMPORT_DB", txtDatabaseNameMasked.Text);
                    workItem.Command = workItem.Command.Replace("EXPORT_DB", txtOldCDSDatabase.Text);
                    workItem.Command = workItem.Command.Replace("EXPORT_INSTANCE", server.ConnectionContext.ServerInstance);
                    workItem.Command = workItem.Command.Replace("FORMAT_LOCATION", AppDomain.CurrentDomain.BaseDirectory + @"Scripts\Format");
                    workItem.Command = workItem.Command.Replace("BCPDIR", bceDefaultDirectory.Path);

                    ImportWorkItems.Add(workItem);
                }
            }
            grdImportCDS.RefreshDataSource();
            return false;
        }

        private bool SaveUsers()
        {
            try
            {
                using (new WaitCursor(SplashManager))
                {
                    try
                    {
                        SplashManager.SetWaitFormDescription("Setting up your new Users ...");
                        using (TransactionScope transaction = dataContext.GetTransactionScope())
                        {
                            foreach (Entities.SYS_Person person in Persons)
                            {
                                DB.SYS_Person newPerson = BL.SYS.SYS_Person.New;
                                DB.SEC_User newUser = BL.SEC.SEC_User.New;
                                if (person.Role != 0)
                                {
                                    DB.SEC_UserRole role = BL.SEC.SEC_UserRole.New;
                                    role.RoleId = person.Role;
                                    newUser.SEC_UserRole.Add(role);
                                }
                                Copy(person, newPerson);
                                Copy(person.User.ElementAt(0), newUser);

                                BL.EntityController.SaveSYS_Person(newPerson, dataContext);
                                dataContext.SaveChangesEntitySystemContext();
                                newUser.PersonId = newPerson.Id;
                                BL.EntityController.SaveSEC_User(newUser, dataContext);
                                dataContext.SaveChangesEntitySecurityContext();
                            }
                            dataContext.CompleteTransaction(transaction);
                        }
                        dataContext.EntitySystemContext.AcceptAllChanges();
                        //this.Close();
                    }
                    catch (Exception ex)
                    {
                        //BL.ApplicationdataContext.Instance.RollBackTransaction();
                        dataContext.EntitySystemContext.RejectChanges();
                        dataContext.EntityInventoryContext.RejectChanges();
                        MessageBox.Show(ex.ToString() + Environment.NewLine + ex.Message);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return false;
        }

        private bool SetupUsersToImport()
        {
            using (new WaitCursor(SplashManager))
            {
                ServerModeSourceRoles.QueryableSource = dataContext.EntitySecurityContext.SEC_Role;
                SplashManager.SetWaitFormDescription("Retrieving User Data" + Environment.NewLine + "from previous CDS...");
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder["Data Source"] = ddlOldCDSServer.Text;

                builder["Initial Catalog"] = txtOldCDSDatabase.Text;

                if (cbeOldCDSAuthentication.SelectedIndex == 0)
                {
                    builder["Integrated Security"] = true;
                }
                else
                {
                    builder["User ID"] = txtOldCDSUsername.Text;
                    builder["Password"] = txtOldCDSPassword.Text;
                }
                builder["Persist Security Info"] = null;

                CDL.ApplicationContext.Instance.SetConnections(builder.ConnectionString, true);
                CDL.ApplicationContext.Instance.BeginRead();
                if (!ImportChimera)
                {
                    foreach (CDL.User cdsuser in CDL.UserDataProvider.Instance.List(""))
                    {
                        Entities.SYS_Person userEntity = Entities.SYS_Person.New;
                        Entities.SEC_User user = Entities.SEC_User.New;

                        userEntity.Name = Char.ToUpperInvariant(cdsuser.Firstname[0]) + cdsuser.Firstname.Substring(1).ToLowerInvariant();
                        userEntity.Surname = Char.ToUpperInvariant(cdsuser.Lastname[0]) + cdsuser.Lastname.Substring(1).ToLowerInvariant();
                        userEntity.Archived = cdsuser.Password.Contains("XX") ? true : false;

                        user.DisplayName = userEntity.Name + ' ' + userEntity.Surname;
                        user.Username = cdsuser.Username;
                        user.Password = BL.SEC.SecurityLibrary.EncodePassword(cdsuser.Password);

                        userEntity.User.Add(user);
                        Persons.Add(userEntity);
                    }

                    SqlCommand command = CDL.ApplicationContext.Instance.GetCommand(@"select UPPER( SUBSTRING(sCreatedBy,1,1))+LOWER( SUBSTRING(sCreatedBy,2,CHARINDEX(' ',sCreatedBy)-2)) FirstName , UPPER(LOWER(SUBSTRING(sCreatedBy,CHARINDEX(' ',sCreatedBy)+1,1)))+LOWER(LOWER(SUBSTRING(sCreatedBy,CHARINDEX(' ',sCreatedBy)+2,LEN(sCreatedBy)  - CHARINDEX(' ',sCreatedBy)))) LastName from (select distinct sCreatedBy  from tblGeneralLedger where sCreatedBy not in ('','SYSTEM') union select distinct sCreatedBy from tblDocument where sCreatedBy not in ('','SYSTEM')) X where sCreatedBy not in (select sFirstName + ' ' + sLastName from tblUser)", true);
                    SqlDataReader reader;
                    CDL.ApplicationContext.Instance.BeginRead();
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Entities.SYS_Person userEntity = Entities.SYS_Person.New;
                        Entities.SEC_User user = Entities.SEC_User.New;

                        userEntity.Name = Char.ToUpperInvariant(reader["Firstname"].ToString()[0]) + reader["Firstname"].ToString().Substring(1).ToLowerInvariant();
                        userEntity.Surname = Char.ToUpperInvariant(reader["Lastname"].ToString()[0]) + reader["Lastname"].ToString().Substring(1).ToLowerInvariant();
                        userEntity.Archived = true;

                        user.DisplayName = userEntity.Name + ' ' + userEntity.Surname;
                        user.Username = userEntity.Name.ToUpper();
                        user.Password = BL.SEC.SecurityLibrary.EncodePassword(userEntity.Surname);

                        userEntity.User.Add(user);
                        Persons.Add(userEntity);
                    }
                    CDL.ApplicationContext.Instance.EndRead();
                }
                else
                {
                    SqlCommand sqlCommand = null;
                    SqlDataReader sqlReader = null;
                    sqlCommand = CDL.ApplicationContext.Instance.GetCommand("SELECT SUBSTRING(Displayname, 0, CHARINDEX(' ', DisplayName)) Firstname,SUBSTRING(Displayname, CHARINDEX(' ', DisplayName) + 1, LEN(Displayname)) Lastname,Username,Password FROM SEC_User", true);
                    sqlReader = sqlCommand.ExecuteReader();

                    while (sqlReader.Read())
                    {
                        Entities.SYS_Person userEntity = Entities.SYS_Person.New;
                        Entities.SEC_User user = Entities.SEC_User.New;

                        if (sqlReader["Firstname"].ToString().Length > 0)
                            userEntity.Name = Char.ToUpperInvariant(sqlReader["Firstname"].ToString()[0]) + sqlReader["Firstname"].ToString().Substring(1).ToLowerInvariant();
                        else
                            userEntity.Name = "";

                        if (sqlReader["Lastname"].ToString().Length > 0 && userEntity.Name.Length > 0)
                            userEntity.Surname = Char.ToUpperInvariant(sqlReader["Lastname"].ToString()[0]) + sqlReader["Lastname"].ToString().Substring(1).ToLowerInvariant();
                        else
                        {
                            userEntity.Name = Char.ToUpperInvariant(sqlReader["Lastname"].ToString()[0]) + sqlReader["Lastname"].ToString().Substring(1).ToLowerInvariant();
                            userEntity.Surname = "";
                        }

                        userEntity.Archived = false;

                        user.DisplayName = userEntity.Name + ' ' + userEntity.Surname;
                        user.Username = sqlReader["Username"].ToString();
                        user.Password = sqlReader["Password"].ToString();

                        userEntity.User.Add(user);
                        Persons.Add(userEntity);
                    }
                }
                CDL.ApplicationContext.Instance.EndRead();

                Persons.GroupBy(g => new { g.Name, g.Surname }).Select(l => new { l.Key, Persons = l.Select(a => a) }).ToList().
                              ForEach(c =>
                              {
                                  if (c.Persons.Count() > 1)
                                  {
                                      int counter = 0;
                                      c.Persons.ToList().ForEach(
                                          cc =>
                                          {
                                              if (++counter != 1)
                                              {
                                                  cc.Name += " " + counter;
                                                  cc.Archived = true;
                                              }
                                          }
                                      );
                                  }
                              });

                BindingSourcePerson.DataSource = Persons;
            }


            return false;
        }

        private bool SaveSites()
        {
            try
            {
                using (new WaitCursor(SplashManager))
                {
                    if (txtPrintServerLocation.EditValue.ToString().Length > 0)
                    {
                        BL.CDSWebService.CDSServiceClient Service = new BL.CDSWebService.CDSServiceClient("BasicHttpBinding_ICDSService", txtPrintServerLocation.EditValue.ToString());

                        SplashManager.SetWaitFormDescription("Checking if Services are running ...");
                        if (!Service.DistributedTransactionServiceRunning())
                        {
                            CDS.Client.Desktop.Essential.BaseAlert.ShowAlert("Required Service", "The following service is not started on the server please contact support.\nMSDTC", CDS.Client.Desktop.Essential.BaseAlert.Buttons.Ok, CDS.Client.Desktop.Essential.BaseAlert.Icons.Error);
                        }
                    }
                    try
                    {
                        DB.SYS_Entity firstSiteEntity = null;

                        SplashManager.SetWaitFormDescription("Setting up your new Sites ...");
                        using (TransactionScope transaction = dataContext.GetTransactionScope())
                        {
                            foreach (Entities.SYS_Entity entity in SiteEntities)
                            {
                                DB.SYS_Entity newEntity = BL.SYS.SYS_Entity.NewSite;
                                DB.SYS_Site newSite = BL.SYS.SYS_Site.New;
                                DB.SYS_Address bAddress = BL.SYS.SYS_Address.NewBillingAddress;
                                DB.SYS_Address sAddress = BL.SYS.SYS_Address.NewShippingAddress;
                                Copy(entity, newEntity);
                                Copy(entity.Addresses.ElementAt(0), bAddress);
                                Copy(entity.Addresses.ElementAt(1), sAddress);
                                Copy(entity.Site.ElementAt(0), newSite);
                                newSite.SYS_Entity = newEntity;
                                newSite.SYS_Address_BillingAddress = bAddress;
                                newSite.SYS_Address_ShippingAddress = sAddress;
                                newSite.PrintServerLocation = txtPrintServerLocation.EditValue.ToString();
                                newSite.SafetyStockPeriod = (byte)BL.SYS.SYS_SafetyStockPeriod.Days;
                                newSite.ClientZipLocation = txtClientZipLocation.EditValue.ToString();
                                newSite.UpdateURL = txtUpdateURL.EditValue.ToString();
                                BL.EntityController.SaveSYS_Site(newSite, dataContext);

                                firstSiteEntity = newEntity;

                            }

                            //Create Default Control Accounts
                            if (!ImportCDSData)
                            {
                                var file = AppDomain.CurrentDomain.BaseDirectory + @"Scripts\Scripts\New Company\1. Create Control Accounts.sql";
                                int accounts = dataContext.EntitySystemContext.Database.ExecuteSqlCommand(System.IO.File.ReadAllText(file));
                            }

                            if (ImportCDSData)
                            {
                                String vatAccounts =
                                "DECLARE @EntityId BIGINT " +
                                "INSERT INTO [CDS_SYS].[SYS_Entity] (TypeId,CodeMain,CodeSub,ShortName,Name,Description,Archived,CreatedBy,CreatedOn) VALUES (5,'99998','00000','VAT INPUT','VAT INPUT','',0,1,GETDATE())                                        SET @EntityId = SCOPE_IDENTITY();   INSERT INTO [CDS_GLX].[GLX_Account] (EntityId,AccountTypeId,CenterId,AgingAccount,CreatedOn,CreatedBy,ControlId,MasterControlId,BalanceGroup) VALUES (@EntityId,4,NULL,0,GETDATE(),1,NULL,NULL,'')	INSERT INTO [CDS_GLX].[GLX_SiteAccount] (EntityId,TypeId,SystemDefaultAccount,ShortDescription,CreatedOn,CreatedBy) VALUES (@EntityId,22,1,'VAT INPUT',GETDATE(),1)  " +
                                "INSERT INTO [CDS_SYS].[SYS_Entity] (TypeId,CodeMain,CodeSub,ShortName,Name,Description,Archived,CreatedBy,CreatedOn) VALUES (5,'99999','00000','VAT OUTPUT','VAT OUTPUT','',0,1,GETDATE())                                      SET @EntityId = SCOPE_IDENTITY();   INSERT INTO [CDS_GLX].[GLX_Account] (EntityId,AccountTypeId,CenterId,AgingAccount,CreatedOn,CreatedBy,ControlId,MasterControlId,BalanceGroup) VALUES (@EntityId,5,NULL,0,GETDATE(),1,NULL,NULL,'')	INSERT INTO [CDS_GLX].[GLX_SiteAccount] (EntityId,TypeId,SystemDefaultAccount,ShortDescription,CreatedOn,CreatedBy) VALUES (@EntityId,23,1,'VAT OUTPUT',GETDATE(),1) ";

                              //  int accounts = dataContext.EntitySystemContext.Database.ExecuteSqlCommand(vatAccounts);
                            }

                            dataContext.SaveChangesEntitySystemContext();
                            dataContext.SaveChangesEntitySecurityContext();
                            dataContext.CompleteTransaction(transaction);
                        }
                        dataContext.EntitySystemContext.AcceptAllChanges();
                        dataContext.EntitySecurityContext.AcceptAllChanges();
                        //this.Close();
                    }
                    catch (Exception ex)
                    {
                        //BL.ApplicationdataContext.Instance.RollBackTransaction();
                        dataContext.EntitySystemContext.RejectChanges();
                        dataContext.EntityInventoryContext.RejectChanges();
                        MessageBox.Show(ex.ToString() + Environment.NewLine + ex.Message);
                        return true;
                    }

                    dataContext.EntitySecurityContext.ReloadEntry(BL.ApplicationDataContext.Instance.LoggedInUser);
                    BL.ApplicationDataContext.Instance.Reload();
                }
            }
            catch (Exception ex)
            {
                CDS.Client.Desktop.Essential.BaseAlert.ShowAlert("Service Unavailable", "The URL entered is incorrect please try again.", CDS.Client.Desktop.Essential.BaseAlert.Buttons.Ok, CDS.Client.Desktop.Essential.BaseAlert.Icons.Error);
                MessageBox.Show(ex.ToString() + Environment.NewLine + ex.Message);
                return true;
            }

            return false;
        }

        private bool SetupSitesToImport()
        {
            SiteEntities.Clear();

            grvEntity.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            using (new WaitCursor(SplashManager))
            {
                SplashManager.SetWaitFormDescription("Retrieving Site Data" + Environment.NewLine + "from previous CDS...");
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder["Data Source"] = ddlOldCDSServer.Text;

                builder["Initial Catalog"] = txtOldCDSDatabase.Text;

                if (cbeOldCDSAuthentication.SelectedIndex == 0)
                {
                    builder["Integrated Security"] = true;
                }
                else
                {
                    builder["User ID"] = txtOldCDSUsername.Text;
                    builder["Password"] = txtOldCDSPassword.Text;
                }
                builder["Persist Security Info"] = null;

                CDL.ApplicationContext.Instance.SetConnections(builder.ConnectionString, true);

                if (!ImportChimera)
                {
                    int counter = 0;
                    CDL.ApplicationContext.Instance.BeginRead();
                    foreach (CDL.Warehouse warehouse in CDL.WarehouseProvider.Instance.List(""))
                    {
                        Entities.SYS_Entity siteEntity = Entities.SYS_Entity.NewSite;
                        Entities.SYS_Site site = Entities.SYS_Site.New;
                        siteEntity.Site.Add(site);

                        siteEntity.Addresses.ElementAt(0).Line1 = CDL.ApplicationContext.Instance.CompanySite.BillingAddress.Address1;
                        siteEntity.Addresses.ElementAt(0).Line2 = CDL.ApplicationContext.Instance.CompanySite.BillingAddress.Address2;
                        siteEntity.Addresses.ElementAt(0).Line3 = CDL.ApplicationContext.Instance.CompanySite.BillingAddress.Address3;
                        siteEntity.Addresses.ElementAt(0).Code = CDL.ApplicationContext.Instance.CompanySite.BillingAddress.PostalCode;

                        siteEntity.Addresses.ElementAt(1).Line1 = CDL.ApplicationContext.Instance.CompanySite.ShippingAddress.Address1;
                        siteEntity.Addresses.ElementAt(1).Line2 = CDL.ApplicationContext.Instance.CompanySite.ShippingAddress.Address2;
                        siteEntity.Addresses.ElementAt(1).Line3 = CDL.ApplicationContext.Instance.CompanySite.ShippingAddress.Address3;
                        siteEntity.Addresses.ElementAt(1).Code = CDL.ApplicationContext.Instance.CompanySite.ShippingAddress.PostalCode;


                        siteEntity.CodeMain = (++counter).ToString().PadLeft(6 - counter.ToString().Length, '0');
                        siteEntity.Name = warehouse.TradingName;
                        siteEntity.ShortName = warehouse.TradingName;
                        siteEntity.Description = string.Empty;

                        site.Telephone = CDL.ApplicationContext.Instance.CompanySite.AccountsTelephone;
                        site.EmailAddress = CDL.ApplicationContext.Instance.CompanySite.AccountsEmailAddress;
                        site.RegistrationNumber = warehouse.RegistrationNumber;
                        site.VatPercentage = CDL.ApplicationContext.Instance.CompanySite.VatPercentage;
                        site.VatNumber = warehouse.VatNumber;
                        site.Currency = CDL.ApplicationContext.Instance.CompanySite.Currency;
                        site.CashierRefreshIntervals = Convert.ToInt16(CDL.ApplicationContext.Instance.CompanySite.CashierRefreshIntervals);
                        site.SMTPServerLocation = CDL.ApplicationContext.Instance.CompanySite.SMTPServer;
                        site.AccountEmailAddress = CDL.ApplicationContext.Instance.CompanySite.SMTPMailAccount;
                        site.AccountEmailUsername = CDL.ApplicationContext.Instance.CompanySite.SMTPUsername;
                        site.AccountEmailPassword = CDL.ApplicationContext.Instance.CompanySite.SMTPPassword;
                        site.AccountEmailDomain = CDL.ApplicationContext.Instance.CompanySite.SMTPDomain;
                        site.AccountEmailBCCAddress = CDL.ApplicationContext.Instance.CompanySite.SMTPMailAccount;
                        site.DocumentEmailAddress = CDL.ApplicationContext.Instance.CompanySite.SMTPDocMailAccount;
                        site.DocumentEmailUsername = CDL.ApplicationContext.Instance.CompanySite.SMTPDocUsername;
                        site.DocumentEmailPassword = CDL.ApplicationContext.Instance.CompanySite.SMTPDocPassword;
                        site.DocumentEmailDomain = CDL.ApplicationContext.Instance.CompanySite.SMTPDocDomain;
                        site.DocumentEmailBCCAddress = CDL.ApplicationContext.Instance.CompanySite.SMTPDocMailAccount;
                        site.ProxyServerLocation = CDL.ApplicationContext.Instance.CompanySite.ProxyServer;
                        site.ProxyServerUsername = CDL.ApplicationContext.Instance.CompanySite.ProxyUsername;
                        site.ProxyServerPassword = CDL.ApplicationContext.Instance.CompanySite.ProxyPassword;
                        site.PrintServerLocation = txtPrintServerLocation.EditValue.ToString();
                        site.BankName = CDL.ApplicationContext.Instance.CompanySite.BankingBank;
                        site.BankBranch = CDL.ApplicationContext.Instance.CompanySite.BankingBranch;
                        site.BankCode = CDL.ApplicationContext.Instance.CompanySite.BankingBranchCode;
                        site.BankAccountNumber = CDL.ApplicationContext.Instance.CompanySite.BankingAccount;
                        site.DefaultMessageDocument = CDL.ApplicationContext.Instance.CompanySite.MessageStandard;
                        site.DefaultMessageStatement = CDL.ApplicationContext.Instance.CompanySite.StatementMessageStandard;
                        //site.UpdateURL = CDL.ApplicationContext.Instance.CompanySite.UpdateUrl;
                        site.MinimizeNavigation = CDL.ApplicationContext.Instance.CompanySite.MinimizeNavigation;
                        site.UseBarcodes = CDL.ApplicationContext.Instance.CompanySite.UseBarcodes;
                        site.UseLabels = CDL.ApplicationContext.Instance.CompanySite.UseLabels;
                        site.CopyInvoiceOrderNumbertoCreditNote = true;
                        site.AutoWriteoffOpenItemCredits = CDL.ApplicationContext.Instance.CompanySite.AutoWriteoffOpenItemCredits;
                        switch (CDL.ApplicationContext.Instance.CompanySite.NegitiveDiscountEffects)
                        {
                            case "UNITPRICE": site.NegativeDiscountEffects = 0; break;
                            case "UNITCOST": site.NegativeDiscountEffects = 1; break;
                            case "UNITREPLACEMENTCOST": site.NegativeDiscountEffects = 2; break;
                            default: site.NegativeDiscountEffects = 0; break;
                        }
                        site.NotifyonZeroMarkupSale = CDL.ApplicationContext.Instance.CompanySite.NotifyOnZeroMarkupSale;
                        site.NotifyonZeroProfitSale = CDL.ApplicationContext.Instance.CompanySite.NotifyOnZeroProfitSale;
                        site.QuoteValidDays = (byte)CDL.ApplicationContext.Instance.CompanySite.QuoteValidityInDays;
                        site.QuoteValidMax = (byte)CDL.ApplicationContext.Instance.CompanySite.QuoteValidityMaxInDays;
                        site.NotifyonBackOrder = true;
                        site.RoundingAmount = CDL.ApplicationContext.Instance.CompanySite.Rounding;
                        site.CashierPaymentsFullAmount = CDL.ApplicationContext.Instance.CompanySite.CasherPaymentsMustBeForFullAmount;
                        site.CODAccountLimit = (byte)CDL.ApplicationContext.Instance.CompanySite.CODAccountLimit;
                        site.DebtorGracePeriod = (byte)CDL.ApplicationContext.Instance.CompanySite.DebtorGracePeriod;
                        site.DefaultInterestCharged = CDL.ApplicationContext.Instance.CompanySite.InterestDefault;
                        site.MonthWeight3 = (byte)CDL.ApplicationContext.Instance.CompanySite.ThreeMonthWeight;
                        site.MonthWeight6 = (byte)CDL.ApplicationContext.Instance.CompanySite.SixMonthWeight;
                        site.MonthWeight12 = (byte)CDL.ApplicationContext.Instance.CompanySite.TwelveMonthWeight;
                        site.MonthWeight24 = 0;
                        site.MonthWeight36 = 0;
                        site.FixedOrderCost = Convert.ToDecimal(CDL.ApplicationContext.Instance.CompanySite.FixedOrderCost);
                        site.MaxOrderLines = (byte)CDL.ApplicationContext.Instance.CompanySite.MaxOrderLines;
                        switch (CDL.ApplicationContext.Instance.CompanySite.SafetyStockPeriod)
                        {
                            case CDL.OrderingPeriods.None:
                            case CDL.OrderingPeriods.Days: site.SafetyStockPeriod = 0; break;
                            case CDL.OrderingPeriods.Weeks: site.SafetyStockPeriod = 1; break;
                        }
                        site.DistributionNumber = CDL.ApplicationContext.Instance.CompanySite.DistributionNumber;
                        site.BackupLocation = CDL.ApplicationContext.Instance.CompanySite.DefaultBackupPath;
                        site.LineTypeFilter = "Inventory, Account, Buy Out";

                        SiteEntities.Add(siteEntity);

                    }
                    CDL.ApplicationContext.Instance.EndRead();
                }
                else
                {
                    CDL.ApplicationContext.Instance.BeginRead();
                    SqlCommand sqlCommand = null;
                    SqlDataReader sqlReader = null;
                    sqlCommand = CDL.ApplicationContext.Instance.GetCommand("select sCode, sTradingName, sRegistrationNumber, sVatNumber from vwWarehouse", true);
                    sqlReader = sqlCommand.ExecuteReader();

                    while (sqlReader.Read())
                    {

                        Entities.SYS_Entity siteEntity = Entities.SYS_Entity.NewSite;
                        Entities.SYS_Site site = Entities.SYS_Site.New;
                        siteEntity.Site.Add(site);

                        siteEntity.CodeMain = sqlReader["sCode"] == null ? string.Empty : sqlReader["sCode"].ToString().PadLeft(5 - sqlReader["sCode"].ToString().Length, '0');
                        siteEntity.Name = sqlReader["sTradingName"].ToString();
                        siteEntity.ShortName = sqlReader["sTradingName"].ToString();
                        siteEntity.Description = string.Empty;
                        site.RegistrationNumber = sqlReader["sRegistrationNumber"].ToString();
                        site.VatNumber = sqlReader["sVatNumber"].ToString();

                        SiteEntities.Add(siteEntity);
                    }

                    CDL.ApplicationContext.Instance.EndRead();

                    foreach (var siteEntity in SiteEntities)
                    {
                        var site = siteEntity.Site.FirstOrDefault();
                        siteEntity.Addresses.ElementAt(0).Line1 = CDL.ApplicationContext.Instance.CompanySite.BillingAddress.Address1;
                        siteEntity.Addresses.ElementAt(0).Line2 = CDL.ApplicationContext.Instance.CompanySite.BillingAddress.Address2;
                        siteEntity.Addresses.ElementAt(0).Line3 = CDL.ApplicationContext.Instance.CompanySite.BillingAddress.Address3;
                        siteEntity.Addresses.ElementAt(0).Code = CDL.ApplicationContext.Instance.CompanySite.BillingAddress.PostalCode;

                        siteEntity.Addresses.ElementAt(1).Line1 = CDL.ApplicationContext.Instance.CompanySite.ShippingAddress.Address1;
                        siteEntity.Addresses.ElementAt(1).Line2 = CDL.ApplicationContext.Instance.CompanySite.ShippingAddress.Address2;
                        siteEntity.Addresses.ElementAt(1).Line3 = CDL.ApplicationContext.Instance.CompanySite.ShippingAddress.Address3;
                        siteEntity.Addresses.ElementAt(1).Code = CDL.ApplicationContext.Instance.CompanySite.ShippingAddress.PostalCode;

                        site.Telephone = CDL.ApplicationContext.Instance.CompanySite.AccountsTelephone;
                        site.EmailAddress = CDL.ApplicationContext.Instance.CompanySite.AccountsEmailAddress;
                        site.VatPercentage = CDL.ApplicationContext.Instance.CompanySite.VatPercentage;
                        site.Currency = CDL.ApplicationContext.Instance.CompanySite.Currency;
                        site.CashierRefreshIntervals = Convert.ToInt16(CDL.ApplicationContext.Instance.CompanySite.CashierRefreshIntervals);
                        site.SMTPServerLocation = CDL.ApplicationContext.Instance.CompanySite.SMTPServer;
                        site.AccountEmailAddress = CDL.ApplicationContext.Instance.CompanySite.SMTPMailAccount;
                        site.AccountEmailUsername = CDL.ApplicationContext.Instance.CompanySite.SMTPUsername;
                        site.AccountEmailPassword = CDL.ApplicationContext.Instance.CompanySite.SMTPPassword;
                        site.AccountEmailDomain = CDL.ApplicationContext.Instance.CompanySite.SMTPDomain;
                        site.AccountEmailBCCAddress = CDL.ApplicationContext.Instance.CompanySite.SMTPMailAccount;
                        site.DocumentEmailAddress = CDL.ApplicationContext.Instance.CompanySite.SMTPDocMailAccount;
                        site.DocumentEmailUsername = CDL.ApplicationContext.Instance.CompanySite.SMTPDocUsername;
                        site.DocumentEmailPassword = CDL.ApplicationContext.Instance.CompanySite.SMTPDocPassword;
                        site.DocumentEmailDomain = CDL.ApplicationContext.Instance.CompanySite.SMTPDocDomain;
                        site.DocumentEmailBCCAddress = CDL.ApplicationContext.Instance.CompanySite.SMTPDocMailAccount;
                        site.ProxyServerLocation = CDL.ApplicationContext.Instance.CompanySite.ProxyServer;
                        site.ProxyServerUsername = CDL.ApplicationContext.Instance.CompanySite.ProxyUsername;
                        site.ProxyServerPassword = CDL.ApplicationContext.Instance.CompanySite.ProxyPassword;
                        site.PrintServerLocation = txtPrintServerLocation.EditValue.ToString();
                        site.BankName = CDL.ApplicationContext.Instance.CompanySite.BankingBank;
                        site.BankBranch = CDL.ApplicationContext.Instance.CompanySite.BankingBranch;
                        site.BankCode = CDL.ApplicationContext.Instance.CompanySite.BankingBranchCode;
                        site.BankAccountNumber = CDL.ApplicationContext.Instance.CompanySite.BankingAccount;
                        site.DefaultMessageDocument = CDL.ApplicationContext.Instance.CompanySite.MessageStandard;
                        site.DefaultMessageStatement = CDL.ApplicationContext.Instance.CompanySite.StatementMessageStandard;
                        site.UpdateURL = CDL.ApplicationContext.Instance.CompanySite.UpdateUrl;
                        //site.MinimizeNavigation = CDL.ApplicationContext.Instance.CompanySite.MinimizeNavigation;
                        site.UseBarcodes = CDL.ApplicationContext.Instance.CompanySite.UseBarcodes;
                        site.UseLabels = CDL.ApplicationContext.Instance.CompanySite.UseLabels;
                        site.CopyInvoiceOrderNumbertoCreditNote = true;
                        site.AutoWriteoffOpenItemCredits = CDL.ApplicationContext.Instance.CompanySite.AutoWriteoffOpenItemCredits;
                        switch (CDL.ApplicationContext.Instance.CompanySite.NegitiveDiscountEffects)
                        {
                            case "UNITPRICE": site.NegativeDiscountEffects = 0; break;
                            case "UNITCOST": site.NegativeDiscountEffects = 1; break;
                            case "UNITREPLACEMENTCOST": site.NegativeDiscountEffects = 2; break;
                            default: site.NegativeDiscountEffects = 0; break;
                        }
                        site.NotifyonZeroMarkupSale = CDL.ApplicationContext.Instance.CompanySite.NotifyOnZeroMarkupSale;
                        site.NotifyonZeroProfitSale = CDL.ApplicationContext.Instance.CompanySite.NotifyOnZeroProfitSale;
                        site.QuoteValidDays = (byte)CDL.ApplicationContext.Instance.CompanySite.QuoteValidityInDays;
                        site.QuoteValidMax = (byte)CDL.ApplicationContext.Instance.CompanySite.QuoteValidityMaxInDays;
                        site.NotifyonBackOrder = true;
                        site.RoundingAmount = CDL.ApplicationContext.Instance.CompanySite.Rounding;
                        site.CashierPaymentsFullAmount = CDL.ApplicationContext.Instance.CompanySite.CasherPaymentsMustBeForFullAmount;
                        site.CODAccountLimit = (byte)CDL.ApplicationContext.Instance.CompanySite.CODAccountLimit;
                        site.DebtorGracePeriod = (byte)CDL.ApplicationContext.Instance.CompanySite.DebtorGracePeriod;
                        site.DefaultInterestCharged = CDL.ApplicationContext.Instance.CompanySite.InterestDefault;
                        site.MonthWeight3 = (byte)CDL.ApplicationContext.Instance.CompanySite.ThreeMonthWeight;
                        site.MonthWeight6 = (byte)CDL.ApplicationContext.Instance.CompanySite.SixMonthWeight;
                        site.MonthWeight12 = (byte)CDL.ApplicationContext.Instance.CompanySite.TwelveMonthWeight;
                        site.MonthWeight24 = 0;
                        site.MonthWeight36 = 0;
                        site.FixedOrderCost = Convert.ToDecimal(CDL.ApplicationContext.Instance.CompanySite.FixedOrderCost);
                        site.MaxOrderLines = CDL.ApplicationContext.Instance.CompanySite.MaxOrderLines > 250 ? (byte)250 : (byte)CDL.ApplicationContext.Instance.CompanySite.MaxOrderLines;
                        switch (CDL.ApplicationContext.Instance.CompanySite.SafetyStockPeriod)
                        {
                            case CDL.OrderingPeriods.None:
                            case CDL.OrderingPeriods.Days: site.SafetyStockPeriod = 0; break;
                            case CDL.OrderingPeriods.Weeks: site.SafetyStockPeriod = 1; break;
                        }
                        site.DistributionNumber = CDL.ApplicationContext.Instance.CompanySite.DistributionNumber;
                        site.BackupLocation = CDL.ApplicationContext.Instance.CompanySite.DefaultBackupPath;
                        site.LineTypeFilter = "Inventory, Account, Buy Out";
                    }

                }

                BindingSourceEntity.DataSource = SiteEntities;
                grvEntity.RefreshData();
            }

            return false;
        }

        private bool CreateSystemDatabase()
        {
            PrepairSQLFile();
            //run sql script
            //update registerdcompanies
            //fill in site defaults
            dataContext = new BL.DataContext();
            BL.ApplicationDataContext.Instance.LoggedInUser = dataContext.EntitySecurityContext.SEC_User.FirstOrDefault();
            txtPrintServerLocation.EditValue = string.Format("http://{0}:8090/CDSService.svc", Environment.MachineName);

            return false;
        }

        private bool SetupBusinesslayerConnection()
        {
            try
            {
                using (new WaitCursor(SplashManager))
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    ConfigurationSection section = (ConfigurationSection)config.GetSection("CompleteDistributionConfig");
                    section.LockItem = false;
                    BL.Configuration.RegisteredCompanyCollection companies = (BL.Configuration.RegisteredCompanyCollection)((BL.Configuration.CompleteDistributionConfig)(section)).RegisteredCompanies;
                  
                    if (companies.Count > 0)
                    {
                        companies.Clear();
                    }

                    //for (int i = 0; i < companies.Count; i++)
                    //{
                    //    if (companies[i].Name != txtCompanyConnectionName.Text)
                    //        companies.RemoveCompany(companies[i].Name);
                    //    else
                    //        selectedCompany = companies[i];
                    //}

                    if (selectedCompany == null)
                        selectedCompany = companies.NewCompany(txtCompanyConnectionName.Text, GetConnectionString(true), Convert.ToString(Convert.ToInt32(txtTimeout.EditValue) * 1000), true);



                    SqlConnection sqlCon = new SqlConnection(GetConnectionString(true));
                    SplashManager.SetWaitFormDescription("Checking Connection to SQL...");
                    sqlCon.Open();
                    config.Save(ConfigurationSaveMode.Modified);
                    if (BL.SEC.SecurityLibrary.SetConnection(selectedCompany))
                    {
                        //if (BL.SEC.SecurityLibrary.Signin(txtUsername.Text, txtPassword.Text))
                        {
                            //Properties.Settings.Default.RegisteredCompany = config.RegisteredCompanies[ilbCompanies.SelectedIndex].Name;
                            Properties.Settings.Default.RegisteredCompany = selectedCompany.Name;
                            Properties.Settings.Default.Save();
                        }
                    }

                    server = new Microsoft.SqlServer.Management.Smo.Server(new Microsoft.SqlServer.Management.Common.ServerConnection(BL.ApplicationDataContext.Instance.SqlConnectionString));
                    DataTable tblRoot = server.EnumAvailableMedia();
                    //bceServerPath.Path = tblRoot.Rows[0][0].ToString();


                    foreach (object item in lcgDatabaseFileLocations.Items)
                    {
                        if (item is DevExpress.XtraLayout.LayoutControlItem)
                        {
                            if ((item as DevExpress.XtraLayout.LayoutControlItem).Control is DevExpress.XtraEditors.BreadCrumbEdit)
                            {
                                ((item as DevExpress.XtraLayout.LayoutControlItem).Control as DevExpress.XtraEditors.BreadCrumbEdit).Properties.History.Clear();
                                foreach (DataRow driveInfo in tblRoot.Rows)
                                {
                                    ((item as DevExpress.XtraLayout.LayoutControlItem).Control as DevExpress.XtraEditors.BreadCrumbEdit).Properties.History.Add(new BreadCrumbHistoryItem(driveInfo[0].ToString()));
                                }
                            }
                        }
                    }

                    txtDatabaseName.Text = txtCompanyConnectionName.Text.ToLower();
                }

                return !(server.Databases.Contains(txtDatabaseNameMasked.Text) ? DevExpress.XtraEditors.XtraMessageBox.Show(this.LookAndFeel, "Database exists would you like to override ?", "Override Database", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes : true);
                
            }
            catch (Exception ex)
            {
                CDS.Client.Desktop.Essential.BaseAlert.ShowAlert("Connection Unavailable", "The connection credentials are incorrect please correct and try again.", CDS.Client.Desktop.Essential.BaseAlert.Buttons.Ok, CDS.Client.Desktop.Essential.BaseAlert.Icons.Error);
                CDS.Client.Desktop.Essential.BaseAlert.ShowAlert("Connection Unavailable", ex.ToString(), CDS.Client.Desktop.Essential.BaseAlert.Buttons.Ok, CDS.Client.Desktop.Essential.BaseAlert.Icons.Error);
                return true;

            }
            return false;
        }

        private void BreadCrumb_Properties_NewNodeAdding(object sender, DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventArgs e)
        {
            e.Node.PopulateOnDemand = true;
        }

        private void BreadCrumb_Properties_QueryChildNodes(object sender, BreadCrumbQueryChildNodesEventArgs e)
        {
            DataTable tblDirectories = server.EnumDirectories((sender as DevExpress.XtraEditors.BreadCrumbEdit).Path);
            foreach (DataRow driveInfo in tblDirectories.Rows)
            {
                e.Node.ChildNodes.Add(new BreadCrumbNode(driveInfo[0].ToString(), driveInfo[0].ToString(), true));
            }
        }

        private void PrepairSQLFile()
        {

            //string configText = System.IO.File.ReadAllText(
            //@"C:\SolutionsOnline\CDS.Pegasus\CDS.Client.Installer.Prerequisites\Requirements\Prerequisites\Installers\SQL\2014 Express\CDSSQLTemplate.txt");

            string configText = System.IO.File.ReadAllText(CDS.Server.Installer.Helper.StartupPath + @"\..\Prerequisites\Installers\SQL\2014 Express\CDSSQLTemplate.txt");

            configText = configText.Replace("{DATABASENAME}", txtDatabaseNameMasked.Text);


            if (Convert.ToBoolean(rgAuthenticationMode.EditValue) == true)
            {
                configText = configText.Replace("{AUTHENTICATION}", "SA");
                configText = configText.Replace("{USER}", txtUsername.Text);
                configText = configText.Replace("{PASSWORD}", txtPassword.Text);
            }
            else
            {
                configText = configText.Replace("{AUTHENTICATION}", "WINDOWSAUT");
                configText = configText.Replace("{DOMAINNAME}", Environment.UserDomainName);
                configText = configText.Replace("{COMPUSERNAME}", Environment.UserName);
            }

            foreach (object item in lcgDatabaseFileLocations.Items)
            {
                if (item is DevExpress.XtraLayout.LayoutControlItem)
                {
                    if ((item as DevExpress.XtraLayout.LayoutControlItem).Control is DevExpress.XtraEditors.BreadCrumbEdit)
                    {
                        configText = configText.Replace("{" + (item as DevExpress.XtraLayout.LayoutControlItem).Text.ToLower().Replace(' ', '_') + "}",
                           ((item as DevExpress.XtraLayout.LayoutControlItem).Control as DevExpress.XtraEditors.BreadCrumbEdit).Path);
                    }
                }
            }

            using (new WaitCursor(SplashManager))
            {
                SplashManager.SetWaitFormDescription("Creating Database ... ");

                if (server.Databases.Contains(txtDatabaseNameMasked.Text))
                {
                    server.ConnectionContext.ExecuteNonQuery(string.Format(
                    "EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'{0}'" + Environment.NewLine +
                    "GO" + Environment.NewLine +
                    "USE [master]" + Environment.NewLine +
                    "GO" + Environment.NewLine +
                    "ALTER DATABASE [{0}] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE" + Environment.NewLine +
                    "GO" + Environment.NewLine +
                    "USE [master]" + Environment.NewLine +
                    "GO" + Environment.NewLine +
                    "DROP DATABASE [{0}]" + Environment.NewLine +
                    "GO" + Environment.NewLine
                    , txtDatabaseNameMasked.Text));
                }
                server.ConnectionContext.ExecuteNonQuery(configText);
            }

            using (new WaitCursor(SplashManager))
            {
                SplashManager.SetWaitFormDescription("Setting up your Connections ... ");
                UpdateConnectionInfo();
            }

            //using (System.IO.StreamWriter ms = new System.IO.StreamWriter(CDS.Server.Installer.Helper.StartupPath + @"\..\Prerequisites\Installers\SQL\2014 Express\cds_database.sql"))
            //{
            //    ms.Write(configText);
            //    ms.Close();
            //}

        }

        private void UpdateConnectionInfo()
        {
            selectedCompany.ConnectionString = GetConnectionString(false);
            if (BL.SEC.SecurityLibrary.SetConnection(selectedCompany))
            {
                //if (BL.SEC.SecurityLibrary.Signin(txtUsername.Text, txtPassword.Text))
                {
                    //Properties.Settings.Default.RegisteredCompany = config.RegisteredCompanies[ilbCompanies.SelectedIndex].Name;
                    Properties.Settings.Default.RegisteredCompany = selectedCompany.Name;
                    Properties.Settings.Default.Save();
                }
            }

            Configuration config = ConfigurationManager.OpenExeConfiguration(@"C:\Program Files\Complete Distribution\Client\Enterprise\CDS.Client.Desktop.exe");
            ConfigurationSection section = (ConfigurationSection)config.GetSection("CompleteDistributionConfig");
            section.LockItem = false;
            BL.Configuration.RegisteredCompanyCollection companies = (BL.Configuration.RegisteredCompanyCollection)((BL.Configuration.CompleteDistributionConfig)(section)).RegisteredCompanies;

            if (companies.Count == 0)
            {
                companies.NewCompany(txtCompanyConnectionName.Text, GetConnectionString(false), Convert.ToString(Convert.ToInt32(txtTimeout.EditValue) * 1000), true);
            }
            else
            {
                companies[0].Name = txtCompanyConnectionName.Text;
                companies[0].ConnectionString = GetConnectionString(false);
                companies[0].ConnectionTimeout = Convert.ToString(Convert.ToInt32(txtTimeout.EditValue) * 1000);
                companies[0].UpdateSite = true;
            }

            config.Save(ConfigurationSaveMode.Modified);
            if (BL.SEC.SecurityLibrary.SetConnection(selectedCompany))
            {
                //if (BL.SEC.SecurityLibrary.Signin(txtUsername.Text, txtPassword.Text))
                {
                    //Properties.Settings.Default.RegisteredCompany = config.RegisteredCompanies[ilbCompanies.SelectedIndex].Name;
                    Properties.Settings.Default.RegisteredCompany = selectedCompany.Name;
                    Properties.Settings.Default.Save();
                }
            }



            SqlConnection sqlCon = new SqlConnection(GetConnectionString(false));
            sqlCon.Open();
            config.Save(ConfigurationSaveMode.Modified);

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load("C:\\inetpub\\CDS.Web.DataService\\Web.config");

            System.Xml.XmlAttribute connectionString = (System.Xml.XmlAttribute)doc.SelectSingleNode("/configuration/connectionStrings/add/@connectionString");
            connectionString.Value = GetConnectionString(false);
            doc.Save("C:\\inetpub\\CDS.Web.DataService\\Web.config");

        }

        private void wcInstaller_FinishClick(object sender, CancelEventArgs e)
        {
            try
            {
                using (new WaitCursor(SplashManager))
                {

                    this.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void wcInstaller_CancelClick(object sender, CancelEventArgs e)
        {
            this.Close();
        }

        private void ddlServer_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Redo)
                {
                    RefreshServerList(sender as ComboBoxEdit);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void InstallerForm_Load(object sender, EventArgs e)
        {
        }

        private String GetConnectionString(bool master)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder["Data Source"] = ddlServer.Text;

                if (master)
                    builder["Initial Catalog"] = "master";
                else
                    builder["Initial Catalog"] = txtDatabaseNameMasked.Text;

                if (cbeAuthentication.SelectedIndex == 0)
                {
                    builder["Integrated Security"] = true;
                }
                else
                {
                    //This breaks the connection string, there is no false, its either true or not there
                    //builder["Integrated Security"] = false;
                    builder["User ID"] = txtUsername.Text;
                    builder["Password"] = txtPassword.Text;
                }

                //if (!String.IsNullOrEmpty(btnDBFileLocation.Text))
                //{
                //    builder["AttachDBFilename"] = btnDBFileLocation.Text;
                //}

                //REMOVE "Persist Security Info" causes fast reports go get some kind of access issue
                builder["Persist Security Info"] = null;

                return builder.ConnectionString;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void RefreshServerList(ComboBoxEdit servers)
        {
            try
            {
                using (new WaitCursor(SplashManager))
                {
                    SplashManager.SetWaitFormDescription("Searching for SQL Servers/non the network ...");
                    servers.Properties.Items.Clear();
                    System.Data.DataTable table = SqlDataSourceEnumerator.Instance.GetDataSources();

                    //ServerName / InstanceName
                    foreach (DataRow row in SqlDataSourceEnumerator.Instance.GetDataSources().Rows)
                    {
                        servers.Properties.Items.Add(
                            String.IsNullOrEmpty(Convert.ToString(row["InstanceName"])) ?
                            Convert.ToString(row["ServerName"]) :
                            Convert.ToString(row["ServerName"]) + "\\" + Convert.ToString(row["InstanceName"]));
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void ShowWaitForm()
        {
            try
            {
                if (!SplashManager.IsSplashFormVisible)
                    SplashManager.ShowWaitForm();
            }
            catch (Exception ex)
            {

            }
        }

        public void CloseWaitForm()
        {
            try
            {
                if (SplashManager.IsSplashFormVisible)
                    SplashManager.CloseWaitForm();
            }
            catch (Exception ex)
            {

            }
        }

        private void wcInstaller_SelectedPageChanging(object sender, DevExpress.XtraWizard.WizardPageChangingEventArgs e)
        {
            switch (e.Direction)
            {
                case DevExpress.XtraWizard.Direction.Forward:
                    if (wcInstaller.SelectedPage == wpSqlSetupOption)
                    {
                        if (btnInstallSQLExpress.Checked)
                        {
                            e.Page = wpSqlInstall;
                            //  e.Cancel = true;

                        }
                        if (btnChooseSql.Checked)
                        {
                            e.Page = wpConnection;
                            //  e.Cancel = true;
                        }
                    }
                    else if (wcInstaller.SelectedPage == wpSqlInstall)
                    {
                        InstallSQLExpress();
                        e.Page = wpConnection;
                        //  e.Cancel = true;
                    }
                    else if (wcInstaller.SelectedPage == wpNewOrImport)
                    {
                        if (btnNewCompany.Checked)
                        {
                            e.Page = wpSiteSetup;
                            //  e.Cancel = true;

                        }
                        if (btnImportCDS.Checked)
                        {
                            ImportCDSData = true;
                            e.Page = wpImportConnection;
                            //  e.Cancel = true;
                        }
                        if (btnImportChimera.Checked)
                        {
                            ImportCDSData = true;
                            ImportChimera = true;
                            e.Page = wpImportConnection;
                            //  e.Cancel = true;
                        }
                    }
                    else if (wcInstaller.SelectedPage == wpSiteSetup && !ImportCDSData)
                    {
                        e.Page = wpComplete;
                        wcInstaller.SelectedPage.AllowBack = false;
                    }
                    break;
                case DevExpress.XtraWizard.Direction.Backward:
                    if (wcInstaller.SelectedPage == wpConnection)
                    {
                        e.Page = wpSqlSetupOption;
                        //  e.Cancel = true;
                    }
                    else if (wcInstaller.SelectedPage == wpNewOrImport)
                    {
                        e.Page = wpDataDirectories;
                        //  e.Cancel = true;
                    }
                    else if (wcInstaller.SelectedPage == wpImportConnection)
                    {
                        e.Page = wpNewOrImport;
                        //  e.Cancel = true;
                    }
                    else if (wcInstaller.SelectedPage == wpSiteSetup)
                    {
                        e.Page = wpNewOrImport;
                        //  e.Cancel = true;
                    }
                    break;
            }
        }

        private bool CreateNewSitesToImport()
        {
            Entities.SYS_Entity entity = Entities.SYS_Entity.NewSite;
            entity.CodeMain = "00001";
            //entity.CodeSub = string.Empty;
            //entity.CreatedBy = BL.ApplicationDataContext.Instance.LoggedInUser.PersonId;
            //entity.TypeId = 10;
            entity.Site = new List<Entities.SYS_Site>();
            Entities.SYS_Site site = Entities.SYS_Site.New;
            Entities.SYS_Address billingAddress = Entities.SYS_Address.NewBillingAddress;
            Entities.SYS_Address shippingAddress = Entities.SYS_Address.NewShippingAddress;
            entity.Addresses.ElementAt(0).Line1 = billingAddress.Line1;
            entity.Addresses.ElementAt(0).Line2 = billingAddress.Line2;
            entity.Addresses.ElementAt(0).Line3 = billingAddress.Line3;
            entity.Addresses.ElementAt(0).Code = billingAddress.Code;

            entity.Addresses.ElementAt(1).Line1 = shippingAddress.Line1;
            entity.Addresses.ElementAt(1).Line2 = shippingAddress.Line2;
            entity.Addresses.ElementAt(1).Line3 = shippingAddress.Line3;
            entity.Addresses.ElementAt(1).Code = shippingAddress.Code;

            site.SafetyStockPeriod = 1;
            site.BackupLocation = @"C:\";
            site.LineTypeFilter = "Inventory, Account, Buy Out";

            entity.Site.Add(site);
            SiteEntities.Add(entity);
            BindingSourceEntity.DataSource = SiteEntities;

            return false;
        }

        private void InstallSQLExpress()
        {
            PrepairConfigFile();

            if (SystemInfo.is64BitOperatingSystem)
            {
                if (System.IO.File.Exists(CDS.Server.Installer.Helper.StartupPath + @"\..\Prerequisites\Installers\SQL\2014 Express\x64\SQLEXPR_x64_ENU.exe"))
                {
                    //MessageBox.Show("Extracting files");
                    if (System.IO.Directory.Exists("C:\\Windows\\Temp\\SQLEXPR_x64_ENU"))
                        System.IO.Directory.Delete("C:\\Windows\\Temp\\SQLEXPR_x64_ENU", true);

                    CDS.Server.Installer.Helper.Execute(CDS.Server.Installer.Helper.StartupPath + "\\..\\Prerequisites\\Installers\\SQL\\2014 Express\\x64\\SQLEXPR_x64_ENU.exe",
                        "/u /x:\"C:\\Windows\\Temp\\SQLEXPR_x64_ENU\"", true, false, CDS.Server.Installer.Helper.StartupPath + "\\..\\Prerequisites\\Installers\\SQL\\2014 Express\\x64\\");

                    //MessageBox.Show("Running install");


                    CDS.Server.Installer.Helper.Execute(@"C:\Windows\Temp\SQLEXPR_x64_ENU\SETUP.EXE",
                        " /IACCEPTSQLSERVERLICENSETERMS " + (!Convert.ToBoolean(rgAuthenticationMode.EditValue) ? string.Format("/SAPWD=\"{0}\"", txtSAPassword.EditValue) : "") + " /ConfigurationFile=\"" + CDS.Server.Installer.Helper.StartupPath + "\\..\\Prerequisites\\Installers\\SQL\\2014 Express\\ConfigurationFile.ini\" ", true, false, CDS.Server.Installer.Helper.StartupPath + @"C:\Windows\Temp\SQLEXPR_x64_ENU\");
                    //MessageBox.Show("Installed");
                }
                else
                {
                    //    MessageDialogue.ShowMessage("Missing File", "Please download Installer with Windows 7 SP 1 included");
                }
            }
            else
            {
                if (System.IO.File.Exists(CDS.Server.Installer.Helper.StartupPath + @"\..\Prerequisites\Installers\SQL\2014 Express\x86\SQLEXPR_x86_ENU.exe"))
                {
                    //MessageBox.Show("Extracting files");
                    if (System.IO.Directory.Exists("C:\\Windows\\Temp\\SQLEXPR_x86_ENU"))
                        System.IO.Directory.Delete("C:\\Windows\\Temp\\SQLEXPR_x86_ENU", true);

                    CDS.Server.Installer.Helper.Execute(CDS.Server.Installer.Helper.StartupPath + "\\..\\Prerequisites\\Installers\\SQL\\2014 Express\\x86\\SQLEXPR_x86_ENU.exe",
                        "/u /x:\"C:\\Windows\\Temp\\SQLEXPR_x86_ENU\"", true, false, CDS.Server.Installer.Helper.StartupPath + "\\..\\Prerequisites\\Installers\\SQL\\2014 Express\\x86\\");

                    //MessageBox.Show("Running install");

                    CDS.Server.Installer.Helper.Execute(@"C:\Windows\Temp\SQLEXPR_x86_ENU\SETUP.EXE",
                        " /IACCEPTSQLSERVERLICENSETERMS " + (!Convert.ToBoolean(rgAuthenticationMode.EditValue) ? string.Format("/SAPWD=\"{0}\"", txtPassword) : "") + " /ConfigurationFile=\"" + CDS.Server.Installer.Helper.StartupPath + "\\..\\Prerequisites\\Installers\\SQL\\2014 Express\\ConfigurationFile.ini\" ", true, false, CDS.Server.Installer.Helper.StartupPath + @"C:\Windows\Temp\SQLEXPR_x86_ENU\");
                    //MessageBox.Show("Installed");
                }
                else
                {
                    // MessageDialogue.ShowMessage("Missing File", "Please download Installer with Windows 7 SP 1 included");
                }
            }
        }

        private void PrepairConfigFile()
        {
            string configText = System.IO.File.ReadAllText(CDS.Server.Installer.Helper.StartupPath + @"\..\Prerequisites\Installers\SQL\2014 Express\ConfigurationFileTemplate.ini");

            if (Convert.ToBoolean(rgInstanceType.EditValue) == true)
            {
                configText = configText.Replace("{INSTANCENAME}", string.Format("INSTANCENAME=\"{0}\"", "MSSQLSERVER"));
                configText = configText.Replace("{INSTANCEID}", string.Format("INSTANCEID=\"{0}\"", "MSSQLSERVER"));
                configText = configText.Replace("{INSTANCENAMEONLY}", string.Format("{0}", "MSSQLSERVER"));


            }
            else
            {
                configText = configText.Replace("{INSTANCENAME}", string.Format("INSTANCENAME=\"{0}\"", txtInstanceName.Text));
                configText = configText.Replace("{INSTANCEID}", string.Format("INSTANCEID=\"{0}\"", txtInstanceName.Text));
                configText = configText.Replace("{INSTANCENAMEONLY}", string.Format("{0}", txtInstanceName.Text));
            }

            if (Convert.ToBoolean(rgAuthenticationMode.EditValue) == true)
            {
                configText = configText.Replace("{SECURITYMODE}", "");
                configText = configText.Replace("{SQLSYSADMINACCOUNTS}", string.Format("SQLSYSADMINACCOUNTS=\"{0}\\{1}\"", Environment.MachineName, Environment.UserName));
            }
            else
            {
                configText = configText.Replace("{SECURITYMODE}", "SECURITYMODE=\"SQL\"");
                configText = configText.Replace("{SQLSYSADMINACCOUNTS}", "");
            }

            using (System.IO.StreamWriter ms = new System.IO.StreamWriter(CDS.Server.Installer.Helper.StartupPath + @"\..\Prerequisites\Installers\SQL\2014 Express\ConfigurationFile.ini"))
            {
                ms.Write(configText);
                ms.Close();
            }

        }

        private void rgInstanceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rgInstanceType.SelectedIndex == 1)
            {
                txtInstanceName.Enabled = true;
            }
            else
            {
                txtInstanceName.Enabled = false;
            }
        }

        private void rgAuthenticationMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rgAuthenticationMode.SelectedIndex == 1)
            {
                txtSAPassword.Enabled = true;
                txtSAPassworkConfirm.Enabled = true;
                gcSQLServerAdministrators.Enabled = true;
            }
            else
            {
                txtSAPassword.Enabled = false;
                txtSAPassworkConfirm.Enabled = false;
                gcSQLServerAdministrators.Enabled = false;

                txtSAPassword.Text = string.Empty;
                txtSAPassworkConfirm.Text = string.Empty;
            }
        }

        public class SQLServerAdministrators
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        private void xtraScrollableControl1_Click(object sender, EventArgs e)
        {

        }

        private void wcInstaller_SelectedPageChanged(object sender, DevExpress.XtraWizard.WizardPageChangedEventArgs e)
        {
            if (e.Page == wpConnection)
            {
                if (Convert.ToBoolean(rgInstanceType.EditValue) == true)
                {
                    ddlServer.EditValue = Environment.MachineName;
                }
                else
                {
                    ddlServer.EditValue = string.Format(@"{0}\{1}", Environment.MachineName, txtInstanceName.Text);
                }

                if (Convert.ToBoolean(rgAuthenticationMode.EditValue) == true)
                {
                    cbeAuthentication.EditValue = "Windows Authentication";
                }
                else
                {
                    cbeAuthentication.EditValue = "SQL Server Authentication";
                    txtUsername.EditValue = "sa";
                    txtPassword.EditValue = txtSAPassword.EditValue;
                }
            }
            else if (e.Page == wpImportConnection)
            {
                ddlOldCDSServer.EditValue = ddlServer.EditValue;
                cbeOldCDSAuthentication.EditValue = cbeAuthentication.EditValue;
                txtOldCDSUsername.EditValue = txtUsername.EditValue;
                txtOldCDSPassword.EditValue = txtPassword.EditValue;
            }
        }

        private void txtDatabaseName_EditValueChanged(object sender, EventArgs e)
        {
            txtDatabaseNameMasked.EditValue = txtDatabaseName.Text.ToLower().Replace(' ', '_');
        }

        string lastDefaultDirectory;

        private void bceDefaultDirectory_Leave(object sender, EventArgs e)
        {
            layoutControlGroup4.Invalidate();
            layoutControlGroup4.BeginUpdate();
            foreach (object item in lcgDatabaseFileLocations.Items)
            {
                if (item is DevExpress.XtraLayout.LayoutControlItem)
                {
                    if ((item as DevExpress.XtraLayout.LayoutControlItem).Control is DevExpress.XtraEditors.BreadCrumbEdit)
                    {
                        if (((item as DevExpress.XtraLayout.LayoutControlItem).Control as DevExpress.XtraEditors.BreadCrumbEdit).Path == string.Empty ||
                            ((item as DevExpress.XtraLayout.LayoutControlItem).Control as DevExpress.XtraEditors.BreadCrumbEdit).Path == lastDefaultDirectory)
                        {
                            ((item as DevExpress.XtraLayout.LayoutControlItem).Control as DevExpress.XtraEditors.BreadCrumbEdit).Properties.Nodes.Clear();
                            ((item as DevExpress.XtraLayout.LayoutControlItem).Control as DevExpress.XtraEditors.BreadCrumbEdit).Path = bceDefaultDirectory.Path;
                        }
                    }
                }
            }

            lastDefaultDirectory = bceDefaultDirectory.Path;

            layoutControlGroup4.EndUpdate();
        }

        private void grvSite_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //Entities.SYS_Entity row = ((Entities.SYS_Entity)(grvEntity.GetFocusedRow()));
            //row = Entities.SYS_Entity.NewSite;
            //row.CodeMain = string.Empty;
            //row.CodeSub = string.Empty;
            //row.CreatedBy = BL.ApplicationDataContext.Instance.LoggedInUser.PersonId;
            //row.TypeId = 10;
            //row.Site = new List<Entities.SYS_Site>();
            //Entities.SYS_Site site = Entities.SYS_Site.New;
            //Entities.SYS_Address billingAddress = Entities.SYS_Address.NewBillingAddress;
            //Entities.SYS_Address shippingAddress = Entities.SYS_Address.NewShippingAddress;
            //row.Addresses.ElementAt(0).Line1 = billingAddress.Line1;
            //row.Addresses.ElementAt(0).Line2 = billingAddress.Line2;
            //row.Addresses.ElementAt(0).Line3 = billingAddress.Line3;
            //row.Addresses.ElementAt(0).Code =  billingAddress.Code;

            //row.Addresses.ElementAt(1).Line1 = shippingAddress.Line1;
            //row.Addresses.ElementAt(1).Line2 = shippingAddress.Line2;
            //row.Addresses.ElementAt(1).Line3 = shippingAddress.Line3;
            //row.Addresses.ElementAt(1).Code = shippingAddress.Code;
            //row.Site.Add(site);
        }

        public static T Copy<T>(Object toClone, T toCloneInto)
        {
            var properties = toClone.GetType().GetProperties();
            foreach (var property in properties)
            {
                //Will skip and Collections of Entities en Entities
                //Will only copy primitive types
                if (property.PropertyType.Namespace == "System.Collections.Generic" || (property.PropertyType.Namespace == "CDS.Client.DataAccessLayer.DB"))
                    continue;

                //Werner Scheffer
                //NEVER EXCLUDE Id I'm using it on Jobs to identify what line the deleted line comes from
                if (!(new string[] { "CreatedBy", "HasChanges" }).Any(n => n.Equals(property.Name)))
                {
                    //Check if there is a Set
                    if (property.CanWrite)
                    {
                        var value = property.GetValue(toClone);
                        if (toCloneInto.GetType().GetProperty(property.Name) != null)
                            toCloneInto.GetType().GetProperty(property.Name).SetValue(toCloneInto, value);
                    }
                }

                if (property.Name == "CreatedBy")
                {
                    toCloneInto.GetType().GetProperty(property.Name).SetValue(toCloneInto, BL.ApplicationDataContext.Instance.LoggedInUser.PersonId);
                }

                ////Werner Scheffer
                ////NEVER EXCLUDE Id I'm using it on Jobs to identify what line the deleted line comes from
                //if (!property.Name.Equals("CreatedOn") || !property.Name.Equals("CreatedBy"))
                //{
                //    var value = property.GetValue(toClone);
                //    property.SetValue(toCloneInto, value);
                //}
            }
            return toCloneInto;
        }

        private void txtCompanyConnectionName_EditValueChanged(object sender, EventArgs e)
        {
            txtDatabase.EditValue = txtCompanyConnectionName.Text.ToLower().Replace(' ', '_');
            txtDatabaseName.EditValue = txtCompanyConnectionName.EditValue;
            txtDatabaseNameMasked.EditValue = txtDatabaseName.Text.ToLower().Replace(' ', '_');
        }

        private void cbeAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUsername.ReadOnly = cbeAuthentication.SelectedIndex == 0;
            txtPassword.ReadOnly = cbeAuthentication.SelectedIndex == 0;
        }

    }
}