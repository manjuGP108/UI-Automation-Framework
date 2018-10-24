
using System;
using System.Text.RegularExpressions;
using System.Windows.Automation;

namespace UIAFramework
{
    public class WindowBase
    {

        #region Fields
        private Condition _condition;
        //private AutomationElement _UIElement;
        private TreeScope _treescope;
        #endregion

        #region Property

        public int ProcessId
        {
            get
            {
                return Convert.ToInt32(ParentBase.parents.GetCurrentPropertyValue(AutomationElement.ProcessIdProperty));
            }
        }

        #endregion

        public WindowBase()
        {

        }

        public WindowBase(Regex pattern)
        {
            AutomationElementCollection windows = AutomationElement.RootElement.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window));
            try
            {
                foreach (AutomationElement ae in windows)
                {
                    string x = ae.Current.Name;
                    bool matc = pattern.IsMatch(x);
                    Match match = pattern.Match(x);
                    if (match.Success)
                    {
                        ParentBase.parents = ae;
                        ParentBase.parents.SetFocus();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public WindowBase(string conditionString)
        {

            this._condition = Common.GetPropertyCondition(conditionString);
            this._treescope = Common.GetTreeScope("Descendants");

            UIAWait.WaitUntil(() =>
            {
                AutomationElement windows = AutomationElement.RootElement.FindFirst(this._treescope, this._condition);
                if (windows == null)
                    return false;
                else
                {
                    ParentBase.parents = windows;
                    windows.SetFocusIfFocusable();
                }
                return true;
            }, 0.25);

            if (ParentBase.parents == null)
            {
                throw new Exception("Window with condition" + Common.SearchAttribute + "is not found");
            }
        }

    }
}

