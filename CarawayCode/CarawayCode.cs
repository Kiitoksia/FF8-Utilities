using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarawayCode.Entities;

namespace CarawayCode
{
    public static class CarawayCode
    {
        /// <summary>
        /// Given the supplied pole sequences, will produce a list of possible results.  This can return empty if none found
        /// </summary>
        public static CarawayCodeOutput[] CalculateCode(PoleCount[] poles, bool hideUnlikelyResults)
        {
            IEnumerable<int> orderArr = Enumerable.Range(0, Options.SearchWidth / 2)
                .SelectMany(offset => new[] { Options.DefaultStartIndex + offset, Options.DefaultStartIndex - offset })
                .Where(d => d >= 0);

            List<int> order = orderArr.Distinct().ToList();
            int min = order.Min();
            int max = order.Max();

            List<CarawayOutput> calculatedOutput = new Caraway().CreateCarawayCodeTable(min, max).Where(t => t != null).ToList();
            List<CarawayCodeOutput> output = new List<CarawayCodeOutput>();

            string hexSearch = string.Join("", poles.Select(t => t.Count.ToString("X")));

            List<CarawayOutput> completedOutputs = calculatedOutput.Where(t => t.PolesHex.EndsWith(hexSearch)).ToList();
            foreach (CarawayOutput completedOutput in completedOutputs)
            {
                CarawayOutput incompleteOutput = calculatedOutput.SingleOrDefault(t => t.Index == completedOutput.Index + 1);
                if (hideUnlikelyResults)
                {
                    if (completedOutput.Index < 220 || completedOutput.Index > 580) continue;
                }

                CarawayOutput completeBackup = calculatedOutput.SingleOrDefault(t => t.Index == completedOutput.Index + 2);
                CarawayOutput incompleteBackup = calculatedOutput.SingleOrDefault(t => t.Index == incompleteOutput.Index + 2);

                output.Add(new CarawayCodeOutput(completedOutput.Index.ToString(), new CarawayOption(completedOutput, completeBackup), new CarawayOption(incompleteOutput, incompleteBackup)));

            }

            return output.ToArray();
        }
    }
}
