//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CDS.Client.DataAccessLayer.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    
    public partial class ITM_InventorySupplier : INotifyPropertyChanged, IBaseEntity
    { 
    	bool hasChanges = false;
        public bool HasChanges
        {
        	get
        	{
                return hasChanges;
        	}
        	set
        	{
                if (hasChanges != value)
                    hasChanges = value;
        	}
        } 
    	
    	bool ignoreChanges = false;
        public bool IgnoreChanges
        {
            get
            {
                
                
                return ignoreChanges;
            }
            set
            {
                if (ignoreChanges != value)
                {
                    ignoreChanges = value;
                }
            }
        }
    
    	List<string> changeList = new List<string>();
    	[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public List<string> ChangeList
        {
            get
            { 
                return changeList;
            }
            set
            {
                if (changeList != value)
                {
                    changeList = value;
                }
            }
        } 
    
    	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged; 
    	private void SetProperty<T>(ref T field, T value, [System.Runtime.CompilerServices.CallerMemberName] string name = "")
    	{
    		if (!EqualityComparer<T>.Default.Equals(field, value))
    		{
    			field = value;
    			//ChangeSet.Add(LogEntry.New<T>(field.ToString(),this.ToString(), this.Id,  field,  value ));
    			var handler = PropertyChanged;
    			if (handler != null)
    			{
    				if(!name.StartsWith("Id") && name != "Title" && name != "CreatedOn" && !IgnoreChanges)  
    				{
    					HasChanges = true;
    					ChangeList.Add(name);
    				}
    
    				handler(this, new System.ComponentModel.PropertyChangedEventArgs(name));
    			}
    		}
    	} 
     
        private long id;
        private long inventoryId;
        private long supplierId;
        private Nullable<byte> leadTime;
        private string supplierStockCode;
        private Nullable<decimal> minimumOrderLevel;
        private Nullable<decimal> maximumOrderLevel;
        private Nullable<decimal> packSize;
        private Nullable<bool> primarySupplier;
        private Nullable<decimal> unitAverage;
        private Nullable<decimal> available;
        private Nullable<System.DateTime> lastQueried;
        private Nullable<System.DateTime> createdOn;
        private Nullable<long> createdBy;
    
        public long Id 
    	{ 
    		get { return id; }
    		set { SetProperty(ref id, value); }
    	 }
        public long InventoryId 
    	{ 
    		get { return inventoryId; }
    		set { SetProperty(ref inventoryId, value); }
    	 }
        public long SupplierId 
    	{ 
    		get { return supplierId; }
    		set { SetProperty(ref supplierId, value); }
    	 }
        public Nullable<byte> LeadTime 
    	{ 
    		get { return leadTime; }
    		set { SetProperty(ref leadTime, value); }
    	 }
        public string SupplierStockCode 
    	{ 
    		get { return supplierStockCode; }
    		set { SetProperty(ref supplierStockCode, value); }
    	 }
        public Nullable<decimal> MinimumOrderLevel 
    	{ 
    		get { return minimumOrderLevel; }
    		set { SetProperty(ref minimumOrderLevel, value); }
    	 }
        public Nullable<decimal> MaximumOrderLevel 
    	{ 
    		get { return maximumOrderLevel; }
    		set { SetProperty(ref maximumOrderLevel, value); }
    	 }
        public Nullable<decimal> PackSize 
    	{ 
    		get { return packSize; }
    		set { SetProperty(ref packSize, value); }
    	 }
        public Nullable<bool> PrimarySupplier 
    	{ 
    		get { return primarySupplier; }
    		set { SetProperty(ref primarySupplier, value); }
    	 }
        public Nullable<decimal> UnitAverage 
    	{ 
    		get { return unitAverage; }
    		set { SetProperty(ref unitAverage, value); }
    	 }
        public Nullable<decimal> Available 
    	{ 
    		get { return available; }
    		set { SetProperty(ref available, value); }
    	 }
        public Nullable<System.DateTime> LastQueried 
    	{ 
    		get { return lastQueried; }
    		set { SetProperty(ref lastQueried, value); }
    	 }
        public Nullable<System.DateTime> CreatedOn 
    	{ 
    		get { return createdOn; }
    		set { SetProperty(ref createdOn, value); }
    	 }
        public Nullable<long> CreatedBy 
    	{ 
    		get { return createdBy; }
    		set { SetProperty(ref createdBy, value); }
    	 }
    }
}
