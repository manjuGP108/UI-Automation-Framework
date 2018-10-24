using System.Windows.Automation;
using System;
using System.Drawing;
using System.Threading;
//using System.Windows;
using UIAFramework.Exceptions;
using Microsoft.VisualStudio.TestTools.UITesting;
using System.Collections.Generic;

namespace UIAFramework
{
    public class ControlBase
    {

        #region Fields

        private Condition _condition;

        private static AutomationElement _UIElement ;

        private static AutomationElementCollection _UIElementList;

        private TreeScope _treescope;

        public string AutomationId { get; set; }

        public string ClassName { get; set; }

        // public string Value { get; set; }

        public bool IsInvokePatternAvailable { get; set; }

        public bool IsExpandCollapsePatternAvailableProperty { get; set; }

        public bool IsGridPatternAvailableProperty { get; set; }

        public bool IsScrollPatternAvailableProperty { get; set; }

        public bool IsTablePatternAvailableProperty { get; set; }

        public bool IsScollItemPatternAvailableProperty { get; set; }

        public int NativeWindowHandle { get; set; }

        public string Name { get; set; }

        public bool IsVisible { get; set; }

        public bool IsEnabled { get; set; }

        public bool IsSelected { get; set; }

        public bool IsOnScreen { get; set; }

        #endregion


        #region Constructor Methods

        public ControlBase()
        {
        }

        public ControlBase(AutomationElement ae, string callerMember = null)
        {
            ParentBase.controlName = callerMember;
            this.NativeElement = ae;
        }


        /// <summary>
        /// Sets the root element of the window with a property and defined tree scope
        /// </summary>
        /// <param name="conditionString">property identifier</param>
        /// <param name="treescope">scope of search</param>
        public ControlBase(string conditionString, string treescope, UIAEnums.ConditionType? type = null, string callerMember = null)
        {
            this._condition = Common.GetPropertyCondition(conditionString, type);
            this._treescope = Common.GetTreeScope(treescope);
            ParentBase.controlName = callerMember;
         
                Wrap(_condition, _treescope);
                _UIElement = this.NativeElement;
                InitializeProperty(_UIElement);
            
        }


        public ControlBase(string conditionString, string treescope, AutomationElement ae, UIAEnums.ConditionType? type = null, string callerMember = null)
        {
            this._condition = Common.GetPropertyCondition(conditionString, type);
            this._treescope = Common.GetTreeScope(treescope);
            ParentBase.controlName = callerMember;
            Wrap(_condition, _treescope, ae);
            _UIElement = this.NativeElement;
            InitializeProperty(_UIElement);

        }

        public ControlBase(string treePath, bool isPath, string callerMember = null)
        {
            Wrap(treePath, isPath);
            ParentBase.controlName = callerMember;
            _UIElement = this.NativeElement;
            InitializeProperty(_UIElement);
        }

        public ControlBase(string treePath, bool isPath, AutomationElement ae, string callerMember = null)
        {
            Wrap(treePath, isPath, ae);
            ParentBase.controlName = callerMember;
            _UIElement = this.NativeElement;
            InitializeProperty(_UIElement);
        }

        public ControlBase(string conditionString, string treescope,bool isMultipleControl,UIAEnums.ConditionType? type = null, string callerMember = null)
        {
            this._condition = Common.GetPropertyCondition(conditionString, type);
            this._treescope = Common.GetTreeScope(treescope);
            ParentBase.controlName = callerMember;
           
            WrapAll(_condition, _treescope);
            _UIElementList = this.NativeElementList;
        }

        public ControlBase (string conditionString, string treescope,AutomationElement ae,bool isMultipleControl,UIAEnums.ConditionType? type = null, string callerMember = null)
        {
            this._condition = Common.GetPropertyCondition(conditionString, type);
            this._treescope = Common.GetTreeScope(treescope);
            ParentBase.controlName = callerMember;
           
            WrapAll(_condition, _treescope,ae);
            _UIElementList = this.NativeElementList;
        }

        #endregion


        #region Wrap and UnWrap Methods

        public AutomationElement NativeElement
        {
            
            get
            {
                return _UIElement;
            }
            set
            {
                _UIElement= value;
            }
        }


        public  AutomationElementCollection NativeElementList
        {
            get
            {
                return _UIElementList;
            }

            set
            {
                _UIElementList = value;
            }
        }






        public void Wrap(Condition condition, TreeScope scope, AutomationElement ae)
        {
            UIAWait.WaitFor(5);
            this.NativeElement = ae.FindFirst(scope, condition);
            if (this.NativeElement == null)
                throw new UI_NullElement(ParentBase.controlName, Common.SearchAttribute);
            this.NativeElement.SetFocusIfFocusable();
        }

