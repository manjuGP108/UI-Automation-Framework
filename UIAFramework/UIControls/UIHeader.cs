using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Automation;

namespace UIAFramework
{
    public class UIHeader : ControlBase
    {
        public UIHeader() { }

        public UIHeader(string condition, string treescope, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("header");
        }

        public UIHeader(string condition, string treescope, AutomationElement ae, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope, ae, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("header");
        }

        public UIHeader(string treePath, bool isPath, [CallerMemberName] string memberName = "")
            : base(treePath, isPath)
        {
            ParentBase.controlType = Common.GetControlType("header");
        }

        public UIHeader(string treePath, bool isPath, AutomationElement ae, [CallerMemberName] string memberName = "")
            : base(treePath, isPath, ae)
        {
            ParentBase.controlType = Common.GetControlType("header");
        }

        public UIHeader(AutomationElement ae, [CallerMemberName] string memberName = "")
            : base(ae,memberName)
        {
            ParentBase.controlType = Common.GetControlType("header");
        }

                 public UIHeader (string condition, string treescope, bool isMultipleControl, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            :base(condition,treescope,isMultipleControl,type,memberName)
        {
            ParentBase.controlType = Common.GetControlType("header");
        }

           public UIHeader(string condition, string treescope, AutomationElement ae, bool isMultipleControl, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope,ae, isMultipleControl, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("header");
        }
        #region Actions

        public int HeaderColumnCount(string columnHeaderName)
        {
            int count = 0;
            bool found = false;

            AutomationElementCollection headerItems = UnWrap().FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.HeaderItem));
            foreach (AutomationElement header in headerItems)
            {
                count++;
                if (header.Current.Name.Contains(columnHeaderName))
                {
                    found = true;
                    break;
                }
            }
            if (found)
                return count;
            else
                throw new Exception("Exception Occured: Header item '" + columnHeaderName + "' not present.");
        }

        public List<string> GetHeaderColumnNames()
        {
            List<string> headerList = new List<string>();
            AutomationElementCollection headerItems = UnWrap().FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.HeaderItem));
            foreach (AutomationElement header in headerItems)
            {
                headerList.Add(header.Current.Name);
            }
            return headerList;
        }

        #endregion
    }
}
