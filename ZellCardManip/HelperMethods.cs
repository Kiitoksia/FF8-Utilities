using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZellCardManip.Entities;

namespace ZellCardManip
{
    public static class HelperMethods
    {
        public static void ParseArguments(string[] args)
        {
            Settings.Arguments = args;

            long? initialState = 0;
            if (long.TryParse(args[0], out long state)) initialState = state;


            switch (initialState)
            {
                case 1:
                    initialState = 0x1de5_b942;
                    InputArguments.FirstState = QuistisPattern.Elastoid;                    
                    break;
                case 2:
                    initialState = 0x963c_b5e4;
                    InputArguments.FirstState = QuistisPattern.Malboro;
                    break;
                case 3:
                    initialState = 0x1f13_2481;
                    InputArguments.FirstState = QuistisPattern.Wedge;
                    break;
                default:
                    initialState = null;
                    break;
            }

            switch (args.Length)
            {
                case 1:
                    InputArguments.SearchType = SearchType.First;
                    break;
                case 2:
                    InputArguments.SearchType = SearchType.Counting;
                    break;
                default:
                    InputArguments.SearchType = SearchType.Recovery;
                    break;
            }

            if (args.Length > 1)
            {
                if (int.TryParse(args[1], out int count))
                {
                    InputArguments.Count = count;
                }
            }
        }

        public static CardRng BeginManip(string[] args)
        {
            ParseArguments(args);
            CardRng rng = new CardRng(InputArguments.FirstState.ToInitialState(), args.Length > 1 ? SearchType.First : SearchType.Recovery);

            if (args.Length > 1)
            {
                for (int i = 0; i < InputArguments.Count; i++) rng.GetNextState();

            }

            StartScan(rng.State, SearchType.Counting);

            return rng;
        }

        public static void StartScan(long state, SearchType searchType, int increment = 0)
        {
            long startIndex = 0;
            int width = 0;

            switch (searchType)
            {
                case SearchType.First:
                    startIndex = Settings.Base;
                    width = Settings.Width;
                    break;
                case SearchType.Counting:
                    startIndex = (long)InputArguments.Count;
                    width = Settings.CountingWidth;
                    break;
                case SearchType.Recovery:
                    startIndex = Settings.RecoveryWidth / 2;
                    state = (state + increment - startIndex) & 0xffff_ffff;
                    width = Settings.RecoveryWidth;
                    break;
            }
                        
            List<long> order = new List<long>();

            bool first = true;
            for (long i = startIndex + 1; i < width / 2 || first; i++)
            {
                List<long> newOrders = new List<long>();
                newOrders.Add(startIndex + i);
                newOrders.Add(startIndex - i);

                order.AddRange(newOrders);
                first = false;
            }

            order = order.Where(i => i >= 0).ToList();

            order = order.OrderByDescending(r => r).ToList();

            CreateOpeningTable(order.Min(), order.Max(), InputArguments.FirstState, InputArguments.SearchType, increment);
        }

