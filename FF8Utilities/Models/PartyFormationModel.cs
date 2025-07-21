using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimeciaManip;
using UltimeciaManip.Entities;

namespace FF8Utilities.Models
{
    public class PartyFormationModel : BaseModel
    {
        public PartyFormationModel(PartyFormation formation, bool includeRinoaParties)
        {
            Movements = string.Join(", ", formation.Movements.Select(s => s.ToString()));
            Rng = formation.RngState;

            List<Lineup> lineUps = formation.TargetOffsetTbl.Select(t => new Lineup(t.Party[0].ToString(), t.Party[1].ToString(), t.Party[2].ToString(), t.Offset)).ToList();

            if (!includeRinoaParties) lineUps = lineUps.Where(t => t.FirstCharacter != "Rinoa" && t.SecondCharacter != "Rinoa" && t.ThirdCharacter != "Rinoa").ToList();

            lineUps = lineUps.OrderBy(t => t.Count).ToList();
            Lineup fastestLineup = lineUps.First();

            LineupsLineOne = new BindingList<LineupModel>(lineUps.Take(3).Select(s => new LineupModel(s, s == fastestLineup)).ToList());
            LineupsLineTwo = new BindingList<LineupModel>(lineUps.Skip(3).Take(3).Select(s => new LineupModel(s, s == fastestLineup)).ToList());
            LineupsLineThree = new BindingList<LineupModel>(lineUps.Skip(6).Take(3).Select(s => new LineupModel(s, s == fastestLineup)).ToList());

            LineupTwoVisible = LineupsLineTwo.Count > 0;
            LineupThreeVisible = LineupsLineThree.Count > 0;


            //Lineups = new BindingList<LineupModel>(lineUps.Select(s => new LineupModel(s, false)).ToList());
            //Lineups.OrderBy(l => l.Count).First().IsFastest = true;
        }

        public string Movements { get; }
        public string Rng { get; }
        //public BindingList<LineupModel> Lineups { get; }

        public BindingList<LineupModel> LineupsLineOne { get; }
        public BindingList<LineupModel> LineupsLineTwo { get; }
        public BindingList<LineupModel> LineupsLineThree { get; }

        public bool LineupTwoVisible { get; }
        public bool LineupThreeVisible { get; }
    }
}
