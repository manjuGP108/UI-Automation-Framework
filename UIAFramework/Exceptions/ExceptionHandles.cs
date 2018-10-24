using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAFramework.Exceptions
{
    public class UIA_GenericException : Exception
    {
        public UIA_GenericException(string sMessage) : base(sMessage) { }
    }

    public class UIA_InvalidSearchParameterFormat : Exception
    {
        public UIA_InvalidSearchParameterFormat(string searchParameters)
            : base(string.Format("Search Parameter Format is not valid -> '{0}', should be like 'sKey1=sValue1;sKey2=sValue2;'.", searchParameters))
        { }
    }

    public class UIA_WrongPageExpectedException : Exception
    {
        public UIA_WrongPageExpectedException(string sMessage) : base(sMessage) { }
    }

    public class UIA_InvalidSearchKey : Exception
    {
        public UIA_InvalidSearchKey(string sKey, string searchParameters, List<string> controlProperties)
            : base(string.Format("Search Pattern Key not supported -> '{0}' in '{1}'. Available Properties: {2}", sKey, searchParameters,
            string.Join(", ", controlProperties)))
        { }
    }

    public class UIA_InvalidTraversal : Exception
    {
        public UIA_InvalidTraversal(string sMessage)
            : base(string.Format("You are trying to traverse to an element/control which is not present in the tree: {0}", sMessage))
        { }
    }

    public class UI_NullElement : Exception
    {
        public UI_NullElement(string controlName, string searchAttribute)
            : base(controlName + "  is not  found with search attribute  " + searchAttribute)
        {

        }
    }
}
