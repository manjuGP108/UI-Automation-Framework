using System;
using System.Threading;
using Microsoft.VisualBasic.Devices;
using System.Text;

namespace UIAFramework
{
    public static class KeyBoard
    {
        /// <summary>
        /// Types plain text in the current focussed control
        /// </summary>     
        public static void EnterText(string text)
        {
            Keyboard ObjKeyBoard = new Keyboard();
            char[] TextCharacters = text.ToCharArray();
            foreach (char ch in TextCharacters)
            {
                ObjKeyBoard.SendKeys(ch.ToString(), true);
            }
        }

        public static void EnterText(StringBuilder text)
        {
            Keyboard ObjKeyBoard = new Keyboard();
            string str = text.ToString();
            char[] TextCharacters = str.ToCharArray();
            foreach (char ch in TextCharacters)
            {
                ObjKeyBoard.SendKeys(ch.ToString(), true);
            }
        }

        /// <summary>
        /// Simulates a combination of two keys. Example. Ctrl + A
        /// </summary>
        public static void SimulateKeys(string modifierKey, string combinedKey)
        {            
            string key = string.Empty;
            Keyboard ObjKeyBoard = new Keyboard();
            switch (modifierKey)
            {
                case "Shift":
                    key = string.Concat("+", "(", combinedKey.ToLower(), ")");
                    break;
                case "Ctrl":
                    key = string.Concat("^", "(", combinedKey.ToLower(), ")");
                    break;
                case "Alt":
                    key = string.Concat("%", "(", combinedKey.ToLower(), ")");
                    break;
                case "ShiftDown":
                    key = string.Concat("+", "{DOWN}");
                    break;
                default:
                    throw new Exception("Incorrect Modifier Key");
            }
            
            ObjKeyBoard.SendKeys(key, true);
        }

        /// <summary>
        /// Simulates the key being sent 
        /// </summary>
        /// <param name="keyToPress">Key to be simulated Example.Control/ Backspace etc</param>
        public static void SimulateKeys(string keyToPress)
        {
            Keyboard ObjKeyBoard = new Keyboard();
            ObjKeyBoard.SendKeys(keyToPress, true);
        }

        /// <summary>
        /// Clears the current text on the focused control by using Ctrl+A and Backspace combination
        /// </summary>
        public static void Clear()
        {
            SimulateKeys("Ctrl", "A");
            Thread.Sleep(1000);
            SimulateKeys("{BS}");
        }

    }
}
