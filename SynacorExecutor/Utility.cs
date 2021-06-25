using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynacorExecutor
{
    public static class Utility
    {
        public static ushort[] ConvertFromBytes(byte[] bytes)
        {
            var toReturn = new ushort[bytes.Length / 2];

            for (var i = 0; i < bytes.Length / 2; i++)
            {
                var u = BitConverter.ToUInt16(bytes, i * 2);
                toReturn[i] = u;
            }

            return toReturn;
        }

        public static byte[] ConvertToBytes(ushort[] shorts)
        {
            var toReturn = new byte[shorts.Length * 2];

            for (var i = 0; i < shorts.Length; i++)
            {
                var u = BitConverter.GetBytes(shorts[i]);
                toReturn[i * 2] = u[0];
                toReturn[i * 2 + 1] = u[1];
            }

            return toReturn;
        }

        public static void NOP(double durationSeconds)
        {
            var durationTicks = Math.Round(durationSeconds * Stopwatch.Frequency);
            var sw = Stopwatch.StartNew();

            while (sw.ElapsedTicks < durationTicks) { }
        }
    }
}