        /// <summary>
        /// Creates and sets the value of property value
        /// </summary>
        /// <param name="condition">Control identifier</param>
        /// <param name="scope">Scope of control search</param>
        public void Wrap(Condition condition, TreeScope scope)
        {
            this.NativeElement = ParentBase.parents.FindFirst(scope, condition);
            if (this.NativeElement == null)
                throw new UI_NullElement(ParentBase.controlName, Common.SearchAttribute);
            this.NativeElement.SetFocusIfFocusable();
        }

        public void Wrap(string treePath, bool isPath)
        {
            this.NativeElement = ParentBase.parents.FindElement(treePath, isPath);
            if (this.NativeElement == null)
                throw new UI_NullElement(ParentBase.controlName, Common.SearchAttribute);
            this.NativeElement.SetFocusIfFocusable();
        }

        public void Wrap(string treePath, bool isPath, AutomationElement ae)
        {
            this.NativeElement = ae.FindElement(treePath, isPath);
            if (this.NativeElement == null)
                throw new UI_NullElement(ParentBase.controlName, Common.SearchAttribute);
            this.NativeElement.SetFocusIfFocusable();
        }

        public void WrapAll(Condition condition, TreeScope scope)
        {
            this.NativeElementList=  ParentBase.parents.FindAll(scope, condition);
            if (this.NativeElementList.Count<0)
                throw new UI_NullElement(ParentBase.controlName, Common.SearchAttribute);
            this.NativeElementList[0].SetFocusIfFocusable();
        }


        public void WrapAll(Condition condition, TreeScope scope, AutomationElement ae)
        {
            this.NativeElementList = ae.FindAll(scope, condition);
            if (this.NativeElementList.Count < 0)
                throw new UI_NullElement(ParentBase.controlName, Common.SearchAttribute);
            this.NativeElementList[0].SetFocusIfFocusable();
        }

        public AutomationElement UnWrap()
        {
            return this.NativeElement;
        }

        #endregion


        #region Actions


        protected void InitializeProperty(AutomationElement ae)
        {
            this.Name = ae.Current.Name;
            this.AutomationId = ae.Current.AutomationId;
            ParentBase.controlTypeProperty = ae.Current.ControlType;
            this.ClassName = ae.Current.ClassName;

            this.IsEnabled = ae.Current.IsEnabled;
            if (Convert.ToBoolean(ae.GetPropertyAttribute(AutomationElement.IsSelectionItemPatternAvailableProperty)))
            {
                this.IsSelected = ae.GetSelectionItemPattern().Current.IsSelected;
            }

            if (_UIElement.Current.IsOffscreen)
                this.IsOnScreen = false;
            else
                this.IsOnScreen = true;

            this.IsInvokePatternAvailable = Convert.ToBoolean(ae.GetPropertyAttribute(AutomationElement.IsInvokePatternAvailableProperty));
            this.IsGridPatternAvailableProperty = Convert.ToBoolean(ae.GetPropertyAttribute(AutomationElement.IsGridPatternAvailableProperty));
            if (_UIElement.Current.IsOffscreen == false && _UIElement.Current.IsEnabled == true)
                this.IsVisible = true;
            else
                this.IsVisible = false;

            this.IsScrollPatternAvailableProperty = Convert.ToBoolean(ae.GetPropertyAttribute(AutomationElement.IsScrollPatternAvailableProperty));
            this.IsScollItemPatternAvailableProperty = Convert.ToBoolean(ae.GetPropertyAttribute(AutomationElement.IsScrollItemPatternAvailableProperty));
            this.IsExpandCollapsePatternAvailableProperty = Convert.ToBoolean(ae.GetPropertyAttribute(AutomationElement.IsExpandCollapsePatternAvailableProperty));
            this.IsTablePatternAvailableProperty = Convert.ToBoolean(ae.GetPropertyAttribute(AutomationElement.IsTablePatternAvailableProperty));
            this.NativeWindowHandle = Convert.ToInt32(ae.GetPropertyAttribute(AutomationElement.NativeWindowHandleProperty));

        }

