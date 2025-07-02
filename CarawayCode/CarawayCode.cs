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
            // Create a list to store our possible subscripts

            var orderArr = Enumerable.Range(0, Options.SearchWidth / 2)
                .SelectMany(offset => new[] { Options.DefaultStartIndex + offset, Options.DefaultStartIndex - offset })
                .Where(d => d >= 0);

            var order = orderArr.Distinct().ToList();
            int min = order.Min();
            int max = order.Max();

            List<CarawayOutput> calculatedOutput = new Caraway().CreateCarawayCodeTable(min, max).Where(t => t != null).ToList();


            List<int> subscripts = new List<int>();

            
            //int i = -1; // Create an indexer for iteration purposes

            //// Const.Poles is an array of possible pole combinations.  Any valid combination will be in this array somewhere
            //// Lets loop through our possible combination array
            //foreach (int pole in Const.Poles)
            //{
            //    i++; 
            //    if (poles.FirstOrDefault()?.Count != pole)
            //    {
            //        // The first user submitted pole doesn't match this looping through pole.  We can ignore this subscript
            //        continue;
            //    }

            //    int y = -1; // Create a separate indexer for user submitted pole iteration
            //    foreach (PoleCount poleModel in poles)
            //    {
            //        y++;
            //        if (i + y > Const.Poles.Length - 1)
            //        {
            //            // Subscripts only go up to 697, its possible their pole may be one of the last in the array.
            //            // This would cause an OutOfRange exception, and at this point, it's an invalid combination anyway
            //            break; 
            //        }

            //        if (poleModel.Count == Const.Poles[i + y])
            //        {
            //            // A valid subscript, add its index to the list
            //            subscripts.Add(i);
            //        }
            //        else break;
            //    }
            //}

            // Right now, subscripts will be a large int[] of subscripts.
            // Possible subscripts are subscripts that when grouped, match the amount of series the user submitted.
            // e.g. 4 series, there should be 4 mentions of the subscript.  Any more/less and it's invalid.

            // Using LINQ Grouping is a fast way to only get the results we want
            var subScriptGrouping = subscripts.GroupBy(c => c).Where(c => c.Count() == poles.Length);

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
