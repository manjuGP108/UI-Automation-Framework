using System.Windows.Automation;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace UIAFramework
{
    public class UIDataGridItem : ControlBase
    {
        public UIDataGridItem() { }

        public UIDataGridItem(string condition, string treescope, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("dataitem");
        }

        public UIDataGridItem(string condition, string treescope, AutomationElement ae, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope, ae, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("dataitem");
        }

        public UIDataGridItem(string treePath, bool isPath, [CallerMemberName] string memberName = "")
            : base(treePath, isPath, memberName)
        {
            ParentBase.controlType = Common.GetControlType("dataitem");
        }

        public UIDataGridItem(string treePath, bool isPath, AutomationElement ae, [CallerMemberName] string memberName = "")
            : base(treePath, isPath, ae, memberName)
        {
            ParentBase.controlType = Common.GetControlType("dataitem");
        }

        public UIDataGridItem(AutomationElement ae,[CallerMemberName] string memberName = "")
            : base(ae,memberName)
        {

            ParentBase.controlType = Common.GetControlType("dataitem");
        }

             public UIDataGridItem (string condition, string treescope, bool isMultipleControl, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            :base(condition,treescope,isMultipleControl,type,memberName)
        {
            ParentBase.controlType = Common.GetControlType("dataitem");
        }

           public UIDataGridItem(string condition, string treescope, AutomationElement ae, bool isMultipleControl, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope,ae, isMultipleControl, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("dataitem");
        }

        public int GetGridNumberofRows()
        {
            return UnWrap().GetGridItemPattern().Current.RowSpan;
        }

    }
}
