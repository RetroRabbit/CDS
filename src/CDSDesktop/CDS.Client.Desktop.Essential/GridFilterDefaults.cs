using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS.Client.Desktop.Essential
{
    public class GridFilterDefaults
    {

        public static void ApplyStandards(List<GridView> gridViews)
        {
            gridViews.ForEach(n => ApplyStandards(n));
        }

        public static void ApplyStandards(GridView gridView)
        {
            gridView.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;

            //GridView.BestFitColumns();                
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridView.Columns)
            {

                column.OptionsFilter.ImmediateUpdateAutoFilter = false;
                if (column.ColumnType == typeof(String))
                {
                    column.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                    column.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
                }
                else if (column.ColumnType == typeof(int)
                    || column.ColumnType == typeof(decimal)
                    || column.ColumnType == typeof(double)
                    || column.ColumnType == typeof(long)
                    || column.ColumnType == typeof(int?)
                    || column.ColumnType == typeof(decimal?)
                    || column.ColumnType == typeof(double?)
                    || column.ColumnType == typeof(long?))
                {
                    column.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals;
                }
                else if (column.ColumnType == typeof(DateTime?) || column.ColumnType == typeof(DateTime))
                {
                    //Werner : This mode is in effect for columns displaying date-time values. It consists of a calendar, like the Date mode, plus check boxes that allow used date intervals to be selected. If there is no underlying data that would fall into a specific date range, the corresponding check box is hidden.
                    column.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateAlt;
                    //column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    //column.DisplayFormat.FormatString = "D";
                }

                if (column.Caption.Equals("Archived"))
                {
                    gridView.ActiveFilterString = String.Format("[{0}] = False", column.FieldName);
                }
            }
        }
    }
}
