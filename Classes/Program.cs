using System;
using System.Threading.Tasks;
using Halo_MCC_Offset_Dumper.Classes;
using Memory;

namespace Halo_MCC_Offset_Dumper
{
    internal class Program
    {
        static Mem Memory = new Mem();
        static async Task Main()
        {
            Prerequisites.ConsoleSetup();
            await Prerequisites.GetProcess(Memory);
            try
            {
               Console.WriteLine("Starting AoB Scan:\n");
               await AoBScan.Start(Memory);
               Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an unexpected error, please contact zqq#7441\n\n Error:");
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
