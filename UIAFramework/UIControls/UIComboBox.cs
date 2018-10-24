using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Automation;
using UIAFramework.Base;

namespace UIAFramework
{
    public class UIComboBox : ControlBase
    {
        AutomationElement _comboBox;

        public UIComboBox() { }

        public UIComboBox(string condition, string treescope, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("combobox");
        }

        public UIComboBox(string condition, string treescope, AutomationElement ae, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope, ae, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("combobox");
        }

        public UIComboBox(string treePath, bool isPath, [CallerMemberName] string memberName = "")
            : base(treePath, isPath, memberName)
        {
            ParentBase.controlType = Common.GetControlType("combobox");
        }

        public UIComboBox(string treePath, bool isPath, AutomationElement ae, [CallerMemberName] string memberName = "")
            : base(treePath, isPath, ae, memberName)
        {
            ParentBase.controlType = Common.GetControlType("combobox");
        }

        public UIComboBox(AutomationElement ae,[CallerMemberName] string memberName = "")
            : base(ae,memberName)
        {
            ParentBase.controlType = Common.GetControlType("combobox");
        }

            public UIComboBox(string condition, string treescope, bool isMultipleControl, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            :base(condition,treescope,isMultipleControl,type,memberName)
        {
            ParentBase.controlType = Common.GetControlType("combobox");
        }

           public UIComboBox(string condition, string treescope, AutomationElement ae, bool isMultipleControl, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope,ae, isMultipleControl, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("combobox");
        }
           public UIComboBox(AutomationElement ae)
               : base(ae)
           {
           }
        #region Actions

        /// <summary>
        /// Selects the item in combobox by its name 
        /// </summary>
        /// <param name="name">item name to be selected</param>
        /// <param name="isExpandCollapse">expands combobox by default</param>
        public void SelectComboBoxItem(string name, bool isExpandCollapse = true)
        {
            _comboBox = UnWrap();
            if (isExpandCollapse == true)
            {
                Expand();
            }
            ScrollPattern SIP = _comboBox.GetScrollPattern();
            if (SIP.Current.VerticallyScrollable)
                SIP.SetScrollPercent(SIP.Current.HorizontalScrollPercent, 0);
            AutomationElement ListItem = _comboBox.FindFirst(TreeScope.Children, Common.GetPropertyCondition("ControlType=listitem"));
            while (ListItem != null)
            {
                ScrollItemPattern SP = ListItem.GetScrollItemPattern();
                SP.ScrollIntoView();
                AutomationElement textBlock = ListItem.FindFirst(TreeScope.Descendants, Common.GetPropertyCondition("ControlType=text"));
                if (textBlock.Current.Name.Contains(name))
                {
                    ListItem.GetSelectionItemPattern().Select();
                    if (isExpandCollapse == true)
                    {
                        Collapse();
                    }
                    return;
                }
                ListItem = ControlFactory.GetNextSibling<UIListItem>(ListItem).NativeElement;
                System.Threading.Thread.Sleep(500);
            }
            if (isExpandCollapse == true)
            {
                Collapse(_comboBox);
            }
            throw new Exception("The name of list item you have entered i.e., " + name + "does not exists in the context");
        }

        /// <summary>
        ///  Selects the combobox Item based on rowNumber
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="isExpandCollapse"></param>
        public void SelectComboBoxItem(int rowNumber, bool isExpandCollapse = true)
        {
            _comboBox = UnWrap();
            if (isExpandCollapse == true)
            {
                Expand();
            } UIListItem listItem = ControlFactory.Create<UIListItem>("listitem[" + (rowNumber + 1) + "]", true, _comboBox);
            listItem.Select();
            if (isExpandCollapse == true)
            {
                Collapse();
            }
        }

        /// <summary>
        /// Gets name of  selected Item in combo box
        /// </summary>
        public string GetSelectedItem()
        {
            _comboBox = UnWrap();
            SelectionPattern sp = _comboBox.GetSelectionPattern();
            AutomationElement[] listItem = sp.Current.GetSelection();
            return listItem[0].Current.Name;
        }


        /// <summary>
        /// Gets the all names of items of combo box by scroll till end
        /// </summary>
        /// <param name="isExpandCollapse"></param>
        /// <returns></returns>
        public List<string> GetListItems(bool isExpandCollapse = true)
        {
            UIAWait.WaitFor(5);
            _comboBox = UnWrap();
            var element = NativeElement;
            List<string> ListItemNames = new List<string>();
            if (isExpandCollapse == true)
            {
                Expand();
            }
            UIAWait.WaitFor(2);
            ScrollPattern SIP = _comboBox.GetScrollPattern();
            if (SIP.Current.VerticallyScrollable)
                SIP.SetScrollPercent(SIP.Current.HorizontalScrollPercent, 0);

            AutomationElement ListItem = _comboBox.FindFirst(TreeScope.Children, Common.GetPropertyCondition("ControlType=listItem"));
            while (ListItem != null)
            {

                ScrollItemPattern SP = ListItem.GetScrollItemPattern();
                SP.ScrollIntoView();
                ListItemNames.Add(ListItem.FindFirst(TreeScope.Descendants, Common.GetPropertyCondition("ControlType=text")).Current.Name);
                ListItem = ControlFactory.GetNextSibling<UIListItem>(ListItem).NativeElement;
                UIAWait.WaitFor(2);

            }
            if (isExpandCollapse == true)
            {
                Collapse(_comboBox);
            }
            return ListItemNames;
        }

        /// <summary>
        ///  Gets all the check boxes under a comboBox 
        /// </summary>
        /// <param name="isExpandCollapse"></param>
        /// <returns></returns>
        public List<UICheckBox> GetAllCheckBoxesWithInComboBox(bool isExpandCollapse = true)
        {
            _comboBox = UnWrap();
            List<UICheckBox> CheckBoxes = new List<UICheckBox>();
            if (isExpandCollapse == true)
            {
                Expand();
            }

            ScrollPattern SIP = _comboBox.GetScrollPattern();
            if (SIP.Current.VerticallyScrollable)
                SIP.SetScrollPercent(SIP.Current.HorizontalScrollPercent, 0);
            AutomationElement ListItem = _comboBox.FindFirst(TreeScope.Children, Common.GetPropertyCondition("ControlType=listItem"));
            while (ListItem != null)
            {
                ScrollItemPattern SP = ListItem.GetScrollItemPattern();
                SP.ScrollIntoView();
                CheckBoxes.Add(new UICheckBox(ListItem.FindFirst(TreeScope.Descendants, Common.GetPropertyCondition("ControlType=checkbox"))));
                ListItem = ControlFactory.GetNextSibling<UIListItem>(ListItem).NativeElement;
                System.Threading.Thread.Sleep(500);
            }
            if (isExpandCollapse == true)
            {
                Collapse();
            }
            return CheckBoxes;
        }
        /// <summary>
        /// Gets the perticular comboBox Check box based on its name of list item
        /// </summary>
        /// <param name="name"></param>
        public UICheckBox GetCheckBoxOfComboBox(string name, bool isExpandCollapse = true)
        {
            _comboBox = UnWrap();
            if (isExpandCollapse == true)
            {
                Expand();
            }
            ScrollPattern SIP = _comboBox.GetScrollPattern();
            if (SIP.Current.VerticallyScrollable)
                SIP.SetScrollPercent(SIP.Current.HorizontalScrollPercent, 0);
            AutomationElement ListItem = _comboBox.FindFirst(TreeScope.Children, Common.GetPropertyCondition("ControlType=listItem"));
            while (ListItem != null)
            {
                ScrollItemPattern SP = ListItem.GetScrollItemPattern();
                SP.ScrollIntoView();
                AutomationElement textBlock = ListItem.FindFirst(TreeScope.Descendants, Common.GetPropertyCondition("ControlType=text"));
                if (textBlock.Current.Name == name)
                {
                    if (isExpandCollapse == true)
                    {
                        Collapse();
                    }
                    return new UICheckBox(ListItem.FindFirst(TreeScope.Descendants, Common.GetPropertyCondition("ControlType=checkbox")));
                }
                ListItem = ControlFactory.GetNextSibling<UIListItem>(ListItem).NativeElement;
                System.Threading.Thread.Sleep(500);
            }
            throw new Exception("The name of list item you have entered i.e., " + name + "does not exists in the context");
        }

        #endregion
    }
}
