using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF8Utilities.Models.AbilityModels
{
    public class SoldierAttack : EncounterAbilityModel
    {
        public SoldierAttack(int count = 0) : base("Soldier Physical Attack", 2, count)
        {

        }
    }
}
