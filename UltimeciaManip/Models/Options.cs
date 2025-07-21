using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimeciaManip.Models
{
    public class FinalPartyManipOptions
    {
        public List<PartyMember[]> Targets { get; set; } = new List<PartyMember[]>(
            new[]
            {
                new[] { PartyMember.Irvine, PartyMember.Squall, PartyMember.Zell },
                new[] { PartyMember.Irvine, PartyMember.Squall, PartyMember.Selphie },
                new[] { PartyMember.Irvine, PartyMember.Squall, PartyMember.Rinoa },
                new[] { PartyMember.Irvine, PartyMember.Zell, PartyMember.Quistis },
                new[] { PartyMember.Irvine, PartyMember.Zell, PartyMember.Selphie },
                new[] { PartyMember.Irvine, PartyMember.Zell, PartyMember.Rinoa },
                new[] { PartyMember.Irvine, PartyMember.Selphie, PartyMember.Rinoa },
                new[] { PartyMember.Irvine, PartyMember.Selphie, PartyMember.Quistis },
                new[] { PartyMember.Irvine, PartyMember.Quistis, PartyMember.Rinoa },
            });

        public int Base { get; set; } = 12;
        public int Width { get; set; } = 9000;
        public string Order { get; set; } = "reverse";
        public bool HardReset { get; set; } = false;
        public double LastMapDuration { get; set; } = 21.5;
        public double[] LastMapSafeRange { get; set; } = new[] { 0.10, 0.20, 0.30, 0.40 };
        public int MovementsSize { get; set; } = 12;
        public bool HolyWar { get; set; } = false;
    }
}
