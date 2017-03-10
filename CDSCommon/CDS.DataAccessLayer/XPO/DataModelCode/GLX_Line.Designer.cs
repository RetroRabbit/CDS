//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.DataAccessLayer.XPO.Datamodel
{

    [Persistent(@"CDS_GLX.GLX_Line")]
    public partial class GLX_Line : XPLiteObject
    {
        long fId;
        [Key(true)]
        public long Id
        {
            get { return fId; }
            set { SetPropertyValue<long>("Id", ref fId, value); }
        }
        GLX_Header fHeaderId;
        [Association(@"GLX_LineReferencesGLX_Header")]
        public GLX_Header HeaderId
        {
            get { return fHeaderId; }
            set { SetPropertyValue<GLX_Header>("HeaderId", ref fHeaderId, value); }
        }
        SYS_Entity fEntityId;
        [Association(@"GLX_LineReferencesSYS_Entity")]
        public SYS_Entity EntityId
        {
            get { return fEntityId; }
            set { SetPropertyValue<SYS_Entity>("EntityId", ref fEntityId, value); }
        }
        GLX_Recon fReconId;
        [Association(@"GLX_LineReferencesGLX_Recon")]
        public GLX_Recon ReconId
        {
            get { return fReconId; }
            set { SetPropertyValue<GLX_Recon>("ReconId", ref fReconId, value); }
        }
        GLX_Tax fTaxId;
        [Association(@"GLX_LineReferencesGLX_Tax")]
        public GLX_Tax TaxId
        {
            get { return fTaxId; }
            set { SetPropertyValue<GLX_Tax>("TaxId", ref fTaxId, value); }
        }
        SYS_Entity fCenterId;
        [Association(@"GLX_LineReferencesSYS_Entity1")]
        public SYS_Entity CenterId
        {
            get { return fCenterId; }
            set { SetPropertyValue<SYS_Entity>("CenterId", ref fCenterId, value); }
        }
        GLX_Aging fAgingId;
        [Association(@"GLX_LineReferencesGLX_Aging")]
        public GLX_Aging AgingId
        {
            get { return fAgingId; }
            set { SetPropertyValue<GLX_Aging>("AgingId", ref fAgingId, value); }
        }
        decimal fAmount;
        public decimal Amount
        {
            get { return fAmount; }
            set { SetPropertyValue<decimal>("Amount", ref fAmount, value); }
        }
        DateTime fCreatedOn;
        [NonPersistent]
        public DateTime CreatedOn
        {
            get { return fCreatedOn; }
            set { SetPropertyValue<DateTime>("CreatedOn", ref fCreatedOn, value); }
        }
        SYS_Person fCreatedBy;
        [Association(@"GLX_LineReferencesSYS_Person")]
        public SYS_Person CreatedBy
        {
            get { return fCreatedBy; }
            set { SetPropertyValue<SYS_Person>("CreatedBy", ref fCreatedBy, value); }
        }
        DateTime fDate;
        public DateTime Date
        {
            get { return fDate; }
            set { SetPropertyValue<DateTime>("Date", ref fDate, value); }
        }
    }

}