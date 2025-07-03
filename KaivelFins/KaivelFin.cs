using KaivelFins.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaivelFins
{
    public class KaivelFin
    {
        private const string KaivelJson = "kaivel.json";
        private const string LimitRNGJson = "limitRng.json";
        private string _scriptsFolder;

        private List<KaivelPattern> Patterns;
        private int[] LimitRNG;

        public KaivelFin(string scriptsFolder)
        {
            foreach (string requiredScript in new[] { KaivelJson, LimitRNGJson })
            {
                if (!File.Exists(Path.Combine(scriptsFolder, requiredScript)))
                {
                    throw new Exception("Kaivel Fin files not available");
                }
            }

            LoadPatterns(File.ReadAllText(Path.Combine(_scriptsFolder, KaivelJson)));
            LoadLimitRNG(File.ReadAllText(Path.Combine(_scriptsFolder, LimitRNGJson)));
        }

        public List<KaivelIndex> Calculate(string pattern, int prefightQHP)
        {
            List<KaivelIndex> options = new List<KaivelIndex>();

            List<KaivelPattern> patterns = Patterns.Where(t => t.Pattern.StartsWith(pattern)).ToList();
            foreach (KaivelPattern patternModel in patterns)
            {
                int qHPAfterDamage = prefightQHP - patternModel.GlobalDamageQ;
                // Manip says RESET if Q will die (i.e. HP before battle is lower than Q Global Damage)
                // or if Q hp is above the max hp allowed for the row
                if (prefightQHP != 0 && (qHPAfterDamage > patternModel.Option1.HP || qHPAfterDamage <= 0))
                {
                    //<td id="fish1">RESET bc ${(qHPAfterDamage > row.hp1) ? "Q HP too high" : "Q Dead"}</td>
                    options.Add(new KaivelIndex($"RESET bc {(qHPAfterDamage > patternModel.Option1.HP ? "Q HP too high" : "Q Dead")}"));
                }
                else
                {
                    KaivelIndex index = new KaivelIndex();
                    index.Fish1Sequence = patternModel.Option1.Manip;
                    index.Fish
                }
            }

            throw new NotImplementedException();
        }

        private void LoadPatterns(string fileText)
        {
            dynamic jObj = JsonConvert.DeserializeObject(fileText);
            Patterns = new List<KaivelPattern>();
            foreach (var pattern in jObj)
            {
                Patterns.Add(new KaivelPattern(pattern));
            }
        }

        private void LoadLimitRNG(string fileText)
        {
            LimitRNG = JsonConvert.DeserializeObject<int[]>(fileText);           
        }

        private LimitsBetweenRng LimitsBetweenRng(int rngStart, int rngEnd, int currentHp, int maxHp)
        {
            // Waves wants the number of refreshes between the second last limit -> last limit

            int numerator = LimitLevelNumerator(currentHp, maxHp, 0);

            List<int> limits = new List<int>();
            // Need to map RNG values using Kaivel's explanation.
            if (rngStart > rngEnd) rngEnd += 256;

            for (int i = rngStart; i < rngEnd; i++)
            {
                // RNG if we go over 256
                int moduloRngIndex = i % 256;

                int limitLevel = (int)Math.Truncate(numerator / (160m + LimitRNG[moduloRngIndex]));

                if (limitLevel > 4)
                {
                    // Limit break!
                    limits.Add(i);
                }
            }

            // Calculations
            int refreshesToLastLimit;
            if (limits.Count == 0) refreshesToLastLimit = 0;
            else if (limits.Count == 1) refreshesToLastLimit = limits[0];
            else refreshesToLastLimit = limits[limits.Count - 1] - limits[limits.Count - 2];
            LimitsBetweenRng rng = new LimitsBetweenRng(limits.Count, refreshesToLastLimit);
            return rng;
        }

        private int LimitLevelNumerator(int currentHp, int maxHp, int deadCharacters, params Status[] statuses)
        {
            int hpMod = (int)Math.Truncate(2500m * (currentHp / maxHp));
            int deathBonus = (int)Math.Truncate(1600m + (deadCharacters * 200));

            int statusSum = statuses.Sum(t => (int)t);

            int statusBonus = (int)Math.Truncate(10m * statusSum);
            return statusBonus + deathBonus - hpMod;
        }
    }
}
