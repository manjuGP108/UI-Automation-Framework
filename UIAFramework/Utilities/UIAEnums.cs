using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAFramework
{

    public static class UIAEnums
    {
        public enum ScrollLimit
        {
            // Summary:
            //     Specifies that scrolling is done in large decrements, equivalent to PageUp
            //     or clicking on a blank part of a scrollbar. If PageUp is not a relevant amount
            //     for the control and/or no scrollbar exists, the value represents an amount
            //     equal to the current visible window.
            LargeDecrement = 0,
            //
            // Summary:
            //     Specifies that scrolling is done in small decrements, equivalent to pressing
            //     an arrow key or clicking the arrow button on a scrollbar.
            SmallDecrement = 1,
            //
            // Summary:
            //     Specifies that scrolling should not be performed.
            NoAmount = 2,
            //
            // Summary:
            //     Specifies that scrolling is done in large increments, equivalent to a PageDown
            //     or clicking on the track of a scrollbar component. If a PageDown is not a
            //     relevant amount for the control and/or no scrollbar exists, the value represents
            //     an amount equal to the current visible region.
            LargeIncrement = 3,
            //
            // Summary:
            //     Specifies that scrolling is done in small increments, equivalent to pressing
            //     an arrow key or clicking the arrow button on a scrollbar.
            SmallIncrement = 4,
            // Summary:
            //     Specifies that scrolling is done in large increments, equivalent to a PageDown
            //     or clicking on the track of a scrollbar component. If a PageDown is not a
            //     relevant amount for the control and/or no scrollbar exists, the value represents
            //     an amount equal to the current visible region.
            LargeIncrementVertical = 5,
            //
            // Summary:
            //     Specifies that scrolling is done in small increments, equivalent to pressing
            //     an arrow key or clicking the arrow button on a scrollbar.
            SmallIncrementVertical = 6,

        }


        public enum ConditionType
        {
            And,
            Or,
            Not

        }
    }
}
