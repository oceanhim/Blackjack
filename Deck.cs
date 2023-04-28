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

        public Card[] Draw(int amount)
        {
            Card[] nonnull = _cards.SkipWhile(c => c == null).ToArray();
            _cards[0] = null!;
            _cards[1] = null!;
            return nonnull.Take(amount).ToArray();
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