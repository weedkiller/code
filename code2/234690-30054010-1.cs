    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace Lib.Windows
    {
        class BalloonTip
        {
            private System.Timers.Timer timer = new System.Timers.Timer();
            private SemaphoreSlim semaphore = new SemaphoreSlim(1);
            private IntPtr hWnd;
    
            public BalloonTip(string text, Control control)
            {
                Show("", text, control);
            }
    
            public BalloonTip(string title, string text, Control control, ICON icon = 0, double timeOut = 0, bool focus = false)
            {
                Show(title, text, control, icon, timeOut, focus);
            }
    
            void Show(string title, string text, Control control, ICON icon = 0, double timeOut = 0, bool focus = false)
            {
                ushort x = (ushort)(control.RectangleToScreen(control.ClientRectangle).Left + control.Width / 2);
                ushort y = (ushort)(control.RectangleToScreen(control.ClientRectangle).Top + control.Height / 2);
                TOOLINFO toolInfo = new TOOLINFO();
                toolInfo.cbSize = (uint)Marshal.SizeOf(toolInfo);
                toolInfo.uFlags = 0x20; // TTF_TRACK
                toolInfo.lpszText = text;
                IntPtr pToolInfo = Marshal.AllocCoTaskMem(Marshal.SizeOf(toolInfo));
                Marshal.StructureToPtr(toolInfo, pToolInfo, false);
                byte[] buffer = Encoding.UTF8.GetBytes(title);
                buffer = buffer.Concat(new byte[] { 0 }).ToArray();
                IntPtr pszTitle = Marshal.AllocCoTaskMem(buffer.Length);
                Marshal.Copy(buffer, 0, pszTitle, buffer.Length);
                hWnd = User32.CreateWindowEx(0x8, "tooltips_class32", "", 0xC3, 0, 0, 0, 0, control.Parent.Handle, (IntPtr)0, (IntPtr)0, (IntPtr)0);
                User32.SendMessage(hWnd, 1028, (IntPtr)0, pToolInfo); // TTM_ADDTOOL
                User32.SendMessage(hWnd, 1041, (IntPtr)1, pToolInfo); // TTM_TRACKACTIVATE
                User32.SendMessage(hWnd, 1042, (IntPtr)0, (IntPtr)(x | (y << 16))); // TTM_TRACKPOSITION
                //User32.SendMessage(hWnd, 1043, (IntPtr)0, (IntPtr)0); // TTM_SETTIPBKCOLOR
                //User32.SendMessage(hWnd, 1044, (IntPtr)0xffff, (IntPtr)0); // TTM_SETTIPTEXTCOLOR
                User32.SendMessage(hWnd, 1056, (IntPtr)icon, pszTitle); // TTM_SETTITLE 0:None, 1:Info, 2:Warning, 3:Error, >3:assumed to be an hIcon. ; 1057 for Unicode
                User32.SendMessage(hWnd, 1048, (IntPtr)0, (IntPtr)500); // TTM_SETMAXTIPWIDTH
                User32.SendMessage(hWnd, 0x40c, (IntPtr)0, pToolInfo); // TTM_UPDATETIPTEXT; 0x439 for Unicode
                Marshal.FreeCoTaskMem(pszTitle);
                Marshal.DestroyStructure(pToolInfo, typeof(TOOLINFO));
                Marshal.FreeCoTaskMem(pToolInfo);
                if (focus)
                    control.Focus();
                control.Click += control_Event;
                control.Leave += control_Event;
                control.TextChanged += control_Event;
                control.LocationChanged += control_Event;
                control.TopLevelControl.LocationChanged += control_Event;
                control.TopLevelControl.SizeChanged += control_Event;
                ((Form)control.TopLevelControl).Deactivate += control_Event;
                timer.AutoReset = false;
                timer.Elapsed += timer_Elapsed;
                if (timeOut > 0)
                {
                    timer.Interval = timeOut;
                    timer.Start();
                }
            }
    
            void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                Close();
            }
    
            void control_Event(object sender, EventArgs e)
            {
                Close();
            }
    
            void Close()
            {
                if (!semaphore.Wait(0)) // ensures one time only execution
                    return;
                timer.Elapsed -= timer_Elapsed;
                timer.Close();
                User32.SendMessage(hWnd, 0x0010, (IntPtr)0, (IntPtr)0); // WM_CLOSE
                //User32.SendMessage(hWnd, 0x0002, (IntPtr)0, (IntPtr)0); // WM_DESTROY
                //User32.SendMessage(hWnd, 0x0082, (IntPtr)0, (IntPtr)0); // WM_NCDESTROY
            }
    
            [StructLayout(LayoutKind.Sequential)]
            struct TOOLINFO
            {
                public uint cbSize;
                public uint uFlags;
                public IntPtr hwnd;
                public IntPtr uId;
                public RECT rect;
                public IntPtr hinst;
                [MarshalAs(UnmanagedType.LPStr)]
                public string lpszText;
                public IntPtr lParam;
            }
            [StructLayout(LayoutKind.Sequential)]
            struct RECT
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }
    
            public enum ICON
            {
                NONE,
                INFO,
                WARNING,
                ERROR
            }
        }
    
        static class User32
        {
            [DllImportAttribute("user32.dll")]
            public static extern int SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
            [DllImportAttribute("user32.dll")]
            public static extern IntPtr CreateWindowEx(uint dwExStyle, string lpClassName, string lpWindowName, uint dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr LPVOIDlpParam);
        }
    }
