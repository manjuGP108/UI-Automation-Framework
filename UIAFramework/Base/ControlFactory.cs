using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace UIAFramework.Base
{
    public static class ControlFactory
    {
        #region Create OverLoad Methods
        /// <summary>
        /// Creates an instance of type T1
        /// </summary>
        /// <typeparam name="T1">Type of object to be created</typeparam>
        /// <param name="condition">condition for object identification</param>
        /// <param name="treescope">scope for object search</param>
        /// <returns></returns>       
        public static T1 Create<T1>(string condition, string treescope, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "") 
            where T1 : ControlBase
        {
            object obj = null;
            //if (ParentBase.controlType.ProgrammaticName == ParentBase.controlType.ProgrammaticName)
            //{
                UIAWait.WaitUntil(() =>
            {
                obj = (T1)Activator.CreateInstance(typeof(T1), new object[] { condition, treescope, type, memberName });
                if (obj == null)
                    return false;
                else
                    return true;
            }, 0.25);

                return (T1)obj;
            //}
            //else
            //    throw new Exception(ParentBase.controlName + " is not of type " + ParentBase.controlType.ProgrammaticName);
          
        }

        public static T1 Create<T1>(string condition, string treescope, AutomationElement parent, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "") 
            where T1:ControlBase
        {
            object obj = null;
            if (ParentBase.controlType.ProgrammaticName == ParentBase.controlType.ProgrammaticName)
            {
               
                    UIAWait.WaitUntil(() =>
                    {
                        obj = (T1)Activator.CreateInstance(typeof(T1), new object[] { condition, treescope, parent, type, memberName });
                        if (obj == null)
                            return false;
                        else
                            return true;
                    }, 0.25);
                    return (T1)obj;
               
            }
            else
                throw new Exception(ParentBase.controlName + " is not of type " + ParentBase.controlType.ProgrammaticName);
        }

        public static T1 Create<T1>(string path, bool ispath, [CallerMemberName] string memberName = "") where T1 : ControlBase
        {
            object obj = null;
            if (ParentBase.controlType.ProgrammaticName == ParentBase.controlType.ProgrammaticName)
            {
                UIAWait.WaitUntil(() =>
                {
                    obj = (T1)Activator.CreateInstance(typeof(T1), new object[] { path, ispath, memberName });
                    if (obj == null)
                        return false;
                    else
                        return true;
                }, 0.25);
                return (T1)obj;
            }
            else
                throw new Exception(ParentBase.controlName + " is not of type " + ParentBase.controlType.ProgrammaticName);
        }

        public static T1 Create<T1>(string path, bool ispath, AutomationElement parent) where T1:ControlBase
        {
             object obj = null;
             if (ParentBase.controlType.ProgrammaticName == ParentBase.controlType.ProgrammaticName)
             {
                 UIAWait.WaitUntil(() =>
                 {
                     obj = (T1)Activator.CreateInstance(typeof(T1), new object[] { path, ispath, parent });
                     if (obj == null)
                         return false;
                     else
                         return true;
                 }, 0.25);
                 return (T1)obj;
             } 
            else
                throw new Exception(ParentBase.controlName + " is not of type " + ParentBase.controlType.ProgrammaticName);
        }

        public static List<T1> CreateAll<T1>(string condition, string treescope, UIAEnums.ConditionType? type = null, [CallerMemberName] string memberName = "") where T1 : ControlBase
        {
            List<T1> objList = new List<T1>();
            object  obj = null;
            if (ParentBase.controlType.ProgrammaticName == ParentBase.controlType.ProgrammaticName)
            {

                UIAWait.WaitUntil(() =>
                {
                    obj = (T1)Activator.CreateInstance(typeof(T1), new object[] { condition, treescope,true, type, memberName });
                    if (obj == null)
                        return false;
                    else
                        return true;
                }, 0.25);


                AutomationElementCollection collection = ((UIAFramework.ControlBase)(obj)).NativeElementList;
                foreach (AutomationElement item in collection)
                {
                   objList.Add((T1)Activator.CreateInstance(typeof(T1), new object[] { item, memberName }));
      
                }

            }
            else
                throw new Exception(ParentBase.controlName + " is not of type " + ParentBase.controlType.ProgrammaticName);
            return objList;
        }

        #endregion

        #region Get Parents/Children Methods

        public static T1 GetParent<T1>(AutomationElement ae)
        {
            AutomationElement element = TreeWalker.RawViewWalker.GetParent(ae);
            return (T1)Activator.CreateInstance(typeof(T1), new object[] { element });
        }

        public static T1 GetFirstChild<T1>(AutomationElement ae)
        {
            AutomationElement element = TreeWalker.RawViewWalker.GetFirstChild(ae);
            return (T1)Activator.CreateInstance(typeof(T1), new object[] { element });
        }

        public static T1 GetNextSibling<T1>(AutomationElement ae)
        {
            AutomationElement element = TreeWalker.RawViewWalker.GetNextSibling(ae);
            return (T1)Activator.CreateInstance(typeof(T1), new object[] { element });
        }

        public static T1 GetPreviousSibling<T1>(AutomationElement ae)
        {
            AutomationElement element = TreeWalker.RawViewWalker.GetPreviousSibling(ae);

            return (T1)Activator.CreateInstance(typeof(T1), new object[] { element });
        }

        public static T1 GetLastChild<T1>(AutomationElement ae)
        {
            AutomationElement element = TreeWalker.RawViewWalker.GetLastChild(ae);
            return (T1)Activator.CreateInstance(typeof(T1), new object[] { element });
        }
        #endregion

        public static TT GetStart<TT, T>()
            where TT : WindowFlowBase<T>
            where T : WindowBase
        {

            var window = (T)Activator.CreateInstance(typeof(T));
            return (TT)Activator.CreateInstance(typeof(TT), window);
        }

    }
}
