using System;
using FF8Utilities.Interfaces;
using FF8Utilities.Models;
using FF8Utilities.Models.AbilityModels;

namespace FF8Utilities.Entities.Encounters.Dollet
{
    public class AnacondaurEncounter : BaseEncounterModel
    {
        private int _squallPhysicals;
        private int _seiferAttacks;
        private int _zellAttacks;
        private int _limits = 1;
        private int _rolls;
        private int _blind;
        private ThreePersonFanfareCamera? _camera;
        private bool _allCharactersSurvived = true;

        public AnacondaurEncounter() : base("Anacondaur", 14, typeof(ThreePersonFanfareCamera))
        {
            Abilities.Add(new SquallAttack());
            Abilities.Add(new SeiferAttack());
            Abilities.Add(new ZellAttack());
            Abilities.Add(new Limit(1));
            Abilities.Add(new EncounterAbilityModel("Squeeze", 3));
            Abilities.Add(new EncounterAbilityModel("Dark Mists", 1));

            ToggleOptionDescription = "All chars alive on defeat?";
            IsToggled = true;
        }

        protected override int CustomRNGAddition
        {
            get
            {
                if (Fanfare == null) return 0;
                if ((ThreePersonFanfareCamera)Fanfare == ThreePersonFanfareCamera.ThreeCharacters && !IsToggled)
                {
                    // Special case, subtract one if three character camera and not everyone is alive
                    return -1;
                }

                return 0;
            }
        }
    }
}
