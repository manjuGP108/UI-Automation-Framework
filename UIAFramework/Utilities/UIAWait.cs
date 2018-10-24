using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace UIAFramework
{
    public static class UIAWait
    {
        public static bool WaitUntil(Func<bool> condition, double minute)
        {
            double noOfPool = minute * 60;
            do
            {
                if (condition.Invoke())
                {
                    Thread.Sleep(1000);
                    break;
                }
                else
                {
                    Thread.Sleep(1000);
                }

                noOfPool = noOfPool - 1;
            } while (noOfPool != 0);

            if (noOfPool == 0)
            {
                throw new Exception("Time out.");
            }
            else
            {
                return true;
            }
        }

        public static void WaitFor(int seconds)
        {
            int sleepTime = 1000 * seconds;

            Thread.Sleep(sleepTime);
        }

       
    }
}
