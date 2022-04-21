using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Memory;

namespace Halo_MCC_Offset_Dumper.Classes
{
    internal class Prerequisites
    {
        #region

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        #endregion

        public static void ConsoleSetup()
        {
            Console.Title = Process.GetCurrentProcess().ProcessName + " | Created by tezkidd (zqq)";
            Console.SetWindowSize(80, 30);
            Console.SetBufferSize(80, 30);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public async static Task<bool> GetProcess(Mem Memory)
        {
            while (!Process.GetProcessesByName("MCC-Win64-Shipping").Any())
            {
                Console.Clear();
                Console.Write("Waiting for Halo");
                await Task.Delay(5000);
            }

            if (Process.GetProcessesByName("MCC-Win64-Shipping").Count() > 0)
            {
                Memory.OpenProcess("MCC-Win64-Shipping");                                                           //Open the process
                while (Memory.modules.Count < 180)                                                                     //Check all modules are loaded for full AoB Scan
                {
                    Console.Clear();
                    Console.WriteLine(Memory.modules.Count + " process modules found, re-running...");
                    Memory.CloseProcess();
                    await Task.Delay(5000);
                    Memory.OpenProcess("MCC-Win64-Shipping");
                }
            }

            Console.Clear();
            Console.WriteLine("Process opened: MCC-Win64-Shipping");
            Console.WriteLine("Found " + Memory.modules.Count + " process modules\n");
            Console.WriteLine("--------------------------------------\n");

            return true;
        }
    }
}
