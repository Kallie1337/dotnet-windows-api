using DotNetWindowsApi.Core;
using System;

namespace DotNetWindowsApi.Tests
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WindowManager windowManager = new WindowManager();
            DpiManager dpiManager = new DpiManager();

            IntPtr window = windowManager.FindWindow("CabinetWClass", "This PC");
            IntPtr childOfWindow = windowManager.FindChildWindow(IntPtr.Zero, IntPtr.Zero, "", "");

            IntPtr desktop = windowManager.GetDesktopWindow();
            IntPtr shell = windowManager.GetShellWindow();

            Rect windowRect = windowManager.GetWindowRect(window);
            Rect clientRect = windowManager.GetClientRect(window);

            Console.WriteLine($"{windowRect.left} {windowRect.right} {windowRect.top} {windowRect.bottom}");
            Console.WriteLine($"{clientRect.left} {clientRect.right} {clientRect.top} {clientRect.bottom}");

            windowManager.SetWindowPos(window, WindowManagerDependencies.WindowZOrder.HWND_TOPMOST, 0, 0, 800, WindowManagerDependencies.WindowSizingAndPositioningFlags.SWP_ASYNCWINDOWPOS);

            int dpi = dpiManager.GetWindowDpi(window);

            Console.WriteLine(dpi);

        }
    }
}