using FF8Utilities.Interfaces;
using FF8Utilities.Models;
using FF8Utilities.Models.AbilityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace FF8Utilities.Entities.Encounters.Dollet
{
    public class TripleSoldierEncounter : BaseEncounterModel
    {
        public TripleSoldierEncounter(string description = "3X Soldier") : base(description, 22, typeof(ThreePersonFanfareCamera))
        {
            Abilities.Add(new SquallAttack());
            Abilities.Add(new SeiferAttack());
            Abilities.Add(new ZellAttack());
            Abilities.Add(new SoldierAttack());

            ShowPlusOneToAllButton = true;
        }
    }
}
