using System.Collections.Generic;
using System.Diagnostics;

namespace CardManipulation
{
    public class Translate
    {
        private static Dictionary<string, string> _expressions = new Dictionary<string, string>();

        static Translate()
        {
            var filename = Process.GetCurrentProcess().ProcessName;

            _expressions.Add("settings_error", "Error when reading \"settings.json\".");
            _expressions.Add("pattern2str_fmt", "Initiative: {0}\nDeck: {1}");
            _expressions.Add("no_target", "There is no target.");

            _expressions.Add("prompt_args.first", "Enter 1 for Elastoid, 2 for Malboro, 3 for Biggs&Wedge or the RNG state in hexadecimal:");
            _expressions.Add("prompt_args.second", "Enter the RNG counter (optional):");

            _expressions.Add("prompt.rare_search", "Enter:start Rare Card Timer (h:Help, q:Quit, else:Recovery Search):");
            _expressions.Add("prompt.after_normal_search", "Enter:start Rare Card Timer (h:Help, q:Quit, else:change Pattern for Search):");
            _expressions.Add("prompt.second_game_method", "Please hit \"Play\" with turbo button\nand input the opening situation of the 1st game (h:Help, q:Quit):");
            _expressions.Add("prompt.first_game_method", "Enter:start Rare Card Timer (h:Help, q:Quit)");
            _expressions.Add("prompt.rare_timer", "*:Rare (Enter:stop to enter Recovery Search)");

            _expressions.Add("str2pattern.UnmatchedInput_fmt", "There are not 4 or more cards: {0}");
            _expressions.Add("str2pattern.EmptyIDs_fmt", "There is no card corresponding to ranks: {0}");
            _expressions.Add("str2pattern.read_as_fuzzy", "read again as fuzzy input...");
            _expressions.Add("str2pattern.DuplicatedIDs_fmt", "Duplicated Cards: {0}");

            _expressions.Add("fuzzy.fmt", "Fuzzy: {0}");
            _expressions.Add("fuzzy.ranks", "Ranks");
            _expressions.Add("fuzzy.order", "Order");
            _expressions.Add("fuzzy.strict", "Strict");

            _expressions.Add("initiative.player", "Player");
            _expressions.Add("initiative.cpu", "CPU");
            _expressions.Add("initiative.any", "Any");

            _expressions.Add("read_argv.unused", "Initial Value");
            _expressions.Add("read_argv.elastoid", "Elastoid");
            _expressions.Add("read_argv.malboro", "Malboro");
            _expressions.Add("read_argv.wedge", "Wedge&Biggs");
            _expressions.Add("read_argv.pattern_fmt", "{0} {1} pattern");
            _expressions.Add("read_argv.select_fmt", "{0} is selected");
            _expressions.Add("read_argv.direct_rng_state_fmt", "RNG state is selected directly: 0x{0:x8}");
            _expressions.Add("read_argv.advanced_rng_fmt", "=> Card_RNG[{0}]: 0x{1:x8}");

            _expressions.Add("help.first", $"Usage: {filename} early_quistis [count]\n" +
                                           "early_quistis   The 2nd card in CPU's deck when you use Early Quistis.\n" +
                                           "                0: unused, 1: Elastoid, 2: Malboro, 3: Wedge&Biggs,\n" +
                                           "                etc: select the Card RNG state directly with hex\n" +
                                           "                     then you can use the rare card timer on the 1st game.\n" +
                                           "count           How many times the Card RNG is used until Ma Dincht.\n" +
                                           "                When you put this argument,\n" +
                                           "                you can use the rare card timer on the 1st game.\n" +
                                           "\n" +
                                           "1. On the screen on the 1st game with Ma Dincht, hit \"Play\" with turbo button.\n" +
                                           "2. While playing the game, input the opening situation pattern and match it.\n" +
                                           "3. Just before the next game with her, hit \"Yes\" on the field\n" +
                                           "   and press Enter at the same time. And start the rare card timer.\n" +
                                           "4. When the center of the secuence of \"*\" overlaps \"!\" at the leftmost,\n" +
                                           "   hit \"Play\" and press Enter to stop timer at the same time.\n" +
                                           "5. She draws Zell card and you can get it.");

            _expressions.Add("help.last", "Note:\n" +
                                          "- If you didn't match at step 2, the reasons are considered as follows:\n" +
                                          "  - Wrong Early Quistis pattern was put on 1st argument of the script.\n" +
                                          "  - You had entered the card game screen before Ma Dincht.\n" +
                                          "  - \"Play\" was not hit with turbo speed not less than $option[:autofire_speed].\n" +
                                          "  - The search range ($option[:width]) was narrow.\n" +
                                          "- At step 3 and 4,\n" +
                                          "  it is recommended to hit both of \"Yes\" and \"Play\" with non-turbo button.\n" +
                                          "- If you could't gain Zell card,\n" +
                                          "  input the opening situation of the game just like step 2.\n" +
                                          "  You can do recovery search to specify RNG state from timing where you stopped\n" +
                                          "  And you can do that any number of times until you get Zell card.\n" +
                                          "- When you put the count of RNG on 2nd argument or select RNG state directly,\n" +
                                          "  You can perform from step 3. The process of to specify RNG state is skipped.");

            _expressions.Add("help.pattern", "- You can track back your input history with the up and down arrow keys.\n" +
                                             "- The opening situation is expressed by\n" +
                                             "  \"CPU's deck\" and \"Which side has initiative\".\n" +
                                             "- CPU's deck\n" +
                                             "  - Input ranks. The order is u-l-r-d. (changeable by $option[:ranks_order])\n" +
                                             "  - Zell card (up:8, left:6, right:5, down:A) is expressed by \"8650\" or \"865a\".\n" +
                                             "  - Even if you input wrong order, it is automatically modified.\n" +
                                             "  - Input of Zell card is skippable.\n" +
                                             "- Which side has initiative\n" +
                                             "  - +: Player, -: CPU\n" +
                                             "  - Anywhere in pattern is allowed.\n" +
                                             "  - Skippable. In that case, the pattern matches both.\n" +
                                             "- All the following patterns mean the opening situation that\n" +
                                             "  CPU's deck is [Zell, Gayla, Bomb, Malboro, Buel] and player has initiative.\n" +
                                             "+8650.2414.2376.7274.6322       # basically?\n" +
                                             "+0568.1244.7326.4772.2362       # automatically modified even if wrong order\n" +
                                             "+2414.2376.7274.6322            # Zell card is skippable\n" +
                                             "+86502414237672746322           # sequential input is allowed\n" +
                                             "+8650``2414^^2376\"\"7274'6322    # any chars between ranks are allowed\n" +
                                             "8650.2414.2376.7274.6322+       # initiative anywhere is allowed\n" +
                                             "8650-2414-2376-7274+6322        # the last initiative is adopted\n" +
                                             "8650.2414.2376.7274.6322        # initiative is skippable");
        }

        public static string Get(string key)
        {
            return _expressions[key];
        }
    }
}
