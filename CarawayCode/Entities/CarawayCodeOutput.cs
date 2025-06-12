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
        public CarawayCodeOutput(string subScript, string firstOption, string secondOption, string thirdOption, string fourthOption)
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

        public string FirstOption { get; }
        public string SecondOption { get; }
        public string ThirdOption { get;}
        public string FourthOption { get; }

        public string Subscript { get; }

        public bool IsValid { get; }
        public string ErrorText { get; }

        public string SubscriptDisplay => $"Subscript: {Subscript}";

        public bool LikelyCSR => int.Parse(Subscript) < 320;
    }
}
