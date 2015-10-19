using System;
using System.Runtime.InteropServices;
using System.Windows;


namespace ConsoleApplication10
{
    class Program
    {
        const int SWP_NOSIZE = 0x0001;
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static readonly IntPtr MyConsole = GetConsoleWindow();
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        private static int maxWidth = (int) SystemParameters.VirtualScreenWidth - Console.LargestWindowWidth + 100;
        private static int maxHeight = (int)SystemParameters.VirtualScreenHeight - Console.LargestWindowHeight;

        public static int currentX;
        public static int currentY;
        public static bool moveLeft = true;
        public  static bool moveDown = true;

        static void Main()
        {
            Console.SetWindowSize(10, 2);

            while (true)
            {
                currentY += moveDown ? 1 : -1;
                currentX += moveLeft ? 1 : -1;

                if (currentY >= maxHeight) moveDown = false;
                if (currentY <= 0) moveDown = true;

                if (currentX >= maxWidth) moveLeft = false;
                if (currentX <= 0) moveLeft = true;

                SetWindowPos(MyConsole, 0, currentX, currentY, 0, 0, SWP_NOSIZE);
                System.Threading.Thread.Sleep(2);
            }
        }
    }
}