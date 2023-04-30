using app.Cards;

namespace app.Players
{
    public static class Dealer
    {
        public static List<Card> hand = new List<Card>();
        public static void Hit()
        {
            hand.Add(Game.deck.Draw());
            Console.WriteLine($"The Dealer hit and drew a {hand.Last().ToString()} -- > Sum of their hand is {hand.Sum()}");
            Console.WriteLine("Their hand: ");
            Dealer.hand.List();
            hand.CheckSum("Dealer");
        }

        public static void Play()
        {
            while(hand.Sum() < 17)
            {
                Dealer.Hit();
            }
            if(hand.Sum() >= 17 && hand.Sum() < 21)
            {
                if(hand.Sum() < Player.hand.Sum())
                {
                    Console.WriteLine($"You won!");
                }
                else if(hand.Sum() > Player.hand.Sum())
                {
                    Console.WriteLine("You Lost!");
                }
                Console.WriteLine($"The Dealer had a sum of {hand.Sum()} and you had a sum of {Player.hand.Sum()}");
                Game.InRound = false;
                Game.isOver = true;
                Console.WriteLine("Type 'next' to start the next round");
            }
        }
    }
}