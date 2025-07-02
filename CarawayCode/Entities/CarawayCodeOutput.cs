using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarawayCode.Entities
{
    [DebuggerDisplay("Subscript: {Subscript}, {FirstOption}, {SecondOption}, {ThirdOption}, {FourthOption}")]
    public class CarawayCodeOutput
    {
        /// <summary>
        /// Constructor will return a valid output
        /// </summary>
        public CarawayCodeOutput(string subScript, CarawayOption firstOption, CarawayOption secondOption, CarawayOption thirdOption, CarawayOption fourthOption)
        {
            Subscript = subScript;
            FirstOption = firstOption;
            SecondOption = secondOption;
            ThirdOption = thirdOption;
            FourthOption = fourthOption;
            IsValid = true;
        }

        /// <summary>
        /// Constructor will return an invalid output
        /// </summary>
        public CarawayCodeOutput(string errorText)
        {
            IsValid = false;
            ErrorText = errorText;
        }

        public CarawayOption FirstOption { get; }
        public CarawayOption SecondOption { get; }
        public CarawayOption ThirdOption { get;}
        public CarawayOption FourthOption { get; }

        public string Subscript { get; }

        public bool IsValid { get; }
        public string ErrorText { get; }

        public string SubscriptDisplay => $"Subscript: {Subscript}";

        public bool LikelyCSR => int.Parse(Subscript) < 320;

    }

    public class CarawayOption
    {
        internal CarawayOption(CarawayOutput output)
        {
            Code = output.Code;
            Station = output.Station;
            Escalator = output.Escalator;
            Street = output.Street;
            Bus = output.Bus;
            Input = output.Input;
        }

        public string Code { get; }
        public string Station { get; }

        public string Escalator { get; }

        public string Street { get; }

        public string Bus { get; }

        public string Input { get; }
    }
}
