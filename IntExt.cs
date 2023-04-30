using app.Cards;

namespace app{
    public static class IntExt{
        //this function will return a base 2 representation of an integer
        //for example, the number 2 will return 0000010
        //0-00-1101
        static List<int> indexes(List<int> list)
        {
            List<int> index = new List<int>();

            /*
                This foreach() loop determines which bits need to be turned on.
                It does this by finding the indexes, given {list}
                {list} contains the number that sum up to the given parameter in magic()
                For example, if 25 was passed to magic(), then the corresponding binary value is 11001
                That would mean that 16, 8, and 1 are passed to {list}, as they sum up to 25
                The for() loop determines the indexes for the bits that need to be turned on.
                For example, the indexes for 11001 would be 5, 4, 1. Bits 5, 4, and 1 need to be turned on
            */
            foreach(int num in list)
            {
                int starting = 1;
                int index2 = 0;
                for(int i = 2; starting < num; i++)
                {
                    starting *= 2;
                    index2 = i;
                }
                if(index2 == 0)
                {
                    index2 = 1;
                }
                index.Add(index2);
            }
            return index;
        }
        static int repeated(int num, int starting)
        {
            /* 
                This loop finds the first number in the binary sequence.
                For example, is {num} is 25, then this function will return 16 since
                16 is the biggst bit that can go into 25
            */
            for(int i = 0; starting <= num; i ++)
            {
                starting *= 2;
            }
            return starting / 2;
        }
        public static string magic(this int  num)
        {
            // {lst} will contain all of the values that sum up to {num}

            var lst = new List<int>(){repeated(num,1)};
            
            // This loop populates {lst} with all of the values that sum up to {num}

            do
            {
                lst.Add(repeated(num-lst.Sum(),1));
            }
            while(lst.Last() > 0);
            
            // {list} will contain all of the indexes that indicate which bits to turn on

            List<int> list = indexes(lst);
            list.RemoveAt(list.Count() - 1);
            return convertToBinary(list).PadLeft(32,'0');
        }

        static string convertToBinary(List<int> list)
        {
            // Creating Binary Length

            string sequenceBeta = "";

            for(int i = 0; i < list.First(); i++)
            {
                sequenceBeta += "0 ";
            }

            // Turning Bits On

            string[] splitted = sequenceBeta.Split(" ");
            foreach(int index in list)
            {
                splitted[index-1] = "1";
            }
            string sequence = string.Join("", splitted);

            // Reaversing array because indexes are currently backwards

            char[] charArray = sequence.ToCharArray();
            Array.Reverse(charArray);
            string finaledSequence = new string(charArray);
            return finaledSequence;
        }

        public static void List(this List<Card> hand)
        {
            foreach(Card c in hand)
            {
                Console.WriteLine($"{c.Value} of {c.Suit}");
            }
        }

        public static void CheckSum(this List<Card> hand, string owner)
        {
            if(hand.Sum() > 21)
            {
                Game.InRound = false;
                Game.isOver = true;
                Console.WriteLine($"The {owner} Lost! They went over 21.\nType 'next' to start the next round");
            }
            else if(hand.Sum() == 21)
            {
                Game.InRound = false;
                Game.isOver = true;
                Console.WriteLine($"Blackjack!The {owner} hit 21!\nType 'next' to start the next round");
            }
        }

        public static int Sum(this List<Card> hand)
        {
            int sum = 0;
            foreach(Card c in hand)
            {
                sum += c.Value;
            }
            return sum;
        }
    }
}