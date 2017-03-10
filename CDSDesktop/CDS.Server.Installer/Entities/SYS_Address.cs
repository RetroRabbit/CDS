//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CDS.Server.Installer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;


    public partial class SYS_Address : INotifyPropertyChanged
    { 

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

                    handler(this, new System.ComponentModel.PropertyChangedEventArgs(name));
                }
            }
        }

        public SYS_Address()
        { 
        }

        private long id;
        private byte typeId;
        private string line1;
        private string line2;
        private string line3;
        private string line4;
        private string code;
        private string title;
        private Nullable<System.DateTime> createdOn;
        private Nullable<long> createdBy;

        public long Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }
        public byte TypeId
        {
            get { return typeId; }
            set { SetProperty(ref typeId, value); }
        }
        public string Line1
        {
            get { return line1; }
            set { SetProperty(ref line1, value); }
        }
        public string Line2
        {
            get { return line2; }
            set { SetProperty(ref line2, value); }
        }
        public string Line3
        {
            get { return line3; }
            set { SetProperty(ref line3, value); }
        }
        public string Line4
        {
            get { return line4; }
            set { SetProperty(ref line4, value); }
        }
        public string Code
        {
            get { return code; }
            set { SetProperty(ref code, value); }
        }
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
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

        public static SYS_Address NewBillingAddress
        {
            get
            {
                SYS_Address entry = new SYS_Address();
                entry.Title = "Billing Address";
                entry.TypeId = 1;
                return entry;
            }
        }

        public static SYS_Address NewShippingAddress
        {
            get
            {
                SYS_Address entry = new SYS_Address();
                entry.Title = "Shipping Address";
                entry.TypeId = 2;
                return entry;
            }
        }
    }
}