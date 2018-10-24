using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;

namespace UIAFramework
{
    public static class Extensions
    {
        #region Pattern Implementation

        public static ExpandCollapsePattern GetExpandCollapsePattern(this AutomationElement ae)
        {
            UIAWait.WaitFor(4);
            object Pattern;
            if (!ae.TryGetCurrentPattern(ExpandCollapsePattern.Pattern, out Pattern))
            {
                throw new Exception("ExpandCollapsePattern is not Supported by this AutomationElement.");
            }

            return Pattern as ExpandCollapsePattern;
        }

        public static GridPattern GetGridPattern(this AutomationElement ae)
        {
            object Pattern;
            if (!ae.TryGetCurrentPattern(GridPattern.Pattern, out Pattern))
            {
                throw new Exception("GridPattern is not Supported by this AutomationElement.");
            }

            return Pattern as GridPattern;
        }

        public static GridItemPattern GetGridItemPattern(this AutomationElement ae)
        {
            object Pattern;
            if (!ae.TryGetCurrentPattern(GridItemPattern.Pattern, out Pattern))
            {
                throw new Exception("GridItemPattern is not Supported by this AutomationElement.");
            }

            return Pattern as GridItemPattern;

        }

        public static InvokePattern GetInvokePattern(this AutomationElement ae)
        {
            object Pattern;
            if (!ae.TryGetCurrentPattern(InvokePattern.Pattern, out Pattern))
            {
                throw new Exception("InvokePattern is not Supported by this AutomationElement.");
            }

            return Pattern as InvokePattern;
        }


        public static ScrollPattern GetScrollPattern(this AutomationElement ae)
        {
            object Pattern;
            if (!ae.TryGetCurrentPattern(ScrollPattern.Pattern, out Pattern))
            {
                throw new Exception("ScrollPattern is not Supported by this AutomationElement.");
            }

            return Pattern as ScrollPattern;
        }

        public static ScrollItemPattern GetScrollItemPattern(this AutomationElement ae)
        {
            object Pattern;
            if (!ae.TryGetCurrentPattern(ScrollItemPattern.Pattern, out Pattern))
            {
                throw new Exception("ScrollItemPattern is not Supported by this AutomationElement.");
            }

            return Pattern as ScrollItemPattern;
        }






        public static SelectionPattern GetSelectionPattern(this AutomationElement ae)
        {
            object Pattern;
            if (!ae.TryGetCurrentPattern(SelectionPattern.Pattern, out Pattern))
            {
                throw new Exception("SelectionPattern is not Supported by this AutomationElement.");
            }

            return Pattern as SelectionPattern;
        }

        public static SelectionItemPattern GetSelectionItemPattern(this AutomationElement ae)
        {
            object Pattern;
            if (!ae.TryGetCurrentPattern(SelectionItemPattern.Pattern, out Pattern))
            {
                throw new Exception("SelectionItemPattern is not Supported by this AutomationElement.");
            }

            return Pattern as SelectionItemPattern;
        }

        public static TablePattern GetTablePattern(this AutomationElement ae)
        {
            object Pattern;
            if (!ae.TryGetCurrentPattern(TablePattern.Pattern, out Pattern))
            {
                throw new Exception("TablePattern is not Supported by this AutomationElement.");
            }

            return Pattern as TablePattern;
        }

        public static TableItemPattern GetTableItemPattern(this AutomationElement ae)
        {
            object Pattern;
            if (!ae.TryGetCurrentPattern(TableItemPattern.Pattern, out Pattern))
            {
                throw new Exception("TableItemPattern is not Supported by this AutomationElement.");
            }

            return Pattern as TableItemPattern;
        }

        public static TextPattern GetTextPattern(this AutomationElement ae)
        {
            object Pattern;
            if (!ae.TryGetCurrentPattern(TextPattern.Pattern, out Pattern))
            {
                throw new Exception("TextPattern is not Supported by this AutomationElement.");
            }

            return Pattern as TextPattern;
        }

        public static WindowPattern GetWindowPattern(this AutomationElement ae)
        {
            object Pattern;
            if (!ae.TryGetCurrentPattern(WindowPattern.Pattern, out Pattern))
            {
                throw new Exception("WindowPattern is not Supported by this AutomationElement.");
            }

            return Pattern as WindowPattern;
        }


        public static ValuePattern GetValuePattern(this AutomationElement ae)
        {
            object Pattern;
            if (!ae.TryGetCurrentPattern(ValuePattern.Pattern, out Pattern))
            {
                throw new Exception("ValuePattern is not Supported by this AutomationElement.");
            }

            return Pattern as ValuePattern;
        }

