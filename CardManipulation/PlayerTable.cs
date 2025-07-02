using System.Collections.Generic;

namespace ff8_card_manip
{
    public class PlayerTable
    {
        private static Dictionary<string, Player> _table = new Dictionary<string, Player>();

        static PlayerTable()
        {
            _table.Add("fc01", new Player()
            {
                Name = "トゥリープFC会員01番",
                Name_e = "Trepe Groupie #1",
                Rares = new[] { CardTable.FindIdByName("Quistis") },
                RareLimit = 30,
                Levels = new[] {2, 5},
            });

            _table.Add("fc02", new Player()
            {
                Name = "トゥリープFC会員02番",
                Name_e = "Trepe Groupie #2",
                Rares = new[] { CardTable.FindIdByName("Quistis") },
                RareLimit = 20,
                Levels = new[] {1, 3, 5},
            });

            _table.Add("fc03", new Player()
            {
                Name = "トゥリープFC会員03番",
                Name_e = "Trepe Groupie #3",
                Rares = new[] { CardTable.FindIdByName("Quistis") },
                RareLimit = 10,
                Levels = new[] {1, 2, 4, 5},
            });

            _table.Add("zellmama", new Player()
            {
                Name = "ゼルママ",
                Name_e = "Ma Dincht",
                Rares = new[] { CardTable.FindIdByName("Zell") },
                RareLimit = 10,
                Levels = new[] {1, 2, 4, 5},
            });

            _table.Add("running_boy1", new Player()
            {
                Name = "走る少年(DISC 1)",
                Name_e = "Running Boy (DISC 1)",
                Rares = new[] { CardTable.FindIdByName("MiniMog") },
                RareLimit = 20,
                Levels = new[] {1, 2, 3},
            });

            _table.Add("watts", new Player()
            {
                Name = "ワッツ",
                Name_e = "Watts",
                Rares = new[] { CardTable.FindIdByName("Angelo") },
                RareLimit = 30,
                Levels = new[] {1, 4},
            });
        }

        public static Player Get(string key)
        {
            return _table[key];
        }
    }
}
