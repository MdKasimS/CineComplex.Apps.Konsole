using CineComplex.Views;
using System.Runtime.InteropServices;
using CineComplex.Interfaces;
using CineComplex.Models;


namespace CineComplex
{
    internal class Program
    {
        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        const int MF_BYCOMMAND = 0x00000000;
        const int SC_MINIMIZE = 0xF020;
        const int SC_MAXIMIZE = 0xF030;
        const int SC_SIZE = 0xF000;

        private static void Main(string[] args)
        {
            // Console.WindowHeight = 25;
            // Console.WindowWidth = 120;


            // Console.BufferHeight = Console.WindowHeight; // Set the buffer height equal to the window height
            // Console.BufferWidth = Console.WindowWidth;   // Set the buffer width equal to the window width


            // DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MINIMIZE, MF_BYCOMMAND);
            // DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MAXIMIZE, MF_BYCOMMAND);
            // DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_SIZE, MF_BYCOMMAND);


            SQLInteraction.Instance.Init();
            IView app = HomeView.Instance;

            app.View();

        }
    }
}