using DotNetWindowsApi.Core;
using System;

namespace DotNetWindowsApi.Tests
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WindowManager windowManager = new WindowManager();

            IntPtr window = windowManager.FindWindow("", "");
            IntPtr childOfWindow = windowManager.FindChildWindow(IntPtr.Zero, IntPtr.Zero, "", "");

            IntPtr desktop = windowManager.GetRootDesktopWindow();
            IntPtr shell = windowManager.GetRootShellWindow();
            IntPtr active = windowManager.GetActiveWindow();

            Rect windowRect = windowManager.GetWindowPosition(IntPtr.Zero);
        }
    }
}