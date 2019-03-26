using System;
using System.Runtime.InteropServices;

namespace DotNetWindowsApi.Core
{
    public static class WindowManagerDependencies
    {
        [DllImport("user32.dll")] public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")] public static extern IntPtr GetShellWindow();
        [DllImport("user32.dll")] public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")] public static extern IntPtr FindWindowA(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")] public static extern IntPtr FindWindowExA(IntPtr hWndParent, IntPtr hWndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll")] public static extern bool GetClientRect(IntPtr hWnd, ref Rect lpRect);
        [DllImport("user32.dll")] public static extern bool GetWindowRect(IntPtr hWnd, ref Rect lpRect);
        [DllImport("user32.dll")] public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, ulong uFlag);
        [DllImport("user32.dll")] public static extern bool CloseWindow(IntPtr hWnd);

        /// <summary>
        /// A handle to the window to precede the positioned window in the Z order.
        /// This parameter must be one of the following values.
        /// </summary>
        public struct WindowZOrder
        {
            /// <summary>
            /// Places the window at the bottom of the Z order.
            /// </summary>
            public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

            /// <summary>
            /// Places the window at the top of the Z order. 
            /// </summary>
            public static readonly IntPtr HWND_TOP = new IntPtr(0);

            /// <summary>
            /// Places the window above all non-topmost windows.
            /// The window maintains its topmost position even when it is deactivated. 
            /// </summary>
            public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        }

        /// <summary>
        /// 
        /// </summary>
        public struct WindowSizingAndPositioningFlags
        {
            /// <summary>
            /// If the calling thread and the thread that owns the window are attached to different input queues,
            /// the system posts the request to the thread that owns the window. 
            /// </summary>
            public static readonly ulong SWP_ASYNCWINDOWPOS = 0x4000;

            /// <summary>
            /// Prevents generation of the WM_SYNCPAINT message. 
            /// </summary>
            public static readonly ulong SWP_DEFERERASE = 0x2000;

            /// <summary>
            /// Draws a frame (defined in the window's class description) around the window. 
            /// </summary>
            public static readonly ulong SWP_DRAWFRAME = 0x0020;

            /// <summary>
            /// Hides the window. 
            /// </summary>
            public static readonly ulong SWP_HIDEWINDOW = 0x0080;

            /// <summary>
            /// Does not activate the window.
            /// </summary>
            public static readonly ulong SWP_NOACTIVATE = 0x0010;

            /// <summary>
            /// Discards the entire contents of the client area. 
            /// </summary>
            public static readonly ulong SWP_NOCOPYBITS = 0x0100;

            /// <summary>
            /// Retains the current position (ignores X and Y parameters). 
            /// </summary>
            public static readonly ulong SWP_NOMOVE = 0x0002;

            /// <summary>
            /// Does not change the owner window's position in the Z order. 
            /// </summary>
            public static readonly ulong SWP_NOOWNERZORDER = 0x0200;

            /// <summary>
            ///  Does not redraw changes. 
            /// </summary>
            public static readonly ulong SWP_NOREDRAW = 0x0008;

            /// <summary>
            /// Prevents the window from receiving the WM_WINDOWPOSCHANGING message. 
            /// </summary>
            public static readonly ulong SWP_NOSENDCHANGING = 0x0400;

            /// <summary>
            /// Retains the current size (ignores the cx and cy parameters). 
            /// </summary>
            public static readonly ulong SWP_NOSIZE = 0x0001;

            /// <summary>
            /// Retains the current Z order (ignores the hWndInsertAfter parameter). 
            /// </summary>
            public static readonly ulong SWP_NOZORDER = 0x0004;

            /// <summary>
            /// Displays the window. 
            /// </summary>
            public static readonly ulong SWP_SHOWWINDOW = 0x0040;
        }
    }
    public class WindowManager
    {
        /// <summary>
        /// Retrieves a handle to the desktop window. 
        /// </summary>
        /// <returns>The return value is a handle to the desktop window.</returns>
        public IntPtr GetDesktopWindow()
        {
            return WindowManagerDependencies.GetDesktopWindow();
        }

        /// <summary>
        /// Retrieves a handle to the Shell's desktop window.
        /// </summary>
        /// <returns>The return value is the handle of the Shell's desktop window.</returns>
        public IntPtr GetShellWindow()
        {
            return WindowManagerDependencies.GetShellWindow();
        }

        /// <summary>
        /// Retrieves a handle to the foreground window.
        /// </summary>
        /// <returns>The return value is a handle to the foreground window.</returns>
        public IntPtr GetForegroundWindow()
        {
            return WindowManagerDependencies.GetForegroundWindow();
        }

        /// <summary>
        /// Retrieves a handle to the top-level window whose class name and window name match the specified strings.
        /// </summary>
        /// <param name="className">The class name.</param>
        /// <param name="windowTitle">The window name.</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has the specified class name and window name.</returns>
        public IntPtr FindWindow(string className, string windowTitle)
        {
            return WindowManagerDependencies.FindWindowA(className, windowTitle);
        }

        /// <summary>
        /// Retrieves a handle to a window whose class name and window name match the specified strings.
        /// The function searches child windows, beginning with the one following the specified child window.
        /// </summary>
        /// <param name="parentWindow">A handle to the parent window whose child windows are to be searched.</param>
        /// <param name="firstChildWindow">A handle to a child window.</param>
        /// <param name="className">The class name.</param>
        /// <param name="windowTitle">The window name.</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has the specified class and window names.</returns>
        public IntPtr FindChildWindow(IntPtr parentWindow, IntPtr firstChildWindow, string className, string windowTitle)
        {
            return WindowManagerDependencies.FindWindowExA(parentWindow, firstChildWindow, className, windowTitle);
        }

        /// <summary>
        /// Retrieves the coordinates of a window's client area.
        /// </summary>
        /// <param name="window">A handle to the window whose client coordinates are to be retrieved.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        public Rect GetClientRect(IntPtr window)
        {
            Rect rect = new Rect();
            WindowManagerDependencies.GetClientRect(window, ref rect);
            return rect;
        }

        /// <summary>
        /// Retrieves the dimensions of the bounding rectangle of the specified window. 
        /// </summary>
        /// <param name="window">A handle to the window.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        public Rect GetWindowRect(IntPtr window)
        {
            Rect rect = new Rect();
            WindowManagerDependencies.GetWindowRect(window, ref rect);
            return rect;
        }

        /// <summary>
        /// Changes the size, position, and Z order of a child, pop-up, or top-level window. 
        /// </summary>
        /// <param name="window">A handle to the window.</param>
        /// <param name="zOrder">A handle to the window to precede the positioned window in the Z order. </param>
        /// <param name="x">The new position of the left side of the window, in client coordinates.</param>
        /// <param name="y">The new position of the top of the window, in client coordinates.</param>
        /// <param name="w">The new width of the window, in pixels.</param>
        /// <param name="h">The new height of the window, in pixels.</param>
        /// <param name="adds">The window sizing and positioning flags.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        public bool SetWindowPos(IntPtr window, IntPtr zOrder, int x, int y, int w, int h, ulong adds)
        {
            return WindowManagerDependencies.SetWindowPos(window, zOrder, x, y, w, h, adds);
        }

        /// <summary>
        /// Minimizes (but does not destroy) the specified window.
        /// </summary>
        /// <param name="window">A handle to the window to be minimized.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        public bool MinimizeWindow(IntPtr window)
        {
            return WindowManagerDependencies.CloseWindow(window);
        }
    }
}