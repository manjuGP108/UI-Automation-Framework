using System;
using System.Windows;
using System.Windows.Automation;

namespace UIAFramework
{
    public class Coordinate
    {
        AutomationElement Element;

        private Coordinate(AutomationElement ae)
        {
            Element = ae;
        }

        public static implicit operator Coordinate(AutomationElement ae)
        {
            return new Coordinate(ae);
        }

        public int X
        {
            get
            {
                int t = Convert.ToInt32(Element.Current.BoundingRectangle.X);
                int p = (Convert.ToInt32(Element.Current.BoundingRectangle.Size.Width) / 2);
                return p + t;
            }
        }

        public int Y
        {
            get
            {
                int t = Convert.ToInt32(Element.Current.BoundingRectangle.Y);
                int p = (Convert.ToInt32(Element.Current.BoundingRectangle.Size.Height) / 2);
                return p + t;
            }
        }

        public Rect Boundries
        {
            get
            {
                return Element.Current.BoundingRectangle;
            }
        }
    }
}
