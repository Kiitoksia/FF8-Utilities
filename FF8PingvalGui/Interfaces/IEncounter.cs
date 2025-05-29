using FF8Utilities.Models;
using System;
using System.ComponentModel;

namespace FF8Utilities.Interfaces
{
    public interface IEncounter
    {
        int Base { get; }
        int RngAddition { get; }
        string Description { get; }
        //Enum FanfareCamera { get; set; }
        
        //BindingList<EncounterAbilityModel> Abilities { get; }
        
    }
}
