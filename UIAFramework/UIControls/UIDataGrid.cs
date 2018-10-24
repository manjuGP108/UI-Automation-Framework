using System.Windows.Automation;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UIAFramework
{
    public class UIDataGrid : ControlBase
    {
        public UIDataGrid() { }

        public UIDataGrid(string condition, string treescope, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("datagrid");
        }

        public UIDataGrid(string condition, string treescope, AutomationElement ae, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope, ae, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("datagrid");
        }

        public UIDataGrid(string treePath, bool isPath, [CallerMemberName] string memberName = "")
            : base(treePath, isPath, memberName)
        {
            ParentBase.controlType = Common.GetControlType("datagrid");
        }

        public UIDataGrid(string treePath, bool isPath, AutomationElement ae, [CallerMemberName] string memberName = "")
            : base(treePath, isPath, ae, memberName)
        {
            ParentBase.controlType = Common.GetControlType("datagrid");
        }

        public UIDataGrid(AutomationElement ae, [CallerMemberName] string memberName = "")
            : base(ae, memberName)
        {
            ParentBase.controlType = Common.GetControlType("datagrid");
        }
        

            
           public UIDataGrid(string condition, string treescope, bool isMultipleControl, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            :base(condition,treescope,isMultipleControl,type,memberName)
        {
            ParentBase.controlType = Common.GetControlType("datagrid");
        }

           public UIDataGrid(string condition, string treescope, AutomationElement ae, bool isMultipleControl, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope,ae, isMultipleControl, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("datagrid");
        }
           public UIDataGrid(AutomationElement ae)
               : base(ae)
           {
           }
        #region Actions

        public int GetGridRows
        {
            get { return UnWrap().GetGridPattern().Current.RowCount; }
        }

        /*METHODS FOR A DATAGRID WHICH HAS STRUCTURE AS FOLLOWS: Datagrid--> [Header (Child), [DataItems(child)-->Custom]] */

        public int NumberofDataItemRows()
        {
            AutomationElementCollection dataItems = UnWrap().FindAll(TreeScope.Children, Common.GetPropertyCondition("ControlType=dataitem"));
            return dataItems.Count;
        }

        /// <summary>
        /// Clicks on Data grid cell based on rowNo and colNo and single or double click
        /// </summary>
        public void ClickOnCell(int row, int column, int singleOrDoubleClick)
        {

            AutomationElement ae = UnWrap().FindElementOnDescendants("dataitem[" + row + "]/custom[" + column + "]", true);

            MouseClickonCell(ae, singleOrDoubleClick);

        }

        /// <summary>
        /// Gets Data grid cell based on Cell value and cellNo
        /// </summary>
        /// <param name="cellValue"></param>
        /// <param name="cellNumber"></param>
        /// <returns></returns>
        public int GetCell(string cellValue, int cellNumber)
        {
            bool found = false;
            int dataitemno = 0;
            AutomationElementCollection dataItems = UnWrap().FindAll(TreeScope.Children, Common.GetPropertyCondition("ControlType=dataitem"));
            foreach (AutomationElement item in dataItems)
            {
                dataitemno++;
                AutomationElement column = item.FindElement("custom[" + cellNumber + "]", true);
                if (column.GetValuePattern().Current.Value.Contains(cellValue))
                { found = true; break; }
            }
            if (found)
                return dataitemno;
            else
                throw new Exception(cellValue + " cell value not found in the element.");

        }


        private void MouseClickonCell(AutomationElement ae, int SingleOrDouble)
        {

            int x = ((int)ae.Current.BoundingRectangle.X + (int)ae.Current.BoundingRectangle.Right) / 2;
            int y = ((int)ae.Current.BoundingRectangle.Y + (int)ae.Current.BoundingRectangle.Bottom) / 2;
            Point p = new Point(x, y);
            if (SingleOrDouble == 1)
                Mouse.Click(p.X, p.Y);
            else
                Mouse.DoubleClick(p.X, p.Y);
            UIAWait.WaitFor(1);
        }



        /// <summary>
        /// Gets number of columns of Data grid
        /// </summary>
        public int GetColumnCount()
        {

            return UnWrap().GetGridPattern().Current.ColumnCount;

        }

        /// <summary>
        /// Gets number of Rows of Data grid
        /// </summary>
        public int GetRowCount()
        {
            return UnWrap().GetGridPattern().Current.RowCount;
        }

        /// <summary>
        /// Gets the Data grid cell value based on rowNo and column Name
        /// </summary>
        public string GetCellValue(int rowNumber, string ColumName)
        {
            AutomationElement element = null;
            GridPattern gp = UnWrap().GetGridPattern();
            for (int i = 0; i < gp.Current.ColumnCount; i++)
            {
                AutomationElement cell = gp.GetItem(rowNumber, i);
                TableItemPattern tp = cell.GetTableItemPattern();

                AutomationElement[] colheaderItems = tp.Current.GetColumnHeaderItems();

                foreach (AutomationElement m in colheaderItems)
                {
                    if (m.Current.Name.Contains(ColumName))
                        element = cell;
                    break;
                }
                if (element != null)
                    break;
            }
            AutomationElement aechild = element.FindElement("text[1]", true);
            if (aechild == null || aechild.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString().Trim() == "")
                return element.GetValuePattern().Current.Value.Trim();
            else
                return aechild.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString();
        }

        public string GetCellValue_ByAutomationId(int rowNumber, string automationId)
        {
            AutomationElement element = UnWrap().FindFirst(TreeScope.Descendants, Common.GetPropertyCondition("AutomationId=" + automationId));
            return element.GetValuePattern().Current.Value.Trim();
        }

        /// <summary>
        /// Gets column headers of Data grid
        /// </summary>
        public List<string> GetColumnHeaders()
        {
            List<string> colHeadersNames = new List<string>();

            TablePattern gp = UnWrap().GetTablePattern();
            AutomationElement[] colHeaders = gp.Current.GetColumnHeaders();


            foreach (AutomationElement collHeader in colHeaders)
            {
                colHeadersNames.Add(collHeader.Current.Name);
            }

            return colHeadersNames;
        }

        /// <summary>
        /// Gets the cell of Data grid based on rowNo and columnName
        /// </summary>
        public UIDataGridItem GetCell(int row, String col)
        {
            GridPattern gp = UnWrap().GetGridPattern();
            for (int i = 0; i < gp.Current.ColumnCount; i++)
            {
                AutomationElement cell = gp.GetItem(row, i);
                TableItemPattern tp = cell.GetTableItemPattern();
                AutomationElement[] colheaderItems = tp.Current.GetColumnHeaderItems();

                foreach (AutomationElement m in colheaderItems)
                {
                    if (m.Current.Name.Contains(col))
                        return new UIDataGridItem(cell);
                }

            }
            throw new Exception("The cell with column name " + col + " with row no. " + row + " does not exists in the specified context ");
        }

        /// <summary>
        /// Gets the cell of Data grid based on rowNo and columnNo
        /// </summary>
        public UIDataGridItem GetCell(int row, int col)
        {
            GridPattern gp = UnWrap().GetGridPattern();
            return new UIDataGridItem(gp.GetItem(row, col));
        }

        /// <summary>
        /// Gets the Element present with in Data grid cell based on IdentifyingProperty,column Name and current row count
        /// <param name="IdentifyingProperty">The Identifying Property with property type and property name</param>
        /// <param name="columnName">The column name</param>
        /// <param name="currentRowCount">The current Row Count</param>
        /// </summary>
        public TT GetElementFromDataGridCell<TT>(string IdentifyingProperty, string columnName, out int currentRowCount)
        {
            currentRowCount = 0;
            string name = IdentifyingProperty.Substring(IdentifyingProperty.IndexOf('=') + 1);
            UIDataGrid dg = new UIDataGrid(UnWrap());
            int count = dg.GetRowCount();
            Condition Property = Common.GetPropertyCondition(IdentifyingProperty);

            while (currentRowCount < count)
            {
                UIDataGridItem dataGridCell = dg.GetCell(currentRowCount, columnName);

                AutomationElement dataGridCellElement = dataGridCell.NativeElement.FindFirst(TreeScope.Descendants, Property);
                if (dataGridCellElement != null)
                {
                    if (dataGridCellElement.Current.ClassName == "TextBox")
                    {
                        if (dataGridCellElement.GetValuePattern().Current.Value == name)
                        {
                            return (TT)Activator.CreateInstance(typeof(TT), new object[] { dataGridCellElement });
                        }
                    }
                    else if (dataGridCellElement.Current.Name == name)
                    {
                        return (TT)Activator.CreateInstance(typeof(TT), new object[] { dataGridCellElement });
                    }
                }
                currentRowCount++;
                System.Threading.Thread.Sleep(100);
                dg.Scroll(UIAEnums.ScrollLimit.SmallIncrementVertical);
            }
            throw new Exception("The element with Identifying Property " + IdentifyingProperty + " does not exists in the mentioned context ");
        }
    }


        #endregion
}

