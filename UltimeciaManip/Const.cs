using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimeciaManip.Entities;

namespace UltimeciaManip
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        Unknown
    }

    public static class Const
    {
        public static int Movements { get; set; } = 12;
        public static int Base { get; set; } = 2800;
        public static int Width { get; set; } = 2000;
        public static int Left_Width { get; set; } = 40;

        #region Party Formations

        public static PartyFormation[] PartyFormationsJP = new[]
        {

            new PartyFormation(1800, 122, "f27aaf39", "Zell,Squall,Rinoa,", "888666688824", "{Irvine,Zell,Selphie=>51, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1801, 182, "9eb6297e", "Zell,Squall,Irvine,", "886666888244", "{Irvine,Zell,Selphie=>50, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1802, 168, "29a83edf", "Rinoa,Zell,Quistis,", "866668882448", "{Irvine,Zell,Selphie=>49, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1803, 68, "3f44e72c", "Selphie,Irvine,Quistis,", "666688824488", "{Irvine,Zell,Selphie=>48, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1804, 206, "e6ce05f5", "Selphie,Squall,Quistis,", "666888244884", "{Irvine,Zell,Selphie=>47, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(1805, 7, "dc075f8a", "Selphie,Zell,Quistis,", "668882448846", "{Irvine,Zell,Selphie=>46, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(1806, 251, "dcfbe9fb", "Rinoa,Irvine,Selphie,", "688824488466", "{Irvine,Zell,Selphie=>45, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(1807, 175, "8baf4a18", "Zell,Squall,Quistis,", "888244884666", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(1808, 198, "48c60c71", "Rinoa,Irvine,Quistis,", "882448846664", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(1809, 131, "a483ea56", "Irvine,Squall,Rinoa,", "824488466646", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(1810, 21, "52152ad7", "Zell,Squall,Selphie,", "244884666462", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(1811, 90, "1f5aefc4", "Irvine,Zell,Rinoa,", "448846664624", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(1812, 93, "445dfead", "Irvine,Squall,Rinoa,", "488466646242", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(1813, 108, "a66c55e2", "Zell,Squall,Selphie,", "884666462428", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(1814, 23, "ad179d73", "Zell,Squall,Rinoa,", "846664624286", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(1815, 249, "def94430", "Zell,Squall,Irvine,", "466646242862", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(1816, 8, "d008d8a9", "Irvine,Zell,Quistis,", "666462428628", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(1817, 125, "c17dee2e", "Irvine,Squall,Rinoa,", "664624286282", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1818, 196, "a6c49dcf", "Zell,Squall,Quistis,", "646242862828", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1819, 230, "86e6735c", "Irvine,Zell,Rinoa,", "462428628284", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1820, 109, "3c6d5665", "Selphie,Irvine,Quistis,", "624286282842", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1821, 254, "81febf3a", "Irvine,Zell,Quistis,", "242862828424", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(1822, 151, "989747eb", "Irvine,Squall,Selphie,", "428628284246", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(1823, 21, "5b156948", "Selphie,Squall,Quistis,", "286282842462", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(1824, 225, "03e1f3e1", "Rinoa,Squall,Quistis,", "862828424622", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(1825, 137, "40899506", "Zell,Squall,Quistis,", "628284246222", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(1826, 160, "2ea077c7", "Irvine,Squall,Selphie,", "282842462228", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(1827, 187, "e9bbd1f4", "Zell,Squall,Rinoa,", "828424622286", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(1828, 168, "15a8ed1d", "Rinoa,Irvine,Selphie,", "284246222868", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(1829, 153, "7299fb92", "Rinoa,Irvine,Quistis,", "842462228682", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(1830, 34, "5b22c963", "Rinoa,Irvine,Quistis,", "424622286824", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(1831, 190, "4cbe1960", "Zell,Squall,Irvine,", "246222868244", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(1832, 236, "98ec3e19", "Rinoa,Irvine,Selphie,", "462228682448", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(1833, 216, "77d83ede", "Rinoa,Irvine,Quistis,", "622286824488", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(1834, 238, "e7ee98bf", "Zell,Squall,Selphie,", "222868244884", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(1835, 219, "15db6b8c", "Zell,Squall,Selphie,", "228682448846", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(1836, 121, "e379a2d5", "Rinoa,Squall,Selphie,", "286824488462", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(1837, 37, "f0256aea", "Rinoa,Zell,Selphie,", "868244884622", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(1838, 126, "c17e01db", "Rinoa,Squall,Quistis,", "682448846224", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(1839, 153, "d199b478", "Zell,Squall,Rinoa,", "824488462242", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(1840, 62, "203e9751", "Irvine,Zell,Quistis,", "244884622424", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(1841, 103, "66674bb6", "Irvine,Squall,Selphie,", "448846224246", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1842, 208, "d7d0e0b7", "Selphie,Squall,Quistis,", "488462242468", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1843, 241, "ccf1a024", "Zell,Squall,Selphie,", "884622424682", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1844, 132, "e184578d", "Rinoa,Irvine,Quistis,", "846224246828", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1845, 20, "dc146d42", "Selphie,Irvine,Quistis,", "462242468288", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1846, 8, "3108d153", "Zell,Squall,Rinoa,", "622424682888", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1847, 186, "89ba9a90", "Zell,Squall,Selphie,", "224246828884", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1848, 235, "9aebdf89", "Selphie,Rinoa,Quistis,", "242468288846", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1849, 128, "81801b8e", "Selphie,Irvine,Quistis,", "424682888468", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1850, 197, "89c52faf", "Rinoa,Squall,Selphie,", "246828884682", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Selphie"),

            new PartyFormation(1851, 214, "0dd6cfbc", "Irvine,Zell,Selphie,", "468288846824", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(1852, 41, "bf29eb45", "Rinoa,Irvine,Selphie,", "682888468242", "{Irvine,Zell,Selphie=>73, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(1853, 230, "a6e6629a", "Selphie,Zell,Quistis,", "828884682424", "{Irvine,Zell,Selphie=>72, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(1854, 63, "9f3f17cb", "Zell,Squall,Quistis,", "288846824246", "{Irvine,Zell,Selphie=>71, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(1855, 31, "f91f2ba8", "Selphie,Squall,Quistis,", "888468242466", "{Irvine,Zell,Selphie=>70, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(1856, 130, "fd82f6c1", "Irvine,Squall,Rinoa,", "884682424664", "{Irvine,Zell,Selphie=>69, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(1857, 56, "b2380e66", "Selphie,Squall,Quistis,", "846824246648", "{Irvine,Zell,Selphie=>68, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(1858, 37, "ff2565a7", "Rinoa,Irvine,Selphie,", "468242466482", "{Irvine,Zell,Selphie=>67, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(1859, 15, "0e0f5a54", "Irvine,Zell,Rinoa,", "682424664826", "{Irvine,Zell,Selphie=>66, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(1860, 7, "db073dfd", "Rinoa,Zell,Selphie,", "824246648266", "{Irvine,Zell,Selphie=>65, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(1861, 166, "a5a6aaf2", "Zell,Squall,Quistis,", "242466482664", "{Irvine,Zell,Selphie=>64, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(1862, 56, "f938b543", "Rinoa,Irvine,Selphie,", "424664826648", "{Irvine,Zell,Selphie=>63, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(1863, 49, "9931c7c0", "Irvine,Zell,Quistis,", "246648266482", "{Irvine,Zell,Selphie=>62, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(1864, 142, "a38ebcf9", "Zell,Squall,Selphie,", "466482664824", "{Irvine,Zell,Selphie=>61, Irvine,Zell,Quistis=>54, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1865, 240, "82f0843e", "Zell,Squall,Rinoa,", "664826648248", "{Irvine,Zell,Selphie=>60, Irvine,Zell,Quistis=>53, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1866, 167, "0ea7629f", "Irvine,Squall,Quistis,", "648266482486", "{Irvine,Zell,Selphie=>59, Irvine,Zell,Quistis=>52, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1867, 75, "e34b9fec", "Rinoa,Irvine,Selphie,", "482664824866", "{Irvine,Zell,Selphie=>58, Irvine,Zell,Quistis=>51, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1868, 117, "6e752fb5", "Zell,Squall,Irvine,", "826648248662", "{Irvine,Zell,Selphie=>57, Irvine,Zell,Quistis=>50, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1869, 108, "976ca64a", "Irvine,Zell,Rinoa,", "266482486628", "{Irvine,Zell,Selphie=>56, Irvine,Zell,Quistis=>49, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1870, 41, "fb2989bb", "Irvine,Squall,Rinoa,", "664824866282", "{Irvine,Zell,Selphie=>55, Irvine,Zell,Quistis=>48, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1871, 72, "9a48ced8", "Rinoa,Irvine,Quistis,", "648248662828", "{Irvine,Zell,Selphie=>54, Irvine,Zell,Quistis=>47, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1872, 22, "b3161231", "Irvine,Zell,Rinoa,", "482486628284", "{Irvine,Zell,Selphie=>53, Irvine,Zell,Quistis=>46, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1873, 214, "7cd6dd16", "Irvine,Squall,Rinoa,", "824866282844", "{Irvine,Zell,Selphie=>52, Irvine,Zell,Quistis=>45, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1874, 221, "33dd0697", "Irvine,Squall,Rinoa,", "248662828442", "{Irvine,Zell,Selphie=>51, Irvine,Zell,Quistis=>44, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1875, 232, "dce80084", "Selphie,Irvine,Quistis,", "486628284428", "{Irvine,Zell,Selphie=>50, Irvine,Zell,Quistis=>43, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1876, 8, "a908a06d", "Irvine,Squall,Quistis,", "866282844288", "{Irvine,Zell,Selphie=>49, Irvine,Zell,Quistis=>42, Selphie,Irvine,Quistis=>26}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1877, 219, "5adbb4a2", "Zell,Squall,Irvine,", "662828442886", "{Irvine,Zell,Selphie=>48, Irvine,Zell,Quistis=>41, Selphie,Irvine,Quistis=>25}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1878, 225, "77e17533", "Irvine,Squall,Quistis,", "628284428862", "{Irvine,Zell,Selphie=>47, Irvine,Zell,Quistis=>40, Selphie,Irvine,Quistis=>24}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1879, 38, "5526a0f0", "Rinoa,Zell,Selphie,", "282844288624", "{Irvine,Zell,Selphie=>46, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>23}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1880, 27, "701bd669", "Selphie,Rinoa,Quistis,", "828442886246", "{Irvine,Zell,Selphie=>45, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>22}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1881, 100, "b56478ee", "Selphie,Zell,Quistis,", "284428862468", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>21}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1882, 180, "ceb4318f", "Irvine,Squall,Quistis,", "844288624688", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>20}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1883, 108, "8d6cdc1c", "Irvine,Squall,Selphie,", "442886246888", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>19}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1884, 18, "bc127025", "Rinoa,Squall,Selphie,", "428862468884", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>18}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1885, 163, "d3a335fa", "Irvine,Squall,Quistis,", "288624688846", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>17}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1886, 76, "104c57ab", "Zell,Squall,Rinoa,", "886246888468", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>16}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1887, 121, "6c799e08", "Irvine,Squall,Rinoa,", "862468884682", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>15}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1888, 30, "801ee9a1", "Rinoa,Irvine,Selphie,", "624688846824", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>14}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1889, 222, "8bdeb7c6", "Rinoa,Irvine,Selphie,", "246888468244", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>13}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1890, 246, "d2f6c387", "Irvine,Squall,Quistis,", "468884682444", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1891, 14, "840e92b4", "Rinoa,Zell,Quistis,", "688846824444", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1892, 31, "d61f7edd", "Rinoa,Zell,Quistis,", "888468244446", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1893, 254, "fffe8a52", "Selphie,Zell,Quistis,", "884682444464", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1894, 242, "5af21123", "Irvine,Squall,Quistis,", "846824444644", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1895, 92, "9e5c2620", "Zell,Squall,Irvine,", "468244446448", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1896, 154, "1d9a2bd9", "Zell,Squall,Quistis,", "682444464484", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1897, 214, "96d6f99e", "Zell,Squall,Quistis,", "824444644844", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1898, 202, "e7ca9c7f", "Rinoa,Squall,Selphie,", "244446448444", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1899, 45, "b62d844c", "Irvine,Squall,Selphie,", "444464484442", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1900, 120, "0e78ac95", "Zell,Squall,Quistis,", "444644844428", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1901, 53, "3e3511aa", "Irvine,Squall,Rinoa,", "446448444282", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1902, 118, "7b76819b", "Selphie,Irvine,Quistis,", "464484442824", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1903, 212, "45d49938", "Irvine,Squall,Selphie,", "644844428248", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1904, 132, "3b847d11", "Selphie,Rinoa,Quistis,", "448444282488", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1905, 170, "c1aa9e76", "Selphie,Squall,Quistis,", "484442824884", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1906, 49, "f7319c77", "Selphie,Squall,Quistis,", "844428248842", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1907, 214, "98d610e4", "Zell,Squall,Quistis,", "444282488424", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1908, 162, "40a2d94d", "Rinoa,Squall,Quistis,", "442824884244", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1909, 26, "c21a2c02", "Rinoa,Squall,Selphie,", "428248842444", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1910, 25, "2a198913", "Rinoa,Squall,Quistis,", "282488424442", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1911, 85, "8c555750", "Rinoa,Squall,Selphie,", "824884244422", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1912, 208, "98d0bd49", "Selphie,Irvine,Quistis,", "248842444228", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1913, 3, "9a03064e", "Zell,Squall,Quistis,", "488424442286", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(1914, 137, "2d89a36f", "Irvine,Squall,Rinoa,", "884244422862", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Quistis"),

            new PartyFormation(1915, 64, "ea40987c", "Selphie,Zell,Quistis,", "842444228628", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(1916, 222, "d7dee505", "Rinoa,Squall,Quistis,", "424442286284", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Quistis"),

            new PartyFormation(1917, 141, "3a8d395a", "Zell,Squall,Quistis,", "244422862842", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Quistis"),

            new PartyFormation(1918, 55, "2b37078b", "Irvine,Zell,Quistis,", "444228628426", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(1919, 60, "4b3cc068", "Selphie,Squall,Quistis,", "442286284268", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(1920, 237, "c3edcc81", "Rinoa,Zell,Selphie,", "422862842682", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(1921, 85, "cd559126", "Rinoa,Irvine,Selphie,", "228628426822", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(1922, 12, "690c9167", "Rinoa,Irvine,Quistis,", "286284268228", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(1923, 81, "2b517b14", "Zell,Squall,Irvine,", "862842682282", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(1924, 169, "8aa9afbd", "Rinoa,Irvine,Quistis,", "628426822822", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(1925, 249, "a6f999b2", "Irvine,Zell,Selphie,", "284268228222", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(1926, 198, "36c6dd03", "Selphie,Rinoa,Quistis,", "842682282224", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>17}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1927, 85, "9d553480", "Selphie,Rinoa,Quistis,", "426822822242", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>16}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1928, 70, "0e468ab9", "Rinoa,Squall,Selphie,", "268228222424", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>15}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1929, 99, "d6639efe", "Irvine,Zell,Rinoa,", "682282224246", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>14}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1930, 80, "1950465f", "Irvine,Squall,Quistis,", "822822242468", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>13}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1931, 25, "c91918ac", "Rinoa,Zell,Selphie,", "228222424682", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1932, 60, "063c1975", "Selphie,Zell,Quistis,", "282224246828", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1933, 214, "5cd6ad0a", "Selphie,Zell,Quistis,", "822242468284", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1934, 220, "4fdce97b", "Zell,Squall,Irvine,", "222424682848", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1935, 85, "20551398", "Zell,Squall,Irvine,", "224246828482", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1936, 193, "6fc1d7f1", "Irvine,Squall,Selphie,", "242468284822", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1937, 186, "daba8fd6", "Irvine,Zell,Rinoa,", "424682848224", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1938, 198, "8ec6a257", "Rinoa,Squall,Selphie,", "246828482244", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1939, 83, "f653d144", "Zell,Squall,Irvine,", "468284822446", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1940, 11, "8a0b022d", "Zell,Squall,Rinoa,", "682848224466", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1941, 39, "3d27d362", "Rinoa,Irvine,Quistis,", "828482244666", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1942, 41, "8c290cf3", "Zell,Squall,Irvine,", "284822446662", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1943, 94, "e65ebdb0", "Selphie,Irvine,Quistis,", "848224466624", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1944, 66, "5a429429", "Irvine,Squall,Rinoa,", "482244666244", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(1945, 51, "b833c3ae", "Irvine,Zell,Quistis,", "822446662446", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(1946, 61, "ba3d854f", "Zell,Squall,Rinoa,", "224466624462", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(1947, 234, "34ea04dc", "Rinoa,Squall,Selphie,", "244666244624", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(1948, 71, "734749e5", "Selphie,Zell,Quistis,", "446662446246", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(1949, 252, "19fc6cba", "Rinoa,Squall,Selphie,", "466624462468", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(1950, 119, "4b77276b", "Rinoa,Squall,Quistis,", "666244624686", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(1951, 128, "178092c8", "Rinoa,Irvine,Quistis,", "662446246868", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(1952, 39, "7d279f61", "Zell,Squall,Irvine,", "624462468686", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Selphie"),

            new PartyFormation(1953, 116, "42749a86", "Rinoa,Irvine,Selphie,", "244624686868", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Selphie"),

            new PartyFormation(1954, 94, "5c5ecf47", "Irvine,Zell,Selphie,", "446246868684", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>2}", "Irvine,Zell,Selphie"),

            new PartyFormation(1955, 112, "8f701374", "Irvine,Zell,Rinoa,", "462468686848", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1956, 93, "b85dd09d", "Selphie,Irvine,Quistis,", "624686868482", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1957, 239, "4befd912", "Irvine,Zell,Selphie,", "246868684826", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(1958, 47, "df2f18e3", "Rinoa,Squall,Selphie,", "468686848266", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1959, 52, "4334f2e0", "Zell,Squall,Selphie,", "686868482668", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1960, 203, "78cbd999", "Zell,Squall,Rinoa,", "868684826686", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1961, 110, "b06e745e", "Rinoa,Zell,Selphie,", "686848266864", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1962, 48, "a530603f", "Rinoa,Squall,Selphie,", "868482668648", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1963, 166, "82a65d0c", "Irvine,Squall,Rinoa,", "684826686484", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1964, 119, "54777655", "Rinoa,Zell,Selphie,", "848266864846", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1965, 169, "77a9786a", "Zell,Squall,Selphie,", "482668648462", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1966, 212, "a1d4c15b", "Zell,Squall,Selphie,", "826686484628", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1967, 226, "61e23df8", "Selphie,Zell,Quistis,", "266864846284", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1968, 6, "820622d1", "Selphie,Zell,Quistis,", "668648462844", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1969, 222, "39deb136", "Rinoa,Irvine,Selphie,", "686484628444", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1970, 148, "43941837", "Selphie,Irvine,Quistis,", "864846284448", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1971, 249, "96f941a4", "Rinoa,Zell,Quistis,", "648462844482", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>41}", "Irvine,Zell,Selphie"),

            new PartyFormation(1972, 249, "a2f91b0d", "Zell,Squall,Irvine,", "484628444822", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>40}", "Irvine,Zell,Selphie"),

            new PartyFormation(1973, 92, "835caac2", "Irvine,Zell,Selphie,", "846284448228", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>39}", "Irvine,Zell,Selphie"),

            new PartyFormation(1974, 136, "7e8800d3", "Irvine,Zell,Quistis,", "462844482288", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Quistis"),

            new PartyFormation(1975, 90, "865ad410", "Zell,Squall,Selphie,", "628444822884", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Selphie"),

            new PartyFormation(1976, 169, "f5a95b09", "Zell,Squall,Quistis,", "284448228842", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Selphie"),

            new PartyFormation(1977, 206, "e4ceb10e", "Irvine,Zell,Selphie,", "844482288424", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Selphie"),

            new PartyFormation(1978, 199, "e4c7d72f", "Zell,Squall,Irvine,", "444822884246", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Selphie"),

            new PartyFormation(1979, 1, "aa01213c", "Irvine,Squall,Selphie,", "448228842462", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Selphie"),

            new PartyFormation(1980, 3, "ab039ec5", "Rinoa,Squall,Selphie,", "482288424626", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Selphie"),

            new PartyFormation(1981, 72, "bc48d01a", "Rinoa,Irvine,Quistis,", "822884246268", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Selphie"),

            new PartyFormation(1982, 132, "e884b74b", "Zell,Squall,Irvine,", "228842462688", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Selphie"),

            new PartyFormation(1983, 93, "3f5d1528", "Irvine,Squall,Rinoa,", "288424626882", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Selphie"),

            new PartyFormation(1984, 4, "dc046241", "Irvine,Squall,Selphie,", "884246268828", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Selphie"),

            new PartyFormation(1985, 19, "8313d3e6", "Irvine,Squall,Quistis,", "842462688286", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Selphie"),

            new PartyFormation(1986, 229, "23e57d27", "Irvine,Zell,Rinoa,", "424626882862", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Selphie"),

            new PartyFormation(1987, 2, "e8025bd4", "Irvine,Zell,Rinoa,", "246268828624", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Selphie"),

            new PartyFormation(1988, 243, "5af3e17d", "Selphie,Zell,Quistis,", "462688286246", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(1989, 57, "2c394872", "Rinoa,Zell,Quistis,", "626882862462", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(1990, 162, "42a2c4c3", "Zell,Squall,Selphie,", "268828624624", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(1991, 19, "a9136140", "Irvine,Squall,Selphie,", "688286246246", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(1992, 98, "5c621879", "Irvine,Zell,Selphie,", "882862462464", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(1993, 207, "dfcf79be", "Zell,Squall,Rinoa,", "828624624646", "{Irvine,Zell,Selphie=>49, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(1994, 98, "e962ea1f", "Irvine,Zell,Rinoa,", "286246246464", "{Irvine,Zell,Selphie=>48, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(1995, 109, "756d516c", "Irvine,Squall,Rinoa,", "862462464642", "{Irvine,Zell,Selphie=>47, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(1996, 226, "b3e2c335", "Irvine,Zell,Quistis,", "624624646424", "{Irvine,Zell,Selphie=>46, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(1997, 5, "1f0573ca", "Irvine,Squall,Rinoa,", "246246464242", "{Irvine,Zell,Selphie=>45, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(1998, 214, "b6d6093b", "Rinoa,Irvine,Selphie,", "462464642424", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(1999, 148, "2e941858", "Irvine,Squall,Quistis,", "624646424248", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(2000, 137, "20895db1", "Rinoa,Irvine,Selphie,", "246464242482", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(2001, 239, "1cef0296", "Rinoa,Irvine,Quistis,", "464642424826", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(2002, 145, "3a91fe17", "Irvine,Squall,Rinoa,", "646424248262", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2003, 94, "c85e6204", "Irvine,Zell,Rinoa,", "464242482624", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2004, 37, "e52523ed", "Zell,Squall,Quistis,", "642424826242", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2005, 16, "d810b222", "Rinoa,Squall,Quistis,", "424248262428", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(2006, 174, "7dae64b3", "Rinoa,Irvine,Quistis,", "242482624284", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2007, 97, "fb619a70", "Irvine,Zell,Quistis,", "424826242842", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(2008, 61, "a83d11e9", "Zell,Squall,Selphie,", "248262428422", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(2009, 171, "40abce6e", "Irvine,Zell,Rinoa,", "482624284226", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Quistis"),

            new PartyFormation(2010, 32, "7920990f", "Zell,Squall,Quistis,", "826242842268", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>2}", "Irvine,Zell,Quistis"),

            new PartyFormation(2011, 29, "b21ded9c", "Irvine,Zell,Quistis,", "262428422682", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>1}", "Irvine,Zell,Quistis"),

            new PartyFormation(2012, 203, "57cbe3a5", "Selphie,Irvine,Quistis,", "624284226826", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2013, 202, "77ca637a", "Irvine,Zell,Quistis,", "242842268264", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(2014, 215, "95d7b72b", "Zell,Squall,Irvine,", "428422682646", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2015, 234, "1cea4788", "Zell,Squall,Quistis,", "284226826464", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2016, 188, "8cbc1521", "Rinoa,Zell,Quistis,", "842268264648", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2017, 11, "f30b3d46", "Rinoa,Irvine,Selphie,", "422682646486", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2018, 152, "12989b07", "Selphie,Zell,Quistis,", "226826464868", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2019, 160, "18a05434", "Zell,Squall,Quistis,", "268264648688", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2020, 35, "aa23e25d", "Irvine,Squall,Rinoa,", "682646486886", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2021, 45, "112de7d2", "Selphie,Rinoa,Quistis,", "826464868862", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2022, 153, "eb99e0a3", "Selphie,Zell,Quistis,", "264648688622", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2023, 8, "54087fa0", "Zell,Squall,Rinoa,", "646486886228", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2024, 65, "b4414759", "Irvine,Squall,Quistis,", "464868862282", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2025, 94, "6b5eaf1e", "Zell,Squall,Quistis,", "648688622824", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2026, 223, "9fdfe3ff", "Selphie,Irvine,Quistis,", "486886228246", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2027, 5, "6005f5cc", "Selphie,Zell,Quistis,", "868862282462", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(2028, 54, "9b360015", "Irvine,Zell,Rinoa,", "688622824624", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(2029, 66, "ef429f2a", "Zell,Squall,Selphie,", "886228246244", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(2030, 88, "f058c11b", "Selphie,Zell,Quistis,", "862282462448", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(2031, 130, "9682a2b8", "Rinoa,Squall,Selphie,", "622824624484", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2032, 131, "75838891", "Selphie,Zell,Quistis,", "228246244846", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2033, 195, "8dc383f6", "Zell,Squall,Quistis,", "282462448466", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2034, 184, "74b853f7", "Selphie,Squall,Quistis,", "824624484668", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(2035, 27, "841b3264", "Irvine,Zell,Quistis,", "246244846686", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2036, 71, "e6471ccd", "Rinoa,Squall,Selphie,", "462448466866", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2037, 155, "0a9be982", "Rinoa,Squall,Selphie,", "624484668666", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2038, 20, "a2143893", "Rinoa,Squall,Selphie,", "244846686668", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2039, 139, "408b10d0", "Zell,Squall,Quistis,", "448466866686", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2040, 53, "ab35b8c9", "Selphie,Squall,Quistis,", "484668666862", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2041, 163, "38a31bce", "Selphie,Irvine,Quistis,", "846686668626", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2042, 63, "9f3fcaef", "Irvine,Zell,Selphie,", "466866686266", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>51}", "Irvine,Zell,Selphie"),

            new PartyFormation(2043, 216, "e1d869fc", "Rinoa,Zell,Quistis,", "668666862668", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>50}", "Irvine,Zell,Selphie"),

            new PartyFormation(2044, 88, "0e581885", "Rinoa,Squall,Selphie,", "686668626688", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>49}", "Irvine,Zell,Selphie"),

            new PartyFormation(2045, 217, "aed926da", "Irvine,Zell,Selphie,", "866686266882", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>48}", "Irvine,Zell,Selphie"),

            new PartyFormation(2046, 232, "02e8270b", "Zell,Squall,Irvine,", "666862668828", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>47}", "Irvine,Zell,Selphie"),

            new PartyFormation(2047, 64, "f64029e8", "Rinoa,Squall,Quistis,", "668626688288", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>46}", "Irvine,Zell,Selphie"),

            new PartyFormation(2048, 134, "b786b801", "Rinoa,Zell,Quistis,", "686266882884", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>45}", "Irvine,Zell,Selphie"),

            new PartyFormation(2049, 50, "c232d6a6", "Rinoa,Zell,Quistis,", "862668828844", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>44}", "Irvine,Zell,Selphie"),

            new PartyFormation(2050, 112, "577028e7", "Selphie,Squall,Quistis,", "626688288448", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>43}", "Irvine,Zell,Selphie"),

            new PartyFormation(2051, 225, "b0e1fc94", "Rinoa,Zell,Quistis,", "266882884482", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>42}", "Irvine,Zell,Selphie"),

            new PartyFormation(2052, 165, "19a5d33d", "Zell,Squall,Rinoa,", "668828844822", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>41}", "Irvine,Zell,Selphie"),

            new PartyFormation(2053, 37, "5025b732", "Rinoa,Squall,Selphie,", "688288448222", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>40}", "Irvine,Zell,Selphie"),

            new PartyFormation(2054, 140, "008c6c83", "Selphie,Rinoa,Quistis,", "882884482228", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>39}", "Irvine,Zell,Selphie"),

            new PartyFormation(2055, 44, "352c4e00", "Irvine,Squall,Selphie,", "828844822288", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Selphie"),

            new PartyFormation(2056, 161, "77a16639", "Irvine,Zell,Selphie,", "288448222882", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Selphie"),

            new PartyFormation(2057, 244, "a5f4147e", "Selphie,Squall,Quistis,", "884482228828", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Quistis"),

            new PartyFormation(2058, 159, "de9f4ddf", "Irvine,Zell,Quistis,", "844822288286", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Quistis"),

            new PartyFormation(2059, 8, "2d084a2c", "Irvine,Squall,Rinoa,", "448222882868", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Quistis"),

            new PartyFormation(2060, 41, "3d292cf5", "Irvine,Squall,Rinoa,", "482228828682", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Quistis"),

            new PartyFormation(2061, 184, "90b8fa8a", "Rinoa,Zell,Selphie,", "822288286828", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Quistis"),

            new PartyFormation(2062, 212, "cbd4e8fb", "Irvine,Zell,Rinoa,", "222882868288", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Quistis"),

            new PartyFormation(2063, 197, "95c5dd18", "Irvine,Zell,Quistis,", "228828682882", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(2064, 44, "272ca371", "Selphie,Rinoa,Quistis,", "288286828828", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Quistis"),

            new PartyFormation(2065, 52, "62343556", "Zell,Squall,Selphie,", "882868288288", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(2066, 255, "ceff19d7", "Irvine,Zell,Quistis,", "828682882886", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Quistis"),

            new PartyFormation(2067, 199, "6fc7b2c4", "Irvine,Squall,Rinoa,", "286828828866", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Selphie"),

            new PartyFormation(2068, 23, "781705ad", "Rinoa,Squall,Quistis,", "868288288666", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Selphie"),

            new PartyFormation(2069, 86, "765650e2", "Rinoa,Squall,Quistis,", "682882886664", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(2070, 49, "a0317c73", "Rinoa,Zell,Selphie,", "828828866642", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(2071, 239, "bcef3730", "Selphie,Squall,Quistis,", "288288666426", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(2072, 203, "33cb4fa9", "Selphie,Squall,Quistis,", "882886664266", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(2073, 140, "858c992e", "Irvine,Squall,Selphie,", "828866642668", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(2074, 29, "db1d6ccf", "Rinoa,Squall,Selphie,", "288666426682", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(2075, 200, "f9c8965c", "Selphie,Zell,Quistis,", "886664266828", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(2076, 96, "1f603d65", "Irvine,Zell,Selphie,", "866642668288", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(2077, 205, "cfcd1a3a", "Selphie,Zell,Quistis,", "666426682882", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(2078, 46, "fb2e06eb", "Rinoa,Zell,Selphie,", "664266828824", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2079, 118, "fd76bc48", "Selphie,Zell,Quistis,", "642668288244", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2080, 156, "009c4ae1", "Rinoa,Zell,Selphie,", "426682882448", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2081, 98, "ec62a006", "Irvine,Zell,Selphie,", "266828824484", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2082, 100, "fd6426c7", "Rinoa,Zell,Selphie,", "668288244848", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(2083, 95, "ec5f54f4", "Rinoa,Squall,Quistis,", "682882448486", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2084, 49, "5931b41d", "Irvine,Squall,Selphie,", "828824484862", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2085, 120, "ca78b692", "Selphie,Zell,Quistis,", "288244848628", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2086, 242, "43f26863", "Irvine,Squall,Quistis,", "882448486284", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(2087, 150, "a996cc60", "Irvine,Zell,Quistis,", "824484862844", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2088, 186, "99ba7519", "Rinoa,Zell,Quistis,", "244848628444", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(2089, 103, "2e67a9de", "Rinoa,Squall,Quistis,", "448486284446", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Selphie"),

            new PartyFormation(2090, 153, "179927bf", "Selphie,Zell,Quistis,", "484862844462", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Selphie"),

            new PartyFormation(2091, 12, "f30c4e8c", "Rinoa,Zell,Selphie,", "848628444628", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>2}", "Irvine,Zell,Selphie"),

            new PartyFormation(2092, 116, "887449d5", "Irvine,Zell,Selphie,", "486284446288", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>1}", "Irvine,Zell,Selphie"),

            new PartyFormation(2093, 192, "b7c085ea", "Selphie,Irvine,Quistis,", "862844462888", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2094, 194, "e2c280db", "Rinoa,Zell,Selphie,", "628444628884", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(2095, 117, "1475c778", "Selphie,Zell,Quistis,", "284446288842", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(2096, 188, "57bcae51", "Selphie,Zell,Quistis,", "844462888428", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2097, 25, "3c1916b6", "Irvine,Squall,Rinoa,", "444628884282", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2098, 94, "025e4fb7", "Rinoa,Irvine,Quistis,", "446288842824", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2099, 251, "dcfbe324", "Irvine,Zell,Rinoa,", "462888428246", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2100, 76, "a84cde8d", "Irvine,Squall,Rinoa,", "628884282468", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(2101, 151, "0297e842", "Selphie,Squall,Quistis,", "288842824686", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(2102, 126, "c87e3053", "Rinoa,Squall,Quistis,", "888428246864", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(2103, 166, "43a60d90", "Irvine,Squall,Selphie,", "884282468644", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(2104, 53, "7335d689", "Irvine,Zell,Selphie,", "842824686442", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(2105, 64, "2c40468e", "Selphie,Rinoa,Quistis,", "428246864428", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2106, 177, "0cb17eaf", "Irvine,Zell,Quistis,", "282468644282", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(2107, 134, "e68672bc", "Selphie,Rinoa,Quistis,", "824686442824", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2108, 156, "979c5245", "Irvine,Squall,Selphie,", "246864428248", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2109, 254, "54fe3d9a", "Zell,Squall,Selphie,", "468644282484", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2110, 33, "662156cb", "Selphie,Squall,Quistis,", "686442824842", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2111, 165, "50a5fea8", "Selphie,Irvine,Quistis,", "864428248422", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2112, 52, "8834cdc1", "Rinoa,Irvine,Quistis,", "644282484228", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(2113, 114, "39729966", "Rinoa,Irvine,Selphie,", "442824842284", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(2114, 108, "eb6c94a7", "Selphie,Squall,Quistis,", "428248422848", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(2115, 176, "b2b05d54", "Rinoa,Squall,Quistis,", "282484228488", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(2116, 127, "547f84fd", "Irvine,Zell,Quistis,", "824842284886", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(2117, 126, "ed7ee5f2", "Irvine,Squall,Selphie,", "248422848864", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2118, 67, "1443d443", "Rinoa,Squall,Selphie,", "484228488646", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(2119, 95, "7a5ffac0", "Selphie,Zell,Quistis,", "842284886466", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(2120, 196, "09c473f9", "Zell,Squall,Rinoa,", "422848864668", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(2121, 145, "ef916f3e", "Irvine,Zell,Rinoa,", "228488646682", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(2122, 197, "18c5719f", "Rinoa,Squall,Quistis,", "284886466822", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(2123, 170, "f4aa02ec", "Rinoa,Squall,Quistis,", "848864668224", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(2124, 207, "27cf56b5", "Rinoa,Squall,Selphie,", "488646682246", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(2125, 177, "24b1414a", "Rinoa,Irvine,Selphie,", "886466822462", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Selphie"),

            new PartyFormation(2126, 153, "ea9988bb", "Selphie,Zell,Quistis,", "864668224622", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Selphie"),

            new PartyFormation(2127, 170, "e6aa61d8", "Irvine,Zell,Selphie,", "646682246224", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>2}", "Irvine,Zell,Selphie"),

            new PartyFormation(2128, 107, "a56ba931", "Selphie,Squall,Quistis,", "466822462246", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2129, 74, "894a2816", "Selphie,Irvine,Quistis,", "668224622464", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2130, 205, "a3cdf597", "Irvine,Squall,Quistis,", "682246224642", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(2131, 79, "c94fc384", "Selphie,Zell,Quistis,", "822462246426", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(2132, 160, "c0a0a76d", "Irvine,Zell,Selphie,", "224622464268", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(2133, 184, "22b8afa2", "Irvine,Zell,Selphie,", "246224642688", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2134, 114, "07725433", "Zell,Squall,Quistis,", "462246426884", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2135, 199, "13c793f0", "Irvine,Squall,Rinoa,", "622464268846", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2136, 173, "96ad4d69", "Zell,Squall,Irvine,", "224642688462", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2137, 150, "7d9623ee", "Irvine,Zell,Rinoa,", "246426884624", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(2138, 244, "6ff4008f", "Rinoa,Squall,Quistis,", "464268846248", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(2139, 169, "c0a9ff1c", "Irvine,Zell,Rinoa,", "642688462482", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(2140, 196, "3fc45725", "Rinoa,Squall,Selphie,", "426884624828", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(2141, 196, "c4c490fa", "Irvine,Zell,Selphie,", "268846248288", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(2142, 58, "473a16ab", "Zell,Squall,Rinoa,", "688462482884", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(2143, 229, "f9e5f108", "Irvine,Zell,Selphie,", "884624828842", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(2144, 136, "ea8840a1", "Rinoa,Zell,Selphie,", "846248288428", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2145, 58, "3d3ac2c6", "Rinoa,Irvine,Quistis,", "462482884284", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2146, 129, "e4817287", "Zell,Squall,Irvine,", "624828842842", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2147, 109, "976d15b4", "Zell,Squall,Irvine,", "248288428422", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2148, 71, "334745dd", "Selphie,Irvine,Quistis,", "482884284226", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2149, 144, "b2904552", "Rinoa,Zell,Quistis,", "828842842268", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Quistis"),

            new PartyFormation(2150, 248, "6bf8b023", "Rinoa,Zell,Quistis,", "288428422688", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Quistis"),

            new PartyFormation(2151, 159, "dc9fd920", "Irvine,Zell,Rinoa,", "884284226886", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Quistis"),

            new PartyFormation(2152, 247, "b2f762d9", "Selphie,Rinoa,Quistis,", "842842268866", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Quistis"),

            new PartyFormation(2153, 73, "2049649e", "Zell,Squall,Quistis,", "428422688662", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Quistis"),

            new PartyFormation(2154, 28, "0c1c2b7f", "Rinoa,Zell,Selphie,", "284226886628", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Quistis"),

            new PartyFormation(2155, 121, "a079674c", "Irvine,Zell,Quistis,", "842268866282", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(2156, 242, "81f25395", "Irvine,Zell,Rinoa,", "422688662824", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>29}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2157, 227, "a3e32caa", "Rinoa,Squall,Selphie,", "226886628246", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>28}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2158, 210, "b4d2009b", "Irvine,Zell,Rinoa,", "268866282464", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>27}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2159, 123, "cc7bac38", "Rinoa,Zell,Quistis,", "688662824646", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>26}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2160, 113, "2a719411", "Rinoa,Squall,Quistis,", "886628246462", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>25}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2161, 159, "839f6976", "Rinoa,Zell,Quistis,", "866282464626", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>24}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2162, 70, "24460b77", "Selphie,Rinoa,Quistis,", "662824646264", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>23}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2163, 91, "de5b53e4", "Irvine,Squall,Rinoa,", "628246462646", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>22}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2164, 202, "46ca604d", "Irvine,Squall,Quistis,", "282464626464", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>21}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2165, 16, "d610a702", "Rinoa,Zell,Selphie,", "824646264648", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>20}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2166, 133, "e585e813", "Irvine,Zell,Rinoa,", "246462646482", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>19}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2167, 107, "d86bca50", "Zell,Squall,Selphie,", "464626464826", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>18}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2168, 105, "c769b449", "Irvine,Squall,Rinoa,", "646264648262", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>17}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2169, 102, "1666314e", "Rinoa,Squall,Quistis,", "462646482624", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>16}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2170, 220, "9cdcf26f", "Rinoa,Irvine,Quistis,", "626464826248", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>15}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2171, 203, "cccb3b7c", "Rinoa,Zell,Quistis,", "264648262486", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>14}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2172, 144, "9c904c05", "Selphie,Zell,Quistis,", "646482624868", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>13}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2173, 120, "b178145a", "Zell,Squall,Quistis,", "464826248688", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2174, 240, "bdf0468b", "Zell,Squall,Rinoa,", "648262486888", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2175, 78, "ef4e9368", "Rinoa,Squall,Quistis,", "482624868884", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2176, 206, "3fcea381", "Rinoa,Squall,Quistis,", "826248688844", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2177, 147, "57931c26", "Irvine,Squall,Selphie,", "262486888446", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2178, 154, "879ac067", "Irvine,Squall,Quistis,", "624868884464", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2179, 45, "da2d7e14", "Rinoa,Squall,Selphie,", "248688844642", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2180, 64, "5940f6bd", "Zell,Squall,Rinoa,", "486888446428", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2181, 4, "9f04d4b2", "Zell,Squall,Quistis,", "868884464288", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2182, 136, "e188fc03", "Selphie,Rinoa,Quistis,", "688844642888", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2183, 110, "716e6780", "Selphie,Squall,Quistis,", "888446428884", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2184, 139, "7c8b41b9", "Selphie,Zell,Quistis,", "884464288846", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2185, 103, "436789fe", "Selphie,Irvine,Quistis,", "844642888466", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2186, 149, "7795555f", "Irvine,Zell,Quistis,", "446428884662", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(2187, 18, "91127bac", "Irvine,Zell,Selphie,", "464288846624", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>110, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Selphie"),

            new PartyFormation(2188, 149, "b9954075", "Rinoa,Irvine,Selphie,", "642888466242", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>109, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2189, 174, "0dae480a", "Irvine,Zell,Rinoa,", "428884662424", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>108, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2190, 227, "2ee3e87b", "Rinoa,Squall,Selphie,", "288846624246", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>107, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2191, 1, "7201a698", "Selphie,Irvine,Quistis,", "888466242462", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>106, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2192, 6, "7d066ef1", "Zell,Squall,Irvine,", "884662424624", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>105, Selphie,Irvine,Quistis=>84}", "Irvine,Zell,Selphie"),

            new PartyFormation(2193, 240, "30f0dad6", "Zell,Squall,Rinoa,", "846624246248", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>104, Selphie,Irvine,Quistis=>83}", "Irvine,Zell,Selphie"),

            new PartyFormation(2194, 190, "d0be9157", "Selphie,Rinoa,Quistis,", "466242462484", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>103, Selphie,Irvine,Quistis=>82}", "Irvine,Zell,Selphie"),

            new PartyFormation(2195, 182, "71b69444", "Zell,Squall,Rinoa,", "662424624844", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>102, Selphie,Irvine,Quistis=>81}", "Irvine,Zell,Selphie"),

            new PartyFormation(2196, 130, "fc82092d", "Irvine,Squall,Quistis,", "624246248444", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>101, Selphie,Irvine,Quistis=>80}", "Irvine,Zell,Selphie"),

            new PartyFormation(2197, 247, "a7f7ce62", "Rinoa,Zell,Quistis,", "242462484446", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>100, Selphie,Irvine,Quistis=>79}", "Irvine,Zell,Selphie"),

            new PartyFormation(2198, 48, "8730ebf3", "Zell,Squall,Rinoa,", "424624844468", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>99, Selphie,Irvine,Quistis=>78}", "Irvine,Zell,Selphie"),

            new PartyFormation(2199, 170, "a8aab0b0", "Rinoa,Zell,Selphie,", "246248444684", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>98, Selphie,Irvine,Quistis=>77}", "Irvine,Zell,Selphie"),

            new PartyFormation(2200, 163, "2aa30b29", "Selphie,Squall,Quistis,", "462484446846", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>97, Selphie,Irvine,Quistis=>76}", "Irvine,Zell,Selphie"),

            new PartyFormation(2201, 136, "df886eae", "Zell,Squall,Selphie,", "624844468468", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>96, Selphie,Irvine,Quistis=>75}", "Irvine,Zell,Selphie"),

            new PartyFormation(2202, 100, "8764544f", "Zell,Squall,Rinoa,", "248444684688", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>95, Selphie,Irvine,Quistis=>74}", "Irvine,Zell,Selphie"),

            new PartyFormation(2203, 130, "7b8227dc", "Rinoa,Zell,Selphie,", "484446846884", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>94, Selphie,Irvine,Quistis=>73}", "Irvine,Zell,Selphie"),

            new PartyFormation(2204, 184, "eeb830e5", "Irvine,Squall,Rinoa,", "844468468848", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>93, Selphie,Irvine,Quistis=>72}", "Irvine,Zell,Selphie"),

            new PartyFormation(2205, 112, "b970c7ba", "Selphie,Zell,Quistis,", "444684688488", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>92, Selphie,Irvine,Quistis=>71}", "Irvine,Zell,Selphie"),

            new PartyFormation(2206, 187, "05bbe66b", "Zell,Squall,Irvine,", "446846884886", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>91, Selphie,Irvine,Quistis=>70}", "Irvine,Zell,Selphie"),

            new PartyFormation(2207, 247, "12f7e5c8", "Irvine,Squall,Rinoa,", "468468848866", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>90, Selphie,Irvine,Quistis=>69}", "Irvine,Zell,Selphie"),

            new PartyFormation(2208, 63, "1c3ff661", "Rinoa,Squall,Quistis,", "684688488666", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>89, Selphie,Irvine,Quistis=>68}", "Irvine,Zell,Selphie"),

            new PartyFormation(2209, 83, "b453a586", "Rinoa,Squall,Quistis,", "846884886666", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>88, Selphie,Irvine,Quistis=>67}", "Irvine,Zell,Selphie"),

            new PartyFormation(2210, 176, "4fb07e47", "Irvine,Zell,Rinoa,", "468848866668", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>87, Selphie,Irvine,Quistis=>66}", "Irvine,Zell,Selphie"),

            new PartyFormation(2211, 137, "66899674", "Rinoa,Zell,Quistis,", "688488666682", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>86, Selphie,Irvine,Quistis=>65}", "Irvine,Zell,Selphie"),

            new PartyFormation(2212, 36, "6624979d", "Rinoa,Irvine,Quistis,", "884886666828", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>85, Selphie,Irvine,Quistis=>64}", "Irvine,Zell,Selphie"),

            new PartyFormation(2213, 52, "c4349412", "Irvine,Zell,Selphie,", "848866668288", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>84, Selphie,Irvine,Quistis=>63}", "Irvine,Zell,Selphie"),

            new PartyFormation(2214, 108, "a76cb7e3", "Rinoa,Zell,Quistis,", "488666682888", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>83, Selphie,Irvine,Quistis=>62}", "Irvine,Zell,Selphie"),

            new PartyFormation(2215, 227, "45e3a5e0", "Selphie,Squall,Quistis,", "886666828886", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>82, Selphie,Irvine,Quistis=>61}", "Irvine,Zell,Selphie"),

            new PartyFormation(2216, 184, "49b81099", "Rinoa,Irvine,Selphie,", "866668288868", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>81, Selphie,Irvine,Quistis=>60}", "Irvine,Zell,Selphie"),

            new PartyFormation(2217, 195, "27c3df5e", "Zell,Squall,Quistis,", "666682888686", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>80, Selphie,Irvine,Quistis=>59}", "Irvine,Zell,Selphie"),

            new PartyFormation(2218, 40, "3d28ef3f", "Irvine,Squall,Quistis,", "666828886868", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>79, Selphie,Irvine,Quistis=>58}", "Irvine,Zell,Selphie"),

            new PartyFormation(2219, 13, "8d0d400c", "Rinoa,Squall,Quistis,", "668288868682", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>78, Selphie,Irvine,Quistis=>57}", "Irvine,Zell,Selphie"),

            new PartyFormation(2220, 112, "ad701d55", "Zell,Squall,Selphie,", "682888686828", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>77, Selphie,Irvine,Quistis=>56}", "Irvine,Zell,Selphie"),

            new PartyFormation(2221, 106, "466a936a", "Zell,Squall,Quistis,", "828886868284", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>76, Selphie,Irvine,Quistis=>55}", "Irvine,Zell,Selphie"),

            new PartyFormation(2222, 71, "6247405b", "Zell,Squall,Rinoa,", "288868682846", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>75, Selphie,Irvine,Quistis=>54}", "Irvine,Zell,Selphie"),

            new PartyFormation(2223, 84, "6f5450f8", "Selphie,Rinoa,Quistis,", "888686828468", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>74, Selphie,Irvine,Quistis=>53}", "Irvine,Zell,Selphie"),

            new PartyFormation(2224, 98, "af6239d1", "Irvine,Zell,Selphie,", "886868284684", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>73, Selphie,Irvine,Quistis=>52}", "Irvine,Zell,Selphie"),

            new PartyFormation(2225, 22, "63167c36", "Rinoa,Squall,Quistis,", "868682846844", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>72, Selphie,Irvine,Quistis=>51}", "Irvine,Zell,Selphie"),

            new PartyFormation(2226, 47, "d22f8737", "Rinoa,Squall,Quistis,", "686828468446", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>71, Selphie,Irvine,Quistis=>50}", "Irvine,Zell,Selphie"),

            new PartyFormation(2227, 249, "84f984a4", "Irvine,Zell,Rinoa,", "868284684462", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>70, Selphie,Irvine,Quistis=>49}", "Irvine,Zell,Selphie"),

            new PartyFormation(2228, 127, "df7fa20d", "Rinoa,Squall,Quistis,", "682846844626", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>69, Selphie,Irvine,Quistis=>48}", "Irvine,Zell,Selphie"),

            new PartyFormation(2229, 198, "afc625c2", "Rinoa,Zell,Selphie,", "828468446264", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>68, Selphie,Irvine,Quistis=>47}", "Irvine,Zell,Selphie"),

            new PartyFormation(2230, 235, "aceb5fd3", "Rinoa,Squall,Quistis,", "284684462646", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>67, Selphie,Irvine,Quistis=>46}", "Irvine,Zell,Selphie"),

            new PartyFormation(2231, 156, "079c4710", "Irvine,Zell,Rinoa,", "846844626468", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>66, Selphie,Irvine,Quistis=>45}", "Irvine,Zell,Selphie"),

            new PartyFormation(2232, 145, "e1915209", "Zell,Squall,Selphie,", "468446264682", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>65, Selphie,Irvine,Quistis=>44}", "Irvine,Zell,Selphie"),

            new PartyFormation(2233, 212, "0dd4dc0e", "Zell,Squall,Rinoa,", "684462646828", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>64, Selphie,Irvine,Quistis=>43}", "Irvine,Zell,Selphie"),

            new PartyFormation(2234, 130, "7f82262f", "Zell,Squall,Selphie,", "844626468284", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>63, Selphie,Irvine,Quistis=>42}", "Irvine,Zell,Selphie"),

            new PartyFormation(2235, 102, "6966c43c", "Rinoa,Zell,Quistis,", "446264682844", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>62, Selphie,Irvine,Quistis=>41}", "Irvine,Zell,Selphie"),

            new PartyFormation(2236, 244, "32f405c5", "Irvine,Zell,Selphie,", "462646828448", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>61, Selphie,Irvine,Quistis=>40}", "Irvine,Zell,Selphie"),

            new PartyFormation(2237, 6, "8706ab1a", "Selphie,Squall,Quistis,", "626468284484", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>60, Selphie,Irvine,Quistis=>39}", "Irvine,Zell,Selphie"),

            new PartyFormation(2238, 20, "7614f64b", "Irvine,Zell,Rinoa,", "264682844848", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>59, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Selphie"),

            new PartyFormation(2239, 249, "32f9e828", "Rinoa,Zell,Selphie,", "646828448482", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>58, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Selphie"),

            new PartyFormation(2240, 20, "90143941", "Zell,Squall,Rinoa,", "468284484828", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>57, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Selphie"),

            new PartyFormation(2241, 84, "4b545ee6", "Rinoa,Irvine,Quistis,", "682844848288", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>56, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Selphie"),

            new PartyFormation(2242, 186, "93baac27", "Rinoa,Zell,Quistis,", "828448482884", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>55, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Selphie"),

            new PartyFormation(2243, 25, "d4195ed4", "Irvine,Squall,Quistis,", "284484828842", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>54, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Selphie"),

            new PartyFormation(2244, 170, "35aa287d", "Irvine,Squall,Rinoa,", "844848288424", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>53, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Selphie"),

            new PartyFormation(2245, 119, "bf778372", "Rinoa,Irvine,Selphie,", "448482884246", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>52, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Selphie"),

            new PartyFormation(2246, 27, "8c1be3c3", "Irvine,Zell,Selphie,", "484828842466", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>51, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Selphie"),

            new PartyFormation(2247, 23, "d3179440", "Zell,Squall,Quistis,", "848288424666", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>50, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Selphie"),

            new PartyFormation(2248, 181, "f9b5cf79", "Selphie,Squall,Quistis,", "482884246662", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>49, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Selphie"),

            new PartyFormation(2249, 54, "e83664be", "Rinoa,Squall,Quistis,", "828842466624", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>48, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Selphie"),

            new PartyFormation(2250, 206, "9acef91f", "Selphie,Rinoa,Quistis,", "288424666244", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>47, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Selphie"),

            new PartyFormation(2251, 1, "8701b46c", "Rinoa,Squall,Quistis,", "884246662442", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>46, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Selphie"),

            new PartyFormation(2252, 58, "f83aea35", "Irvine,Squall,Selphie,", "842466624424", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>45, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(2253, 112, "3e700eca", "Rinoa,Squall,Selphie,", "424666244248", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>44, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(2254, 116, "7474083b", "Zell,Squall,Rinoa,", "246662442488", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>43, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(2255, 139, "488bab58", "Irvine,Zell,Rinoa,", "466624424886", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>42, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(2256, 188, "4fbcf4b1", "Rinoa,Squall,Quistis,", "666244248868", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>41, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(2257, 232, "b7e84d96", "Irvine,Squall,Quistis,", "662442488688", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>40, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(2258, 144, "2d90ed17", "Rinoa,Squall,Selphie,", "624424886888", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(2259, 188, "c5bc2504", "Selphie,Zell,Quistis,", "244248868888", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(2260, 123, "297b2aed", "Selphie,Squall,Quistis,", "442488688886", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(2261, 211, "90d3ad22", "Irvine,Zell,Rinoa,", "424886888866", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2262, 45, "b32d43b3", "Zell,Squall,Quistis,", "248868888662", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2263, 88, "e4588d70", "Selphie,Squall,Quistis,", "488688886628", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2264, 108, "096c88e9", "Irvine,Zell,Selphie,", "886888866288", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2265, 35, "2223796e", "Rinoa,Zell,Quistis,", "868888662886", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2266, 46, "312e680f", "Zell,Squall,Selphie,", "688886628864", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2267, 17, "5f11109c", "Zell,Squall,Irvine,", "888866288642", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2268, 251, "21fbcaa5", "Rinoa,Zell,Quistis,", "888662886426", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2269, 145, "d091be7a", "Zell,Squall,Quistis,", "886628864262", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2270, 115, "8273762b", "Irvine,Squall,Rinoa,", "866288642626", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2271, 108, "096c9a88", "Selphie,Squall,Quistis,", "662886426268", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2272, 131, "27836c21", "Rinoa,Zell,Quistis,", "628864262686", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2273, 109, "e06d4846", "Zell,Squall,Irvine,", "288642626862", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2274, 177, "86b14a07", "Zell,Squall,Irvine,", "886426268622", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2275, 116, "6674d734", "Irvine,Squall,Quistis,", "864262686228", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2276, 137, "df89a95d", "Selphie,Irvine,Quistis,", "642626862282", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2277, 37, "ba25a2d2", "Zell,Squall,Irvine,", "426268622822", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(2278, 14, "fa0e7fa3", "Zell,Squall,Selphie,", "262686228224", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(2279, 34, "fe2232a0", "Irvine,Squall,Selphie,", "626862282244", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2280, 188, "67bc7e59", "Zell,Squall,Irvine,", "268622822448", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2281, 151, "eb971a1e", "Zell,Squall,Quistis,", "686228224486", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2282, 127, "2a7f72ff", "Irvine,Zell,Selphie,", "862282244866", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2283, 135, "9d87d8cc", "Selphie,Zell,Quistis,", "622822448666", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2284, 173, "f0ada715", "Zell,Squall,Quistis,", "228224486662", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2285, 22, "f216ba2a", "Zell,Squall,Rinoa,", "282244866624", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2286, 226, "a6e2401b", "Zell,Squall,Rinoa,", "822448666244", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2287, 191, "6dbfb5b8", "Irvine,Squall,Quistis,", "224486662446", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2288, 78, "684e9f91", "Rinoa,Irvine,Quistis,", "244866624464", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2289, 62, "993e4ef6", "Zell,Squall,Selphie,", "448666244644", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2290, 218, "c3dac2f7", "Zell,Squall,Irvine,", "486662446444", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2291, 150, "8d967564", "Zell,Squall,Rinoa,", "866624464444", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2292, 44, "502ca3cd", "Irvine,Squall,Selphie,", "666244644448", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2293, 120, "7a786482", "Irvine,Squall,Selphie,", "662446444488", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2294, 110, "926e9793", "Selphie,Irvine,Quistis,", "624464444884", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2295, 247, "99f783d0", "Irvine,Squall,Rinoa,", "244644448846", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(2296, 108, "bb6cafc9", "Zell,Squall,Selphie,", "446444488468", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(2297, 76, "e94c46ce", "Irvine,Zell,Quistis,", "464444884688", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2298, 97, "a46119ef", "Zell,Squall,Selphie,", "644448846882", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2299, 25, "51190cfc", "Selphie,Zell,Quistis,", "444488468822", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2300, 135, "30877f85", "Irvine,Zell,Rinoa,", "444884688226", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(2301, 106, "586a01da", "Rinoa,Irvine,Quistis,", "448846882264", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2302, 79, "ba4f660b", "Rinoa,Zell,Selphie,", "488468822646", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(2303, 103, "3c67fce8", "Rinoa,Squall,Quistis,", "884688226466", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(2304, 197, "eac58f01", "Irvine,Zell,Quistis,", "846882264662", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Quistis"),

            new PartyFormation(2305, 118, "037661a6", "Rinoa,Squall,Selphie,", "468822646624", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2306, 140, "378c57e7", "Selphie,Squall,Quistis,", "688226466248", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2307, 51, "0d33ff94", "Selphie,Irvine,Quistis,", "882264662486", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2308, 123, "b77b1a3d", "Rinoa,Irvine,Selphie,", "822646624866", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2309, 150, "6996f232", "Zell,Squall,Irvine,", "226466248664", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2310, 188, "f7bc8b83", "Selphie,Irvine,Quistis,", "264662486648", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2311, 27, "181b8100", "Irvine,Zell,Selphie,", "646624866486", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>48}", "Irvine,Zell,Selphie"),

            new PartyFormation(2312, 4, "6b041d39", "Rinoa,Irvine,Quistis,", "466248664868", "{Irvine,Zell,Selphie=>50, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>47}", "Irvine,Zell,Quistis"),

            new PartyFormation(2313, 189, "e4bdff7e", "Selphie,Zell,Quistis,", "662486648682", "{Irvine,Zell,Selphie=>49, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>46}", "Irvine,Zell,Quistis"),

            new PartyFormation(2314, 50, "e2325cdf", "Irvine,Squall,Rinoa,", "624866486824", "{Irvine,Zell,Selphie=>48, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>45}", "Irvine,Zell,Quistis"),

            new PartyFormation(2315, 55, "1b37ad2c", "Rinoa,Zell,Quistis,", "248664868246", "{Irvine,Zell,Selphie=>47, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>44}", "Irvine,Zell,Quistis"),

            new PartyFormation(2316, 128, "a98053f5", "Irvine,Zell,Rinoa,", "486648682468", "{Irvine,Zell,Selphie=>46, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>43}", "Irvine,Zell,Quistis"),

            new PartyFormation(2317, 182, "69b6958a", "Irvine,Squall,Rinoa,", "866486824684", "{Irvine,Zell,Selphie=>45, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>42}", "Irvine,Zell,Quistis"),

            new PartyFormation(2318, 9, "5709e7fb", "Irvine,Zell,Quistis,", "664868246842", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>41}", "Irvine,Zell,Quistis"),

            new PartyFormation(2319, 8, "3b087018", "Zell,Squall,Irvine,", "648682468428", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>40}", "Irvine,Zell,Quistis"),

            new PartyFormation(2320, 79, "7f4f3a71", "Rinoa,Squall,Selphie,", "486824684286", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>39}", "Irvine,Zell,Quistis"),

            new PartyFormation(2321, 240, "3cf08056", "Rinoa,Squall,Selphie,", "868246842868", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Quistis"),

            new PartyFormation(2322, 5, "520508d7", "Irvine,Squall,Quistis,", "682468428682", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Quistis"),

            new PartyFormation(2323, 32, "e22075c4", "Irvine,Zell,Quistis,", "824684286828", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Quistis"),

            new PartyFormation(2324, 76, "054c0cad", "Rinoa,Zell,Quistis,", "246842868288", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Quistis"),

            new PartyFormation(2325, 12, "280c4be2", "Selphie,Zell,Quistis,", "468428682888", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Quistis"),

            new PartyFormation(2326, 39, "df275b73", "Irvine,Squall,Rinoa,", "684286828886", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Quistis"),

            new PartyFormation(2327, 145, "ef912a30", "Rinoa,Squall,Quistis,", "842868288862", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Quistis"),

            new PartyFormation(2328, 201, "0cc9c6a9", "Zell,Squall,Selphie,", "428682888622", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Quistis"),

            new PartyFormation(2329, 39, "7c27442e", "Zell,Squall,Quistis,", "286828886226", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(2330, 18, "3d123bcf", "Irvine,Squall,Rinoa,", "868288862264", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Quistis"),

            new PartyFormation(2331, 22, "6016b95c", "Irvine,Squall,Rinoa,", "682888622644", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(2332, 79, "8f4f2465", "Rinoa,Zell,Quistis,", "828886226446", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Quistis"),

            new PartyFormation(2333, 231, "ece7753a", "Selphie,Squall,Quistis,", "288862264466", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Quistis"),

            new PartyFormation(2334, 32, "c920c5eb", "Rinoa,Squall,Quistis,", "888622644668", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(2335, 4, "5e040f48", "Zell,Squall,Selphie,", "886226446688", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(2336, 18, "5e12a1e1", "Irvine,Squall,Selphie,", "862264466884", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(2337, 71, "1047ab06", "Rinoa,Squall,Selphie,", "622644668846", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(2338, 67, "9143d5c7", "Irvine,Squall,Rinoa,", "226446688466", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(2339, 238, "63eed7f4", "Selphie,Squall,Quistis,", "264466884664", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(2340, 54, "4d367b1d", "Selphie,Zell,Quistis,", "644668846644", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(2341, 35, "0f237192", "Rinoa,Irvine,Selphie,", "446688466446", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(2342, 158, "279e0763", "Irvine,Zell,Quistis,", "466884664464", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(2343, 27, "de1b7f60", "Rinoa,Zell,Selphie,", "668846644646", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(2344, 196, "d6c4ac19", "Rinoa,Squall,Selphie,", "688466446468", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(2345, 131, "d28314de", "Rinoa,Irvine,Quistis,", "884664464686", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(2346, 223, "13dfb6bf", "Zell,Squall,Rinoa,", "846644646866", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(2347, 169, "76a9318c", "Selphie,Squall,Quistis,", "466446468662", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(2348, 106, "f16af0d5", "Irvine,Squall,Quistis,", "664464686624", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(2349, 167, "b9a7a0ea", "Selphie,Zell,Quistis,", "644646866246", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2350, 98, "fe62ffdb", "Irvine,Squall,Quistis,", "446468662464", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2351, 125, "f87dda78", "Rinoa,Squall,Quistis,", "464686624642", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2352, 246, "96f6c551", "Zell,Squall,Quistis,", "646866246424", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(2353, 214, "a4d6e1b6", "Irvine,Zell,Rinoa,", "468662464244", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2354, 7, "7107beb7", "Selphie,Squall,Quistis,", "686624642446", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(2355, 242, "74f22624", "Rinoa,Zell,Selphie,", "866246424464", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(2356, 145, "3691658d", "Irvine,Zell,Quistis,", "662464244642", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Quistis"),

            new PartyFormation(2357, 231, "e0e76342", "Zell,Squall,Quistis,", "624642446426", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2358, 207, "c9cf8f53", "Rinoa,Zell,Quistis,", "246424464266", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2359, 61, "183d8090", "Selphie,Irvine,Quistis,", "464244642662", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2360, 187, "0ebbcd89", "Selphie,Irvine,Quistis,", "642446426626", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2361, 140, "3f8c718e", "Rinoa,Irvine,Selphie,", "424464266268", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Selphie"),

            new PartyFormation(2362, 57, "bb39cdaf", "Irvine,Zell,Selphie,", "244642662682", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Selphie"),

            new PartyFormation(2363, 162, "d8a215bc", "Irvine,Zell,Selphie,", "446426626824", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Selphie"),

            new PartyFormation(2364, 10, "2b0ab945", "Irvine,Squall,Selphie,", "464266268244", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Quistis"),

            new PartyFormation(2365, 98, "6862189a", "Zell,Squall,Irvine,", "642662682444", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(2366, 95, "765f95cb", "Zell,Squall,Quistis,", "426626824446", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(2367, 88, "ec58d1a8", "Rinoa,Squall,Selphie,", "266268244468", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(2368, 162, "81a2a4c1", "Rinoa,Irvine,Quistis,", "662682444684", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(2369, 185, "2eb92466", "Irvine,Zell,Rinoa,", "626824446842", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(2370, 207, "5acfc3a7", "Irvine,Squall,Quistis,", "268244468426", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(2371, 61, "b23d6054", "Zell,Squall,Selphie,", "682444684262", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(2372, 115, "6c73cbfd", "Irvine,Zell,Quistis,", "824446842626", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(2373, 35, "782320f2", "Selphie,Squall,Quistis,", "244468426266", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>17}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2374, 42, "c82af343", "Selphie,Zell,Quistis,", "444684262664", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>16}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2375, 58, "793a2dc0", "Rinoa,Squall,Quistis,", "446842626644", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>15}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2376, 54, "7a362af9", "Rinoa,Irvine,Selphie,", "468426266444", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>14}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2377, 190, "ffbe5a3e", "Selphie,Zell,Quistis,", "684262664444", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>13}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2378, 127, "6d7f809f", "Zell,Squall,Quistis,", "842626644446", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2379, 116, "527465ec", "Irvine,Squall,Rinoa,", "426266444468", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2380, 37, "53257db5", "Irvine,Squall,Quistis,", "262664444682", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2381, 65, "0241dc4a", "Selphie,Zell,Quistis,", "626644446822", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2382, 101, "326587bb", "Rinoa,Zell,Quistis,", "266444468222", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2383, 55, "da37f4d8", "Irvine,Squall,Rinoa,", "664444682226", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2384, 125, "2d7d4031", "Rinoa,Zell,Selphie,", "644446822262", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2385, 201, "9ec97316", "Zell,Squall,Irvine,", "444468222622", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2386, 218, "95dae497", "Irvine,Zell,Rinoa,", "444682226224", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2387, 163, "a3a38684", "Rinoa,Squall,Quistis,", "446822262246", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2388, 180, "0db4ae6d", "Rinoa,Irvine,Selphie,", "468222622468", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2389, 97, "7861aaa2", "Irvine,Squall,Selphie,", "682226224682", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2390, 223, "1edf3333", "Selphie,Irvine,Quistis,", "822262246826", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2391, 20, "b31486f0", "Irvine,Squall,Quistis,", "222622468268", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2392, 122, "ce7ac469", "Rinoa,Irvine,Selphie,", "226224682684", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2393, 83, "e453ceee", "Zell,Squall,Quistis,", "262246826846", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2394, 207, "3acfcf8f", "Zell,Squall,Quistis,", "622468268466", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2395, 83, "3353221c", "Zell,Squall,Irvine,", "224682684666", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2396, 114, "ac723e25", "Selphie,Rinoa,Quistis,", "246826846664", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2397, 49, "b131ebfa", "Selphie,Squall,Quistis,", "468268466642", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2398, 131, "a583d5ab", "Selphie,Squall,Quistis,", "682684666426", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2399, 126, "517e4408", "Selphie,Irvine,Quistis,", "826846664264", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2400, 173, "d1ad97a1", "Rinoa,Irvine,Selphie,", "268466642642", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Selphie"),

            new PartyFormation(2401, 162, "52a2cdc6", "Irvine,Squall,Selphie,", "684666426424", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Selphie"),

            new PartyFormation(2402, 40, "37282187", "Rinoa,Irvine,Selphie,", "846664264248", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Selphie"),

            new PartyFormation(2403, 183, "ebb798b4", "Zell,Squall,Irvine,", "466642642486", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Selphie"),

            new PartyFormation(2404, 235, "1ceb0cdd", "Zell,Squall,Quistis,", "666426424866", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Selphie"),

            new PartyFormation(2405, 238, "fdee0052", "Rinoa,Irvine,Selphie,", "664264248664", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Selphie"),

            new PartyFormation(2406, 219, "b3db4f23", "Zell,Squall,Irvine,", "642642486646", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Selphie"),

            new PartyFormation(2407, 143, "7e8f8c20", "Selphie,Squall,Quistis,", "426424866466", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Selphie"),

            new PartyFormation(2408, 144, "209099d9", "Irvine,Zell,Selphie,", "264248664668", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Selphie"),

            new PartyFormation(2409, 71, "0347cf9e", "Zell,Squall,Rinoa,", "642486646686", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(2410, 9, "f909ba7f", "Irvine,Zell,Quistis,", "424866466862", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(2411, 49, "7d314a4c", "Irvine,Squall,Rinoa,", "248664668622", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(2412, 103, "1567fa95", "Rinoa,Squall,Quistis,", "486646686226", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(2413, 221, "6fdd47aa", "Zell,Squall,Quistis,", "866466862262", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(2414, 137, "a4897f9b", "Irvine,Zell,Rinoa,", "664668622622", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(2415, 78, "004ebf38", "Zell,Squall,Selphie,", "646686226224", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(2416, 26, "3d1aab11", "Zell,Squall,Quistis,", "466862262244", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(2417, 160, "c4a03476", "Rinoa,Squall,Selphie,", "668622622448", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(2418, 118, "11767a77", "Irvine,Zell,Selphie,", "686226224484", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(2419, 204, "77cc96e4", "Zell,Squall,Rinoa,", "862262244848", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2420, 109, "f06de74d", "Irvine,Squall,Rinoa,", "622622448482", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2421, 211, "4dd32202", "Zell,Squall,Selphie,", "226224484826", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2422, 206, "46ce4713", "Irvine,Zell,Selphie,", "262244848264", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2423, 46, "cb2e3d50", "Rinoa,Squall,Selphie,", "622448482644", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(2424, 62, "553eab49", "Irvine,Squall,Selphie,", "224484826444", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2425, 85, "67555c4e", "Irvine,Zell,Rinoa,", "244848264442", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2426, 204, "33cc416f", "Irvine,Squall,Rinoa,", "448482644428", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2427, 193, "14c1de7c", "Rinoa,Irvine,Quistis,", "484826444282", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(2428, 61, "783db305", "Irvine,Zell,Quistis,", "848264442822", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2429, 174, "b9aeef5a", "Rinoa,Zell,Quistis,", "482644428224", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2430, 5, "5605858b", "Rinoa,Irvine,Quistis,", "826444282242", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2431, 140, "e38c6668", "Rinoa,Squall,Selphie,", "264442822428", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2432, 107, "466b7a81", "Selphie,Squall,Quistis,", "644428224286", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2433, 220, "3bdca726", "Zell,Squall,Rinoa,", "444282242868", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2434, 68, "a544ef67", "Selphie,Irvine,Quistis,", "442822428688", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2435, 245, "aff58114", "Selphie,Squall,Quistis,", "428224286882", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Quistis"),

            new PartyFormation(2436, 84, "a2543dbd", "Irvine,Squall,Quistis,", "282242868828", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Quistis"),

            new PartyFormation(2437, 220, "85dc0fb2", "Rinoa,Irvine,Quistis,", "822428688288", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Quistis"),

            new PartyFormation(2438, 39, "61271b03", "Rinoa,Irvine,Quistis,", "224286882886", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(2439, 51, "ef339a80", "Irvine,Zell,Rinoa,", "242868828866", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Quistis"),

            new PartyFormation(2440, 11, "910bf8b9", "Selphie,Rinoa,Quistis,", "428688288666", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(2441, 247, "bff774fe", "Zell,Squall,Quistis,", "286882886666", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Quistis"),

            new PartyFormation(2442, 118, "1c76645f", "Irvine,Zell,Rinoa,", "868828866664", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Quistis"),

            new PartyFormation(2443, 119, "f177deac", "Rinoa,Zell,Selphie,", "688288666646", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(2444, 234, "3aea6775", "Rinoa,Squall,Selphie,", "882886666464", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(2445, 209, "3ad1e30a", "Rinoa,Irvine,Selphie,", "828866664642", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(2446, 70, "2246e77b", "Irvine,Squall,Rinoa,", "288666646424", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(2447, 218, "76da3998", "Rinoa,Irvine,Quistis,", "886666464244", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(2448, 7, "3c0705f1", "Zell,Squall,Rinoa,", "866664642446", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(2449, 51, "7c3325d6", "Zell,Squall,Irvine,", "666646424466", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(2450, 210, "10d28057", "Rinoa,Zell,Quistis,", "666464244664", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(2451, 5, "a7055744", "Rinoa,Irvine,Quistis,", "664642446642", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(2452, 117, "8075102d", "Irvine,Zell,Quistis,", "646424466422", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(2453, 147, "4c93c962", "Rinoa,Zell,Selphie,", "464244664226", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2454, 20, "4614caf3", "Zell,Squall,Selphie,", "642446642268", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2455, 162, "d7a2a3b0", "Rinoa,Irvine,Selphie,", "424466422684", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2456, 63, "a83f8229", "Selphie,Squall,Quistis,", "244664226846", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2457, 105, "116919ae", "Rinoa,Squall,Quistis,", "446642268462", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(2458, 39, "7a27234f", "Selphie,Zell,Quistis,", "466422684626", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(2459, 134, "4d864adc", "Irvine,Squall,Selphie,", "664226846264", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(2460, 37, "af2517e5", "Zell,Squall,Quistis,", "642268462642", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(2461, 49, "803122ba", "Rinoa,Irvine,Selphie,", "422684626422", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(2462, 92, "a35ca56b", "Zell,Squall,Irvine,", "226846264228", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(2463, 155, "e49b38c8", "Irvine,Zell,Selphie,", "268462642286", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(2464, 20, "54144d61", "Zell,Squall,Selphie,", "684626422868", "{Irvine,Zell,Selphie=>65, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2465, 62, "763eb086", "Rinoa,Squall,Quistis,", "846264228684", "{Irvine,Zell,Selphie=>64, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2466, 30, "001e2d47", "Rinoa,Zell,Selphie,", "462642286844", "{Irvine,Zell,Selphie=>63, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2467, 143, "4a8f1974", "Rinoa,Zell,Selphie,", "626422868446", "{Irvine,Zell,Selphie=>62, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2468, 103, "7c675e9d", "Selphie,Irvine,Quistis,", "264228684466", "{Irvine,Zell,Selphie=>61, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2469, 69, "81454f12", "Rinoa,Zell,Selphie,", "642286844662", "{Irvine,Zell,Selphie=>60, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>94}", "Irvine,Zell,Quistis"),

            new PartyFormation(2470, 134, "e28656e3", "Zell,Squall,Irvine,", "422868446624", "{Irvine,Zell,Selphie=>59, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>93}", "Irvine,Zell,Quistis"),

            new PartyFormation(2471, 62, "383e58e0", "Irvine,Squall,Selphie,", "228684466244", "{Irvine,Zell,Selphie=>58, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>92}", "Irvine,Zell,Quistis"),

            new PartyFormation(2472, 224, "8ee04799", "Rinoa,Squall,Selphie,", "286844662448", "{Irvine,Zell,Selphie=>57, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>91}", "Irvine,Zell,Quistis"),

            new PartyFormation(2473, 165, "64a54a5e", "Irvine,Zell,Rinoa,", "868446624482", "{Irvine,Zell,Selphie=>56, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>90}", "Irvine,Zell,Quistis"),

            new PartyFormation(2474, 189, "99bd7e3f", "Selphie,Rinoa,Quistis,", "684466244822", "{Irvine,Zell,Selphie=>55, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>89}", "Irvine,Zell,Quistis"),

            new PartyFormation(2475, 224, "d5e0230c", "Rinoa,Irvine,Selphie,", "844662448228", "{Irvine,Zell,Selphie=>54, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>88}", "Irvine,Zell,Quistis"),

            new PartyFormation(2476, 100, "8264c455", "Zell,Squall,Quistis,", "446624482288", "{Irvine,Zell,Selphie=>53, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>87}", "Irvine,Zell,Quistis"),

            new PartyFormation(2477, 119, "a777ae6a", "Rinoa,Irvine,Selphie,", "466244822886", "{Irvine,Zell,Selphie=>52, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>86}", "Irvine,Zell,Quistis"),

            new PartyFormation(2478, 21, "9515bf5b", "Rinoa,Squall,Quistis,", "662448228862", "{Irvine,Zell,Selphie=>51, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>85}", "Irvine,Zell,Quistis"),

            new PartyFormation(2479, 242, "35f263f8", "Zell,Squall,Quistis,", "624482288624", "{Irvine,Zell,Selphie=>50, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>84}", "Irvine,Zell,Quistis"),

            new PartyFormation(2480, 122, "1c7a50d1", "Irvine,Zell,Quistis,", "244822886244", "{Irvine,Zell,Selphie=>49, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>83}", "Irvine,Zell,Quistis"),

            new PartyFormation(2481, 90, "f75a4736", "Rinoa,Squall,Quistis,", "448228862444", "{Irvine,Zell,Selphie=>48, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>82}", "Irvine,Zell,Quistis"),

            new PartyFormation(2482, 230, "9ce6f637", "Zell,Squall,Selphie,", "482288624444", "{Irvine,Zell,Selphie=>47, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>81}", "Irvine,Zell,Quistis"),

            new PartyFormation(2483, 229, "92e5c7a4", "Zell,Squall,Irvine,", "822886244442", "{Irvine,Zell,Selphie=>46, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>80}", "Irvine,Zell,Quistis"),

            new PartyFormation(2484, 130, "9b82290d", "Rinoa,Irvine,Selphie,", "228862444424", "{Irvine,Zell,Selphie=>45, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>79}", "Irvine,Zell,Quistis"),

            new PartyFormation(2485, 251, "ebfba0c2", "Rinoa,Irvine,Quistis,", "288624444246", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>78}", "Irvine,Zell,Quistis"),

            new PartyFormation(2486, 42, "bd2abed3", "Irvine,Squall,Rinoa,", "886244442464", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>77}", "Irvine,Zell,Quistis"),

            new PartyFormation(2487, 137, "bb89ba10", "Rinoa,Squall,Quistis,", "862444424642", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>76}", "Irvine,Zell,Quistis"),

            new PartyFormation(2488, 181, "c8b54909", "Rinoa,Irvine,Quistis,", "624444246422", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>75}", "Irvine,Zell,Quistis"),

            new PartyFormation(2489, 103, "7767070e", "Rinoa,Squall,Selphie,", "244442464226", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>74}", "Irvine,Zell,Quistis"),

            new PartyFormation(2490, 216, "3dd8752f", "Rinoa,Irvine,Quistis,", "444424642268", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>73}", "Irvine,Zell,Quistis"),

            new PartyFormation(2491, 56, "da38673c", "Rinoa,Squall,Quistis,", "444246422688", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>72}", "Irvine,Zell,Quistis"),

            new PartyFormation(2492, 224, "2de06cc5", "Rinoa,Squall,Selphie,", "442464226888", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>71}", "Irvine,Zell,Quistis"),

            new PartyFormation(2493, 16, "0f10861a", "Rinoa,Zell,Quistis,", "424642268888", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>70}", "Irvine,Zell,Quistis"),

            new PartyFormation(2494, 1, "c501354b", "Selphie,Squall,Quistis,", "246422688882", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>69}", "Irvine,Zell,Quistis"),

            new PartyFormation(2495, 194, "82c2bb28", "Zell,Squall,Selphie,", "464226888824", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>68}", "Irvine,Zell,Quistis"),

            new PartyFormation(2496, 224, "eae01041", "Irvine,Squall,Rinoa,", "642268888248", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>67}", "Irvine,Zell,Quistis"),

            new PartyFormation(2497, 160, "59a0e9e6", "Selphie,Zell,Quistis,", "422688882488", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>66}", "Irvine,Zell,Quistis"),

            new PartyFormation(2498, 171, "7eabdb27", "Zell,Squall,Quistis,", "226888824886", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>65}", "Irvine,Zell,Quistis"),

            new PartyFormation(2499, 28, "b31c61d4", "Rinoa,Irvine,Selphie,", "268888248868", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>64}", "Irvine,Zell,Quistis"),

            new PartyFormation(2500, 220, "66dc6f7d", "Selphie,Zell,Quistis,", "688882488688", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>63}", "Irvine,Zell,Quistis"),

            new PartyFormation(2501, 129, "ed81be72", "Zell,Squall,Rinoa,", "888824886882", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>62}", "Irvine,Zell,Quistis"),

            new PartyFormation(2502, 113, "e67102c3", "Selphie,Rinoa,Quistis,", "888248868822", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>61}", "Irvine,Zell,Quistis"),

            new PartyFormation(2503, 199, "32c7c740", "Irvine,Zell,Rinoa,", "882488688226", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>60}", "Irvine,Zell,Quistis"),

            new PartyFormation(2504, 69, "d9458679", "Zell,Squall,Selphie,", "824886882262", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>59}", "Irvine,Zell,Quistis"),

            new PartyFormation(2505, 41, "6c294fbe", "Irvine,Zell,Quistis,", "248868822622", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>58}", "Irvine,Zell,Quistis"),

            new PartyFormation(2506, 215, "8ed7081f", "Zell,Squall,Rinoa,", "488688226226", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>57}", "Irvine,Zell,Quistis"),

            new PartyFormation(2507, 2, "7d02176c", "Rinoa,Irvine,Quistis,", "886882262264", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>56}", "Irvine,Zell,Quistis"),

            new PartyFormation(2508, 143, "668f1135", "Selphie,Squall,Quistis,", "868822622646", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>55}", "Irvine,Zell,Quistis"),

            new PartyFormation(2509, 38, "0626a9ca", "Zell,Squall,Selphie,", "688226226464", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>54}", "Irvine,Zell,Quistis"),

            new PartyFormation(2510, 110, "026e073b", "Selphie,Zell,Quistis,", "882262264644", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>53}", "Irvine,Zell,Quistis"),

            new PartyFormation(2511, 175, "21af3e58", "Rinoa,Zell,Selphie,", "822622646446", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>52}", "Irvine,Zell,Quistis"),

            new PartyFormation(2512, 172, "4cac8bb1", "Irvine,Squall,Selphie,", "226226464468", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>51}", "Irvine,Zell,Quistis"),

            new PartyFormation(2513, 237, "33ed9896", "Zell,Squall,Rinoa,", "262264644682", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>50}", "Irvine,Zell,Quistis"),

            new PartyFormation(2514, 171, "9aabdc17", "Rinoa,Zell,Quistis,", "622646446826", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>49}", "Irvine,Zell,Quistis"),

            new PartyFormation(2515, 5, "4905e804", "Rinoa,Zell,Quistis,", "226464468262", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>48}", "Irvine,Zell,Quistis"),

            new PartyFormation(2516, 77, "5b4d31ed", "Selphie,Zell,Quistis,", "264644682622", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>47}", "Irvine,Zell,Quistis"),

            new PartyFormation(2517, 98, "2f62a822", "Selphie,Zell,Quistis,", "646446826224", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>46}", "Irvine,Zell,Quistis"),

            new PartyFormation(2518, 136, "e88822b3", "Rinoa,Squall,Quistis,", "464468262248", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>45}", "Irvine,Zell,Quistis"),

            new PartyFormation(2519, 251, "c5fb8070", "Selphie,Zell,Quistis,", "644682622486", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>44}", "Irvine,Zell,Quistis"),

            new PartyFormation(2520, 215, "b3d7ffe9", "Rinoa,Irvine,Selphie,", "446826224866", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>43}", "Irvine,Zell,Quistis"),

            new PartyFormation(2521, 39, "7a27246e", "Selphie,Zell,Quistis,", "468262248666", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>42}", "Irvine,Zell,Quistis"),

            new PartyFormation(2522, 216, "0ad8370f", "Rinoa,Zell,Quistis,", "682622486668", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>41}", "Irvine,Zell,Quistis"),

            new PartyFormation(2523, 112, "e370339c", "Irvine,Zell,Quistis,", "826224866688", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>40}", "Irvine,Zell,Quistis"),

            new PartyFormation(2524, 39, "8d27b1a5", "Zell,Squall,Rinoa,", "262248666886", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>39}", "Irvine,Zell,Selphie"),

            new PartyFormation(2525, 165, "7ca5197a", "Rinoa,Squall,Selphie,", "622486668862", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Selphie"),

            new PartyFormation(2526, 107, "0e6b352b", "Rinoa,Irvine,Selphie,", "224866688626", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Selphie"),

            new PartyFormation(2527, 26, "d81aed88", "Rinoa,Irvine,Selphie,", "248666886264", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Selphie"),

            new PartyFormation(2528, 6, "7706c321", "Zell,Squall,Irvine,", "486668862644", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Selphie"),

            new PartyFormation(2529, 219, "09db5346", "Irvine,Zell,Selphie,", "866688626446", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Selphie"),

            new PartyFormation(2530, 229, "33e5f907", "Selphie,Squall,Quistis,", "666886264462", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Quistis"),

            new PartyFormation(2531, 53, "8d355a34", "Zell,Squall,Quistis,", "668862644622", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Quistis"),

            new PartyFormation(2532, 107, "596b705d", "Rinoa,Zell,Quistis,", "688626446226", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Quistis"),

            new PartyFormation(2533, 233, "53e95dd2", "Zell,Squall,Selphie,", "886264462262", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(2534, 95, "b75f1ea3", "Rinoa,Squall,Selphie,", "862644622626", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Quistis"),

            new PartyFormation(2535, 231, "23e7e5a0", "Selphie,Rinoa,Quistis,", "626446226266", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(2536, 115, "2b73b559", "Irvine,Zell,Rinoa,", "264462262666", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Quistis"),

            new PartyFormation(2537, 91, "9d5b851e", "Selphie,Rinoa,Quistis,", "644622626666", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Quistis"),

            new PartyFormation(2538, 187, "75bb01ff", "Rinoa,Irvine,Quistis,", "446226266666", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(2539, 117, "6575bbcc", "Zell,Squall,Irvine,", "462262666662", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(2540, 33, "1e214e15", "Irvine,Squall,Selphie,", "622626666622", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(2541, 54, "b336d52a", "Irvine,Zell,Quistis,", "226266666224", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(2542, 199, "8bc7bf1b", "Rinoa,Irvine,Selphie,", "262666662246", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(2543, 40, "0a28c8b8", "Irvine,Squall,Rinoa,", "626666622468", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(2544, 213, "b6d5b691", "Irvine,Squall,Selphie,", "266666224682", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(2545, 197, "fbc519f6", "Rinoa,Squall,Quistis,", "666662246822", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(2546, 25, "cb1931f7", "Rinoa,Zell,Quistis,", "666622468222", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(2547, 253, "82fdb864", "Irvine,Squall,Selphie,", "666224682222", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(2548, 142, "158e2acd", "Irvine,Squall,Rinoa,", "662246822224", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2549, 32, "a620df82", "Irvine,Squall,Rinoa,", "622468222248", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2550, 164, "a0a4f693", "Rinoa,Squall,Quistis,", "224682222488", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2551, 15, "b20ff6d0", "Rinoa,Zell,Quistis,", "246822224886", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2552, 223, "62dfa6c9", "Irvine,Zell,Selphie,", "468222248866", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(2553, 129, "468171ce", "Zell,Squall,Selphie,", "682222488662", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2554, 30, "c91e68ef", "Irvine,Squall,Selphie,", "822224886624", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2555, 197, "bdc5affc", "Zell,Squall,Irvine,", "222248866242", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2556, 178, "21b2e685", "Zell,Squall,Quistis,", "222488662424", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2557, 70, "eb46dcda", "Rinoa,Zell,Quistis,", "224886624244", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2558, 18, "ef12a50b", "Rinoa,Zell,Selphie,", "248866242444", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2559, 187, "eabbcfe8", "Rinoa,Squall,Selphie,", "488662424446", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2560, 192, "e0c06601", "Rinoa,Irvine,Selphie,", "886624244468", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2561, 197, "76c5eca6", "Rinoa,Squall,Selphie,", "866242444682", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2562, 196, "0ec486e7", "Rinoa,Zell,Selphie,", "662424446828", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2563, 114, "28720294", "Selphie,Irvine,Quistis,", "624244468284", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2564, 204, "87cc613d", "Irvine,Zell,Quistis,", "242444682848", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(2565, 212, "c9d42d32", "Selphie,Zell,Quistis,", "424446828488", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(2566, 200, "3bc8aa83", "Rinoa,Irvine,Selphie,", "244468284888", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(2567, 182, "bcb6b400", "Irvine,Squall,Quistis,", "444682848884", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(2568, 162, "3ca2d439", "Zell,Squall,Irvine,", "446828488844", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(2569, 19, "0b13ea7e", "Selphie,Rinoa,Quistis,", "468284888446", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(2570, 97, "24616bdf", "Selphie,Squall,Quistis,", "682848884462", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2571, 211, "39d3102c", "Selphie,Squall,Quistis,", "828488844626", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2572, 211, "9bd37af5", "Rinoa,Squall,Selphie,", "284888446266", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2573, 0, "1700308a", "Rinoa,Squall,Selphie,", "848884462668", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2574, 154, "6e9ae6fb", "Zell,Squall,Quistis,", "488844626684", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(2575, 119, "ab770318", "Selphie,Squall,Quistis,", "888446266846", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(2576, 45, "c12dd171", "Zell,Squall,Rinoa,", "884462668462", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(2577, 184, "e4b8cb56", "Selphie,Rinoa,Quistis,", "844626684628", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(2578, 38, "cb26f7d7", "Irvine,Squall,Rinoa,", "446266846284", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(2579, 101, "a66538c4", "Selphie,Zell,Quistis,", "462668462842", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(2580, 253, "5bfd13ad", "Zell,Squall,Irvine,", "626684628422", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(2581, 142, "6b8e46e2", "Irvine,Squall,Quistis,", "266846284224", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Selphie"),

            new PartyFormation(2582, 249, "59f93a73", "Rinoa,Zell,Quistis,", "668462842242", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Selphie"),

            new PartyFormation(2583, 223, "a6df1d30", "Rinoa,Irvine,Quistis,", "684628422426", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>2}", "Irvine,Zell,Selphie"),

            new PartyFormation(2584, 4, "cb043da9", "Irvine,Zell,Selphie,", "846284224268", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>1}", "Irvine,Zell,Selphie"),

            new PartyFormation(2585, 77, "554def2e", "Selphie,Irvine,Quistis,", "462842242682", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2586, 163, "bca30acf", "Rinoa,Zell,Quistis,", "628422426826", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2587, 208, "e9d0dc5c", "Rinoa,Irvine,Quistis,", "284224268268", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2588, 58, "fc3a0b65", "Selphie,Squall,Quistis,", "842242682684", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2589, 77, "894dd03a", "Rinoa,Irvine,Selphie,", "422426826842", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2590, 111, "f26f84eb", "Rinoa,Zell,Selphie,", "224268268426", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2591, 189, "acbd6248", "Selphie,Squall,Quistis,", "242682684262", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2592, 68, "8c44f8e1", "Zell,Squall,Selphie,", "426826842628", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2593, 56, "5c38b606", "Irvine,Zell,Rinoa,", "268268426288", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2594, 63, "da3f84c7", "Selphie,Irvine,Quistis,", "682684262886", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2595, 106, "806a5af4", "Irvine,Squall,Selphie,", "826842628864", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(2596, 183, "61b7421d", "Irvine,Squall,Quistis,", "268426288646", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(2597, 154, "f09a2c92", "Zell,Squall,Irvine,", "684262886464", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(2598, 37, "f625a663", "Rinoa,Irvine,Quistis,", "842628864642", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2599, 76, "1a4c3260", "Irvine,Squall,Selphie,", "426288646428", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2600, 10, "c00ae319", "Rinoa,Irvine,Selphie,", "262886464284", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2601, 42, "142a7fde", "Zell,Squall,Quistis,", "628864642844", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(2602, 194, "ccc245bf", "Zell,Squall,Rinoa,", "288646428444", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2603, 178, "d0b2148c", "Irvine,Zell,Rinoa,", "886464284444", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(2604, 93, "8e5d97d5", "Irvine,Zell,Quistis,", "864642844442", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(2605, 218, "a5dabbea", "Irvine,Squall,Selphie,", "646428444424", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2606, 95, "045f7edb", "Rinoa,Squall,Quistis,", "464284444246", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2607, 177, "adb1ed78", "Zell,Squall,Selphie,", "642844442462", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2608, 236, "4decdc51", "Selphie,Irvine,Quistis,", "428444424628", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2609, 160, "50a0acb6", "Zell,Squall,Quistis,", "284444246288", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2610, 205, "13cd2db7", "Irvine,Squall,Selphie,", "844442462882", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2611, 212, "c4d46924", "Irvine,Zell,Rinoa,", "444424628828", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2612, 81, "fc51ec8d", "Zell,Squall,Rinoa,", "444246288282", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2613, 2, "2702de42", "Selphie,Irvine,Quistis,", "442462882824", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2614, 252, "24fcee53", "Selphie,Irvine,Quistis,", "424628828248", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2615, 128, "3780f390", "Zell,Squall,Irvine,", "246288282488", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(2616, 125, "dd7dc489", "Zell,Squall,Rinoa,", "462882824882", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(2617, 100, "6b649c8e", "Irvine,Zell,Selphie,", "628828248828", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(2618, 94, "855e1caf", "Zell,Squall,Quistis,", "288282488284", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2619, 41, "1429b8bc", "Rinoa,Squall,Selphie,", "882824882842", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2620, 117, "e9752045", "Rinoa,Irvine,Selphie,", "828248828422", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2621, 17, "9111f39a", "Irvine,Zell,Selphie,", "282488284222", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2622, 249, "bff9d4cb", "Irvine,Squall,Quistis,", "824882842222", "{Irvine,Zell,Selphie=>105, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(2623, 55, "fc37a4a8", "Rinoa,Irvine,Selphie,", "248828422226", "{Irvine,Zell,Selphie=>104, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2624, 204, "59cc7bc1", "Zell,Squall,Selphie,", "488284222268", "{Irvine,Zell,Selphie=>103, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2625, 11, "420baf66", "Irvine,Zell,Quistis,", "882842222686", "{Irvine,Zell,Selphie=>102, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2626, 78, "3d4ef2a7", "Irvine,Squall,Selphie,", "828422226864", "{Irvine,Zell,Selphie=>101, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2627, 182, "3cb66354", "Selphie,Squall,Quistis,", "284222268644", "{Irvine,Zell,Selphie=>100, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2628, 228, "92e412fd", "Rinoa,Zell,Selphie,", "842222686448", "{Irvine,Zell,Selphie=>99, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2629, 147, "f5935bf2", "Rinoa,Zell,Quistis,", "422226864486", "{Irvine,Zell,Selphie=>98, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2630, 238, "04ee1243", "Zell,Squall,Quistis,", "222268644864", "{Irvine,Zell,Selphie=>97, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2631, 192, "c5c060c0", "Irvine,Zell,Rinoa,", "222686448648", "{Irvine,Zell,Selphie=>96, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2632, 227, "64e3e1f9", "Rinoa,Squall,Selphie,", "226864486486", "{Irvine,Zell,Selphie=>95, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2633, 119, "6377453e", "Selphie,Irvine,Quistis,", "268644864866", "{Irvine,Zell,Selphie=>94, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2634, 213, "fcd58f9f", "Irvine,Zell,Quistis,", "686448648662", "{Irvine,Zell,Selphie=>93, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2635, 170, "2caac8ec", "Irvine,Squall,Quistis,", "864486486624", "{Irvine,Zell,Selphie=>92, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2636, 119, "6077a4b5", "Rinoa,Irvine,Selphie,", "644864866246", "{Irvine,Zell,Selphie=>91, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2637, 30, "e01e774a", "Irvine,Squall,Quistis,", "448648662464", "{Irvine,Zell,Selphie=>90, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2638, 141, "c28d86bb", "Zell,Squall,Selphie,", "486486624642", "{Irvine,Zell,Selphie=>89, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2639, 241, "a4f187d8", "Rinoa,Irvine,Quistis,", "864866246422", "{Irvine,Zell,Selphie=>88, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2640, 74, "bb4ad731", "Zell,Squall,Quistis,", "648662464224", "{Irvine,Zell,Selphie=>87, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2641, 84, "6d54be16", "Selphie,Squall,Quistis,", "486624642248", "{Irvine,Zell,Selphie=>86, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2642, 3, "fa03d397", "Selphie,Irvine,Quistis,", "866246422486", "{Irvine,Zell,Selphie=>85, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2643, 227, "9be34984", "Selphie,Zell,Quistis,", "662464224866", "{Irvine,Zell,Selphie=>84, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2644, 68, "0044b56d", "Zell,Squall,Quistis,", "624642248668", "{Irvine,Zell,Selphie=>83, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2645, 214, "0bd6a5a2", "Zell,Squall,Irvine,", "246422486684", "{Irvine,Zell,Selphie=>82, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2646, 40, "ae281233", "Rinoa,Zell,Selphie,", "464224866848", "{Irvine,Zell,Selphie=>81, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(2647, 13, "630d79f0", "Rinoa,Irvine,Quistis,", "642248668482", "{Irvine,Zell,Selphie=>80, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2648, 132, "87843b69", "Selphie,Squall,Quistis,", "422486684828", "{Irvine,Zell,Selphie=>79, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(2649, 157, "999d79ee", "Irvine,Zell,Quistis,", "224866848282", "{Irvine,Zell,Selphie=>78, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(2650, 71, "1f479e8f", "Irvine,Zell,Quistis,", "248668482826", "{Irvine,Zell,Selphie=>77, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Quistis"),

            new PartyFormation(2651, 104, "1568451c", "Selphie,Zell,Quistis,", "486684828268", "{Irvine,Zell,Selphie=>76, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2652, 28, "721c2525", "Zell,Squall,Rinoa,", "866848282688", "{Irvine,Zell,Selphie=>75, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2653, 235, "48eb46fa", "Selphie,Irvine,Quistis,", "668482826886", "{Irvine,Zell,Selphie=>74, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2654, 41, "1b2994ab", "Irvine,Squall,Selphie,", "684828268862", "{Irvine,Zell,Selphie=>73, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>16}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2655, 66, "a3429708", "Irvine,Squall,Rinoa,", "848282688624", "{Irvine,Zell,Selphie=>72, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>15}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2656, 142, "a58eeea1", "Irvine,Squall,Selphie,", "482826886244", "{Irvine,Zell,Selphie=>71, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>14}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2657, 22, "7c16d8c6", "Zell,Squall,Irvine,", "828268862444", "{Irvine,Zell,Selphie=>70, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>13}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2658, 234, "baead087", "Rinoa,Irvine,Quistis,", "282688624444", "{Irvine,Zell,Selphie=>69, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2659, 238, "b0ee1bb4", "Selphie,Zell,Quistis,", "826886244444", "{Irvine,Zell,Selphie=>68, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2660, 10, "030ad3dd", "Selphie,Squall,Quistis,", "268862444444", "{Irvine,Zell,Selphie=>67, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2661, 23, "9217bb52", "Zell,Squall,Irvine,", "688624444446", "{Irvine,Zell,Selphie=>66, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2662, 153, "2299ee23", "Irvine,Squall,Rinoa,", "886244444462", "{Irvine,Zell,Selphie=>65, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2663, 43, "b42b3f20", "Rinoa,Irvine,Quistis,", "862444444626", "{Irvine,Zell,Selphie=>64, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2664, 101, "d665d0d9", "Selphie,Rinoa,Quistis,", "624444446262", "{Irvine,Zell,Selphie=>63, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2665, 210, "efd23a9e", "Rinoa,Irvine,Selphie,", "244444462624", "{Irvine,Zell,Selphie=>62, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2666, 147, "9e93497f", "Irvine,Squall,Selphie,", "444444626246", "{Irvine,Zell,Selphie=>61, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2667, 85, "7c552d4c", "Zell,Squall,Rinoa,", "444446262462", "{Irvine,Zell,Selphie=>60, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2668, 217, "38d9a195", "Rinoa,Irvine,Selphie,", "444462624622", "{Irvine,Zell,Selphie=>59, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2669, 35, "522362aa", "Irvine,Zell,Rinoa,", "444626246226", "{Irvine,Zell,Selphie=>58, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2670, 156, "3a9cfe9b", "Selphie,Irvine,Quistis,", "446262462268", "{Irvine,Zell,Selphie=>57, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2671, 77, "114dd238", "Irvine,Zell,Rinoa,", "462624622682", "{Irvine,Zell,Selphie=>56, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(2672, 127, "e37fc211", "Irvine,Squall,Rinoa,", "626246226826", "{Irvine,Zell,Selphie=>55, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(2673, 172, "34acff76", "Irvine,Squall,Quistis,", "262462268268", "{Irvine,Zell,Selphie=>54, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(2674, 194, "aec2e977", "Rinoa,Squall,Quistis,", "624622682684", "{Irvine,Zell,Selphie=>53, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(2675, 41, "9529d9e4", "Irvine,Zell,Quistis,", "246226826842", "{Irvine,Zell,Selphie=>52, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2676, 141, "ad8d6e4d", "Irvine,Squall,Rinoa,", "462268268422", "{Irvine,Zell,Selphie=>51, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2677, 97, "d9619d02", "Irvine,Zell,Quistis,", "622682684222", "{Irvine,Zell,Selphie=>50, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2678, 242, "3df2a613", "Selphie,Squall,Quistis,", "226826842224", "{Irvine,Zell,Selphie=>49, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2679, 156, "949cb050", "Zell,Squall,Selphie,", "268268422248", "{Irvine,Zell,Selphie=>48, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2680, 79, "b24fa249", "Zell,Squall,Selphie,", "682684222486", "{Irvine,Zell,Selphie=>47, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2681, 208, "3cd0874e", "Selphie,Squall,Quistis,", "826842224868", "{Irvine,Zell,Selphie=>46, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2682, 87, "e257906f", "Irvine,Squall,Selphie,", "268422248686", "{Irvine,Zell,Selphie=>45, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2683, 36, "f224817c", "Irvine,Squall,Selphie,", "684222486868", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2684, 231, "dae71a05", "Zell,Squall,Rinoa,", "842224868686", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2685, 49, "0331ca5a", "Selphie,Irvine,Quistis,", "422248686862", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2686, 118, "e376c48b", "Zell,Squall,Selphie,", "222486868624", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>52}", "Irvine,Zell,Quistis"),

            new PartyFormation(2687, 246, "57f63968", "Irvine,Squall,Quistis,", "224868686244", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>51}", "Irvine,Zell,Quistis"),

            new PartyFormation(2688, 196, "47c45181", "Rinoa,Irvine,Selphie,", "248686862448", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>50}", "Irvine,Zell,Quistis"),

            new PartyFormation(2689, 50, "2a323226", "Irvine,Squall,Rinoa,", "486868624484", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>49}", "Irvine,Zell,Quistis"),

            new PartyFormation(2690, 11, "b20b1e67", "Rinoa,Zell,Quistis,", "868686244846", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>48}", "Irvine,Zell,Quistis"),

            new PartyFormation(2691, 169, "dca98414", "Irvine,Squall,Quistis,", "686862448462", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>47}", "Irvine,Zell,Quistis"),

            new PartyFormation(2692, 227, "d5e384bd", "Rinoa,Zell,Selphie,", "868624484626", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>46}", "Irvine,Zell,Quistis"),

            new PartyFormation(2693, 127, "0b7f4ab2", "Rinoa,Zell,Quistis,", "686244846266", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>45}", "Irvine,Zell,Quistis"),

            new PartyFormation(2694, 161, "a5a13a03", "Rinoa,Zell,Quistis,", "862448462662", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>44}", "Irvine,Zell,Quistis"),

            new PartyFormation(2695, 164, "46a4cd80", "Zell,Squall,Irvine,", "624484626628", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>43}", "Irvine,Zell,Quistis"),

            new PartyFormation(2696, 200, "bbc8afb9", "Selphie,Rinoa,Quistis,", "244846266288", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>42}", "Irvine,Zell,Quistis"),

            new PartyFormation(2697, 19, "fc135ffe", "Irvine,Squall,Selphie,", "448462662886", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>41}", "Irvine,Zell,Quistis"),

            new PartyFormation(2698, 243, "f7f3735f", "Zell,Squall,Selphie,", "484626628866", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>40}", "Irvine,Zell,Quistis"),

            new PartyFormation(2699, 73, "1a4941ac", "Zell,Squall,Rinoa,", "846266288662", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>39}", "Irvine,Zell,Quistis"),

            new PartyFormation(2700, 59, "fa3b8e75", "Irvine,Zell,Rinoa,", "462662886626", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Quistis"),

            new PartyFormation(2701, 65, "94417e0a", "Selphie,Zell,Quistis,", "626628866262", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Quistis"),

            new PartyFormation(2702, 5, "1a05e67b", "Selphie,Squall,Quistis,", "266288662622", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Quistis"),

            new PartyFormation(2703, 222, "5edecc98", "Selphie,Zell,Quistis,", "662886626224", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Quistis"),

            new PartyFormation(2704, 195, "1cc39cf1", "Rinoa,Squall,Selphie,", "628866262246", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Quistis"),

            new PartyFormation(2705, 129, "6c8170d6", "Irvine,Squall,Selphie,", "288662622462", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Quistis"),

            new PartyFormation(2706, 2, "3f026f57", "Rinoa,Zell,Quistis,", "886626224624", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Quistis"),

            new PartyFormation(2707, 64, "c6401a44", "Rinoa,Squall,Selphie,", "866262246248", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Quistis"),

            new PartyFormation(2708, 228, "85e4172d", "Selphie,Rinoa,Quistis,", "662622462488", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(2709, 251, "dafbc462", "Rinoa,Zell,Quistis,", "626224624886", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Quistis"),

            new PartyFormation(2710, 212, "b8d4a9f3", "Zell,Squall,Irvine,", "262246248868", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(2711, 70, "a34696b0", "Irvine,Zell,Rinoa,", "622462488684", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Quistis"),

            new PartyFormation(2712, 23, "4317f929", "Irvine,Squall,Quistis,", "224624886846", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Quistis"),

            new PartyFormation(2713, 213, "fdd5c4ae", "Irvine,Zell,Quistis,", "246248868462", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(2714, 133, "8285f24f", "Zell,Squall,Selphie,", "462488684622", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(2715, 246, "daf66ddc", "Zell,Squall,Rinoa,", "624886846224", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(2716, 141, "248dfee5", "Irvine,Zell,Quistis,", "248868462242", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(2717, 61, "1e3d7dba", "Selphie,Squall,Quistis,", "488684622422", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(2718, 89, "1459646b", "Rinoa,Squall,Quistis,", "886846224222", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(2719, 106, "bc6a8bc8", "Rinoa,Irvine,Quistis,", "868462242224", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(2720, 164, "94a4a461", "Zell,Squall,Quistis,", "684622422248", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(2721, 53, "3835bb86", "Selphie,Zell,Quistis,", "846224222482", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(2722, 167, "5da7dc47", "Selphie,Rinoa,Quistis,", "462242224826", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(2723, 128, "6b809c74", "Irvine,Squall,Quistis,", "622422248268", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2724, 38, "6b26259d", "Selphie,Rinoa,Quistis,", "224222482684", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2725, 34, "33220a12", "Rinoa,Irvine,Quistis,", "242224826844", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2726, 123, "807bf5e3", "Irvine,Squall,Rinoa,", "422248268446", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2727, 69, "4a450be0", "Irvine,Zell,Selphie,", "222482684462", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(2728, 68, "b8447e99", "Rinoa,Zell,Quistis,", "224826844628", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2729, 18, "1712b55e", "Rinoa,Zell,Quistis,", "248268446284", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2730, 238, "aaee0d3f", "Irvine,Squall,Selphie,", "482684462844", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2731, 31, "8d1f060c", "Selphie,Squall,Quistis,", "826844628446", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2732, 85, "43556b55", "Rinoa,Zell,Quistis,", "268446284462", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2733, 208, "4ad0c96a", "Zell,Squall,Selphie,", "684462844628", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2734, 64, "2a403e5b", "Irvine,Squall,Rinoa,", "844628446288", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2735, 188, "e5bc76f8", "Irvine,Squall,Quistis,", "446284462888", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2736, 78, "394e67d1", "Zell,Squall,Irvine,", "462844628884", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2737, 170, "a6aa1236", "Rinoa,Zell,Quistis,", "628446288844", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2738, 186, "93ba6537", "Selphie,Irvine,Quistis,", "284462888444", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2739, 190, "f0be0aa4", "Irvine,Squall,Selphie,", "844628884444", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>41}", "Irvine,Zell,Selphie"),

            new PartyFormation(2740, 0, "4700b00d", "Irvine,Squall,Quistis,", "446288844448", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>40}", "Irvine,Zell,Selphie"),

            new PartyFormation(2741, 253, "e7fd1bc2", "Irvine,Squall,Rinoa,", "462888444482", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>39}", "Irvine,Zell,Selphie"),

            new PartyFormation(2742, 70, "9f461dd3", "Rinoa,Irvine,Quistis,", "628884444824", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Selphie"),

            new PartyFormation(2743, 35, "d2232d10", "Selphie,Zell,Quistis,", "288844448246", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Selphie"),

            new PartyFormation(2744, 21, "1b154009", "Selphie,Squall,Quistis,", "888444482462", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Selphie"),

            new PartyFormation(2745, 133, "d185320e", "Irvine,Zell,Rinoa,", "884444824622", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Selphie"),

            new PartyFormation(2746, 202, "0fcac42f", "Irvine,Squall,Quistis,", "844448246224", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Selphie"),

            new PartyFormation(2747, 118, "2c760a3c", "Rinoa,Squall,Selphie,", "444482462244", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Selphie"),

            new PartyFormation(2748, 200, "0bc8d3c5", "Rinoa,Zell,Selphie,", "444824622448", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Selphie"),

            new PartyFormation(2749, 102, "0466611a", "Irvine,Zell,Selphie,", "448246224484", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Selphie"),

            new PartyFormation(2750, 73, "c549744b", "Selphie,Zell,Quistis,", "482462244842", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Selphie"),

            new PartyFormation(2751, 183, "5eb78e28", "Irvine,Zell,Selphie,", "824622448426", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Selphie"),

            new PartyFormation(2752, 103, "5c67e741", "Irvine,Zell,Quistis,", "246224484266", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(2753, 249, "5df974e6", "Zell,Squall,Irvine,", "462244842662", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Selphie"),

            new PartyFormation(2754, 185, "d4b90a27", "Rinoa,Zell,Quistis,", "622448426622", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Selphie"),

            new PartyFormation(2755, 11, "b50b64d4", "Zell,Squall,Rinoa,", "224484266226", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Selphie"),

            new PartyFormation(2756, 138, "5e8ab67d", "Irvine,Squall,Quistis,", "244842662264", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(2757, 87, "6657f972", "Rinoa,Squall,Quistis,", "448426622646", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(2758, 162, "41a221c3", "Irvine,Squall,Quistis,", "484266226464", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(2759, 35, "f823fa40", "Rinoa,Squall,Quistis,", "842662264646", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(2760, 17, "6b113d79", "Irvine,Zell,Selphie,", "426622646462", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(2761, 168, "1ba83abe", "Rinoa,Zell,Quistis,", "266226464628", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(2762, 123, "b57b171f", "Rinoa,Irvine,Selphie,", "662264646286", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(2763, 110, "876e7a6c", "Irvine,Zell,Rinoa,", "622646462864", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(2764, 223, "6edf3835", "Irvine,Squall,Selphie,", "226464628646", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(2765, 41, "262944ca", "Selphie,Squall,Quistis,", "264646286462", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(2766, 196, "50c4063b", "Rinoa,Irvine,Quistis,", "646462864628", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(2767, 254, "e9fed158", "Rinoa,Irvine,Selphie,", "464628646284", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(2768, 88, "875822b1", "Rinoa,Squall,Quistis,", "646286462848", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(2769, 254, "40fee396", "Zell,Squall,Quistis,", "462864628484", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(2770, 226, "71e2cb17", "Irvine,Squall,Rinoa,", "628646284844", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2771, 59, "823bab04", "Selphie,Squall,Quistis,", "286462848446", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2772, 155, "ea9b38ed", "Zell,Squall,Selphie,", "864628484466", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2773, 189, "63bda322", "Zell,Squall,Rinoa,", "646284844662", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(2774, 191, "0dbf01b3", "Irvine,Zell,Quistis,", "462848446626", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2775, 74, "d04a7370", "Irvine,Zell,Selphie,", "628484466264", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(2776, 127, "177f76e9", "Rinoa,Irvine,Quistis,", "284844662646", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2777, 182, "f8b6cf6e", "Rinoa,Zell,Selphie,", "848446626464", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2778, 30, "f61e060f", "Selphie,Rinoa,Quistis,", "484466264644", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2779, 59, "6f3b569c", "Selphie,Squall,Quistis,", "844662646446", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2780, 79, "094f98a5", "Selphie,Irvine,Quistis,", "446626464466", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2781, 4, "2c04747a", "Zell,Squall,Quistis,", "466264644668", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(2782, 190, "29bef42b", "Rinoa,Irvine,Selphie,", "662646446684", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(2783, 245, "b8f54088", "Zell,Squall,Selphie,", "626464466842", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2784, 70, "eb461a21", "Irvine,Zell,Selphie,", "264644668424", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2785, 85, "1f555e46", "Irvine,Zell,Rinoa,", "646446684242", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2786, 54, "0a36a807", "Zell,Squall,Rinoa,", "464466842424", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2787, 225, "bce1dd34", "Selphie,Zell,Quistis,", "644668424242", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(2788, 201, "87c9375d", "Irvine,Zell,Rinoa,", "446684242422", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(2789, 121, "8e7918d2", "Rinoa,Squall,Selphie,", "466842424222", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(2790, 139, "138bbda3", "Irvine,Zell,Selphie,", "668424242226", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(2791, 89, "f55998a0", "Zell,Squall,Quistis,", "684242422262", "{Irvine,Zell,Selphie=>77, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(2792, 102, "6f66ec59", "Rinoa,Irvine,Selphie,", "842424222624", "{Irvine,Zell,Selphie=>76, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2793, 171, "30abf01e", "Irvine,Zell,Quistis,", "424242226246", "{Irvine,Zell,Selphie=>75, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(2794, 146, "719290ff", "Rinoa,Irvine,Selphie,", "242422262464", "{Irvine,Zell,Selphie=>74, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2795, 207, "e7cf9ecc", "Selphie,Squall,Quistis,", "424222624646", "{Irvine,Zell,Selphie=>73, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2796, 144, "9390f515", "Zell,Squall,Irvine,", "242226246468", "{Irvine,Zell,Selphie=>72, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2797, 162, "e2a2f02a", "Selphie,Zell,Quistis,", "422262464684", "{Irvine,Zell,Selphie=>71, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2798, 9, "8f093e1b", "Selphie,Irvine,Quistis,", "222624646842", "{Irvine,Zell,Selphie=>70, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2799, 189, "9bbddbb8", "Zell,Squall,Selphie,", "226246468422", "{Irvine,Zell,Selphie=>69, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(2800, 24, "d118cd91", "Zell,Squall,Irvine,", "262464684228", "{Irvine,Zell,Selphie=>68, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(2801, 87, "6557e4f6", "Zell,Squall,Selphie,", "624646842286", "{Irvine,Zell,Selphie=>67, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(2802, 115, "7a73a0f7", "Irvine,Zell,Quistis,", "246468422866", "{Irvine,Zell,Selphie=>66, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(2803, 80, "9450fb64", "Zell,Squall,Quistis,", "464684228668", "{Irvine,Zell,Selphie=>65, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(2804, 107, "a66bb1cd", "Irvine,Squall,Rinoa,", "646842286686", "{Irvine,Zell,Selphie=>64, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(2805, 149, "3d955a82", "Irvine,Squall,Quistis,", "468422866862", "{Irvine,Zell,Selphie=>63, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(2806, 183, "bcb75593", "Rinoa,Irvine,Selphie,", "684228668626", "{Irvine,Zell,Selphie=>62, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(2807, 212, "b8d469d0", "Rinoa,Zell,Selphie,", "842286686268", "{Irvine,Zell,Selphie=>61, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(2808, 142, "118e9dc9", "Rinoa,Irvine,Selphie,", "422866862684", "{Irvine,Zell,Selphie=>60, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(2809, 66, "00429cce", "Irvine,Zell,Rinoa,", "228668626844", "{Irvine,Zell,Selphie=>59, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(2810, 119, "fd77b7ef", "Zell,Squall,Quistis,", "286686268446", "{Irvine,Zell,Selphie=>58, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(2811, 222, "57de52fc", "Irvine,Zell,Rinoa,", "866862684464", "{Irvine,Zell,Selphie=>57, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(2812, 218, "51da4d85", "Rinoa,Squall,Selphie,", "668626844644", "{Irvine,Zell,Selphie=>56, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(2813, 111, "176fb7da", "Irvine,Squall,Rinoa,", "686268446446", "{Irvine,Zell,Selphie=>55, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(2814, 49, "9131e40b", "Zell,Squall,Selphie,", "862684464462", "{Irvine,Zell,Selphie=>54, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2815, 59, "313ba2e8", "Irvine,Squall,Selphie,", "626844644626", "{Irvine,Zell,Selphie=>53, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2816, 119, "09773d01", "Irvine,Squall,Quistis,", "268446446266", "{Irvine,Zell,Selphie=>52, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2817, 33, "cc2177a6", "Rinoa,Zell,Quistis,", "684464462662", "{Irvine,Zell,Selphie=>51, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(2818, 24, "cd18b5e7", "Zell,Squall,Rinoa,", "844644626628", "{Irvine,Zell,Selphie=>50, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2819, 156, "329c0594", "Irvine,Zell,Quistis,", "446446266288", "{Irvine,Zell,Selphie=>49, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(2820, 153, "fa99a83d", "Selphie,Squall,Quistis,", "464462662882", "{Irvine,Zell,Selphie=>48, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(2821, 221, "20dd6832", "Rinoa,Zell,Selphie,", "644626628822", "{Irvine,Zell,Selphie=>47, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Quistis"),

            new PartyFormation(2822, 176, "bcb0c983", "Irvine,Zell,Quistis,", "446266288228", "{Irvine,Zell,Selphie=>46, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>2}", "Irvine,Zell,Quistis"),

            new PartyFormation(2823, 253, "52fde700", "Irvine,Zell,Rinoa,", "462662882282", "{Irvine,Zell,Selphie=>45, Irvine,Zell,Quistis=>48, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2824, 125, "5c7d8b39", "Selphie,Irvine,Quistis,", "626628822822", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>47, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2825, 245, "c8f5d57e", "Zell,Squall,Irvine,", "266288228222", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>46, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2826, 44, "952c7adf", "Rinoa,Squall,Quistis,", "662882282228", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>45, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2827, 218, "b8da732c", "Selphie,Squall,Quistis,", "628822822284", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>44, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2828, 34, "8422a1f5", "Selphie,Zell,Quistis,", "288228222844", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>43, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2829, 149, "4895cb8a", "Zell,Squall,Selphie,", "882282228442", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>42, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2830, 135, "0287e5fb", "Zell,Squall,Selphie,", "822822284426", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>41, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2831, 17, "17119618", "Rinoa,Irvine,Selphie,", "228222844262", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>40, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2832, 200, "5cc86871", "Zell,Squall,Rinoa,", "282228442628", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2833, 141, "098d1656", "Selphie,Irvine,Quistis,", "822284426282", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2834, 100, "2a64e6d7", "Irvine,Squall,Selphie,", "222844262828", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2835, 149, "ec95fbc4", "Rinoa,Zell,Selphie,", "228442628282", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2836, 42, "ec2a1aad", "Rinoa,Squall,Quistis,", "284426282824", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2837, 220, "f0dc41e2", "Selphie,Irvine,Quistis,", "844262828248", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2838, 167, "00a71973", "Zell,Squall,Selphie,", "442628282486", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2839, 217, "12d91030", "Rinoa,Irvine,Selphie,", "426282824862", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2840, 122, "de7ab4a9", "Selphie,Zell,Quistis,", "262828248624", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2841, 0, "c1009a2e", "Irvine,Zell,Rinoa,", "628282486248", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2842, 207, "49cfd9cf", "Selphie,Irvine,Quistis,", "282824862486", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2843, 246, "c6f6ff5c", "Selphie,Zell,Quistis,", "828248624864", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2844, 32, "d620f265", "Rinoa,Zell,Quistis,", "282486248648", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2845, 0, "55002b3a", "Selphie,Zell,Quistis,", "824862486488", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2846, 26, "671a43eb", "Irvine,Squall,Selphie,", "248624864884", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2847, 162, "19a2b548", "Selphie,Zell,Quistis,", "486248648844", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2848, 51, "fb334fe1", "Irvine,Squall,Selphie,", "862486488446", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2849, 53, "8035c106", "Zell,Squall,Rinoa,", "624864884462", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2850, 87, "c85733c7", "Rinoa,Irvine,Selphie,", "248648844626", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2851, 209, "71d1ddf4", "Rinoa,Irvine,Selphie,", "486488446262", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2852, 180, "06b4091d", "Selphie,Irvine,Quistis,", "864884462628", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2853, 220, "1edce792", "Irvine,Squall,Selphie,", "648844626288", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2854, 137, "9f894563", "Zell,Squall,Rinoa,", "488446262882", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2855, 40, "8e28e560", "Irvine,Squall,Quistis,", "884462628828", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2856, 141, "c58d1a19", "Zell,Squall,Rinoa,", "844626288282", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2857, 93, "a35deade", "Irvine,Squall,Selphie,", "446262882822", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2858, 64, "3240d4bf", "Rinoa,Zell,Selphie,", "462628828228", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2859, 38, "3126f78c", "Selphie,Zell,Quistis,", "626288282284", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2860, 76, "cf4c3ed5", "Rinoa,Squall,Quistis,", "262882822848", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2861, 89, "2c59d6ea", "Rinoa,Squall,Selphie,", "628828228482", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2862, 183, "e4b7fddb", "Rinoa,Irvine,Quistis,", "288282284826", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2863, 18, "64120078", "Rinoa,Zell,Quistis,", "882822848264", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2864, 158, "ec9ef351", "Selphie,Irvine,Quistis,", "828228482644", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2865, 118, "ef7677b6", "Zell,Squall,Quistis,", "282284826444", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(2866, 174, "daae9cb7", "Zell,Squall,Quistis,", "822848264444", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(2867, 162, "fca2ac24", "Zell,Squall,Quistis,", "228482644444", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(2868, 142, "698e738d", "Irvine,Zell,Selphie,", "284826444444", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(2869, 234, "84ea5942", "Selphie,Zell,Quistis,", "848264444444", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(2870, 6, "ca064d53", "Zell,Squall,Rinoa,", "482644444444", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(2871, 112, "d1706690", "Irvine,Zell,Quistis,", "826444444448", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(2872, 123, "4f7bbb89", "Zell,Squall,Rinoa,", "264444444486", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(2873, 200, "5fc8c78e", "Irvine,Squall,Rinoa,", "644444444868", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(2874, 30, "5b1e6baf", "Rinoa,Squall,Quistis,", "444444448684", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(2875, 29, "c91d5bbc", "Selphie,Squall,Quistis,", "444444486842", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(2876, 219, "42db8745", "Rinoa,Irvine,Quistis,", "444444868426", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(2877, 13, "7f0dce9a", "Rinoa,Zell,Quistis,", "444448684262", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(2878, 240, "32f013cb", "Rinoa,Irvine,Quistis,", "444486842628", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(2879, 66, "b04277a8", "Irvine,Squall,Selphie,", "444868426284", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2880, 178, "80b252c1", "Rinoa,Zell,Selphie,", "448684262844", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2881, 106, "236a3a66", "Zell,Squall,Irvine,", "486842628444", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2882, 234, "82ea21a7", "Selphie,Squall,Quistis,", "868426284444", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(2883, 27, "821b6654", "Irvine,Zell,Quistis,", "684262844446", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2884, 208, "37d059fd", "Selphie,Zell,Quistis,", "842628444468", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2885, 207, "15cf96f2", "Zell,Squall,Quistis,", "426284444686", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2886, 141, "ba8d3143", "Rinoa,Squall,Quistis,", "262844446862", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2887, 242, "8ff293c0", "Zell,Squall,Quistis,", "628444468624", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2888, 205, "39cd98f9", "Rinoa,Zell,Quistis,", "284444686242", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2889, 188, "cabc303e", "Selphie,Irvine,Quistis,", "844446862428", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2890, 199, "b6c79e9f", "Rinoa,Zell,Quistis,", "444468624286", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(2891, 77, "b34d2bec", "Irvine,Zell,Quistis,", "444686242862", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Quistis"),

            new PartyFormation(2892, 197, "bfc5cbb5", "Rinoa,Irvine,Selphie,", "446862428622", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>105, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2893, 71, "6e47124a", "Selphie,Squall,Quistis,", "468624286226", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>104, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2894, 17, "8b1185bb", "Selphie,Irvine,Quistis,", "686242862262", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>103, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2895, 215, "76d71ad8", "Irvine,Zell,Rinoa,", "862428622626", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>102, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(2896, 212, "bed46e31", "Zell,Squall,Irvine,", "624286226268", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>101, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(2897, 236, "a4ec0916", "Irvine,Squall,Selphie,", "242862262688", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>100, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Selphie"),

            new PartyFormation(2898, 72, "c048c297", "Irvine,Zell,Rinoa,", "428622626888", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>99, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Selphie"),

            new PartyFormation(2899, 15, "e20f0c84", "Rinoa,Irvine,Selphie,", "286226268886", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>98, Selphie,Irvine,Quistis=>2}", "Irvine,Zell,Selphie"),

            new PartyFormation(2900, 80, "0850bc6d", "Irvine,Zell,Selphie,", "862262688868", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>97, Selphie,Irvine,Quistis=>1}", "Irvine,Zell,Selphie"),

            new PartyFormation(2901, 23, "8d17a0a2", "Selphie,Irvine,Quistis,", "622626888686", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>96, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2902, 76, "a54cf133", "Irvine,Squall,Selphie,", "226268886868", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>95, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2903, 178, "53b26cf0", "Selphie,Irvine,Quistis,", "262688868684", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>94, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2904, 201, "31c9b269", "Selphie,Irvine,Quistis,", "626888686842", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>93, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2905, 115, "4d7324ee", "Selphie,Rinoa,Quistis,", "268886868426", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>92, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(2906, 91, "0d5b6d8f", "Rinoa,Zell,Quistis,", "688868684266", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>91, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(2907, 233, "96e9681c", "Rinoa,Zell,Quistis,", "888686842662", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>90, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(2908, 194, "00c20c25", "Rinoa,Zell,Quistis,", "886868426624", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>89, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(2909, 240, "3bf0a1fa", "Zell,Squall,Irvine,", "868684266248", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>88, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(2910, 43, "982b53ab", "Irvine,Zell,Rinoa,", "686842662486", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>87, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(2911, 50, "1f32ea08", "Irvine,Zell,Rinoa,", "868426624864", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>86, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(2912, 44, "d62c45a1", "Selphie,Rinoa,Quistis,", "684266248648", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>85, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2913, 150, "6996e3c6", "Zell,Squall,Selphie,", "842662486484", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>84, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2914, 201, "5fc97f87", "Zell,Squall,Rinoa,", "426624864842", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>83, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2915, 16, "17109eb4", "Irvine,Squall,Rinoa,", "266248648428", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>82, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2916, 166, "55a69add", "Rinoa,Irvine,Selphie,", "662486484284", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>81, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(2917, 13, "1f0d7652", "Irvine,Squall,Quistis,", "624864842842", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>80, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(2918, 52, "a8348d23", "Rinoa,Squall,Selphie,", "248648428428", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>79, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(2919, 114, "ad72f220", "Selphie,Zell,Quistis,", "486484284284", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>78, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(2920, 119, "447707d9", "Zell,Squall,Quistis,", "864842842846", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>77, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(2921, 232, "95e8a59e", "Rinoa,Squall,Quistis,", "648428428468", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>76, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(2922, 184, "ecb8d87f", "Irvine,Zell,Selphie,", "484284284688", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>75, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(2923, 229, "cde5104c", "Zell,Squall,Quistis,", "842842846882", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>74, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2924, 71, "5c474895", "Selphie,Zell,Quistis,", "428428468826", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>73, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2925, 181, "fab57daa", "Selphie,Squall,Quistis,", "284284688262", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>72, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2926, 12, "670c7d9b", "Rinoa,Irvine,Selphie,", "842846882628", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>71, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2927, 120, "2f78e538", "Selphie,Irvine,Quistis,", "428468826288", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>70, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2928, 160, "8da0d911", "Irvine,Zell,Selphie,", "284688262888", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>69, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Selphie"),

            new PartyFormation(2929, 197, "83c5ca76", "Rinoa,Zell,Selphie,", "846882628882", "{Irvine,Zell,Selphie=>72, Irvine,Zell,Quistis=>68, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2930, 43, "ec2b5877", "Rinoa,Squall,Selphie,", "468826288826", "{Irvine,Zell,Selphie=>71, Irvine,Zell,Quistis=>67, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2931, 115, "66731ce4", "Selphie,Irvine,Quistis,", "688262888266", "{Irvine,Zell,Selphie=>70, Irvine,Zell,Quistis=>66, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2932, 40, "ee28f54d", "Irvine,Squall,Rinoa,", "882628882668", "{Irvine,Zell,Selphie=>69, Irvine,Zell,Quistis=>65, Selphie,Irvine,Quistis=>29}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2933, 188, "28bc1802", "Irvine,Squall,Selphie,", "826288826688", "{Irvine,Zell,Selphie=>68, Irvine,Zell,Quistis=>64, Selphie,Irvine,Quistis=>28}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2934, 243, "baf30513", "Rinoa,Squall,Selphie,", "262888266886", "{Irvine,Zell,Selphie=>67, Irvine,Zell,Quistis=>63, Selphie,Irvine,Quistis=>27}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2935, 183, "64b72350", "Rinoa,Squall,Selphie,", "628882668866", "{Irvine,Zell,Selphie=>66, Irvine,Zell,Quistis=>62, Selphie,Irvine,Quistis=>26}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2936, 156, "4e9c9949", "Selphie,Zell,Quistis,", "288826688668", "{Irvine,Zell,Selphie=>65, Irvine,Zell,Quistis=>61, Selphie,Irvine,Quistis=>25}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2937, 215, "46d7b24e", "Irvine,Squall,Selphie,", "888266886686", "{Irvine,Zell,Selphie=>64, Irvine,Zell,Quistis=>60, Selphie,Irvine,Quistis=>24}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2938, 126, "987edf6f", "Selphie,Rinoa,Quistis,", "882668866864", "{Irvine,Zell,Selphie=>63, Irvine,Zell,Quistis=>59, Selphie,Irvine,Quistis=>23}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2939, 243, "94f3247c", "Rinoa,Irvine,Quistis,", "826688668646", "{Irvine,Zell,Selphie=>62, Irvine,Zell,Quistis=>58, Selphie,Irvine,Quistis=>22}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2940, 140, "348c8105", "Zell,Squall,Irvine,", "266886686468", "{Irvine,Zell,Selphie=>61, Irvine,Zell,Quistis=>57, Selphie,Irvine,Quistis=>21}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2941, 0, "3e00a55a", "Rinoa,Zell,Quistis,", "668866864688", "{Irvine,Zell,Selphie=>60, Irvine,Zell,Quistis=>56, Selphie,Irvine,Quistis=>20}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2942, 68, "5644038b", "Selphie,Zell,Quistis,", "688668646888", "{Irvine,Zell,Selphie=>59, Irvine,Zell,Quistis=>55, Selphie,Irvine,Quistis=>19}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2943, 140, "7c8c0c68", "Irvine,Squall,Selphie,", "886686468888", "{Irvine,Zell,Selphie=>58, Irvine,Zell,Quistis=>54, Selphie,Irvine,Quistis=>18}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2944, 217, "b3d92881", "Selphie,Squall,Quistis,", "866864688882", "{Irvine,Zell,Selphie=>57, Irvine,Zell,Quistis=>53, Selphie,Irvine,Quistis=>17}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2945, 147, "d293bd26", "Selphie,Zell,Quistis,", "668646888826", "{Irvine,Zell,Selphie=>56, Irvine,Zell,Quistis=>52, Selphie,Irvine,Quistis=>16}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2946, 237, "9ded4d67", "Rinoa,Zell,Selphie,", "686468888262", "{Irvine,Zell,Selphie=>55, Irvine,Zell,Quistis=>51, Selphie,Irvine,Quistis=>15}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2947, 73, "90498714", "Rinoa,Irvine,Quistis,", "864688882622", "{Irvine,Zell,Selphie=>54, Irvine,Zell,Quistis=>50, Selphie,Irvine,Quistis=>14}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2948, 238, "63eecbbd", "Zell,Squall,Irvine,", "646888826224", "{Irvine,Zell,Selphie=>53, Irvine,Zell,Quistis=>49, Selphie,Irvine,Quistis=>13}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2949, 238, "dfee85b2", "Rinoa,Zell,Selphie,", "468888262244", "{Irvine,Zell,Selphie=>52, Irvine,Zell,Quistis=>48, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2950, 247, "9ef75903", "Irvine,Zell,Rinoa,", "688882622446", "{Irvine,Zell,Selphie=>51, Irvine,Zell,Quistis=>47, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2951, 194, "a7c20080", "Selphie,Rinoa,Quistis,", "888826224464", "{Irvine,Zell,Selphie=>50, Irvine,Zell,Quistis=>46, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2952, 193, "6cc166b9", "Selphie,Zell,Quistis,", "888262244642", "{Irvine,Zell,Selphie=>49, Irvine,Zell,Quistis=>45, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2953, 187, "a7bb4afe", "Irvine,Squall,Rinoa,", "882622446426", "{Irvine,Zell,Selphie=>48, Irvine,Zell,Quistis=>44, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2954, 12, "fa0c825f", "Rinoa,Squall,Quistis,", "826224464268", "{Irvine,Zell,Selphie=>47, Irvine,Zell,Quistis=>43, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2955, 134, "3b86a4ac", "Rinoa,Zell,Selphie,", "262244642684", "{Irvine,Zell,Selphie=>46, Irvine,Zell,Quistis=>42, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2956, 136, "6788b575", "Zell,Squall,Quistis,", "622446426848", "{Irvine,Zell,Selphie=>45, Irvine,Zell,Quistis=>41, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2957, 253, "c9fd190a", "Irvine,Squall,Quistis,", "224464268482", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>40, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2958, 32, "0620e57b", "Zell,Squall,Selphie,", "244642684828", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2959, 15, "5a0f5f98", "Rinoa,Zell,Selphie,", "446426848286", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2960, 60, "8f3c33f1", "Zell,Squall,Irvine,", "464268482868", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2961, 219, "b1dbbbd6", "Selphie,Irvine,Quistis,", "642684828686", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2962, 78, "4b4e5e57", "Rinoa,Irvine,Selphie,", "426848286864", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>50}", "Irvine,Zell,Quistis"),

            new PartyFormation(2963, 102, "ff66dd44", "Rinoa,Zell,Selphie,", "268482868644", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>49}", "Irvine,Zell,Quistis"),

            new PartyFormation(2964, 207, "7ccf1e2d", "Rinoa,Squall,Selphie,", "684828686446", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>48}", "Irvine,Zell,Quistis"),

            new PartyFormation(2965, 47, "032fbf62", "Rinoa,Irvine,Quistis,", "848286864466", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>47}", "Irvine,Zell,Quistis"),

            new PartyFormation(2966, 112, "cf7088f3", "Rinoa,Irvine,Quistis,", "482868644668", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>46}", "Irvine,Zell,Quistis"),

            new PartyFormation(2967, 150, "3b9689b0", "Rinoa,Zell,Selphie,", "828686446684", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>45}", "Irvine,Zell,Quistis"),

            new PartyFormation(2968, 44, "6b2c7029", "Selphie,Rinoa,Quistis,", "286864466848", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>44}", "Irvine,Zell,Quistis"),

            new PartyFormation(2969, 206, "54ce6fae", "Rinoa,Zell,Selphie,", "868644668484", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>43}", "Irvine,Zell,Quistis"),

            new PartyFormation(2970, 128, "9080c14f", "Zell,Squall,Quistis,", "686446684848", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>42}", "Irvine,Zell,Quistis"),

            new PartyFormation(2971, 210, "53d290dc", "Zell,Squall,Rinoa,", "864466848484", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>41}", "Irvine,Zell,Quistis"),

            new PartyFormation(2972, 242, "bef2e5e5", "Rinoa,Zell,Selphie,", "644668484844", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>40}", "Irvine,Zell,Quistis"),

            new PartyFormation(2973, 149, "4395d8ba", "Rinoa,Zell,Quistis,", "446684848442", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>39}", "Irvine,Zell,Quistis"),

            new PartyFormation(2974, 178, "48b2236b", "Irvine,Squall,Selphie,", "466848484424", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Quistis"),

            new PartyFormation(2975, 101, "ca65dec8", "Zell,Squall,Quistis,", "668484844242", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Quistis"),

            new PartyFormation(2976, 240, "4df0fb61", "Selphie,Squall,Quistis,", "684848442428", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Quistis"),

            new PartyFormation(2977, 56, "aa38c686", "Selphie,Squall,Quistis,", "848484424288", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Quistis"),

            new PartyFormation(2978, 77, "584d8b47", "Selphie,Squall,Quistis,", "484844242882", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Quistis"),

            new PartyFormation(2979, 94, "f95e1f74", "Rinoa,Zell,Quistis,", "848442428824", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Quistis"),

            new PartyFormation(2980, 96, "a260ec9d", "Zell,Squall,Selphie,", "484424288248", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Quistis"),

            new PartyFormation(2981, 202, "89cac512", "Irvine,Squall,Rinoa,", "844242882484", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Quistis"),

            new PartyFormation(2982, 77, "714d94e3", "Rinoa,Squall,Selphie,", "442428824842", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(2983, 247, "abf7bee0", "Rinoa,Squall,Selphie,", "424288248426", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Quistis"),

            new PartyFormation(2984, 228, "35e4b599", "Rinoa,Irvine,Quistis,", "242882484268", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(2985, 12, "ef0c205e", "Rinoa,Irvine,Selphie,", "428824842688", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Quistis"),

            new PartyFormation(2986, 186, "60ba9c3f", "Irvine,Squall,Selphie,", "288248426884", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Quistis"),

            new PartyFormation(2987, 201, "e2c9e90c", "Rinoa,Squall,Selphie,", "882484268842", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(2988, 66, "60421255", "Rinoa,Irvine,Selphie,", "824842688424", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(2989, 117, "e075e46a", "Selphie,Rinoa,Quistis,", "248426884242", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(2990, 198, "11c6bd5b", "Rinoa,Squall,Quistis,", "484268842424", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(2991, 178, "aeb289f8", "Rinoa,Squall,Quistis,", "842688424244", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(2992, 222, "75de7ed1", "Rinoa,Zell,Selphie,", "426884242444", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(2993, 5, "2105dd36", "Rinoa,Squall,Quistis,", "268842424442", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(2994, 169, "a6a9d437", "Selphie,Rinoa,Quistis,", "688424244422", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(2995, 130, "ce824da4", "Irvine,Squall,Selphie,", "884242444224", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(2996, 251, "51fb370d", "Rinoa,Irvine,Selphie,", "842424442246", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(2997, 202, "53ca96c2", "Irvine,Zell,Quistis,", "424244422464", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(2998, 61, "433d7cd3", "Selphie,Squall,Quistis,", "242444224642", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(2999, 104, "7b68a010", "Irvine,Zell,Quistis,", "424442246428", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(3000, 177, "48b13709", "Rinoa,Irvine,Selphie,", "244422464282", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(3001, 47, "cc2f5d0e", "Irvine,Zell,Selphie,", "444224642826", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(3002, 89, "e559132f", "Selphie,Squall,Quistis,", "442246428262", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(3003, 31, "901fad3c", "Irvine,Zell,Selphie,", "422464282626", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(3004, 173, "3cad3ac5", "Irvine,Zell,Rinoa,", "224642826262", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(3005, 8, "17083c1a", "Zell,Squall,Irvine,", "246428262628", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(3006, 237, "66edb34b", "Irvine,Zell,Selphie,", "464282626282", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(3007, 216, "f6d86128", "Selphie,Rinoa,Quistis,", "642826262828", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(3008, 171, "54abbe41", "Rinoa,Squall,Selphie,", "428262628286", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(3009, 93, "085dffe6", "Irvine,Zell,Quistis,", "282626282862", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Quistis"),

            new PartyFormation(3010, 226, "85e23927", "Selphie,Squall,Quistis,", "826262828624", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3011, 230, "09e667d4", "Zell,Squall,Rinoa,", "262628286244", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3012, 180, "8cb4fd7d", "Selphie,Irvine,Quistis,", "626282862448", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3013, 250, "d9fa3472", "Selphie,Irvine,Quistis,", "262828624484", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3014, 175, "8daf40c3", "Irvine,Zell,Selphie,", "628286244846", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3015, 44, "532c2d40", "Selphie,Zell,Quistis,", "282862448468", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(3016, 24, "1f18f479", "Rinoa,Irvine,Selphie,", "828624484688", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(3017, 179, "a6b325be", "Irvine,Zell,Quistis,", "286244846886", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(3018, 187, "febb261f", "Irvine,Squall,Selphie,", "862448468866", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>56, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(3019, 70, "d646dd6c", "Selphie,Squall,Quistis,", "624484688664", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>55, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(3020, 43, "812b5f35", "Irvine,Zell,Selphie,", "244846886646", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>54, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(3021, 119, "4e77dfca", "Rinoa,Squall,Quistis,", "448468866466", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>53, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3022, 118, "4f76053b", "Rinoa,Squall,Selphie,", "484688664664", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>52, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3023, 122, "d17a6458", "Selphie,Rinoa,Quistis,", "846886646644", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>51, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3024, 191, "6fbfb9b1", "Rinoa,Irvine,Quistis,", "468866466446", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>50, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3025, 28, "8f1c2e96", "Rinoa,Zell,Selphie,", "688664664468", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>49, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3026, 53, "a335ba17", "Rinoa,Irvine,Quistis,", "886646644682", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>48, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3027, 93, "a15d6e04", "Selphie,Irvine,Quistis,", "866466446822", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>47, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3028, 101, "47653fed", "Irvine,Zell,Rinoa,", "664664468222", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>46, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3029, 228, "dde49e22", "Irvine,Zell,Rinoa,", "646644682228", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>45, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3030, 209, "12d1e0b3", "Rinoa,Zell,Selphie,", "466446822282", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>44, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3031, 69, "33456670", "Rinoa,Irvine,Quistis,", "664468222822", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>43, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3032, 98, "a462ede9", "Rinoa,Zell,Selphie,", "644682228224", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>42, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3033, 210, "4dd27a6e", "Rinoa,Squall,Quistis,", "446822282244", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>41, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3034, 255, "e2ffd50f", "Selphie,Irvine,Quistis,", "468222822446", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>40, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3035, 114, "3272799c", "Irvine,Zell,Selphie,", "682228224464", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3036, 115, "06737fa5", "Rinoa,Squall,Selphie,", "822282244646", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(3037, 175, "8eafcf7a", "Irvine,Zell,Selphie,", "222822446466", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(3038, 110, "c46eb32b", "Irvine,Squall,Selphie,", "228224464664", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3039, 251, "dbfb9388", "Rinoa,Squall,Quistis,", "282244646646", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3040, 65, "f4417121", "Selphie,Squall,Quistis,", "822446466462", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3041, 219, "d0db6946", "Rinoa,Irvine,Selphie,", "224464664626", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3042, 163, "f9a35707", "Rinoa,Irvine,Selphie,", "244646646266", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3043, 122, "257a6034", "Zell,Squall,Selphie,", "446466462664", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3044, 162, "daa2fe5d", "Rinoa,Squall,Quistis,", "464664626644", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3045, 212, "19d4d3d2", "Rinoa,Zell,Quistis,", "646646266448", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3046, 148, "fe945ca3", "Rinoa,Zell,Selphie,", "466462664488", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3047, 119, "a2774ba0", "Rinoa,Irvine,Selphie,", "664626644886", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3048, 150, "a3962359", "Selphie,Irvine,Quistis,", "646266448864", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3049, 136, "55885b1e", "Zell,Squall,Quistis,", "462664488648", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(3050, 6, "0e061fff", "Selphie,Squall,Quistis,", "626644886484", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(3051, 149, "549581cc", "Zell,Squall,Quistis,", "266448864842", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3052, 252, "c0fc9c15", "Irvine,Squall,Rinoa,", "664488648428", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(3053, 91, "305b0b2a", "Irvine,Zell,Selphie,", "644886484286", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(3054, 166, "a0a6bd1b", "Irvine,Zell,Rinoa,", "448864842864", "{Irvine,Zell,Selphie=>54, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3055, 126, "527eeeb8", "Zell,Squall,Irvine,", "488648428644", "{Irvine,Zell,Selphie=>53, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3056, 23, "2717e491", "Selphie,Rinoa,Quistis,", "886484286446", "{Irvine,Zell,Selphie=>52, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3057, 246, "85f6aff6", "Zell,Squall,Selphie,", "864842864464", "{Irvine,Zell,Selphie=>51, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3058, 234, "c1ea0ff7", "Rinoa,Zell,Selphie,", "648428644644", "{Irvine,Zell,Selphie=>50, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3059, 144, "f1903e64", "Rinoa,Irvine,Quistis,", "484286446448", "{Irvine,Zell,Selphie=>49, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3060, 197, "72c538cd", "Irvine,Squall,Rinoa,", "842864464482", "{Irvine,Zell,Selphie=>48, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3061, 213, "f0d5d582", "Irvine,Zell,Rinoa,", "428644644822", "{Irvine,Zell,Selphie=>47, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3062, 165, "d6a5b493", "Zell,Squall,Selphie,", "286446448222", "{Irvine,Zell,Selphie=>46, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3063, 68, "de44dcd0", "Zell,Squall,Quistis,", "864464482228", "{Irvine,Zell,Selphie=>45, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3064, 121, "377994c9", "Selphie,Irvine,Quistis,", "644644822282", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3065, 143, "c68fc7ce", "Selphie,Zell,Quistis,", "446448222826", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(3066, 109, "316d06ef", "Rinoa,Zell,Selphie,", "464482228262", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(3067, 98, "4f62f5fc", "Irvine,Squall,Selphie,", "644822282624", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(3068, 253, "30fdb485", "Zell,Squall,Selphie,", "448222826242", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(3069, 228, "8ce492da", "Rinoa,Squall,Selphie,", "482228262428", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(3070, 173, "90ad230b", "Zell,Squall,Irvine,", "822282624282", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(3071, 231, "3fe775e8", "Irvine,Squall,Rinoa,", "222826242826", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(3072, 234, "d4ea1401", "Zell,Squall,Selphie,", "228262428264", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(3073, 137, "b38902a6", "Rinoa,Squall,Quistis,", "282624282642", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(3074, 136, "6288e4e7", "Irvine,Zell,Quistis,", "826242826428", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(3075, 178, "5bb20894", "Zell,Squall,Rinoa,", "262428264284", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(3076, 226, "7fe2ef3d", "Irvine,Squall,Quistis,", "624282642844", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(3077, 178, "1eb2a332", "Rinoa,Zell,Selphie,", "242826428444", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(3078, 116, "6a74e883", "Rinoa,Squall,Selphie,", "428264284448", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Quistis"),

            new PartyFormation(3079, 241, "0af11a00", "Irvine,Squall,Selphie,", "282642844482", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>2}", "Irvine,Zell,Quistis"),

            new PartyFormation(3080, 148, "3a944239", "Irvine,Zell,Quistis,", "826428444828", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>1}", "Irvine,Zell,Quistis"),

            new PartyFormation(3081, 99, "ce63c07e", "Selphie,Irvine,Quistis,", "264284448286", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3082, 147, "249389df", "Zell,Squall,Irvine,", "642844482866", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(3083, 77, "c84dd62c", "Rinoa,Zell,Selphie,", "428444828662", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(3084, 109, "d26dc8f5", "Rinoa,Zell,Quistis,", "284448286622", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(3085, 119, "ae77668a", "Selphie,Squall,Quistis,", "844482866226", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(3086, 208, "02d0e4fb", "Selphie,Squall,Quistis,", "444828662268", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(3087, 216, "add82918", "Irvine,Squall,Rinoa,", "448286622688", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(3088, 30, "c21eff71", "Irvine,Squall,Quistis,", "482866226884", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(3089, 109, "5b6d6156", "Irvine,Squall,Selphie,", "828662268842", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(3090, 190, "5fbed5d7", "Selphie,Squall,Quistis,", "286622688424", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(3091, 178, "e4b2bec4", "Irvine,Squall,Quistis,", "866226884244", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(3092, 211, "25d321ad", "Rinoa,Irvine,Selphie,", "662268842446", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(3093, 246, "67f63ce2", "Irvine,Zell,Quistis,", "622688424464", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(3094, 48, "c330f873", "Rinoa,Squall,Quistis,", "226884244648", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>48, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3095, 127, "637f0330", "Irvine,Squall,Rinoa,", "268842446486", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>47, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3096, 45, "b72d2ba9", "Rinoa,Irvine,Selphie,", "688424464862", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>46, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3097, 63, "6f3f452e", "Zell,Squall,Irvine,", "884244648626", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>45, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3098, 152, "d498a8cf", "Rinoa,Irvine,Selphie,", "842446486268", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>44, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3099, 137, "2789225c", "Selphie,Irvine,Quistis,", "424464862682", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>43, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3100, 3, "8d03d965", "Irvine,Zell,Rinoa,", "244648626826", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>42, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3101, 254, "fffe863a", "Irvine,Squall,Quistis,", "446486268264", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>41, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3102, 33, "172102eb", "Rinoa,Squall,Selphie,", "464862682642", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>40, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3103, 180, "d4b40848", "Zell,Squall,Rinoa,", "648626826428", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3104, 221, "1adda6e1", "Rinoa,Zell,Quistis,", "486268264282", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3105, 62, "2c3ecc06", "Selphie,Irvine,Quistis,", "862682642824", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3106, 138, "4b8ae2c7", "Rinoa,Irvine,Quistis,", "626826428244", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Selphie"),

            new PartyFormation(3107, 37, "682560f4", "Zell,Squall,Selphie,", "268264282442", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Selphie"),

            new PartyFormation(3108, 44, "ac2cd01d", "Irvine,Zell,Selphie,", "682642824428", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Selphie"),

            new PartyFormation(3109, 235, "49eba292", "Rinoa,Zell,Selphie,", "826428244286", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Selphie"),

            new PartyFormation(3110, 200, "13c8e463", "Zell,Squall,Selphie,", "264282442868", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Selphie"),

            new PartyFormation(3111, 177, "69b19860", "Rinoa,Irvine,Selphie,", "642824428682", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Selphie"),

            new PartyFormation(3112, 75, "574b5119", "Zell,Squall,Selphie,", "428244286826", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Selphie"),

            new PartyFormation(3113, 29, "301d55de", "Irvine,Squall,Selphie,", "282442868262", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Selphie"),

            new PartyFormation(3114, 91, "345b63bf", "Zell,Squall,Irvine,", "824428682626", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Selphie"),

            new PartyFormation(3115, 7, "c807da8c", "Irvine,Squall,Selphie,", "244286826266", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Selphie"),

            new PartyFormation(3116, 54, "2436e5d5", "Rinoa,Irvine,Selphie,", "442868262664", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(3117, 36, "fd24f1ea", "Zell,Squall,Irvine,", "428682626648", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(3118, 108, "8f6c7cdb", "Rinoa,Irvine,Selphie,", "286826266488", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(3119, 158, "4b9e1378", "Rinoa,Squall,Selphie,", "868262664884", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(3120, 13, "e30d0a51", "Irvine,Squall,Selphie,", "682626648842", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(3121, 88, "315842b6", "Irvine,Zell,Rinoa,", "826266488428", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(3122, 172, "b5ac0bb7", "Irvine,Squall,Quistis,", "262664884288", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(3123, 92, "4c5cef24", "Irvine,Zell,Rinoa,", "626648842888", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(3124, 70, "ee46fa8d", "Zell,Squall,Selphie,", "266488428884", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(3125, 157, "aa9dd442", "Selphie,Zell,Quistis,", "664884288842", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(3126, 235, "a8ebac53", "Zell,Squall,Selphie,", "648842888426", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(3127, 11, "160bd990", "Rinoa,Zell,Quistis,", "488428884266", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3128, 181, "d4b5b289", "Selphie,Zell,Quistis,", "884288842662", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(3129, 184, "ccb8f28e", "Rinoa,Zell,Selphie,", "842888426628", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(3130, 122, "2c7abaaf", "Rinoa,Squall,Selphie,", "428884266284", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(3131, 124, "277cfebc", "Selphie,Zell,Quistis,", "288842662848", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(3132, 61, "a73dee45", "Irvine,Zell,Rinoa,", "888426628482", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(3133, 85, "e255a99a", "Selphie,Squall,Quistis,", "884266284822", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(3134, 66, "bf4252cb", "Rinoa,Irvine,Quistis,", "842662848224", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(3135, 121, "38794aa8", "Rinoa,Zell,Selphie,", "426628482242", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(3136, 84, "665429c1", "Irvine,Zell,Selphie,", "266284822428", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Selphie"),

            new PartyFormation(3137, 212, "82d4c566", "Rinoa,Irvine,Selphie,", "662848224288", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3138, 161, "1ba150a7", "Selphie,Zell,Quistis,", "628482242882", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3139, 108, "b26c6954", "Selphie,Squall,Quistis,", "284822428828", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3140, 56, "cb38a0fd", "Selphie,Irvine,Quistis,", "848224288288", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3141, 215, "88d7d1f2", "Rinoa,Zell,Selphie,", "482242882886", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(3142, 8, "d9085043", "Irvine,Zell,Quistis,", "822428828868", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(3143, 208, "07d0c6c0", "Irvine,Squall,Rinoa,", "224288288688", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>94, Selphie,Irvine,Quistis=>14}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3144, 243, "68f34ff9", "Rinoa,Irvine,Quistis,", "242882886886", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>93, Selphie,Irvine,Quistis=>13}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3145, 141, "e58d1b3e", "Selphie,Zell,Quistis,", "428828868862", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>92, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3146, 85, "8b55ad9f", "Selphie,Squall,Quistis,", "288288688622", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>91, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3147, 91, "165b8eec", "Zell,Squall,Selphie,", "882886886226", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>90, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3148, 15, "e10ff2b5", "Rinoa,Squall,Quistis,", "828868862266", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>89, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3149, 187, "5cbbad4a", "Irvine,Squall,Selphie,", "288688622666", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>88, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3150, 241, "7bf184bb", "Zell,Squall,Quistis,", "886886226662", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>87, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3151, 232, "7fe8add8", "Zell,Squall,Quistis,", "868862266628", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>86, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3152, 26, "a81a0531", "Zell,Squall,Selphie,", "688622666284", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>85, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3153, 143, "f58f5416", "Rinoa,Squall,Quistis,", "886226662846", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>84, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3154, 169, "d8a9b197", "Irvine,Squall,Selphie,", "862266628462", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>83, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3155, 38, "a626cf84", "Rinoa,Zell,Selphie,", "622666284624", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>82, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3156, 216, "95d8c36d", "Zell,Squall,Irvine,", "226662846248", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>81, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3157, 36, "ac249ba2", "Selphie,Irvine,Quistis,", "266628462488", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>80, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3158, 77, "f44dd033", "Rinoa,Irvine,Selphie,", "666284624882", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>79, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3159, 3, "b5035ff0", "Selphie,Squall,Quistis,", "662846248826", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>78, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3160, 75, "3d4b2969", "Zell,Squall,Quistis,", "628462488266", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>77, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3161, 212, "afd4cfee", "Zell,Squall,Quistis,", "284624882668", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>76, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3162, 11, "f50b3c8f", "Irvine,Zell,Rinoa,", "846248826686", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>75, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3163, 214, "e7d68b1c", "Selphie,Irvine,Quistis,", "462488266864", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>74, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3164, 99, "c863f325", "Selphie,Irvine,Quistis,", "624882668646", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>73, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3165, 65, "3a41fcfa", "Rinoa,Zell,Quistis,", "248826686462", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>72, Selphie,Irvine,Quistis=>51}", "Irvine,Zell,Selphie"),

            new PartyFormation(3166, 137, "0c8912ab", "Zell,Squall,Quistis,", "488266864622", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>71, Selphie,Irvine,Quistis=>50}", "Irvine,Zell,Selphie"),

            new PartyFormation(3167, 79, "f54f3d08", "Rinoa,Irvine,Selphie,", "882668646226", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>70, Selphie,Irvine,Quistis=>49}", "Irvine,Zell,Selphie"),

            new PartyFormation(3168, 133, "d3859ca1", "Zell,Squall,Irvine,", "826686462262", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>69, Selphie,Irvine,Quistis=>48}", "Irvine,Zell,Selphie"),

            new PartyFormation(3169, 34, "cb22eec6", "Irvine,Zell,Selphie,", "266864622624", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>68, Selphie,Irvine,Quistis=>47}", "Irvine,Zell,Selphie"),

            new PartyFormation(3170, 196, "15c42e87", "Rinoa,Squall,Quistis,", "668646226248", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>67, Selphie,Irvine,Quistis=>46}", "Irvine,Zell,Selphie"),

            new PartyFormation(3171, 31, "4e1f21b4", "Rinoa,Squall,Quistis,", "686462262486", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>66, Selphie,Irvine,Quistis=>45}", "Irvine,Zell,Selphie"),

            new PartyFormation(3172, 190, "84be61dd", "Irvine,Squall,Selphie,", "864622624864", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>65, Selphie,Irvine,Quistis=>44}", "Irvine,Zell,Selphie"),

            new PartyFormation(3173, 207, "54cf3152", "Rinoa,Zell,Quistis,", "646226248646", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>64, Selphie,Irvine,Quistis=>43}", "Irvine,Zell,Selphie"),

            new PartyFormation(3174, 171, "34ab2c23", "Selphie,Squall,Quistis,", "462262486466", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>63, Selphie,Irvine,Quistis=>42}", "Irvine,Zell,Selphie"),

            new PartyFormation(3175, 102, "9a66a520", "Irvine,Squall,Rinoa,", "622624864664", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>62, Selphie,Irvine,Quistis=>41}", "Irvine,Zell,Selphie"),

            new PartyFormation(3176, 196, "dac43ed9", "Zell,Squall,Quistis,", "226248646648", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>61, Selphie,Irvine,Quistis=>40}", "Irvine,Zell,Selphie"),

            new PartyFormation(3177, 139, "a58b109e", "Rinoa,Irvine,Quistis,", "262486466486", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>60, Selphie,Irvine,Quistis=>39}", "Irvine,Zell,Selphie"),

            new PartyFormation(3178, 122, "d37a677f", "Irvine,Zell,Selphie,", "624864664864", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>59, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Selphie"),

            new PartyFormation(3179, 224, "a1e0f34c", "Selphie,Squall,Quistis,", "248646648648", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>58, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Selphie"),

            new PartyFormation(3180, 176, "efb0ef95", "Irvine,Squall,Quistis,", "486466486488", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>57, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Selphie"),

            new PartyFormation(3181, 147, "199398aa", "Zell,Squall,Rinoa,", "864664864886", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>56, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Selphie"),

            new PartyFormation(3182, 215, "19d7fc9b", "Zell,Squall,Selphie,", "646648648866", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>55, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Selphie"),

            new PartyFormation(3183, 207, "8acff838", "Irvine,Squall,Quistis,", "466486488666", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>54, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Selphie"),

            new PartyFormation(3184, 125, "ab7df011", "Irvine,Squall,Rinoa,", "664864886662", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>53, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Selphie"),

            new PartyFormation(3185, 234, "61ea9576", "Rinoa,Squall,Selphie,", "648648866624", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>52, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Selphie"),

            new PartyFormation(3186, 175, "b9afc777", "Irvine,Zell,Rinoa,", "486488666246", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>51, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Selphie"),

            new PartyFormation(3187, 168, "1ba85fe4", "Selphie,Rinoa,Quistis,", "864886662468", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>50, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Selphie"),

            new PartyFormation(3188, 64, "22407c4d", "Irvine,Squall,Selphie,", "648866624688", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>49, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Selphie"),

            new PartyFormation(3189, 226, "ebe29302", "Zell,Squall,Rinoa,", "488666246884", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>48, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Selphie"),

            new PartyFormation(3190, 207, "adcf6413", "Zell,Squall,Quistis,", "886662468846", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>47, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Selphie"),

            new PartyFormation(3191, 125, "6b7d9650", "Zell,Squall,Rinoa,", "866624688462", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>46, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Selphie"),

            new PartyFormation(3192, 37, "9a259049", "Irvine,Squall,Rinoa,", "666246884622", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>45, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(3193, 106, "356add4e", "Selphie,Rinoa,Quistis,", "662468846224", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>44, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(3194, 66, "46422e6f", "Irvine,Squall,Quistis,", "624688462244", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>43, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(3195, 45, "2d2dc77c", "Rinoa,Zell,Quistis,", "246884622442", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>42, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(3196, 45, "f52de805", "Irvine,Zell,Selphie,", "468846224422", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>41, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(3197, 27, "1a1b805a", "Zell,Squall,Selphie,", "688462244226", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>40, Selphie,Irvine,Quistis=>19}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3198, 109, "9e6d428b", "Rinoa,Irvine,Quistis,", "884622442262", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>18}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3199, 77, "814ddf68", "Zell,Squall,Quistis,", "846224422622", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>17}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3200, 169, "faa9ff81", "Rinoa,Squall,Selphie,", "462244226222", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>16}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3201, 1, "e5014826", "Rinoa,Zell,Selphie,", "622442262222", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>15}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3202, 235, "58eb7c67", "Rinoa,Irvine,Selphie,", "224422622226", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>14}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3203, 213, "fad58a14", "Zell,Squall,Quistis,", "244226222262", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>13}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3204, 118, "bc7612bd", "Rinoa,Squall,Quistis,", "442262222624", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3205, 41, "b329c0b2", "Rinoa,Zell,Selphie,", "422622226242", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3206, 41, "3d297803", "Zell,Squall,Quistis,", "226222262422", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3207, 139, "428b3380", "Rinoa,Squall,Quistis,", "262222624226", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3208, 246, "13f61db9", "Rinoa,Squall,Selphie,", "622226242264", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3209, 239, "72ef35fe", "Zell,Squall,Rinoa,", "222262422646", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3210, 193, "12c1915f", "Irvine,Squall,Quistis,", "222624226462", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3211, 48, "853007ac", "Irvine,Zell,Rinoa,", "226242264628", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3212, 209, "f2d1dc75", "Rinoa,Squall,Selphie,", "262422646282", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3213, 4, "8c04b40a", "Irvine,Zell,Rinoa,", "624226462828", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3214, 151, "d697e47b", "Irvine,Squall,Rinoa,", "242264628286", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3215, 107, "986bf298", "Irvine,Zell,Rinoa,", "422646282866", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3216, 112, "0370caf1", "Selphie,Irvine,Quistis,", "226462828668", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3217, 66, "fc4206d6", "Selphie,Irvine,Quistis,", "264628286684", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3218, 182, "25b64d57", "Zell,Squall,Selphie,", "646282866844", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(3219, 121, "8279a044", "Rinoa,Zell,Selphie,", "462828668442", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(3220, 54, "d536252d", "Selphie,Zell,Quistis,", "628286684424", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(3221, 47, "752fba62", "Zell,Squall,Quistis,", "282866844246", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(3222, 232, "79e867f3", "Rinoa,Zell,Selphie,", "828668442468", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(3223, 146, "d0927cb0", "Rinoa,Squall,Selphie,", "286684424684", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(3224, 124, "907ce729", "Rinoa,Squall,Quistis,", "866844246848", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(3225, 83, "c6531aae", "Irvine,Zell,Selphie,", "668442468486", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(3226, 23, "9417904f", "Rinoa,Irvine,Quistis,", "684424684866", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(3227, 26, "e81ab3dc", "Rinoa,Squall,Selphie,", "844246848664", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(3228, 83, "ee53cce5", "Irvine,Squall,Selphie,", "442468486646", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(3229, 58, "a03a33ba", "Irvine,Zell,Selphie,", "424684866464", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3230, 102, "3066e26b", "Irvine,Zell,Rinoa,", "246848664644", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(3231, 141, "3e8d31c8", "Rinoa,Squall,Quistis,", "468486646442", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(3232, 249, "eff95261", "Zell,Squall,Rinoa,", "684866464422", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(3233, 71, "7c47d186", "Irvine,Zell,Rinoa,", "848664644226", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(3234, 15, "e00f3a47", "Zell,Squall,Selphie,", "486646442266", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(3235, 39, "2427a274", "Rinoa,Irvine,Quistis,", "866464422666", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(3236, 23, "9217b39d", "Irvine,Squall,Selphie,", "664644226666", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(3237, 63, "353f8012", "Irvine,Zell,Quistis,", "646442266666", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(3238, 251, "a4fb33e3", "Rinoa,Squall,Quistis,", "464422666666", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3239, 86, "8d5671e0", "Rinoa,Zell,Selphie,", "644226666664", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3240, 192, "77c0ec99", "Rinoa,Irvine,Selphie,", "442266666648", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3241, 145, "9c918b5e", "Rinoa,Zell,Quistis,", "422666666482", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3242, 35, "ab232b3f", "Selphie,Irvine,Quistis,", "226666664826", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3243, 224, "06e0cc0c", "Irvine,Zell,Rinoa,", "266666648268", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(3244, 42, "492ab955", "Selphie,Squall,Quistis,", "666666482684", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(3245, 102, "1866ff6a", "Selphie,Squall,Quistis,", "666664826844", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(3246, 169, "3ba93c5b", "Zell,Squall,Rinoa,", "666648268442", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(3247, 212, "c0d49cf8", "Irvine,Zell,Selphie,", "666482684428", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3248, 42, "422a95d1", "Irvine,Zell,Quistis,", "664826844284", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(3249, 109, "166da836", "Selphie,Squall,Quistis,", "648268442842", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3250, 181, "c5b54337", "Zell,Squall,Quistis,", "482684428422", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3251, 50, "5c3290a4", "Selphie,Rinoa,Quistis,", "826844284224", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3252, 113, "2c71be0d", "Rinoa,Squall,Quistis,", "268442842242", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3253, 100, "df6411c2", "Zell,Squall,Quistis,", "684428422428", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3254, 16, "9910dbd3", "Selphie,Rinoa,Quistis,", "844284224288", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3255, 90, "e75a1310", "Selphie,Rinoa,Quistis,", "442842242884", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3256, 137, "c1892e09", "Selphie,Rinoa,Quistis,", "428422428842", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3257, 101, "1765880e", "Selphie,Squall,Quistis,", "284224288422", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3258, 131, "ae83622f", "Irvine,Squall,Rinoa,", "842242884226", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3259, 53, "3535503c", "Zell,Squall,Irvine,", "422428842262", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3260, 141, "308da1c5", "Selphie,Irvine,Quistis,", "224288422622", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3261, 246, "f6f6171a", "Zell,Squall,Rinoa,", "242884226224", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>53}", "Irvine,Zell,Quistis"),

            new PartyFormation(3262, 237, "99edf24b", "Selphie,Zell,Quistis,", "428842262242", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>52}", "Irvine,Zell,Quistis"),

            new PartyFormation(3263, 37, "7b253428", "Rinoa,Squall,Selphie,", "288422622422", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>51}", "Irvine,Zell,Quistis"),

            new PartyFormation(3264, 171, "43ab9541", "Rinoa,Squall,Selphie,", "884226224226", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>50}", "Irvine,Zell,Quistis"),

            new PartyFormation(3265, 206, "08ce8ae6", "Irvine,Zell,Quistis,", "842262242264", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>49}", "Irvine,Zell,Quistis"),

            new PartyFormation(3266, 39, "82276827", "Rinoa,Squall,Quistis,", "422622422646", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>48}", "Irvine,Zell,Quistis"),

            new PartyFormation(3267, 173, "e1ad6ad4", "Rinoa,Irvine,Selphie,", "226224226462", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>47}", "Irvine,Zell,Quistis"),

            new PartyFormation(3268, 91, "615b447d", "Irvine,Zell,Quistis,", "262242264626", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>46}", "Irvine,Zell,Quistis"),

            new PartyFormation(3269, 104, "f8686f72", "Selphie,Squall,Quistis,", "622422646268", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>45}", "Irvine,Zell,Selphie"),

            new PartyFormation(3270, 152, "ba985fc3", "Rinoa,Zell,Quistis,", "224226462688", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>44}", "Irvine,Zell,Selphie"),

            new PartyFormation(3271, 224, "73e06040", "Irvine,Zell,Selphie,", "242264626888", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>43}", "Irvine,Zell,Selphie"),

            new PartyFormation(3272, 92, "655cab79", "Rinoa,Irvine,Quistis,", "422646268888", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>42}", "Irvine,Zell,Quistis"),

            new PartyFormation(3273, 74, "bd4a10be", "Rinoa,Squall,Quistis,", "226462688884", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>41}", "Irvine,Zell,Quistis"),

            new PartyFormation(3274, 151, "5a97351f", "Rinoa,Squall,Selphie,", "264626888846", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>40}", "Irvine,Zell,Quistis"),

            new PartyFormation(3275, 139, "998b406c", "Irvine,Zell,Quistis,", "646268888466", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>39}", "Irvine,Zell,Quistis"),

            new PartyFormation(3276, 115, "0d738635", "Rinoa,Squall,Quistis,", "462688884666", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Quistis"),

            new PartyFormation(3277, 18, "2f127aca", "Selphie,Rinoa,Quistis,", "626888846664", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Quistis"),

            new PartyFormation(3278, 132, "ee84043b", "Irvine,Squall,Quistis,", "268888466648", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Quistis"),

            new PartyFormation(3279, 33, "0821f758", "Zell,Squall,Selphie,", "688884666482", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Quistis"),

            new PartyFormation(3280, 227, "75e350b1", "Irvine,Zell,Quistis,", "888846664826", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Quistis"),

            new PartyFormation(3281, 69, "ce457996", "Irvine,Zell,Rinoa,", "888466648262", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Quistis"),

            new PartyFormation(3282, 164, "1ea4a917", "Rinoa,Zell,Quistis,", "884666482628", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Quistis"),

            new PartyFormation(3283, 107, "d66b3104", "Zell,Squall,Rinoa,", "846664826286", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Quistis"),

            new PartyFormation(3284, 171, "e1ab46ed", "Selphie,Rinoa,Quistis,", "466648262866", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(3285, 215, "4dd79922", "Zell,Squall,Rinoa,", "666482628666", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Quistis"),

            new PartyFormation(3286, 192, "e7c0bfb3", "Rinoa,Zell,Selphie,", "664826286668", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(3287, 236, "1eec5970", "Irvine,Zell,Quistis,", "648262866688", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Quistis"),

            new PartyFormation(3288, 130, "ca8264e9", "Irvine,Squall,Quistis,", "482628666884", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Selphie"),

            new PartyFormation(3289, 122, "297a256e", "Zell,Squall,Rinoa,", "826286668844", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Selphie"),

            new PartyFormation(3290, 125, "c17da40f", "Irvine,Zell,Selphie,", "262866688442", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(3291, 21, "5d159c9c", "Rinoa,Irvine,Quistis,", "628666884422", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(3292, 147, "f49366a5", "Rinoa,Squall,Selphie,", "286668844226", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(3293, 167, "54a72a7a", "Irvine,Zell,Selphie,", "866688442266", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(3294, 122, "ce7a722b", "Zell,Squall,Quistis,", "666884422664", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(3295, 45, "712de688", "Rinoa,Zell,Selphie,", "668844226642", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(3296, 248, "01f8c821", "Irvine,Zell,Quistis,", "688442266428", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(3297, 109, "ce6d7446", "Selphie,Squall,Quistis,", "884422664282", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>46, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(3298, 44, "f22c0607", "Selphie,Zell,Quistis,", "844226642828", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>45, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(3299, 254, "f6fee334", "Zell,Squall,Quistis,", "442266428284", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>44, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(3300, 248, "c1f8c55d", "Irvine,Squall,Quistis,", "422664282848", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>43, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(3301, 252, "a5fc8ed2", "Irvine,Squall,Rinoa,", "226642828488", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>42, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3302, 120, "6878fba3", "Rinoa,Zell,Quistis,", "266428284888", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>41, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(3303, 64, "5b40fea0", "Selphie,Rinoa,Quistis,", "664282848888", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>40, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(3304, 1, "38015a59", "Rinoa,Irvine,Selphie,", "642828488882", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(3305, 240, "bbf0c61e", "Irvine,Zell,Selphie,", "428284888828", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(3306, 21, "3b15aeff", "Rinoa,Irvine,Selphie,", "282848888282", "{Irvine,Zell,Selphie=>72, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3307, 199, "dbc764cc", "Zell,Squall,Selphie,", "828488882826", "{Irvine,Zell,Selphie=>71, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3308, 100, "16644315", "Zell,Squall,Irvine,", "284888828268", "{Irvine,Zell,Selphie=>70, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3309, 95, "4c5f262a", "Selphie,Rinoa,Quistis,", "848888282686", "{Irvine,Zell,Selphie=>69, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3310, 160, "b0a03c1b", "Irvine,Zell,Rinoa,", "488882826868", "{Irvine,Zell,Selphie=>68, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3311, 108, "5e6c01b8", "Rinoa,Irvine,Quistis,", "888828268688", "{Irvine,Zell,Selphie=>67, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3312, 210, "28d2fb91", "Irvine,Squall,Selphie,", "888282686884", "{Irvine,Zell,Selphie=>66, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3313, 161, "0da17af6", "Irvine,Zell,Rinoa,", "882826868842", "{Irvine,Zell,Selphie=>65, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3314, 124, "917c7ef7", "Selphie,Irvine,Quistis,", "828268688428", "{Irvine,Zell,Selphie=>64, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3315, 187, "cabb8164", "Irvine,Squall,Selphie,", "282686884286", "{Irvine,Zell,Selphie=>63, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(3316, 154, "ea9abfcd", "Irvine,Squall,Quistis,", "826868842864", "{Irvine,Zell,Selphie=>62, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Quistis"),

            new PartyFormation(3317, 226, "6fe25082", "Rinoa,Irvine,Selphie,", "268688428644", "{Irvine,Zell,Selphie=>61, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(3318, 112, "de701393", "Rinoa,Squall,Selphie,", "686884286448", "{Irvine,Zell,Selphie=>60, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Quistis"),

            new PartyFormation(3319, 97, "52614fd0", "Zell,Squall,Selphie,", "868842864482", "{Irvine,Zell,Selphie=>59, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Quistis"),

            new PartyFormation(3320, 160, "44a08bc9", "Selphie,Zell,Quistis,", "688428644828", "{Irvine,Zell,Selphie=>58, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(3321, 104, "4968f2ce", "Rinoa,Irvine,Quistis,", "884286448288", "{Irvine,Zell,Selphie=>57, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(3322, 254, "54fe55ef", "Rinoa,Irvine,Quistis,", "842864482884", "{Irvine,Zell,Selphie=>56, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(3323, 83, "d45398fc", "Irvine,Squall,Selphie,", "428644828846", "{Irvine,Zell,Selphie=>55, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(3324, 29, "2f1d1b85", "Rinoa,Squall,Quistis,", "286448288462", "{Irvine,Zell,Selphie=>54, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(3325, 165, "fba56dda", "Zell,Squall,Rinoa,", "864482884622", "{Irvine,Zell,Selphie=>53, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(3326, 132, "dd84620b", "Irvine,Squall,Quistis,", "644828846228", "{Irvine,Zell,Selphie=>52, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(3327, 191, "46bf48e8", "Zell,Squall,Selphie,", "448288462286", "{Irvine,Zell,Selphie=>51, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(3328, 24, "b318eb01", "Irvine,Squall,Rinoa,", "482884622868", "{Irvine,Zell,Selphie=>50, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(3329, 252, "dcfc8da6", "Selphie,Squall,Quistis,", "828846228688", "{Irvine,Zell,Selphie=>49, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(3330, 21, "bf1513e7", "Irvine,Squall,Quistis,", "288462286882", "{Irvine,Zell,Selphie=>48, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(3331, 180, "d3b40b94", "Irvine,Squall,Rinoa,", "884622868828", "{Irvine,Zell,Selphie=>47, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(3332, 168, "87a8363d", "Irvine,Squall,Selphie,", "846228688288", "{Irvine,Zell,Selphie=>46, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(3333, 83, "7353de32", "Selphie,Zell,Quistis,", "462286882886", "{Irvine,Zell,Selphie=>45, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(3334, 21, "35150783", "Zell,Squall,Irvine,", "622868828862", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(3335, 144, "14904d00", "Selphie,Squall,Quistis,", "228688288628", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(3336, 230, "46e6f939", "Zell,Squall,Selphie,", "286882886284", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(3337, 93, "cb5dab7e", "Rinoa,Zell,Selphie,", "868828862842", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(3338, 150, "c29698df", "Irvine,Squall,Quistis,", "688288628424", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(3339, 45, "982d392c", "Zell,Squall,Quistis,", "882886284242", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(3340, 180, "f6b4eff5", "Irvine,Squall,Rinoa,", "828862842428", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(3341, 165, "f8a5018a", "Rinoa,Squall,Quistis,", "288628424282", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(3342, 117, "5f75e3fb", "Irvine,Squall,Selphie,", "886284242822", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Quistis"),

            new PartyFormation(3343, 202, "9fcabc18", "Irvine,Zell,Quistis,", "862842428224", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>2}", "Irvine,Zell,Quistis"),

            new PartyFormation(3344, 49, "61319671", "Rinoa,Irvine,Quistis,", "628424282242", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>61, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3345, 89, "8a59ac56", "Selphie,Irvine,Quistis,", "284242822422", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>60, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3346, 52, "5b34c4d7", "Rinoa,Irvine,Selphie,", "842428224228", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>59, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3347, 187, "bebb81c4", "Rinoa,Zell,Selphie,", "424282242286", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>58, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3348, 248, "78f828ad", "Irvine,Squall,Selphie,", "242822422868", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>57, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3349, 220, "80dc37e2", "Rinoa,Squall,Quistis,", "428224228688", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>56, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3350, 150, "9196d773", "Rinoa,Zell,Selphie,", "282242286884", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>55, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3351, 208, "c8d0f630", "Zell,Squall,Selphie,", "822422868848", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>54, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3352, 27, "c51ba2a9", "Rinoa,Zell,Selphie,", "224228688486", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>53, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3353, 9, "1009f02e", "Rinoa,Squall,Selphie,", "242286884862", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>52, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3354, 253, "4cfd77cf", "Irvine,Squall,Quistis,", "422868848622", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>51, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3355, 135, "3b87455c", "Irvine,Squall,Quistis,", "228688486226", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>50, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3356, 226, "90e2c065", "Selphie,Irvine,Quistis,", "286884862264", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>49, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3357, 72, "3a48e13a", "Selphie,Squall,Quistis,", "868848622648", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>48, Selphie,Irvine,Quistis=>45}", "Irvine,Zell,Selphie"),

            new PartyFormation(3358, 131, "f283c1eb", "Rinoa,Irvine,Selphie,", "688486226486", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>47, Selphie,Irvine,Quistis=>44}", "Irvine,Zell,Selphie"),

            new PartyFormation(3359, 241, "0df15b48", "Irvine,Squall,Quistis,", "884862264862", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>46, Selphie,Irvine,Quistis=>43}", "Irvine,Zell,Selphie"),

            new PartyFormation(3360, 67, "5b43fde1", "Selphie,Squall,Quistis,", "848622648626", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>45, Selphie,Irvine,Quistis=>42}", "Irvine,Zell,Selphie"),

            new PartyFormation(3361, 83, "1053d706", "Zell,Squall,Quistis,", "486226486266", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>44, Selphie,Irvine,Quistis=>41}", "Irvine,Zell,Selphie"),

            new PartyFormation(3362, 218, "53da91c7", "Zell,Squall,Selphie,", "862264862664", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>43, Selphie,Irvine,Quistis=>40}", "Irvine,Zell,Selphie"),

            new PartyFormation(3363, 100, "9364e3f4", "Zell,Squall,Selphie,", "622648626648", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>42, Selphie,Irvine,Quistis=>39}", "Irvine,Zell,Selphie"),

            new PartyFormation(3364, 33, "c221971d", "Irvine,Squall,Rinoa,", "226486266482", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>41, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Selphie"),

            new PartyFormation(3365, 198, "21c65d92", "Zell,Squall,Selphie,", "264862664824", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>40, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Selphie"),

            new PartyFormation(3366, 228, "42e48363", "Zell,Squall,Quistis,", "648626648248", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Selphie"),

            new PartyFormation(3367, 230, "dce64b60", "Rinoa,Irvine,Selphie,", "486266482484", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Selphie"),

            new PartyFormation(3368, 69, "e5458819", "Selphie,Rinoa,Quistis,", "862664824842", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Selphie"),

            new PartyFormation(3369, 104, "6a68c0de", "Zell,Squall,Quistis,", "626648248428", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Selphie"),

            new PartyFormation(3370, 17, "c311f2bf", "Zell,Squall,Irvine,", "266482484282", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Selphie"),

            new PartyFormation(3371, 84, "c554bd8c", "Zell,Squall,Irvine,", "664824842828", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Selphie"),

            new PartyFormation(3372, 29, "fd1d8cd5", "Rinoa,Zell,Quistis,", "648248428282", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Selphie"),

            new PartyFormation(3373, 60, "c83c0cea", "Irvine,Squall,Quistis,", "482484282828", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Selphie"),

            new PartyFormation(3374, 124, "f47cfbdb", "Zell,Squall,Quistis,", "824842828288", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Selphie"),

            new PartyFormation(3375, 86, "94562678", "Zell,Squall,Irvine,", "248428282884", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Selphie"),

            new PartyFormation(3376, 55, "a1372151", "Rinoa,Irvine,Quistis,", "484282828846", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Selphie"),

            new PartyFormation(3377, 70, "c6460db6", "Irvine,Squall,Selphie,", "842828288464", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Selphie"),

            new PartyFormation(3378, 197, "94c57ab7", "Irvine,Zell,Selphie,", "428282884642", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(3379, 3, "e4033224", "Irvine,Zell,Selphie,", "282828846426", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(3380, 123, "fa7b818d", "Rinoa,Zell,Quistis,", "828288464266", "{Irvine,Zell,Selphie=>116, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>22}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3381, 29, "481d4f42", "Rinoa,Irvine,Selphie,", "282884642662", "{Irvine,Zell,Selphie=>115, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>21}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3382, 173, "b1ad0b53", "Zell,Squall,Rinoa,", "828846426622", "{Irvine,Zell,Selphie=>114, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>20}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3383, 83, "35534c90", "Irvine,Squall,Quistis,", "288464266226", "{Irvine,Zell,Selphie=>113, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>19}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3384, 43, "dd2ba989", "Rinoa,Squall,Selphie,", "884642662266", "{Irvine,Zell,Selphie=>112, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>18}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3385, 53, "62351d8e", "Selphie,Rinoa,Quistis,", "846426622662", "{Irvine,Zell,Selphie=>111, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>17}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3386, 115, "e97309af", "Zell,Squall,Irvine,", "464266226626", "{Irvine,Zell,Selphie=>110, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>16}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3387, 72, "5f48a1bc", "Irvine,Squall,Selphie,", "642662266268", "{Irvine,Zell,Selphie=>109, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>15}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3388, 156, "869c5545", "Rinoa,Zell,Quistis,", "426622662688", "{Irvine,Zell,Selphie=>108, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>14}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3389, 233, "6ae9849a", "Rinoa,Irvine,Selphie,", "266226626882", "{Irvine,Zell,Selphie=>107, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>13}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3390, 240, "54f091cb", "Irvine,Squall,Selphie,", "662266268828", "{Irvine,Zell,Selphie=>106, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3391, 220, "c4dc1da8", "Zell,Squall,Rinoa,", "622662688288", "{Irvine,Zell,Selphie=>105, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3392, 178, "7ab200c1", "Rinoa,Zell,Quistis,", "226626882884", "{Irvine,Zell,Selphie=>104, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3393, 75, "104b5066", "Selphie,Rinoa,Quistis,", "266268828846", "{Irvine,Zell,Selphie=>103, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3394, 116, "f7747fa7", "Irvine,Squall,Quistis,", "662688288468", "{Irvine,Zell,Selphie=>102, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3395, 169, "fda96c54", "Zell,Squall,Rinoa,", "626882884682", "{Irvine,Zell,Selphie=>101, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3396, 28, "bd1ce7fd", "Zell,Squall,Selphie,", "268828846828", "{Irvine,Zell,Selphie=>100, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3397, 172, "feac0cf2", "Irvine,Squall,Quistis,", "688288468288", "{Irvine,Zell,Selphie=>99, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3398, 95, "505f6f43", "Selphie,Zell,Quistis,", "882884682886", "{Irvine,Zell,Selphie=>98, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3399, 90, "5d5af9c0", "Rinoa,Irvine,Selphie,", "828846828864", "{Irvine,Zell,Selphie=>97, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3400, 85, "625506f9", "Rinoa,Irvine,Selphie,", "288468288642", "{Irvine,Zell,Selphie=>96, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3401, 234, "63ea063e", "Irvine,Zell,Rinoa,", "884682886424", "{Irvine,Zell,Selphie=>95, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3402, 127, "6a7fbc9f", "Selphie,Irvine,Quistis,", "846828864246", "{Irvine,Zell,Selphie=>94, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3403, 213, "85d5f1ec", "Selphie,Irvine,Quistis,", "468288642462", "{Irvine,Zell,Selphie=>93, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3404, 86, "345619b5", "Irvine,Zell,Rinoa,", "682886424624", "{Irvine,Zell,Selphie=>92, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(3405, 124, "5b7c484a", "Irvine,Zell,Quistis,", "828864246248", "{Irvine,Zell,Selphie=>91, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(3406, 45, "852d83bb", "Rinoa,Irvine,Selphie,", "288642462482", "{Irvine,Zell,Selphie=>90, Irvine,Zell,Quistis=>46, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3407, 38, "f02640d8", "Selphie,Zell,Quistis,", "886424624824", "{Irvine,Zell,Selphie=>89, Irvine,Zell,Quistis=>45, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3408, 27, "e71b9c31", "Irvine,Zell,Rinoa,", "864246248246", "{Irvine,Zell,Selphie=>88, Irvine,Zell,Quistis=>44, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3409, 62, "0f3e9f16", "Selphie,Irvine,Quistis,", "642462482464", "{Irvine,Zell,Selphie=>87, Irvine,Zell,Quistis=>43, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3410, 38, "3326a097", "Irvine,Squall,Rinoa,", "424624824644", "{Irvine,Zell,Selphie=>86, Irvine,Zell,Quistis=>42, Selphie,Irvine,Quistis=>16}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3411, 42, "182a9284", "Irvine,Squall,Rinoa,", "246248246444", "{Irvine,Zell,Selphie=>85, Irvine,Zell,Quistis=>41, Selphie,Irvine,Quistis=>15}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3412, 220, "18dcca6d", "Selphie,Squall,Quistis,", "462482464448", "{Irvine,Zell,Selphie=>84, Irvine,Zell,Quistis=>40, Selphie,Irvine,Quistis=>14}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3413, 253, "18fd96a2", "Zell,Squall,Irvine,", "624824644482", "{Irvine,Zell,Selphie=>83, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>13}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3414, 42, "8b2aaf33", "Irvine,Squall,Selphie,", "248246444824", "{Irvine,Zell,Selphie=>82, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3415, 0, "b70052f0", "Selphie,Squall,Quistis,", "482464448248", "{Irvine,Zell,Selphie=>81, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3416, 8, "1a08a069", "Zell,Squall,Quistis,", "824644482488", "{Irvine,Zell,Selphie=>80, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3417, 194, "70c27aee", "Irvine,Squall,Rinoa,", "246444824884", "{Irvine,Zell,Selphie=>79, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3418, 87, "c6570b8f", "Zell,Squall,Irvine,", "464448248846", "{Irvine,Zell,Selphie=>78, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3419, 47, "382fae1c", "Rinoa,Squall,Selphie,", "644482488466", "{Irvine,Zell,Selphie=>77, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3420, 1, "3901da25", "Rinoa,Zell,Selphie,", "444824884662", "{Irvine,Zell,Selphie=>76, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3421, 223, "f3df57fa", "Zell,Squall,Rinoa,", "448248846626", "{Irvine,Zell,Selphie=>75, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3422, 66, "6842d1ab", "Irvine,Squall,Selphie,", "482488466264", "{Irvine,Zell,Selphie=>74, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3423, 151, "55979008", "Zell,Squall,Rinoa,", "824884662646", "{Irvine,Zell,Selphie=>73, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3424, 154, "0d9af3a1", "Irvine,Squall,Quistis,", "248846626464", "{Irvine,Zell,Selphie=>72, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3425, 186, "50baf9c6", "Rinoa,Squall,Quistis,", "488466264644", "{Irvine,Zell,Selphie=>71, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3426, 218, "ccdadd87", "Selphie,Irvine,Quistis,", "884662646444", "{Irvine,Zell,Selphie=>70, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3427, 25, "8619a4b4", "Rinoa,Squall,Selphie,", "846626464442", "{Irvine,Zell,Selphie=>69, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>18}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3428, 82, "005228dd", "Rinoa,Zell,Selphie,", "466264644424", "{Irvine,Zell,Selphie=>68, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>17}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3429, 92, "e35cec52", "Irvine,Squall,Rinoa,", "662646444248", "{Irvine,Zell,Selphie=>67, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>16}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3430, 253, "b7fdcb23", "Selphie,Squall,Quistis,", "626464442482", "{Irvine,Zell,Selphie=>66, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>15}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3431, 6, "ab065820", "Zell,Squall,Rinoa,", "264644424824", "{Irvine,Zell,Selphie=>65, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>14}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3432, 77, "094d75d9", "Selphie,Rinoa,Quistis,", "646444248242", "{Irvine,Zell,Selphie=>64, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>13}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3433, 185, "ceb97b9e", "Irvine,Squall,Rinoa,", "464442482422", "{Irvine,Zell,Selphie=>63, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3434, 215, "42d7f67f", "Irvine,Squall,Rinoa,", "644424824226", "{Irvine,Zell,Selphie=>62, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3435, 72, "2848d64c", "Zell,Squall,Irvine,", "444248242268", "{Irvine,Zell,Selphie=>61, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3436, 22, "63169695", "Rinoa,Squall,Selphie,", "442482422684", "{Irvine,Zell,Selphie=>60, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3437, 189, "5ebdb3aa", "Irvine,Squall,Selphie,", "424824226842", "{Irvine,Zell,Selphie=>59, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3438, 255, "42ff7b9b", "Selphie,Zell,Quistis,", "248242268426", "{Irvine,Zell,Selphie=>58, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3439, 83, "53530b38", "Rinoa,Zell,Selphie,", "482422684266", "{Irvine,Zell,Selphie=>57, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3440, 23, "ad170711", "Zell,Squall,Quistis,", "824226842666", "{Irvine,Zell,Selphie=>56, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3441, 27, "7f1b6076", "Selphie,Squall,Quistis,", "242268426666", "{Irvine,Zell,Selphie=>55, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3442, 80, "07503677", "Rinoa,Irvine,Quistis,", "422684266668", "{Irvine,Zell,Selphie=>54, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3443, 201, "e4c9a2e4", "Rinoa,Zell,Quistis,", "226842666682", "{Irvine,Zell,Selphie=>53, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3444, 212, "b9d4034d", "Rinoa,Squall,Selphie,", "268426666828", "{Irvine,Zell,Selphie=>52, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3445, 213, "d2d50e02", "Selphie,Irvine,Quistis,", "684266668282", "{Irvine,Zell,Selphie=>51, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3446, 135, "0687c313", "Rinoa,Irvine,Quistis,", "842666682826", "{Irvine,Zell,Selphie=>50, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>43}", "Irvine,Zell,Quistis"),

            new PartyFormation(3447, 240, "d8f00950", "Irvine,Squall,Selphie,", "426666828268", "{Irvine,Zell,Selphie=>49, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>42}", "Irvine,Zell,Quistis"),

            new PartyFormation(3448, 234, "04ea8749", "Selphie,Squall,Quistis,", "266668282684", "{Irvine,Zell,Selphie=>48, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>41}", "Irvine,Zell,Quistis"),

            new PartyFormation(3449, 138, "b88a084e", "Irvine,Zell,Rinoa,", "666682826844", "{Irvine,Zell,Selphie=>47, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>40}", "Irvine,Zell,Quistis"),

            new PartyFormation(3450, 161, "dba17d6f", "Rinoa,Squall,Selphie,", "666828268442", "{Irvine,Zell,Selphie=>46, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>39}", "Irvine,Zell,Quistis"),

            new PartyFormation(3451, 212, "ead46a7c", "Rinoa,Irvine,Selphie,", "668282684428", "{Irvine,Zell,Selphie=>45, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Quistis"),

            new PartyFormation(3452, 203, "8ccb4f05", "Irvine,Zell,Quistis,", "682826844286", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Quistis"),

            new PartyFormation(3453, 130, "47825b5a", "Zell,Squall,Quistis,", "828268442864", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Quistis"),

            new PartyFormation(3454, 242, "abf2818b", "Rinoa,Squall,Selphie,", "282684428644", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Quistis"),

            new PartyFormation(3455, 59, "963bb268", "Zell,Squall,Rinoa,", "826844286446", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Quistis"),

            new PartyFormation(3456, 54, "8c36d681", "Irvine,Zell,Quistis,", "268442864464", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Quistis"),

            new PartyFormation(3457, 122, "117ad326", "Rinoa,Irvine,Quistis,", "684428644644", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Quistis"),

            new PartyFormation(3458, 5, "d305ab67", "Zell,Squall,Selphie,", "844286446442", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Quistis"),

            new PartyFormation(3459, 77, "4c4d8d14", "Zell,Squall,Quistis,", "442864464422", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(3460, 121, "4f7959bd", "Rinoa,Irvine,Quistis,", "428644644222", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Quistis"),

            new PartyFormation(3461, 48, "3530fbb2", "Rinoa,Irvine,Selphie,", "286446442228", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(3462, 55, "70379703", "Selphie,Zell,Quistis,", "864464422286", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Quistis"),

            new PartyFormation(3463, 0, "47006680", "Rinoa,Squall,Selphie,", "644644222868", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Quistis"),

            new PartyFormation(3464, 102, "2166d4b9", "Selphie,Zell,Quistis,", "446442228684", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(3465, 175, "0daf20fe", "Rinoa,Zell,Quistis,", "464422286846", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(3466, 18, "3212a05f", "Selphie,Rinoa,Quistis,", "644222868464", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(3467, 69, "27456aac", "Irvine,Zell,Quistis,", "442228684642", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(3468, 23, "0c170375", "Zell,Squall,Quistis,", "422286846426", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(3469, 88, "8a584f0a", "Irvine,Squall,Selphie,", "222868464268", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(3470, 106, "7b6ae37b", "Rinoa,Zell,Quistis,", "228684642684", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(3471, 244, "49f48598", "Rinoa,Squall,Quistis,", "286846426848", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(3472, 97, "e96161f1", "Zell,Squall,Quistis,", "868464268482", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(3473, 180, "fbb451d6", "Irvine,Squall,Selphie,", "684642684828", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(3474, 58, "be3a3c57", "Irvine,Zell,Quistis,", "846426848284", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(3475, 120, "7f786344", "Rinoa,Squall,Selphie,", "464268482848", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(3476, 25, "ff192c2d", "Irvine,Squall,Selphie,", "642684828482", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(3477, 251, "e0fbb562", "Irvine,Zell,Rinoa,", "426848284826", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(3478, 60, "a83c46f3", "Rinoa,Squall,Selphie,", "268482848268", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(3479, 58, "923a6fb0", "Selphie,Squall,Quistis,", "684828482684", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(3480, 9, "23095e29", "Irvine,Zell,Quistis,", "848284826842", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(3481, 99, "0263c5ae", "Rinoa,Squall,Selphie,", "482848268426", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3482, 74, "7d4a5f4f", "Irvine,Squall,Rinoa,", "828482684264", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3483, 206, "c7ced6dc", "Rinoa,Irvine,Selphie,", "284826842644", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3484, 176, "22b0b3e5", "Rinoa,Squall,Quistis,", "848268426448", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3485, 42, "e42a8eba", "Zell,Squall,Rinoa,", "482684264484", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3486, 119, "bb77a16b", "Irvine,Squall,Rinoa,", "826842644846", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3487, 224, "48e084c8", "Rinoa,Zell,Quistis,", "268426448468", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3488, 189, "eabda961", "Selphie,Rinoa,Quistis,", "684264484682", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3489, 98, "5e62dc86", "Selphie,Irvine,Quistis,", "842644846824", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3490, 236, "e4ece947", "Selphie,Irvine,Quistis,", "426448468248", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3491, 221, "1bdd2574", "Rinoa,Zell,Quistis,", "264484682482", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3492, 74, "aa4a7a9d", "Selphie,Squall,Quistis,", "644846824824", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(3493, 128, "e5803b12", "Zell,Squall,Quistis,", "448468248248", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(3494, 132, "0b84d2e3", "Rinoa,Squall,Selphie,", "484682482488", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(3495, 97, "1e6124e0", "Rinoa,Squall,Quistis,", "846824824882", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(3496, 217, "edd92399", "Irvine,Zell,Selphie,", "468248248822", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(3497, 162, "cfa2f65e", "Irvine,Zell,Rinoa,", "682482488224", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(3498, 39, "7a27ba3f", "Irvine,Squall,Rinoa,", "824824882246", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(3499, 99, "2963af0c", "Rinoa,Irvine,Quistis,", "248248822466", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(3500, 15, "6e0f6055", "Rinoa,Zell,Selphie,", "482488224666", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Selphie"),

            new PartyFormation(3501, 164, "a2a41a6a", "Irvine,Zell,Selphie,", "824882246668", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Selphie"),

            new PartyFormation(3502, 231, "97e7bb5b", "Zell,Squall,Selphie,", "248822466686", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3503, 34, "4c22aff8", "Rinoa,Zell,Selphie,", "488224666864", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3504, 50, "0e32acd1", "Selphie,Irvine,Quistis,", "882246668644", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3505, 225, "36e17336", "Rinoa,Irvine,Quistis,", "822466686442", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3506, 220, "e0dcb237", "Irvine,Zell,Rinoa,", "224666864428", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3507, 206, "c9ced3a4", "Rinoa,Squall,Quistis,", "246668644284", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3508, 100, "4664450d", "Zell,Squall,Irvine,", "466686442848", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3509, 201, "3ac98cc2", "Rinoa,Irvine,Selphie,", "666864428482", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3510, 192, "90c03ad3", "Rinoa,Squall,Quistis,", "668644284828", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3511, 247, "45f78610", "Selphie,Zell,Quistis,", "686442848286", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3512, 157, "f59d2509", "Selphie,Irvine,Quistis,", "864428482862", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3513, 39, "6327b30e", "Irvine,Squall,Rinoa,", "644284828626", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(3514, 73, "5b49b12f", "Rinoa,Zell,Quistis,", "442848286262", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(3515, 182, "4bb6f33c", "Irvine,Zell,Quistis,", "428482862624", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(3516, 106, "576a08c5", "Rinoa,Irvine,Quistis,", "284828626244", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3517, 47, "542ff21a", "Rinoa,Zell,Quistis,", "848286262446", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3518, 74, "4e4a314b", "Rinoa,Squall,Selphie,", "482862624464", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3519, 158, "1b9e0728", "Selphie,Zell,Quistis,", "828626244644", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3520, 103, "99676c41", "Rinoa,Zell,Selphie,", "286262446446", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3521, 75, "0f4b15e6", "Selphie,Irvine,Quistis,", "862624464466", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3522, 136, "b9889727", "Irvine,Zell,Rinoa,", "626244644668", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3523, 96, "6c606dd4", "Irvine,Squall,Selphie,", "262446446688", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3524, 125, "4c7d8b7d", "Irvine,Squall,Quistis,", "624464466882", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3525, 162, "71a2aa72", "Zell,Squall,Quistis,", "244644668824", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3526, 93, "b85d7ec3", "Rinoa,Irvine,Selphie,", "446446688242", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3527, 64, "8a409340", "Selphie,Irvine,Quistis,", "464466882428", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3528, 220, "addc6279", "Rinoa,Zell,Quistis,", "644668824288", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Quistis"),

            new PartyFormation(3529, 108, "0f6cfbbe", "Zell,Squall,Rinoa,", "446688242888", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Quistis"),

            new PartyFormation(3530, 15, "b90f441f", "Zell,Squall,Quistis,", "466882428886", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Quistis"),

            new PartyFormation(3531, 59, "013ba36c", "Zell,Squall,Irvine,", "668824288866", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Quistis"),

            new PartyFormation(3532, 183, "83b7ad35", "Selphie,Zell,Quistis,", "688242888666", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Quistis"),

            new PartyFormation(3533, 249, "77f915ca", "Zell,Squall,Quistis,", "882428886662", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Quistis"),

            new PartyFormation(3534, 238, "1dee033b", "Rinoa,Zell,Selphie,", "824288866624", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Quistis"),

            new PartyFormation(3535, 245, "bdf58a58", "Irvine,Squall,Rinoa,", "242888666242", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Quistis"),

            new PartyFormation(3536, 194, "09c2e7b1", "Rinoa,Zell,Selphie,", "428886662424", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(3537, 122, "ae7ac496", "Rinoa,Zell,Quistis,", "288866624244", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Quistis"),

            new PartyFormation(3538, 47, "d42f9817", "Selphie,Zell,Quistis,", "888666242446", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(3539, 100, "5164f404", "Zell,Squall,Irvine,", "886662424468", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Quistis"),

            new PartyFormation(3540, 109, "296d4ded", "Selphie,Squall,Quistis,", "866624244682", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Quistis"),

            new PartyFormation(3541, 150, "63969422", "Rinoa,Zell,Quistis,", "666242446824", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(3542, 139, "7c8b9eb3", "Irvine,Zell,Quistis,", "662424468246", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(3543, 63, "c33f4c70", "Rinoa,Irvine,Quistis,", "624244682466", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>41, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(3544, 221, "f9dddbe9", "Rinoa,Zell,Quistis,", "242446824662", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>40, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(3545, 173, "3badd06e", "Irvine,Zell,Selphie,", "424468246622", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(3546, 151, "8197730f", "Rinoa,Irvine,Selphie,", "244682466226", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(3547, 36, "1f24bf9c", "Selphie,Squall,Quistis,", "446824662268", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(3548, 175, "43af4da5", "Rinoa,Irvine,Quistis,", "468246622686", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(3549, 234, "2dea857a", "Irvine,Squall,Rinoa,", "682466226864", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(3550, 226, "37e2312b", "Selphie,Squall,Quistis,", "824662268644", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(3551, 140, "a88c3988", "Selphie,Rinoa,Quistis,", "246622686448", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(3552, 108, "846c1f21", "Zell,Squall,Selphie,", "466226864488", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(3553, 11, "c80b7f46", "Selphie,Squall,Quistis,", "662268644886", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3554, 208, "e3d0b507", "Rinoa,Irvine,Quistis,", "622686448868", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(3555, 111, "616f6634", "Zell,Squall,Irvine,", "226864488686", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(3556, 202, "adca8c5d", "Irvine,Squall,Quistis,", "268644886864", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(3557, 240, "e2f049d2", "Selphie,Zell,Quistis,", "686448868648", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(3558, 57, "41399aa3", "Rinoa,Zell,Selphie,", "864488686482", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(3559, 182, "4fb6b1a0", "Irvine,Zell,Selphie,", "644886864824", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(3560, 168, "9ca89159", "Irvine,Zell,Rinoa,", "448868648248", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3561, 229, "13e5311e", "Rinoa,Irvine,Selphie,", "488686482482", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3562, 193, "e8c13dff", "Selphie,Zell,Quistis,", "886864824822", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3563, 101, "ad6547cc", "Irvine,Squall,Selphie,", "868648248222", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3564, 199, "03c7ea15", "Rinoa,Squall,Selphie,", "686482482226", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3565, 175, "e6af412a", "Selphie,Rinoa,Quistis,", "864824822266", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3566, 245, "aef5bb1b", "Selphie,Irvine,Quistis,", "648248222662", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3567, 133, "ef8514b8", "Rinoa,Zell,Quistis,", "482482226622", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Selphie"),

            new PartyFormation(3568, 74, "464a1291", "Rinoa,Irvine,Quistis,", "824822266224", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Selphie"),

            new PartyFormation(3569, 88, "ac5845f6", "Irvine,Squall,Selphie,", "248222662248", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Selphie"),

            new PartyFormation(3570, 42, "d92aedf7", "Irvine,Squall,Quistis,", "482226622484", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Selphie"),

            new PartyFormation(3571, 210, "4fd2c464", "Rinoa,Squall,Selphie,", "822266224844", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Selphie"),

            new PartyFormation(3572, 236, "7dec46cd", "Rinoa,Squall,Quistis,", "222662248448", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Selphie"),

            new PartyFormation(3573, 186, "6abacb82", "Irvine,Squall,Selphie,", "226622484484", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Selphie"),

            new PartyFormation(3574, 22, "c4167293", "Irvine,Zell,Selphie,", "266224844844", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Selphie"),

            new PartyFormation(3575, 41, "4529c2d0", "Irvine,Zell,Selphie,", "662248448442", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(3576, 3, "a90382c9", "Rinoa,Squall,Quistis,", "622484484426", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(3577, 206, "38ce1dce", "Rinoa,Irvine,Selphie,", "224844844264", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(3578, 43, "582ba4ef", "Selphie,Zell,Quistis,", "248448442646", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(3579, 176, "16b03bfc", "Selphie,Squall,Quistis,", "484484426468", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(3580, 56, "bc388285", "Irvine,Squall,Rinoa,", "844844264688", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(3581, 178, "13b248da", "Rinoa,Squall,Selphie,", "448442646884", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(3582, 183, "67b7a10b", "Zell,Squall,Rinoa,", "484426468846", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(3583, 195, "75c31be8", "Zell,Squall,Irvine,", "844264688466", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(3584, 3, "1403c201", "Irvine,Zell,Quistis,", "442646884666", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(3585, 124, "f87c18a6", "Rinoa,Irvine,Quistis,", "426468846668", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(3586, 189, "d2bd42e7", "Irvine,Squall,Rinoa,", "264688466682", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3587, 162, "caa20e94", "Zell,Squall,Selphie,", "646884666824", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(3588, 233, "81e97d3d", "Irvine,Squall,Rinoa,", "468846668242", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(3589, 193, "cec11932", "Selphie,Rinoa,Quistis,", "688466682422", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(3590, 145, "0c912683", "Irvine,Zell,Selphie,", "884666824222", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(3591, 219, "9fdb8000", "Zell,Squall,Quistis,", "846668242226", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3592, 117, "f175b039", "Rinoa,Squall,Quistis,", "466682422262", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3593, 227, "6fe3967e", "Irvine,Squall,Selphie,", "666824222626", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3594, 53, "5f35a7df", "Irvine,Squall,Selphie,", "668242226262", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3595, 120, "58789c2c", "Rinoa,Irvine,Quistis,", "682422262628", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3596, 248, "60f816f5", "Irvine,Squall,Rinoa,", "824222626288", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3597, 30, "d71e9c8a", "Zell,Squall,Irvine,", "242226262884", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3598, 118, "0876e2fb", "Selphie,Squall,Quistis,", "422262628844", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3599, 233, "1ce94f18", "Selphie,Irvine,Quistis,", "222626288442", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3600, 0, "aa002d71", "Selphie,Zell,Quistis,", "226262884428", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(3601, 81, "4651f756", "Selphie,Rinoa,Quistis,", "262628844282", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(3602, 198, "0cc6b3d7", "Rinoa,Squall,Quistis,", "626288442824", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(3603, 176, "aab044c4", "Selphie,Zell,Quistis,", "262884428248", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(3604, 153, "55992fad", "Selphie,Zell,Quistis,", "628844282482", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(3605, 142, "eb8e32e2", "Rinoa,Squall,Selphie,", "288442824824", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(3606, 216, "5bd8b673", "Rinoa,Irvine,Selphie,", "884428248248", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(3607, 206, "72cee930", "Selphie,Squall,Quistis,", "844282482484", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Selphie"),

            new PartyFormation(3608, 70, "784619a9", "Irvine,Squall,Selphie,", "442824824844", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Selphie"),

            new PartyFormation(3609, 96, "53609b2e", "Irvine,Zell,Selphie,", "428248248448", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>2}", "Irvine,Zell,Selphie"),

            new PartyFormation(3610, 254, "a2fe46cf", "Irvine,Zell,Selphie,", "282482484484", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>1}", "Irvine,Zell,Selphie"),

            new PartyFormation(3611, 241, "32f1685c", "Selphie,Irvine,Quistis,", "824824844842", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3612, 189, "51bda765", "Rinoa,Irvine,Selphie,", "248248448422", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(3613, 223, "b3df3c3a", "Irvine,Squall,Selphie,", "482484484226", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(3614, 66, "e94280eb", "Rinoa,Zell,Quistis,", "824844842264", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(3615, 90, "f55aae48", "Irvine,Zell,Selphie,", "248448422644", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(3616, 102, "2c6654e1", "Irvine,Zell,Rinoa,", "484484226444", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(3617, 116, "dc74e206", "Selphie,Zell,Quistis,", "844842264448", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3618, 70, "d14640c7", "Irvine,Zell,Selphie,", "448422644484", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(3619, 144, "239066f4", "Rinoa,Irvine,Selphie,", "484226444848", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(3620, 146, "b8925e1d", "Selphie,Rinoa,Quistis,", "842264448484", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(3621, 109, "566d1892", "Rinoa,Zell,Quistis,", "422644484842", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(3622, 220, "1cdc2263", "Zell,Squall,Selphie,", "226444848428", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(3623, 198, "17c6fe60", "Rinoa,Squall,Selphie,", "264448484284", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(3624, 123, "df7bbf19", "Irvine,Zell,Quistis,", "644484842846", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(3625, 64, "02402bde", "Rinoa,Irvine,Quistis,", "444848428468", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3626, 100, "ce6481bf", "Rinoa,Zell,Selphie,", "448484284688", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3627, 13, "590da08c", "Zell,Squall,Irvine,", "484842846882", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3628, 0, "ca0033d5", "Irvine,Squall,Rinoa,", "848428468828", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3629, 159, "3d9f27ea", "Irvine,Squall,Rinoa,", "484284688286", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3630, 233, "03e97adb", "Selphie,Irvine,Quistis,", "842846882862", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3631, 58, "6e3a3978", "Irvine,Zell,Selphie,", "428468828624", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Selphie"),

            new PartyFormation(3632, 29, "971d3851", "Selphie,Zell,Quistis,", "284688286242", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Selphie"),

            new PartyFormation(3633, 63, "5e3fd8b6", "Irvine,Squall,Quistis,", "846882862426", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Selphie"),

            new PartyFormation(3634, 250, "67fae9b7", "Zell,Squall,Irvine,", "468828624264", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Selphie"),

            new PartyFormation(3635, 149, "f3957524", "Rinoa,Squall,Quistis,", "688286242642", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(3636, 44, "fe2c088d", "Rinoa,Squall,Selphie,", "882862426428", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(3637, 104, "0d68ca42", "Zell,Squall,Rinoa,", "828624264288", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(3638, 74, "d44a6a53", "Zell,Squall,Irvine,", "286242642884", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(3639, 70, "5f46bf90", "Rinoa,Squall,Selphie,", "862426428844", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(3640, 221, "d8dda089", "Rinoa,Zell,Quistis,", "624264288442", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(3641, 61, "d03d488e", "Zell,Squall,Quistis,", "242642884422", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(3642, 7, "820758af", "Irvine,Squall,Quistis,", "426428844226", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(3643, 128, "a08044bc", "Zell,Squall,Rinoa,", "264288442268", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(3644, 246, "50f6bc45", "Rinoa,Squall,Quistis,", "642884422684", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(3645, 201, "c8c95f9a", "Rinoa,Irvine,Selphie,", "428844226842", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(3646, 250, "e3fad0cb", "Zell,Squall,Selphie,", "288442268424", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3647, 106, "856af0a8", "Selphie,Squall,Quistis,", "884422684244", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(3648, 203, "2dcbd7c1", "Zell,Squall,Quistis,", "844226842446", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(3649, 205, "7bcddb66", "Irvine,Zell,Rinoa,", "442268424462", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(3650, 99, "0663aea7", "Zell,Squall,Irvine,", "422684244626", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(3651, 210, "93d26f54", "Rinoa,Squall,Quistis,", "226842446264", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(3652, 125, "7d7d2efd", "Irvine,Squall,Quistis,", "268424462642", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(3653, 76, "274c47f2", "Zell,Squall,Irvine,", "684244626428", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(3654, 146, "10928e43", "Rinoa,Irvine,Selphie,", "842446264284", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(3655, 145, "c0912cc0", "Rinoa,Irvine,Quistis,", "424462642842", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Selphie"),

            new PartyFormation(3656, 242, "95f2bdf9", "Irvine,Zell,Selphie,", "244626428424", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Selphie"),

            new PartyFormation(3657, 210, "f5d2f13e", "Zell,Squall,Selphie,", "446264284244", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3658, 69, "4445cb9f", "Zell,Squall,Rinoa,", "462642842442", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3659, 188, "31bc54ec", "Selphie,Irvine,Quistis,", "626428424428", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3660, 152, "299840b5", "Irvine,Squall,Rinoa,", "264284244288", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Quistis"),

            new PartyFormation(3661, 136, "1a88e34a", "Irvine,Zell,Quistis,", "642842442888", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Quistis"),

            new PartyFormation(3662, 197, "96c582bb", "Rinoa,Irvine,Quistis,", "428424428882", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>52, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Selphie"),

            new PartyFormation(3663, 143, "f78fd3d8", "Rinoa,Squall,Selphie,", "284244288826", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>51, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Selphie"),

            new PartyFormation(3664, 217, "ebd93331", "Irvine,Squall,Rinoa,", "842442888262", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>50, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Selphie"),

            new PartyFormation(3665, 249, "a1f9ea16", "Rinoa,Irvine,Selphie,", "424428882622", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>49, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Selphie"),

            new PartyFormation(3666, 191, "bfbf8f97", "Irvine,Squall,Quistis,", "244288826226", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>48, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Selphie"),

            new PartyFormation(3667, 26, "681a5584", "Selphie,Squall,Quistis,", "442888262264", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>47, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Selphie"),

            new PartyFormation(3668, 92, "015cd16d", "Zell,Squall,Irvine,", "428882622648", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>46, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Selphie"),

            new PartyFormation(3669, 162, "83a291a2", "Irvine,Squall,Rinoa,", "288826226484", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>45, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Selphie"),

            new PartyFormation(3670, 227, "59e38e33", "Rinoa,Zell,Selphie,", "888262264846", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>44, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(3671, 169, "89a945f0", "Selphie,Rinoa,Quistis,", "882622648462", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>43, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(3672, 2, "38021769", "Zell,Squall,Irvine,", "826226484624", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>42, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(3673, 60, "403c25ee", "Zell,Squall,Selphie,", "262264846248", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>41, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(3674, 62, "713eda8f", "Zell,Squall,Selphie,", "622648462484", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>40, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(3675, 244, "b7f4d11c", "Zell,Squall,Rinoa,", "226484624848", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(3676, 155, "c29bc125", "Selphie,Rinoa,Quistis,", "264846248486", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(3677, 200, "18c8b2fa", "Selphie,Rinoa,Quistis,", "648462484868", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(3678, 88, "9b5890ab", "Selphie,Zell,Quistis,", "484624848688", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(3679, 11, "700be308", "Irvine,Squall,Quistis,", "846248486886", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(3680, 108, "f46c4aa1", "Selphie,Rinoa,Quistis,", "462484868868", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(3681, 95, "aa5f04c6", "Irvine,Zell,Selphie,", "624848688686", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3682, 13, "750d8c87", "Rinoa,Zell,Selphie,", "248486886862", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(3683, 0, "ef0027b4", "Zell,Squall,Rinoa,", "484868868628", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(3684, 97, "3861efdd", "Zell,Squall,Quistis,", "848688686282", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(3685, 182, "7ab6a752", "Rinoa,Irvine,Selphie,", "486886862824", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(3686, 44, "222c6a23", "Rinoa,Squall,Selphie,", "868868628248", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(3687, 82, "0f520b20", "Selphie,Squall,Quistis,", "688686282484", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(3688, 18, "4012acd9", "Irvine,Zell,Selphie,", "886862824844", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(3689, 115, "c173e69e", "Rinoa,Squall,Quistis,", "868628248446", "{Irvine,Zell,Selphie=>50, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3690, 209, "2ad1857f", "Irvine,Zell,Rinoa,", "686282484462", "{Irvine,Zell,Selphie=>49, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3691, 28, "911cb94c", "Rinoa,Irvine,Selphie,", "862824844628", "{Irvine,Zell,Selphie=>48, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3692, 120, "26783d95", "Zell,Squall,Irvine,", "628248446288", "{Irvine,Zell,Selphie=>47, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3693, 51, "7a33ceaa", "Zell,Squall,Rinoa,", "282484462886", "{Irvine,Zell,Selphie=>46, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3694, 130, "d282fa9b", "Selphie,Irvine,Quistis,", "824844628864", "{Irvine,Zell,Selphie=>45, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3695, 2, "b9021e38", "Zell,Squall,Irvine,", "248446288644", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3696, 108, "026c1e11", "Rinoa,Squall,Selphie,", "484462886448", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3697, 88, "8b582b76", "Rinoa,Irvine,Quistis,", "844628864488", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3698, 12, "c50ca577", "Rinoa,Squall,Selphie,", "446288644888", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3699, 214, "f1d6e5e4", "Irvine,Squall,Rinoa,", "462886448884", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3700, 227, "24e38a4d", "Irvine,Zell,Rinoa,", "628864488846", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3701, 147, "8d938902", "Rinoa,Irvine,Quistis,", "288644888466", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3702, 28, "b51c2213", "Selphie,Squall,Quistis,", "886448884668", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3703, 14, "dd0e7c50", "Selphie,Rinoa,Quistis,", "864488846684", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3704, 235, "feeb7e49", "Irvine,Zell,Rinoa,", "644888466846", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3705, 53, "8035334e", "Selphie,Irvine,Quistis,", "448884668462", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3706, 156, "489ccc6f", "Zell,Squall,Rinoa,", "488846684628", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3707, 231, "fde70d7c", "Zell,Squall,Quistis,", "888466846286", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3708, 100, "6b64b605", "Irvine,Squall,Rinoa,", "884668462868", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3709, 53, "7635365a", "Selphie,Zell,Quistis,", "846684628682", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3710, 211, "6ed3c08b", "Irvine,Squall,Quistis,", "466846286826", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3711, 85, "eb558568", "Selphie,Irvine,Quistis,", "668462868262", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3712, 127, "d87fad81", "Zell,Squall,Quistis,", "684628682626", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Quistis"),

            new PartyFormation(3713, 0, "08005e26", "Irvine,Zell,Rinoa,", "846286826268", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>2}", "Irvine,Zell,Quistis"),

            new PartyFormation(3714, 59, "fc3bda67", "Irvine,Zell,Quistis,", "462868262686", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>1}", "Irvine,Zell,Quistis"),

            new PartyFormation(3715, 177, "b4b19014", "Selphie,Irvine,Quistis,", "628682626862", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3716, 248, "8cf8a0bd", "Rinoa,Squall,Selphie,", "286826268628", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3717, 4, "160436b2", "Zell,Squall,Selphie,", "868262686288", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3718, 33, "2821b603", "Irvine,Squall,Quistis,", "682626862882", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3719, 33, "e5219980", "Rinoa,Irvine,Selphie,", "826268628822", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3720, 19, "05138bb9", "Selphie,Rinoa,Quistis,", "262686288226", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3721, 251, "27fb0bfe", "Irvine,Squall,Selphie,", "626862882266", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3722, 255, "47ffaf5f", "Irvine,Squall,Rinoa,", "268628822666", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3723, 198, "51c6cdac", "Selphie,Irvine,Quistis,", "686288226664", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3724, 88, "23582a75", "Selphie,Squall,Quistis,", "862882266648", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(3725, 247, "74f7ea0a", "Rinoa,Zell,Selphie,", "628822666486", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(3726, 153, "e499e27b", "Irvine,Zell,Quistis,", "288226664862", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(3727, 169, "9ea91898", "Irvine,Squall,Selphie,", "882266648622", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(3728, 13, "b10df8f1", "Rinoa,Zell,Selphie,", "822666486222", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(3729, 50, "60329cd6", "Zell,Squall,Irvine,", "226664862224", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(3730, 218, "04da2b57", "Irvine,Squall,Selphie,", "266648622244", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(3731, 99, "26632644", "Rinoa,Irvine,Quistis,", "666486222446", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(3732, 120, "6a78332d", "Rinoa,Irvine,Selphie,", "664862224468", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(3733, 147, "f693b062", "Zell,Squall,Irvine,", "648622244686", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(3734, 108, "4a6c25f3", "Selphie,Rinoa,Quistis,", "486222446868", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(3735, 142, "b08e62b0", "Zell,Squall,Selphie,", "862224468684", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(3736, 209, "92d1d529", "Irvine,Zell,Quistis,", "622244686842", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(3737, 0, "b90070ae", "Selphie,Rinoa,Quistis,", "222446868428", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(3738, 25, "3c192e4f", "Irvine,Squall,Selphie,", "224468684282", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(3739, 238, "22eef9dc", "Irvine,Zell,Selphie,", "244686842824", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(3740, 9, "cc099ae5", "Zell,Squall,Selphie,", "446868428242", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3741, 102, "bf66e9ba", "Zell,Squall,Selphie,", "468684282424", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3742, 228, "d9e4606b", "Irvine,Squall,Quistis,", "686842824248", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3743, 95, "195fd7c8", "Selphie,Rinoa,Quistis,", "868428242486", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3744, 62, "ae3e0061", "Zell,Squall,Quistis,", "684282424864", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3745, 137, "0089e786", "Rinoa,Zell,Selphie,", "842824248642", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3746, 230, "56e69847", "Selphie,Irvine,Quistis,", "428242486424", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3747, 126, "107ea874", "Rinoa,Squall,Selphie,", "282424864244", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Quistis"),

            new PartyFormation(3748, 249, "5af9419d", "Rinoa,Zell,Quistis,", "824248642442", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Quistis"),

            new PartyFormation(3749, 140, "4a8cf612", "Rinoa,Irvine,Selphie,", "242486424428", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Quistis"),

            new PartyFormation(3750, 234, "94ea71e3", "Irvine,Squall,Selphie,", "424864244284", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Quistis"),

            new PartyFormation(3751, 23, "8f17d7e0", "Rinoa,Zell,Selphie,", "248642442846", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(3752, 45, "082d5a99", "Zell,Squall,Selphie,", "486424428462", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Quistis"),

            new PartyFormation(3753, 64, "3840615e", "Zell,Squall,Quistis,", "864244284628", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(3754, 200, "bdc8493f", "Irvine,Squall,Rinoa,", "642442846288", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Quistis"),

            new PartyFormation(3755, 82, "7a52920c", "Selphie,Squall,Quistis,", "424428462884", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Quistis"),

            new PartyFormation(3756, 240, "3ef00755", "Rinoa,Squall,Quistis,", "244284628848", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(3757, 45, "2f2d356a", "Irvine,Squall,Selphie,", "442846288482", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(3758, 130, "16823a5b", "Irvine,Zell,Quistis,", "428462884824", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(3759, 156, "809cc2f8", "Selphie,Zell,Quistis,", "284628848248", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(3760, 246, "49f6c3d1", "Selphie,Squall,Quistis,", "846288482484", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(3761, 97, "32613e36", "Irvine,Zell,Quistis,", "462884824842", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(3762, 32, "e8202137", "Zell,Squall,Rinoa,", "628848248428", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(3763, 87, "475716a4", "Irvine,Zell,Selphie,", "288482484286", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(3764, 210, "0fd2cc0d", "Rinoa,Zell,Selphie,", "884824842864", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(3765, 251, "15fb07c2", "Irvine,Zell,Selphie,", "848248428646", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(3766, 75, "1a4b99d3", "Selphie,Zell,Quistis,", "482484286466", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(3767, 64, "c740f910", "Zell,Squall,Rinoa,", "824842864668", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(3768, 237, "54ed1c09", "Rinoa,Zell,Selphie,", "248428646682", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(3769, 117, "5f75de0e", "Rinoa,Irvine,Selphie,", "484286466822", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(3770, 172, "dbac002f", "Rinoa,Irvine,Selphie,", "842864668228", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(3771, 164, "03a4963c", "Irvine,Zell,Rinoa,", "428646682288", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(3772, 66, "21426fc5", "Rinoa,Squall,Selphie,", "286466822884", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(3773, 181, "deb5cd1a", "Zell,Squall,Irvine,", "864668228842", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(3774, 2, "7402704b", "Rinoa,Squall,Quistis,", "646682288424", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(3775, 66, "0842da28", "Zell,Squall,Quistis,", "466822884244", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(3776, 223, "c5df4341", "Irvine,Squall,Selphie,", "668228842446", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(3777, 211, "cbd3a0e6", "Irvine,Zell,Quistis,", "682288424466", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(3778, 5, "1c05c627", "Selphie,Zell,Quistis,", "822884244662", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3779, 255, "d9ff70d4", "Selphie,Squall,Quistis,", "228842446626", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3780, 27, "be1bd27d", "Zell,Squall,Selphie,", "288424466266", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3781, 168, "f5a8e572", "Selphie,Irvine,Quistis,", "884244662668", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3782, 254, "76fe9dc3", "Rinoa,Irvine,Selphie,", "842446626684", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(3783, 76, "c64cc640", "Rinoa,Zell,Quistis,", "424466266848", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(3784, 152, "68981979", "Rinoa,Squall,Selphie,", "244662668488", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(3785, 27, "4d1be6be", "Irvine,Zell,Selphie,", "446626684886", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Selphie"),

            new PartyFormation(3786, 35, "0a23531f", "Irvine,Zell,Quistis,", "466266848866", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Quistis"),

            new PartyFormation(3787, 88, "3d58066c", "Irvine,Zell,Quistis,", "662668488668", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>2}", "Irvine,Zell,Quistis"),

            new PartyFormation(3788, 247, "53f7d435", "Rinoa,Zell,Quistis,", "626684886686", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3789, 43, "d92bb0ca", "Selphie,Irvine,Quistis,", "266848866866", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3790, 180, "cdb4023b", "Selphie,Squall,Quistis,", "668488668668", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3791, 245, "22f51d58", "Irvine,Squall,Quistis,", "684886686682", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3792, 94, "9b5e7eb1", "Zell,Squall,Irvine,", "848866866824", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3793, 188, "dfbc0f96", "Irvine,Squall,Selphie,", "488668668248", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3794, 214, "b3d68717", "Selphie,Irvine,Quistis,", "886686682484", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3795, 74, "424ab704", "Rinoa,Zell,Selphie,", "866866824844", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(3796, 171, "8eab54ed", "Zell,Squall,Irvine,", "668668248446", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(3797, 33, "cf218f22", "Selphie,Squall,Quistis,", "686682484462", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(3798, 50, "c1327db3", "Selphie,Squall,Quistis,", "866824844624", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(3799, 62, "503e3f70", "Irvine,Zell,Quistis,", "668248446244", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),
        };


        public static PartyFormation[] PartyFormations = new[]
        {

            new PartyFormation(1800, 122, "f27aaf39", "Zell,Squall,Irvine", "888666688824", "{Irvine,Zell,Selphie=>50, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1801, 182, "9eb6297e", "Rinoa,Zell,Quistis", "886666888244", "{Irvine,Zell,Selphie=>49, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1802, 168, "29a83edf", "Selphie,Irvine,Quistis", "866668882448", "{Irvine,Zell,Selphie=>48, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1803, 68, "3f44e72c", "Selphie,Squall,Quistis", "666688824488", "{Irvine,Zell,Selphie=>47, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(1804, 206, "e6ce05f5", "Selphie,Zell,Quistis", "666888244884", "{Irvine,Zell,Selphie=>46, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(1805, 7, "dc075f8a", "Rinoa,Irvine,Selphie", "668882448846", "{Irvine,Zell,Selphie=>45, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(1806, 251, "dcfbe9fb", "Zell,Squall,Quistis", "688824488466", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(1807, 175, "8baf4a18", "Rinoa,Irvine,Quistis", "888244884666", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(1808, 198, "48c60c71", "Irvine,Squall,Rinoa", "882448846664", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(1809, 131, "a483ea56", "Zell,Squall,Selphie", "824488466646", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(1810, 21, "52152ad7", "Irvine,Zell,Rinoa", "244884666462", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(1811, 90, "1f5aefc4", "Irvine,Squall,Rinoa", "448846664624", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(1812, 93, "445dfead", "Zell,Squall,Selphie", "488466646242", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(1813, 108, "a66c55e2", "Zell,Squall,Rinoa", "884666462428", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(1814, 23, "ad179d73", "Zell,Squall,Irvine", "846664624286", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(1815, 249, "def94430", "Irvine,Zell,Quistis", "466646242862", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(1816, 8, "d008d8a9", "Irvine,Squall,Rinoa", "666462428628", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1817, 125, "c17dee2e", "Zell,Squall,Quistis", "664624286282", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1818, 196, "a6c49dcf", "Irvine,Zell,Rinoa", "646242862828", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1819, 230, "86e6735c", "Selphie,Irvine,Quistis", "462428628284", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1820, 109, "3c6d5665", "Irvine,Zell,Quistis", "624286282842", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(1821, 254, "81febf3a", "Irvine,Squall,Selphie", "242862828424", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(1822, 151, "989747eb", "Selphie,Squall,Quistis", "428628284246", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(1823, 21, "5b156948", "Rinoa,Squall,Quistis", "286282842462", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(1824, 225, "03e1f3e1", "Zell,Squall,Quistis", "862828424622", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(1825, 137, "40899506", "Irvine,Squall,Selphie", "628284246222", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(1826, 160, "2ea077c7", "Zell,Squall,Rinoa", "282842462228", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(1827, 187, "e9bbd1f4", "Rinoa,Irvine,Selphie", "828424622286", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(1828, 168, "15a8ed1d", "Rinoa,Irvine,Quistis", "284246222868", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(1829, 153, "7299fb92", "Rinoa,Irvine,Quistis", "842462228682", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(1830, 34, "5b22c963", "Zell,Squall,Irvine", "424622286824", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(1831, 190, "4cbe1960", "Rinoa,Irvine,Selphie", "246222868244", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(1832, 236, "98ec3e19", "Rinoa,Irvine,Quistis", "462228682448", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(1833, 216, "77d83ede", "Zell,Squall,Selphie", "622286824488", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(1834, 238, "e7ee98bf", "Zell,Squall,Selphie", "222868244884", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(1835, 219, "15db6b8c", "Rinoa,Squall,Selphie", "228682448846", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(1836, 121, "e379a2d5", "Rinoa,Zell,Selphie", "286824488462", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(1837, 37, "f0256aea", "Rinoa,Squall,Quistis", "868244884622", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(1838, 126, "c17e01db", "Zell,Squall,Rinoa", "682448846224", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(1839, 153, "d199b478", "Irvine,Zell,Quistis", "824488462242", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(1840, 62, "203e9751", "Irvine,Squall,Selphie", "244884622424", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1841, 103, "66674bb6", "Selphie,Squall,Quistis", "448846224246", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1842, 208, "d7d0e0b7", "Zell,Squall,Selphie", "488462242468", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1843, 241, "ccf1a024", "Rinoa,Irvine,Quistis", "884622424682", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1844, 132, "e184578d", "Selphie,Irvine,Quistis", "846224246828", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1845, 20, "dc146d42", "Zell,Squall,Rinoa", "462242468288", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1846, 8, "3108d153", "Zell,Squall,Selphie", "622424682888", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1847, 186, "89ba9a90", "Selphie,Rinoa,Quistis", "224246828884", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1848, 235, "9aebdf89", "Selphie,Irvine,Quistis", "242468288846", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1849, 128, "81801b8e", "Rinoa,Squall,Selphie", "424682888468", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Selphie"),

            new PartyFormation(1850, 197, "89c52faf", "Irvine,Zell,Selphie", "246828884682", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(1851, 214, "0dd6cfbc", "Rinoa,Irvine,Selphie", "468288846824", "{Irvine,Zell,Selphie=>73, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(1852, 41, "bf29eb45", "Selphie,Zell,Quistis", "682888468242", "{Irvine,Zell,Selphie=>72, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(1853, 230, "a6e6629a", "Zell,Squall,Quistis", "828884682424", "{Irvine,Zell,Selphie=>71, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(1854, 63, "9f3f17cb", "Selphie,Squall,Quistis", "288846824246", "{Irvine,Zell,Selphie=>70, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(1855, 31, "f91f2ba8", "Irvine,Squall,Rinoa", "888468242466", "{Irvine,Zell,Selphie=>69, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(1856, 130, "fd82f6c1", "Selphie,Squall,Quistis", "884682424664", "{Irvine,Zell,Selphie=>68, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(1857, 56, "b2380e66", "Rinoa,Irvine,Selphie", "846824246648", "{Irvine,Zell,Selphie=>67, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(1858, 37, "ff2565a7", "Irvine,Zell,Rinoa", "468242466482", "{Irvine,Zell,Selphie=>66, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(1859, 15, "0e0f5a54", "Rinoa,Zell,Selphie", "682424664826", "{Irvine,Zell,Selphie=>65, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(1860, 7, "db073dfd", "Zell,Squall,Quistis", "824246648266", "{Irvine,Zell,Selphie=>64, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(1861, 166, "a5a6aaf2", "Rinoa,Irvine,Selphie", "242466482664", "{Irvine,Zell,Selphie=>63, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(1862, 56, "f938b543", "Irvine,Zell,Quistis", "424664826648", "{Irvine,Zell,Selphie=>62, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(1863, 49, "9931c7c0", "Zell,Squall,Selphie", "246648266482", "{Irvine,Zell,Selphie=>61, Irvine,Zell,Quistis=>54, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1864, 142, "a38ebcf9", "Zell,Squall,Rinoa", "466482664824", "{Irvine,Zell,Selphie=>60, Irvine,Zell,Quistis=>53, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1865, 240, "82f0843e", "Irvine,Squall,Quistis", "664826648248", "{Irvine,Zell,Selphie=>59, Irvine,Zell,Quistis=>52, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1866, 167, "0ea7629f", "Rinoa,Irvine,Selphie", "648266482486", "{Irvine,Zell,Selphie=>58, Irvine,Zell,Quistis=>51, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1867, 75, "e34b9fec", "Zell,Squall,Irvine", "482664824866", "{Irvine,Zell,Selphie=>57, Irvine,Zell,Quistis=>50, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1868, 117, "6e752fb5", "Irvine,Zell,Rinoa", "826648248662", "{Irvine,Zell,Selphie=>56, Irvine,Zell,Quistis=>49, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1869, 108, "976ca64a", "Irvine,Squall,Rinoa", "266482486628", "{Irvine,Zell,Selphie=>55, Irvine,Zell,Quistis=>48, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1870, 41, "fb2989bb", "Rinoa,Irvine,Quistis", "664824866282", "{Irvine,Zell,Selphie=>54, Irvine,Zell,Quistis=>47, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1871, 72, "9a48ced8", "Irvine,Zell,Rinoa", "648248662828", "{Irvine,Zell,Selphie=>53, Irvine,Zell,Quistis=>46, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1872, 22, "b3161231", "Irvine,Squall,Rinoa", "482486628284", "{Irvine,Zell,Selphie=>52, Irvine,Zell,Quistis=>45, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1873, 214, "7cd6dd16", "Irvine,Squall,Rinoa", "824866282844", "{Irvine,Zell,Selphie=>51, Irvine,Zell,Quistis=>44, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1874, 221, "33dd0697", "Selphie,Irvine,Quistis", "248662828442", "{Irvine,Zell,Selphie=>50, Irvine,Zell,Quistis=>43, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1875, 232, "dce80084", "Irvine,Squall,Quistis", "486628284428", "{Irvine,Zell,Selphie=>49, Irvine,Zell,Quistis=>42, Selphie,Irvine,Quistis=>26}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1876, 8, "a908a06d", "Zell,Squall,Irvine", "866282844288", "{Irvine,Zell,Selphie=>48, Irvine,Zell,Quistis=>41, Selphie,Irvine,Quistis=>25}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1877, 219, "5adbb4a2", "Irvine,Squall,Quistis", "662828442886", "{Irvine,Zell,Selphie=>47, Irvine,Zell,Quistis=>40, Selphie,Irvine,Quistis=>24}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1878, 225, "77e17533", "Rinoa,Zell,Selphie", "628284428862", "{Irvine,Zell,Selphie=>46, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>23}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1879, 38, "5526a0f0", "Selphie,Rinoa,Quistis", "282844288624", "{Irvine,Zell,Selphie=>45, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>22}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1880, 27, "701bd669", "Selphie,Zell,Quistis", "828442886246", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>21}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1881, 100, "b56478ee", "Irvine,Squall,Quistis", "284428862468", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>20}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1882, 180, "ceb4318f", "Irvine,Squall,Selphie", "844288624688", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>19}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1883, 108, "8d6cdc1c", "Rinoa,Squall,Selphie", "442886246888", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>18}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1884, 18, "bc127025", "Irvine,Squall,Quistis", "428862468884", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>17}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1885, 163, "d3a335fa", "Zell,Squall,Rinoa", "288624688846", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>16}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1886, 76, "104c57ab", "Irvine,Squall,Rinoa", "886246888468", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>15}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1887, 121, "6c799e08", "Rinoa,Irvine,Selphie", "862468884682", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>14}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1888, 30, "801ee9a1", "Rinoa,Irvine,Selphie", "624688846824", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>13}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1889, 222, "8bdeb7c6", "Irvine,Squall,Quistis", "246888468244", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1890, 246, "d2f6c387", "Rinoa,Zell,Quistis", "468884682444", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1891, 14, "840e92b4", "Rinoa,Zell,Quistis", "688846824444", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1892, 31, "d61f7edd", "Selphie,Zell,Quistis", "888468244446", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1893, 254, "fffe8a52", "Irvine,Squall,Quistis", "884682444464", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1894, 242, "5af21123", "Zell,Squall,Irvine", "846824444644", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1895, 92, "9e5c2620", "Zell,Squall,Quistis", "468244446448", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1896, 154, "1d9a2bd9", "Zell,Squall,Quistis", "682444464484", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1897, 214, "96d6f99e", "Rinoa,Squall,Selphie", "824444644844", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1898, 202, "e7ca9c7f", "Irvine,Squall,Selphie", "244446448444", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1899, 45, "b62d844c", "Zell,Squall,Quistis", "444464484442", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1900, 120, "0e78ac95", "Irvine,Squall,Rinoa", "444644844428", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1901, 53, "3e3511aa", "Selphie,Irvine,Quistis", "446448444282", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1902, 118, "7b76819b", "Irvine,Squall,Selphie", "464484442824", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1903, 212, "45d49938", "Selphie,Rinoa,Quistis", "644844428248", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1904, 132, "3b847d11", "Selphie,Squall,Quistis", "448444282488", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1905, 170, "c1aa9e76", "Selphie,Squall,Quistis", "484442824884", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1906, 49, "f7319c77", "Zell,Squall,Quistis", "844428248842", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1907, 214, "98d610e4", "Rinoa,Squall,Quistis", "444282488424", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1908, 162, "40a2d94d", "Rinoa,Squall,Selphie", "442824884244", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1909, 26, "c21a2c02", "Rinoa,Squall,Quistis", "428248842444", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1910, 25, "2a198913", "Rinoa,Squall,Selphie", "282488424442", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1911, 85, "8c555750", "Selphie,Irvine,Quistis", "824884244422", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1912, 208, "98d0bd49", "Zell,Squall,Quistis", "248842444228", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(1913, 3, "9a03064e", "Irvine,Squall,Rinoa", "488424442286", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Quistis"),

            new PartyFormation(1914, 137, "2d89a36f", "Selphie,Zell,Quistis", "884244422862", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(1915, 64, "ea40987c", "Rinoa,Squall,Quistis", "842444228628", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Quistis"),

            new PartyFormation(1916, 222, "d7dee505", "Zell,Squall,Quistis", "424442286284", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Quistis"),

            new PartyFormation(1917, 141, "3a8d395a", "Irvine,Zell,Quistis", "244422862842", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(1918, 55, "2b37078b", "Selphie,Squall,Quistis", "444228628426", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(1919, 60, "4b3cc068", "Rinoa,Zell,Selphie", "442286284268", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(1920, 237, "c3edcc81", "Rinoa,Irvine,Selphie", "422862842682", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(1921, 85, "cd559126", "Rinoa,Irvine,Quistis", "228628426822", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(1922, 12, "690c9167", "Zell,Squall,Irvine", "286284268228", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(1923, 81, "2b517b14", "Rinoa,Irvine,Quistis", "862842682282", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(1924, 169, "8aa9afbd", "Irvine,Zell,Selphie", "628426822822", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(1925, 249, "a6f999b2", "Selphie,Rinoa,Quistis", "284268228222", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>17}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1926, 198, "36c6dd03", "Selphie,Rinoa,Quistis", "842682282224", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>16}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1927, 85, "9d553480", "Rinoa,Squall,Selphie", "426822822242", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>15}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1928, 70, "0e468ab9", "Irvine,Zell,Rinoa", "268228222424", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>14}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1929, 99, "d6639efe", "Irvine,Squall,Quistis", "682282224246", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>13}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1930, 80, "1950465f", "Rinoa,Zell,Selphie", "822822242468", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1931, 25, "c91918ac", "Selphie,Zell,Quistis", "228222424682", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1932, 60, "063c1975", "Selphie,Zell,Quistis", "282224246828", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1933, 214, "5cd6ad0a", "Zell,Squall,Irvine", "822242468284", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1934, 220, "4fdce97b", "Zell,Squall,Irvine", "222424682848", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1935, 85, "20551398", "Irvine,Squall,Selphie", "224246828482", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1936, 193, "6fc1d7f1", "Irvine,Zell,Rinoa", "242468284822", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1937, 186, "daba8fd6", "Rinoa,Squall,Selphie", "424682848224", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1938, 198, "8ec6a257", "Zell,Squall,Irvine", "246828482244", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1939, 83, "f653d144", "Zell,Squall,Rinoa", "468284822446", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1940, 11, "8a0b022d", "Rinoa,Irvine,Quistis", "682848224466", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1941, 39, "3d27d362", "Zell,Squall,Irvine", "828482244666", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1942, 41, "8c290cf3", "Selphie,Irvine,Quistis", "284822446662", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1943, 94, "e65ebdb0", "Irvine,Squall,Rinoa", "848224466624", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(1944, 66, "5a429429", "Irvine,Zell,Quistis", "482244666244", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(1945, 51, "b833c3ae", "Zell,Squall,Rinoa", "822446662446", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(1946, 61, "ba3d854f", "Rinoa,Squall,Selphie", "224466624462", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(1947, 234, "34ea04dc", "Selphie,Zell,Quistis", "244666244624", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(1948, 71, "734749e5", "Rinoa,Squall,Selphie", "446662446246", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(1949, 252, "19fc6cba", "Rinoa,Squall,Quistis", "466624462468", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(1950, 119, "4b77276b", "Rinoa,Irvine,Quistis", "666244624686", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(1951, 128, "178092c8", "Zell,Squall,Irvine", "662446246868", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Selphie"),

            new PartyFormation(1952, 39, "7d279f61", "Rinoa,Irvine,Selphie", "624462468686", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Selphie"),

            new PartyFormation(1953, 116, "42749a86", "Irvine,Zell,Selphie", "244624686868", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>2}", "Irvine,Zell,Selphie"),

            new PartyFormation(1954, 94, "5c5ecf47", "Irvine,Zell,Rinoa", "446246868684", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1955, 112, "8f701374", "Selphie,Irvine,Quistis", "462468686848", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1956, 93, "b85dd09d", "Irvine,Zell,Selphie", "624686868482", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(1957, 239, "4befd912", "Rinoa,Squall,Selphie", "246868684826", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1958, 47, "df2f18e3", "Zell,Squall,Selphie", "468686848266", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1959, 52, "4334f2e0", "Zell,Squall,Rinoa", "686868482668", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1960, 203, "78cbd999", "Rinoa,Zell,Selphie", "868684826686", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1961, 110, "b06e745e", "Rinoa,Squall,Selphie", "686848266864", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1962, 48, "a530603f", "Irvine,Squall,Rinoa", "868482668648", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1963, 166, "82a65d0c", "Rinoa,Zell,Selphie", "684826686484", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1964, 119, "54777655", "Zell,Squall,Selphie", "848266864846", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1965, 169, "77a9786a", "Zell,Squall,Selphie", "482668648462", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1966, 212, "a1d4c15b", "Selphie,Zell,Quistis", "826686484628", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1967, 226, "61e23df8", "Selphie,Zell,Quistis", "266864846284", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1968, 6, "820622d1", "Rinoa,Irvine,Selphie", "668648462844", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1969, 222, "39deb136", "Selphie,Irvine,Quistis", "686484628444", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(1970, 148, "43941837", "Rinoa,Zell,Quistis", "864846284448", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>41}", "Irvine,Zell,Selphie"),

            new PartyFormation(1971, 249, "96f941a4", "Zell,Squall,Irvine", "648462844482", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>40}", "Irvine,Zell,Selphie"),

            new PartyFormation(1972, 249, "a2f91b0d", "Irvine,Zell,Selphie", "484628444822", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>39}", "Irvine,Zell,Selphie"),

            new PartyFormation(1973, 92, "835caac2", "Irvine,Zell,Quistis", "846284448228", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Quistis"),

            new PartyFormation(1974, 136, "7e8800d3", "Zell,Squall,Selphie", "462844482288", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Selphie"),

            new PartyFormation(1975, 90, "865ad410", "Zell,Squall,Quistis", "628444822884", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Selphie"),

            new PartyFormation(1976, 169, "f5a95b09", "Irvine,Zell,Selphie", "284448228842", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Selphie"),

            new PartyFormation(1977, 206, "e4ceb10e", "Zell,Squall,Irvine", "844482288424", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Selphie"),

            new PartyFormation(1978, 199, "e4c7d72f", "Irvine,Squall,Selphie", "444822884246", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Selphie"),

            new PartyFormation(1979, 1, "aa01213c", "Rinoa,Squall,Selphie", "448228842462", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Selphie"),

            new PartyFormation(1980, 3, "ab039ec5", "Rinoa,Irvine,Quistis", "482288424626", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Selphie"),

            new PartyFormation(1981, 72, "bc48d01a", "Zell,Squall,Irvine", "822884246268", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Selphie"),

            new PartyFormation(1982, 132, "e884b74b", "Irvine,Squall,Rinoa", "228842462688", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Selphie"),

            new PartyFormation(1983, 93, "3f5d1528", "Irvine,Squall,Selphie", "288424626882", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Selphie"),

            new PartyFormation(1984, 4, "dc046241", "Irvine,Squall,Quistis", "884246268828", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Selphie"),

            new PartyFormation(1985, 19, "8313d3e6", "Irvine,Zell,Rinoa", "842462688286", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Selphie"),

            new PartyFormation(1986, 229, "23e57d27", "Irvine,Zell,Rinoa", "424626882862", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Selphie"),

            new PartyFormation(1987, 2, "e8025bd4", "Selphie,Zell,Quistis", "246268828624", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(1988, 243, "5af3e17d", "Rinoa,Zell,Quistis", "462688286246", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(1989, 57, "2c394872", "Zell,Squall,Selphie", "626882862462", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(1990, 162, "42a2c4c3", "Irvine,Squall,Selphie", "268828624624", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(1991, 19, "a9136140", "Irvine,Zell,Selphie", "688286246246", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(1992, 98, "5c621879", "Zell,Squall,Rinoa", "882862462464", "{Irvine,Zell,Selphie=>49, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(1993, 207, "dfcf79be", "Irvine,Zell,Rinoa", "828624624646", "{Irvine,Zell,Selphie=>48, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(1994, 98, "e962ea1f", "Irvine,Squall,Rinoa", "286246246464", "{Irvine,Zell,Selphie=>47, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(1995, 109, "756d516c", "Irvine,Zell,Quistis", "862462464642", "{Irvine,Zell,Selphie=>46, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(1996, 226, "b3e2c335", "Irvine,Squall,Rinoa", "624624646424", "{Irvine,Zell,Selphie=>45, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(1997, 5, "1f0573ca", "Rinoa,Irvine,Selphie", "246246464242", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(1998, 214, "b6d6093b", "Irvine,Squall,Quistis", "462464642424", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(1999, 148, "2e941858", "Rinoa,Irvine,Selphie", "624646424248", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(2000, 137, "20895db1", "Rinoa,Irvine,Quistis", "246464242482", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(2001, 239, "1cef0296", "Irvine,Squall,Rinoa", "464642424826", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2002, 145, "3a91fe17", "Irvine,Zell,Rinoa", "646424248262", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2003, 94, "c85e6204", "Zell,Squall,Quistis", "464242482624", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2004, 37, "e52523ed", "Rinoa,Squall,Quistis", "642424826242", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(2005, 16, "d810b222", "Rinoa,Irvine,Quistis", "424248262428", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2006, 174, "7dae64b3", "Irvine,Zell,Quistis", "242482624284", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(2007, 97, "fb619a70", "Zell,Squall,Selphie", "424826242842", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(2008, 61, "a83d11e9", "Irvine,Zell,Rinoa", "248262428422", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Quistis"),

            new PartyFormation(2009, 171, "40abce6e", "Zell,Squall,Quistis", "482624284226", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>2}", "Irvine,Zell,Quistis"),

            new PartyFormation(2010, 32, "7920990f", "Irvine,Zell,Quistis", "826242842268", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>1}", "Irvine,Zell,Quistis"),

            new PartyFormation(2011, 29, "b21ded9c", "Selphie,Irvine,Quistis", "262428422682", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2012, 203, "57cbe3a5", "Irvine,Zell,Quistis", "624284226826", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(2013, 202, "77ca637a", "Zell,Squall,Irvine", "242842268264", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2014, 215, "95d7b72b", "Zell,Squall,Quistis", "428422682646", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2015, 234, "1cea4788", "Rinoa,Zell,Quistis", "284226826464", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2016, 188, "8cbc1521", "Rinoa,Irvine,Selphie", "842268264648", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2017, 11, "f30b3d46", "Selphie,Zell,Quistis", "422682646486", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2018, 152, "12989b07", "Zell,Squall,Quistis", "226826464868", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2019, 160, "18a05434", "Irvine,Squall,Rinoa", "268264648688", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2020, 35, "aa23e25d", "Selphie,Rinoa,Quistis", "682646486886", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2021, 45, "112de7d2", "Selphie,Zell,Quistis", "826464868862", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2022, 153, "eb99e0a3", "Zell,Squall,Rinoa", "264648688622", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2023, 8, "54087fa0", "Irvine,Squall,Quistis", "646486886228", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2024, 65, "b4414759", "Zell,Squall,Quistis", "464868862282", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2025, 94, "6b5eaf1e", "Selphie,Irvine,Quistis", "648688622824", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2026, 223, "9fdfe3ff", "Selphie,Zell,Quistis", "486886228246", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(2027, 5, "6005f5cc", "Irvine,Zell,Rinoa", "868862282462", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(2028, 54, "9b360015", "Zell,Squall,Selphie", "688622824624", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(2029, 66, "ef429f2a", "Selphie,Zell,Quistis", "886228246244", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(2030, 88, "f058c11b", "Rinoa,Squall,Selphie", "862282462448", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2031, 130, "9682a2b8", "Selphie,Zell,Quistis", "622824624484", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2032, 131, "75838891", "Zell,Squall,Quistis", "228246244846", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2033, 195, "8dc383f6", "Selphie,Squall,Quistis", "282462448466", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(2034, 184, "74b853f7", "Irvine,Zell,Quistis", "824624484668", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2035, 27, "841b3264", "Rinoa,Squall,Selphie", "246244846686", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2036, 71, "e6471ccd", "Rinoa,Squall,Selphie", "462448466866", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2037, 155, "0a9be982", "Rinoa,Squall,Selphie", "624484668666", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2038, 20, "a2143893", "Zell,Squall,Quistis", "244846686668", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2039, 139, "408b10d0", "Selphie,Squall,Quistis", "448466866686", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2040, 53, "ab35b8c9", "Selphie,Irvine,Quistis", "484668666862", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2041, 163, "38a31bce", "Irvine,Zell,Selphie", "846686668626", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>51}", "Irvine,Zell,Selphie"),

            new PartyFormation(2042, 63, "9f3fcaef", "Rinoa,Zell,Quistis", "466866686266", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>50}", "Irvine,Zell,Selphie"),

            new PartyFormation(2043, 216, "e1d869fc", "Rinoa,Squall,Selphie", "668666862668", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>49}", "Irvine,Zell,Selphie"),

            new PartyFormation(2044, 88, "0e581885", "Irvine,Zell,Selphie", "686668626688", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>48}", "Irvine,Zell,Selphie"),

            new PartyFormation(2045, 217, "aed926da", "Zell,Squall,Irvine", "866686266882", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>47}", "Irvine,Zell,Selphie"),

            new PartyFormation(2046, 232, "02e8270b", "Rinoa,Squall,Quistis", "666862668828", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>46}", "Irvine,Zell,Selphie"),

            new PartyFormation(2047, 64, "f64029e8", "Rinoa,Zell,Quistis", "668626688288", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>45}", "Irvine,Zell,Selphie"),

            new PartyFormation(2048, 134, "b786b801", "Rinoa,Zell,Quistis", "686266882884", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>44}", "Irvine,Zell,Selphie"),

            new PartyFormation(2049, 50, "c232d6a6", "Selphie,Squall,Quistis", "862668828844", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>43}", "Irvine,Zell,Selphie"),

            new PartyFormation(2050, 112, "577028e7", "Rinoa,Zell,Quistis", "626688288448", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>42}", "Irvine,Zell,Selphie"),

            new PartyFormation(2051, 225, "b0e1fc94", "Zell,Squall,Rinoa", "266882884482", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>41}", "Irvine,Zell,Selphie"),

            new PartyFormation(2052, 165, "19a5d33d", "Rinoa,Squall,Selphie", "668828844822", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>40}", "Irvine,Zell,Selphie"),

            new PartyFormation(2053, 37, "5025b732", "Selphie,Rinoa,Quistis", "688288448222", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>39}", "Irvine,Zell,Selphie"),

            new PartyFormation(2054, 140, "008c6c83", "Irvine,Squall,Selphie", "882884482228", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Selphie"),

            new PartyFormation(2055, 44, "352c4e00", "Irvine,Zell,Selphie", "828844822288", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Selphie"),

            new PartyFormation(2056, 161, "77a16639", "Selphie,Squall,Quistis", "288448222882", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Quistis"),

            new PartyFormation(2057, 244, "a5f4147e", "Irvine,Zell,Quistis", "884482228828", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Quistis"),

            new PartyFormation(2058, 159, "de9f4ddf", "Irvine,Squall,Rinoa", "844822288286", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Quistis"),

            new PartyFormation(2059, 8, "2d084a2c", "Irvine,Squall,Rinoa", "448222882868", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Quistis"),

            new PartyFormation(2060, 41, "3d292cf5", "Rinoa,Zell,Selphie", "482228828682", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Quistis"),

            new PartyFormation(2061, 184, "90b8fa8a", "Irvine,Zell,Rinoa", "822288286828", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Quistis"),

            new PartyFormation(2062, 212, "cbd4e8fb", "Irvine,Zell,Quistis", "222882868288", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(2063, 197, "95c5dd18", "Selphie,Rinoa,Quistis", "228828682882", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Quistis"),

            new PartyFormation(2064, 44, "272ca371", "Zell,Squall,Selphie", "288286828828", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(2065, 52, "62343556", "Irvine,Zell,Quistis", "882868288288", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Quistis"),

            new PartyFormation(2066, 255, "ceff19d7", "Irvine,Squall,Rinoa", "828682882886", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Selphie"),

            new PartyFormation(2067, 199, "6fc7b2c4", "Rinoa,Squall,Quistis", "286828828866", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Selphie"),

            new PartyFormation(2068, 23, "781705ad", "Rinoa,Squall,Quistis", "868288288666", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(2069, 86, "765650e2", "Rinoa,Zell,Selphie", "682882886664", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(2070, 49, "a0317c73", "Selphie,Squall,Quistis", "828828866642", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(2071, 239, "bcef3730", "Selphie,Squall,Quistis", "288288666426", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(2072, 203, "33cb4fa9", "Irvine,Squall,Selphie", "882886664266", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(2073, 140, "858c992e", "Rinoa,Squall,Selphie", "828866642668", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(2074, 29, "db1d6ccf", "Selphie,Zell,Quistis", "288666426682", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(2075, 200, "f9c8965c", "Irvine,Zell,Selphie", "886664266828", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(2076, 96, "1f603d65", "Selphie,Zell,Quistis", "866642668288", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(2077, 205, "cfcd1a3a", "Rinoa,Zell,Selphie", "666426682882", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2078, 46, "fb2e06eb", "Selphie,Zell,Quistis", "664266828824", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2079, 118, "fd76bc48", "Rinoa,Zell,Selphie", "642668288244", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2080, 156, "009c4ae1", "Irvine,Zell,Selphie", "426682882448", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2081, 98, "ec62a006", "Rinoa,Zell,Selphie", "266828824484", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(2082, 100, "fd6426c7", "Rinoa,Squall,Quistis", "668288244848", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2083, 95, "ec5f54f4", "Irvine,Squall,Selphie", "682882448486", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2084, 49, "5931b41d", "Selphie,Zell,Quistis", "828824484862", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2085, 120, "ca78b692", "Irvine,Squall,Quistis", "288244848628", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(2086, 242, "43f26863", "Irvine,Zell,Quistis", "882448486284", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2087, 150, "a996cc60", "Rinoa,Zell,Quistis", "824484862844", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(2088, 186, "99ba7519", "Rinoa,Squall,Quistis", "244848628444", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Selphie"),

            new PartyFormation(2089, 103, "2e67a9de", "Selphie,Zell,Quistis", "448486284446", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Selphie"),

            new PartyFormation(2090, 153, "179927bf", "Rinoa,Zell,Selphie", "484862844462", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>2}", "Irvine,Zell,Selphie"),

            new PartyFormation(2091, 12, "f30c4e8c", "Irvine,Zell,Selphie", "848628444628", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>1}", "Irvine,Zell,Selphie"),

            new PartyFormation(2092, 116, "887449d5", "Selphie,Irvine,Quistis", "486284446288", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2093, 192, "b7c085ea", "Rinoa,Zell,Selphie", "862844462888", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(2094, 194, "e2c280db", "Selphie,Zell,Quistis", "628444628884", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(2095, 117, "1475c778", "Selphie,Zell,Quistis", "284446288842", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2096, 188, "57bcae51", "Irvine,Squall,Rinoa", "844462888428", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2097, 25, "3c1916b6", "Rinoa,Irvine,Quistis", "444628884282", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2098, 94, "025e4fb7", "Irvine,Zell,Rinoa", "446288842824", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2099, 251, "dcfbe324", "Irvine,Squall,Rinoa", "462888428246", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(2100, 76, "a84cde8d", "Selphie,Squall,Quistis", "628884282468", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(2101, 151, "0297e842", "Rinoa,Squall,Quistis", "288842824686", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(2102, 126, "c87e3053", "Irvine,Squall,Selphie", "888428246864", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(2103, 166, "43a60d90", "Irvine,Zell,Selphie", "884282468644", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(2104, 53, "7335d689", "Selphie,Rinoa,Quistis", "842824686442", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2105, 64, "2c40468e", "Irvine,Zell,Quistis", "428246864428", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(2106, 177, "0cb17eaf", "Selphie,Rinoa,Quistis", "282468644282", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2107, 134, "e68672bc", "Irvine,Squall,Selphie", "824686442824", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2108, 156, "979c5245", "Zell,Squall,Selphie", "246864428248", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2109, 254, "54fe3d9a", "Selphie,Squall,Quistis", "468644282484", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2110, 33, "662156cb", "Selphie,Irvine,Quistis", "686442824842", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2111, 165, "50a5fea8", "Rinoa,Irvine,Quistis", "864428248422", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(2112, 52, "8834cdc1", "Rinoa,Irvine,Selphie", "644282484228", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(2113, 114, "39729966", "Selphie,Squall,Quistis", "442824842284", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(2114, 108, "eb6c94a7", "Rinoa,Squall,Quistis", "428248422848", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(2115, 176, "b2b05d54", "Irvine,Zell,Quistis", "282484228488", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(2116, 127, "547f84fd", "Irvine,Squall,Selphie", "824842284886", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2117, 126, "ed7ee5f2", "Rinoa,Squall,Selphie", "248422848864", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(2118, 67, "1443d443", "Selphie,Zell,Quistis", "484228488646", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(2119, 95, "7a5ffac0", "Zell,Squall,Rinoa", "842284886466", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(2120, 196, "09c473f9", "Irvine,Zell,Rinoa", "422848864668", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(2121, 145, "ef916f3e", "Rinoa,Squall,Quistis", "228488646682", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(2122, 197, "18c5719f", "Rinoa,Squall,Quistis", "284886466822", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(2123, 170, "f4aa02ec", "Rinoa,Squall,Selphie", "848864668224", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(2124, 207, "27cf56b5", "Rinoa,Irvine,Selphie", "488646682246", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Selphie"),

            new PartyFormation(2125, 177, "24b1414a", "Selphie,Zell,Quistis", "886466822462", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Selphie"),

            new PartyFormation(2126, 153, "ea9988bb", "Irvine,Zell,Selphie", "864668224622", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>2}", "Irvine,Zell,Selphie"),

            new PartyFormation(2127, 170, "e6aa61d8", "Selphie,Squall,Quistis", "646682246224", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2128, 107, "a56ba931", "Selphie,Irvine,Quistis", "466822462246", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2129, 74, "894a2816", "Irvine,Squall,Quistis", "668224622464", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(2130, 205, "a3cdf597", "Selphie,Zell,Quistis", "682246224642", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(2131, 79, "c94fc384", "Irvine,Zell,Selphie", "822462246426", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(2132, 160, "c0a0a76d", "Irvine,Zell,Selphie", "224622464268", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2133, 184, "22b8afa2", "Zell,Squall,Quistis", "246224642688", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2134, 114, "07725433", "Irvine,Squall,Rinoa", "462246426884", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2135, 199, "13c793f0", "Zell,Squall,Irvine", "622464268846", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2136, 173, "96ad4d69", "Irvine,Zell,Rinoa", "224642688462", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(2137, 150, "7d9623ee", "Rinoa,Squall,Quistis", "246426884624", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(2138, 244, "6ff4008f", "Irvine,Zell,Rinoa", "464268846248", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(2139, 169, "c0a9ff1c", "Rinoa,Squall,Selphie", "642688462482", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(2140, 196, "3fc45725", "Irvine,Zell,Selphie", "426884624828", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(2141, 196, "c4c490fa", "Zell,Squall,Rinoa", "268846248288", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(2142, 58, "473a16ab", "Irvine,Zell,Selphie", "688462482884", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(2143, 229, "f9e5f108", "Rinoa,Zell,Selphie", "884624828842", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2144, 136, "ea8840a1", "Rinoa,Irvine,Quistis", "846248288428", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2145, 58, "3d3ac2c6", "Zell,Squall,Irvine", "462482884284", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2146, 129, "e4817287", "Zell,Squall,Irvine", "624828842842", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2147, 109, "976d15b4", "Selphie,Irvine,Quistis", "248288428422", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2148, 71, "334745dd", "Rinoa,Zell,Quistis", "482884284226", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Quistis"),

            new PartyFormation(2149, 144, "b2904552", "Rinoa,Zell,Quistis", "828842842268", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Quistis"),

            new PartyFormation(2150, 248, "6bf8b023", "Irvine,Zell,Rinoa", "288428422688", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Quistis"),

            new PartyFormation(2151, 159, "dc9fd920", "Selphie,Rinoa,Quistis", "884284226886", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Quistis"),

            new PartyFormation(2152, 247, "b2f762d9", "Zell,Squall,Quistis", "842842268866", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Quistis"),

            new PartyFormation(2153, 73, "2049649e", "Rinoa,Zell,Selphie", "428422688662", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Quistis"),

            new PartyFormation(2154, 28, "0c1c2b7f", "Irvine,Zell,Quistis", "284226886628", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(2155, 121, "a079674c", "Irvine,Zell,Rinoa", "842268866282", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>29}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2156, 242, "81f25395", "Rinoa,Squall,Selphie", "422688662824", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>28}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2157, 227, "a3e32caa", "Irvine,Zell,Rinoa", "226886628246", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>27}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2158, 210, "b4d2009b", "Rinoa,Zell,Quistis", "268866282464", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>26}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2159, 123, "cc7bac38", "Rinoa,Squall,Quistis", "688662824646", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>25}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2160, 113, "2a719411", "Rinoa,Zell,Quistis", "886628246462", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>24}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2161, 159, "839f6976", "Selphie,Rinoa,Quistis", "866282464626", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>23}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2162, 70, "24460b77", "Irvine,Squall,Rinoa", "662824646264", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>22}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2163, 91, "de5b53e4", "Irvine,Squall,Quistis", "628246462646", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>21}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2164, 202, "46ca604d", "Rinoa,Zell,Selphie", "282464626464", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>20}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2165, 16, "d610a702", "Irvine,Zell,Rinoa", "824646264648", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>19}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2166, 133, "e585e813", "Zell,Squall,Selphie", "246462646482", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>18}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2167, 107, "d86bca50", "Irvine,Squall,Rinoa", "464626464826", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>17}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2168, 105, "c769b449", "Rinoa,Squall,Quistis", "646264648262", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>16}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2169, 102, "1666314e", "Rinoa,Irvine,Quistis", "462646482624", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>15}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2170, 220, "9cdcf26f", "Rinoa,Zell,Quistis", "626464826248", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>14}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2171, 203, "cccb3b7c", "Selphie,Zell,Quistis", "264648262486", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>13}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2172, 144, "9c904c05", "Zell,Squall,Quistis", "646482624868", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2173, 120, "b178145a", "Zell,Squall,Rinoa", "464826248688", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2174, 240, "bdf0468b", "Rinoa,Squall,Quistis", "648262486888", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2175, 78, "ef4e9368", "Rinoa,Squall,Quistis", "482624868884", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2176, 206, "3fcea381", "Irvine,Squall,Selphie", "826248688844", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2177, 147, "57931c26", "Irvine,Squall,Quistis", "262486888446", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2178, 154, "879ac067", "Rinoa,Squall,Selphie", "624868884464", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2179, 45, "da2d7e14", "Zell,Squall,Rinoa", "248688844642", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2180, 64, "5940f6bd", "Zell,Squall,Quistis", "486888446428", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2181, 4, "9f04d4b2", "Selphie,Rinoa,Quistis", "868884464288", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2182, 136, "e188fc03", "Selphie,Squall,Quistis", "688844642888", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2183, 110, "716e6780", "Selphie,Zell,Quistis", "888446428884", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2184, 139, "7c8b41b9", "Selphie,Irvine,Quistis", "884464288846", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2185, 103, "436789fe", "Irvine,Zell,Quistis", "844642888466", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(2186, 149, "7795555f", "Irvine,Zell,Selphie", "446428884662", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>110, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Selphie"),

            new PartyFormation(2187, 18, "91127bac", "Rinoa,Irvine,Selphie", "464288846624", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>109, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2188, 149, "b9954075", "Irvine,Zell,Rinoa", "642888466242", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>108, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2189, 174, "0dae480a", "Rinoa,Squall,Selphie", "428884662424", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>107, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2190, 227, "2ee3e87b", "Selphie,Irvine,Quistis", "288846624246", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>106, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2191, 1, "7201a698", "Zell,Squall,Irvine", "888466242462", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>105, Selphie,Irvine,Quistis=>84}", "Irvine,Zell,Selphie"),

            new PartyFormation(2192, 6, "7d066ef1", "Zell,Squall,Rinoa", "884662424624", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>104, Selphie,Irvine,Quistis=>83}", "Irvine,Zell,Selphie"),

            new PartyFormation(2193, 240, "30f0dad6", "Selphie,Rinoa,Quistis", "846624246248", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>103, Selphie,Irvine,Quistis=>82}", "Irvine,Zell,Selphie"),

            new PartyFormation(2194, 190, "d0be9157", "Zell,Squall,Rinoa", "466242462484", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>102, Selphie,Irvine,Quistis=>81}", "Irvine,Zell,Selphie"),

            new PartyFormation(2195, 182, "71b69444", "Irvine,Squall,Quistis", "662424624844", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>101, Selphie,Irvine,Quistis=>80}", "Irvine,Zell,Selphie"),

            new PartyFormation(2196, 130, "fc82092d", "Rinoa,Zell,Quistis", "624246248444", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>100, Selphie,Irvine,Quistis=>79}", "Irvine,Zell,Selphie"),

            new PartyFormation(2197, 247, "a7f7ce62", "Zell,Squall,Rinoa", "242462484446", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>99, Selphie,Irvine,Quistis=>78}", "Irvine,Zell,Selphie"),

            new PartyFormation(2198, 48, "8730ebf3", "Rinoa,Zell,Selphie", "424624844468", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>98, Selphie,Irvine,Quistis=>77}", "Irvine,Zell,Selphie"),

            new PartyFormation(2199, 170, "a8aab0b0", "Selphie,Squall,Quistis", "246248444684", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>97, Selphie,Irvine,Quistis=>76}", "Irvine,Zell,Selphie"),

            new PartyFormation(2200, 163, "2aa30b29", "Zell,Squall,Selphie", "462484446846", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>96, Selphie,Irvine,Quistis=>75}", "Irvine,Zell,Selphie"),

            new PartyFormation(2201, 136, "df886eae", "Zell,Squall,Rinoa", "624844468468", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>95, Selphie,Irvine,Quistis=>74}", "Irvine,Zell,Selphie"),

            new PartyFormation(2202, 100, "8764544f", "Rinoa,Zell,Selphie", "248444684688", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>94, Selphie,Irvine,Quistis=>73}", "Irvine,Zell,Selphie"),

            new PartyFormation(2203, 130, "7b8227dc", "Irvine,Squall,Rinoa", "484446846884", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>93, Selphie,Irvine,Quistis=>72}", "Irvine,Zell,Selphie"),

            new PartyFormation(2204, 184, "eeb830e5", "Selphie,Zell,Quistis", "844468468848", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>92, Selphie,Irvine,Quistis=>71}", "Irvine,Zell,Selphie"),

            new PartyFormation(2205, 112, "b970c7ba", "Zell,Squall,Irvine", "444684688488", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>91, Selphie,Irvine,Quistis=>70}", "Irvine,Zell,Selphie"),

            new PartyFormation(2206, 187, "05bbe66b", "Irvine,Squall,Rinoa", "446846884886", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>90, Selphie,Irvine,Quistis=>69}", "Irvine,Zell,Selphie"),

            new PartyFormation(2207, 247, "12f7e5c8", "Rinoa,Squall,Quistis", "468468848866", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>89, Selphie,Irvine,Quistis=>68}", "Irvine,Zell,Selphie"),

            new PartyFormation(2208, 63, "1c3ff661", "Rinoa,Squall,Quistis", "684688488666", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>88, Selphie,Irvine,Quistis=>67}", "Irvine,Zell,Selphie"),

            new PartyFormation(2209, 83, "b453a586", "Irvine,Zell,Rinoa", "846884886666", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>87, Selphie,Irvine,Quistis=>66}", "Irvine,Zell,Selphie"),

            new PartyFormation(2210, 176, "4fb07e47", "Rinoa,Zell,Quistis", "468848866668", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>86, Selphie,Irvine,Quistis=>65}", "Irvine,Zell,Selphie"),

            new PartyFormation(2211, 137, "66899674", "Rinoa,Irvine,Quistis", "688488666682", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>85, Selphie,Irvine,Quistis=>64}", "Irvine,Zell,Selphie"),

            new PartyFormation(2212, 36, "6624979d", "Irvine,Zell,Selphie", "884886666828", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>84, Selphie,Irvine,Quistis=>63}", "Irvine,Zell,Selphie"),

            new PartyFormation(2213, 52, "c4349412", "Rinoa,Zell,Quistis", "848866668288", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>83, Selphie,Irvine,Quistis=>62}", "Irvine,Zell,Selphie"),

            new PartyFormation(2214, 108, "a76cb7e3", "Selphie,Squall,Quistis", "488666682888", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>82, Selphie,Irvine,Quistis=>61}", "Irvine,Zell,Selphie"),

            new PartyFormation(2215, 227, "45e3a5e0", "Rinoa,Irvine,Selphie", "886666828886", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>81, Selphie,Irvine,Quistis=>60}", "Irvine,Zell,Selphie"),

            new PartyFormation(2216, 184, "49b81099", "Zell,Squall,Quistis", "866668288868", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>80, Selphie,Irvine,Quistis=>59}", "Irvine,Zell,Selphie"),

            new PartyFormation(2217, 195, "27c3df5e", "Irvine,Squall,Quistis", "666682888686", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>79, Selphie,Irvine,Quistis=>58}", "Irvine,Zell,Selphie"),

            new PartyFormation(2218, 40, "3d28ef3f", "Rinoa,Squall,Quistis", "666828886868", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>78, Selphie,Irvine,Quistis=>57}", "Irvine,Zell,Selphie"),

            new PartyFormation(2219, 13, "8d0d400c", "Zell,Squall,Selphie", "668288868682", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>77, Selphie,Irvine,Quistis=>56}", "Irvine,Zell,Selphie"),

            new PartyFormation(2220, 112, "ad701d55", "Zell,Squall,Quistis", "682888686828", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>76, Selphie,Irvine,Quistis=>55}", "Irvine,Zell,Selphie"),

            new PartyFormation(2221, 106, "466a936a", "Zell,Squall,Rinoa", "828886868284", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>75, Selphie,Irvine,Quistis=>54}", "Irvine,Zell,Selphie"),

            new PartyFormation(2222, 71, "6247405b", "Selphie,Rinoa,Quistis", "288868682846", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>74, Selphie,Irvine,Quistis=>53}", "Irvine,Zell,Selphie"),

            new PartyFormation(2223, 84, "6f5450f8", "Irvine,Zell,Selphie", "888686828468", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>73, Selphie,Irvine,Quistis=>52}", "Irvine,Zell,Selphie"),

            new PartyFormation(2224, 98, "af6239d1", "Rinoa,Squall,Quistis", "886868284684", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>72, Selphie,Irvine,Quistis=>51}", "Irvine,Zell,Selphie"),

            new PartyFormation(2225, 22, "63167c36", "Rinoa,Squall,Quistis", "868682846844", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>71, Selphie,Irvine,Quistis=>50}", "Irvine,Zell,Selphie"),

            new PartyFormation(2226, 47, "d22f8737", "Irvine,Zell,Rinoa", "686828468446", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>70, Selphie,Irvine,Quistis=>49}", "Irvine,Zell,Selphie"),

            new PartyFormation(2227, 249, "84f984a4", "Rinoa,Squall,Quistis", "868284684462", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>69, Selphie,Irvine,Quistis=>48}", "Irvine,Zell,Selphie"),

            new PartyFormation(2228, 127, "df7fa20d", "Rinoa,Zell,Selphie", "682846844626", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>68, Selphie,Irvine,Quistis=>47}", "Irvine,Zell,Selphie"),

            new PartyFormation(2229, 198, "afc625c2", "Rinoa,Squall,Quistis", "828468446264", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>67, Selphie,Irvine,Quistis=>46}", "Irvine,Zell,Selphie"),

            new PartyFormation(2230, 235, "aceb5fd3", "Irvine,Zell,Rinoa", "284684462646", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>66, Selphie,Irvine,Quistis=>45}", "Irvine,Zell,Selphie"),

            new PartyFormation(2231, 156, "079c4710", "Zell,Squall,Selphie", "846844626468", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>65, Selphie,Irvine,Quistis=>44}", "Irvine,Zell,Selphie"),

            new PartyFormation(2232, 145, "e1915209", "Zell,Squall,Rinoa", "468446264682", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>64, Selphie,Irvine,Quistis=>43}", "Irvine,Zell,Selphie"),

            new PartyFormation(2233, 212, "0dd4dc0e", "Zell,Squall,Selphie", "684462646828", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>63, Selphie,Irvine,Quistis=>42}", "Irvine,Zell,Selphie"),

            new PartyFormation(2234, 130, "7f82262f", "Rinoa,Zell,Quistis", "844626468284", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>62, Selphie,Irvine,Quistis=>41}", "Irvine,Zell,Selphie"),

            new PartyFormation(2235, 102, "6966c43c", "Irvine,Zell,Selphie", "446264682844", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>61, Selphie,Irvine,Quistis=>40}", "Irvine,Zell,Selphie"),

            new PartyFormation(2236, 244, "32f405c5", "Selphie,Squall,Quistis", "462646828448", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>60, Selphie,Irvine,Quistis=>39}", "Irvine,Zell,Selphie"),

            new PartyFormation(2237, 6, "8706ab1a", "Irvine,Zell,Rinoa", "626468284484", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>59, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Selphie"),

            new PartyFormation(2238, 20, "7614f64b", "Rinoa,Zell,Selphie", "264682844848", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>58, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Selphie"),

            new PartyFormation(2239, 249, "32f9e828", "Zell,Squall,Rinoa", "646828448482", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>57, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Selphie"),

            new PartyFormation(2240, 20, "90143941", "Rinoa,Irvine,Quistis", "468284484828", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>56, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Selphie"),

            new PartyFormation(2241, 84, "4b545ee6", "Rinoa,Zell,Quistis", "682844848288", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>55, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Selphie"),

            new PartyFormation(2242, 186, "93baac27", "Irvine,Squall,Quistis", "828448482884", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>54, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Selphie"),

            new PartyFormation(2243, 25, "d4195ed4", "Irvine,Squall,Rinoa", "284484828842", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>53, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Selphie"),

            new PartyFormation(2244, 170, "35aa287d", "Rinoa,Irvine,Selphie", "844848288424", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>52, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Selphie"),

            new PartyFormation(2245, 119, "bf778372", "Irvine,Zell,Selphie", "448482884246", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>51, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Selphie"),

            new PartyFormation(2246, 27, "8c1be3c3", "Zell,Squall,Quistis", "484828842466", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>50, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Selphie"),

            new PartyFormation(2247, 23, "d3179440", "Selphie,Squall,Quistis", "848288424666", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>49, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Selphie"),

            new PartyFormation(2248, 181, "f9b5cf79", "Rinoa,Squall,Quistis", "482884246662", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>48, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Selphie"),

            new PartyFormation(2249, 54, "e83664be", "Selphie,Rinoa,Quistis", "828842466624", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>47, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Selphie"),

            new PartyFormation(2250, 206, "9acef91f", "Rinoa,Squall,Quistis", "288424666244", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>46, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Selphie"),

            new PartyFormation(2251, 1, "8701b46c", "Irvine,Squall,Selphie", "884246662442", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>45, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(2252, 58, "f83aea35", "Rinoa,Squall,Selphie", "842466624424", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>44, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(2253, 112, "3e700eca", "Zell,Squall,Rinoa", "424666244248", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>43, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(2254, 116, "7474083b", "Irvine,Zell,Rinoa", "246662442488", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>42, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(2255, 139, "488bab58", "Rinoa,Squall,Quistis", "466624424886", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>41, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(2256, 188, "4fbcf4b1", "Irvine,Squall,Quistis", "666244248868", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>40, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(2257, 232, "b7e84d96", "Rinoa,Squall,Selphie", "662442488688", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(2258, 144, "2d90ed17", "Selphie,Zell,Quistis", "624424886888", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(2259, 188, "c5bc2504", "Selphie,Squall,Quistis", "244248868888", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(2260, 123, "297b2aed", "Irvine,Zell,Rinoa", "442488688886", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2261, 211, "90d3ad22", "Zell,Squall,Quistis", "424886888866", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2262, 45, "b32d43b3", "Selphie,Squall,Quistis", "248868888662", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2263, 88, "e4588d70", "Irvine,Zell,Selphie", "488688886628", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2264, 108, "096c88e9", "Rinoa,Zell,Quistis", "886888866288", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2265, 35, "2223796e", "Zell,Squall,Selphie", "868888662886", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2266, 46, "312e680f", "Zell,Squall,Irvine", "688886628864", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2267, 17, "5f11109c", "Rinoa,Zell,Quistis", "888866288642", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2268, 251, "21fbcaa5", "Zell,Squall,Quistis", "888662886426", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2269, 145, "d091be7a", "Irvine,Squall,Rinoa", "886628864262", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2270, 115, "8273762b", "Selphie,Squall,Quistis", "866288642626", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2271, 108, "096c9a88", "Rinoa,Zell,Quistis", "662886426268", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2272, 131, "27836c21", "Zell,Squall,Irvine", "628864262686", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2273, 109, "e06d4846", "Zell,Squall,Irvine", "288642626862", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2274, 177, "86b14a07", "Irvine,Squall,Quistis", "886426268622", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2275, 116, "6674d734", "Selphie,Irvine,Quistis", "864262686228", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2276, 137, "df89a95d", "Zell,Squall,Irvine", "642626862282", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(2277, 37, "ba25a2d2", "Zell,Squall,Selphie", "426268622822", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(2278, 14, "fa0e7fa3", "Irvine,Squall,Selphie", "262686228224", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2279, 34, "fe2232a0", "Zell,Squall,Irvine", "626862282244", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2280, 188, "67bc7e59", "Zell,Squall,Quistis", "268622822448", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2281, 151, "eb971a1e", "Irvine,Zell,Selphie", "686228224486", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2282, 127, "2a7f72ff", "Selphie,Zell,Quistis", "862282244866", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2283, 135, "9d87d8cc", "Zell,Squall,Quistis", "622822448666", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2284, 173, "f0ada715", "Zell,Squall,Rinoa", "228224486662", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2285, 22, "f216ba2a", "Zell,Squall,Rinoa", "282244866624", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2286, 226, "a6e2401b", "Irvine,Squall,Quistis", "822448666244", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2287, 191, "6dbfb5b8", "Rinoa,Irvine,Quistis", "224486662446", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2288, 78, "684e9f91", "Zell,Squall,Selphie", "244866624464", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2289, 62, "993e4ef6", "Zell,Squall,Irvine", "448666244644", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2290, 218, "c3dac2f7", "Zell,Squall,Rinoa", "486662446444", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2291, 150, "8d967564", "Irvine,Squall,Selphie", "866624464444", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2292, 44, "502ca3cd", "Irvine,Squall,Selphie", "666244644448", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2293, 120, "7a786482", "Selphie,Irvine,Quistis", "662446444488", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2294, 110, "926e9793", "Irvine,Squall,Rinoa", "624464444884", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(2295, 247, "99f783d0", "Zell,Squall,Selphie", "244644448846", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(2296, 108, "bb6cafc9", "Irvine,Zell,Quistis", "446444488468", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2297, 76, "e94c46ce", "Zell,Squall,Selphie", "464444884688", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2298, 97, "a46119ef", "Selphie,Zell,Quistis", "644448846882", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2299, 25, "51190cfc", "Irvine,Zell,Rinoa", "444488468822", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(2300, 135, "30877f85", "Rinoa,Irvine,Quistis", "444884688226", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2301, 106, "586a01da", "Rinoa,Zell,Selphie", "448846882264", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(2302, 79, "ba4f660b", "Rinoa,Squall,Quistis", "488468822646", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(2303, 103, "3c67fce8", "Irvine,Zell,Quistis", "884688226466", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Quistis"),

            new PartyFormation(2304, 197, "eac58f01", "Rinoa,Squall,Selphie", "846882264662", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2305, 118, "037661a6", "Selphie,Squall,Quistis", "468822646624", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2306, 140, "378c57e7", "Selphie,Irvine,Quistis", "688226466248", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2307, 51, "0d33ff94", "Rinoa,Irvine,Selphie", "882264662486", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2308, 123, "b77b1a3d", "Zell,Squall,Irvine", "822646624866", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2309, 150, "6996f232", "Selphie,Irvine,Quistis", "226466248664", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2310, 188, "f7bc8b83", "Irvine,Zell,Selphie", "264662486648", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>48}", "Irvine,Zell,Selphie"),

            new PartyFormation(2311, 27, "181b8100", "Rinoa,Irvine,Quistis", "646624866486", "{Irvine,Zell,Selphie=>50, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>47}", "Irvine,Zell,Quistis"),

            new PartyFormation(2312, 4, "6b041d39", "Selphie,Zell,Quistis", "466248664868", "{Irvine,Zell,Selphie=>49, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>46}", "Irvine,Zell,Quistis"),

            new PartyFormation(2313, 189, "e4bdff7e", "Irvine,Squall,Rinoa", "662486648682", "{Irvine,Zell,Selphie=>48, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>45}", "Irvine,Zell,Quistis"),

            new PartyFormation(2314, 50, "e2325cdf", "Rinoa,Zell,Quistis", "624866486824", "{Irvine,Zell,Selphie=>47, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>44}", "Irvine,Zell,Quistis"),

            new PartyFormation(2315, 55, "1b37ad2c", "Irvine,Zell,Rinoa", "248664868246", "{Irvine,Zell,Selphie=>46, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>43}", "Irvine,Zell,Quistis"),

            new PartyFormation(2316, 128, "a98053f5", "Irvine,Squall,Rinoa", "486648682468", "{Irvine,Zell,Selphie=>45, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>42}", "Irvine,Zell,Quistis"),

            new PartyFormation(2317, 182, "69b6958a", "Irvine,Zell,Quistis", "866486824684", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>41}", "Irvine,Zell,Quistis"),

            new PartyFormation(2318, 9, "5709e7fb", "Zell,Squall,Irvine", "664868246842", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>40}", "Irvine,Zell,Quistis"),

            new PartyFormation(2319, 8, "3b087018", "Rinoa,Squall,Selphie", "648682468428", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>39}", "Irvine,Zell,Quistis"),

            new PartyFormation(2320, 79, "7f4f3a71", "Rinoa,Squall,Selphie", "486824684286", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Quistis"),

            new PartyFormation(2321, 240, "3cf08056", "Irvine,Squall,Quistis", "868246842868", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Quistis"),

            new PartyFormation(2322, 5, "520508d7", "Irvine,Zell,Quistis", "682468428682", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Quistis"),

            new PartyFormation(2323, 32, "e22075c4", "Rinoa,Zell,Quistis", "824684286828", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Quistis"),

            new PartyFormation(2324, 76, "054c0cad", "Selphie,Zell,Quistis", "246842868288", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Quistis"),

            new PartyFormation(2325, 12, "280c4be2", "Irvine,Squall,Rinoa", "468428682888", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Quistis"),

            new PartyFormation(2326, 39, "df275b73", "Rinoa,Squall,Quistis", "684286828886", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Quistis"),

            new PartyFormation(2327, 145, "ef912a30", "Zell,Squall,Selphie", "842868288862", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Quistis"),

            new PartyFormation(2328, 201, "0cc9c6a9", "Zell,Squall,Quistis", "428682888622", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(2329, 39, "7c27442e", "Irvine,Squall,Rinoa", "286828886226", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Quistis"),

            new PartyFormation(2330, 18, "3d123bcf", "Irvine,Squall,Rinoa", "868288862264", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(2331, 22, "6016b95c", "Rinoa,Zell,Quistis", "682888622644", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Quistis"),

            new PartyFormation(2332, 79, "8f4f2465", "Selphie,Squall,Quistis", "828886226446", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Quistis"),

            new PartyFormation(2333, 231, "ece7753a", "Rinoa,Squall,Quistis", "288862264466", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(2334, 32, "c920c5eb", "Zell,Squall,Selphie", "888622644668", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(2335, 4, "5e040f48", "Irvine,Squall,Selphie", "886226446688", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(2336, 18, "5e12a1e1", "Rinoa,Squall,Selphie", "862264466884", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(2337, 71, "1047ab06", "Irvine,Squall,Rinoa", "622644668846", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(2338, 67, "9143d5c7", "Selphie,Squall,Quistis", "226446688466", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(2339, 238, "63eed7f4", "Selphie,Zell,Quistis", "264466884664", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(2340, 54, "4d367b1d", "Rinoa,Irvine,Selphie", "644668846644", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(2341, 35, "0f237192", "Irvine,Zell,Quistis", "446688466446", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(2342, 158, "279e0763", "Rinoa,Zell,Selphie", "466884664464", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(2343, 27, "de1b7f60", "Rinoa,Squall,Selphie", "668846644646", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(2344, 196, "d6c4ac19", "Rinoa,Irvine,Quistis", "688466446468", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(2345, 131, "d28314de", "Zell,Squall,Rinoa", "884664464686", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(2346, 223, "13dfb6bf", "Selphie,Squall,Quistis", "846644646866", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(2347, 169, "76a9318c", "Irvine,Squall,Quistis", "466446468662", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(2348, 106, "f16af0d5", "Selphie,Zell,Quistis", "664464686624", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2349, 167, "b9a7a0ea", "Irvine,Squall,Quistis", "644646866246", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2350, 98, "fe62ffdb", "Rinoa,Squall,Quistis", "446468662464", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2351, 125, "f87dda78", "Zell,Squall,Quistis", "464686624642", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(2352, 246, "96f6c551", "Irvine,Zell,Rinoa", "646866246424", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2353, 214, "a4d6e1b6", "Selphie,Squall,Quistis", "468662464244", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(2354, 7, "7107beb7", "Rinoa,Zell,Selphie", "686624642446", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(2355, 242, "74f22624", "Irvine,Zell,Quistis", "866246424464", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Quistis"),

            new PartyFormation(2356, 145, "3691658d", "Zell,Squall,Quistis", "662464244642", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2357, 231, "e0e76342", "Rinoa,Zell,Quistis", "624642446426", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2358, 207, "c9cf8f53", "Selphie,Irvine,Quistis", "246424464266", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2359, 61, "183d8090", "Selphie,Irvine,Quistis", "464244642662", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2360, 187, "0ebbcd89", "Rinoa,Irvine,Selphie", "642446426626", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Selphie"),

            new PartyFormation(2361, 140, "3f8c718e", "Irvine,Zell,Selphie", "424464266268", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Selphie"),

            new PartyFormation(2362, 57, "bb39cdaf", "Irvine,Zell,Selphie", "244642662682", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Selphie"),

            new PartyFormation(2363, 162, "d8a215bc", "Irvine,Squall,Selphie", "446426626824", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Quistis"),

            new PartyFormation(2364, 10, "2b0ab945", "Zell,Squall,Irvine", "464266268244", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(2365, 98, "6862189a", "Zell,Squall,Quistis", "642662682444", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(2366, 95, "765f95cb", "Rinoa,Squall,Selphie", "426626824446", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(2367, 88, "ec58d1a8", "Rinoa,Irvine,Quistis", "266268244468", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(2368, 162, "81a2a4c1", "Irvine,Zell,Rinoa", "662682444684", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(2369, 185, "2eb92466", "Irvine,Squall,Quistis", "626824446842", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(2370, 207, "5acfc3a7", "Zell,Squall,Selphie", "268244468426", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(2371, 61, "b23d6054", "Irvine,Zell,Quistis", "682444684262", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(2372, 115, "6c73cbfd", "Selphie,Squall,Quistis", "824446842626", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>17}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2373, 35, "782320f2", "Selphie,Zell,Quistis", "244468426266", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>16}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2374, 42, "c82af343", "Rinoa,Squall,Quistis", "444684262664", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>15}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2375, 58, "793a2dc0", "Rinoa,Irvine,Selphie", "446842626644", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>14}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2376, 54, "7a362af9", "Selphie,Zell,Quistis", "468426266444", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>13}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2377, 190, "ffbe5a3e", "Zell,Squall,Quistis", "684262664444", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2378, 127, "6d7f809f", "Irvine,Squall,Rinoa", "842626644446", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2379, 116, "527465ec", "Irvine,Squall,Quistis", "426266444468", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2380, 37, "53257db5", "Selphie,Zell,Quistis", "262664444682", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2381, 65, "0241dc4a", "Rinoa,Zell,Quistis", "626644446822", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2382, 101, "326587bb", "Irvine,Squall,Rinoa", "266444468222", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2383, 55, "da37f4d8", "Rinoa,Zell,Selphie", "664444682226", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2384, 125, "2d7d4031", "Zell,Squall,Irvine", "644446822262", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2385, 201, "9ec97316", "Irvine,Zell,Rinoa", "444468222622", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2386, 218, "95dae497", "Rinoa,Squall,Quistis", "444682226224", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2387, 163, "a3a38684", "Rinoa,Irvine,Selphie", "446822262246", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2388, 180, "0db4ae6d", "Irvine,Squall,Selphie", "468222622468", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2389, 97, "7861aaa2", "Selphie,Irvine,Quistis", "682226224682", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2390, 223, "1edf3333", "Irvine,Squall,Quistis", "822262246826", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2391, 20, "b31486f0", "Rinoa,Irvine,Selphie", "222622468268", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2392, 122, "ce7ac469", "Zell,Squall,Quistis", "226224682684", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2393, 83, "e453ceee", "Zell,Squall,Quistis", "262246826846", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2394, 207, "3acfcf8f", "Zell,Squall,Irvine", "622468268466", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2395, 83, "3353221c", "Selphie,Rinoa,Quistis", "224682684666", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2396, 114, "ac723e25", "Selphie,Squall,Quistis", "246826846664", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2397, 49, "b131ebfa", "Selphie,Squall,Quistis", "468268466642", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2398, 131, "a583d5ab", "Selphie,Irvine,Quistis", "682684666426", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2399, 126, "517e4408", "Rinoa,Irvine,Selphie", "826846664264", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Selphie"),

            new PartyFormation(2400, 173, "d1ad97a1", "Irvine,Squall,Selphie", "268466642642", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Selphie"),

            new PartyFormation(2401, 162, "52a2cdc6", "Rinoa,Irvine,Selphie", "684666426424", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Selphie"),

            new PartyFormation(2402, 40, "37282187", "Zell,Squall,Irvine", "846664264248", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Selphie"),

            new PartyFormation(2403, 183, "ebb798b4", "Zell,Squall,Quistis", "466642642486", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Selphie"),

            new PartyFormation(2404, 235, "1ceb0cdd", "Rinoa,Irvine,Selphie", "666426424866", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Selphie"),

            new PartyFormation(2405, 238, "fdee0052", "Zell,Squall,Irvine", "664264248664", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Selphie"),

            new PartyFormation(2406, 219, "b3db4f23", "Selphie,Squall,Quistis", "642642486646", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Selphie"),

            new PartyFormation(2407, 143, "7e8f8c20", "Irvine,Zell,Selphie", "426424866466", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Selphie"),

            new PartyFormation(2408, 144, "209099d9", "Zell,Squall,Rinoa", "264248664668", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(2409, 71, "0347cf9e", "Irvine,Zell,Quistis", "642486646686", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(2410, 9, "f909ba7f", "Irvine,Squall,Rinoa", "424866466862", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(2411, 49, "7d314a4c", "Rinoa,Squall,Quistis", "248664668622", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(2412, 103, "1567fa95", "Zell,Squall,Quistis", "486646686226", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(2413, 221, "6fdd47aa", "Irvine,Zell,Rinoa", "866466862262", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(2414, 137, "a4897f9b", "Zell,Squall,Selphie", "664668622622", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(2415, 78, "004ebf38", "Zell,Squall,Quistis", "646686226224", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(2416, 26, "3d1aab11", "Rinoa,Squall,Selphie", "466862262244", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(2417, 160, "c4a03476", "Irvine,Zell,Selphie", "668622622448", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(2418, 118, "11767a77", "Zell,Squall,Rinoa", "686226224484", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2419, 204, "77cc96e4", "Irvine,Squall,Rinoa", "862262244848", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2420, 109, "f06de74d", "Zell,Squall,Selphie", "622622448482", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2421, 211, "4dd32202", "Irvine,Zell,Selphie", "226224484826", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2422, 206, "46ce4713", "Rinoa,Squall,Selphie", "262244848264", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(2423, 46, "cb2e3d50", "Irvine,Squall,Selphie", "622448482644", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2424, 62, "553eab49", "Irvine,Zell,Rinoa", "224484826444", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2425, 85, "67555c4e", "Irvine,Squall,Rinoa", "244848264442", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2426, 204, "33cc416f", "Rinoa,Irvine,Quistis", "448482644428", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(2427, 193, "14c1de7c", "Irvine,Zell,Quistis", "484826444282", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2428, 61, "783db305", "Rinoa,Zell,Quistis", "848264442822", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2429, 174, "b9aeef5a", "Rinoa,Irvine,Quistis", "482644428224", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2430, 5, "5605858b", "Rinoa,Squall,Selphie", "826444282242", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2431, 140, "e38c6668", "Selphie,Squall,Quistis", "264442822428", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2432, 107, "466b7a81", "Zell,Squall,Rinoa", "644428224286", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2433, 220, "3bdca726", "Selphie,Irvine,Quistis", "444282242868", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2434, 68, "a544ef67", "Selphie,Squall,Quistis", "442822428688", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Quistis"),

            new PartyFormation(2435, 245, "aff58114", "Irvine,Squall,Quistis", "428224286882", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Quistis"),

            new PartyFormation(2436, 84, "a2543dbd", "Rinoa,Irvine,Quistis", "282242868828", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Quistis"),

            new PartyFormation(2437, 220, "85dc0fb2", "Rinoa,Irvine,Quistis", "822428688288", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(2438, 39, "61271b03", "Irvine,Zell,Rinoa", "224286882886", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Quistis"),

            new PartyFormation(2439, 51, "ef339a80", "Selphie,Rinoa,Quistis", "242868828866", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(2440, 11, "910bf8b9", "Zell,Squall,Quistis", "428688288666", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Quistis"),

            new PartyFormation(2441, 247, "bff774fe", "Irvine,Zell,Rinoa", "286882886666", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Quistis"),

            new PartyFormation(2442, 118, "1c76645f", "Rinoa,Zell,Selphie", "868828866664", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(2443, 119, "f177deac", "Rinoa,Squall,Selphie", "688288666646", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(2444, 234, "3aea6775", "Rinoa,Irvine,Selphie", "882886666464", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(2445, 209, "3ad1e30a", "Irvine,Squall,Rinoa", "828866664642", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(2446, 70, "2246e77b", "Rinoa,Irvine,Quistis", "288666646424", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(2447, 218, "76da3998", "Zell,Squall,Rinoa", "886666464244", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(2448, 7, "3c0705f1", "Zell,Squall,Irvine", "866664642446", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(2449, 51, "7c3325d6", "Rinoa,Zell,Quistis", "666646424466", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(2450, 210, "10d28057", "Rinoa,Irvine,Quistis", "666464244664", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(2451, 5, "a7055744", "Irvine,Zell,Quistis", "664642446642", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(2452, 117, "8075102d", "Rinoa,Zell,Selphie", "646424466422", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2453, 147, "4c93c962", "Zell,Squall,Selphie", "464244664226", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2454, 20, "4614caf3", "Rinoa,Irvine,Selphie", "642446642268", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2455, 162, "d7a2a3b0", "Selphie,Squall,Quistis", "424466422684", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2456, 63, "a83f8229", "Rinoa,Squall,Quistis", "244664226846", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(2457, 105, "116919ae", "Selphie,Zell,Quistis", "446642268462", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(2458, 39, "7a27234f", "Irvine,Squall,Selphie", "466422684626", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(2459, 134, "4d864adc", "Zell,Squall,Quistis", "664226846264", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(2460, 37, "af2517e5", "Rinoa,Irvine,Selphie", "642268462642", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(2461, 49, "803122ba", "Zell,Squall,Irvine", "422684626422", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(2462, 92, "a35ca56b", "Irvine,Zell,Selphie", "226846264228", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(2463, 155, "e49b38c8", "Zell,Squall,Selphie", "268462642286", "{Irvine,Zell,Selphie=>65, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2464, 20, "54144d61", "Rinoa,Squall,Quistis", "684626422868", "{Irvine,Zell,Selphie=>64, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2465, 62, "763eb086", "Rinoa,Zell,Selphie", "846264228684", "{Irvine,Zell,Selphie=>63, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2466, 30, "001e2d47", "Rinoa,Zell,Selphie", "462642286844", "{Irvine,Zell,Selphie=>62, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2467, 143, "4a8f1974", "Selphie,Irvine,Quistis", "626422868446", "{Irvine,Zell,Selphie=>61, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2468, 103, "7c675e9d", "Rinoa,Zell,Selphie", "264228684466", "{Irvine,Zell,Selphie=>60, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>94}", "Irvine,Zell,Quistis"),

            new PartyFormation(2469, 69, "81454f12", "Zell,Squall,Irvine", "642286844662", "{Irvine,Zell,Selphie=>59, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>93}", "Irvine,Zell,Quistis"),

            new PartyFormation(2470, 134, "e28656e3", "Irvine,Squall,Selphie", "422868446624", "{Irvine,Zell,Selphie=>58, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>92}", "Irvine,Zell,Quistis"),

            new PartyFormation(2471, 62, "383e58e0", "Rinoa,Squall,Selphie", "228684466244", "{Irvine,Zell,Selphie=>57, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>91}", "Irvine,Zell,Quistis"),

            new PartyFormation(2472, 224, "8ee04799", "Irvine,Zell,Rinoa", "286844662448", "{Irvine,Zell,Selphie=>56, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>90}", "Irvine,Zell,Quistis"),

            new PartyFormation(2473, 165, "64a54a5e", "Selphie,Rinoa,Quistis", "868446624482", "{Irvine,Zell,Selphie=>55, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>89}", "Irvine,Zell,Quistis"),

            new PartyFormation(2474, 189, "99bd7e3f", "Rinoa,Irvine,Selphie", "684466244822", "{Irvine,Zell,Selphie=>54, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>88}", "Irvine,Zell,Quistis"),

            new PartyFormation(2475, 224, "d5e0230c", "Zell,Squall,Quistis", "844662448228", "{Irvine,Zell,Selphie=>53, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>87}", "Irvine,Zell,Quistis"),

            new PartyFormation(2476, 100, "8264c455", "Rinoa,Irvine,Selphie", "446624482288", "{Irvine,Zell,Selphie=>52, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>86}", "Irvine,Zell,Quistis"),

            new PartyFormation(2477, 119, "a777ae6a", "Rinoa,Squall,Quistis", "466244822886", "{Irvine,Zell,Selphie=>51, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>85}", "Irvine,Zell,Quistis"),

            new PartyFormation(2478, 21, "9515bf5b", "Zell,Squall,Quistis", "662448228862", "{Irvine,Zell,Selphie=>50, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>84}", "Irvine,Zell,Quistis"),

            new PartyFormation(2479, 242, "35f263f8", "Irvine,Zell,Quistis", "624482288624", "{Irvine,Zell,Selphie=>49, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>83}", "Irvine,Zell,Quistis"),

            new PartyFormation(2480, 122, "1c7a50d1", "Rinoa,Squall,Quistis", "244822886244", "{Irvine,Zell,Selphie=>48, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>82}", "Irvine,Zell,Quistis"),

            new PartyFormation(2481, 90, "f75a4736", "Zell,Squall,Selphie", "448228862444", "{Irvine,Zell,Selphie=>47, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>81}", "Irvine,Zell,Quistis"),

            new PartyFormation(2482, 230, "9ce6f637", "Zell,Squall,Irvine", "482288624444", "{Irvine,Zell,Selphie=>46, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>80}", "Irvine,Zell,Quistis"),

            new PartyFormation(2483, 229, "92e5c7a4", "Rinoa,Irvine,Selphie", "822886244442", "{Irvine,Zell,Selphie=>45, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>79}", "Irvine,Zell,Quistis"),

            new PartyFormation(2484, 130, "9b82290d", "Rinoa,Irvine,Quistis", "228862444424", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>78}", "Irvine,Zell,Quistis"),

            new PartyFormation(2485, 251, "ebfba0c2", "Irvine,Squall,Rinoa", "288624444246", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>77}", "Irvine,Zell,Quistis"),

            new PartyFormation(2486, 42, "bd2abed3", "Rinoa,Squall,Quistis", "886244442464", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>76}", "Irvine,Zell,Quistis"),

            new PartyFormation(2487, 137, "bb89ba10", "Rinoa,Irvine,Quistis", "862444424642", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>75}", "Irvine,Zell,Quistis"),

            new PartyFormation(2488, 181, "c8b54909", "Rinoa,Squall,Selphie", "624444246422", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>74}", "Irvine,Zell,Quistis"),

            new PartyFormation(2489, 103, "7767070e", "Rinoa,Irvine,Quistis", "244442464226", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>73}", "Irvine,Zell,Quistis"),

            new PartyFormation(2490, 216, "3dd8752f", "Rinoa,Squall,Quistis", "444424642268", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>72}", "Irvine,Zell,Quistis"),

            new PartyFormation(2491, 56, "da38673c", "Rinoa,Squall,Selphie", "444246422688", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>71}", "Irvine,Zell,Quistis"),

            new PartyFormation(2492, 224, "2de06cc5", "Rinoa,Zell,Quistis", "442464226888", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>70}", "Irvine,Zell,Quistis"),

            new PartyFormation(2493, 16, "0f10861a", "Selphie,Squall,Quistis", "424642268888", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>69}", "Irvine,Zell,Quistis"),

            new PartyFormation(2494, 1, "c501354b", "Zell,Squall,Selphie", "246422688882", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>68}", "Irvine,Zell,Quistis"),

            new PartyFormation(2495, 194, "82c2bb28", "Irvine,Squall,Rinoa", "464226888824", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>67}", "Irvine,Zell,Quistis"),

            new PartyFormation(2496, 224, "eae01041", "Selphie,Zell,Quistis", "642268888248", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>66}", "Irvine,Zell,Quistis"),

            new PartyFormation(2497, 160, "59a0e9e6", "Zell,Squall,Quistis", "422688882488", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>65}", "Irvine,Zell,Quistis"),

            new PartyFormation(2498, 171, "7eabdb27", "Rinoa,Irvine,Selphie", "226888824886", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>64}", "Irvine,Zell,Quistis"),

            new PartyFormation(2499, 28, "b31c61d4", "Selphie,Zell,Quistis", "268888248868", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>63}", "Irvine,Zell,Quistis"),

            new PartyFormation(2500, 220, "66dc6f7d", "Zell,Squall,Rinoa", "688882488688", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>62}", "Irvine,Zell,Quistis"),

            new PartyFormation(2501, 129, "ed81be72", "Selphie,Rinoa,Quistis", "888824886882", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>61}", "Irvine,Zell,Quistis"),

            new PartyFormation(2502, 113, "e67102c3", "Irvine,Zell,Rinoa", "888248868822", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>60}", "Irvine,Zell,Quistis"),

            new PartyFormation(2503, 199, "32c7c740", "Zell,Squall,Selphie", "882488688226", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>59}", "Irvine,Zell,Quistis"),

            new PartyFormation(2504, 69, "d9458679", "Irvine,Zell,Quistis", "824886882262", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>58}", "Irvine,Zell,Quistis"),

            new PartyFormation(2505, 41, "6c294fbe", "Zell,Squall,Rinoa", "248868822622", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>57}", "Irvine,Zell,Quistis"),

            new PartyFormation(2506, 215, "8ed7081f", "Rinoa,Irvine,Quistis", "488688226226", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>56}", "Irvine,Zell,Quistis"),

            new PartyFormation(2507, 2, "7d02176c", "Selphie,Squall,Quistis", "886882262264", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>55}", "Irvine,Zell,Quistis"),

            new PartyFormation(2508, 143, "668f1135", "Zell,Squall,Selphie", "868822622646", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>54}", "Irvine,Zell,Quistis"),

            new PartyFormation(2509, 38, "0626a9ca", "Selphie,Zell,Quistis", "688226226464", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>53}", "Irvine,Zell,Quistis"),

            new PartyFormation(2510, 110, "026e073b", "Rinoa,Zell,Selphie", "882262264644", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>52}", "Irvine,Zell,Quistis"),

            new PartyFormation(2511, 175, "21af3e58", "Irvine,Squall,Selphie", "822622646446", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>51}", "Irvine,Zell,Quistis"),

            new PartyFormation(2512, 172, "4cac8bb1", "Zell,Squall,Rinoa", "226226464468", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>50}", "Irvine,Zell,Quistis"),

            new PartyFormation(2513, 237, "33ed9896", "Rinoa,Zell,Quistis", "262264644682", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>49}", "Irvine,Zell,Quistis"),

            new PartyFormation(2514, 171, "9aabdc17", "Rinoa,Zell,Quistis", "622646446826", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>48}", "Irvine,Zell,Quistis"),

            new PartyFormation(2515, 5, "4905e804", "Selphie,Zell,Quistis", "226464468262", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>47}", "Irvine,Zell,Quistis"),

            new PartyFormation(2516, 77, "5b4d31ed", "Selphie,Zell,Quistis", "264644682622", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>46}", "Irvine,Zell,Quistis"),

            new PartyFormation(2517, 98, "2f62a822", "Rinoa,Squall,Quistis", "646446826224", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>45}", "Irvine,Zell,Quistis"),

            new PartyFormation(2518, 136, "e88822b3", "Selphie,Zell,Quistis", "464468262248", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>44}", "Irvine,Zell,Quistis"),

            new PartyFormation(2519, 251, "c5fb8070", "Rinoa,Irvine,Selphie", "644682622486", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>43}", "Irvine,Zell,Quistis"),

            new PartyFormation(2520, 215, "b3d7ffe9", "Selphie,Zell,Quistis", "446826224866", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>42}", "Irvine,Zell,Quistis"),

            new PartyFormation(2521, 39, "7a27246e", "Rinoa,Zell,Quistis", "468262248666", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>41}", "Irvine,Zell,Quistis"),

            new PartyFormation(2522, 216, "0ad8370f", "Irvine,Zell,Quistis", "682622486668", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>40}", "Irvine,Zell,Quistis"),

            new PartyFormation(2523, 112, "e370339c", "Zell,Squall,Rinoa", "826224866688", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>39}", "Irvine,Zell,Selphie"),

            new PartyFormation(2524, 39, "8d27b1a5", "Rinoa,Squall,Selphie", "262248666886", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Selphie"),

            new PartyFormation(2525, 165, "7ca5197a", "Rinoa,Irvine,Selphie", "622486668862", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Selphie"),

            new PartyFormation(2526, 107, "0e6b352b", "Rinoa,Irvine,Selphie", "224866688626", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Selphie"),

            new PartyFormation(2527, 26, "d81aed88", "Zell,Squall,Irvine", "248666886264", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Selphie"),

            new PartyFormation(2528, 6, "7706c321", "Irvine,Zell,Selphie", "486668862644", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Selphie"),

            new PartyFormation(2529, 219, "09db5346", "Selphie,Squall,Quistis", "866688626446", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Quistis"),

            new PartyFormation(2530, 229, "33e5f907", "Zell,Squall,Quistis", "666886264462", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Quistis"),

            new PartyFormation(2531, 53, "8d355a34", "Rinoa,Zell,Quistis", "668862644622", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Quistis"),

            new PartyFormation(2532, 107, "596b705d", "Zell,Squall,Selphie", "688626446226", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(2533, 233, "53e95dd2", "Rinoa,Squall,Selphie", "886264462262", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Quistis"),

            new PartyFormation(2534, 95, "b75f1ea3", "Selphie,Rinoa,Quistis", "862644622626", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(2535, 231, "23e7e5a0", "Irvine,Zell,Rinoa", "626446226266", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Quistis"),

            new PartyFormation(2536, 115, "2b73b559", "Selphie,Rinoa,Quistis", "264462262666", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Quistis"),

            new PartyFormation(2537, 91, "9d5b851e", "Rinoa,Irvine,Quistis", "644622626666", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(2538, 187, "75bb01ff", "Zell,Squall,Irvine", "446226266666", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(2539, 117, "6575bbcc", "Irvine,Squall,Selphie", "462262666662", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(2540, 33, "1e214e15", "Irvine,Zell,Quistis", "622626666622", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(2541, 54, "b336d52a", "Rinoa,Irvine,Selphie", "226266666224", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(2542, 199, "8bc7bf1b", "Irvine,Squall,Rinoa", "262666662246", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(2543, 40, "0a28c8b8", "Irvine,Squall,Selphie", "626666622468", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(2544, 213, "b6d5b691", "Rinoa,Squall,Quistis", "266666224682", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(2545, 197, "fbc519f6", "Rinoa,Zell,Quistis", "666662246822", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(2546, 25, "cb1931f7", "Irvine,Squall,Selphie", "666622468222", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(2547, 253, "82fdb864", "Irvine,Squall,Rinoa", "666224682222", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2548, 142, "158e2acd", "Irvine,Squall,Rinoa", "662246822224", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2549, 32, "a620df82", "Rinoa,Squall,Quistis", "622468222248", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2550, 164, "a0a4f693", "Rinoa,Zell,Quistis", "224682222488", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2551, 15, "b20ff6d0", "Irvine,Zell,Selphie", "246822224886", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(2552, 223, "62dfa6c9", "Zell,Squall,Selphie", "468222248866", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2553, 129, "468171ce", "Irvine,Squall,Selphie", "682222488662", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2554, 30, "c91e68ef", "Zell,Squall,Irvine", "822224886624", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2555, 197, "bdc5affc", "Zell,Squall,Quistis", "222248866242", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2556, 178, "21b2e685", "Rinoa,Zell,Quistis", "222488662424", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2557, 70, "eb46dcda", "Rinoa,Zell,Selphie", "224886624244", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2558, 18, "ef12a50b", "Rinoa,Squall,Selphie", "248866242444", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2559, 187, "eabbcfe8", "Rinoa,Irvine,Selphie", "488662424446", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2560, 192, "e0c06601", "Rinoa,Squall,Selphie", "886624244468", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2561, 197, "76c5eca6", "Rinoa,Zell,Selphie", "866242444682", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2562, 196, "0ec486e7", "Selphie,Irvine,Quistis", "662424446828", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2563, 114, "28720294", "Irvine,Zell,Quistis", "624244468284", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(2564, 204, "87cc613d", "Selphie,Zell,Quistis", "242444682848", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(2565, 212, "c9d42d32", "Rinoa,Irvine,Selphie", "424446828488", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(2566, 200, "3bc8aa83", "Irvine,Squall,Quistis", "244468284888", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(2567, 182, "bcb6b400", "Zell,Squall,Irvine", "444682848884", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(2568, 162, "3ca2d439", "Selphie,Rinoa,Quistis", "446828488844", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(2569, 19, "0b13ea7e", "Selphie,Squall,Quistis", "468284888446", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2570, 97, "24616bdf", "Selphie,Squall,Quistis", "682848884462", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2571, 211, "39d3102c", "Rinoa,Squall,Selphie", "828488844626", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2572, 211, "9bd37af5", "Rinoa,Squall,Selphie", "284888446266", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2573, 0, "1700308a", "Zell,Squall,Quistis", "848884462668", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(2574, 154, "6e9ae6fb", "Selphie,Squall,Quistis", "488844626684", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(2575, 119, "ab770318", "Zell,Squall,Rinoa", "888446266846", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(2576, 45, "c12dd171", "Selphie,Rinoa,Quistis", "884462668462", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(2577, 184, "e4b8cb56", "Irvine,Squall,Rinoa", "844626684628", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(2578, 38, "cb26f7d7", "Selphie,Zell,Quistis", "446266846284", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(2579, 101, "a66538c4", "Zell,Squall,Irvine", "462668462842", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(2580, 253, "5bfd13ad", "Irvine,Squall,Quistis", "626684628422", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Selphie"),

            new PartyFormation(2581, 142, "6b8e46e2", "Rinoa,Zell,Quistis", "266846284224", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Selphie"),

            new PartyFormation(2582, 249, "59f93a73", "Rinoa,Irvine,Quistis", "668462842242", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>2}", "Irvine,Zell,Selphie"),

            new PartyFormation(2583, 223, "a6df1d30", "Irvine,Zell,Selphie", "684628422426", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>1}", "Irvine,Zell,Selphie"),

            new PartyFormation(2584, 4, "cb043da9", "Selphie,Irvine,Quistis", "846284224268", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2585, 77, "554def2e", "Rinoa,Zell,Quistis", "462842242682", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2586, 163, "bca30acf", "Rinoa,Irvine,Quistis", "628422426826", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2587, 208, "e9d0dc5c", "Selphie,Squall,Quistis", "284224268268", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2588, 58, "fc3a0b65", "Rinoa,Irvine,Selphie", "842242682684", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2589, 77, "894dd03a", "Rinoa,Zell,Selphie", "422426826842", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2590, 111, "f26f84eb", "Selphie,Squall,Quistis", "224268268426", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2591, 189, "acbd6248", "Zell,Squall,Selphie", "242682684262", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2592, 68, "8c44f8e1", "Irvine,Zell,Rinoa", "426826842628", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2593, 56, "5c38b606", "Selphie,Irvine,Quistis", "268268426288", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2594, 63, "da3f84c7", "Irvine,Squall,Selphie", "682684262886", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(2595, 106, "806a5af4", "Irvine,Squall,Quistis", "826842628864", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(2596, 183, "61b7421d", "Zell,Squall,Irvine", "268426288646", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(2597, 154, "f09a2c92", "Rinoa,Irvine,Quistis", "684262886464", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2598, 37, "f625a663", "Irvine,Squall,Selphie", "842628864642", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2599, 76, "1a4c3260", "Rinoa,Irvine,Selphie", "426288646428", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2600, 10, "c00ae319", "Zell,Squall,Quistis", "262886464284", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(2601, 42, "142a7fde", "Zell,Squall,Rinoa", "628864642844", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2602, 194, "ccc245bf", "Irvine,Zell,Rinoa", "288646428444", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(2603, 178, "d0b2148c", "Irvine,Zell,Quistis", "886464284444", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(2604, 93, "8e5d97d5", "Irvine,Squall,Selphie", "864642844442", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2605, 218, "a5dabbea", "Rinoa,Squall,Quistis", "646428444424", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2606, 95, "045f7edb", "Zell,Squall,Selphie", "464284444246", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2607, 177, "adb1ed78", "Selphie,Irvine,Quistis", "642844442462", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2608, 236, "4decdc51", "Zell,Squall,Quistis", "428444424628", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2609, 160, "50a0acb6", "Irvine,Squall,Selphie", "284444246288", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2610, 205, "13cd2db7", "Irvine,Zell,Rinoa", "844442462882", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2611, 212, "c4d46924", "Zell,Squall,Rinoa", "444424628828", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2612, 81, "fc51ec8d", "Selphie,Irvine,Quistis", "444246288282", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2613, 2, "2702de42", "Selphie,Irvine,Quistis", "442462882824", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2614, 252, "24fcee53", "Zell,Squall,Irvine", "424628828248", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(2615, 128, "3780f390", "Zell,Squall,Rinoa", "246288282488", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(2616, 125, "dd7dc489", "Irvine,Zell,Selphie", "462882824882", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(2617, 100, "6b649c8e", "Zell,Squall,Quistis", "628828248828", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2618, 94, "855e1caf", "Rinoa,Squall,Selphie", "288282488284", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2619, 41, "1429b8bc", "Rinoa,Irvine,Selphie", "882824882842", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2620, 117, "e9752045", "Irvine,Zell,Selphie", "828248828422", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2621, 17, "9111f39a", "Irvine,Squall,Quistis", "282488284222", "{Irvine,Zell,Selphie=>105, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(2622, 249, "bff9d4cb", "Rinoa,Irvine,Selphie", "824882842222", "{Irvine,Zell,Selphie=>104, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2623, 55, "fc37a4a8", "Zell,Squall,Selphie", "248828422226", "{Irvine,Zell,Selphie=>103, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2624, 204, "59cc7bc1", "Irvine,Zell,Quistis", "488284222268", "{Irvine,Zell,Selphie=>102, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2625, 11, "420baf66", "Irvine,Squall,Selphie", "882842222686", "{Irvine,Zell,Selphie=>101, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2626, 78, "3d4ef2a7", "Selphie,Squall,Quistis", "828422226864", "{Irvine,Zell,Selphie=>100, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2627, 182, "3cb66354", "Rinoa,Zell,Selphie", "284222268644", "{Irvine,Zell,Selphie=>99, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2628, 228, "92e412fd", "Rinoa,Zell,Quistis", "842222686448", "{Irvine,Zell,Selphie=>98, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2629, 147, "f5935bf2", "Zell,Squall,Quistis", "422226864486", "{Irvine,Zell,Selphie=>97, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2630, 238, "04ee1243", "Irvine,Zell,Rinoa", "222268644864", "{Irvine,Zell,Selphie=>96, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2631, 192, "c5c060c0", "Rinoa,Squall,Selphie", "222686448648", "{Irvine,Zell,Selphie=>95, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2632, 227, "64e3e1f9", "Selphie,Irvine,Quistis", "226864486486", "{Irvine,Zell,Selphie=>94, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2633, 119, "6377453e", "Irvine,Zell,Quistis", "268644864866", "{Irvine,Zell,Selphie=>93, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2634, 213, "fcd58f9f", "Irvine,Squall,Quistis", "686448648662", "{Irvine,Zell,Selphie=>92, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2635, 170, "2caac8ec", "Rinoa,Irvine,Selphie", "864486486624", "{Irvine,Zell,Selphie=>91, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2636, 119, "6077a4b5", "Irvine,Squall,Quistis", "644864866246", "{Irvine,Zell,Selphie=>90, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2637, 30, "e01e774a", "Zell,Squall,Selphie", "448648662464", "{Irvine,Zell,Selphie=>89, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2638, 141, "c28d86bb", "Rinoa,Irvine,Quistis", "486486624642", "{Irvine,Zell,Selphie=>88, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2639, 241, "a4f187d8", "Zell,Squall,Quistis", "864866246422", "{Irvine,Zell,Selphie=>87, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2640, 74, "bb4ad731", "Selphie,Squall,Quistis", "648662464224", "{Irvine,Zell,Selphie=>86, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2641, 84, "6d54be16", "Selphie,Irvine,Quistis", "486624642248", "{Irvine,Zell,Selphie=>85, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2642, 3, "fa03d397", "Selphie,Zell,Quistis", "866246422486", "{Irvine,Zell,Selphie=>84, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2643, 227, "9be34984", "Zell,Squall,Quistis", "662464224866", "{Irvine,Zell,Selphie=>83, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2644, 68, "0044b56d", "Zell,Squall,Irvine", "624642248668", "{Irvine,Zell,Selphie=>82, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2645, 214, "0bd6a5a2", "Rinoa,Zell,Selphie", "246422486684", "{Irvine,Zell,Selphie=>81, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(2646, 40, "ae281233", "Rinoa,Irvine,Quistis", "464224866848", "{Irvine,Zell,Selphie=>80, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2647, 13, "630d79f0", "Selphie,Squall,Quistis", "642248668482", "{Irvine,Zell,Selphie=>79, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(2648, 132, "87843b69", "Irvine,Zell,Quistis", "422486684828", "{Irvine,Zell,Selphie=>78, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(2649, 157, "999d79ee", "Irvine,Zell,Quistis", "224866848282", "{Irvine,Zell,Selphie=>77, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Quistis"),

            new PartyFormation(2650, 71, "1f479e8f", "Selphie,Zell,Quistis", "248668482826", "{Irvine,Zell,Selphie=>76, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2651, 104, "1568451c", "Zell,Squall,Rinoa", "486684828268", "{Irvine,Zell,Selphie=>75, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2652, 28, "721c2525", "Selphie,Irvine,Quistis", "866848282688", "{Irvine,Zell,Selphie=>74, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2653, 235, "48eb46fa", "Irvine,Squall,Selphie", "668482826886", "{Irvine,Zell,Selphie=>73, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>16}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2654, 41, "1b2994ab", "Irvine,Squall,Rinoa", "684828268862", "{Irvine,Zell,Selphie=>72, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>15}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2655, 66, "a3429708", "Irvine,Squall,Selphie", "848282688624", "{Irvine,Zell,Selphie=>71, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>14}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2656, 142, "a58eeea1", "Zell,Squall,Irvine", "482826886244", "{Irvine,Zell,Selphie=>70, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>13}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2657, 22, "7c16d8c6", "Rinoa,Irvine,Quistis", "828268862444", "{Irvine,Zell,Selphie=>69, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2658, 234, "baead087", "Selphie,Zell,Quistis", "282688624444", "{Irvine,Zell,Selphie=>68, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2659, 238, "b0ee1bb4", "Selphie,Squall,Quistis", "826886244444", "{Irvine,Zell,Selphie=>67, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2660, 10, "030ad3dd", "Zell,Squall,Irvine", "268862444444", "{Irvine,Zell,Selphie=>66, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2661, 23, "9217bb52", "Irvine,Squall,Rinoa", "688624444446", "{Irvine,Zell,Selphie=>65, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2662, 153, "2299ee23", "Rinoa,Irvine,Quistis", "886244444462", "{Irvine,Zell,Selphie=>64, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2663, 43, "b42b3f20", "Selphie,Rinoa,Quistis", "862444444626", "{Irvine,Zell,Selphie=>63, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2664, 101, "d665d0d9", "Rinoa,Irvine,Selphie", "624444446262", "{Irvine,Zell,Selphie=>62, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2665, 210, "efd23a9e", "Irvine,Squall,Selphie", "244444462624", "{Irvine,Zell,Selphie=>61, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2666, 147, "9e93497f", "Zell,Squall,Rinoa", "444444626246", "{Irvine,Zell,Selphie=>60, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2667, 85, "7c552d4c", "Rinoa,Irvine,Selphie", "444446262462", "{Irvine,Zell,Selphie=>59, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2668, 217, "38d9a195", "Irvine,Zell,Rinoa", "444462624622", "{Irvine,Zell,Selphie=>58, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2669, 35, "522362aa", "Selphie,Irvine,Quistis", "444626246226", "{Irvine,Zell,Selphie=>57, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2670, 156, "3a9cfe9b", "Irvine,Zell,Rinoa", "446262462268", "{Irvine,Zell,Selphie=>56, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(2671, 77, "114dd238", "Irvine,Squall,Rinoa", "462624622682", "{Irvine,Zell,Selphie=>55, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(2672, 127, "e37fc211", "Irvine,Squall,Quistis", "626246226826", "{Irvine,Zell,Selphie=>54, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(2673, 172, "34acff76", "Rinoa,Squall,Quistis", "262462268268", "{Irvine,Zell,Selphie=>53, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(2674, 194, "aec2e977", "Irvine,Zell,Quistis", "624622682684", "{Irvine,Zell,Selphie=>52, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2675, 41, "9529d9e4", "Irvine,Squall,Rinoa", "246226826842", "{Irvine,Zell,Selphie=>51, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2676, 141, "ad8d6e4d", "Irvine,Zell,Quistis", "462268268422", "{Irvine,Zell,Selphie=>50, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2677, 97, "d9619d02", "Selphie,Squall,Quistis", "622682684222", "{Irvine,Zell,Selphie=>49, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2678, 242, "3df2a613", "Zell,Squall,Selphie", "226826842224", "{Irvine,Zell,Selphie=>48, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2679, 156, "949cb050", "Zell,Squall,Selphie", "268268422248", "{Irvine,Zell,Selphie=>47, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2680, 79, "b24fa249", "Selphie,Squall,Quistis", "682684222486", "{Irvine,Zell,Selphie=>46, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2681, 208, "3cd0874e", "Irvine,Squall,Selphie", "826842224868", "{Irvine,Zell,Selphie=>45, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2682, 87, "e257906f", "Irvine,Squall,Selphie", "268422248686", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2683, 36, "f224817c", "Zell,Squall,Rinoa", "684222486868", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2684, 231, "dae71a05", "Selphie,Irvine,Quistis", "842224868686", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2685, 49, "0331ca5a", "Zell,Squall,Selphie", "422248686862", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>52}", "Irvine,Zell,Quistis"),

            new PartyFormation(2686, 118, "e376c48b", "Irvine,Squall,Quistis", "222486868624", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>51}", "Irvine,Zell,Quistis"),

            new PartyFormation(2687, 246, "57f63968", "Rinoa,Irvine,Selphie", "224868686244", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>50}", "Irvine,Zell,Quistis"),

            new PartyFormation(2688, 196, "47c45181", "Irvine,Squall,Rinoa", "248686862448", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>49}", "Irvine,Zell,Quistis"),

            new PartyFormation(2689, 50, "2a323226", "Rinoa,Zell,Quistis", "486868624484", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>48}", "Irvine,Zell,Quistis"),

            new PartyFormation(2690, 11, "b20b1e67", "Irvine,Squall,Quistis", "868686244846", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>47}", "Irvine,Zell,Quistis"),

            new PartyFormation(2691, 169, "dca98414", "Rinoa,Zell,Selphie", "686862448462", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>46}", "Irvine,Zell,Quistis"),

            new PartyFormation(2692, 227, "d5e384bd", "Rinoa,Zell,Quistis", "868624484626", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>45}", "Irvine,Zell,Quistis"),

            new PartyFormation(2693, 127, "0b7f4ab2", "Rinoa,Zell,Quistis", "686244846266", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>44}", "Irvine,Zell,Quistis"),

            new PartyFormation(2694, 161, "a5a13a03", "Zell,Squall,Irvine", "862448462662", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>43}", "Irvine,Zell,Quistis"),

            new PartyFormation(2695, 164, "46a4cd80", "Selphie,Rinoa,Quistis", "624484626628", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>42}", "Irvine,Zell,Quistis"),

            new PartyFormation(2696, 200, "bbc8afb9", "Irvine,Squall,Selphie", "244846266288", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>41}", "Irvine,Zell,Quistis"),

            new PartyFormation(2697, 19, "fc135ffe", "Zell,Squall,Selphie", "448462662886", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>40}", "Irvine,Zell,Quistis"),

            new PartyFormation(2698, 243, "f7f3735f", "Zell,Squall,Rinoa", "484626628866", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>39}", "Irvine,Zell,Quistis"),

            new PartyFormation(2699, 73, "1a4941ac", "Irvine,Zell,Rinoa", "846266288662", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Quistis"),

            new PartyFormation(2700, 59, "fa3b8e75", "Selphie,Zell,Quistis", "462662886626", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Quistis"),

            new PartyFormation(2701, 65, "94417e0a", "Selphie,Squall,Quistis", "626628866262", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Quistis"),

            new PartyFormation(2702, 5, "1a05e67b", "Selphie,Zell,Quistis", "266288662622", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Quistis"),

            new PartyFormation(2703, 222, "5edecc98", "Rinoa,Squall,Selphie", "662886626224", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Quistis"),

            new PartyFormation(2704, 195, "1cc39cf1", "Irvine,Squall,Selphie", "628866262246", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Quistis"),

            new PartyFormation(2705, 129, "6c8170d6", "Rinoa,Zell,Quistis", "288662622462", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Quistis"),

            new PartyFormation(2706, 2, "3f026f57", "Rinoa,Squall,Selphie", "886626224624", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Quistis"),

            new PartyFormation(2707, 64, "c6401a44", "Selphie,Rinoa,Quistis", "866262246248", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(2708, 228, "85e4172d", "Rinoa,Zell,Quistis", "662622462488", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Quistis"),

            new PartyFormation(2709, 251, "dafbc462", "Zell,Squall,Irvine", "626224624886", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(2710, 212, "b8d4a9f3", "Irvine,Zell,Rinoa", "262246248868", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Quistis"),

            new PartyFormation(2711, 70, "a34696b0", "Irvine,Squall,Quistis", "622462488684", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Quistis"),

            new PartyFormation(2712, 23, "4317f929", "Irvine,Zell,Quistis", "224624886846", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(2713, 213, "fdd5c4ae", "Zell,Squall,Selphie", "246248868462", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(2714, 133, "8285f24f", "Zell,Squall,Rinoa", "462488684622", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(2715, 246, "daf66ddc", "Irvine,Zell,Quistis", "624886846224", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(2716, 141, "248dfee5", "Selphie,Squall,Quistis", "248868462242", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(2717, 61, "1e3d7dba", "Rinoa,Squall,Quistis", "488684622422", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(2718, 89, "1459646b", "Rinoa,Irvine,Quistis", "886846224222", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(2719, 106, "bc6a8bc8", "Zell,Squall,Quistis", "868462242224", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(2720, 164, "94a4a461", "Selphie,Zell,Quistis", "684622422248", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(2721, 53, "3835bb86", "Selphie,Rinoa,Quistis", "846224222482", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(2722, 167, "5da7dc47", "Irvine,Squall,Quistis", "462242224826", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2723, 128, "6b809c74", "Selphie,Rinoa,Quistis", "622422248268", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2724, 38, "6b26259d", "Rinoa,Irvine,Quistis", "224222482684", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2725, 34, "33220a12", "Irvine,Squall,Rinoa", "242224826844", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2726, 123, "807bf5e3", "Irvine,Zell,Selphie", "422248268446", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(2727, 69, "4a450be0", "Rinoa,Zell,Quistis", "222482684462", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2728, 68, "b8447e99", "Rinoa,Zell,Quistis", "224826844628", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2729, 18, "1712b55e", "Irvine,Squall,Selphie", "248268446284", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2730, 238, "aaee0d3f", "Selphie,Squall,Quistis", "482684462844", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2731, 31, "8d1f060c", "Rinoa,Zell,Quistis", "826844628446", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2732, 85, "43556b55", "Zell,Squall,Selphie", "268446284462", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2733, 208, "4ad0c96a", "Irvine,Squall,Rinoa", "684462844628", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2734, 64, "2a403e5b", "Irvine,Squall,Quistis", "844628446288", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2735, 188, "e5bc76f8", "Zell,Squall,Irvine", "446284462888", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2736, 78, "394e67d1", "Rinoa,Zell,Quistis", "462844628884", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2737, 170, "a6aa1236", "Selphie,Irvine,Quistis", "628446288844", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2738, 186, "93ba6537", "Irvine,Squall,Selphie", "284462888444", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>41}", "Irvine,Zell,Selphie"),

            new PartyFormation(2739, 190, "f0be0aa4", "Irvine,Squall,Quistis", "844628884444", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>40}", "Irvine,Zell,Selphie"),

            new PartyFormation(2740, 0, "4700b00d", "Irvine,Squall,Rinoa", "446288844448", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>39}", "Irvine,Zell,Selphie"),

            new PartyFormation(2741, 253, "e7fd1bc2", "Rinoa,Irvine,Quistis", "462888444482", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Selphie"),

            new PartyFormation(2742, 70, "9f461dd3", "Selphie,Zell,Quistis", "628884444824", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Selphie"),

            new PartyFormation(2743, 35, "d2232d10", "Selphie,Squall,Quistis", "288844448246", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Selphie"),

            new PartyFormation(2744, 21, "1b154009", "Irvine,Zell,Rinoa", "888444482462", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Selphie"),

            new PartyFormation(2745, 133, "d185320e", "Irvine,Squall,Quistis", "884444824622", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Selphie"),

            new PartyFormation(2746, 202, "0fcac42f", "Rinoa,Squall,Selphie", "844448246224", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Selphie"),

            new PartyFormation(2747, 118, "2c760a3c", "Rinoa,Zell,Selphie", "444482462244", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Selphie"),

            new PartyFormation(2748, 200, "0bc8d3c5", "Irvine,Zell,Selphie", "444824622448", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Selphie"),

            new PartyFormation(2749, 102, "0466611a", "Selphie,Zell,Quistis", "448246224484", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Selphie"),

            new PartyFormation(2750, 73, "c549744b", "Irvine,Zell,Selphie", "482462244842", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Selphie"),

            new PartyFormation(2751, 183, "5eb78e28", "Irvine,Zell,Quistis", "824622448426", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(2752, 103, "5c67e741", "Zell,Squall,Irvine", "246224484266", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Selphie"),

            new PartyFormation(2753, 249, "5df974e6", "Rinoa,Zell,Quistis", "462244842662", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Selphie"),

            new PartyFormation(2754, 185, "d4b90a27", "Zell,Squall,Rinoa", "622448426622", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Selphie"),

            new PartyFormation(2755, 11, "b50b64d4", "Irvine,Squall,Quistis", "224484266226", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(2756, 138, "5e8ab67d", "Rinoa,Squall,Quistis", "244842662264", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(2757, 87, "6657f972", "Irvine,Squall,Quistis", "448426622646", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(2758, 162, "41a221c3", "Rinoa,Squall,Quistis", "484266226464", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(2759, 35, "f823fa40", "Irvine,Zell,Selphie", "842662264646", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(2760, 17, "6b113d79", "Rinoa,Zell,Quistis", "426622646462", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(2761, 168, "1ba83abe", "Rinoa,Irvine,Selphie", "266226464628", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(2762, 123, "b57b171f", "Irvine,Zell,Rinoa", "662264646286", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(2763, 110, "876e7a6c", "Irvine,Squall,Selphie", "622646462864", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(2764, 223, "6edf3835", "Selphie,Squall,Quistis", "226464628646", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(2765, 41, "262944ca", "Rinoa,Irvine,Quistis", "264646286462", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(2766, 196, "50c4063b", "Rinoa,Irvine,Selphie", "646462864628", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(2767, 254, "e9fed158", "Rinoa,Squall,Quistis", "464628646284", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(2768, 88, "875822b1", "Zell,Squall,Quistis", "646286462848", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(2769, 254, "40fee396", "Irvine,Squall,Rinoa", "462864628484", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2770, 226, "71e2cb17", "Selphie,Squall,Quistis", "628646284844", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2771, 59, "823bab04", "Zell,Squall,Selphie", "286462848446", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2772, 155, "ea9b38ed", "Zell,Squall,Rinoa", "864628484466", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(2773, 189, "63bda322", "Irvine,Zell,Quistis", "646284844662", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2774, 191, "0dbf01b3", "Irvine,Zell,Selphie", "462848446626", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(2775, 74, "d04a7370", "Rinoa,Irvine,Quistis", "628484466264", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2776, 127, "177f76e9", "Rinoa,Zell,Selphie", "284844662646", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2777, 182, "f8b6cf6e", "Selphie,Rinoa,Quistis", "848446626464", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2778, 30, "f61e060f", "Selphie,Squall,Quistis", "484466264644", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2779, 59, "6f3b569c", "Selphie,Irvine,Quistis", "844662646446", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2780, 79, "094f98a5", "Zell,Squall,Quistis", "446626464466", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(2781, 4, "2c04747a", "Rinoa,Irvine,Selphie", "466264644668", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(2782, 190, "29bef42b", "Zell,Squall,Selphie", "662646446684", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2783, 245, "b8f54088", "Irvine,Zell,Selphie", "626464466842", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2784, 70, "eb461a21", "Irvine,Zell,Rinoa", "264644668424", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2785, 85, "1f555e46", "Zell,Squall,Rinoa", "646446684242", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2786, 54, "0a36a807", "Selphie,Zell,Quistis", "464466842424", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(2787, 225, "bce1dd34", "Irvine,Zell,Rinoa", "644668424242", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(2788, 201, "87c9375d", "Rinoa,Squall,Selphie", "446684242422", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(2789, 121, "8e7918d2", "Irvine,Zell,Selphie", "466842424222", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(2790, 139, "138bbda3", "Zell,Squall,Quistis", "668424242226", "{Irvine,Zell,Selphie=>77, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(2791, 89, "f55998a0", "Rinoa,Irvine,Selphie", "684242422262", "{Irvine,Zell,Selphie=>76, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2792, 102, "6f66ec59", "Irvine,Zell,Quistis", "842424222624", "{Irvine,Zell,Selphie=>75, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(2793, 171, "30abf01e", "Rinoa,Irvine,Selphie", "424242226246", "{Irvine,Zell,Selphie=>74, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2794, 146, "719290ff", "Selphie,Squall,Quistis", "242422262464", "{Irvine,Zell,Selphie=>73, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2795, 207, "e7cf9ecc", "Zell,Squall,Irvine", "424222624646", "{Irvine,Zell,Selphie=>72, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2796, 144, "9390f515", "Selphie,Zell,Quistis", "242226246468", "{Irvine,Zell,Selphie=>71, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2797, 162, "e2a2f02a", "Selphie,Irvine,Quistis", "422262464684", "{Irvine,Zell,Selphie=>70, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2798, 9, "8f093e1b", "Zell,Squall,Selphie", "222624646842", "{Irvine,Zell,Selphie=>69, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(2799, 189, "9bbddbb8", "Zell,Squall,Irvine", "226246468422", "{Irvine,Zell,Selphie=>68, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(2800, 24, "d118cd91", "Zell,Squall,Selphie", "262464684228", "{Irvine,Zell,Selphie=>67, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(2801, 87, "6557e4f6", "Irvine,Zell,Quistis", "624646842286", "{Irvine,Zell,Selphie=>66, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(2802, 115, "7a73a0f7", "Zell,Squall,Quistis", "246468422866", "{Irvine,Zell,Selphie=>65, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(2803, 80, "9450fb64", "Irvine,Squall,Rinoa", "464684228668", "{Irvine,Zell,Selphie=>64, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(2804, 107, "a66bb1cd", "Irvine,Squall,Quistis", "646842286686", "{Irvine,Zell,Selphie=>63, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(2805, 149, "3d955a82", "Rinoa,Irvine,Selphie", "468422866862", "{Irvine,Zell,Selphie=>62, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(2806, 183, "bcb75593", "Rinoa,Zell,Selphie", "684228668626", "{Irvine,Zell,Selphie=>61, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(2807, 212, "b8d469d0", "Rinoa,Irvine,Selphie", "842286686268", "{Irvine,Zell,Selphie=>60, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(2808, 142, "118e9dc9", "Irvine,Zell,Rinoa", "422866862684", "{Irvine,Zell,Selphie=>59, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(2809, 66, "00429cce", "Zell,Squall,Quistis", "228668626844", "{Irvine,Zell,Selphie=>58, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(2810, 119, "fd77b7ef", "Irvine,Zell,Rinoa", "286686268446", "{Irvine,Zell,Selphie=>57, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(2811, 222, "57de52fc", "Rinoa,Squall,Selphie", "866862684464", "{Irvine,Zell,Selphie=>56, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(2812, 218, "51da4d85", "Irvine,Squall,Rinoa", "668626844644", "{Irvine,Zell,Selphie=>55, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(2813, 111, "176fb7da", "Zell,Squall,Selphie", "686268446446", "{Irvine,Zell,Selphie=>54, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2814, 49, "9131e40b", "Irvine,Squall,Selphie", "862684464462", "{Irvine,Zell,Selphie=>53, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2815, 59, "313ba2e8", "Irvine,Squall,Quistis", "626844644626", "{Irvine,Zell,Selphie=>52, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2816, 119, "09773d01", "Rinoa,Zell,Quistis", "268446446266", "{Irvine,Zell,Selphie=>51, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(2817, 33, "cc2177a6", "Zell,Squall,Rinoa", "684464462662", "{Irvine,Zell,Selphie=>50, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2818, 24, "cd18b5e7", "Irvine,Zell,Quistis", "844644626628", "{Irvine,Zell,Selphie=>49, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(2819, 156, "329c0594", "Selphie,Squall,Quistis", "446446266288", "{Irvine,Zell,Selphie=>48, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(2820, 153, "fa99a83d", "Rinoa,Zell,Selphie", "464462662882", "{Irvine,Zell,Selphie=>47, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Quistis"),

            new PartyFormation(2821, 221, "20dd6832", "Irvine,Zell,Quistis", "644626628822", "{Irvine,Zell,Selphie=>46, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>2}", "Irvine,Zell,Quistis"),

            new PartyFormation(2822, 176, "bcb0c983", "Irvine,Zell,Rinoa", "446266288228", "{Irvine,Zell,Selphie=>45, Irvine,Zell,Quistis=>48, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2823, 253, "52fde700", "Selphie,Irvine,Quistis", "462662882282", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>47, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2824, 125, "5c7d8b39", "Zell,Squall,Irvine", "626628822822", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>46, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2825, 245, "c8f5d57e", "Rinoa,Squall,Quistis", "266288228222", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>45, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2826, 44, "952c7adf", "Selphie,Squall,Quistis", "662882282228", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>44, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2827, 218, "b8da732c", "Selphie,Zell,Quistis", "628822822284", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>43, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2828, 34, "8422a1f5", "Zell,Squall,Selphie", "288228222844", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>42, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2829, 149, "4895cb8a", "Zell,Squall,Selphie", "882282228442", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>41, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2830, 135, "0287e5fb", "Rinoa,Irvine,Selphie", "822822284426", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>40, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2831, 17, "17119618", "Zell,Squall,Rinoa", "228222844262", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2832, 200, "5cc86871", "Selphie,Irvine,Quistis", "282228442628", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2833, 141, "098d1656", "Irvine,Squall,Selphie", "822284426282", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2834, 100, "2a64e6d7", "Rinoa,Zell,Selphie", "222844262828", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2835, 149, "ec95fbc4", "Rinoa,Squall,Quistis", "228442628282", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2836, 42, "ec2a1aad", "Selphie,Irvine,Quistis", "284426282824", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2837, 220, "f0dc41e2", "Zell,Squall,Selphie", "844262828248", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2838, 167, "00a71973", "Rinoa,Irvine,Selphie", "442628282486", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2839, 217, "12d91030", "Selphie,Zell,Quistis", "426282824862", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2840, 122, "de7ab4a9", "Irvine,Zell,Rinoa", "262828248624", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2841, 0, "c1009a2e", "Selphie,Irvine,Quistis", "628282486248", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2842, 207, "49cfd9cf", "Selphie,Zell,Quistis", "282824862486", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2843, 246, "c6f6ff5c", "Rinoa,Zell,Quistis", "828248624864", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2844, 32, "d620f265", "Selphie,Zell,Quistis", "282486248648", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2845, 0, "55002b3a", "Irvine,Squall,Selphie", "824862486488", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2846, 26, "671a43eb", "Selphie,Zell,Quistis", "248624864884", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2847, 162, "19a2b548", "Irvine,Squall,Selphie", "486248648844", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2848, 51, "fb334fe1", "Zell,Squall,Rinoa", "862486488446", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2849, 53, "8035c106", "Rinoa,Irvine,Selphie", "624864884462", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2850, 87, "c85733c7", "Rinoa,Irvine,Selphie", "248648844626", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2851, 209, "71d1ddf4", "Selphie,Irvine,Quistis", "486488446262", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2852, 180, "06b4091d", "Irvine,Squall,Selphie", "864884462628", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2853, 220, "1edce792", "Zell,Squall,Rinoa", "648844626288", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2854, 137, "9f894563", "Irvine,Squall,Quistis", "488446262882", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2855, 40, "8e28e560", "Zell,Squall,Rinoa", "884462628828", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2856, 141, "c58d1a19", "Irvine,Squall,Selphie", "844626288282", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2857, 93, "a35deade", "Rinoa,Zell,Selphie", "446262882822", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2858, 64, "3240d4bf", "Selphie,Zell,Quistis", "462628828228", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2859, 38, "3126f78c", "Rinoa,Squall,Quistis", "626288282284", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2860, 76, "cf4c3ed5", "Rinoa,Squall,Selphie", "262882822848", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2861, 89, "2c59d6ea", "Rinoa,Irvine,Quistis", "628828228482", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2862, 183, "e4b7fddb", "Rinoa,Zell,Quistis", "288282284826", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2863, 18, "64120078", "Selphie,Irvine,Quistis", "882822848264", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2864, 158, "ec9ef351", "Zell,Squall,Quistis", "828228482644", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(2865, 118, "ef7677b6", "Zell,Squall,Quistis", "282284826444", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(2866, 174, "daae9cb7", "Zell,Squall,Quistis", "822848264444", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(2867, 162, "fca2ac24", "Irvine,Zell,Selphie", "228482644444", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(2868, 142, "698e738d", "Selphie,Zell,Quistis", "284826444444", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(2869, 234, "84ea5942", "Zell,Squall,Rinoa", "848264444444", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(2870, 6, "ca064d53", "Irvine,Zell,Quistis", "482644444444", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(2871, 112, "d1706690", "Zell,Squall,Rinoa", "826444444448", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(2872, 123, "4f7bbb89", "Irvine,Squall,Rinoa", "264444444486", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(2873, 200, "5fc8c78e", "Rinoa,Squall,Quistis", "644444444868", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(2874, 30, "5b1e6baf", "Selphie,Squall,Quistis", "444444448684", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(2875, 29, "c91d5bbc", "Rinoa,Irvine,Quistis", "444444486842", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(2876, 219, "42db8745", "Rinoa,Zell,Quistis", "444444868426", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(2877, 13, "7f0dce9a", "Rinoa,Irvine,Quistis", "444448684262", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(2878, 240, "32f013cb", "Irvine,Squall,Selphie", "444486842628", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(2879, 66, "b04277a8", "Rinoa,Zell,Selphie", "444868426284", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(2880, 178, "80b252c1", "Zell,Squall,Irvine", "448684262844", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(2881, 106, "236a3a66", "Selphie,Squall,Quistis", "486842628444", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(2882, 234, "82ea21a7", "Irvine,Zell,Quistis", "868426284444", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(2883, 27, "821b6654", "Selphie,Zell,Quistis", "684262844446", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2884, 208, "37d059fd", "Zell,Squall,Quistis", "842628444468", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2885, 207, "15cf96f2", "Rinoa,Squall,Quistis", "426284444686", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2886, 141, "ba8d3143", "Zell,Squall,Quistis", "262844446862", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2887, 242, "8ff293c0", "Rinoa,Zell,Quistis", "628444468624", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2888, 205, "39cd98f9", "Selphie,Irvine,Quistis", "284444686242", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2889, 188, "cabc303e", "Rinoa,Zell,Quistis", "844446862428", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(2890, 199, "b6c79e9f", "Irvine,Zell,Quistis", "444468624286", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Quistis"),

            new PartyFormation(2891, 77, "b34d2bec", "Rinoa,Irvine,Selphie", "444686242862", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>105, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2892, 197, "bfc5cbb5", "Selphie,Squall,Quistis", "446862428622", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>104, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2893, 71, "6e47124a", "Selphie,Irvine,Quistis", "468624286226", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>103, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2894, 17, "8b1185bb", "Irvine,Zell,Rinoa", "686242862262", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>102, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(2895, 215, "76d71ad8", "Zell,Squall,Irvine", "862428622626", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>101, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(2896, 212, "bed46e31", "Irvine,Squall,Selphie", "624286226268", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>100, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Selphie"),

            new PartyFormation(2897, 236, "a4ec0916", "Irvine,Zell,Rinoa", "242862262688", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>99, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Selphie"),

            new PartyFormation(2898, 72, "c048c297", "Rinoa,Irvine,Selphie", "428622626888", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>98, Selphie,Irvine,Quistis=>2}", "Irvine,Zell,Selphie"),

            new PartyFormation(2899, 15, "e20f0c84", "Irvine,Zell,Selphie", "286226268886", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>97, Selphie,Irvine,Quistis=>1}", "Irvine,Zell,Selphie"),

            new PartyFormation(2900, 80, "0850bc6d", "Selphie,Irvine,Quistis", "862262688868", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>96, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2901, 23, "8d17a0a2", "Irvine,Squall,Selphie", "622626888686", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>95, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2902, 76, "a54cf133", "Selphie,Irvine,Quistis", "226268886868", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>94, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2903, 178, "53b26cf0", "Selphie,Irvine,Quistis", "262688868684", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>93, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2904, 201, "31c9b269", "Selphie,Rinoa,Quistis", "626888686842", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>92, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(2905, 115, "4d7324ee", "Rinoa,Zell,Quistis", "268886868426", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>91, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(2906, 91, "0d5b6d8f", "Rinoa,Zell,Quistis", "688868684266", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>90, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(2907, 233, "96e9681c", "Rinoa,Zell,Quistis", "888686842662", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>89, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(2908, 194, "00c20c25", "Zell,Squall,Irvine", "886868426624", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>88, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(2909, 240, "3bf0a1fa", "Irvine,Zell,Rinoa", "868684266248", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>87, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(2910, 43, "982b53ab", "Irvine,Zell,Rinoa", "686842662486", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>86, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(2911, 50, "1f32ea08", "Selphie,Rinoa,Quistis", "868426624864", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>85, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(2912, 44, "d62c45a1", "Zell,Squall,Selphie", "684266248648", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>84, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(2913, 150, "6996e3c6", "Zell,Squall,Rinoa", "842662486484", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>83, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(2914, 201, "5fc97f87", "Irvine,Squall,Rinoa", "426624864842", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>82, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(2915, 16, "17109eb4", "Rinoa,Irvine,Selphie", "266248648428", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>81, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(2916, 166, "55a69add", "Irvine,Squall,Quistis", "662486484284", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>80, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(2917, 13, "1f0d7652", "Rinoa,Squall,Selphie", "624864842842", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>79, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(2918, 52, "a8348d23", "Selphie,Zell,Quistis", "248648428428", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>78, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(2919, 114, "ad72f220", "Zell,Squall,Quistis", "486484284284", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>77, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(2920, 119, "447707d9", "Rinoa,Squall,Quistis", "864842842846", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>76, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(2921, 232, "95e8a59e", "Irvine,Zell,Selphie", "648428428468", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>75, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(2922, 184, "ecb8d87f", "Zell,Squall,Quistis", "484284284688", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>74, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2923, 229, "cde5104c", "Selphie,Zell,Quistis", "842842846882", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>73, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2924, 71, "5c474895", "Selphie,Squall,Quistis", "428428468826", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>72, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2925, 181, "fab57daa", "Rinoa,Irvine,Selphie", "284284688262", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>71, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2926, 12, "670c7d9b", "Selphie,Irvine,Quistis", "842846882628", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>70, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2927, 120, "2f78e538", "Irvine,Zell,Selphie", "428468826288", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>69, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Selphie"),

            new PartyFormation(2928, 160, "8da0d911", "Rinoa,Zell,Selphie", "284688262888", "{Irvine,Zell,Selphie=>72, Irvine,Zell,Quistis=>68, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2929, 197, "83c5ca76", "Rinoa,Squall,Selphie", "846882628882", "{Irvine,Zell,Selphie=>71, Irvine,Zell,Quistis=>67, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2930, 43, "ec2b5877", "Selphie,Irvine,Quistis", "468826288826", "{Irvine,Zell,Selphie=>70, Irvine,Zell,Quistis=>66, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2931, 115, "66731ce4", "Irvine,Squall,Rinoa", "688262888266", "{Irvine,Zell,Selphie=>69, Irvine,Zell,Quistis=>65, Selphie,Irvine,Quistis=>29}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2932, 40, "ee28f54d", "Irvine,Squall,Selphie", "882628882668", "{Irvine,Zell,Selphie=>68, Irvine,Zell,Quistis=>64, Selphie,Irvine,Quistis=>28}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2933, 188, "28bc1802", "Rinoa,Squall,Selphie", "826288826688", "{Irvine,Zell,Selphie=>67, Irvine,Zell,Quistis=>63, Selphie,Irvine,Quistis=>27}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2934, 243, "baf30513", "Rinoa,Squall,Selphie", "262888266886", "{Irvine,Zell,Selphie=>66, Irvine,Zell,Quistis=>62, Selphie,Irvine,Quistis=>26}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2935, 183, "64b72350", "Selphie,Zell,Quistis", "628882668866", "{Irvine,Zell,Selphie=>65, Irvine,Zell,Quistis=>61, Selphie,Irvine,Quistis=>25}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2936, 156, "4e9c9949", "Irvine,Squall,Selphie", "288826688668", "{Irvine,Zell,Selphie=>64, Irvine,Zell,Quistis=>60, Selphie,Irvine,Quistis=>24}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2937, 215, "46d7b24e", "Selphie,Rinoa,Quistis", "888266886686", "{Irvine,Zell,Selphie=>63, Irvine,Zell,Quistis=>59, Selphie,Irvine,Quistis=>23}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2938, 126, "987edf6f", "Rinoa,Irvine,Quistis", "882668866864", "{Irvine,Zell,Selphie=>62, Irvine,Zell,Quistis=>58, Selphie,Irvine,Quistis=>22}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2939, 243, "94f3247c", "Zell,Squall,Irvine", "826688668646", "{Irvine,Zell,Selphie=>61, Irvine,Zell,Quistis=>57, Selphie,Irvine,Quistis=>21}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2940, 140, "348c8105", "Rinoa,Zell,Quistis", "266886686468", "{Irvine,Zell,Selphie=>60, Irvine,Zell,Quistis=>56, Selphie,Irvine,Quistis=>20}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2941, 0, "3e00a55a", "Selphie,Zell,Quistis", "668866864688", "{Irvine,Zell,Selphie=>59, Irvine,Zell,Quistis=>55, Selphie,Irvine,Quistis=>19}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2942, 68, "5644038b", "Irvine,Squall,Selphie", "688668646888", "{Irvine,Zell,Selphie=>58, Irvine,Zell,Quistis=>54, Selphie,Irvine,Quistis=>18}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2943, 140, "7c8c0c68", "Selphie,Squall,Quistis", "886686468888", "{Irvine,Zell,Selphie=>57, Irvine,Zell,Quistis=>53, Selphie,Irvine,Quistis=>17}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2944, 217, "b3d92881", "Selphie,Zell,Quistis", "866864688882", "{Irvine,Zell,Selphie=>56, Irvine,Zell,Quistis=>52, Selphie,Irvine,Quistis=>16}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2945, 147, "d293bd26", "Rinoa,Zell,Selphie", "668646888826", "{Irvine,Zell,Selphie=>55, Irvine,Zell,Quistis=>51, Selphie,Irvine,Quistis=>15}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2946, 237, "9ded4d67", "Rinoa,Irvine,Quistis", "686468888262", "{Irvine,Zell,Selphie=>54, Irvine,Zell,Quistis=>50, Selphie,Irvine,Quistis=>14}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2947, 73, "90498714", "Zell,Squall,Irvine", "864688882622", "{Irvine,Zell,Selphie=>53, Irvine,Zell,Quistis=>49, Selphie,Irvine,Quistis=>13}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2948, 238, "63eecbbd", "Rinoa,Zell,Selphie", "646888826224", "{Irvine,Zell,Selphie=>52, Irvine,Zell,Quistis=>48, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2949, 238, "dfee85b2", "Irvine,Zell,Rinoa", "468888262244", "{Irvine,Zell,Selphie=>51, Irvine,Zell,Quistis=>47, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2950, 247, "9ef75903", "Selphie,Rinoa,Quistis", "688882622446", "{Irvine,Zell,Selphie=>50, Irvine,Zell,Quistis=>46, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2951, 194, "a7c20080", "Selphie,Zell,Quistis", "888826224464", "{Irvine,Zell,Selphie=>49, Irvine,Zell,Quistis=>45, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2952, 193, "6cc166b9", "Irvine,Squall,Rinoa", "888262244642", "{Irvine,Zell,Selphie=>48, Irvine,Zell,Quistis=>44, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2953, 187, "a7bb4afe", "Rinoa,Squall,Quistis", "882622446426", "{Irvine,Zell,Selphie=>47, Irvine,Zell,Quistis=>43, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2954, 12, "fa0c825f", "Rinoa,Zell,Selphie", "826224464268", "{Irvine,Zell,Selphie=>46, Irvine,Zell,Quistis=>42, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2955, 134, "3b86a4ac", "Zell,Squall,Quistis", "262244642684", "{Irvine,Zell,Selphie=>45, Irvine,Zell,Quistis=>41, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2956, 136, "6788b575", "Irvine,Squall,Quistis", "622446426848", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>40, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2957, 253, "c9fd190a", "Zell,Squall,Selphie", "224464268482", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2958, 32, "0620e57b", "Rinoa,Zell,Selphie", "244642684828", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2959, 15, "5a0f5f98", "Zell,Squall,Irvine", "446426848286", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2960, 60, "8f3c33f1", "Selphie,Irvine,Quistis", "464268482868", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(2961, 219, "b1dbbbd6", "Rinoa,Irvine,Selphie", "642684828686", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>50}", "Irvine,Zell,Quistis"),

            new PartyFormation(2962, 78, "4b4e5e57", "Rinoa,Zell,Selphie", "426848286864", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>49}", "Irvine,Zell,Quistis"),

            new PartyFormation(2963, 102, "ff66dd44", "Rinoa,Squall,Selphie", "268482868644", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>48}", "Irvine,Zell,Quistis"),

            new PartyFormation(2964, 207, "7ccf1e2d", "Rinoa,Irvine,Quistis", "684828686446", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>47}", "Irvine,Zell,Quistis"),

            new PartyFormation(2965, 47, "032fbf62", "Rinoa,Irvine,Quistis", "848286864466", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>46}", "Irvine,Zell,Quistis"),

            new PartyFormation(2966, 112, "cf7088f3", "Rinoa,Zell,Selphie", "482868644668", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>45}", "Irvine,Zell,Quistis"),

            new PartyFormation(2967, 150, "3b9689b0", "Selphie,Rinoa,Quistis", "828686446684", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>44}", "Irvine,Zell,Quistis"),

            new PartyFormation(2968, 44, "6b2c7029", "Rinoa,Zell,Selphie", "286864466848", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>43}", "Irvine,Zell,Quistis"),

            new PartyFormation(2969, 206, "54ce6fae", "Zell,Squall,Quistis", "868644668484", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>42}", "Irvine,Zell,Quistis"),

            new PartyFormation(2970, 128, "9080c14f", "Zell,Squall,Rinoa", "686446684848", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>41}", "Irvine,Zell,Quistis"),

            new PartyFormation(2971, 210, "53d290dc", "Rinoa,Zell,Selphie", "864466848484", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>40}", "Irvine,Zell,Quistis"),

            new PartyFormation(2972, 242, "bef2e5e5", "Rinoa,Zell,Quistis", "644668484844", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>39}", "Irvine,Zell,Quistis"),

            new PartyFormation(2973, 149, "4395d8ba", "Irvine,Squall,Selphie", "446684848442", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Quistis"),

            new PartyFormation(2974, 178, "48b2236b", "Zell,Squall,Quistis", "466848484424", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Quistis"),

            new PartyFormation(2975, 101, "ca65dec8", "Selphie,Squall,Quistis", "668484844242", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Quistis"),

            new PartyFormation(2976, 240, "4df0fb61", "Selphie,Squall,Quistis", "684848442428", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Quistis"),

            new PartyFormation(2977, 56, "aa38c686", "Selphie,Squall,Quistis", "848484424288", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Quistis"),

            new PartyFormation(2978, 77, "584d8b47", "Rinoa,Zell,Quistis", "484844242882", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Quistis"),

            new PartyFormation(2979, 94, "f95e1f74", "Zell,Squall,Selphie", "848442428824", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Quistis"),

            new PartyFormation(2980, 96, "a260ec9d", "Irvine,Squall,Rinoa", "484424288248", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Quistis"),

            new PartyFormation(2981, 202, "89cac512", "Rinoa,Squall,Selphie", "844242882484", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(2982, 77, "714d94e3", "Rinoa,Squall,Selphie", "442428824842", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Quistis"),

            new PartyFormation(2983, 247, "abf7bee0", "Rinoa,Irvine,Quistis", "424288248426", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(2984, 228, "35e4b599", "Rinoa,Irvine,Selphie", "242882484268", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Quistis"),

            new PartyFormation(2985, 12, "ef0c205e", "Irvine,Squall,Selphie", "428824842688", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Quistis"),

            new PartyFormation(2986, 186, "60ba9c3f", "Rinoa,Squall,Selphie", "288248426884", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(2987, 201, "e2c9e90c", "Rinoa,Irvine,Selphie", "882484268842", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(2988, 66, "60421255", "Selphie,Rinoa,Quistis", "824842688424", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(2989, 117, "e075e46a", "Rinoa,Squall,Quistis", "248426884242", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(2990, 198, "11c6bd5b", "Rinoa,Squall,Quistis", "484268842424", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(2991, 178, "aeb289f8", "Rinoa,Zell,Selphie", "842688424244", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(2992, 222, "75de7ed1", "Rinoa,Squall,Quistis", "426884242444", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(2993, 5, "2105dd36", "Selphie,Rinoa,Quistis", "268842424442", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(2994, 169, "a6a9d437", "Irvine,Squall,Selphie", "688424244422", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(2995, 130, "ce824da4", "Rinoa,Irvine,Selphie", "884242444224", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(2996, 251, "51fb370d", "Irvine,Zell,Quistis", "842424442246", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(2997, 202, "53ca96c2", "Selphie,Squall,Quistis", "424244422464", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(2998, 61, "433d7cd3", "Irvine,Zell,Quistis", "242444224642", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(2999, 104, "7b68a010", "Rinoa,Irvine,Selphie", "424442246428", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(3000, 177, "48b13709", "Irvine,Zell,Selphie", "244422464282", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(3001, 47, "cc2f5d0e", "Selphie,Squall,Quistis", "444224642826", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(3002, 89, "e559132f", "Irvine,Zell,Selphie", "442246428262", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(3003, 31, "901fad3c", "Irvine,Zell,Rinoa", "422464282626", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(3004, 173, "3cad3ac5", "Zell,Squall,Irvine", "224642826262", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(3005, 8, "17083c1a", "Irvine,Zell,Selphie", "246428262628", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(3006, 237, "66edb34b", "Selphie,Rinoa,Quistis", "464282626282", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(3007, 216, "f6d86128", "Rinoa,Squall,Selphie", "642826262828", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(3008, 171, "54abbe41", "Irvine,Zell,Quistis", "428262628286", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Quistis"),

            new PartyFormation(3009, 93, "085dffe6", "Selphie,Squall,Quistis", "282626282862", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3010, 226, "85e23927", "Zell,Squall,Rinoa", "826262828624", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3011, 230, "09e667d4", "Selphie,Irvine,Quistis", "262628286244", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3012, 180, "8cb4fd7d", "Selphie,Irvine,Quistis", "626282862448", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3013, 250, "d9fa3472", "Irvine,Zell,Selphie", "262828624484", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3014, 175, "8daf40c3", "Selphie,Zell,Quistis", "628286244846", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(3015, 44, "532c2d40", "Rinoa,Irvine,Selphie", "282862448468", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(3016, 24, "1f18f479", "Irvine,Zell,Quistis", "828624484688", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(3017, 179, "a6b325be", "Irvine,Squall,Selphie", "286244846886", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>56, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(3018, 187, "febb261f", "Selphie,Squall,Quistis", "862448468866", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>55, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(3019, 70, "d646dd6c", "Irvine,Zell,Selphie", "624484688664", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>54, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(3020, 43, "812b5f35", "Rinoa,Squall,Quistis", "244846886646", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>53, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3021, 119, "4e77dfca", "Rinoa,Squall,Selphie", "448468866466", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>52, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3022, 118, "4f76053b", "Selphie,Rinoa,Quistis", "484688664664", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>51, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3023, 122, "d17a6458", "Rinoa,Irvine,Quistis", "846886646644", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>50, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3024, 191, "6fbfb9b1", "Rinoa,Zell,Selphie", "468866466446", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>49, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3025, 28, "8f1c2e96", "Rinoa,Irvine,Quistis", "688664664468", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>48, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3026, 53, "a335ba17", "Selphie,Irvine,Quistis", "886646644682", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>47, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3027, 93, "a15d6e04", "Irvine,Zell,Rinoa", "866466446822", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>46, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3028, 101, "47653fed", "Irvine,Zell,Rinoa", "664664468222", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>45, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3029, 228, "dde49e22", "Rinoa,Zell,Selphie", "646644682228", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>44, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3030, 209, "12d1e0b3", "Rinoa,Irvine,Quistis", "466446822282", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>43, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3031, 69, "33456670", "Rinoa,Zell,Selphie", "664468222822", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>42, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3032, 98, "a462ede9", "Rinoa,Squall,Quistis", "644682228224", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>41, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3033, 210, "4dd27a6e", "Selphie,Irvine,Quistis", "446822282244", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>40, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3034, 255, "e2ffd50f", "Irvine,Zell,Selphie", "468222822446", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3035, 114, "3272799c", "Rinoa,Squall,Selphie", "682228224464", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(3036, 115, "06737fa5", "Irvine,Zell,Selphie", "822282244646", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(3037, 175, "8eafcf7a", "Irvine,Squall,Selphie", "222822446466", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3038, 110, "c46eb32b", "Rinoa,Squall,Quistis", "228224464664", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3039, 251, "dbfb9388", "Selphie,Squall,Quistis", "282244646646", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3040, 65, "f4417121", "Rinoa,Irvine,Selphie", "822446466462", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3041, 219, "d0db6946", "Rinoa,Irvine,Selphie", "224464664626", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3042, 163, "f9a35707", "Zell,Squall,Selphie", "244646646266", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3043, 122, "257a6034", "Rinoa,Squall,Quistis", "446466462664", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3044, 162, "daa2fe5d", "Rinoa,Zell,Quistis", "464664626644", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3045, 212, "19d4d3d2", "Rinoa,Zell,Selphie", "646646266448", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3046, 148, "fe945ca3", "Rinoa,Irvine,Selphie", "466462664488", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3047, 119, "a2774ba0", "Selphie,Irvine,Quistis", "664626644886", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3048, 150, "a3962359", "Zell,Squall,Quistis", "646266448864", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(3049, 136, "55885b1e", "Selphie,Squall,Quistis", "462664488648", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(3050, 6, "0e061fff", "Zell,Squall,Quistis", "626644886484", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3051, 149, "549581cc", "Irvine,Squall,Rinoa", "266448864842", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(3052, 252, "c0fc9c15", "Irvine,Zell,Selphie", "664488648428", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(3053, 91, "305b0b2a", "Irvine,Zell,Rinoa", "644886484286", "{Irvine,Zell,Selphie=>54, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3054, 166, "a0a6bd1b", "Zell,Squall,Irvine", "448864842864", "{Irvine,Zell,Selphie=>53, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3055, 126, "527eeeb8", "Selphie,Rinoa,Quistis", "488648428644", "{Irvine,Zell,Selphie=>52, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3056, 23, "2717e491", "Zell,Squall,Selphie", "886484286446", "{Irvine,Zell,Selphie=>51, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3057, 246, "85f6aff6", "Rinoa,Zell,Selphie", "864842864464", "{Irvine,Zell,Selphie=>50, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3058, 234, "c1ea0ff7", "Rinoa,Irvine,Quistis", "648428644644", "{Irvine,Zell,Selphie=>49, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3059, 144, "f1903e64", "Irvine,Squall,Rinoa", "484286446448", "{Irvine,Zell,Selphie=>48, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3060, 197, "72c538cd", "Irvine,Zell,Rinoa", "842864464482", "{Irvine,Zell,Selphie=>47, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3061, 213, "f0d5d582", "Zell,Squall,Selphie", "428644644822", "{Irvine,Zell,Selphie=>46, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3062, 165, "d6a5b493", "Zell,Squall,Quistis", "286446448222", "{Irvine,Zell,Selphie=>45, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3063, 68, "de44dcd0", "Selphie,Irvine,Quistis", "864464482228", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3064, 121, "377994c9", "Selphie,Zell,Quistis", "644644822282", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(3065, 143, "c68fc7ce", "Rinoa,Zell,Selphie", "446448222826", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(3066, 109, "316d06ef", "Irvine,Squall,Selphie", "464482228262", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(3067, 98, "4f62f5fc", "Zell,Squall,Selphie", "644822282624", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(3068, 253, "30fdb485", "Rinoa,Squall,Selphie", "448222826242", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(3069, 228, "8ce492da", "Zell,Squall,Irvine", "482228262428", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(3070, 173, "90ad230b", "Irvine,Squall,Rinoa", "822282624282", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(3071, 231, "3fe775e8", "Zell,Squall,Selphie", "222826242826", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(3072, 234, "d4ea1401", "Rinoa,Squall,Quistis", "228262428264", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(3073, 137, "b38902a6", "Irvine,Zell,Quistis", "282624282642", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(3074, 136, "6288e4e7", "Zell,Squall,Rinoa", "826242826428", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(3075, 178, "5bb20894", "Irvine,Squall,Quistis", "262428264284", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(3076, 226, "7fe2ef3d", "Rinoa,Zell,Selphie", "624282642844", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(3077, 178, "1eb2a332", "Rinoa,Squall,Selphie", "242826428444", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Quistis"),

            new PartyFormation(3078, 116, "6a74e883", "Irvine,Squall,Selphie", "428264284448", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>2}", "Irvine,Zell,Quistis"),

            new PartyFormation(3079, 241, "0af11a00", "Irvine,Zell,Quistis", "282642844482", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>1}", "Irvine,Zell,Quistis"),

            new PartyFormation(3080, 148, "3a944239", "Selphie,Irvine,Quistis", "826428444828", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3081, 99, "ce63c07e", "Zell,Squall,Irvine", "264284448286", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(3082, 147, "249389df", "Rinoa,Zell,Selphie", "642844482866", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(3083, 77, "c84dd62c", "Rinoa,Zell,Quistis", "428444828662", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(3084, 109, "d26dc8f5", "Selphie,Squall,Quistis", "284448286622", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(3085, 119, "ae77668a", "Selphie,Squall,Quistis", "844482866226", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(3086, 208, "02d0e4fb", "Irvine,Squall,Rinoa", "444828662268", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(3087, 216, "add82918", "Irvine,Squall,Quistis", "448286622688", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(3088, 30, "c21eff71", "Irvine,Squall,Selphie", "482866226884", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(3089, 109, "5b6d6156", "Selphie,Squall,Quistis", "828662268842", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(3090, 190, "5fbed5d7", "Irvine,Squall,Quistis", "286622688424", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(3091, 178, "e4b2bec4", "Rinoa,Irvine,Selphie", "866226884244", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(3092, 211, "25d321ad", "Irvine,Zell,Quistis", "662268842446", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(3093, 246, "67f63ce2", "Rinoa,Squall,Quistis", "622688424464", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>48, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3094, 48, "c330f873", "Irvine,Squall,Rinoa", "226884244648", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>47, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3095, 127, "637f0330", "Rinoa,Irvine,Selphie", "268842446486", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>46, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3096, 45, "b72d2ba9", "Zell,Squall,Irvine", "688424464862", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>45, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3097, 63, "6f3f452e", "Rinoa,Irvine,Selphie", "884244648626", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>44, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3098, 152, "d498a8cf", "Selphie,Irvine,Quistis", "842446486268", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>43, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3099, 137, "2789225c", "Irvine,Zell,Rinoa", "424464862682", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>42, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3100, 3, "8d03d965", "Irvine,Squall,Quistis", "244648626826", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>41, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3101, 254, "fffe863a", "Rinoa,Squall,Selphie", "446486268264", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>40, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3102, 33, "172102eb", "Zell,Squall,Rinoa", "464862682642", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3103, 180, "d4b40848", "Rinoa,Zell,Quistis", "648626826428", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3104, 221, "1adda6e1", "Selphie,Irvine,Quistis", "486268264282", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3105, 62, "2c3ecc06", "Rinoa,Irvine,Quistis", "862682642824", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Selphie"),

            new PartyFormation(3106, 138, "4b8ae2c7", "Zell,Squall,Selphie", "626826428244", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Selphie"),

            new PartyFormation(3107, 37, "682560f4", "Irvine,Zell,Selphie", "268264282442", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Selphie"),

            new PartyFormation(3108, 44, "ac2cd01d", "Rinoa,Zell,Selphie", "682642824428", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Selphie"),

            new PartyFormation(3109, 235, "49eba292", "Zell,Squall,Selphie", "826428244286", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Selphie"),

            new PartyFormation(3110, 200, "13c8e463", "Rinoa,Irvine,Selphie", "264282442868", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Selphie"),

            new PartyFormation(3111, 177, "69b19860", "Zell,Squall,Selphie", "642824428682", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Selphie"),

            new PartyFormation(3112, 75, "574b5119", "Irvine,Squall,Selphie", "428244286826", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Selphie"),

            new PartyFormation(3113, 29, "301d55de", "Zell,Squall,Irvine", "282442868262", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Selphie"),

            new PartyFormation(3114, 91, "345b63bf", "Irvine,Squall,Selphie", "824428682626", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Selphie"),

            new PartyFormation(3115, 7, "c807da8c", "Rinoa,Irvine,Selphie", "244286826266", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(3116, 54, "2436e5d5", "Zell,Squall,Irvine", "442868262664", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(3117, 36, "fd24f1ea", "Rinoa,Irvine,Selphie", "428682626648", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(3118, 108, "8f6c7cdb", "Rinoa,Squall,Selphie", "286826266488", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(3119, 158, "4b9e1378", "Irvine,Squall,Selphie", "868262664884", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(3120, 13, "e30d0a51", "Irvine,Zell,Rinoa", "682626648842", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(3121, 88, "315842b6", "Irvine,Squall,Quistis", "826266488428", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(3122, 172, "b5ac0bb7", "Irvine,Zell,Rinoa", "262664884288", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(3123, 92, "4c5cef24", "Zell,Squall,Selphie", "626648842888", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(3124, 70, "ee46fa8d", "Selphie,Zell,Quistis", "266488428884", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(3125, 157, "aa9dd442", "Zell,Squall,Selphie", "664884288842", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(3126, 235, "a8ebac53", "Rinoa,Zell,Quistis", "648842888426", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3127, 11, "160bd990", "Selphie,Zell,Quistis", "488428884266", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(3128, 181, "d4b5b289", "Rinoa,Zell,Selphie", "884288842662", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(3129, 184, "ccb8f28e", "Rinoa,Squall,Selphie", "842888426628", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(3130, 122, "2c7abaaf", "Selphie,Zell,Quistis", "428884266284", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(3131, 124, "277cfebc", "Irvine,Zell,Rinoa", "288842662848", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(3132, 61, "a73dee45", "Selphie,Squall,Quistis", "888426628482", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(3133, 85, "e255a99a", "Rinoa,Irvine,Quistis", "884266284822", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(3134, 66, "bf4252cb", "Rinoa,Zell,Selphie", "842662848224", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(3135, 121, "38794aa8", "Irvine,Zell,Selphie", "426628482242", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Selphie"),

            new PartyFormation(3136, 84, "665429c1", "Rinoa,Irvine,Selphie", "266284822428", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3137, 212, "82d4c566", "Selphie,Zell,Quistis", "662848224288", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3138, 161, "1ba150a7", "Selphie,Squall,Quistis", "628482242882", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3139, 108, "b26c6954", "Selphie,Irvine,Quistis", "284822428828", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3140, 56, "cb38a0fd", "Rinoa,Zell,Selphie", "848224288288", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(3141, 215, "88d7d1f2", "Irvine,Zell,Quistis", "482242882886", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(3142, 8, "d9085043", "Irvine,Squall,Rinoa", "822428828868", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>94, Selphie,Irvine,Quistis=>14}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3143, 208, "07d0c6c0", "Rinoa,Irvine,Quistis", "224288288688", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>93, Selphie,Irvine,Quistis=>13}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3144, 243, "68f34ff9", "Selphie,Zell,Quistis", "242882886886", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>92, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3145, 141, "e58d1b3e", "Selphie,Squall,Quistis", "428828868862", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>91, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3146, 85, "8b55ad9f", "Zell,Squall,Selphie", "288288688622", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>90, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3147, 91, "165b8eec", "Rinoa,Squall,Quistis", "882886886226", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>89, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3148, 15, "e10ff2b5", "Irvine,Squall,Selphie", "828868862266", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>88, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3149, 187, "5cbbad4a", "Zell,Squall,Quistis", "288688622666", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>87, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3150, 241, "7bf184bb", "Zell,Squall,Quistis", "886886226662", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>86, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3151, 232, "7fe8add8", "Zell,Squall,Selphie", "868862266628", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>85, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3152, 26, "a81a0531", "Rinoa,Squall,Quistis", "688622666284", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>84, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3153, 143, "f58f5416", "Irvine,Squall,Selphie", "886226662846", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>83, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3154, 169, "d8a9b197", "Rinoa,Zell,Selphie", "862266628462", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>82, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3155, 38, "a626cf84", "Zell,Squall,Irvine", "622666284624", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>81, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3156, 216, "95d8c36d", "Selphie,Irvine,Quistis", "226662846248", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>80, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3157, 36, "ac249ba2", "Rinoa,Irvine,Selphie", "266628462488", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>79, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3158, 77, "f44dd033", "Selphie,Squall,Quistis", "666284624882", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>78, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3159, 3, "b5035ff0", "Zell,Squall,Quistis", "662846248826", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>77, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3160, 75, "3d4b2969", "Zell,Squall,Quistis", "628462488266", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>76, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3161, 212, "afd4cfee", "Irvine,Zell,Rinoa", "284624882668", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>75, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3162, 11, "f50b3c8f", "Selphie,Irvine,Quistis", "846248826686", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>74, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3163, 214, "e7d68b1c", "Selphie,Irvine,Quistis", "462488266864", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>73, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3164, 99, "c863f325", "Rinoa,Zell,Quistis", "624882668646", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>72, Selphie,Irvine,Quistis=>51}", "Irvine,Zell,Selphie"),

            new PartyFormation(3165, 65, "3a41fcfa", "Zell,Squall,Quistis", "248826686462", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>71, Selphie,Irvine,Quistis=>50}", "Irvine,Zell,Selphie"),

            new PartyFormation(3166, 137, "0c8912ab", "Rinoa,Irvine,Selphie", "488266864622", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>70, Selphie,Irvine,Quistis=>49}", "Irvine,Zell,Selphie"),

            new PartyFormation(3167, 79, "f54f3d08", "Zell,Squall,Irvine", "882668646226", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>69, Selphie,Irvine,Quistis=>48}", "Irvine,Zell,Selphie"),

            new PartyFormation(3168, 133, "d3859ca1", "Irvine,Zell,Selphie", "826686462262", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>68, Selphie,Irvine,Quistis=>47}", "Irvine,Zell,Selphie"),

            new PartyFormation(3169, 34, "cb22eec6", "Rinoa,Squall,Quistis", "266864622624", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>67, Selphie,Irvine,Quistis=>46}", "Irvine,Zell,Selphie"),

            new PartyFormation(3170, 196, "15c42e87", "Rinoa,Squall,Quistis", "668646226248", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>66, Selphie,Irvine,Quistis=>45}", "Irvine,Zell,Selphie"),

            new PartyFormation(3171, 31, "4e1f21b4", "Irvine,Squall,Selphie", "686462262486", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>65, Selphie,Irvine,Quistis=>44}", "Irvine,Zell,Selphie"),

            new PartyFormation(3172, 190, "84be61dd", "Rinoa,Zell,Quistis", "864622624864", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>64, Selphie,Irvine,Quistis=>43}", "Irvine,Zell,Selphie"),

            new PartyFormation(3173, 207, "54cf3152", "Selphie,Squall,Quistis", "646226248646", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>63, Selphie,Irvine,Quistis=>42}", "Irvine,Zell,Selphie"),

            new PartyFormation(3174, 171, "34ab2c23", "Irvine,Squall,Rinoa", "462262486466", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>62, Selphie,Irvine,Quistis=>41}", "Irvine,Zell,Selphie"),

            new PartyFormation(3175, 102, "9a66a520", "Zell,Squall,Quistis", "622624864664", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>61, Selphie,Irvine,Quistis=>40}", "Irvine,Zell,Selphie"),

            new PartyFormation(3176, 196, "dac43ed9", "Rinoa,Irvine,Quistis", "226248646648", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>60, Selphie,Irvine,Quistis=>39}", "Irvine,Zell,Selphie"),

            new PartyFormation(3177, 139, "a58b109e", "Irvine,Zell,Selphie", "262486466486", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>59, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Selphie"),

            new PartyFormation(3178, 122, "d37a677f", "Selphie,Squall,Quistis", "624864664864", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>58, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Selphie"),

            new PartyFormation(3179, 224, "a1e0f34c", "Irvine,Squall,Quistis", "248646648648", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>57, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Selphie"),

            new PartyFormation(3180, 176, "efb0ef95", "Zell,Squall,Rinoa", "486466486488", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>56, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Selphie"),

            new PartyFormation(3181, 147, "199398aa", "Zell,Squall,Selphie", "864664864886", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>55, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Selphie"),

            new PartyFormation(3182, 215, "19d7fc9b", "Irvine,Squall,Quistis", "646648648866", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>54, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Selphie"),

            new PartyFormation(3183, 207, "8acff838", "Irvine,Squall,Rinoa", "466486488666", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>53, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Selphie"),

            new PartyFormation(3184, 125, "ab7df011", "Rinoa,Squall,Selphie", "664864886662", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>52, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Selphie"),

            new PartyFormation(3185, 234, "61ea9576", "Irvine,Zell,Rinoa", "648648866624", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>51, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Selphie"),

            new PartyFormation(3186, 175, "b9afc777", "Selphie,Rinoa,Quistis", "486488666246", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>50, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Selphie"),

            new PartyFormation(3187, 168, "1ba85fe4", "Irvine,Squall,Selphie", "864886662468", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>49, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Selphie"),

            new PartyFormation(3188, 64, "22407c4d", "Zell,Squall,Rinoa", "648866624688", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>48, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Selphie"),

            new PartyFormation(3189, 226, "ebe29302", "Zell,Squall,Quistis", "488666246884", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>47, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Selphie"),

            new PartyFormation(3190, 207, "adcf6413", "Zell,Squall,Rinoa", "886662468846", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>46, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Selphie"),

            new PartyFormation(3191, 125, "6b7d9650", "Irvine,Squall,Rinoa", "866624688462", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>45, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(3192, 37, "9a259049", "Selphie,Rinoa,Quistis", "666246884622", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>44, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(3193, 106, "356add4e", "Irvine,Squall,Quistis", "662468846224", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>43, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(3194, 66, "46422e6f", "Rinoa,Zell,Quistis", "624688462244", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>42, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(3195, 45, "2d2dc77c", "Irvine,Zell,Selphie", "246884622442", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>41, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(3196, 45, "f52de805", "Zell,Squall,Selphie", "468846224422", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>40, Selphie,Irvine,Quistis=>19}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3197, 27, "1a1b805a", "Rinoa,Irvine,Quistis", "688462244226", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>18}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3198, 109, "9e6d428b", "Zell,Squall,Quistis", "884622442262", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>17}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3199, 77, "814ddf68", "Rinoa,Squall,Selphie", "846224422622", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>16}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3200, 169, "faa9ff81", "Rinoa,Zell,Selphie", "462244226222", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>15}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3201, 1, "e5014826", "Rinoa,Irvine,Selphie", "622442262222", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>14}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3202, 235, "58eb7c67", "Zell,Squall,Quistis", "224422622226", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>13}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3203, 213, "fad58a14", "Rinoa,Squall,Quistis", "244226222262", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3204, 118, "bc7612bd", "Rinoa,Zell,Selphie", "442262222624", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3205, 41, "b329c0b2", "Zell,Squall,Quistis", "422622226242", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3206, 41, "3d297803", "Rinoa,Squall,Quistis", "226222262422", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3207, 139, "428b3380", "Rinoa,Squall,Selphie", "262222624226", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3208, 246, "13f61db9", "Zell,Squall,Rinoa", "622226242264", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3209, 239, "72ef35fe", "Irvine,Squall,Quistis", "222262422646", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3210, 193, "12c1915f", "Irvine,Zell,Rinoa", "222624226462", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3211, 48, "853007ac", "Rinoa,Squall,Selphie", "226242264628", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3212, 209, "f2d1dc75", "Irvine,Zell,Rinoa", "262422646282", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3213, 4, "8c04b40a", "Irvine,Squall,Rinoa", "624226462828", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3214, 151, "d697e47b", "Irvine,Zell,Rinoa", "242264628286", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3215, 107, "986bf298", "Selphie,Irvine,Quistis", "422646282866", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3216, 112, "0370caf1", "Selphie,Irvine,Quistis", "226462828668", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3217, 66, "fc4206d6", "Zell,Squall,Selphie", "264628286684", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(3218, 182, "25b64d57", "Rinoa,Zell,Selphie", "646282866844", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(3219, 121, "8279a044", "Selphie,Zell,Quistis", "462828668442", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(3220, 54, "d536252d", "Zell,Squall,Quistis", "628286684424", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(3221, 47, "752fba62", "Rinoa,Zell,Selphie", "282866844246", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(3222, 232, "79e867f3", "Rinoa,Squall,Selphie", "828668442468", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(3223, 146, "d0927cb0", "Rinoa,Squall,Quistis", "286684424684", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(3224, 124, "907ce729", "Irvine,Zell,Selphie", "866844246848", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(3225, 83, "c6531aae", "Rinoa,Irvine,Quistis", "668442468486", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(3226, 23, "9417904f", "Rinoa,Squall,Selphie", "684424684866", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(3227, 26, "e81ab3dc", "Irvine,Squall,Selphie", "844246848664", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(3228, 83, "ee53cce5", "Irvine,Zell,Selphie", "442468486646", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3229, 58, "a03a33ba", "Irvine,Zell,Rinoa", "424684866464", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(3230, 102, "3066e26b", "Rinoa,Squall,Quistis", "246848664644", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(3231, 141, "3e8d31c8", "Zell,Squall,Rinoa", "468486646442", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(3232, 249, "eff95261", "Irvine,Zell,Rinoa", "684866464422", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(3233, 71, "7c47d186", "Zell,Squall,Selphie", "848664644226", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(3234, 15, "e00f3a47", "Rinoa,Irvine,Quistis", "486646442266", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(3235, 39, "2427a274", "Irvine,Squall,Selphie", "866464422666", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(3236, 23, "9217b39d", "Irvine,Zell,Quistis", "664644226666", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(3237, 63, "353f8012", "Rinoa,Squall,Quistis", "646442266666", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3238, 251, "a4fb33e3", "Rinoa,Zell,Selphie", "464422666666", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3239, 86, "8d5671e0", "Rinoa,Irvine,Selphie", "644226666664", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3240, 192, "77c0ec99", "Rinoa,Zell,Quistis", "442266666648", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3241, 145, "9c918b5e", "Selphie,Irvine,Quistis", "422666666482", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3242, 35, "ab232b3f", "Irvine,Zell,Rinoa", "226666664826", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(3243, 224, "06e0cc0c", "Selphie,Squall,Quistis", "266666648268", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(3244, 42, "492ab955", "Selphie,Squall,Quistis", "666666482684", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(3245, 102, "1866ff6a", "Zell,Squall,Rinoa", "666664826844", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(3246, 169, "3ba93c5b", "Irvine,Zell,Selphie", "666648268442", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3247, 212, "c0d49cf8", "Irvine,Zell,Quistis", "666482684428", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(3248, 42, "422a95d1", "Selphie,Squall,Quistis", "664826844284", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3249, 109, "166da836", "Zell,Squall,Quistis", "648268442842", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3250, 181, "c5b54337", "Selphie,Rinoa,Quistis", "482684428422", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3251, 50, "5c3290a4", "Rinoa,Squall,Quistis", "826844284224", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3252, 113, "2c71be0d", "Zell,Squall,Quistis", "268442842242", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3253, 100, "df6411c2", "Selphie,Rinoa,Quistis", "684428422428", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3254, 16, "9910dbd3", "Selphie,Rinoa,Quistis", "844284224288", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3255, 90, "e75a1310", "Selphie,Rinoa,Quistis", "442842242884", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3256, 137, "c1892e09", "Selphie,Squall,Quistis", "428422428842", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3257, 101, "1765880e", "Irvine,Squall,Rinoa", "284224288422", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3258, 131, "ae83622f", "Zell,Squall,Irvine", "842242884226", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3259, 53, "3535503c", "Selphie,Irvine,Quistis", "422428842262", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3260, 141, "308da1c5", "Zell,Squall,Rinoa", "224288422622", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>53}", "Irvine,Zell,Quistis"),

            new PartyFormation(3261, 246, "f6f6171a", "Selphie,Zell,Quistis", "242884226224", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>52}", "Irvine,Zell,Quistis"),

            new PartyFormation(3262, 237, "99edf24b", "Rinoa,Squall,Selphie", "428842262242", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>51}", "Irvine,Zell,Quistis"),

            new PartyFormation(3263, 37, "7b253428", "Rinoa,Squall,Selphie", "288422622422", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>50}", "Irvine,Zell,Quistis"),

            new PartyFormation(3264, 171, "43ab9541", "Irvine,Zell,Quistis", "884226224226", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>49}", "Irvine,Zell,Quistis"),

            new PartyFormation(3265, 206, "08ce8ae6", "Rinoa,Squall,Quistis", "842262242264", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>48}", "Irvine,Zell,Quistis"),

            new PartyFormation(3266, 39, "82276827", "Rinoa,Irvine,Selphie", "422622422646", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>47}", "Irvine,Zell,Quistis"),

            new PartyFormation(3267, 173, "e1ad6ad4", "Irvine,Zell,Quistis", "226224226462", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>46}", "Irvine,Zell,Quistis"),

            new PartyFormation(3268, 91, "615b447d", "Selphie,Squall,Quistis", "262242264626", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>45}", "Irvine,Zell,Selphie"),

            new PartyFormation(3269, 104, "f8686f72", "Rinoa,Zell,Quistis", "622422646268", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>44}", "Irvine,Zell,Selphie"),

            new PartyFormation(3270, 152, "ba985fc3", "Irvine,Zell,Selphie", "224226462688", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>43}", "Irvine,Zell,Selphie"),

            new PartyFormation(3271, 224, "73e06040", "Rinoa,Irvine,Quistis", "242264626888", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>42}", "Irvine,Zell,Quistis"),

            new PartyFormation(3272, 92, "655cab79", "Rinoa,Squall,Quistis", "422646268888", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>41}", "Irvine,Zell,Quistis"),

            new PartyFormation(3273, 74, "bd4a10be", "Rinoa,Squall,Selphie", "226462688884", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>40}", "Irvine,Zell,Quistis"),

            new PartyFormation(3274, 151, "5a97351f", "Irvine,Zell,Quistis", "264626888846", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>39}", "Irvine,Zell,Quistis"),

            new PartyFormation(3275, 139, "998b406c", "Rinoa,Squall,Quistis", "646268888466", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Quistis"),

            new PartyFormation(3276, 115, "0d738635", "Selphie,Rinoa,Quistis", "462688884666", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Quistis"),

            new PartyFormation(3277, 18, "2f127aca", "Irvine,Squall,Quistis", "626888846664", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Quistis"),

            new PartyFormation(3278, 132, "ee84043b", "Zell,Squall,Selphie", "268888466648", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Quistis"),

            new PartyFormation(3279, 33, "0821f758", "Irvine,Zell,Quistis", "688884666482", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Quistis"),

            new PartyFormation(3280, 227, "75e350b1", "Irvine,Zell,Rinoa", "888846664826", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Quistis"),

            new PartyFormation(3281, 69, "ce457996", "Rinoa,Zell,Quistis", "888466648262", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Quistis"),

            new PartyFormation(3282, 164, "1ea4a917", "Zell,Squall,Rinoa", "884666482628", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Quistis"),

            new PartyFormation(3283, 107, "d66b3104", "Selphie,Rinoa,Quistis", "846664826286", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(3284, 171, "e1ab46ed", "Zell,Squall,Rinoa", "466648262866", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Quistis"),

            new PartyFormation(3285, 215, "4dd79922", "Rinoa,Zell,Selphie", "666482628666", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(3286, 192, "e7c0bfb3", "Irvine,Zell,Quistis", "664826286668", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Quistis"),

            new PartyFormation(3287, 236, "1eec5970", "Irvine,Squall,Quistis", "648262866688", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Selphie"),

            new PartyFormation(3288, 130, "ca8264e9", "Zell,Squall,Rinoa", "482628666884", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Selphie"),

            new PartyFormation(3289, 122, "297a256e", "Irvine,Zell,Selphie", "826286668844", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(3290, 125, "c17da40f", "Rinoa,Irvine,Quistis", "262866688442", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(3291, 21, "5d159c9c", "Rinoa,Squall,Selphie", "628666884422", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(3292, 147, "f49366a5", "Irvine,Zell,Selphie", "286668844226", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(3293, 167, "54a72a7a", "Zell,Squall,Quistis", "866688442266", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(3294, 122, "ce7a722b", "Rinoa,Zell,Selphie", "666884422664", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(3295, 45, "712de688", "Irvine,Zell,Quistis", "668844226642", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(3296, 248, "01f8c821", "Selphie,Squall,Quistis", "688442266428", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>46, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(3297, 109, "ce6d7446", "Selphie,Zell,Quistis", "884422664282", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>45, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(3298, 44, "f22c0607", "Zell,Squall,Quistis", "844226642828", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>44, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(3299, 254, "f6fee334", "Irvine,Squall,Quistis", "442266428284", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>43, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(3300, 248, "c1f8c55d", "Irvine,Squall,Rinoa", "422664282848", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>42, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3301, 252, "a5fc8ed2", "Rinoa,Zell,Quistis", "226642828488", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>41, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(3302, 120, "6878fba3", "Selphie,Rinoa,Quistis", "266428284888", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>40, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(3303, 64, "5b40fea0", "Rinoa,Irvine,Selphie", "664282848888", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(3304, 1, "38015a59", "Irvine,Zell,Selphie", "642828488882", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(3305, 240, "bbf0c61e", "Rinoa,Irvine,Selphie", "428284888828", "{Irvine,Zell,Selphie=>72, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3306, 21, "3b15aeff", "Zell,Squall,Selphie", "282848888282", "{Irvine,Zell,Selphie=>71, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3307, 199, "dbc764cc", "Zell,Squall,Irvine", "828488882826", "{Irvine,Zell,Selphie=>70, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3308, 100, "16644315", "Selphie,Rinoa,Quistis", "284888828268", "{Irvine,Zell,Selphie=>69, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3309, 95, "4c5f262a", "Irvine,Zell,Rinoa", "848888282686", "{Irvine,Zell,Selphie=>68, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3310, 160, "b0a03c1b", "Rinoa,Irvine,Quistis", "488882826868", "{Irvine,Zell,Selphie=>67, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3311, 108, "5e6c01b8", "Irvine,Squall,Selphie", "888828268688", "{Irvine,Zell,Selphie=>66, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3312, 210, "28d2fb91", "Irvine,Zell,Rinoa", "888282686884", "{Irvine,Zell,Selphie=>65, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3313, 161, "0da17af6", "Selphie,Irvine,Quistis", "882826868842", "{Irvine,Zell,Selphie=>64, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3314, 124, "917c7ef7", "Irvine,Squall,Selphie", "828268688428", "{Irvine,Zell,Selphie=>63, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(3315, 187, "cabb8164", "Irvine,Squall,Quistis", "282686884286", "{Irvine,Zell,Selphie=>62, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Quistis"),

            new PartyFormation(3316, 154, "ea9abfcd", "Rinoa,Irvine,Selphie", "826868842864", "{Irvine,Zell,Selphie=>61, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(3317, 226, "6fe25082", "Rinoa,Squall,Selphie", "268688428644", "{Irvine,Zell,Selphie=>60, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Quistis"),

            new PartyFormation(3318, 112, "de701393", "Zell,Squall,Selphie", "686884286448", "{Irvine,Zell,Selphie=>59, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Quistis"),

            new PartyFormation(3319, 97, "52614fd0", "Selphie,Zell,Quistis", "868842864482", "{Irvine,Zell,Selphie=>58, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(3320, 160, "44a08bc9", "Rinoa,Irvine,Quistis", "688428644828", "{Irvine,Zell,Selphie=>57, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(3321, 104, "4968f2ce", "Rinoa,Irvine,Quistis", "884286448288", "{Irvine,Zell,Selphie=>56, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(3322, 254, "54fe55ef", "Irvine,Squall,Selphie", "842864482884", "{Irvine,Zell,Selphie=>55, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(3323, 83, "d45398fc", "Rinoa,Squall,Quistis", "428644828846", "{Irvine,Zell,Selphie=>54, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(3324, 29, "2f1d1b85", "Zell,Squall,Rinoa", "286448288462", "{Irvine,Zell,Selphie=>53, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(3325, 165, "fba56dda", "Irvine,Squall,Quistis", "864482884622", "{Irvine,Zell,Selphie=>52, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(3326, 132, "dd84620b", "Zell,Squall,Selphie", "644828846228", "{Irvine,Zell,Selphie=>51, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(3327, 191, "46bf48e8", "Irvine,Squall,Rinoa", "448288462286", "{Irvine,Zell,Selphie=>50, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(3328, 24, "b318eb01", "Selphie,Squall,Quistis", "482884622868", "{Irvine,Zell,Selphie=>49, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(3329, 252, "dcfc8da6", "Irvine,Squall,Quistis", "828846228688", "{Irvine,Zell,Selphie=>48, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(3330, 21, "bf1513e7", "Irvine,Squall,Rinoa", "288462286882", "{Irvine,Zell,Selphie=>47, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(3331, 180, "d3b40b94", "Irvine,Squall,Selphie", "884622868828", "{Irvine,Zell,Selphie=>46, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(3332, 168, "87a8363d", "Selphie,Zell,Quistis", "846228688288", "{Irvine,Zell,Selphie=>45, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(3333, 83, "7353de32", "Zell,Squall,Irvine", "462286882886", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(3334, 21, "35150783", "Selphie,Squall,Quistis", "622868828862", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(3335, 144, "14904d00", "Zell,Squall,Selphie", "228688288628", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(3336, 230, "46e6f939", "Rinoa,Zell,Selphie", "286882886284", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(3337, 93, "cb5dab7e", "Irvine,Squall,Quistis", "868828862842", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(3338, 150, "c29698df", "Zell,Squall,Quistis", "688288628424", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(3339, 45, "982d392c", "Irvine,Squall,Rinoa", "882886284242", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(3340, 180, "f6b4eff5", "Rinoa,Squall,Quistis", "828862842428", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(3341, 165, "f8a5018a", "Irvine,Squall,Selphie", "288628424282", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Quistis"),

            new PartyFormation(3342, 117, "5f75e3fb", "Irvine,Zell,Quistis", "886284242822", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>2}", "Irvine,Zell,Quistis"),

            new PartyFormation(3343, 202, "9fcabc18", "Rinoa,Irvine,Quistis", "862842428224", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>61, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3344, 49, "61319671", "Selphie,Irvine,Quistis", "628424282242", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>60, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3345, 89, "8a59ac56", "Rinoa,Irvine,Selphie", "284242822422", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>59, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3346, 52, "5b34c4d7", "Rinoa,Zell,Selphie", "842428224228", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>58, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3347, 187, "bebb81c4", "Irvine,Squall,Selphie", "424282242286", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>57, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3348, 248, "78f828ad", "Rinoa,Squall,Quistis", "242822422868", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>56, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3349, 220, "80dc37e2", "Rinoa,Zell,Selphie", "428224228688", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>55, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3350, 150, "9196d773", "Zell,Squall,Selphie", "282242286884", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>54, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3351, 208, "c8d0f630", "Rinoa,Zell,Selphie", "822422868848", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>53, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3352, 27, "c51ba2a9", "Rinoa,Squall,Selphie", "224228688486", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>52, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3353, 9, "1009f02e", "Irvine,Squall,Quistis", "242286884862", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>51, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3354, 253, "4cfd77cf", "Irvine,Squall,Quistis", "422868848622", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>50, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3355, 135, "3b87455c", "Selphie,Irvine,Quistis", "228688486226", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>49, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3356, 226, "90e2c065", "Selphie,Squall,Quistis", "286884862264", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>48, Selphie,Irvine,Quistis=>45}", "Irvine,Zell,Selphie"),

            new PartyFormation(3357, 72, "3a48e13a", "Rinoa,Irvine,Selphie", "868848622648", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>47, Selphie,Irvine,Quistis=>44}", "Irvine,Zell,Selphie"),

            new PartyFormation(3358, 131, "f283c1eb", "Irvine,Squall,Quistis", "688486226486", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>46, Selphie,Irvine,Quistis=>43}", "Irvine,Zell,Selphie"),

            new PartyFormation(3359, 241, "0df15b48", "Selphie,Squall,Quistis", "884862264862", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>45, Selphie,Irvine,Quistis=>42}", "Irvine,Zell,Selphie"),

            new PartyFormation(3360, 67, "5b43fde1", "Zell,Squall,Quistis", "848622648626", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>44, Selphie,Irvine,Quistis=>41}", "Irvine,Zell,Selphie"),

            new PartyFormation(3361, 83, "1053d706", "Zell,Squall,Selphie", "486226486266", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>43, Selphie,Irvine,Quistis=>40}", "Irvine,Zell,Selphie"),

            new PartyFormation(3362, 218, "53da91c7", "Zell,Squall,Selphie", "862264862664", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>42, Selphie,Irvine,Quistis=>39}", "Irvine,Zell,Selphie"),

            new PartyFormation(3363, 100, "9364e3f4", "Irvine,Squall,Rinoa", "622648626648", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>41, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Selphie"),

            new PartyFormation(3364, 33, "c221971d", "Zell,Squall,Selphie", "226486266482", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>40, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Selphie"),

            new PartyFormation(3365, 198, "21c65d92", "Zell,Squall,Quistis", "264862664824", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Selphie"),

            new PartyFormation(3366, 228, "42e48363", "Rinoa,Irvine,Selphie", "648626648248", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Selphie"),

            new PartyFormation(3367, 230, "dce64b60", "Selphie,Rinoa,Quistis", "486266482484", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Selphie"),

            new PartyFormation(3368, 69, "e5458819", "Zell,Squall,Quistis", "862664824842", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Selphie"),

            new PartyFormation(3369, 104, "6a68c0de", "Zell,Squall,Irvine", "626648248428", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Selphie"),

            new PartyFormation(3370, 17, "c311f2bf", "Zell,Squall,Irvine", "266482484282", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Selphie"),

            new PartyFormation(3371, 84, "c554bd8c", "Rinoa,Zell,Quistis", "664824842828", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Selphie"),

            new PartyFormation(3372, 29, "fd1d8cd5", "Irvine,Squall,Quistis", "648248428282", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Selphie"),

            new PartyFormation(3373, 60, "c83c0cea", "Zell,Squall,Quistis", "482484282828", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Selphie"),

            new PartyFormation(3374, 124, "f47cfbdb", "Zell,Squall,Irvine", "824842828288", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Selphie"),

            new PartyFormation(3375, 86, "94562678", "Rinoa,Irvine,Quistis", "248428282884", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Selphie"),

            new PartyFormation(3376, 55, "a1372151", "Irvine,Squall,Selphie", "484282828846", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Selphie"),

            new PartyFormation(3377, 70, "c6460db6", "Irvine,Zell,Selphie", "842828288464", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(3378, 197, "94c57ab7", "Irvine,Zell,Selphie", "428282884642", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(3379, 3, "e4033224", "Rinoa,Zell,Quistis", "282828846426", "{Irvine,Zell,Selphie=>116, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>22}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3380, 123, "fa7b818d", "Rinoa,Irvine,Selphie", "828288464266", "{Irvine,Zell,Selphie=>115, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>21}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3381, 29, "481d4f42", "Zell,Squall,Rinoa", "282884642662", "{Irvine,Zell,Selphie=>114, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>20}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3382, 173, "b1ad0b53", "Irvine,Squall,Quistis", "828846426622", "{Irvine,Zell,Selphie=>113, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>19}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3383, 83, "35534c90", "Rinoa,Squall,Selphie", "288464266226", "{Irvine,Zell,Selphie=>112, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>18}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3384, 43, "dd2ba989", "Selphie,Rinoa,Quistis", "884642662266", "{Irvine,Zell,Selphie=>111, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>17}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3385, 53, "62351d8e", "Zell,Squall,Irvine", "846426622662", "{Irvine,Zell,Selphie=>110, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>16}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3386, 115, "e97309af", "Irvine,Squall,Selphie", "464266226626", "{Irvine,Zell,Selphie=>109, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>15}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3387, 72, "5f48a1bc", "Rinoa,Zell,Quistis", "642662266268", "{Irvine,Zell,Selphie=>108, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>14}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3388, 156, "869c5545", "Rinoa,Irvine,Selphie", "426622662688", "{Irvine,Zell,Selphie=>107, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>13}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3389, 233, "6ae9849a", "Irvine,Squall,Selphie", "266226626882", "{Irvine,Zell,Selphie=>106, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3390, 240, "54f091cb", "Zell,Squall,Rinoa", "662266268828", "{Irvine,Zell,Selphie=>105, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3391, 220, "c4dc1da8", "Rinoa,Zell,Quistis", "622662688288", "{Irvine,Zell,Selphie=>104, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3392, 178, "7ab200c1", "Selphie,Rinoa,Quistis", "226626882884", "{Irvine,Zell,Selphie=>103, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3393, 75, "104b5066", "Irvine,Squall,Quistis", "266268828846", "{Irvine,Zell,Selphie=>102, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3394, 116, "f7747fa7", "Zell,Squall,Rinoa", "662688288468", "{Irvine,Zell,Selphie=>101, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3395, 169, "fda96c54", "Zell,Squall,Selphie", "626882884682", "{Irvine,Zell,Selphie=>100, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3396, 28, "bd1ce7fd", "Irvine,Squall,Quistis", "268828846828", "{Irvine,Zell,Selphie=>99, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3397, 172, "feac0cf2", "Selphie,Zell,Quistis", "688288468288", "{Irvine,Zell,Selphie=>98, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3398, 95, "505f6f43", "Rinoa,Irvine,Selphie", "882884682886", "{Irvine,Zell,Selphie=>97, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3399, 90, "5d5af9c0", "Rinoa,Irvine,Selphie", "828846828864", "{Irvine,Zell,Selphie=>96, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3400, 85, "625506f9", "Irvine,Zell,Rinoa", "288468288642", "{Irvine,Zell,Selphie=>95, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3401, 234, "63ea063e", "Selphie,Irvine,Quistis", "884682886424", "{Irvine,Zell,Selphie=>94, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3402, 127, "6a7fbc9f", "Selphie,Irvine,Quistis", "846828864246", "{Irvine,Zell,Selphie=>93, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3403, 213, "85d5f1ec", "Irvine,Zell,Rinoa", "468288642462", "{Irvine,Zell,Selphie=>92, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(3404, 86, "345619b5", "Irvine,Zell,Quistis", "682886424624", "{Irvine,Zell,Selphie=>91, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(3405, 124, "5b7c484a", "Rinoa,Irvine,Selphie", "828864246248", "{Irvine,Zell,Selphie=>90, Irvine,Zell,Quistis=>46, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3406, 45, "852d83bb", "Selphie,Zell,Quistis", "288642462482", "{Irvine,Zell,Selphie=>89, Irvine,Zell,Quistis=>45, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3407, 38, "f02640d8", "Irvine,Zell,Rinoa", "886424624824", "{Irvine,Zell,Selphie=>88, Irvine,Zell,Quistis=>44, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3408, 27, "e71b9c31", "Selphie,Irvine,Quistis", "864246248246", "{Irvine,Zell,Selphie=>87, Irvine,Zell,Quistis=>43, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3409, 62, "0f3e9f16", "Irvine,Squall,Rinoa", "642462482464", "{Irvine,Zell,Selphie=>86, Irvine,Zell,Quistis=>42, Selphie,Irvine,Quistis=>16}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3410, 38, "3326a097", "Irvine,Squall,Rinoa", "424624824644", "{Irvine,Zell,Selphie=>85, Irvine,Zell,Quistis=>41, Selphie,Irvine,Quistis=>15}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3411, 42, "182a9284", "Selphie,Squall,Quistis", "246248246444", "{Irvine,Zell,Selphie=>84, Irvine,Zell,Quistis=>40, Selphie,Irvine,Quistis=>14}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3412, 220, "18dcca6d", "Zell,Squall,Irvine", "462482464448", "{Irvine,Zell,Selphie=>83, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>13}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3413, 253, "18fd96a2", "Irvine,Squall,Selphie", "624824644482", "{Irvine,Zell,Selphie=>82, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3414, 42, "8b2aaf33", "Selphie,Squall,Quistis", "248246444824", "{Irvine,Zell,Selphie=>81, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3415, 0, "b70052f0", "Zell,Squall,Quistis", "482464448248", "{Irvine,Zell,Selphie=>80, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3416, 8, "1a08a069", "Irvine,Squall,Rinoa", "824644482488", "{Irvine,Zell,Selphie=>79, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3417, 194, "70c27aee", "Zell,Squall,Irvine", "246444824884", "{Irvine,Zell,Selphie=>78, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3418, 87, "c6570b8f", "Rinoa,Squall,Selphie", "464448248846", "{Irvine,Zell,Selphie=>77, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3419, 47, "382fae1c", "Rinoa,Zell,Selphie", "644482488466", "{Irvine,Zell,Selphie=>76, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3420, 1, "3901da25", "Zell,Squall,Rinoa", "444824884662", "{Irvine,Zell,Selphie=>75, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3421, 223, "f3df57fa", "Irvine,Squall,Selphie", "448248846626", "{Irvine,Zell,Selphie=>74, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3422, 66, "6842d1ab", "Zell,Squall,Rinoa", "482488466264", "{Irvine,Zell,Selphie=>73, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3423, 151, "55979008", "Irvine,Squall,Quistis", "824884662646", "{Irvine,Zell,Selphie=>72, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3424, 154, "0d9af3a1", "Rinoa,Squall,Quistis", "248846626464", "{Irvine,Zell,Selphie=>71, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3425, 186, "50baf9c6", "Selphie,Irvine,Quistis", "488466264644", "{Irvine,Zell,Selphie=>70, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3426, 218, "ccdadd87", "Rinoa,Squall,Selphie", "884662646444", "{Irvine,Zell,Selphie=>69, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>18}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3427, 25, "8619a4b4", "Rinoa,Zell,Selphie", "846626464442", "{Irvine,Zell,Selphie=>68, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>17}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3428, 82, "005228dd", "Irvine,Squall,Rinoa", "466264644424", "{Irvine,Zell,Selphie=>67, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>16}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3429, 92, "e35cec52", "Selphie,Squall,Quistis", "662646444248", "{Irvine,Zell,Selphie=>66, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>15}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3430, 253, "b7fdcb23", "Zell,Squall,Rinoa", "626464442482", "{Irvine,Zell,Selphie=>65, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>14}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3431, 6, "ab065820", "Selphie,Rinoa,Quistis", "264644424824", "{Irvine,Zell,Selphie=>64, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>13}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3432, 77, "094d75d9", "Irvine,Squall,Rinoa", "646444248242", "{Irvine,Zell,Selphie=>63, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>12}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3433, 185, "ceb97b9e", "Irvine,Squall,Rinoa", "464442482422", "{Irvine,Zell,Selphie=>62, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>11}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3434, 215, "42d7f67f", "Zell,Squall,Irvine", "644424824226", "{Irvine,Zell,Selphie=>61, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3435, 72, "2848d64c", "Rinoa,Squall,Selphie", "444248242268", "{Irvine,Zell,Selphie=>60, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3436, 22, "63169695", "Irvine,Squall,Selphie", "442482422684", "{Irvine,Zell,Selphie=>59, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3437, 189, "5ebdb3aa", "Selphie,Zell,Quistis", "424824226842", "{Irvine,Zell,Selphie=>58, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3438, 255, "42ff7b9b", "Rinoa,Zell,Selphie", "248242268426", "{Irvine,Zell,Selphie=>57, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3439, 83, "53530b38", "Zell,Squall,Quistis", "482422684266", "{Irvine,Zell,Selphie=>56, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3440, 23, "ad170711", "Selphie,Squall,Quistis", "824226842666", "{Irvine,Zell,Selphie=>55, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3441, 27, "7f1b6076", "Rinoa,Irvine,Quistis", "242268426666", "{Irvine,Zell,Selphie=>54, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3442, 80, "07503677", "Rinoa,Zell,Quistis", "422684266668", "{Irvine,Zell,Selphie=>53, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3443, 201, "e4c9a2e4", "Rinoa,Squall,Selphie", "226842666682", "{Irvine,Zell,Selphie=>52, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3444, 212, "b9d4034d", "Selphie,Irvine,Quistis", "268426666828", "{Irvine,Zell,Selphie=>51, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3445, 213, "d2d50e02", "Rinoa,Irvine,Quistis", "684266668282", "{Irvine,Zell,Selphie=>50, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>43}", "Irvine,Zell,Quistis"),

            new PartyFormation(3446, 135, "0687c313", "Irvine,Squall,Selphie", "842666682826", "{Irvine,Zell,Selphie=>49, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>42}", "Irvine,Zell,Quistis"),

            new PartyFormation(3447, 240, "d8f00950", "Selphie,Squall,Quistis", "426666828268", "{Irvine,Zell,Selphie=>48, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>41}", "Irvine,Zell,Quistis"),

            new PartyFormation(3448, 234, "04ea8749", "Irvine,Zell,Rinoa", "266668282684", "{Irvine,Zell,Selphie=>47, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>40}", "Irvine,Zell,Quistis"),

            new PartyFormation(3449, 138, "b88a084e", "Rinoa,Squall,Selphie", "666682826844", "{Irvine,Zell,Selphie=>46, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>39}", "Irvine,Zell,Quistis"),

            new PartyFormation(3450, 161, "dba17d6f", "Rinoa,Irvine,Selphie", "666828268442", "{Irvine,Zell,Selphie=>45, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Quistis"),

            new PartyFormation(3451, 212, "ead46a7c", "Irvine,Zell,Quistis", "668282684428", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Quistis"),

            new PartyFormation(3452, 203, "8ccb4f05", "Zell,Squall,Quistis", "682826844286", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Quistis"),

            new PartyFormation(3453, 130, "47825b5a", "Rinoa,Squall,Selphie", "828268442864", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Quistis"),

            new PartyFormation(3454, 242, "abf2818b", "Zell,Squall,Rinoa", "282684428644", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Quistis"),

            new PartyFormation(3455, 59, "963bb268", "Irvine,Zell,Quistis", "826844286446", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Quistis"),

            new PartyFormation(3456, 54, "8c36d681", "Rinoa,Irvine,Quistis", "268442864464", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Quistis"),

            new PartyFormation(3457, 122, "117ad326", "Zell,Squall,Selphie", "684428644644", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Quistis"),

            new PartyFormation(3458, 5, "d305ab67", "Zell,Squall,Quistis", "844286446442", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(3459, 77, "4c4d8d14", "Rinoa,Irvine,Quistis", "442864464422", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Quistis"),

            new PartyFormation(3460, 121, "4f7959bd", "Rinoa,Irvine,Selphie", "428644644222", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(3461, 48, "3530fbb2", "Selphie,Zell,Quistis", "286446442228", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Quistis"),

            new PartyFormation(3462, 55, "70379703", "Rinoa,Squall,Selphie", "864464422286", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Quistis"),

            new PartyFormation(3463, 0, "47006680", "Selphie,Zell,Quistis", "644644222868", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(3464, 102, "2166d4b9", "Rinoa,Zell,Quistis", "446442228684", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(3465, 175, "0daf20fe", "Selphie,Rinoa,Quistis", "464422286846", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(3466, 18, "3212a05f", "Irvine,Zell,Quistis", "644222868464", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(3467, 69, "27456aac", "Zell,Squall,Quistis", "442228684642", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(3468, 23, "0c170375", "Irvine,Squall,Selphie", "422286846426", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(3469, 88, "8a584f0a", "Rinoa,Zell,Quistis", "222868464268", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(3470, 106, "7b6ae37b", "Rinoa,Squall,Quistis", "228684642684", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(3471, 244, "49f48598", "Zell,Squall,Quistis", "286846426848", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(3472, 97, "e96161f1", "Irvine,Squall,Selphie", "868464268482", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(3473, 180, "fbb451d6", "Irvine,Zell,Quistis", "684642684828", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(3474, 58, "be3a3c57", "Rinoa,Squall,Selphie", "846426848284", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(3475, 120, "7f786344", "Irvine,Squall,Selphie", "464268482848", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(3476, 25, "ff192c2d", "Irvine,Zell,Rinoa", "642684828482", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(3477, 251, "e0fbb562", "Rinoa,Squall,Selphie", "426848284826", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(3478, 60, "a83c46f3", "Selphie,Squall,Quistis", "268482848268", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(3479, 58, "923a6fb0", "Irvine,Zell,Quistis", "684828482684", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(3480, 9, "23095e29", "Rinoa,Squall,Selphie", "848284826842", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3481, 99, "0263c5ae", "Irvine,Squall,Rinoa", "482848268426", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3482, 74, "7d4a5f4f", "Rinoa,Irvine,Selphie", "828482684264", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3483, 206, "c7ced6dc", "Rinoa,Squall,Quistis", "284826842644", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3484, 176, "22b0b3e5", "Zell,Squall,Rinoa", "848268426448", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3485, 42, "e42a8eba", "Irvine,Squall,Rinoa", "482684264484", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3486, 119, "bb77a16b", "Rinoa,Zell,Quistis", "826842644846", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3487, 224, "48e084c8", "Selphie,Rinoa,Quistis", "268426448468", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3488, 189, "eabda961", "Selphie,Irvine,Quistis", "684264484682", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3489, 98, "5e62dc86", "Selphie,Irvine,Quistis", "842644846824", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3490, 236, "e4ece947", "Rinoa,Zell,Quistis", "426448468248", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3491, 221, "1bdd2574", "Selphie,Squall,Quistis", "264484682482", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(3492, 74, "aa4a7a9d", "Zell,Squall,Quistis", "644846824824", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(3493, 128, "e5803b12", "Rinoa,Squall,Selphie", "448468248248", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(3494, 132, "0b84d2e3", "Rinoa,Squall,Quistis", "484682482488", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(3495, 97, "1e6124e0", "Irvine,Zell,Selphie", "846824824882", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(3496, 217, "edd92399", "Irvine,Zell,Rinoa", "468248248822", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(3497, 162, "cfa2f65e", "Irvine,Squall,Rinoa", "682482488224", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(3498, 39, "7a27ba3f", "Rinoa,Irvine,Quistis", "824824882246", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(3499, 99, "2963af0c", "Rinoa,Zell,Selphie", "248248822466", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Selphie"),

            new PartyFormation(3500, 15, "6e0f6055", "Irvine,Zell,Selphie", "482488224666", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Selphie"),

            new PartyFormation(3501, 164, "a2a41a6a", "Zell,Squall,Selphie", "824882246668", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3502, 231, "97e7bb5b", "Rinoa,Zell,Selphie", "248822466686", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3503, 34, "4c22aff8", "Selphie,Irvine,Quistis", "488224666864", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3504, 50, "0e32acd1", "Rinoa,Irvine,Quistis", "882246668644", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3505, 225, "36e17336", "Irvine,Zell,Rinoa", "822466686442", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3506, 220, "e0dcb237", "Rinoa,Squall,Quistis", "224666864428", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3507, 206, "c9ced3a4", "Zell,Squall,Irvine", "246668644284", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3508, 100, "4664450d", "Rinoa,Irvine,Selphie", "466686442848", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3509, 201, "3ac98cc2", "Rinoa,Squall,Quistis", "666864428482", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3510, 192, "90c03ad3", "Selphie,Zell,Quistis", "668644284828", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3511, 247, "45f78610", "Selphie,Irvine,Quistis", "686442848286", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3512, 157, "f59d2509", "Irvine,Squall,Rinoa", "864428482862", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(3513, 39, "6327b30e", "Rinoa,Zell,Quistis", "644284828626", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(3514, 73, "5b49b12f", "Irvine,Zell,Quistis", "442848286262", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(3515, 182, "4bb6f33c", "Rinoa,Irvine,Quistis", "428482862624", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3516, 106, "576a08c5", "Rinoa,Zell,Quistis", "284828626244", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3517, 47, "542ff21a", "Rinoa,Squall,Selphie", "848286262446", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3518, 74, "4e4a314b", "Selphie,Zell,Quistis", "482862624464", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3519, 158, "1b9e0728", "Rinoa,Zell,Selphie", "828626244644", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3520, 103, "99676c41", "Selphie,Irvine,Quistis", "286262446446", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3521, 75, "0f4b15e6", "Irvine,Zell,Rinoa", "862624464466", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3522, 136, "b9889727", "Irvine,Squall,Selphie", "626244644668", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3523, 96, "6c606dd4", "Irvine,Squall,Quistis", "262446446688", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3524, 125, "4c7d8b7d", "Zell,Squall,Quistis", "624464466882", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3525, 162, "71a2aa72", "Rinoa,Irvine,Selphie", "244644668824", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3526, 93, "b85d7ec3", "Selphie,Irvine,Quistis", "446446688242", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3527, 64, "8a409340", "Rinoa,Zell,Quistis", "464466882428", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>38}", "Irvine,Zell,Quistis"),

            new PartyFormation(3528, 220, "addc6279", "Zell,Squall,Rinoa", "644668824288", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>37}", "Irvine,Zell,Quistis"),

            new PartyFormation(3529, 108, "0f6cfbbe", "Zell,Squall,Quistis", "446688242888", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>36}", "Irvine,Zell,Quistis"),

            new PartyFormation(3530, 15, "b90f441f", "Zell,Squall,Irvine", "466882428886", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>35}", "Irvine,Zell,Quistis"),

            new PartyFormation(3531, 59, "013ba36c", "Selphie,Zell,Quistis", "668824288866", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Quistis"),

            new PartyFormation(3532, 183, "83b7ad35", "Zell,Squall,Quistis", "688242888666", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Quistis"),

            new PartyFormation(3533, 249, "77f915ca", "Rinoa,Zell,Selphie", "882428886662", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Quistis"),

            new PartyFormation(3534, 238, "1dee033b", "Irvine,Squall,Rinoa", "824288866624", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Quistis"),

            new PartyFormation(3535, 245, "bdf58a58", "Rinoa,Zell,Selphie", "242888666242", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(3536, 194, "09c2e7b1", "Rinoa,Zell,Quistis", "428886662424", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Quistis"),

            new PartyFormation(3537, 122, "ae7ac496", "Selphie,Zell,Quistis", "288866624244", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(3538, 47, "d42f9817", "Zell,Squall,Irvine", "888666242446", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Quistis"),

            new PartyFormation(3539, 100, "5164f404", "Selphie,Squall,Quistis", "886662424468", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Quistis"),

            new PartyFormation(3540, 109, "296d4ded", "Rinoa,Zell,Quistis", "866624244682", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(3541, 150, "63969422", "Irvine,Zell,Quistis", "666242446824", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(3542, 139, "7c8b9eb3", "Rinoa,Irvine,Quistis", "662424468246", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>41, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(3543, 63, "c33f4c70", "Rinoa,Zell,Quistis", "624244682466", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>40, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(3544, 221, "f9dddbe9", "Irvine,Zell,Selphie", "242446824662", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(3545, 173, "3badd06e", "Rinoa,Irvine,Selphie", "424468246622", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(3546, 151, "8197730f", "Selphie,Squall,Quistis", "244682466226", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(3547, 36, "1f24bf9c", "Rinoa,Irvine,Quistis", "446824662268", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(3548, 175, "43af4da5", "Irvine,Squall,Rinoa", "468246622686", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(3549, 234, "2dea857a", "Selphie,Squall,Quistis", "682466226864", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(3550, 226, "37e2312b", "Selphie,Rinoa,Quistis", "824662268644", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(3551, 140, "a88c3988", "Zell,Squall,Selphie", "246622686448", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(3552, 108, "846c1f21", "Selphie,Squall,Quistis", "466226864488", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3553, 11, "c80b7f46", "Rinoa,Irvine,Quistis", "662268644886", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(3554, 208, "e3d0b507", "Zell,Squall,Irvine", "622686448868", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(3555, 111, "616f6634", "Irvine,Squall,Quistis", "226864488686", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(3556, 202, "adca8c5d", "Selphie,Zell,Quistis", "268644886864", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(3557, 240, "e2f049d2", "Rinoa,Zell,Selphie", "686448868648", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(3558, 57, "41399aa3", "Irvine,Zell,Selphie", "864488686482", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(3559, 182, "4fb6b1a0", "Irvine,Zell,Rinoa", "644886864824", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3560, 168, "9ca89159", "Rinoa,Irvine,Selphie", "448868648248", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3561, 229, "13e5311e", "Selphie,Zell,Quistis", "488686482482", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3562, 193, "e8c13dff", "Irvine,Squall,Selphie", "886864824822", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3563, 101, "ad6547cc", "Rinoa,Squall,Selphie", "868648248222", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3564, 199, "03c7ea15", "Selphie,Rinoa,Quistis", "686482482226", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3565, 175, "e6af412a", "Selphie,Irvine,Quistis", "864824822266", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3566, 245, "aef5bb1b", "Rinoa,Zell,Quistis", "648248222662", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Selphie"),

            new PartyFormation(3567, 133, "ef8514b8", "Rinoa,Irvine,Quistis", "482482226622", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Selphie"),

            new PartyFormation(3568, 74, "464a1291", "Irvine,Squall,Selphie", "824822266224", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Selphie"),

            new PartyFormation(3569, 88, "ac5845f6", "Irvine,Squall,Quistis", "248222662248", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Selphie"),

            new PartyFormation(3570, 42, "d92aedf7", "Rinoa,Squall,Selphie", "482226622484", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Selphie"),

            new PartyFormation(3571, 210, "4fd2c464", "Rinoa,Squall,Quistis", "822266224844", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Selphie"),

            new PartyFormation(3572, 236, "7dec46cd", "Irvine,Squall,Selphie", "222662248448", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Selphie"),

            new PartyFormation(3573, 186, "6abacb82", "Irvine,Zell,Selphie", "226622484484", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Selphie"),

            new PartyFormation(3574, 22, "c4167293", "Irvine,Zell,Selphie", "266224844844", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(3575, 41, "4529c2d0", "Rinoa,Squall,Quistis", "662248448442", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(3576, 3, "a90382c9", "Rinoa,Irvine,Selphie", "622484484426", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(3577, 206, "38ce1dce", "Selphie,Zell,Quistis", "224844844264", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(3578, 43, "582ba4ef", "Selphie,Squall,Quistis", "248448442646", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(3579, 176, "16b03bfc", "Irvine,Squall,Rinoa", "484484426468", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(3580, 56, "bc388285", "Rinoa,Squall,Selphie", "844844264688", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(3581, 178, "13b248da", "Zell,Squall,Rinoa", "448442646884", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(3582, 183, "67b7a10b", "Zell,Squall,Irvine", "484426468846", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(3583, 195, "75c31be8", "Irvine,Zell,Quistis", "844264688466", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(3584, 3, "1403c201", "Rinoa,Irvine,Quistis", "442646884666", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(3585, 124, "f87c18a6", "Irvine,Squall,Rinoa", "426468846668", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3586, 189, "d2bd42e7", "Zell,Squall,Selphie", "264688466682", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(3587, 162, "caa20e94", "Irvine,Squall,Rinoa", "646884666824", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(3588, 233, "81e97d3d", "Selphie,Rinoa,Quistis", "468846668242", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(3589, 193, "cec11932", "Irvine,Zell,Selphie", "688466682422", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(3590, 145, "0c912683", "Zell,Squall,Quistis", "884666824222", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3591, 219, "9fdb8000", "Rinoa,Squall,Quistis", "846668242226", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3592, 117, "f175b039", "Irvine,Squall,Selphie", "466682422262", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3593, 227, "6fe3967e", "Irvine,Squall,Selphie", "666824222626", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3594, 53, "5f35a7df", "Rinoa,Irvine,Quistis", "668242226262", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3595, 120, "58789c2c", "Irvine,Squall,Rinoa", "682422262628", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3596, 248, "60f816f5", "Zell,Squall,Irvine", "824222626288", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3597, 30, "d71e9c8a", "Selphie,Squall,Quistis", "242226262884", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3598, 118, "0876e2fb", "Selphie,Irvine,Quistis", "422262628844", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3599, 233, "1ce94f18", "Selphie,Zell,Quistis", "222626288442", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(3600, 0, "aa002d71", "Selphie,Rinoa,Quistis", "226262884428", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(3601, 81, "4651f756", "Rinoa,Squall,Quistis", "262628844282", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(3602, 198, "0cc6b3d7", "Selphie,Zell,Quistis", "626288442824", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(3603, 176, "aab044c4", "Selphie,Zell,Quistis", "262884428248", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(3604, 153, "55992fad", "Rinoa,Squall,Selphie", "628844282482", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(3605, 142, "eb8e32e2", "Rinoa,Irvine,Selphie", "288442824824", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(3606, 216, "5bd8b673", "Selphie,Squall,Quistis", "884428248248", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Selphie"),

            new PartyFormation(3607, 206, "72cee930", "Irvine,Squall,Selphie", "844282482484", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Selphie"),

            new PartyFormation(3608, 70, "784619a9", "Irvine,Zell,Selphie", "442824824844", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>2}", "Irvine,Zell,Selphie"),

            new PartyFormation(3609, 96, "53609b2e", "Irvine,Zell,Selphie", "428248248448", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>1}", "Irvine,Zell,Selphie"),

            new PartyFormation(3610, 254, "a2fe46cf", "Selphie,Irvine,Quistis", "282482484484", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3611, 241, "32f1685c", "Rinoa,Irvine,Selphie", "824824844842", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(3612, 189, "51bda765", "Irvine,Squall,Selphie", "248248448422", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(3613, 223, "b3df3c3a", "Rinoa,Zell,Quistis", "482484484226", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(3614, 66, "e94280eb", "Irvine,Zell,Selphie", "824844842264", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(3615, 90, "f55aae48", "Irvine,Zell,Rinoa", "248448422644", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(3616, 102, "2c6654e1", "Selphie,Zell,Quistis", "484484226444", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3617, 116, "dc74e206", "Irvine,Zell,Selphie", "844842264448", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(3618, 70, "d14640c7", "Rinoa,Irvine,Selphie", "448422644484", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(3619, 144, "239066f4", "Selphie,Rinoa,Quistis", "484226444848", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(3620, 146, "b8925e1d", "Rinoa,Zell,Quistis", "842264448484", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(3621, 109, "566d1892", "Zell,Squall,Selphie", "422644484842", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(3622, 220, "1cdc2263", "Rinoa,Squall,Selphie", "226444848428", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(3623, 198, "17c6fe60", "Irvine,Zell,Quistis", "264448484284", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(3624, 123, "df7bbf19", "Rinoa,Irvine,Quistis", "644484842846", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3625, 64, "02402bde", "Rinoa,Zell,Selphie", "444848428468", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3626, 100, "ce6481bf", "Zell,Squall,Irvine", "448484284688", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3627, 13, "590da08c", "Irvine,Squall,Rinoa", "484842846882", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3628, 0, "ca0033d5", "Irvine,Squall,Rinoa", "848428468828", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3629, 159, "3d9f27ea", "Selphie,Irvine,Quistis", "484284688286", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3630, 233, "03e97adb", "Irvine,Zell,Selphie", "842846882862", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Selphie"),

            new PartyFormation(3631, 58, "6e3a3978", "Selphie,Zell,Quistis", "428468828624", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Selphie"),

            new PartyFormation(3632, 29, "971d3851", "Irvine,Squall,Quistis", "284688286242", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Selphie"),

            new PartyFormation(3633, 63, "5e3fd8b6", "Zell,Squall,Irvine", "846882862426", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Selphie"),

            new PartyFormation(3634, 250, "67fae9b7", "Rinoa,Squall,Quistis", "468828624264", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(3635, 149, "f3957524", "Rinoa,Squall,Selphie", "688286242642", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(3636, 44, "fe2c088d", "Zell,Squall,Rinoa", "882862426428", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(3637, 104, "0d68ca42", "Zell,Squall,Irvine", "828624264288", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(3638, 74, "d44a6a53", "Rinoa,Squall,Selphie", "286242642884", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(3639, 70, "5f46bf90", "Rinoa,Zell,Quistis", "862426428844", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(3640, 221, "d8dda089", "Zell,Squall,Quistis", "624264288442", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(3641, 61, "d03d488e", "Irvine,Squall,Quistis", "242642884422", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(3642, 7, "820758af", "Zell,Squall,Rinoa", "426428844226", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(3643, 128, "a08044bc", "Rinoa,Squall,Quistis", "264288442268", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(3644, 246, "50f6bc45", "Rinoa,Irvine,Selphie", "642884422684", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(3645, 201, "c8c95f9a", "Zell,Squall,Selphie", "428844226842", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3646, 250, "e3fad0cb", "Selphie,Squall,Quistis", "288442268424", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(3647, 106, "856af0a8", "Zell,Squall,Quistis", "884422684244", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(3648, 203, "2dcbd7c1", "Irvine,Zell,Rinoa", "844226842446", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(3649, 205, "7bcddb66", "Zell,Squall,Irvine", "442268424462", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(3650, 99, "0663aea7", "Rinoa,Squall,Quistis", "422684244626", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(3651, 210, "93d26f54", "Irvine,Squall,Quistis", "226842446264", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(3652, 125, "7d7d2efd", "Zell,Squall,Irvine", "268424462642", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(3653, 76, "274c47f2", "Rinoa,Irvine,Selphie", "684244626428", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(3654, 146, "10928e43", "Rinoa,Irvine,Quistis", "842446264284", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Selphie"),

            new PartyFormation(3655, 145, "c0912cc0", "Irvine,Zell,Selphie", "424462642842", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Selphie"),

            new PartyFormation(3656, 242, "95f2bdf9", "Zell,Squall,Selphie", "244626428424", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3657, 210, "f5d2f13e", "Zell,Squall,Rinoa", "446264284244", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3658, 69, "4445cb9f", "Selphie,Irvine,Quistis", "462642842442", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3659, 188, "31bc54ec", "Irvine,Squall,Rinoa", "626428424428", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Quistis"),

            new PartyFormation(3660, 152, "299840b5", "Irvine,Zell,Quistis", "264284244288", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Quistis"),

            new PartyFormation(3661, 136, "1a88e34a", "Rinoa,Irvine,Quistis", "642842442888", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>52, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Selphie"),

            new PartyFormation(3662, 197, "96c582bb", "Rinoa,Squall,Selphie", "428424428882", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>51, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Selphie"),

            new PartyFormation(3663, 143, "f78fd3d8", "Irvine,Squall,Rinoa", "284244288826", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>50, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Selphie"),

            new PartyFormation(3664, 217, "ebd93331", "Rinoa,Irvine,Selphie", "842442888262", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>49, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Selphie"),

            new PartyFormation(3665, 249, "a1f9ea16", "Irvine,Squall,Quistis", "424428882622", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>48, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Selphie"),

            new PartyFormation(3666, 191, "bfbf8f97", "Selphie,Squall,Quistis", "244288826226", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>47, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Selphie"),

            new PartyFormation(3667, 26, "681a5584", "Zell,Squall,Irvine", "442888262264", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>46, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Selphie"),

            new PartyFormation(3668, 92, "015cd16d", "Irvine,Squall,Rinoa", "428882622648", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>45, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Selphie"),

            new PartyFormation(3669, 162, "83a291a2", "Rinoa,Zell,Selphie", "288826226484", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>44, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Selphie"),

            new PartyFormation(3670, 227, "59e38e33", "Selphie,Rinoa,Quistis", "888262264846", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>43, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Selphie"),

            new PartyFormation(3671, 169, "89a945f0", "Zell,Squall,Irvine", "882622648462", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>42, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Selphie"),

            new PartyFormation(3672, 2, "38021769", "Zell,Squall,Selphie", "826226484624", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>41, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Selphie"),

            new PartyFormation(3673, 60, "403c25ee", "Zell,Squall,Selphie", "262264846248", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>40, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Selphie"),

            new PartyFormation(3674, 62, "713eda8f", "Zell,Squall,Rinoa", "622648462484", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>39, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(3675, 244, "b7f4d11c", "Selphie,Rinoa,Quistis", "226484624848", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>38, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(3676, 155, "c29bc125", "Selphie,Rinoa,Quistis", "264846248486", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>37, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(3677, 200, "18c8b2fa", "Selphie,Zell,Quistis", "648462484868", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>36, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(3678, 88, "9b5890ab", "Irvine,Squall,Quistis", "484624848688", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>35, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Selphie"),

            new PartyFormation(3679, 11, "700be308", "Selphie,Rinoa,Quistis", "846248486886", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>34, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Selphie"),

            new PartyFormation(3680, 108, "f46c4aa1", "Irvine,Zell,Selphie", "462484868868", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>33, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Selphie"),

            new PartyFormation(3681, 95, "aa5f04c6", "Rinoa,Zell,Selphie", "624848688686", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>32, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Selphie"),

            new PartyFormation(3682, 13, "750d8c87", "Zell,Squall,Rinoa", "248486886862", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>31, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Selphie"),

            new PartyFormation(3683, 0, "ef0027b4", "Zell,Squall,Quistis", "484868868628", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>30, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Selphie"),

            new PartyFormation(3684, 97, "3861efdd", "Rinoa,Irvine,Selphie", "848688686282", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>29, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(3685, 182, "7ab6a752", "Rinoa,Squall,Selphie", "486886862824", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(3686, 44, "222c6a23", "Selphie,Squall,Quistis", "868868628248", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>27, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(3687, 82, "0f520b20", "Irvine,Zell,Selphie", "688686282484", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>26, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(3688, 18, "4012acd9", "Rinoa,Squall,Quistis", "886862824844", "{Irvine,Zell,Selphie=>50, Irvine,Zell,Quistis=>25, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3689, 115, "c173e69e", "Irvine,Zell,Rinoa", "868628248446", "{Irvine,Zell,Selphie=>49, Irvine,Zell,Quistis=>24, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3690, 209, "2ad1857f", "Rinoa,Irvine,Selphie", "686282484462", "{Irvine,Zell,Selphie=>48, Irvine,Zell,Quistis=>23, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3691, 28, "911cb94c", "Zell,Squall,Irvine", "862824844628", "{Irvine,Zell,Selphie=>47, Irvine,Zell,Quistis=>22, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3692, 120, "26783d95", "Zell,Squall,Rinoa", "628248446288", "{Irvine,Zell,Selphie=>46, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3693, 51, "7a33ceaa", "Selphie,Irvine,Quistis", "282484462886", "{Irvine,Zell,Selphie=>45, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3694, 130, "d282fa9b", "Zell,Squall,Irvine", "824844628864", "{Irvine,Zell,Selphie=>44, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>10}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3695, 2, "b9021e38", "Rinoa,Squall,Selphie", "248446288644", "{Irvine,Zell,Selphie=>43, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>9}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3696, 108, "026c1e11", "Rinoa,Irvine,Quistis", "484462886448", "{Irvine,Zell,Selphie=>42, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>8}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3697, 88, "8b582b76", "Rinoa,Squall,Selphie", "844628864488", "{Irvine,Zell,Selphie=>41, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3698, 12, "c50ca577", "Irvine,Squall,Rinoa", "446288644888", "{Irvine,Zell,Selphie=>40, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3699, 214, "f1d6e5e4", "Irvine,Zell,Rinoa", "462886448884", "{Irvine,Zell,Selphie=>39, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3700, 227, "24e38a4d", "Rinoa,Irvine,Quistis", "628864488846", "{Irvine,Zell,Selphie=>38, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3701, 147, "8d938902", "Selphie,Squall,Quistis", "288644888466", "{Irvine,Zell,Selphie=>37, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3702, 28, "b51c2213", "Selphie,Rinoa,Quistis", "886448884668", "{Irvine,Zell,Selphie=>36, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3703, 14, "dd0e7c50", "Irvine,Zell,Rinoa", "864488846684", "{Irvine,Zell,Selphie=>35, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3704, 235, "feeb7e49", "Selphie,Irvine,Quistis", "644888466846", "{Irvine,Zell,Selphie=>34, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3705, 53, "8035334e", "Zell,Squall,Rinoa", "448884668462", "{Irvine,Zell,Selphie=>33, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3706, 156, "489ccc6f", "Zell,Squall,Quistis", "488846684628", "{Irvine,Zell,Selphie=>32, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3707, 231, "fde70d7c", "Irvine,Squall,Rinoa", "888466846286", "{Irvine,Zell,Selphie=>31, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3708, 100, "6b64b605", "Selphie,Zell,Quistis", "884668462868", "{Irvine,Zell,Selphie=>30, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3709, 53, "7635365a", "Irvine,Squall,Quistis", "846684628682", "{Irvine,Zell,Selphie=>29, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3710, 211, "6ed3c08b", "Selphie,Irvine,Quistis", "466846286826", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3711, 85, "eb558568", "Zell,Squall,Quistis", "668462868262", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Quistis"),

            new PartyFormation(3712, 127, "d87fad81", "Irvine,Zell,Rinoa", "684628682626", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>2}", "Irvine,Zell,Quistis"),

            new PartyFormation(3713, 0, "08005e26", "Irvine,Zell,Quistis", "846286826268", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>1}", "Irvine,Zell,Quistis"),

            new PartyFormation(3714, 59, "fc3bda67", "Selphie,Irvine,Quistis", "462868262686", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3715, 177, "b4b19014", "Rinoa,Squall,Selphie", "628682626862", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>7}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3716, 248, "8cf8a0bd", "Zell,Squall,Selphie", "286826268628", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3717, 4, "160436b2", "Irvine,Squall,Quistis", "868262686288", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3718, 33, "2821b603", "Rinoa,Irvine,Selphie", "682626862882", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3719, 33, "e5219980", "Selphie,Rinoa,Quistis", "826268628822", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3720, 19, "05138bb9", "Irvine,Squall,Selphie", "262686288226", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3721, 251, "27fb0bfe", "Irvine,Squall,Rinoa", "626862882266", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3722, 255, "47ffaf5f", "Selphie,Irvine,Quistis", "268628822666", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3723, 198, "51c6cdac", "Selphie,Squall,Quistis", "686288226664", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(3724, 88, "23582a75", "Rinoa,Zell,Selphie", "862882266648", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(3725, 247, "74f7ea0a", "Irvine,Zell,Quistis", "628822666486", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(3726, 153, "e499e27b", "Irvine,Squall,Selphie", "288226664862", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Quistis"),

            new PartyFormation(3727, 169, "9ea91898", "Rinoa,Zell,Selphie", "882266648622", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Quistis"),

            new PartyFormation(3728, 13, "b10df8f1", "Zell,Squall,Irvine", "822666486222", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Quistis"),

            new PartyFormation(3729, 50, "60329cd6", "Irvine,Squall,Selphie", "226664862224", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Quistis"),

            new PartyFormation(3730, 218, "04da2b57", "Rinoa,Irvine,Quistis", "266648622244", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(3731, 99, "26632644", "Rinoa,Irvine,Selphie", "666486222446", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(3732, 120, "6a78332d", "Zell,Squall,Irvine", "664862224468", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(3733, 147, "f693b062", "Selphie,Rinoa,Quistis", "648622244686", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(3734, 108, "4a6c25f3", "Zell,Squall,Selphie", "486222446868", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(3735, 142, "b08e62b0", "Irvine,Zell,Quistis", "862224468684", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(3736, 209, "92d1d529", "Selphie,Rinoa,Quistis", "622244686842", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>21, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Selphie"),

            new PartyFormation(3737, 0, "b90070ae", "Irvine,Squall,Selphie", "222446868428", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>20, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Selphie"),

            new PartyFormation(3738, 25, "3c192e4f", "Irvine,Zell,Selphie", "224468684282", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>19, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(3739, 238, "22eef9dc", "Zell,Squall,Selphie", "244686842824", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>18, Selphie,Irvine,Quistis=>6}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3740, 9, "cc099ae5", "Zell,Squall,Selphie", "446868428242", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>17, Selphie,Irvine,Quistis=>5}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3741, 102, "bf66e9ba", "Irvine,Squall,Quistis", "468684282424", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>16, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3742, 228, "d9e4606b", "Selphie,Rinoa,Quistis", "686842824248", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3743, 95, "195fd7c8", "Zell,Squall,Quistis", "868428242486", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3744, 62, "ae3e0061", "Rinoa,Zell,Selphie", "684282424864", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3745, 137, "0089e786", "Selphie,Irvine,Quistis", "842824248642", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3746, 230, "56e69847", "Rinoa,Squall,Selphie", "428242486424", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>34}", "Irvine,Zell,Quistis"),

            new PartyFormation(3747, 126, "107ea874", "Rinoa,Zell,Quistis", "282424864244", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>33}", "Irvine,Zell,Quistis"),

            new PartyFormation(3748, 249, "5af9419d", "Rinoa,Irvine,Selphie", "824248642442", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>32}", "Irvine,Zell,Quistis"),

            new PartyFormation(3749, 140, "4a8cf612", "Irvine,Squall,Selphie", "242486424428", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>31}", "Irvine,Zell,Quistis"),

            new PartyFormation(3750, 234, "94ea71e3", "Rinoa,Zell,Selphie", "424864244284", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>30}", "Irvine,Zell,Quistis"),

            new PartyFormation(3751, 23, "8f17d7e0", "Zell,Squall,Selphie", "248642442846", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>29}", "Irvine,Zell,Quistis"),

            new PartyFormation(3752, 45, "082d5a99", "Zell,Squall,Quistis", "486424428462", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>28}", "Irvine,Zell,Quistis"),

            new PartyFormation(3753, 64, "3840615e", "Irvine,Squall,Rinoa", "864244284628", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>27}", "Irvine,Zell,Quistis"),

            new PartyFormation(3754, 200, "bdc8493f", "Selphie,Squall,Quistis", "642442846288", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>26}", "Irvine,Zell,Quistis"),

            new PartyFormation(3755, 82, "7a52920c", "Rinoa,Squall,Quistis", "424428462884", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>25}", "Irvine,Zell,Quistis"),

            new PartyFormation(3756, 240, "3ef00755", "Irvine,Squall,Selphie", "244284628848", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>24}", "Irvine,Zell,Quistis"),

            new PartyFormation(3757, 45, "2f2d356a", "Irvine,Zell,Quistis", "442846288482", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>23}", "Irvine,Zell,Quistis"),

            new PartyFormation(3758, 130, "16823a5b", "Selphie,Zell,Quistis", "428462884824", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>22}", "Irvine,Zell,Quistis"),

            new PartyFormation(3759, 156, "809cc2f8", "Selphie,Squall,Quistis", "284628848248", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>21}", "Irvine,Zell,Quistis"),

            new PartyFormation(3760, 246, "49f6c3d1", "Irvine,Zell,Quistis", "846288482484", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>20}", "Irvine,Zell,Quistis"),

            new PartyFormation(3761, 97, "32613e36", "Zell,Squall,Rinoa", "462884824842", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>15, Selphie,Irvine,Quistis=>19}", "Irvine,Zell,Selphie"),

            new PartyFormation(3762, 32, "e8202137", "Irvine,Zell,Selphie", "628848248428", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>14, Selphie,Irvine,Quistis=>18}", "Irvine,Zell,Selphie"),

            new PartyFormation(3763, 87, "475716a4", "Rinoa,Zell,Selphie", "288482484286", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>13, Selphie,Irvine,Quistis=>17}", "Irvine,Zell,Selphie"),

            new PartyFormation(3764, 210, "0fd2cc0d", "Irvine,Zell,Selphie", "884824842864", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>12, Selphie,Irvine,Quistis=>16}", "Irvine,Zell,Selphie"),

            new PartyFormation(3765, 251, "15fb07c2", "Selphie,Zell,Quistis", "848248428646", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>15}", "Irvine,Zell,Quistis"),

            new PartyFormation(3766, 75, "1a4b99d3", "Zell,Squall,Rinoa", "482484286466", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>14}", "Irvine,Zell,Quistis"),

            new PartyFormation(3767, 64, "c740f910", "Rinoa,Zell,Selphie", "824842864668", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>13}", "Irvine,Zell,Quistis"),

            new PartyFormation(3768, 237, "54ed1c09", "Rinoa,Irvine,Selphie", "248428646682", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>12}", "Irvine,Zell,Quistis"),

            new PartyFormation(3769, 117, "5f75de0e", "Rinoa,Irvine,Selphie", "484286466822", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>11}", "Irvine,Zell,Quistis"),

            new PartyFormation(3770, 172, "dbac002f", "Irvine,Zell,Rinoa", "842864668228", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>10}", "Irvine,Zell,Quistis"),

            new PartyFormation(3771, 164, "03a4963c", "Rinoa,Squall,Selphie", "428646682288", "{Irvine,Zell,Selphie=>13, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(3772, 66, "21426fc5", "Zell,Squall,Irvine", "286466822884", "{Irvine,Zell,Selphie=>12, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(3773, 181, "deb5cd1a", "Rinoa,Squall,Quistis", "864668228842", "{Irvine,Zell,Selphie=>11, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(3774, 2, "7402704b", "Zell,Squall,Quistis", "646682288424", "{Irvine,Zell,Selphie=>10, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(3775, 66, "0842da28", "Irvine,Squall,Selphie", "466822884244", "{Irvine,Zell,Selphie=>9, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(3776, 223, "c5df4341", "Irvine,Zell,Quistis", "668228842446", "{Irvine,Zell,Selphie=>8, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Quistis"),

            new PartyFormation(3777, 211, "cbd3a0e6", "Selphie,Zell,Quistis", "682288424466", "{Irvine,Zell,Selphie=>7, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3778, 5, "1c05c627", "Selphie,Squall,Quistis", "822884244662", "{Irvine,Zell,Selphie=>6, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3779, 255, "d9ff70d4", "Zell,Squall,Selphie", "228842446626", "{Irvine,Zell,Selphie=>5, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3780, 27, "be1bd27d", "Selphie,Irvine,Quistis", "288424466266", "{Irvine,Zell,Selphie=>4, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3781, 168, "f5a8e572", "Rinoa,Irvine,Selphie", "884244662668", "{Irvine,Zell,Selphie=>3, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Selphie"),

            new PartyFormation(3782, 254, "76fe9dc3", "Rinoa,Zell,Quistis", "842446626684", "{Irvine,Zell,Selphie=>2, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Selphie"),

            new PartyFormation(3783, 76, "c64cc640", "Rinoa,Squall,Selphie", "424466266848", "{Irvine,Zell,Selphie=>1, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Selphie"),

            new PartyFormation(3784, 152, "68981979", "Irvine,Zell,Selphie", "244662668488", "{Irvine,Zell,Selphie=>0, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>4}", "Irvine,Zell,Selphie"),

            new PartyFormation(3785, 27, "4d1be6be", "Irvine,Zell,Quistis", "446626684886", "{Irvine,Zell,Selphie=>28, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>3}", "Irvine,Zell,Quistis"),

            new PartyFormation(3786, 35, "0a23531f", "Irvine,Zell,Quistis", "466266848866", "{Irvine,Zell,Selphie=>27, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>2}", "Irvine,Zell,Quistis"),

            new PartyFormation(3787, 88, "3d58066c", "Rinoa,Zell,Quistis", "662668488668", "{Irvine,Zell,Selphie=>26, Irvine,Zell,Quistis=>11, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3788, 247, "53f7d435", "Selphie,Irvine,Quistis", "626684886686", "{Irvine,Zell,Selphie=>25, Irvine,Zell,Quistis=>10, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3789, 43, "d92bb0ca", "Selphie,Squall,Quistis", "266848866866", "{Irvine,Zell,Selphie=>24, Irvine,Zell,Quistis=>9, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3790, 180, "cdb4023b", "Irvine,Squall,Quistis", "668488668668", "{Irvine,Zell,Selphie=>23, Irvine,Zell,Quistis=>8, Selphie,Irvine,Quistis=>3}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3791, 245, "22f51d58", "Zell,Squall,Irvine", "684886686682", "{Irvine,Zell,Selphie=>22, Irvine,Zell,Quistis=>7, Selphie,Irvine,Quistis=>2}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3792, 94, "9b5e7eb1", "Irvine,Squall,Selphie", "848866866824", "{Irvine,Zell,Selphie=>21, Irvine,Zell,Quistis=>6, Selphie,Irvine,Quistis=>1}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3793, 188, "dfbc0f96", "Selphie,Irvine,Quistis", "488668668248", "{Irvine,Zell,Selphie=>20, Irvine,Zell,Quistis=>5, Selphie,Irvine,Quistis=>0}", "Selphie,Irvine,Quistis"),

            new PartyFormation(3794, 214, "b3d68717", "Rinoa,Zell,Selphie", "886686682484", "{Irvine,Zell,Selphie=>19, Irvine,Zell,Quistis=>4, Selphie,Irvine,Quistis=>9}", "Irvine,Zell,Quistis"),

            new PartyFormation(3795, 74, "424ab704", "Zell,Squall,Irvine", "866866824844", "{Irvine,Zell,Selphie=>18, Irvine,Zell,Quistis=>3, Selphie,Irvine,Quistis=>8}", "Irvine,Zell,Quistis"),

            new PartyFormation(3796, 171, "8eab54ed", "Selphie,Squall,Quistis", "668668248446", "{Irvine,Zell,Selphie=>17, Irvine,Zell,Quistis=>2, Selphie,Irvine,Quistis=>7}", "Irvine,Zell,Quistis"),

            new PartyFormation(3797, 33, "cf218f22", "Selphie,Squall,Quistis", "686682484462", "{Irvine,Zell,Selphie=>16, Irvine,Zell,Quistis=>1, Selphie,Irvine,Quistis=>6}", "Irvine,Zell,Quistis"),

            new PartyFormation(3798, 50, "c1327db3", "Irvine,Zell,Quistis", "866824844624", "{Irvine,Zell,Selphie=>15, Irvine,Zell,Quistis=>0, Selphie,Irvine,Quistis=>5}", "Irvine,Zell,Quistis"),

            new PartyFormation(3799, 62, "503e3f70", "Selphie,Rinoa,Quistis", "668248446244", "{Irvine,Zell,Selphie=>14, Irvine,Zell,Quistis=>28, Selphie,Irvine,Quistis=>4}", "Selphie,Irvine,Quistis")
        };

        #endregion
    }
}
