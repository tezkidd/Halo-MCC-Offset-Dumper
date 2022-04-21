using System.Collections.Generic;

namespace Halo_MCC_Offset_Dumper
{
    public class OffsetBuilder
    {
        public static Dictionary<string, AddressDetails> Offsets = new Dictionary<string, AddressDetails>();

        public static void Startup()
        {
            Offsets.Add("aim_Angle", new AddressDetails { Signature = "F3 41 0F 59 8C AE 08 03 00 00" });
            Offsets.Add("aim_Range", new AddressDetails { Signature = "F3 41 0F 59 94 AE 0C 03 00 00" });
            Offsets.Add("aim_Deviation", new AddressDetails { Signature = "F3 41 0F 10 84 AE 28 03 00 00" });
        }
    }

   public class AddressDetails
    {
        public string Signature;
        public string Offset;
    }
}
