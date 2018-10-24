using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Automation;

namespace UIAFramework
{
    public class UICalander : ControlBase
    {
        public UICalander() { }

        public UICalander(string condition, string treescope, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope,type,memberName)
        {
            ParentBase.controlType = Common.GetControlType("calender");
        }

        public UICalander(string condition, string treescope, AutomationElement ae, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope, ae,type,memberName)
        {
            ParentBase.controlType = Common.GetControlType("calender");
        }

        public UICalander(string treePath, bool isPath, [CallerMemberName] string memberName = "")
            : base(treePath, isPath,memberName)
        {
            ParentBase.controlType = Common.GetControlType("calender");
        }

        public UICalander(string treePath, bool isPath, AutomationElement ae, [CallerMemberName] string memberName = "")
            : base(treePath, isPath, ae,memberName)
        {
            ParentBase.controlType = Common.GetControlType("calender");
        }

        public UICalander(AutomationElement ae, [CallerMemberName] string memberName = "")
            : base(ae,memberName)
        {
            ParentBase.controlType = Common.GetControlType("calender");
        }

        public UICalander(string condition, string treescope, bool isMultipleControl, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            :base(condition,treescope,isMultipleControl,type,memberName)
        {
            ParentBase.controlType = Common.GetControlType("calender");
        }

          public UICalander(string condition, string treescope, AutomationElement ae, bool isMultipleControl, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "")
            : base(condition, treescope,ae, isMultipleControl, type, memberName)
        {
            ParentBase.controlType = Common.GetControlType("calender");
        }
          public UICalander(AutomationElement ae)
               : base(ae)
           {
           }
        #region Actions
        /// <summary>
        /// Used to Select Perticular date in a calander and the calander should be in current month and year to use this method
        /// </summary>
        /// <param name="dateToBeSet">Date To Be Set in calander</param>
        /// <param name="dayButtonProperty">Property of day Button</param>
        /// <param name="previousButtonProperty">Property of previous Button</param>
        /// <param name="nextButtonPrpoerty">Property of next Button</param>
        public void SelectDate(DateTime dateToBeSet, string dayButtonProperty, string previousButtonProperty, string nextButtonPrpoerty)
        {
            int date = Convert.ToInt32(dateToBeSet.Date.ToString());
            int month = Convert.ToInt32(dateToBeSet.Month.ToString());
            int year = Convert.ToInt32(dateToBeSet.Year.ToString());
            if (date > 31)
                throw new Exception("The date is out not with in the range of dates and it is greater than 31");
            if (month > 12 || month < 1)
                throw new Exception("The mentioned month does not fall with in the range of months");
            if (date < 1)
                throw new Exception("The date is out not with in the range of dates and it is less than 1");
            int currentYear = DateTime.Today.Year;
            int currentMonth = DateTime.Today.Month;
            int ClickCount;
            List<AutomationElement> sameDateElements = new List<AutomationElement>();
            if (currentYear - year == 0)
            {
                if (currentMonth - month == 0)
                {
                    ClickOnDate(date, dayButtonProperty);
                }
                else if (currentMonth - month < 0)
                {
                    ClickCount = month - currentMonth;
                    ClickOnNextButton(ClickCount, nextButtonPrpoerty);
                    ClickOnDate(date, dayButtonProperty);
                }
                else if (currentMonth - month > 0)
                {
                    ClickCount = month - currentMonth;
                    ClickOnPreviousButton(ClickCount, previousButtonProperty);
                    ClickOnDate(date, dayButtonProperty);
                }
            }
            if (currentYear - year < 0)
            {
                ClickCount = ((year - currentYear - 1) * 12 + (12 - currentMonth) + (month));
                ClickOnNextButton(ClickCount, nextButtonPrpoerty);
                ClickOnDate(date, dayButtonProperty);
            }
            if (currentYear - year > 0)
            {
                ClickCount = ((currentYear - year - 1) * 12 + (currentMonth) + (12 - month));
                ClickOnPreviousButton(ClickCount, previousButtonProperty);
                ClickOnDate(date, dayButtonProperty);
            }
        }

        /// <summary>
        /// Used to Click on date
        /// </summary>
        /// <param name="ClickOnDate">Date To Be Set in calander</param>
        /// <param name="dayButtonProperty">Property of day Button</param>
        private void ClickOnDate(int date, string dayButtonProperty)
        {
            string dayButtonId = dayButtonProperty.Substring(dayButtonProperty.IndexOf('=') + 1);
            Condition DayButtonPropertyCondition = Common.GetPropertyCondition(dayButtonProperty);
            List<AutomationElement> sameDateElements = new List<AutomationElement>();
            AutomationElementCollection allDates;
            allDates = UnWrap().FindAll(TreeScope.Descendants, DayButtonPropertyCondition);
            foreach (AutomationElement item in allDates)
            {
                if (item.FindFirst(TreeScope.Descendants,Common.GetPropertyCondition("ControlType=text")).Current.Name == date.ToString())
                {
                    sameDateElements.Add(item);
                }
            }
            if (sameDateElements.Count == 1)
            {
                new UIButton(sameDateElements[0]).Click();
                return;
            }
            else if (date > 23)
            {
                new UIButton(sameDateElements[1]).Click();
                return;
            }
            else if (date < 7)
            {
                new UIButton(sameDateElements[0]).Click();
                return;
            }
        }

   
        /// <summary>
        /// Used to Click on Previous Button
        /// </summary>
        /// <param name="count">count to click no. of times the previous Button</param>
        /// <param name="previousButtonProperty"> search Property of previous Button</param>
        private void ClickOnPreviousButton(int count, string previousButtonProperty)
        {
            string previousButtonId = previousButtonProperty.Substring(previousButtonProperty.IndexOf('=') + 1);
            Condition PreviousButtonCondition = Common.GetPropertyCondition(previousButtonProperty);
            UIButton previousButton = new UIButton(UnWrap().FindFirst(TreeScope.Descendants, PreviousButtonCondition));
            while (count > 0)
            {
                previousButton.Click();
                count--;
                UIAWait.WaitFor(1);
            }
        }

         /// Used to Click on Previous Button
        /// </summary>
        /// <param name="count">count to click no. of times the next Button</param>
        /// <param name="nextButtonPrpoerty">Search property of next button</param>
        private void ClickOnNextButton(int count, string nextButtonPrpoerty)
        {
            string nextsButtonId = nextButtonPrpoerty.Substring(nextButtonPrpoerty.IndexOf('=') + 1);
            Condition NextButtonCondition = Common.GetPropertyCondition(nextButtonPrpoerty);
            UIButton previousButton = new UIButton(UnWrap().FindFirst(TreeScope.Descendants, NextButtonCondition));
            while (count > 0)
            {
                previousButton.Click();
                count--;
                UIAWait.WaitFor(1);
            }
        }

        #endregion
    }
}
