﻿using System;
using System.Runtime.InteropServices;
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
    }
}