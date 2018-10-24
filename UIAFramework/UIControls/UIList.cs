using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Automation;
using UIAFramework.Base;

namespace UIAFramework
{
    public class UIList : ControlBase
    {
        AutomationElement _UIList;

        public UIList() { }

        public UIList(string condition, string treescope, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("list");
        }

        public UIList(string condition, string treescope, AutomationElement ae, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope, ae, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("list");
        }

        public UIList(string treePath, bool isPath, [CallerMemberName] string memberName = "")
            : base(treePath, isPath, memberName)
        {
            ParentBase.controlType = Common.GetControlType("list");
        }

        public UIList(string treePath, bool isPath, AutomationElement ae, [CallerMemberName] string memberName = "")
            : base(treePath, isPath, ae, memberName)
        {
            ParentBase.controlType = Common.GetControlType("list");
        }

        public UIList(AutomationElement ae, [CallerMemberName] string memberName = "")
            : base(ae,memberName)
        {
            ParentBase.controlType = Common.GetControlType("list");
        }

            public UIList (string condition, string treescope, bool isMultipleControl, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            :base(condition,treescope,isMultipleControl,type,memberName)
        {
            ParentBase.controlType = Common.GetControlType("list");
        }

           public UIList(string condition, string treescope, AutomationElement ae, bool isMultipleControl, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope,ae, isMultipleControl, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("list");
        }
           public UIList(AutomationElement ae)
               : base(ae)
           {
           }
        #region Actions
        /// <summary>
        /// Selects a comboBox Item based on its name
        /// </summary>
        /// <param name="name"></param>
        public void SelectListItem(string name)
        {
            _UIList = UnWrap();
            ScrollPattern SIP = _UIList.GetScrollPattern();
            if (SIP.Current.VerticallyScrollable)
                SIP.SetScrollPercent(SIP.Current.HorizontalScrollPercent, 0);
            AutomationElement ListItem = _UIList.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem));
            while (ListItem != null)
            {
                ScrollItemPattern SP = ListItem.GetScrollItemPattern();
                SP.ScrollIntoView();
                AutomationElement textBlock = ListItem.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Text));
                if (textBlock.Current.Name.Contains(name))
                {
                    ListItem.GetSelectionItemPattern().Select();
                    return;
                }
                ListItem = ControlFactory.GetNextSibling<UIListItem>(ListItem).NativeElement;
                System.Threading.Thread.Sleep(500);
            }
        }

        /// <summary>
        /// Selects a Perticular ListItem based on its rowNumber
        /// </summary>
        /// <param name="rowNumber"></param>
        public void SelectListItem(int rowNumber)
        {
            UIListItem listItem = ControlFactory.Create<UIListItem>("listitem[" + rowNumber + "]", true, UnWrap());
            listItem.Select();
        }

        /// <summary>
        /// Gets all ListItems of ListView
        /// </summary>
        /// <param name="rowNumber"></param>
        public List<UIListItem> GetAllUIListItems()
        {
            _UIList = UnWrap();
            List<UIListItem> ListItems = new List<UIListItem>();
            ScrollPattern SIP = _UIList.GetScrollPattern();
            if (SIP.Current.VerticallyScrollable)
                SIP.SetScrollPercent(SIP.Current.HorizontalScrollPercent, 0);
            AutomationElement ListItem = _UIList.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem));
            while (ListItem != null)
            {
                ScrollItemPattern SP = ListItem.GetScrollItemPattern();
                SP.ScrollIntoView();
                ListItems.Add(new UIListItem(ListItem));
                ListItem = ControlFactory.GetNextSibling<UIListItem>(ListItem).NativeElement;
                System.Threading.Thread.Sleep(500);
            }
            return ListItems;
        }

        /// <summary>
        /// Gets all ListItems Names of ListView
        /// </summary>
        /// <param name="rowNumber"></param>
        public List<string> GetAllUIListItemsName()
        {
            _UIList = UnWrap();
            List<string> ListItemNames = new List<string>();
            ScrollPattern SIP = _UIList.GetScrollPattern();
            if (SIP.Current.VerticallyScrollable)
                SIP.SetScrollPercent(SIP.Current.HorizontalScrollPercent, 0);
            AutomationElement ListItem = _UIList.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem));
            while (ListItem != null)
            {
                ScrollItemPattern SP = ListItem.GetScrollItemPattern();
                SP.ScrollIntoView();
                ListItemNames.Add(ListItem.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Text)).Current.Name);
                ListItem = ControlFactory.GetNextSibling<UIListItem>(ListItem).NativeElement;
                System.Threading.Thread.Sleep(500);
            }
            return ListItemNames;
        }

        /// <summary>
        /// Gets all ListItems Check Boxes of ListView
        /// </summary>
        /// <param name="rowNumber"></param>
        public List<UICheckBox> GetAllUIListItemCheckBoxes()
        {
            _UIList = UnWrap();
            List<UICheckBox> CheckBoxes = new List<UICheckBox>();
            ScrollPattern SIP = _UIList.GetScrollPattern();
            if (SIP.Current.VerticallyScrollable)
                SIP.SetScrollPercent(SIP.Current.HorizontalScrollPercent, 0);
            AutomationElement ListItem = _UIList.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem));
            while (ListItem != null)
            {
                ScrollItemPattern SP = ListItem.GetScrollItemPattern();
                SP.ScrollIntoView();
                CheckBoxes.Add(new UICheckBox(ListItem.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.CheckBox))));
                ListItem = ControlFactory.GetNextSibling<UIListItem>(ListItem).NativeElement;
                System.Threading.Thread.Sleep(500);
            }
            return CheckBoxes;
        }

        /// <summary>
        /// Gets a Perticular Check Box of ListItem Check Box of ListView
        /// </summary>
        /// <param name="rowNumber"></param>
        public UICheckBox GetCheckBoxOfUIListItem(string name)
        {
            _UIList = UnWrap();
            ScrollPattern SIP = _UIList.GetScrollPattern();
            if (SIP.Current.VerticallyScrollable)
                SIP.SetScrollPercent(SIP.Current.HorizontalScrollPercent, 0);
            AutomationElement ListItem = _UIList.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem));
            while (ListItem != null)
            {
                ScrollItemPattern SP = ListItem.GetScrollItemPattern();
                SP.ScrollIntoView();
                AutomationElement textBlock = ListItem.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Text));
                if (textBlock.Current.Name == name)
                {
                    return new UICheckBox(ListItem.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.CheckBox)));
                }
                ListItem = ControlFactory.GetNextSibling<UIListItem>(ListItem).NativeElement;
                System.Threading.Thread.Sleep(500);
            }
            throw new Exception("The name of list item you have entered i.e., " + name + "does not exists in the context");
        }
    }


        #endregion
}

