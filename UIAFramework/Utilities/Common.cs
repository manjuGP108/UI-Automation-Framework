using System;
using System.Collections.Generic;
using System.Windows.Automation;

namespace UIAFramework
{
    public static class Common
    {
        public static string SearchAttribute = string.Empty;
        /// <summary>
        /// Returns the ControlType of the control for the string control being sent.
        /// </summary>
        public static ControlType GetControlType(string controlName)
        {
            string tag = controlName.ToLower().Trim();
            switch (tag)
            {
                case "pane":
                    return ControlType.Pane;
                case "custom":
                    return ControlType.Custom;
                case "combobox":
                    return ControlType.ComboBox;
                case "tab":
                    return ControlType.Tab;
                case "tabitem":
                    return ControlType.TabItem;
                case "listview":
                    return ControlType.List;
                case "listitem":
                    return ControlType.ListItem;
                case "window":
                    return ControlType.Window;
                case "menu":
                    return ControlType.Menu;
                case "menuitem":
                    return ControlType.MenuItem;
                case "button":
                    return ControlType.Button;
                case "edit":
                    return ControlType.Edit;
                case "calendar":
                    return ControlType.Calendar;
                case "checkbox":
                    return ControlType.CheckBox;
                case "datagrid":
                    return ControlType.DataGrid;
                case "dataitem":
                    return ControlType.DataItem;
                case "document":
                    return ControlType.Document;
                case "group":
                    return ControlType.Group;
                case "header":
                    return ControlType.Header;
                case "headeritem":
                    return ControlType.HeaderItem;
                case "hyperlink":
                    return ControlType.Hyperlink;
                case "image":
                    return ControlType.Image;
                case "list":
                    return ControlType.List;
                case "menubar":
                    return ControlType.MenuBar;
                case "progressbar":
                    return ControlType.ProgressBar;
                case "radiobutton":
                    return ControlType.RadioButton;
                case "scrollbar":
                    return ControlType.ScrollBar;
                case "separator":
                    return ControlType.Separator;
                case "slider":
                    return ControlType.Slider;
                case "spinner":
                    return ControlType.Spinner;
                case "splitbutton":
                    return ControlType.SplitButton;
                case "statusbar":
                    return ControlType.StatusBar;
                case "table":
                    return ControlType.Table;
                case "text":
                    return ControlType.Text;
                case "thumb":
                    return ControlType.Thumb;
                case "titlebar":
                    return ControlType.TitleBar;
                case "toolbar":
                    return ControlType.ToolBar;
                case "tooltip":
                    return ControlType.ToolTip;
                case "tree":
                    return ControlType.Tree;
                case "treeitem":
                    return ControlType.TreeItem;
                default:
                    throw new Exception("ControlType <" + tag + "> does not exist.");
            }
        }

        /// <summary>
        /// Returns the TreeScope type for the string treescope being sent.
        /// </summary>
        public static TreeScope GetTreeScope(string treescope)
        {
            TreeScope ts = TreeScope.Descendants;
            switch (treescope.Trim().ToUpper())
            {
                case "ELEMENT":
                    ts = TreeScope.Element;
                    break;
                case "CHILDREN":
                    ts = TreeScope.Children;
                    break;
                case "DESCENDANTS":
                    ts = TreeScope.Descendants;
                    break;
                case "SUBTREE":
                    ts = TreeScope.Subtree;
                    break;
                case "PARENT":
                    ts = TreeScope.Parent;
                    break;
                case "ANCESTORS":
                    ts = TreeScope.Ancestors;
                    break;
                default:
                    throw new Exception("Invalid entry for TreeScope");
            }
            return ts;
        }
        /// <summary>
        /// Returns the property condition for the string property condition being sent.
        /// </summary>
        public static Condition GetPropertyCondition(string conditionString, UIAEnums.ConditionType? type = null)
        {
            Condition condition = null;
            List<Condition> conditionList = new List<Condition>();


            string[] conditionAttributes = { conditionString };
            SearchAttribute = conditionString;
            if (conditionString.Contains(";"))
            {
                conditionAttributes = conditionString.Split(';');

                foreach (string id in conditionAttributes)
                {
                    conditionList.Add(GetProperty(id));
                }
                condition = GetConditions(conditionList.ToArray(), type);
            }
            else
            {
                condition = GetProperty(conditionString);
            }

            return condition;
        }

        private static Condition GetProperty(string conditionAttribute)
        {
            Condition condition1 = null;
            string[] idAttributes = conditionAttribute.Split('=');
            AutomationProperty autoationProperty;

            switch (idAttributes[0])
            {
                case "AutomationId":
                    autoationProperty = AutomationElement.AutomationIdProperty;
                    break;
                case "ClassName":
                    autoationProperty = AutomationElement.ClassNameProperty;
                    break;
                case "ControlType":
                    autoationProperty = AutomationElement.ControlTypeProperty;

                    break;
                case "Name":
                    autoationProperty = AutomationElement.NameProperty;
                    break;
                case "LocalizedControlType":
                    autoationProperty = AutomationElement.LocalizedControlTypeProperty;
                    break;
                default:
                    throw new Exception("Property parameter <" + idAttributes[0] + "> does not exist.");
                    break;

            }

            if (idAttributes[0] == "ControlType")
            {
                condition1 = new PropertyCondition(autoationProperty, Common.GetControlType(idAttributes[1]));
            }
            else
            {
                condition1 = new PropertyCondition(autoationProperty, idAttributes[1]);
            }
            return condition1;
        }

        public static Condition GetConditions(Condition[] conditionList, UIAEnums.ConditionType? type = null)
        {
            Condition condition = null;
            switch (type)
            {
                case UIAEnums.ConditionType.And:
                    condition = new AndCondition(conditionList);
                    break;
                case UIAEnums.ConditionType.Or:
                    condition = new OrCondition(conditionList);
                    break;
                case UIAEnums.ConditionType.Not:
                    condition = new NotCondition(conditionList[0]);
                    break;

                default:
                    break;
            }
            return condition;
        }

        public static AutomationProperty GetAutomationProperty(string attribute)
        {
            AutomationProperty property = null;
            switch (attribute)
            {
                case "AutomationId":
                    property = AutomationElement.AutomationIdProperty;
                    break;
                case "ClassName":
                    property = AutomationElement.ClassNameProperty;
                    break;
                case "ControlType":
                    property = AutomationElement.ControlTypeProperty;
                    break;
                case "Name":
                    property = AutomationElement.NameProperty;
                    break;
                case "LocalizedControlType":
                    property = AutomationElement.LocalizedControlTypeProperty;
                    break;
                default:
                    throw new Exception("Property parameter <" + attribute + "> does not exist.");
            }
            return property;
        }

    }
}
