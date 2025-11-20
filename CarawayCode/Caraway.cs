using CarawayCode.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarawayCode
{
    internal static class Options
    {
        public static int DefaultStartIndex { get; set; } = 350;
        public static int SearchWidth { get; set; } = 800;
        public static  int PolesArraySize { get; set; } = 6;

    }


    internal class Caraway
    {
        private static uint[] GetRange(int start, int end) => Enumerable.Range(start, end - start  +1).Select(t => (uint)t).ToArray();

        private bool ArrayCompare(int[] array1, int[] array2) => Enumerable.SequenceEqual(array1.OrderBy(t => t), array2.OrderBy(t => t));

        internal class RNG
        {

            internal uint Current_Rng { get; private set; }

            internal RNG()
            {
                Current_Rng = 1;
            }

            private uint CreateRand(long? seed)
            {
                /**
                * https://en.wikipedia.org/wiki/Linear_congruential_generator
                * FF8's Field RNG is an LCR with:
                * a = 0x41C64E6D = 1103515245
                * b = 0x3039     = 12345
                * m = 0xffffffff = 2^32
                * NewRNG = (OldRNG * a + b) mod m
                **/

                uint a = 0x41C64E6D;
                uint b = 0x3039;
                uint m = 0xffffffff;

                uint randomSeed;
                using (var rng = RandomNumberGenerator.Create())
                {
                    byte[] bytes = new byte[4];
                    rng.GetBytes(bytes);
                    randomSeed = BitConverter.ToUInt32(bytes, 0);
                }

                long z = seed ?? randomSeed;
                uint rngCalc = (uint)(((ulong)z * a + b) & m); // Use ulong to avoid overflow
                return (uint)rngCalc;
            }

            public uint NextRng()
            {
                uint oldRng = Current_Rng;
                Current_Rng = CreateRand(oldRng);
                return oldRng;
            }

            /// <summary>
            /// Random number generation rand(0..32767)
            /// </summary>
            public long Nxt()
            {
                return (NextRng() >> 16) & 32767;
            }

            /// <summary>
            /// Returns the upper 2nd byte of the random number state rand(0..255)
            /// </summary>
            public long Next_1b()
            {
                return Nxt() & 255;
            }
        }

        public List<CarawayOutput> CreateCarawayCodeTable(int from, int to)
        {
            RNG rng = new RNG();
            int margin = 10;
            int size = to + margin;

            uint[] rngStateArray = GetRange(0, size);  //0 - (1015+250)
            rngStateArray = rngStateArray.Select(t => rng.NextRng()).ToArray();

            // Random numbers actually used (0..255)
            // >> is a Right shift operand, which shifts the first operand the specified number of bits
            int[] sourceArray = rngStateArray.Select(t => Convert.ToInt32((t >> 16) & 255)).ToArray();

            return Enumerable.Range(0, to).Select(idx =>
            {
                if (idx < from || idx > to) return null;

                // source
                int source = sourceArray[idx];

                // The code
                int rawCode = source;

                // Game does some logic if the code is out of bounds
                if (source == 0) rawCode = 1;
                else if (source >= 200) rawCode = source - 199;

                // Format it as a 3-digit 0 padded number
                string code = rawCode.ToString().PadLeft(3, '0');

                // The number of utility poles is rand (0..255)% 16
                int polesMinIdx = Math.Max(0, idx - (Options.PolesArraySize + 3));

                int[] polesArray = polesMinIdx < 0 ? null : sourceArray.Skip(polesMinIdx).Take(idx - 4 + 1 - polesMinIdx).Select(t => t % 16).ToArray();
                if (polesArray == null || polesArray.Length == 0) return null;
                string polesHex = string.Join("", polesArray.Select(t => t.ToString("X")));

                string bus = null;
                string street = null;
                string escalator = null;
                string station = null;

                // Station NPC
                if (idx - 1 >= 0)
                {
                    if (sourceArray[idx - 3] >= 100) station = "None";
                    else station = "Walk";
                }

                // Escalator NPC
                if (idx - 2 >= 0)
                {
                    if (sourceArray[idx - 2] >= 150)
                    {
                        if (sourceArray[idx - 1] >= 150) escalator = "None";
                        else escalator = "Boy";
                    }
                    else
                    {
                        if (sourceArray[idx - 1] >= 150) escalator = "Girl";
                        else escalator = "Boy + Girl";
                    }
                }

                // Street NPC
                if (sourceArray[idx + 1] >= 120)
                {
                    if (sourceArray[idx + 1] >= 200)
                    {
                        if (sourceArray[idx + 3] >= 130) street = "Still -> Walk";
                        else street = "None";
                    }
                    else street = "None";
                }
                else street = "Walk";

                // Bus NPC
                if (sourceArray[idx + 1] >= 200)
                {
                    if (sourceArray[idx + 6] < 200)
                    {
                        if (sourceArray[idx + 4] >= 100)
                        {
                            if (sourceArray[idx + 5] >= 100) bus = "Spawn";
                            else bus = "Stop";
                        }
                        else
                        {
                            if (sourceArray[idx + 5] >= 100) bus = "Stop";
                            else bus = "Leave";
                        }
                    }
                    else bus = "None";
                }
                else
                {
                    if (sourceArray[idx + 4] < 200)
                    {
                        if (sourceArray[idx + 2] >= 100)
                        {
                            if (sourceArray[idx + 3] >= 100) bus = "Spawn";
                            else bus = "Stop";
                        }
                        else
                        {
                            if (sourceArray[idx + 3] >= 100) bus = "Stop";
                            else bus = "Leave";
                        }
                    }
                    else bus = "None";
                }

                string codeInput = string.Join(", ", code.Reverse().Select(c =>
                {
                    string up = "↑";
                    string down = "↓";
                    string asIs = "-";
                    string open = "[";
                    string close = "]";

                    int n = int.Parse(c.ToString());
                    if (n == 0) return $"{open}{asIs}{close}";
                    string direction = n <= 5 ? down : up;
                    int count = n <= 5 ? n : 10 - n;
                    return $"{direction}{count}";
                }));

                // RNG State - converted to hex format
                var hexRngState = rngStateArray[idx].ToString("x8");
                return new CarawayOutput(idx, hexRngState, source, code, polesArray, polesHex, station, escalator, street, bus, codeInput);
            }).ToList();
        }
    }
}
