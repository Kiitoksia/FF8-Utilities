namespace ff8_card_manip
{
    public class Card
    {
        public int Id { get; set; }
        public int[] Urdl { get; set; }
        public string Urdl_s { get; set; }
        public int Level { get; set; }
        public int Row { get; set; }
        public string Name { get; set; }
        public TElement Element { get; set; }
        public bool Rare { get; set; }

        public enum TElement
        {
            None,
            Fire,
            Ice,
            Thunder,
            Water,
            Earth,
            Wind,
            Poison,
            Holy,
        }
    }
}
