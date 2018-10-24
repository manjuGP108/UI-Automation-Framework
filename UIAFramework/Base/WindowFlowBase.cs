using System.Collections.Generic;

namespace UIAFramework
{
    public class WindowFlowBase<T>
    {
        private readonly T _windowBase;
        public WindowFlowBase() { }
        public WindowFlowBase(T windowBase)
        {
            _windowBase = windowBase;
        }

        public T Window
        {
            get { return _windowBase; }
        }
    }
}
