using app.Cards;

namespace app.Players
{
    public static class Dealer
    {
        public static List<Card> hand = new List<Card>();
        public static void Hit()
        {
            hand.Add(Game.deck.Draw(1).First());
        }
    }
}