
namespace FF8Utilities.Common.Cards.Encounters.IfritsCavern
{
    public class IfritEncounter : BaseEncounterModel
    {
        public IfritEncounter() : base("Ifrit", 10)
        {
            Abilities.Add(new Limit());
            Abilities.Add(new SquallAttack());
            Abilities.Add(new EncounterAbilityModel("Ifrit Punches", 2));
        }

        protected override int CustomRNGAddition
        {
            get 
            {
                return 2; // Always add +2 for the camera
            }
        }
    }
}
