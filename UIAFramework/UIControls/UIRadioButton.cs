using System.Runtime.CompilerServices;
using System.Windows.Automation;
namespace UIAFramework
{
    public class UIRadioButton : ControlBase
    {
        public UIRadioButton() { }
        AutomationElement _radioButton;

        public UIRadioButton(string condition, string treescope, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("radiobutton");
        }

        public UIRadioButton(string condition, string treescope, AutomationElement ae, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope, ae, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("radiobutton");
        }

        public UIRadioButton(string treePath, bool isPath, [CallerMemberName] string memberName = "")
            : base(treePath, isPath, memberName)
        {
            ParentBase.controlType = Common.GetControlType("radiobutton");
        }

        public UIRadioButton(string treePath, bool isPath, AutomationElement ae, [CallerMemberName] string memberName = "")
            : base(treePath, isPath, ae, memberName)
        {
            ParentBase.controlType = Common.GetControlType("radiobutton");
        }

        public UIRadioButton(AutomationElement ae, [CallerMemberName] string memberName = "")
            : base(ae,memberName)
        {
            ParentBase.controlType = Common.GetControlType("radiobutton");
        }

            public UIRadioButton (string condition, string treescope, bool isMultipleControl, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            :base(condition,treescope,isMultipleControl,type,memberName)
        {
            ParentBase.controlType = Common.GetControlType("radiobutton");
        }

           public UIRadioButton(string condition, string treescope, AutomationElement ae, bool isMultipleControl, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope,ae, isMultipleControl, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("radiobutton");
        }

        #region Actions
        /// <summary>
        /// Used to Check check box
        /// </summary>
        public void SelectRadioButton()
        {
            _radioButton = UnWrap();
            if (_radioButton.GetTogglePattern().Current.ToggleState == ToggleState.Off)
                _radioButton.GetTogglePattern().Toggle();
        }

        /// <summary>
        /// Used to UnCheck check box
        /// </summary>
        public void DeSelectRadioButton()
        {
            _radioButton = UnWrap();
            if (_radioButton.GetTogglePattern().Current.ToggleState == ToggleState.On)
                _radioButton.GetTogglePattern().Toggle();
        }
        #endregion
    }
}