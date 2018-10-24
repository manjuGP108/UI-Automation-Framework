using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Automation;
using UIAFramework.Exceptions;

namespace UIAFramework
{
    public class UITextBox : ControlBase
    {

        public UITextBox() { }

        public UITextBox(string condition, string treescope, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("edit");
        }

        public UITextBox(string condition, string treescope, AutomationElement ae, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope, ae, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("edit");
        }

        public UITextBox(string treePath, bool isPath, [CallerMemberName] string memberName = "")
            : base(treePath, isPath, memberName)
        {
            ParentBase.controlType = Common.GetControlType("edit");
        }

        public UITextBox(string treePath, bool isPath, AutomationElement ae, [CallerMemberName] string memberName = "")
            : base(treePath, isPath, ae, memberName)
        {
            ParentBase.controlType = Common.GetControlType("edit");
        }

        public UITextBox(AutomationElement ae, [CallerMemberName] string memberName = "")
            : base(ae,memberName)
        {
            ParentBase.controlType = Common.GetControlType("edit");
        }

        public UITextBox(string condition, string treescope, bool isMultipleControl,UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            :base(condition,treescope,isMultipleControl,type,memberName)
        {
            ParentBase.controlType = Common.GetControlType("edit");
        }


        public UITextBox(string condition, string treescope, AutomationElement ae,bool isMultipleControl, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope, ae,isMultipleControl, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("edit");
        }

        public UITextBox(AutomationElement ae)
               : base(ae)
           {
           }
        #region Actions
        /// <summary>
        /// Waits for text to be visible in the textbox control
        /// </summary>
        public void WaitForText(string text)
        {
            UIAWait.WaitUntil(() =>
            {
                if (UnWrap().GetValuePattern().Current.Value.Contains(text))
                    return true;
                else
                    return false;

            }, 1);
        }


        public void EnterText(string text)
        {
            UnWrap().GetValuePattern().SetValue(text);
        }

        public void GetText(out string text)
        {
            text = string.Empty;
            WaitForText(text);
            text = UnWrap().GetValuePattern().Current.Value;

        }

        public void EnterEncryptedText(string encryptedText)
        {
            UnWrap().SetFocusIfFocusable();
            UIAWait.WaitFor(1);
            Microsoft.VisualStudio.TestTools.UITesting.Keyboard.SendKeys(encryptedText, true);
        }

        public string GetText()
        {
            string text = string.Empty;
            WaitForText(text);
            text = UnWrap().GetValuePattern().Current.Value;
            return text;
        }
        #endregion
    }
}
