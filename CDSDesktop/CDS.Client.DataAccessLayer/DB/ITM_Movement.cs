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
    
    
    public partial class ITM_Movement : INotifyPropertyChanged, IBaseEntity
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
        private long lineId;
        private Nullable<decimal> onHand;
        private Nullable<decimal> onOrder;
        private Nullable<decimal> onReserve;
        private Nullable<decimal> unitCost;
        private Nullable<decimal> unitPrice;
        private Nullable<decimal> unitAverage;
        private Nullable<decimal> newUnitCost;
        private Nullable<decimal> newUnitPrice;
        private Nullable<decimal> newUnitAverage;
        private Nullable<System.DateTime> createdOn;
        private Nullable<long> createdBy;
        private Nullable<decimal> onHold;
    
        public long Id 
    	{ 
    		get { return id; }
    		set { SetProperty(ref id, value); }
    	 }
        public long LineId 
    	{ 
    		get { return lineId; }
    		set { SetProperty(ref lineId, value); }
    	 }
        public Nullable<decimal> OnHand 
    	{ 
    		get { return onHand; }
    		set { SetProperty(ref onHand, value); }
    	 }
        public Nullable<decimal> OnOrder 
    	{ 
    		get { return onOrder; }
    		set { SetProperty(ref onOrder, value); }
    	 }
        public Nullable<decimal> OnReserve 
    	{ 
    		get { return onReserve; }
    		set { SetProperty(ref onReserve, value); }
    	 }
        public Nullable<decimal> UnitCost 
    	{ 
    		get { return unitCost; }
    		set { SetProperty(ref unitCost, value); }
    	 }
        public Nullable<decimal> UnitPrice 
    	{ 
    		get { return unitPrice; }
    		set { SetProperty(ref unitPrice, value); }
    	 }
        public Nullable<decimal> UnitAverage 
    	{ 
    		get { return unitAverage; }
    		set { SetProperty(ref unitAverage, value); }
    	 }
        public Nullable<decimal> NewUnitCost 
    	{ 
    		get { return newUnitCost; }
    		set { SetProperty(ref newUnitCost, value); }
    	 }
        public Nullable<decimal> NewUnitPrice 
    	{ 
    		get { return newUnitPrice; }
    		set { SetProperty(ref newUnitPrice, value); }
    	 }
        public Nullable<decimal> NewUnitAverage 
    	{ 
    		get { return newUnitAverage; }
    		set { SetProperty(ref newUnitAverage, value); }
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
        public Nullable<decimal> OnHold 
    	{ 
    		get { return onHold; }
    		set { SetProperty(ref onHold, value); }
    	 }
    }
}
