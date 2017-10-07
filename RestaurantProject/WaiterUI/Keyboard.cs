using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WaiterUI
{
    class Keyboard
    {
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern bool SetWindowPos(
int hWnd, // window handle
int hWndInsertAfter, // placement-order handle
int X, // horizontal position
int Y, // vertical position
int cx, // width
int cy, // height
uint uFlags); // window positioning flags
        public const int HWND_BOTTOM = 0x0001;
        public const int HWND_TOP = 0x0000;
        public const int SWP_NOSIZE = 0x0001;
        public const int SWP_NOMOVE = 0x0002;
        public const int SWP_NOZORDER = 0x0004;
        public const int SWP_NOREDRAW = 0x0008;
        public const int SWP_NOACTIVATE = 0x0010;
        public const int SWP_FRAMECHANGED = 0x0020;
        public const int SWP_SHOWWINDOW = 0x0040;
        public const int SWP_HIDEWINDOW = 0x0080;

        internal void ShowDialog()
        {
            throw new NotImplementedException();
        }

        public const int SWP_NOCOPYBITS = 0x0100;
        public const int SWP_NOOWNERZORDER = 0x0200;
        public const int SWP_NOSENDCHANGING = 0x0400;

        public object DialogResult { get; internal set; }
        public string Text1 { get; internal set; }
    }

}


