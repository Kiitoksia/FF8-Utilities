using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UltimeciaManip.Models;

namespace UltimeciaManip
{
    public class UltiManip
    {
        FinalPartyManipOptions _options;

        private int PartyRndOffset { get; }

        private List<PartyFormation> Formations { get; set; }


        public UltiManip(FinalPartyManipOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));

            double rem = _options.LastMapDuration % 0.5;
            double minSafe = _options.LastMapSafeRange.Min();
            double maxSafe = _options.LastMapSafeRange.Max();
            double lastMapExtra = Between(rem, minSafe, maxSafe) ? 0 : (rem < minSafe ? 0.25 - rem : 0.75 - rem);

            PartyRndOffset = (int)Math.Floor((_options.LastMapDuration + lastMapExtra) / 0.5) + 1;

            Init();
        }

        private void Init()
        {
            int startIndex = _options.Base;
            var orderArr = Range(0, _options.Width / 2).ToArray();

            var order = orderArr.Select(offset => new[] { startIndex + offset, startIndex - offset })
                                .SelectMany(x => x)
                                .Where(idx => idx >= 0)
                                .Distinct()
                                .ToList();

            if (IsEven(_options.Width))
            {
                int max = order.Max();
                order.Remove(max);
            }

            int min = order.Min();
            int maxIdx = order.Max();

            switch (_options.Order)
            {
                case "reverse":
                    order.Reverse();
                    break;
                case "ascending":
                    order.Sort();
                    break;
                case "descending":
                    order = order.OrderByDescending(x => x).ToList();
                    break;
            }

            Formations = MakeLastPartyTable(min, maxIdx);
        }

        private List<PartyFormation> MakeLastPartyTable(int from, int to)
        {
            var rng = new RNG();
            int margin = 250;
            int size = to + margin;

            var rngStateArr = Range(0, size).Select(x => rng.NextRng()).ToArray();

            var sourceRng = new RNG();
            var sourceArr = Range(0, size).Select(x => sourceRng.Next_1b()).ToArray();

            var directionArr = sourceArr.Select(v => new[] { "8", "2", "4", "6" }[v & 3]).ToArray();

            int lastPartySize = size - PartyRndOffset;
            var partyArr = Enumerable.Range(0, lastPartySize)
                .Select(idx => LastParty((int)sourceArr[idx + PartyRndOffset]))
                .ToArray();

            var targetOffsetTblArr = GenerateOffsetTable(partyArr);

            var table = new List<PartyFormation>();
            for (int idx = from; idx <= to; idx++)
            {
                if (idx < from || idx > to) continue;

                var row = new PartyFormation
                {
                    Index = idx,
                    Source = (int)sourceArr[idx],
                    RngState = rngStateArr[idx].ToString("X"),
                    Party = partyArr[idx],
                    Movements = directionArr.Skip(Math.Max(0, idx - (_options.MovementsSize - 1))).Take(_options.MovementsSize).Select(c => c[0].ToDirection()).ToArray(),
                    TargetOffsetTbl = _options.Targets.Select(targetParty => new TargetOffset
                    {
                        Party = targetParty,
                        Offset = targetOffsetTblArr[idx].ContainsKey(targetParty) ? targetOffsetTblArr[idx][targetParty] : 0
                    }).ToList()
                };

                int minOffset = row.TargetOffsetTbl.Min(item => item.Offset);
                row.NearestTarget = row.TargetOffsetTbl.First(item => item.Offset == minOffset).Party;

                table.Add(row);
            }

            return table;
        }

        private List<Dictionary<PartyMember[], int>> GenerateOffsetTable(PartyMember[][] partyArr)
        {
            var targets = _options.Targets;
            var r = new List<Dictionary<PartyMember[], int>>();
            var reversedPartyArr = partyArr.Reverse().ToArray();

            for (int i = 0; i < reversedPartyArr.Length; i++)
            {
                PartyMember[] currentParty = reversedPartyArr[i];
                r.Add(new Dictionary<PartyMember[], int>(new PartyComparer()));
                if (i > 0)
                {
                    // Increment the number for each party from the last index
                    Dictionary<PartyMember[], int> lastValue = r[i - 1];
                    foreach (var key in lastValue.Keys)
                    {
                        r[i][key] = lastValue[key] + 1;
                    }
                }

                foreach (var elem in targets)
                {
                    if (ArrayCompare(currentParty, elem))
                    {
                        r[i][currentParty] = 0;
                    }
                }
            }

            r.Reverse();
            return r;
        }

        public PartyFormation[] SearchLastParty(Direction[] movements)
        {
            if (movements.Length != _options.MovementsSize) return null;

            string pattern = string.Join("", movements.Select(d => d.ToDirectionCharacter()));
            pattern = pattern.Replace("5", ".");

            PartyFormation[] results = Formations.Where(i => Regex.IsMatch(string.Join("", i.Movements.Select(t => t.ToDirectionCharacter())), $"^{pattern}$")).ToArray();
            return results;
        }

        // Final party selection
        // Numbers are references to specific party members
        public PartyMember[] LastParty(int rnd)
        {
            PartyMember[][] tbl = new PartyMember[][]
            {
                new[] { PartyMember.Squall, PartyMember.Zell, PartyMember.Irvine },
                new[] { PartyMember.Squall, PartyMember.Zell, PartyMember.Rinoa },
                new[] { PartyMember.Squall, PartyMember.Zell, PartyMember.Selphie },
                new[] { PartyMember.Squall, PartyMember.Zell, PartyMember.Quistis },
                new[] { PartyMember.Squall, PartyMember.Irvine, PartyMember.Rinoa },
                new[] { PartyMember.Squall, PartyMember.Irvine, PartyMember.Selphie },
                new[] { PartyMember.Squall, PartyMember.Irvine, PartyMember.Quistis },
                new[] { PartyMember.Squall, PartyMember.Rinoa, PartyMember.Selphie },
                new[] { PartyMember.Squall, PartyMember.Rinoa, PartyMember.Quistis },
                new[] { PartyMember.Squall, PartyMember.Selphie, PartyMember.Quistis },
                new[] { PartyMember.Zell, PartyMember.Irvine, PartyMember.Rinoa },
                new[] { PartyMember.Zell, PartyMember.Irvine, PartyMember.Selphie },
                new[] { PartyMember.Zell, PartyMember.Irvine, PartyMember.Quistis },
                new[] { PartyMember.Zell, PartyMember.Rinoa, PartyMember.Selphie },
                new[] { PartyMember.Zell, PartyMember.Rinoa, PartyMember.Quistis },
                new[] { PartyMember.Zell, PartyMember.Selphie, PartyMember.Quistis },
                new[] { PartyMember.Irvine, PartyMember.Rinoa, PartyMember.Selphie },
                new[] { PartyMember.Irvine, PartyMember.Rinoa, PartyMember.Quistis },
                new[] { PartyMember.Irvine, PartyMember.Selphie, PartyMember.Quistis },
                new[] { PartyMember.Rinoa, PartyMember.Selphie, PartyMember.Quistis }
            };
            int idx = rnd / 13;
            return tbl[idx];
        }

        public static IEnumerable<int> Range(int start, int end)
        {
            for (int i = start; i <= end; i++)
                yield return i;
        }

        public static bool IsEven(int num) => num % 2 == 0;

        public static bool ArrayCompare(IEnumerable<PartyMember> a, IEnumerable<PartyMember> b)
        {
            var aSorted = a.OrderBy(x => x.ToString()).ToArray();
            var bSorted = b.OrderBy(x => x.ToString()).ToArray();
            if (aSorted.Length != bSorted.Length) return false;
            for (int i = aSorted.Length; i > 0; i--)
            {
                if (aSorted[i - 1] != bSorted[i - 1]) return false;
                i--;
            }
            return true;
        }

        public static bool Between(double value, double a, double b)
        {
            var min = Math.Min(a, b);
            var max = Math.Max(a, b);
            return value >= min && value <= max;
        }
    }

    public class PartyFormation
    {
        public int Index { get; set; }
        public int Source { get; set; }
        public string RngState { get; set; }
        public PartyMember[] Party { get; set; }
        public Direction[] Movements { get; set; }
        public List<TargetOffset> TargetOffsetTbl { get; set; }
        public PartyMember[] NearestTarget { get; set; }
    }

    public class TargetOffset
    {
        public PartyMember[] Party { get; set; }
        public int Offset { get; set; }
    }

    // For comparing party arrays as keys in Dictionary
    public class PartyComparer : IEqualityComparer<PartyMember[]>
    {
        public bool Equals(PartyMember[] x, PartyMember[] y)
        {
            return UltiManip.ArrayCompare(x, y);
        }

        public int GetHashCode(PartyMember[] obj)
        {
            unchecked
            {
                int hash = 17;
                foreach (var s in obj.OrderBy(e => e))
                    hash = hash * 23 + s.GetHashCode();
                return hash;
            }
        }
    }

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
}
