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
        public PartyFormationModel(PartyFormation formation)
        {
            Movements = string.Join(", ", formation.Movements.Select(s => s.ToDirection().ToString()));
            Rng = formation.RngState;

            Lineups = new BindingList<LineupModel>(formation.Lineups.Select(s => new LineupModel(s, false)).ToList());
            Lineups.OrderBy(l => l.Count).First().IsFastest = true;
        }

        public string Movements { get; }
        public string Rng { get; }
        public BindingList<LineupModel> Lineups { get; }
    }
}