        /// <summary>
        /// Horizontal Scrol
        /// </summary>
        /// <param name="amt"></param>
        public void Scroll(UIAEnums.ScrollLimit amt)
        {
            switch (amt)
            {
                case UIAEnums.ScrollLimit.LargeDecrement:
                    _UIElement.GetScrollPattern().ScrollHorizontal(ScrollAmount.LargeDecrement);
                    break;
                case UIAEnums.ScrollLimit.SmallDecrement:
                    _UIElement.GetScrollPattern().ScrollHorizontal(ScrollAmount.SmallDecrement);
                    break;
                case UIAEnums.ScrollLimit.NoAmount:
                    _UIElement.GetScrollPattern().ScrollHorizontal(ScrollAmount.NoAmount);
                    break;
                case UIAEnums.ScrollLimit.SmallIncrement:
                    _UIElement.GetScrollPattern().ScrollHorizontal(ScrollAmount.SmallIncrement);
                    break;
                case UIAEnums.ScrollLimit.LargeIncrement:
                    _UIElement.GetScrollPattern().ScrollHorizontal(ScrollAmount.LargeIncrement);
                    break;
                case UIAEnums.ScrollLimit.LargeIncrementVertical:
                    _UIElement.GetScrollPattern().ScrollVertical(ScrollAmount.LargeIncrement);
                    break;
                case UIAEnums.ScrollLimit.SmallIncrementVertical:
                    _UIElement.GetScrollPattern().ScrollVertical(ScrollAmount.SmallIncrement);
                    break;
                default:
                    break;
            }
        }

        public double GetHorizontalScrollPercentage()
        {
            return _UIElement.GetScrollPattern().Current.HorizontalScrollPercent;
        }


        public void MouseClick()
        {
            Point p = BoundingRectangle();
            Mouse.Click(p.X, p.Y);
            Thread.Sleep(1000);
        }

        public void Hover()
        {
            Point p = BoundingRectangle();
            Mouse.MoveTo(p.X, p.Y);
        }

        public void RightClick()
        {
            Point p = BoundingRectangle();
            Mouse.RightClick(p.X, p.Y);
            Thread.Sleep(1000);
        }

        public virtual void Clear()
        {
            MouseClick();
            Thread.Sleep(500);
            KeyBoard.Clear();
        }

        public virtual void DoubleClick()
        {
            Point p = BoundingRectangle();
            Mouse.DoubleClick(p.X, p.Y);
        }

        public Point BoundingRectangle()
        {
            int x = ((int)_UIElement.Current.BoundingRectangle.X + (int)_UIElement.Current.BoundingRectangle.Right) / 2;
            int y = ((int)_UIElement.Current.BoundingRectangle.Y + (int)_UIElement.Current.BoundingRectangle.Bottom) / 2;
            return new Point(x, y);
        }

        public virtual void Expand()
        {
            ExpandCollapsePattern pattern = _UIElement.GetExpandCollapsePattern();

            if (pattern.Current.ExpandCollapseState != ExpandCollapseState.Expanded)
            {
                pattern.Expand();
            }
        }

        public virtual void Collapse(AutomationElement currentElement = null)
        {ExpandCollapsePattern pattern ;
            if(_UIElement != null)
            pattern = _UIElement.GetExpandCollapsePattern();
            else pattern = currentElement.GetExpandCollapsePattern();
            if (pattern.Current.ExpandCollapseState != ExpandCollapseState.Collapsed)
            {
                pattern.Collapse();
            }
        }

        public virtual void Select()
        {
            _UIElement.GetSelectionItemPattern().Select();
        }


        public virtual void ScrollUntilControlAvailable(string condition)
        {
            List<string> list = new List<string>();
            AutomationElement element = UnWrap();
            ScrollPattern scrollPattern = element.GetScrollPattern();
            Condition searchCondition = Common.GetPropertyCondition(condition);
            bool onScreen = false;
            do
            {
                onScreen = (element.FindFirst(TreeScope.Descendants, searchCondition) != null);
                scrollPattern.ScrollVertical(ScrollAmount.SmallIncrement);

                if (scrollPattern.Current.VerticalScrollPercent == 100)
                {
                    break;
                }
            }
            while (!onScreen);
        }

        public virtual void WaitForControlExists(AutomationElement ae)
        {
            this.CreateUiTestControl(ae).WaitForControlExist();
        }

        public virtual void WaitForControlNotExists(AutomationElement ae)
        {
            this.CreateUiTestControl(ae).WaitForControlNotExist();
        }

        public virtual void WaitForControlEnabled(AutomationElement ae)
        {
            this.CreateUiTestControl(ae).WaitForControlEnabled();
        }

        public virtual void WaitForControlReady(AutomationElement ae)
        {
            this.CreateUiTestControl(ae).WaitForControlReady();
        }

        public virtual bool IsExpanded()
        {
            ExpandCollapsePattern ep = UnWrap().GetExpandCollapsePattern();
            ExpandCollapseState state = ep.Current.ExpandCollapseState;
            if (state == ExpandCollapseState.Expanded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        private Microsoft.VisualStudio.TestTools.UITesting.UITestControl CreateUiTestControl(AutomationElement ae)
        {
            return UITestControlFactory.FromNativeElement(ae, "UIA");
        }
        public bool Exists
        {
            get
            {
                if (NativeElement == null)
                    return false;
                else
                    return true;
            }
        }

    }
}