        public static List<Card> CreateCardTable()
        {
            List<Card> cards = new List<Card>
            {
                new Card(0, 1, 4, 1, 5, 1, 1, "Geezard", Element.None, false),
                new Card(1, 5, 1, 1, 3, 1, 2, "Funguar", Element.None, false),
                new Card(2, 1, 3, 3, 5, 1, 3, "Bite Bug", Element.None, false),
                new Card(3, 6, 1, 1, 2, 1, 4, "Red Bat", Element.None, false),
                new Card(4, 2, 3, 1, 5, 1, 5, "Blobra", Element.None, false),
                new Card(5, 2, 1, 4, 4, 1, 6, "Gayla", Element.Thunder, false),
                new Card(6, 1, 5, 4, 1, 1, 7, "Gesper", Element.None, false),
                new Card(7, 3, 5, 2, 1, 1, 8, "Fastitocalon-F", Element.Earth, false),
                new Card(8, 2, 1, 6, 1, 1, 9, "Blood Soul", Element.None, false),
                new Card(9, 4, 2, 4, 3, 1, 10, "Caterchipillar", Element.None, false),
                new Card(10, 2, 1, 2, 6, 1, 11, "Cockatrice", Element.Thunder, false),
                new Card(11, 7, 1, 3, 1, 2, 1, "Grat", Element.None, false),
                new Card(12, 6, 2, 2, 3, 2, 2, "Buel", Element.None, false),
                new Card(13, 5, 3, 3, 4, 2, 3, "Mesmerize", Element.None, false),
                new Card(14, 6, 1, 4, 3, 2, 4, "Glacial Eye", Element.Ice, false),
                new Card(15, 3, 4, 5, 3, 2, 5, "Belhelmel", Element.None, false),
                new Card(16, 5, 3, 2, 5, 2, 6, "Thrustaevis", Element.Water, false),
                new Card(17, 5, 1, 3, 5, 2, 7, "Anacondaur", Element.Poison, false),
                new Card(18, 5, 2, 5, 2, 2, 8, "Creeps", Element.Thunder, false),
                new Card(19, 4, 4, 5, 2, 2, 9, "Grendel", Element.Thunder, false),
                new Card(20, 3, 2, 1, 7, 2, 10, "Jelleye", Element.None, false),
                new Card(21, 5, 2, 5, 3, 2, 11, "Grand Mantis", Element.None, false),
                new Card(22, 6, 6, 3, 2, 3, 1, "Forbidden", Element.None, false),
                new Card(23, 6, 3, 1, 6, 3, 2, "Armadodo", Element.Earth, false),
                new Card(24, 3, 5, 5, 5, 3, 3, "Tri-Face", Element.Poison, false),
                new Card(25, 7, 5, 1, 3, 3, 4, "Fastitocalon", Element.Water, false),
                new Card(26, 7, 1, 5, 3, 3, 5, "Snow Lion", Element.Ice, false),
                new Card(27, 5, 6, 3, 3, 3, 6, "Ochu", Element.None, false),
                new Card(28, 5, 6, 2, 4, 3, 7, "SAM08G", Element.Fire, false),
                new Card(29, 4, 4, 7, 2, 3, 8, "Death Claw", Element.Fire, false),
                new Card(30, 6, 2, 6, 3, 3, 9, "Cactuar", Element.None, false),
                new Card(31, 3, 6, 4, 4, 3, 10, "Tonberry", Element.None, false),
                new Card(32, 7, 2, 3, 5, 3, 11, "Abyss Worm", Element.Earth, false),
                new Card(33, 2, 3, 6, 7, 4, 1, "Turtapod", Element.None, false),
                new Card(34, 6, 5, 4, 5, 4, 2, "Vysage", Element.None, false),
                new Card(35, 4, 6, 2, 7, 4, 3, "T-Rexaur", Element.None, false),
                new Card(36, 2, 7, 6, 3, 4, 4, "Bomb", Element.Fire, false),
                new Card(37, 1, 6, 4, 7, 4, 5, "Blitz", Element.Thunder, false),
                new Card(38, 7, 3, 1, 6, 4, 6, "Wendigo", Element.None, false),
                new Card(39, 7, 4, 4, 4, 4, 7, "Torama", Element.None, false),
                new Card(40, 3, 7, 3, 6, 4, 8, "Imp", Element.None, false),
                new Card(41, 6, 2, 7, 3, 4, 9, "Blue Dragon", Element.Poison, false),
                new Card(42, 4, 5, 5, 6, 4, 10, "Adamantoise", Element.Earth, false),
                new Card(43, 7, 5, 4, 3, 4, 11, "Hexadragon", Element.Fire, false),
                new Card(44, 6, 5, 6, 5, 5, 1, "Iron Giant", Element.None, false),
                new Card(45, 3, 6, 5, 7, 5, 2, "Behemoth", Element.None, false),
                new Card(46, 7, 6, 5, 3, 5, 3, "Chimera", Element.Water, false),
                new Card(47, 3, 10, 2, 1, 5, 4, "PuPu", Element.None, false),
                new Card(48, 6, 2, 6, 7, 5, 5, "Elastoid", Element.None, false),
                new Card(49, 5, 5, 7, 4, 5, 6, "GIM47N", Element.None, false),
                new Card(50, 7, 7, 4, 2, 5, 7, "Malboro", Element.Poison, false),
                new Card(51, 7, 2, 7, 4, 5, 8, "Ruby Dragon", Element.Fire, false),
                new Card(52, 5, 3, 7, 6, 5, 9, "Elnoyle", Element.None, false),
                new Card(53, 4, 6, 7, 4, 5, 10, "Tonberry King", Element.None, false),
                new Card(54, 6, 6, 2, 7, 5, 11, "Wedge Biggs", Element.None, false),
                new Card(55, 2, 8, 8, 4, 6, 1, "Fujin Raijin", Element.None, false),
                new Card(56, 7, 8, 3, 4, 6, 2, "Elvoret", Element.Wind, false),
                new Card(57, 4, 8, 7, 3, 6, 3, "X-ATM092", Element.None, false),
                new Card(58, 7, 2, 8, 5, 6, 4, "Granaldo", Element.None, false),
                new Card(59, 1, 8, 8, 3, 6, 5, "Gerogero", Element.Poison, false),
                new Card(60, 8, 2, 8, 2, 6, 6, "Iguion", Element.None, false),
                new Card(61, 6, 8, 4, 5, 6, 7, "Abadon", Element.None, false),
                new Card(62, 4, 8, 5, 6, 6, 8, "Trauma", Element.None, false),
                new Card(63, 1, 8, 4, 8, 6, 9, "Oilboyle", Element.None, false),
                new Card(64, 6, 5, 8, 4, 6, 10, "Shumi Tribe", Element.None, false),
                new Card(65, 7, 5, 8, 1, 6, 11, "Krysta", Element.None, false),
                new Card(66, 8, 4, 4, 8, 7, 1, "Propagator", Element.None, false),
                new Card(67, 8, 8, 4, 4, 7, 2, "Jumbo Cactuar", Element.None, false),
                new Card(68, 8, 5, 2, 8, 7, 3, "Tri-Point", Element.Thunder, false),
                new Card(69, 5, 6, 6, 8, 7, 4, "Gargantua", Element.None, false),
                new Card(70, 8, 6, 7, 3, 7, 5, "Mobile Type 8", Element.None, false),
                new Card(71, 8, 3, 5, 8, 7, 6, "Sphinxara", Element.None, false),
                new Card(72, 8, 8, 5, 4, 7, 7, "Tiamat", Element.None, false),
                new Card(73, 5, 7, 8, 5, 7, 8, "BGH251F2", Element.None, false),
                new Card(74, 6, 8, 4, 7, 7, 9, "Red Giant", Element.None, false),
                new Card(75, 1, 8, 7, 7, 7, 10, "Catoblepas", Element.None, false),
                new Card(76, 7, 7, 8, 2, 7, 11, "Ultima Weapon", Element.None, false),
                new Card(77, 4, 4, 8, 9, 8, 1, "Chubby Chocobo", Element.None, true),
                new Card(78, 9, 6, 7, 3, 8, 2, "Angelo", Element.None, true),
                new Card(79, 3, 7, 9, 6, 8, 3, "Gilgamesh", Element.None, true),
                new Card(80, 9, 3, 9, 2, 8, 4, "MinMog", Element.None, true),
                new Card(81, 9, 4, 8, 4, 8, 5, "Chicobo", Element.None, true),
                new Card(82, 2, 9, 9, 4, 8, 6, "Quezacotl", Element.Thunder, true),
                new Card(83, 6, 7, 4, 9, 8, 7, "Shiva", Element.Ice, true),
                new Card(84, 9, 6, 2, 8, 8, 8, "Ifrit", Element.Fire, true),
                new Card(85, 8, 9, 6, 2, 8, 9, "Siren", Element.None, true),
                new Card(86, 5, 1, 9, 9, 8, 10, "Sacred", Element.Earth, true),
                new Card(87, 9, 5, 2, 9, 8, 11, "Minotaur", Element.Earth, true),
                new Card(88, 8, 4, 10, 4, 9, 1, "Carbuncle", Element.None, true),
                new Card(89, 5, 10, 8, 3, 9, 2, "Diablos", Element.None, true),
                new Card(90, 7, 10, 1, 7, 9, 3, "Leviathan", Element.Water, true),
                new Card(91, 8, 10, 3, 5, 9, 4, "Odin", Element.None, true),
                new Card(92, 10, 1, 7, 7, 9, 5, "Pandemonia", Element.Wind, true),
                new Card(93, 7, 4, 6, 10, 9, 6, "Cerberus", Element.None, true),
                new Card(94, 9, 10, 4, 2, 9, 7, "Alexander", Element.Holy, true),
                new Card(95, 7, 2, 7, 10, 9, 8, "Phoenix", Element.Fire, true),
                new Card(96, 10, 8, 2, 6, 9, 9, "Bahumut", Element.None, true),
                new Card(97, 3, 1, 10, 10, 9, 10, "Doomtrain", Element.Poison, true),
                new Card(98, 4, 4, 9, 10, 9, 11, "Eden", Element.None, true),
                new Card(99, 10, 7, 2, 8, 10, 1, "Ward", Element.None, true),
                new Card(100, 6, 7, 6, 10, 10, 2, "Kiros", Element.None, true),
                new Card(101, 5, 10, 3, 9, 10, 3, "Laguna", Element.None, true),
                new Card(102, 10, 8, 6, 4, 10, 4, "Selphie", Element.None, true),
                new Card(103, 9, 6, 10, 2, 10, 5, "Quistis", Element.None, true),
                new Card(104, 2, 6, 9, 10, 10, 6, "Irvine", Element.None, true),
                new Card(105, 8, 5, 10, 6, 10, 7, "Zell", Element.None, true),
                new Card(106, 4, 10, 2, 10, 10, 8, "Rinoa", Element.None, true),
                new Card(107, 10, 10, 3, 3, 10, 9, "Edea", Element.None, true),
                new Card(108, 6, 9, 10, 4, 10, 10, "Seifer", Element.None, true),
                new Card(109, 10, 4, 6, 9, 10, 11, "Squall", Element.None, true)
            };


            return cards;
        }

