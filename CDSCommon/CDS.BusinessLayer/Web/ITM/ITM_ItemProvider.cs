using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using DAL = CDS.DataAccessLayer.XPO;
using PORT = CDS.DataAccessLayer.Portable;

namespace CDS.BusinessLayer.Web.ITM
{
    public static class ITM_ItemProvider
    {
        public static List<PORT.Item> GetItems(string connectionString, byte typeId)
        {
            DAL.Enums.SYS_Type type = (DAL.Enums.SYS_Type)typeId;
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.ConnectionString = connectionString;
                uow.Connect();

                if (type == DAL.Enums.SYS_Type.Account)
                {
                    XPQuery<DAL.Datamodel.GLX_Account> items = uow.Query<DAL.Datamodel.GLX_Account>();
                    return items.Where(a => a.AccountTypeId == DAL.Enums.GLX_Type.Expenses || a.AccountTypeId == DAL.Enums.GLX_Type.Sales)
                        .Select(n => new PORT.Item { id = n.EntityId.Id, name = n.EntityId.Name, codeMain = n.EntityId.CodeMain, codeSub = n.EntityId.CodeSub, description = n.EntityId.Description, shortName = n.EntityId.ShortName })
                        .ToList();
                }
                else
                {
                    XPQuery<DAL.Datamodel.SYS_Entity> items = uow.Query<DAL.Datamodel.SYS_Entity>();
                    return items.Where(c => c.TypeId == type)
                        .Select(n => new PORT.Item { id = n.Id, name = n.Name, codeMain = n.CodeMain, codeSub = n.CodeSub, description = n.Description, shortName = n.ShortName })
                        .ToList();

                }
            }
        }
    }
}
