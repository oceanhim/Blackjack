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
            while(running)
            {
                var command = Console.ReadLine();
                switch (command) 
                {
                    case "help":
                        Console.WriteLine(@"List of Commands:
                        --> exit: Exits the program
                        --> hand: Displays your hand
                        --> dealer: Shows the Dealer's first card
                        --> hit: If currently in the middle of a round, you will draw a card
                        --> sum: Displays sum of your hand"
                        );
                        break;
                    case "exit":
                        running = false;
                        break;
                    case "hand":
                        Player.hand.List();
                        break;
                    case "dealer":
                        Dealer.hand[0].ToString();
                        break;
                    case "hit":
                        if(Game.InRound)
                        {
                            Player.Hit();
                        }
                        else Console.WriteLine("Cannot 'hit' at this time.");
                        break;
                    case "sum":
                        Console.WriteLine($"Sum of your hand: {Player.hand.Sum()}");
                        break;
                    case "stand":
                        if(Game.InRound)
                        {
                            Console.WriteLine($"You stood with a total of {Player.hand.Sum()}\nNow it's the Dealers turn.");
                            Dealer.Play();
                        }
                        else Console.WriteLine("You cannot stand at this time.");
                        break;
                    case "next":
                        if(Game.isOver)
                        {
                            Game.Initiate();
                        }
                        else Console.WriteLine("You cannot skip the round, play it out then you may move onto the next one.");
                        break;
                    default:
                        Console.WriteLine($"'{command}' is not a command.");
                        break;
                }
            }
        }
    }
}