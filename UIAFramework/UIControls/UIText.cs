using System.Runtime.CompilerServices;
using System.Windows.Automation;
namespace UIAFramework
{
    public class UIText : ControlBase
    {
        public UIText() { }

        public UIText(string condition, string treescope, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("text");
        }

        public UIText(string condition, string treescope, AutomationElement ae, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope, ae, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("text");
        }

        public UIText(string treePath, bool isPath, [CallerMemberName] string memberName = "")
            : base(treePath, isPath, memberName)
        {
            ParentBase.controlType = Common.GetControlType("text");
        }

        public UIText(string treePath, bool isPath, AutomationElement ae, [CallerMemberName] string memberName = "")
            : base(treePath, isPath, ae, memberName)
        {
            ParentBase.controlType = Common.GetControlType("text");
        }

        public UIText(AutomationElement ae, [CallerMemberName] string memberName = "")
            : base(ae,memberName)
        {
            ParentBase.controlType = Common.GetControlType("text");
        }

        public UIText(string condition, string treescope, bool isMultipleControl, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            :base(condition,treescope,isMultipleControl,type,memberName)
        {
            ParentBase.controlType = Common.GetControlType("text");
        }

        public UIText(string condition, string treescope, AutomationElement ae,bool isMultipleControl, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope,ae, isMultipleControl, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("text");
        }
        public UIText(AutomationElement ae)
               : base(ae)
           {
           }
        public void GetText(out string text)
        {
            text = string.Empty;
            text = UnWrap().Current.Name;

        }

    }
}
