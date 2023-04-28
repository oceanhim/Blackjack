using app.Cards;
using app.Players;

namespace app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool running = true;
            Game.Initiate();
            Console.WriteLine("Player's Hand: ");
            Player.hand.List();
            Console.WriteLine("Dealer's card: ");
            Console.WriteLine(Dealer.hand[0].Value + " of " + Dealer.hand[0].Suit);
            while(running)
            {
                var command = Console.ReadLine();
                switch (command) 
                {
                    case "exit":
                        running = false;
                        break;
                    default:
                        Console.WriteLine($"'{command}' is not a command.");
                        break;
                }
            }
        }
    }
}