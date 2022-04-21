using Memory;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Halo_MCC_Offset_Dumper.Classes
{
    internal class AoBScan
    {
        static IntPtr ptr;
        static string result;

        public static async Task Start(Mem memory)
        {
            ModuleBase(memory);
            OffsetBuilder.Startup();
            foreach(var byteArray in OffsetBuilder.Offsets)
            {
                await Scan(memory, byteArray);
            }
        }

        internal static async Task Scan(Mem memory, KeyValuePair<string, AddressDetails> byteArray)
        {
            if (memory.modules.TryGetValue("haloreach.dll", out ptr))
            {
                var memoryAddressesFound = await memory.AoBScan(0, 1407347471578112L, byteArray.Value.Signature, true, true);
                if (!memoryAddressesFound?.Any() ?? true) return;

                long scan =  memoryAddressesFound.First();
                result = (scan - (long)ptr).ToString("X8");


                byteArray.Value.Offset = result;
                Console.WriteLine($"{byteArray.Key}: haloreach.dll+{ result }");
                Offset();
            }
        }

        internal static void ModuleBase(Mem Memory)
        {
            if (Memory.modules.TryGetValue("haloreach.dll", out ptr))
            {
                result = ptr.ToString("X8");
                Console.WriteLine("Module Base: haloreach.dll+" + result);
            }
        }

        static internal void Offset()
        {
            //The address is set in the OffsetBuilder.Offset list

            //Option 1
            var aimAngle = OffsetBuilder.Offsets["aim_Angle"];

            //Option 2
            if(OffsetBuilder.Offsets.TryGetValue("aim_Angle", out var value))
            {
                
            };

            //Option 3
            var opt3 = OffsetBuilder.Offsets.FirstOrDefault(x => x.Key == "aim_Angle");

        }
    }
}
