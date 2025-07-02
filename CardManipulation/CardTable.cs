using System.Collections.Generic;
using System.Linq;

namespace CardManipulation
{
    public class CardTable
    {
        private static Card[] _table = new[]
        {
            new Card()
            {
                Id = 0,
                Urdl = new int[] {1, 4, 1, 5},
                Urdl_s = "1415",
                Level = 1,
                Row = 1,                
                Name = "Geezard",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 1,
                Urdl = new int[] {5, 1, 1, 3},
                Urdl_s = "5113",
                Level = 1,
                Row = 2,
                
                Name = "Funguar",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 2,
                Urdl = new int[] {1, 3, 3, 5},
                Urdl_s = "1335",
                Level = 1,
                Row = 3,
                
                Name = "Bite Bug",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 3,
                Urdl = new int[] {6, 1, 1, 2},
                Urdl_s = "6112",
                Level = 1,
                Row = 4,
                
                Name = "Red Bat",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 4,
                Urdl = new int[] {2, 3, 1, 5},
                Urdl_s = "2315",
                Level = 1,
                Row = 5,
                
                Name = "Blobra",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 5,
                Urdl = new int[] {2, 1, 4, 4},
                Urdl_s = "2144",
                Level = 1,
                Row = 6,
                
                Name = "Gayla",
                Element = Card.TElement.Thunder,
                Rare = false,
            },
            new Card()
            {
                Id = 6,
                Urdl = new int[] {1, 5, 4, 1},
                Urdl_s = "1541",
                Level = 1,
                Row = 7,
                
                Name = "Gesper",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 7,
                Urdl = new int[] {3, 5, 2, 1},
                Urdl_s = "3521",
                Level = 1,
                Row = 8,
                
                Name = "Fastitocalon-F",
                Element = Card.TElement.Earth,
                Rare = false,
            },
            new Card()
            {
                Id = 8,
                Urdl = new int[] {2, 1, 6, 1},
                Urdl_s = "2161",
                Level = 1,
                Row = 9,
                
                Name = "Blood Soul",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 9,
                Urdl = new int[] {4, 2, 4, 3},
                Urdl_s = "4243",
                Level = 1,
                Row = 10,
                
                Name = "Caterchipillar",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 10,
                Urdl = new int[] {2, 1, 2, 6},
                Urdl_s = "2126",
                Level = 1,
                Row = 11,
                
                Name = "Cockatrice",
                Element = Card.TElement.Thunder,
                Rare = false,
            },
            new Card()
            {
                Id = 11,
                Urdl = new int[] {7, 1, 3, 1},
                Urdl_s = "7131",
                Level = 2,
                Row = 1,
                
                Name = "Grat",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 12,
                Urdl = new int[] {6, 2, 2, 3},
                Urdl_s = "6223",
                Level = 2,
                Row = 2,
                
                Name = "Buel",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 13,
                Urdl = new int[] {5, 3, 3, 4},
                Urdl_s = "5334",
                Level = 2,
                Row = 3,
                
                Name = "Mesmerize",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 14,
                Urdl = new int[] {6, 1, 4, 3},
                Urdl_s = "6143",
                Level = 2,
                Row = 4,
                
                Name = "Glacial Eye",
                Element = Card.TElement.Ice,
                Rare = false,
            },
            new Card()
            {
                Id = 15,
                Urdl = new int[] {3, 4, 5, 3},
                Urdl_s = "3453",
                Level = 2,
                Row = 5,
                
                Name = "Belhelmel",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 16,
                Urdl = new int[] {5, 3, 2, 5},
                Urdl_s = "5325",
                Level = 2,
                Row = 6,
                
                Name = "Thrustaevis",
                Element = Card.TElement.Wind,
                Rare = false,
            },
            new Card()
            {
                Id = 17,
                Urdl = new int[] {5, 1, 3, 5},
                Urdl_s = "5135",
                Level = 2,
                Row = 7,
                
                Name = "Anacondaur",
                Element = Card.TElement.Poison,
                Rare = false,
            },
            new Card()
            {
                Id = 18,
                Urdl = new int[] {5, 2, 5, 2},
                Urdl_s = "5252",
                Level = 2,
                Row = 8,
                
                Name = "Creeps",
                Element = Card.TElement.Thunder,
                Rare = false,
            },
            new Card()
            {
                Id = 19,
                Urdl = new int[] {4, 4, 5, 2},
                Urdl_s = "4452",
                Level = 2,
                Row = 9,
                
                Name = "Grendel",
                Element = Card.TElement.Thunder,
                Rare = false,
            },
            new Card()
            {
                Id = 20,
                Urdl = new int[] {3, 2, 1, 7},
                Urdl_s = "3217",
                Level = 2,
                Row = 10,
                
                Name = "Jelleye",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 21,
                Urdl = new int[] {5, 2, 5, 3},
                Urdl_s = "5253",
                Level = 2,
                Row = 11,
                
                Name = "Grand Mantis",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 22,
                Urdl = new int[] {6, 6, 3, 2},
                Urdl_s = "6632",
                Level = 3,
                Row = 1,
                
                Name = "Forbidden",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 23,
                Urdl = new int[] {6, 3, 1, 6},
                Urdl_s = "6316",
                Level = 3,
                Row = 2,
                
                Name = "Armadodo",
                Element = Card.TElement.Earth,
                Rare = false,
            },
            new Card()
            {
                Id = 24,
                Urdl = new int[] {3, 5, 5, 5},
                Urdl_s = "3555",
                Level = 3,
                Row = 3,
                
                Name = "Tri-Face",
                Element = Card.TElement.Poison,
                Rare = false,
            },
            new Card()
            {
                Id = 25,
                Urdl = new int[] {7, 5, 1, 3},
                Urdl_s = "7513",
                Level = 3,
                Row = 4,
                
                Name = "Fastitocalon",
                Element = Card.TElement.Water,
                Rare = false,
            },
            new Card()
            {
                Id = 26,
                Urdl = new int[] {7, 1, 5, 3},
                Urdl_s = "7153",
                Level = 3,
                Row = 5,
                
                Name = "Snow Lion",
                Element = Card.TElement.Ice,
                Rare = false,
            },
            new Card()
            {
                Id = 27,
                Urdl = new int[] {5, 6, 3, 3},
                Urdl_s = "5633",
                Level = 3,
                Row = 6,
                
                Name = "Ochu",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 28,
                Urdl = new int[] {5, 6, 2, 4},
                Urdl_s = "5624",
                Level = 3,
                Row = 7,
                
                Name = "SAM08G",
                Element = Card.TElement.Fire,
                Rare = false,
            },
            new Card()
            {
                Id = 29,
                Urdl = new int[] {4, 4, 7, 2},
                Urdl_s = "4472",
                Level = 3,
                Row = 8,
                
                Name = "Death Claw",
                Element = Card.TElement.Fire,
                Rare = false,
            },
            new Card()
            {
                Id = 30,
                Urdl = new int[] {6, 2, 6, 3},
                Urdl_s = "6263",
                Level = 3,
                Row = 9,
                
                Name = "Cactuar",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 31,
                Urdl = new int[] {3, 6, 4, 4},
                Urdl_s = "3644",
                Level = 3,
                Row = 10,
                
                Name = "Tonberry",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 32,
                Urdl = new int[] {7, 2, 3, 5},
                Urdl_s = "7235",
                Level = 3,
                Row = 11,
                
                Name = "Abyss Worm",
                Element = Card.TElement.Earth,
                Rare = false,
            },
            new Card()
            {
                Id = 33,
                Urdl = new int[] {2, 3, 6, 7},
                Urdl_s = "2367",
                Level = 4,
                Row = 1,
                
                Name = "Turtapod",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 34,
                Urdl = new int[] {6, 5, 4, 5},
                Urdl_s = "6545",
                Level = 4,
                Row = 2,
                
                Name = "Vysage",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 35,
                Urdl = new int[] {4, 6, 2, 7},
                Urdl_s = "4627",
                Level = 4,
                Row = 3,
                
                Name = "T-Rexaur",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 36,
                Urdl = new int[] {2, 7, 6, 3},
                Urdl_s = "2763",
                Level = 4,
                Row = 4,
                
                Name = "Bomb",
                Element = Card.TElement.Fire,
                Rare = false,
            },
            new Card()
            {
                Id = 37,
                Urdl = new int[] {1, 6, 4, 7},
                Urdl_s = "1647",
                Level = 4,
                Row = 5,
                
                Name = "Blitz",
                Element = Card.TElement.Thunder,
                Rare = false,
            },
            new Card()
            {
                Id = 38,
                Urdl = new int[] {7, 3, 1, 6},
                Urdl_s = "7316",
                Level = 4,
                Row = 6,
                
                Name = "Wendigo",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 39,
                Urdl = new int[] {7, 4, 4, 4},
                Urdl_s = "7444",
                Level = 4,
                Row = 7,
                
                Name = "Torama",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 40,
                Urdl = new int[] {3, 7, 3, 6},
                Urdl_s = "3736",
                Level = 4,
                Row = 8,
                
                Name = "Imp",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 41,
                Urdl = new int[] {6, 2, 7, 3},
                Urdl_s = "6273",
                Level = 4,
                Row = 9,
                
                Name = "Blue Dragon",
                Element = Card.TElement.Poison,
                Rare = false,
            },
            new Card()
            {
                Id = 42,
                Urdl = new int[] {4, 5, 5, 6},
                Urdl_s = "4556",
                Level = 4,
                Row = 10,
                
                Name = "Adamantoise",
                Element = Card.TElement.Earth,
                Rare = false,
            },
            new Card()
            {
                Id = 43,
                Urdl = new int[] {7, 5, 4, 3},
                Urdl_s = "7543",
                Level = 4,
                Row = 11,
                
                Name = "Hexadragon",
                Element = Card.TElement.Fire,
                Rare = false,
            },
            new Card()
            {
                Id = 44,
                Urdl = new int[] {6, 5, 6, 5},
                Urdl_s = "6565",
                Level = 5,
                Row = 1,
                
                Name = "Iron Giant",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 45,
                Urdl = new int[] {3, 6, 5, 7},
                Urdl_s = "3657",
                Level = 5,
                Row = 2,
                
                Name = "Behemoth",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 46,
                Urdl = new int[] {7, 6, 5, 3},
                Urdl_s = "7653",
                Level = 5,
                Row = 3,
                
                Name = "Chimera",
                Element = Card.TElement.Water,
                Rare = false,
            },
            new Card()
            {
                Id = 47,
                Urdl = new int[] {3, 10, 2, 1},
                Urdl_s = "3a21",
                Level = 5,
                Row = 4,
                
                Name = "PuPu",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 48,
                Urdl = new int[] {6, 2, 6, 7},
                Urdl_s = "6267",
                Level = 5,
                Row = 5,
                
                Name = "Elastoid",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 49,
                Urdl = new int[] {5, 5, 7, 4},
                Urdl_s = "5574",
                Level = 5,
                Row = 6,
                
                Name = "GIM47N",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 50,
                Urdl = new int[] {7, 7, 4, 2},
                Urdl_s = "7742",
                Level = 5,
                Row = 7,
                
                Name = "Malboro",
                Element = Card.TElement.Poison,
                Rare = false,
            },
            new Card()
            {
                Id = 51,
                Urdl = new int[] {7, 2, 7, 4},
                Urdl_s = "7274",
                Level = 5,
                Row = 8,
                
                Name = "Ruby Dragon",
                Element = Card.TElement.Fire,
                Rare = false,
            },
            new Card()
            {
                Id = 52,
                Urdl = new int[] {5, 3, 7, 6},
                Urdl_s = "5376",
                Level = 5,
                Row = 9,
                
                Name = "Elnoyle",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 53,
                Urdl = new int[] {4, 6, 7, 4},
                Urdl_s = "4674",
                Level = 5,
                Row = 10,
                
                Name = "Tonberry King",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 54,
                Urdl = new int[] {6, 6, 2, 7},
                Urdl_s = "6627",
                Level = 5,
                Row = 11,
                
                Name = "Wedge Biggs",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 55,
                Urdl = new int[] {2, 8, 8, 4},
                Urdl_s = "2884",
                Level = 6,
                Row = 1,
                
                Name = "Fujin Raijin",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 56,
                Urdl = new int[] {7, 8, 3, 4},
                Urdl_s = "7834",
                Level = 6,
                Row = 2,
                
                Name = "Elvoret",
                Element = Card.TElement.Wind,
                Rare = false,
            },
            new Card()
            {
                Id = 57,
                Urdl = new int[] {4, 8, 7, 3},
                Urdl_s = "4873",
                Level = 6,
                Row = 3,
                
                Name = "X-ATM092",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 58,
                Urdl = new int[] {7, 2, 8, 5},
                Urdl_s = "7285",
                Level = 6,
                Row = 4,
                
                Name = "Granaldo",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 59,
                Urdl = new int[] {1, 8, 8, 3},
                Urdl_s = "1883",
                Level = 6,
                Row = 5,
                
                Name = "Gerogero",
                Element = Card.TElement.Poison,
                Rare = false,
            },
            new Card()
            {
                Id = 60,
                Urdl = new int[] {8, 2, 8, 2},
                Urdl_s = "8282",
                Level = 6,
                Row = 6,
                
                Name = "Iguion",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 61,
                Urdl = new int[] {6, 8, 4, 5},
                Urdl_s = "6845",
                Level = 6,
                Row = 7,
                
                Name = "Abadon",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 62,
                Urdl = new int[] {4, 8, 5, 6},
                Urdl_s = "4856",
                Level = 6,
                Row = 8,
                
                Name = "Trauma",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 63,
                Urdl = new int[] {1, 8, 4, 8},
                Urdl_s = "1848",
                Level = 6,
                Row = 9,
                
                Name = "Oilboyle",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 64,
                Urdl = new int[] {6, 5, 8, 4},
                Urdl_s = "6584",
                Level = 6,
                Row = 10,
                
                Name = "Shumi Tribe",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 65,
                Urdl = new int[] {7, 5, 8, 1},
                Urdl_s = "7581",
                Level = 6,
                Row = 11,
                
                Name = "Krysta",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 66,
                Urdl = new int[] {8, 4, 4, 8},
                Urdl_s = "8448",
                Level = 7,
                Row = 1,
                
                Name = "Propagator",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 67,
                Urdl = new int[] {8, 8, 4, 4},
                Urdl_s = "8844",
                Level = 7,
                Row = 2,
                
                Name = "Jumbo Cactuar",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 68,
                Urdl = new int[] {8, 5, 2, 8},
                Urdl_s = "8528",
                Level = 7,
                Row = 3,
                
                Name = "Tri-Point",
                Element = Card.TElement.Thunder,
                Rare = false,
            },
            new Card()
            {
                Id = 69,
                Urdl = new int[] {5, 6, 6, 8},
                Urdl_s = "5668",
                Level = 7,
                Row = 4,
                
                Name = "Gargantua",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 70,
                Urdl = new int[] {8, 6, 7, 3},
                Urdl_s = "8673",
                Level = 7,
                Row = 5,
                
                Name = "Mobile Type 8",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 71,
                Urdl = new int[] {8, 3, 5, 8},
                Urdl_s = "8358",
                Level = 7,
                Row = 6,
                
                Name = "Sphinxara",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 72,
                Urdl = new int[] {8, 8, 5, 4},
                Urdl_s = "8854",
                Level = 7,
                Row = 7,
                
                Name = "Tiamat",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 73,
                Urdl = new int[] {5, 7, 8, 5},
                Urdl_s = "5785",
                Level = 7,
                Row = 8,
                
                Name = "BGH251F2",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 74,
                Urdl = new int[] {6, 8, 4, 7},
                Urdl_s = "6847",
                Level = 7,
                Row = 9,
                
                Name = "Red Giant",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 75,
                Urdl = new int[] {1, 8, 7, 7},
                Urdl_s = "1877",
                Level = 7,
                Row = 10,
                
                Name = "Catoblepas",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 76,
                Urdl = new int[] {7, 7, 8, 2},
                Urdl_s = "7782",
                Level = 7,
                Row = 11,
                
                Name = "Ultima Weapon",
                Element = Card.TElement.None,
                Rare = false,
            },
            new Card()
            {
                Id = 77,
                Urdl = new int[] {4, 4, 8, 9},
                Urdl_s = "4489",
                Level = 8,
                Row = 1,
                
                Name = "Chubby Chocobo",
                Element = Card.TElement.None,
                Rare = true,
            },
            new Card()
            {
                Id = 78,
                Urdl = new int[] {9, 6, 7, 3},
                Urdl_s = "9673",
                Level = 8,
                Row = 2,
                
                Name = "Angelo",
                Element = Card.TElement.None,
                Rare = true,
            },
            new Card()
            {
                Id = 79,
                Urdl = new int[] {3, 7, 9, 6},
                Urdl_s = "3796",
                Level = 8,
                Row = 3,
                
                Name = "Gilgamesh",
                Element = Card.TElement.None,
                Rare = true,
            },
            new Card()
            {
                Id = 80,
                Urdl = new int[] {9, 3, 9, 2},
                Urdl_s = "9392",
                Level = 8,
                Row = 4,
                
                Name = "MiniMog",
                Element = Card.TElement.None,
                Rare = true,
            },
            new Card()
            {
                Id = 81,
                Urdl = new int[] {9, 4, 8, 4},
                Urdl_s = "9484",
                Level = 8,
                Row = 5,
                
                Name = "Chicobo",
                Element = Card.TElement.None,
                Rare = true,
            },
            new Card()
            {
                Id = 82,
                Urdl = new int[] {2, 9, 9, 4},
                Urdl_s = "2994",
                Level = 8,
                Row = 6,
                
                Name = "Quezacotl",
                Element = Card.TElement.Thunder,
                Rare = true,
            },
            new Card()
            {
                Id = 83,
                Urdl = new int[] {6, 7, 4, 9},
                Urdl_s = "6749",
                Level = 8,
                Row = 7,
                
                Name = "Shiva",
                Element = Card.TElement.Ice,
                Rare = true,
            },
            new Card()
            {
                Id = 84,
                Urdl = new int[] {9, 6, 2, 8},
                Urdl_s = "9628",
                Level = 8,
                Row = 8,
                
                Name = "Ifrit",
                Element = Card.TElement.Fire,
                Rare = true,
            },
            new Card()
            {
                Id = 85,
                Urdl = new int[] {8, 9, 6, 2},
                Urdl_s = "8962",
                Level = 8,
                Row = 9,
                
                Name = "Siren",
                Element = Card.TElement.None,
                Rare = true,
            },
            new Card()
            {
                Id = 86,
                Urdl = new int[] {5, 1, 9, 9},
                Urdl_s = "5199",
                Level = 8,
                Row = 10,
                
                Name = "Sacred",
                Element = Card.TElement.Earth,
                Rare = true,
            },
            new Card()
            {
                Id = 87,
                Urdl = new int[] {9, 5, 2, 9},
                Urdl_s = "9529",
                Level = 8,
                Row = 11,
                
                Name = "Minotaur",
                Element = Card.TElement.Earth,
                Rare = true,
            },
            new Card()
            {
                Id = 88,
                Urdl = new int[] {8, 4, 10, 4},
                Urdl_s = "84a4",
                Level = 9,
                Row = 1,
                
                Name = "Carbuncle",
                Element = Card.TElement.None,
                Rare = true,
            },
            new Card()
            {
                Id = 89,
                Urdl = new int[] {5, 10, 8, 3},
                Urdl_s = "5a83",
                Level = 9,
                Row = 2,
                
                Name = "Diablos",
                Element = Card.TElement.None,
                Rare = true,
            },
            new Card()
            {
                Id = 90,
                Urdl = new int[] {7, 10, 1, 7},
                Urdl_s = "7a17",
                Level = 9,
                Row = 3,
                
                Name = "Leviathan",
                Element = Card.TElement.Water,
                Rare = true,
            },
            new Card()
            {
                Id = 91,
                Urdl = new int[] {8, 10, 3, 5},
                Urdl_s = "8a35",
                Level = 9,
                Row = 4,
                
                Name = "Odin",
                Element = Card.TElement.None,
                Rare = true,
            },
            new Card()
            {
                Id = 92,
                Urdl = new int[] {10, 1, 7, 7},
                Urdl_s = "a177",
                Level = 9,
                Row = 5,
                
                Name = "Pandemonia",
                Element = Card.TElement.Wind,
                Rare = true,
            },
            new Card()
            {
                Id = 93,
                Urdl = new int[] {7, 4, 6, 10},
                Urdl_s = "746a",
                Level = 9,
                Row = 6,
                
                Name = "Cerberus",
                Element = Card.TElement.None,
                Rare = true,
            },
            new Card()
            {
                Id = 94,
                Urdl = new int[] {9, 10, 4, 2},
                Urdl_s = "9a42",
                Level = 9,
                Row = 7,
                
                Name = "Alexander",
                Element = Card.TElement.Holy,
                Rare = true,
            },
            new Card()
            {
                Id = 95,
                Urdl = new int[] {7, 2, 7, 10},
                Urdl_s = "727a",
                Level = 9,
                Row = 8,
                
                Name = "Phoenix",
                Element = Card.TElement.Fire,
                Rare = true,
            },
            new Card()
            {
                Id = 96,
                Urdl = new int[] {10, 8, 2, 6},
                Urdl_s = "a826",
                Level = 9,
                Row = 9,
                
                Name = "Bahumut",
                Element = Card.TElement.None,
                Rare = true,
            },
            new Card()
            {
                Id = 97,
                Urdl = new int[] {3, 1, 10, 10},
                Urdl_s = "31aa",
                Level = 9,
                Row = 10,
                
                Name = "Doomtrain",
                Element = Card.TElement.Poison,
                Rare = true,
            },
            new Card()
            {
                Id = 98,
                Urdl = new int[] {4, 4, 9, 10},
                Urdl_s = "449a",
                Level = 9,
                Row = 11,
                
                Name = "Eden",
                Element = Card.TElement.None,
                Rare = true,
            },
            new Card()
            {
                Id = 99,
                Urdl = new int[] {10, 7, 2, 8},
                Urdl_s = "a728",
                Level = 10,
                Row = 1,
                
                Name = "Ward",
                Element = Card.TElement.None,
                Rare = true,
            },
            new Card()
            {
                Id = 100,
                Urdl = new int[] {6, 7, 6, 10},
                Urdl_s = "676a",
                Level = 10,
                Row = 2,
                
                Name = "Kiros",
                Element = Card.TElement.None,
                Rare = true,
            },
            new Card()
            {
                Id = 101,
                Urdl = new int[] {5, 10, 3, 9},
                Urdl_s = "5a39",
                Level = 10,
                Row = 3,
                
                Name = "Laguna",
                Element = Card.TElement.None,
                Rare = true,
            },
            new Card()
            {
                Id = 102,
                Urdl = new int[] {10, 8, 6, 4},
                Urdl_s = "a864",
                Level = 10,
                Row = 4,
                
                Name = "Selphie",
                Element = Card.TElement.None,
                Rare = true,
            },
            new Card()
            {
                Id = 103,
                Urdl = new int[] {9, 6, 10, 2},
                Urdl_s = "96a2",
                Level = 10,
                Row = 5,
                
                Name = "Quistis",
                Element = Card.TElement.None,
                Rare = true,
            },
            new Card()
            {
                Id = 104,
                Urdl = new int[] {2, 6, 9, 10},
                Urdl_s = "269a",
                Level = 10,
                Row = 6,
                
                Name = "Irvine",
                Element = Card.TElement.None,
                Rare = true,
            },
            new Card()
            {
                Id = 105,
                Urdl = new int[] {8, 5, 10, 6},
                Urdl_s = "85a6",
                Level = 10,
                Row = 7,
                
                Name = "Zell",
                Element = Card.TElement.None,
                Rare = true,
            },
            new Card()
            {
                Id = 106,
                Urdl = new int[] {4, 10, 2, 10},
                Urdl_s = "4a2a",
                Level = 10,
                Row = 8,
                
                Name = "Rinoa",
                Element = Card.TElement.None,
                Rare = true,
            },
            new Card()
            {
                Id = 107,
                Urdl = new int[] {10, 10, 3, 3},
                Urdl_s = "aa33",
                Level = 10,
                Row = 9,
                
                Name = "Edea",
                Element = Card.TElement.None,
                Rare = true,
            },
            new Card()
            {
                Id = 108,
                Urdl = new int[] {6, 9, 10, 4},
                Urdl_s = "69a4",
                Level = 10,
                Row = 10,
                
                Name = "Seifer",
                Element = Card.TElement.None,
                Rare = true,
            },
            new Card()
            {
                Id = 109,
                Urdl = new int[] {10, 4, 6, 9},
                Urdl_s = "a469",
                Level = 10,
                Row = 11,
                
                Name = "Squall",
                Element = Card.TElement.None,
                Rare = true,
            },
        };

        public static int FindIdByName(string name_e)
        {
            return _table.First(x => x.Name == name_e).Id;
        }

        public static string FindNameById(int id)
        {
            return _table.First(x => x.Id == id).Name;
        }

        public static IList<int> ListIdsByUrdl(IEnumerable<int> urdl, bool fuzzy = false)
        {
            if (fuzzy)
            {
                urdl = urdl.OrderBy(x => x);
            }

            return _table
                .Where(x => urdl.SequenceEqual(fuzzy ? x.Urdl.OrderBy(y => y).ToArray() : x.Urdl))
                .Select(x => x.Id)
                .ToList();
        }
    }
}
