using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.Client.Desktop.Catalogue.CAT
{
    #region EntryItem Category Class
    public class EntryItemCategory
    {
        public Int64 ItemId { get; set; }
        public Int64 CategoryId { get; set; }
        public String ItemName { get; set; }
        public String CategoryName { get; set; }
        public String StockCode { get; set; }
    }
    #endregion

    #region EntryMeta Class
    public class EntryMeta
    {
        public Int64 Id { get; set; }
        public Int64 CategoryId { get; set; }
        public String Grouping { get; set; }
        public String Name { get; set; }
        public Object Value { get; set; }
        public String Type { get; set; }
    }
    #endregion

    #region Entry Meta Data Class
    public class EntryMetaData
    {
        public Int64 Id { get; set; }
        public Int64 CategoryId { get; set; }
        public String ItemName { get; set; }
        public String Grouping { get; set; }
        public String Name { get; set; }
        public Object Value { get; set; }
        public String Type { get; set; }
    }

    public class MetaType
    {
        public Int64 Id { get; set; }
        public String Name { get; set; }
    }
    #endregion

    #region Item With Meta Class
    public class ItemWithMeta
    {
        public Int64 Id;
        public String Name;
        public Dictionary<String, String> Meta;

        public ItemWithMeta(Int64 Id, String Name)
        {
            this.Id = Id;
            this.Name = Name;
            this.Meta = new Dictionary<string, string>();
        }

        public ItemWithMeta AddMeta(String Key, String Value)
        {
            this.Meta.Add(Key, Value);
            return this;
        }
    }
    #endregion

    #region CategoryItem
    public class CategoryItem
    {
        public Int64 Id;
        public String Name;
        public Int64? CategoryId;
        public String Items;

        public CategoryItem()
        {
        }
    }
    #endregion
}