        public static List<CardFormation> CreateOpeningTable(long from, long to, QuistisPattern pattern, SearchType type = SearchType.First, int increment = 0)
        {
            long size = to + 1;

            List<long> rngStateArray = new List<long>();            

            switch (type)
            {
                case SearchType.First:
                    //CardRng cardRng = new CardRng(null, SearchType.First);
                    break;
                case SearchType.Counting:
                    CardRng cardRng = new CardRng(pattern.ToInitialState(), SearchType.Counting);
                    long maxIndex = InputArguments.Count.Value + Settings.CountingWidth;

                    for (int i = 0; i < maxIndex; i++)
                    {
                        cardRng.GetNextState();
                        rngStateArray.Add(cardRng.State + increment);
                    }
                    break;
            }

            int[] offsetArray = new int[Settings.CountingWidth];
            switch (type)
            {
                case SearchType.Counting:
                    offsetArray = new int[Settings.CountingWidth];
                    for (int i = 0; i < offsetArray.Length; i++)
                    {
                        offsetArray[i] = i - Settings.CountingWidth / 2;
                    }
                    break;
            }




            int index = -1;
            List<CardFormation> formations = new List<CardFormation>();

            for (int i = 0; i <= to; i++)
            {
                if (i < from || i > to) continue;

                foreach (int offset in offsetArray)
                {
                    var rngState = (rngStateArray[i] + offset) & 0xffff_ffff;
                    formations.Add(new CardFormation
                    {
                        Cards = GetOpeningCards(rngState, true),
                        Index = index,
                        Offset = offset
                    });
                }
            }

            //foreach (int offset in offsetArray)
            //{
            //    index++;
            //    long rngState = rngStateArray[index] + offset & 0xffff_ffff;
            //    formations.Add(new CardFormation
            //    {
            //        Cards = GetOpeningCards(rngState, true),
            //        Index = index,
            //        Offset = offset
            //    });
            //}



            return formations;
        }

