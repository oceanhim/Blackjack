using app.Cards;
using System.Linq;

namespace app
{
    public class Deck
    {
        public Card[] _cards = new Card[52];
        public void Init()
        {
            for (int i=0;i<52;i++) {
                var mycard = new Card((Suits)(int)(i/13),(i%13)+1);
                _cards[i] = mycard;
            }
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            _cards = (from c in _cards select new Pair<Card>(rnd.Next(),c)).OrderBy(o => o.prop1).Select(o => o.prop2).ToArray();
        }

        public Card Draw()
        {
            Card[] nonnull = _cards.SkipWhile(c => c == null).ToArray();
            Card drawn = nonnull.First();
            for(int i = 0; i < _cards.Count(); i++)
            {
                if(_cards[i] != null)
                {
                    _cards[i] = null!;
                    i = _cards.Count();
                }                
            }
            return drawn;
        }

        public Deck()
        {
            Init();
        }
    }

    class Pair<T>
    {
        internal int prop1;
        internal T prop2;

        public Pair(int x, T y)
        {
            prop1 = x;
            prop2 = y;
        }
    }
}