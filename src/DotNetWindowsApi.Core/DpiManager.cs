using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DotNetWindowsApi.Core
{
    public class DpiManager
    {
        [DllImport("user32.dll")] private static extern int GetDpiForWindow(IntPtr window);

        public int GetWindowDpi(IntPtr window)
        {
            return GetDpiForWindow(window);
        }
    }
}
