using System;
using System.Runtime.InteropServices;
using System.Threading;
using BehaviorRecorder.Models;

namespace BehaviorRecorder.Helpers
{
    public static class WindowsBehaviorHelper
    {
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point lpPoint);

        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        public static extern int GetKeyboardState(byte[] keystate);

        [DllImport("user32.dll")]
        public static extern int SetKeyboardState(byte[] keystate);

        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);

        [DllImport("user32.dll")]
        public static extern short GetKeyState(int vKey);

        // A very simple implementation for tracking the state of the left mouse button.
        static void detect()
        {
            short oldState = GetKeyState(0x01);

            while (true)
            {
                short newState = GetKeyState(0x01);                

                if (oldState != newState)
                {
                    oldState = newState;

                    if (newState < 0)
                    {
                        onMouseClick();
                    }
                }

                Thread.Sleep(50);
            }
        }

        static void onMouseClick()
        {
            Console.WriteLine("Clicked!");
        }
        public static void LeftMouseClick(int xPosition, int yPosition)
        {
            SetCursorPos(xPosition, yPosition);
            mouse_event(MouseEventFlag.LeftDown, xPosition, yPosition, 0, new UIntPtr());
            mouse_event(MouseEventFlag.LeftUp, xPosition, yPosition, 0, new UIntPtr());
        }
    }
}