        public static long ToInitialState(this QuistisPattern pattern)
        {
            switch (pattern)
            {
                case QuistisPattern.Elastoid:
                    return 0x1de5_b942;
                case QuistisPattern.Malboro:
                    return 0x963c_b5e4;
                case QuistisPattern.Wedge:
                    return 0x1f13_2481;
                default:
                    throw new ArgumentOutOfRangeException(nameof(pattern), pattern, "Invalid pattern: " + pattern);
            }
        }

        public static List<Card> GetOpeningCards(long state, bool player, bool noRare = false)
        {
            int zellCard = 105;
            int rareLimit = 10;        
            int[] levels = { 1, 2, 4, 5};


            CardRng cardRng = new CardRng(state, SearchType.First);
            List<Card> cards = new List<Card>();

            List<Card> allCards = CreateCardTable();

            if (cardRng.State % 100 < rareLimit) cards.Add(allCards.Single(s => s.ID == zellCard));

            while (cards.Count < 5)
            {
                int level = levels[cardRng.State % levels.Length];
                long row1 = cardRng.State % 11;
                cardRng.GetNextState();
                long cardIndex = (level - 1) * 11 + row1;
                cards.Add(allCards.Single(s => s.ID == cardIndex));
            }


            return cards;
        }

        public static void ConfigureTimer(long state)
        {
            double delay = (double)Settings.FrameDelay / 60;
            int increment = 0;
            double incrementStart = delay - Settings.ForcedIncrement;
            int timer_width = 8;
            int width = 60;

            DateTime start = DateTime.Now;
            

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (s, e) =>
            {
                Timer timer = new Timer((o) =>
                {
                    TimeSpan duration = DateTime.Now - start;

                    increment = Math.Max((int)(duration.Ticks - incrementStart) * 60, Settings.ForcedIncrement + Settings.AcceptFrameDelay);

                    if (increment <= Settings.ForcedIncrement + Settings.AcceptFrameDelay) increment = Settings.ForcedIncrement;


                }, null,TimeSpan.Zero, TimeSpan.FromSeconds((double)1 / 60));
            };
        } 

    }
}
