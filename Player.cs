using app.Cards;

namespace app.Players
{
    public static class Player
    {
        public static List<Card> hand = new List<Card>();
        public static void Hit()
        {
            hand.Add(Game.deck.Draw());
            Console.WriteLine($"You hit and drew a {hand.Last().ToString()}!");
            hand.CheckSum("Player");
        }
    }
}