
namespace FF8Utilities.Common.Cards.Encounters.Dollet
{
    public class DoubleSoldierEncounter : BaseEncounterModel
    {

        public DoubleSoldierEncounter(bool hasFanfare, string description = "2X Soldier") : base(description, 18, hasFanfare ? typeof(ThreePersonFanfareCamera) : null)
        {
            Abilities.Add(new SquallAttack());
            Abilities.Add(new SeiferAttack());
            Abilities.Add(new ZellAttack());
            Abilities.Add(new SoldierAttack());

            ShowPlusOneToAllButton = true;
        }
    }
}
