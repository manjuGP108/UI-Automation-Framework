using System.Runtime.CompilerServices;
using System.Windows.Automation;

namespace UIAFramework
{
    public class UICheckBox : ControlBase
    {
        AutomationElement _checkbox;

        public UICheckBox() { }

        public UICheckBox(string condition, string treescope, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("checkbox");
        }

        public UICheckBox(string condition, string treescope, AutomationElement ae, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope, ae, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("checkbox");
        }

        public UICheckBox(string treePath, bool isPath, [CallerMemberName] string memberName = "")
            : base(treePath, isPath, memberName)
        {
            ParentBase.controlType = Common.GetControlType("checkbox");
        }

        public UICheckBox(string treePath, bool isPath, AutomationElement ae, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(treePath, isPath, ae, memberName)
        {
            ParentBase.controlType = Common.GetControlType("checkbox");
        }

        public UICheckBox(AutomationElement ae, [CallerMemberName] string memberName = "")
            : base(ae,memberName)
        {
            ParentBase.controlType = Common.GetControlType("checkbox");
        }

           public UICheckBox(string condition, string treescope, bool isMultipleControl, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            :base(condition,treescope,isMultipleControl,type,memberName)
        {
            ParentBase.controlType = Common.GetControlType("checkbox");
        }

           public UICheckBox(string condition, string treescope, AutomationElement ae, bool isMultipleControl, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope,ae, isMultipleControl, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("checkbox");
        }
           public UICheckBox(AutomationElement ae)
               : base(ae)
           {
           }
        #region Actions

        /// <summary>
        ///  return whether checkbox is checked or not
        /// </summary>
        /// <returns>boolean</returns>
        public bool isChecked()
        {
            ToggleState state = UnWrap().GetTogglePattern().Current.ToggleState;
            if (state == ToggleState.On)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Used to  check box
        /// </summary>
        public void Check()
        {
            _checkbox = UnWrap();
            if (_checkbox.GetTogglePattern().Current.ToggleState == ToggleState.Off)
                _checkbox.GetTogglePattern().Toggle();
        }

        /// <summary>
        /// Used to UnCheck check box
        /// </summary>
        public void UnCheck()
        {
            _checkbox = UnWrap();
            if (_checkbox.GetTogglePattern().Current.ToggleState == ToggleState.On)
                _checkbox.GetTogglePattern().Toggle();
        }

        #endregion
    }
}
