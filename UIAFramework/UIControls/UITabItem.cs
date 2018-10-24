using System.Runtime.CompilerServices;
using System.Windows.Automation;

namespace UIAFramework
{
    public class UITabItem : ControlBase
    {
        public UITabItem() { }

        public UITabItem(string condition, string treescope, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("tabitem");
        }

        public UITabItem(string condition, string treescope, AutomationElement ae, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope, ae, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("tabitem");
        }

        public UITabItem(string treePath, bool isPath, [CallerMemberName] string memberName = "")
            : base(treePath, isPath, memberName)
        {
            ParentBase.controlType = Common.GetControlType("tabitem");
        }

        public UITabItem(string treePath, bool isPath, AutomationElement ae, [CallerMemberName] string memberName = "")
            : base(treePath, isPath, ae, memberName)
        {
            ParentBase.controlType = Common.GetControlType("tabitem");
        }

        public UITabItem(AutomationElement ae, [CallerMemberName] string memberName = "")
            : base(ae,memberName)
        {
            ParentBase.controlType = Common.GetControlType("tabitem");
        }

            public UITabItem (string condition, string treescope, bool isMultipleControl, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            :base(condition,treescope,isMultipleControl,type,memberName)
        {
            ParentBase.controlType = Common.GetControlType("tabitem");
        }

           public UITabItem(string condition, string treescope, AutomationElement ae, bool isMultipleControl, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope,ae, isMultipleControl, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("tabitem");
        }

        #region Actions
        /// <summary>
        /// Selects the Tab Item based on tab name
        /// <param name="name">The name of the tab item</param>
        public virtual void SelectTabItem(string name)
        {
            AutomationElementCollection coll = UnWrap().FindAll(TreeScope.Children, Common.GetPropertyCondition("ControlType=tabitem"));
            foreach (AutomationElement item in coll)
            {
                AutomationElement txt = item.FindFirst(TreeScope.Descendants, Common.GetPropertyCondition("ControlType=text"));
                if (txt.Current.Name == name)
                    new UITabItem(item).Select();
            }
        }
        #endregion

    }
}
