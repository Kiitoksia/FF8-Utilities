using System;

namespace FF8Utilities.Common.Cards.Encounters.Dollet
{
    public class AnacondaurEncounter : BaseEncounterModel
    {
        public AnacondaurEncounter() : base("Anacondaur", 14, FanfareCamera.ThreePerson.AllExcludeNone)
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
                if (Fanfare == FanfareCamera.ThreePerson.ThreeCharacters && !IsToggled)
                {
                    // Special case, subtract one if three character camera and not everyone is alive
                    return -1;
                }

                return 0;
            }
        }
    }
}
