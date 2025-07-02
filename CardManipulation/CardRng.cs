namespace ff8_card_manip
{
    public class CardRng
    {
        public uint State { get; private set; }

        public CardRng(uint seed = 0x0000_0001)
        {
            State = seed;
        }

        public uint Next()
        {
            State = (State * 0x10dcd + 1) & 0xffff_ffff;
            return State >> 17;
        }
    }
}
