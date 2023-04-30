using app.Cards;
using app.Players;

namespace app
{
    public static class Game
    {
        public static Deck deck = new Deck();
        public static List<List<Card>> hands = new List<List<Card>>();
        public static bool InRound = false;
        public static bool isOver = false;

        public static void Initiate()
        {
            isOver = false;
            InRound = true;
            Console.Clear();
            hands.RemoveRange(0,hands.Count);
            hands.Add(Player.hand);
            hands.Add(Dealer.hand);
            hands[0].RemoveRange(0,hands[0].Count);
            hands[1].RemoveRange(0,hands[1].Count);
            deck.Init();
            deck.Shuffle();
            foreach(List<Card> hand in hands)
            {
                hand.Add(deck.Draw());
                hand.Add(deck.Draw());
            }
            Intro();
        }
        
        private static void Intro()
        {
            Console.WriteLine("Player's Hand: ");
            Player.hand.List();
            Console.WriteLine("Dealer's card: ");
            Console.WriteLine(Dealer.hand[0].ToString());
            InitHit();
        } 

        private static void InitHit()
        {
            InRound = true;
            Console.WriteLine("Hit or Stand?");
        }
    }
}