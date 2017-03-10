using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils.Editors;
using DevExpress.XtraEditors.DXErrorProvider;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;


namespace CDS.Client.Desktop.Essential.UTL
{
    public class CustomValidationRuleTextEdit : DevExpress.XtraEditors.DXErrorProvider.ValidationRule
    {
        public CustomValidationRuleTextEdit() { }
        public CustomValidationRuleTextEdit(string name) { Name = name; }
        public CustomValidationRuleTextEdit(string name, ConditionOperator op) { Name = name; ConditionOperator = op; }
        public CustomValidationRuleTextEdit(string name, ConditionOperator op, ICollection values) { Name = name; ConditionOperator = op; Values = ((ArrayList)values); }
        public CustomValidationRuleTextEdit(string name, ConditionOperator op, object value) { }
        public CustomValidationRuleTextEdit(string name, ConditionOperator op, object value1, object value2) { }

        public String Name { get; set; }
        public ConditionOperator ConditionOperator { get; set; }
        [DefaultValue("")]
        [Editor(typeof(UIObjectEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ObjectEditorTypeConverter))]
        public object Value1 { get; set; }
        [DefaultValue("")]
        [Editor(typeof(UIObjectEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ObjectEditorTypeConverter))]
        public object Value2 { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design", typeof(UITypeEditor))]
        public ArrayList Values { get; set; }

        public override bool Validate(Control control, object value)
        {
            bool valid = true;
            if (value != null)
            switch (ConditionOperator)
            {
                case ConditionOperator.None:
                    valid = true;
                    break;
                case ConditionOperator.Equals:
                    valid = value.ToString().Equals(Value1);
                    break;
                case ConditionOperator.NotEquals:
                    valid = !value.ToString().Equals(Value1);
                    break;
                case ConditionOperator.Between:
                    valid = value.ToString().CompareTo(Value1) >= 0 && value.ToString().CompareTo(Value1) < 0;
                    break;
                case ConditionOperator.NotBetween:
                    valid = !(value.ToString().CompareTo(Value1) >= 0 && value.ToString().CompareTo(Value1) < 0);
                    break;
                case ConditionOperator.Less:
                    valid = value.ToString().CompareTo(Value1) < 0;
                    break;
                case ConditionOperator.Greater:
                    valid = value.ToString().CompareTo(Value1) > 0;
                    break;
                case ConditionOperator.GreaterOrEqual:
                    valid = value.ToString().CompareTo(Value1) >= 0;
                    break;
                case ConditionOperator.LessOrEqual:
                    valid = value.ToString().CompareTo(Value1) <= 0;
                    break;
                case ConditionOperator.BeginsWith:
                    valid = value.ToString().StartsWith(Value1.ToString());
                    break;
                case ConditionOperator.EndsWith:
                    valid = value.ToString().EndsWith(Value1.ToString());
                    break;
                case ConditionOperator.Contains:
                    valid = Values.Contains(value);
                    break;
                case ConditionOperator.NotContains:
                    valid = !Values.Contains(value);
                    break;
                case ConditionOperator.Like:
                    //valid = !value.Contains(Value1);
                    break;
                case ConditionOperator.NotLike:
                    break;
                case ConditionOperator.IsBlank:
                    break;
                case ConditionOperator.IsNotBlank:
                    break;
                case ConditionOperator.AnyOf:
                    break;
                case ConditionOperator.NotAnyOf:
                    break;
            }
            return valid;
        }
    }
}
