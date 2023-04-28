using app.Cards;
using app.Players;

namespace app
{
    public static class Game
    {
        public static Deck deck = new Deck();
        public static List<List<Card>> hands = new List<List<Card>>();

        public static void Initiate()
        {
            hands.Add(Player.hand);
            hands.Add(Dealer.hand);
            
            foreach(List<Card> hand in hands)
            {
                hand.Add(deck.Draw(1).First());
                hand.Add(deck.Draw(1).First());
            }
        }
    }
}