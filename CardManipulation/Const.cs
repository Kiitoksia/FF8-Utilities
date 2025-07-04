using CardManipulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardManipulation
{
    internal static class Const
    {
        internal static List<Card> CreateCardTable()
        {
            return new List<Card>
            {
                new Card { Id = 0, Urdl = new[] {1,4,1,5}, Name = "ハウリザード", NameEn = "Geezard", Level = 1, Row = 1, IsRare = false },
                new Card { Id = 1, Urdl = new[] {5,1,1,3}, Name = "フンゴオンゴ", NameEn = "Funguar", Level = 1, Row = 2, IsRare = false },
                new Card { Id = 2, Urdl = new[] {1,3,3,5}, Name = "バイトバグ", NameEn = "Bite Bug", Level = 1, Row = 3, IsRare = false },
                new Card { Id = 3, Urdl = new[] {6,1,1,2}, Name = "レッドマウス", NameEn = "Red Bat", Level = 1, Row = 4, IsRare = false },
                new Card { Id = 4, Urdl = new[] {2,3,1,5}, Name = "プリヌラ", NameEn = "Blobra", Level = 1, Row = 5, IsRare = false },
                new Card { Id = 5, Urdl = new[] {2,1,4,4}, Name = "ゲイラ", NameEn = "Gayla", Level = 1, Row = 6, IsRare = false },
                new Card { Id = 6, Urdl = new[] {1,5,4,1}, Name = "ゲスパー", NameEn = "Gesper", Level = 1, Row = 7, IsRare = false },
                new Card { Id = 7, Urdl = new[] {3,5,2,1}, Name = "フォカロルフェイク", NameEn = "Fastitocalon-F", Level = 1, Row = 8, IsRare = false },
                new Card { Id = 8, Urdl = new[] {2,1,6,1}, Name = "ブラットソウル", NameEn = "Blood Soul", Level = 1, Row = 9, IsRare = false },
                new Card { Id = 9, Urdl = new[] {4,2,4,3}, Name = "ケダチク", NameEn = "Caterchipillar", Level = 1, Row = 10, IsRare = false },
                new Card { Id = 10, Urdl = new[] {2,1,2,6}, Name = "コカトリス", NameEn = "Cockatrice", Level = 1, Row = 11, IsRare = false },
                new Card { Id = 11, Urdl = new[] {7,1,3,1}, Name = "グラット", NameEn = "Grat", Level = 2, Row = 1, IsRare = false },
                new Card { Id = 12, Urdl = new[] {6,2,2,3}, Name = "ブエル", NameEn = "Buel", Level = 2, Row = 2, IsRare = false },
                new Card { Id = 13, Urdl = new[] {5,3,3,4}, Name = "メズマライズ", NameEn = "Mesmerize", Level = 2, Row = 3, IsRare = false },
                new Card { Id = 14, Urdl = new[] {6,1,4,3}, Name = "グヘイスアイ", NameEn = "Glacial Eye", Level = 2, Row = 4, IsRare = false },
                new Card { Id = 15, Urdl = new[] {3,4,5,3}, Name = "ベルヘルメルヘル", NameEn = "Belhelmel", Level = 2, Row = 5, IsRare = false },
                new Card { Id = 16, Urdl = new[] {5,3,2,5}, Name = "スラストエイビス", NameEn = "Thrustaevis", Level = 2, Row = 6, IsRare = false },
                new Card { Id = 17, Urdl = new[] {5,1,3,5}, Name = "ヘッジヴァイパー", NameEn = "Anacondaur", Level = 2, Row = 7, IsRare = false },
                new Card { Id = 18, Urdl = new[] {5,2,5,2}, Name = "クリープス", NameEn = "Creeps", Level = 2, Row = 8, IsRare = false },
                new Card { Id = 19, Urdl = new[] {4,4,5,2}, Name = "グレンデル", NameEn = "Grendel", Level = 2, Row = 9, IsRare = false },
                new Card { Id = 20, Urdl = new[] {3,2,1,7}, Name = "ダブルハガー", NameEn = "Jelleye", Level = 2, Row = 10, IsRare = false },
                new Card { Id = 21, Urdl = new[] {5,2,5,3}, Name = "グランデアーロ", NameEn = "Grand Mantis", Level = 2, Row = 11, IsRare = false },
                new Card { Id = 22, Urdl = new[] {6,6,3,2}, Name = "ライフフォビドン", NameEn = "Forbidden", Level = 3, Row = 1, IsRare = false },
                new Card { Id = 23, Urdl = new[] {6,3,1,6}, Name = "エサンスーシ", NameEn = "Armadodo", Level = 3, Row = 2, IsRare = false },
                new Card { Id = 24, Urdl = new[] {3,5,5,5}, Name = "トライフェイス", NameEn = "Tri-Face", Level = 3, Row = 3, IsRare = false },
                new Card { Id = 25, Urdl = new[] {7,5,1,3}, Name = "フォカロル", NameEn = "Fastitocalon", Level = 3, Row = 4, IsRare = false },
                new Card { Id = 26, Urdl = new[] {7,1,5,3}, Name = "ゴージュシール", NameEn = "Snow Lion", Level = 3, Row = 5, IsRare = false },
                new Card { Id = 27, Urdl = new[] {5,6,3,3}, Name = "オチュー", NameEn = "Ochu", Level = 3, Row = 6, IsRare = false },
                new Card { Id = 28, Urdl = new[] {5,6,2,4}, Name = "SAM08G", NameEn = "SAM08G", Level = 3, Row = 7, IsRare = false },
                new Card { Id = 29, Urdl = new[] {4,4,7,2}, Name = "ワイルドフック", NameEn = "Death Claw", Level = 3, Row = 8, IsRare = false },
                new Card { Id = 30, Urdl = new[] {6,2,6,3}, Name = "サボテンダー", NameEn = "Cactuar", Level = 3, Row = 9, IsRare = false },
                new Card { Id = 31, Urdl = new[] {3,6,4,4}, Name = "トンベリ", NameEn = "Tonberry", Level = 3, Row = 10, IsRare = false },
                new Card { Id = 32, Urdl = new[] {7,2,3,5}, Name = "アビスウォーム", NameEn = "Abyss Worm", Level = 3, Row = 11, IsRare = false },
                new Card { Id = 33, Urdl = new[] {2,3,6,7}, Name = "グラナトゥム", NameEn = "Turtapod", Level = 4, Row = 1, IsRare = false },
                new Card { Id = 34, Urdl = new[] {6,5,4,5}, Name = "バイセージ・ハンズ", NameEn = "Vysage", Level = 4, Row = 2, IsRare = false },
                new Card { Id = 35, Urdl = new[] {4,6,2,7}, Name = "アルケオダイノス", NameEn = "T-Rexaur", Level = 4, Row = 3, IsRare = false },
                new Card { Id = 36, Urdl = new[] {2,7,6,3}, Name = "ボム", NameEn = "Bomb", Level = 4, Row = 4, IsRare = false },
                new Card { Id = 37, Urdl = new[] {1,6,4,7}, Name = "ブリッツ", NameEn = "Blitz", Level = 4, Row = 5, IsRare = false },
                new Card { Id = 38, Urdl = new[] {7,3,1,6}, Name = "ウェンディゴ", NameEn = "Wendigo", Level = 4, Row = 6, IsRare = false },
                new Card { Id = 39, Urdl = new[] {7,4,4,4}, Name = "クアール", NameEn = "Torama", Level = 4, Row = 7, IsRare = false },
                new Card { Id = 40, Urdl = new[] {3,7,3,6}, Name = "ガルキマセラ", NameEn = "Imp", Level = 4, Row = 8, IsRare = false },
                new Card { Id = 41, Urdl = new[] {6,2,7,3}, Name = "ドラゴンイゾルデ", NameEn = "Blue Dragon", Level = 4, Row = 9, IsRare = false },
                new Card { Id = 42, Urdl = new[] {4,5,5,6}, Name = "アダマンタイマイ", NameEn = "Adamantoise", Level = 4, Row = 10, IsRare = false },
                new Card { Id = 43, Urdl = new[] {7,5,4,3}, Name = "メルトドラゴン", NameEn = "Hexadragon", Level = 4, Row = 11, IsRare = false },
                new Card { Id = 44, Urdl = new[] {6,5,6,5}, Name = "鉄巨人", NameEn = "Iron Giant", Level = 5, Row = 1, IsRare = false },
                new Card { Id = 45, Urdl = new[] {3,6,5,7}, Name = "ベヒーモス", NameEn = "Behemoth", Level = 5, Row = 2, IsRare = false },
                new Card { Id = 46, Urdl = new[] {7,6,5,3}, Name = "キマイラブレイン", NameEn = "Chimera", Level = 5, Row = 3, IsRare = false },
                new Card { Id = 47, Urdl = new[] {3,10,2,1}, Name = "コヨコヨ", NameEn = "PuPu", Level = 5, Row = 4, IsRare = false },
                new Card { Id = 48, Urdl = new[] {6,2,6,7}, Name = "インビンシブル", NameEn = "Elastoid", Level = 5, Row = 5, IsRare = false },
                new Card { Id = 49, Urdl = new[] {5,5,7,4}, Name = "GIM47N", NameEn = "GIM47N", Level = 5, Row = 6, IsRare = false },
                new Card { Id = 50, Urdl = new[] {7,7,4,2}, Name = "モルボル", NameEn = "Malboro", Level = 5, Row = 7, IsRare = false },
                new Card { Id = 51, Urdl = new[] {7,2,7,4}, Name = "ルブルムドラゴン", NameEn = "Ruby Dragon", Level = 5, Row = 8, IsRare = false },
                new Card { Id = 52, Urdl = new[] {5,3,7,6}, Name = "エルノーイル", NameEn = "Elnoyle", Level = 5, Row = 9, IsRare = false },
                new Card { Id = 53, Urdl = new[] {4,6,7,4}, Name = "トンベリキング", NameEn = "Tonberry King", Level = 5, Row = 10, IsRare = false },
                new Card { Id = 54, Urdl = new[] {6,6,2,7}, Name = "ウェッジ・ビッグス", NameEn = "Wedge Biggs", Level = 5, Row = 11, IsRare = false },
                new Card { Id = 55, Urdl = new[] {2,8,8,4}, Name = "風神・雷神", NameEn = "Fujin Raijin", Level = 6, Row = 1, IsRare = false },
                new Card { Id = 56, Urdl = new[] {7,8,3,4}, Name = "エルヴィオレ", NameEn = "Elvoret", Level = 6, Row = 2, IsRare = false },
                new Card { Id = 57, Urdl = new[] {4,8,7,3}, Name = "X-ATM092", NameEn = "X-ATM092", Level = 6, Row = 3, IsRare = false },
                new Card { Id = 58, Urdl = new[] {7,2,8,5}, Name = "グラナルド", NameEn = "Granaldo", Level = 6, Row = 4, IsRare = false },
                new Card { Id = 59, Urdl = new[] {1,8,8,3}, Name = "ナムタル・ウトク", NameEn = "Gerogero", Level = 6, Row = 5, IsRare = false },
                new Card { Id = 60, Urdl = new[] {8,2,8,2}, Name = "シュメルケ", NameEn = "Iguion", Level = 6, Row = 6, IsRare = false },
                new Card { Id = 61, Urdl = new[] {6,8,4,5}, Name = "アバドン", NameEn = "Abadon", Level = 6, Row = 7, IsRare = false },
                new Card { Id = 62, Urdl = new[] {4,8,5,6}, Name = "ドルメン", NameEn = "Trauma", Level = 6, Row = 8, IsRare = false },
                new Card { Id = 63, Urdl = new[] {1,8,4,8}, Name = "オイルシッパー", NameEn = "Oilboyle", Level = 6, Row = 9, IsRare = false },
                new Card { Id = 64, Urdl = new[] {6,5,8,4}, Name = "シュミ族", NameEn = "Shumi Tribe", Level = 6, Row = 10, IsRare = false },
                new Card { Id = 65, Urdl = new[] {7,5,8,1}, Name = "コキュートス", NameEn = "Krysta", Level = 6, Row = 11, IsRare = false },
                new Card { Id = 66, Urdl = new[] {8,4,4,8}, Name = "プロパゲーター", NameEn = "Propagator", Level = 7, Row = 1, IsRare = false },
                new Card { Id = 67, Urdl = new[] {8,8,4,4}, Name = "ジャボテンダー", NameEn = "Jumbo Cactuar", Level = 7, Row = 2, IsRare = false },
                new Card { Id = 68, Urdl = new[] {8,5,2,8}, Name = "トライエッジ", NameEn = "Tri-Point", Level = 7, Row = 3, IsRare = false },
                new Card { Id = 69, Urdl = new[] {5,6,6,8}, Name = "ガルガンチュア", NameEn = "Gargantua", Level = 7, Row = 4, IsRare = false },
                new Card { Id = 70, Urdl = new[] {8,6,7,3}, Name = "機動兵器８型ＢＩＳ", NameEn = "Mobile Type 8", Level = 7, Row = 5, IsRare = false },
                new Card { Id = 71, Urdl = new[] {8,3,5,8}, Name = "アンドロ", NameEn = "Sphinxara", Level = 7, Row = 6, IsRare = false },
                new Card { Id = 72, Urdl = new[] {8,8,5,4}, Name = "ティアマト", NameEn = "Tiamat", Level = 7, Row = 7, IsRare = false },
                new Card { Id = 73, Urdl = new[] {5,7,8,5}, Name = "BGH251F2", NameEn = "BGH251F2", Level = 7, Row = 8, IsRare = false },
                new Card { Id = 74, Urdl = new[] {6,8,4,7}, Name = "ウルフラマイター", NameEn = "Red Giant", Level = 7, Row = 9, IsRare = false },
                new Card { Id = 75, Urdl = new[] {1,8,7,7}, Name = "カトブレパス", NameEn = "Catoblepas", Level = 7, Row = 10, IsRare = false },
                new Card { Id = 76, Urdl = new[] {7,7,8,2}, Name = "アルテマウェポン", NameEn = "Ultima Weapon", Level = 7, Row = 11, IsRare = false },
                // Rare cards
                new Card { Id = 77, Urdl = new[] {4,4,8,9}, Name = "デブチョコボ", NameEn = "Chubby Chocobo", Level = 8, Row = 1, IsRare = true },
                new Card { Id = 78, Urdl = new[] {9,6,7,3}, Name = "アンジェロ", NameEn = "Angelo", Level = 8, Row = 2, IsRare = true },
                new Card { Id = 79, Urdl = new[] {3,7,9,6}, Name = "ギルガメッシュ", NameEn = "Gilgamesh", Level = 8, Row = 3, IsRare = true },
                new Card { Id = 80, Urdl = new[] {9,3,9,2}, Name = "コモーグリ", NameEn = "MinMog", Level = 8, Row = 4, IsRare = true },
                new Card { Id = 81, Urdl = new[] {9,4,8,4}, Name = "コチョコボ", NameEn = "Chicobo", Level = 8, Row = 5, IsRare = true },
                new Card { Id = 82, Urdl = new[] {2,9,9,4}, Name = "ケツァクウァトル", NameEn = "Quezacotl", Level = 8, Row = 6, IsRare = true },
                new Card { Id = 83, Urdl = new[] {6,7,4,9}, Name = "シヴァ", NameEn = "Shiva", Level = 8, Row = 7, IsRare = true },
                new Card { Id = 84, Urdl = new[] {9,6,2,8}, Name = "イフリート", NameEn = "Ifrit", Level = 8, Row = 8, IsRare = true },
                new Card { Id = 85, Urdl = new[] {8,9,6,2}, Name = "セイレーン", NameEn = "Siren", Level = 8, Row = 9, IsRare = true },
                new Card { Id = 86, Urdl = new[] {5,1,9,9}, Name = "セクレト", NameEn = "Sacred", Level = 8, Row = 10, IsRare = true },
                new Card { Id = 87, Urdl = new[] {9,5,2,9}, Name = "ミノタウロス", NameEn = "Minotaur", Level = 8, Row = 11, IsRare = true },
                new Card { Id = 88, Urdl = new[] {8,4,10,4}, Name = "カーバンクル", NameEn = "Carbuncle", Level = 9, Row = 1, IsRare = true },
                new Card { Id = 89, Urdl = new[] {5,10,8,3}, Name = "ディアボロス", NameEn = "Diablos", Level = 9, Row = 2, IsRare = true },
                new Card { Id = 90, Urdl = new[] {7,10,1,7}, Name = "リヴァイアサン", NameEn = "Leviathan", Level = 9, Row = 3, IsRare = true },
                new Card { Id = 91, Urdl = new[] {8,10,3,5}, Name = "オーディン", NameEn = "Odin", Level = 9, Row = 4, IsRare = true },
                new Card { Id = 92, Urdl = new[] {10,1,7,7}, Name = "パンデモニウム", NameEn = "Pandemonia", Level = 9, Row = 5, IsRare = true },
                new Card { Id = 93, Urdl = new[] {7,4,6,10}, Name = "ケルベロス", NameEn = "Cerberus", Level = 9, Row = 6, IsRare = true },
                new Card { Id = 94, Urdl = new[] {9,10,4,2}, Name = "アレクサンダー", NameEn = "Alexander", Level = 9, Row = 7, IsRare = true },
                new Card { Id = 95, Urdl = new[] {7,2,7,10}, Name = "フェニックス", NameEn = "Phoenix", Level = 9, Row = 8, IsRare = true },
                new Card { Id = 96, Urdl = new[] {10,8,2,6}, Name = "バハムート", NameEn = "Bahumut", Level = 9, Row = 9, IsRare = true },
                new Card { Id = 97, Urdl = new[] {3,1,10,10}, Name = "グラシャラボラス", NameEn = "Doomtrain", Level = 9, Row = 10, IsRare = true },
                new Card { Id = 98, Urdl = new[] {4,4,9,10}, Name = "エデン", NameEn = "Eden", Level = 9, Row = 11, IsRare = true },
                new Card { Id = 99, Urdl = new[] {10,7,2,8}, Name = "ウォード", NameEn = "Ward", Level = 10, Row = 1, IsRare = true },
                new Card { Id = 100, Urdl = new[] {6,7,6,10}, Name = "キロス", NameEn = "Kiros", Level = 10, Row = 2, IsRare = true },
                new Card { Id = 101, Urdl = new[] {5,10,3,9}, Name = "ラグナ", NameEn = "Laguna", Level = 10, Row = 3, IsRare = true },
                new Card { Id = 102, Urdl = new[] {10,8,6,4}, Name = "セルフィ", NameEn = "Selphie", Level = 10, Row = 4, IsRare = true },
                new Card { Id = 103, Urdl = new[] {9,6,10,2}, Name = "キスティス", NameEn = "Quistis", Level = 10, Row = 5, IsRare = true },
                new Card { Id = 104, Urdl = new[] {2,6,9,10}, Name = "アーヴァイン", NameEn = "Irvine", Level = 10, Row = 6, IsRare = true },
                new Card { Id = 105, Urdl = new[] {8,5,10,6}, Name = "ゼル", NameEn = "Zell", Level = 10, Row = 7, IsRare = true },
                new Card { Id = 106, Urdl = new[] {4,10,2,10}, Name = "リノア", NameEn = "Rinoa", Level = 10, Row = 8, IsRare = true },
                new Card { Id = 107, Urdl = new[] {10,10,3,3}, Name = "イデア", NameEn = "Edea", Level = 10, Row = 9, IsRare = true },
                new Card { Id = 108, Urdl = new[] {6,9,10,4}, Name = "サイファー", NameEn = "Seifer", Level = 10, Row = 10, IsRare = true },
                new Card { Id = 109, Urdl = new[] {10,4,6,9}, Name = "スコール", NameEn = "Squall", Level = 10, Row = 11, IsRare = true },
            };
        }

        internal static Dictionary<string, PlayerProfile> CreatePlayerProfiles()
        {
            return new Dictionary<string, PlayerProfile>
            {
                ["fc01"] = new PlayerProfile
                {
                    Key = "fc01",
                    Name = "トゥリープFC会員01番",
                    NameEn = "Trepe Groupie #1",
                    Rares = new List<int> { 103 }, // Quistis_ID
                    RareLimit = 30,
                    Levels = new List<int> { 2, 5 }
                },
                ["fc02"] = new PlayerProfile
                {
                    Key = "fc02",
                    Name = "トゥリープFC会員02番",
                    NameEn = "Trepe Groupie #2",
                    Rares = new List<int> { 103 }, // Quistis_ID
                    RareLimit = 20,
                    Levels = new List<int> { 1, 3, 5 }
                },
                ["fc03"] = new PlayerProfile
                {
                    Key = "fc03",
                    Name = "トゥリープFC会員03番",
                    NameEn = "Trepe Groupie #3",
                    Rares = new List<int> { 103 }, // Quistis_ID
                    RareLimit = 10,
                    Levels = new List<int> { 1, 2, 4, 5 }
                },
                ["zellmama"] = new PlayerProfile
                {
                    Key = "zellmama",
                    Name = "ゼルママ",
                    NameEn = "Ma Dincht",
                    Rares = new List<int> { 105 }, // Zell_ID
                    RareLimit = 10,
                    Levels = new List<int> { 1, 2, 4, 5 }
                },
                ["running_boy1"] = new PlayerProfile
                {
                    Key = "running_boy1",
                    Name = "走る少年(DISC 1)",
                    NameEn = "Running Boy (DISC 1)",
                    Rares = new List<int> { 80 }, // Minimog_ID
                    RareLimit = 20,
                    Levels = new List<int> { 1, 2, 3 }
                },
                ["watts"] = new PlayerProfile
                {
                    Key = "watts",
                    Name = "ワッツ",
                    NameEn = "Watts",
                    Rares = new List<int> { 77 }, // Angelo_ID
                    RareLimit = 30,
                    Levels = new List<int> { 1, 4 }
                }
            };
        }
    }
}
