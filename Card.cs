namespace app.Cards
{
    enum Suits{
        Heart=0,
        Diamond=1,
        Club=2,
        Spades=3
    }
    class Card{
        private readonly int _v;
        public Card(Suits s, int number)
        {
            _v = (int)s<<4|number;
            System.Console.WriteLine($"You created {number} of {s} which looks like {_v.magic()}");
        }
        public Suits Suit { get{
            return (Suits)(_v>>4);
        } }
        public int Value { get{
            return ((_v<<28)>>28);
        } }
    }
}