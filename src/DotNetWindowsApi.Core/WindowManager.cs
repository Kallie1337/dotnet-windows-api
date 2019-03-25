using System;
using System.Runtime.InteropServices;

namespace DotNetWindowsApi.Core
{
    public class WindowManager
    {
        [DllImport("user32.dll")] private static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")] private static extern IntPtr GetShellWindow();
        [DllImport("user32.dll")] private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")] private static extern IntPtr FindWindowA(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")] private static extern IntPtr FindWindowExA(IntPtr hWndParent, IntPtr hWndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll")] private static extern bool GetClientRect(IntPtr hWnd, ref Rect lpRect);

        public IntPtr GetRootDesktopWindow()
        {
            return GetDesktopWindow();
        }

        public IntPtr GetRootShellWindow()
        {
            return GetShellWindow();
        }

        public IntPtr GetActiveWindow()
        {
            return GetForegroundWindow();
        }

        public IntPtr FindWindow(string className, string windowTitle)
        {
            return FindWindowA(className, windowTitle);
        }

        public IntPtr FindChildWindow(IntPtr parentWindow, IntPtr firstChildWindow, string className, string windowTitle)
        {
            return FindWindowExA(parentWindow, firstChildWindow, className, windowTitle);
        }

        public Rect GetWindowPosition(IntPtr window)
        {
            Rect rect = new Rect();
            GetClientRect(window, ref rect);
            return rect;
        }
    }
}