using System.Runtime.CompilerServices;
using System.Windows.Automation;

namespace UIAFramework
{
    public class UIButton : ControlBase
    {
        public UIButton() { }

        public UIButton(string condition, string treescope, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("button");
        }

        public UIButton(string condition, string treescope, AutomationElement ae, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope, ae, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("button");
        }

        public UIButton(string treePath, bool isPath, [CallerMemberName] string memberName = "")
            : base(treePath, isPath, memberName)
        {
            ParentBase.controlType = Common.GetControlType("button");
        }

        public UIButton(string treePath, bool isPath, AutomationElement ae, [CallerMemberName] string memberName = "")
            : base(treePath, isPath, ae, memberName)
        {
            ParentBase.controlType = Common.GetControlType("button");
        }

        public UIButton(AutomationElement ae, [CallerMemberName] string memberName = "")
            : base(ae)
        {
            ParentBase.controlType = Common.GetControlType("button");
        }

          public UIButton(string condition, string treescope, bool isMultipleControl, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            :base(condition,treescope,isMultipleControl,type,memberName)
        {
            ParentBase.controlType = Common.GetControlType("button");
        }

          public UIButton(string condition, string treescope, AutomationElement ae, bool isMultipleControl, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope,ae, isMultipleControl, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("button");
        }
          public UIButton(AutomationElement ae)
               : base(ae)
           {
           }

        #region Actions
        /// <summary>
        /// Click on the button using invoke pattern
        /// </summary>
        public void Click()
        {
            UnWrap().GetInvokePattern().Invoke();
        }
        #endregion
    }
}