        public static TogglePattern GetTogglePattern(this AutomationElement ae)
        {
            object Pattern;
            if (!ae.TryGetCurrentPattern(TogglePattern.Pattern, out Pattern))
            {
                throw new Exception("ValuePattern is not Supported by this AutomationElement.");
            }

            return Pattern as TogglePattern;

        }


        #endregion

        #region FindElement Implementation

        public static void SetFocusIfFocusable(this AutomationElement ae)
        {
            if (Convert.ToBoolean(ae.GetCurrentPropertyValue(AutomationElement.IsKeyboardFocusableProperty)))
            {
                ae.SetFocus();
            }
        }

        public static object GetPropertyAttribute(this AutomationElement ae, AutomationProperty property)
        {
            return ae.GetCurrentPropertyValue(property);
        }

        /// <summary>
        /// Searches for an element on the basis of TreePath
        /// </summary>
        /// <param name="ae">parent element</param>
        /// <param name="treePathFromInvokedElemnt"></param>
        /// <param name="isWeightPath"></param>
        /// <returns></returns>
        public static AutomationElement FindElement(this AutomationElement ae, string treePathFromInvokedElemnt, bool isWeightPath)
        {
            AutomationElement Element = ae;
            if (!isWeightPath)
            {
                List<string> pathElemet = treePathFromInvokedElemnt.Split('/').ToList();
                int index = 0;
                foreach (string automationId in pathElemet)
                {
                    Condition Cond = new PropertyCondition(AutomationElement.AutomationIdProperty, pathElemet[index]);
                    Element = Element.FindFirst(TreeScope.Children, Cond);
                    index = index + 1;
                }
            }
            else
            {
                ControlType CntType = null;
                List<string> pathElemet = treePathFromInvokedElemnt.Split('/').ToList();
                int index = 0;
                string tag = string.Empty;
                foreach (string tagWithWeight in pathElemet)
                {
                    tag = tagWithWeight.Split('[')[0];
                    index = Convert.ToInt16((tagWithWeight.Split('[')[1]).Split(']')[0]);
                    //index = Convert.ToInt16(tagWithWeight.Split('[')[1].Substring(0, 1));
                    CntType = Common.GetControlType(tag);
                    Condition con = new PropertyCondition(AutomationElement.ControlTypeProperty, CntType);
                    if (index == 1)
                    {
                        Element = Element.FindFirst(TreeScope.Children, con);
                    }
                    else
                    {
                        Element = Element.FindAll(TreeScope.Children, con)[index - 1];
                    }
                }
            }

            return Element;
        }

        /// <summary>
        /// Searches for an element on the basis of TreePath
        /// </summary>
        /// <param name="ae">parent element</param>
        /// <param name="treePathFromInvokedElemnt"></param>
        /// <param name="isWeightPath"></param>
        /// <returns></returns>
        public static AutomationElement FindElementOnDescendants(this AutomationElement ae, string treePathFromInvokedElemnt, bool isWeightPath)
        {
            AutomationElement Element = ae;
            if (!isWeightPath)
            {
                List<string> pathElemet = treePathFromInvokedElemnt.Split('/').ToList();
                int index = 0;
                foreach (string automationId in pathElemet)
                {
                    Condition Cond = new PropertyCondition(AutomationElement.AutomationIdProperty, pathElemet[index]);
                    Element = Element.FindFirst(TreeScope.Children, Cond);
                    index = index + 1;
                }
            }
            else
            {
                ControlType CntType = null;
                List<string> pathElemet = treePathFromInvokedElemnt.Split('/').ToList();
                int index = 0;
                string tag = string.Empty;
                foreach (string tagWithWeight in pathElemet)
                {
                    tag = tagWithWeight.Split('[')[0];
                    index = Convert.ToInt16((tagWithWeight.Split('[')[1]).Split(']')[0]);
                    //index = Convert.ToInt16(tagWithWeight.Split('[')[1].Substring(0, 1));
                    CntType = Common.GetControlType(tag);
                    Condition con = new PropertyCondition(AutomationElement.ControlTypeProperty, CntType);
                    if (index == 1)
                    {
                        Element = Element.FindFirst(TreeScope.Descendants, con);
                    }
                    else
                    {
                        Element = Element.FindAll(TreeScope.Descendants, con)[index - 1];
                    }
                }
            }

            return Element;
        }

        #endregion

    }

}

