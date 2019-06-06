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
    
    
    public partial class SYS_Printer : INotifyPropertyChanged, IBaseEntity
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
     
        public SYS_Printer()
        {
            this.SYS_Site = new List<SYS_Site>();
            this.SYS_Site1 = new List<SYS_Site>();
            this.SYS_Site2 = new List<SYS_Site>();
        }
    
        private long id;
        private string name;
        private string location;
        private string printerType;
        private string printerModel;
        private bool archived;
        private Nullable<System.DateTime> createdOn;
        private Nullable<long> createdBy;
    
        public long Id 
    	{ 
    		get { return id; }
    		set { SetProperty(ref id, value); }
    	 }
        public string Name 
    	{ 
    		get { return name; }
    		set { SetProperty(ref name, value); }
    	 }
        public string Location 
    	{ 
    		get { return location; }
    		set { SetProperty(ref location, value); }
    	 }
        public string PrinterType 
    	{ 
    		get { return printerType; }
    		set { SetProperty(ref printerType, value); }
    	 }
        public string PrinterModel 
    	{ 
    		get { return printerModel; }
    		set { SetProperty(ref printerModel, value); }
    	 }
        public bool Archived 
    	{ 
    		get { return archived; }
    		set { SetProperty(ref archived, value); }
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
    
        
    	public virtual SYS_Person SYS_Person { get; set; }
        [System.Xml.Serialization.XmlIgnore]
    	public virtual ICollection<SYS_Site> SYS_Site { get; set; }
        [System.Xml.Serialization.XmlIgnore]
    	public virtual ICollection<SYS_Site> SYS_Site1 { get; set; }
        [System.Xml.Serialization.XmlIgnore]
    	public virtual ICollection<SYS_Site> SYS_Site2 { get; set; }
    }
}