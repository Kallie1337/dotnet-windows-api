using DotNetWindowsApi.Core;
using System;

namespace DotNetWindowsApi.Tests
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WindowManager windowManager = new WindowManager();

            var window = windowManager.FindWindow("CabinetWClass", "This PC");
            var windowChild = windowManager.FindChildWindow(window, IntPtr.Zero, "", "");
            var desktop = windowManager.GetDesktopWindow();
            var shell = windowManager.GetShellWindow();
            var foreground = windowManager.GetForegroundWindow();

            var windowRect = windowManager.GetWindowRect(window);
            var clientRect = windowManager.GetClientRect(window);

            var x = windowManager.SetWindowPos(window, WindowManagerDependencies.WindowZOrder.HWND_TOPMOST, 0, 0, 200, 200,
                WindowManagerDependencies.WindowSizingAndPositioningFlags.SWP_SHOWWINDOW);

            windowManager.MinimizeWindow(window);
        }
    }
}