using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UltimeciaManip.Entities
{
    public class PartyFormation
    {
        public PartyFormation(int index, int source, string rngState, string party, string movements,
            string targetOffsetTable, string nearestTarget)
        {
            Index = index;
            Source = source;
            RngState = rngState;
            Party = party;
            Movements = movements;
            //TargetOffsetTable = targetOffsetTable;
            //NearestTarget = nearestTarget;

            MatchCollection matches = Regex.Matches(targetOffsetTable, "(?:(\\w+),(\\w+),(\\w+)=>(\\d+))");
            Lineups = new List<Lineup>();
            for (int i = 0; i < matches.Count; i++)
            {
                Lineups.Add(new Lineup(matches[i].Groups[1].Value, matches[i].Groups[2].Value, matches[i].Groups[3].Value, 
                    int.Parse(matches[i].Groups[4].Value)));
            }        
    }

        public int Index { get; }
        public int Source { get; }
        public string RngState { get; }
        public string Party { get; }
        public string Movements { get; }

        public bool IsMatch(Direction[] directions)
        {
            string pattern = string.Join("", directions.Select(d => d.ToDirectionCharacter()));
            return Regex.IsMatch(Movements, pattern);
        }

        public List<Lineup> Lineups { get; }
        public Lineup FastestLineup => Lineups.OrderBy(m => m.Count).First();
    }
}
