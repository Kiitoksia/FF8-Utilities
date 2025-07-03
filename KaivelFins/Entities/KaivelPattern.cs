using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaivelFins.Entities
{
    public class KaivelPattern
    {
        internal KaivelPattern(JObject json)
        {
            Index = json.Value<int>("index");
            Pattern = json.Value<string>("pattern");
            Option1 = CreateOption(json, 1);
            Option2 = CreateOption(json, 2);
            Option3 = CreateOption(json, 3);
            GlobalDamageQ = json.Value<int>("globaldamage_q");
            GlobalDamageS = json.Value<int>("globaldamage_s");
        }

        private KaivelOption CreateOption(JObject json, int optionNumber)
        {
            return new KaivelOption(
                json.Value<int>($"hp{optionNumber}"), 
                json.Value<int>($"drop{optionNumber}"),
                json.Value<string>($"manip_{optionNumber}"),
                json.Value<int>($"skip_{optionNumber}"),
                json.Value<int>($"rng_start_{optionNumber}"),
                json.Value<int>($"rng_end_{optionNumber}")
                );
        }

        public int Index { get; }
        public string Pattern { get; }

        public KaivelOption Option1 { get; }
        public KaivelOption Option2 { get; }
        public KaivelOption Option3 { get; }

        public int GlobalDamageQ { get; }
        public int GlobalDamageS { get; }

        public int DamageQ1 { get; }
    }
}
