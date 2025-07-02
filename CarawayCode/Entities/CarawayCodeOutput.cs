using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarawayCode.Entities
{
    [DebuggerDisplay("Subscript: {Subscript}")]
    public class CarawayCodeOutput
    {
        /// <summary>
        /// Constructor will return a valid output
        /// </summary>
        public CarawayCodeOutput(string subScript, CarawayOption completeOption, CarawayOption incompleteOption)
        {
            Subscript = subScript;
            CompleteOption = completeOption;
            IncompleteOption = incompleteOption;
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

        public CarawayOption CompleteOption { get; }
        public CarawayOption IncompleteOption { get; }

        public string Subscript { get; }

        public bool IsValid { get; }
        public string ErrorText { get; }

        public string SubscriptDisplay => $"Subscript: {Subscript}";

        public bool LikelyCSR => int.Parse(Subscript) < 320;

    }

    public class CarawayOption
    {
        internal CarawayOption(CarawayOutput output, CarawayOutput backupOutput)
        {
            Code = output.Code;
            Station = output.Station;
            Escalator = output.Escalator;
            Street = output.Street;
            Bus = output.Bus;
            Input = output.Input;
            BackupCode = backupOutput?.Code;
            BackupInput = backupOutput?.Input;
        }

        public string Code { get; }
        public string Station { get; }

        public string Escalator { get; }

        public string Street { get; }

        public string Bus { get; }

        public string Input { get; }

        public string BackupCode { get; }

        public string BackupInput { get; }
    }
}
