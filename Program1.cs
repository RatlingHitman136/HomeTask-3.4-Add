using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace WarWarAndWar
{
    class Program
    {
        public static Queue<int> Player1;
        public static Queue<int> Player2;
        public static Queue<int> ToAddFrom1,ToAddFrom2;
        public static int NumOfRounds = 0;
        public static bool isPat = false, isEnd = false;

        static void Main(string[] args)
        {
            
            Player1 = new Queue<int>();
            Player2 = new Queue<int>();
            int n = int.Parse(Console.ReadLine()); 
            for (int i = 0; i < n; i++)
            {
                string cardp1 = Console.ReadLine();
                Player1.Enqueue(GetNumOfCard(cardp1));
            }
            int m = int.Parse(Console.ReadLine()); 
            for (int i = 0; i < m; i++)
            {
                string cardp2 = Console.ReadLine();
                Player2.Enqueue(GetNumOfCard(cardp2));
            }

            while(!isEnd)
            {
                Round();
            }
            /*Console.WriteLine("END");
            for (int i = 0; i < Player1.Count; i++)
            {
                Console.Write(" {0} ", Player1.ToArray()[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < Player2.Count; i++)
            {
                Console.Write(" {0} ", Player2.ToArray()[i]);
            }
            //Console.WriteLine("PAT");*/
            Console.ReadKey();
        }

        static int Battle()
        {
            int card1 = Player1.Dequeue();
            int card2 = Player2.Dequeue();
            ToAddFrom1.Enqueue(card1);
            ToAddFrom2.Enqueue(card2);
            if (card1 > card2)
            {         
                return 1;
            }
            else if (card1 < card2)
            {
                return 2;
            }
            else// card1 = card2
            {
                return War();
            }
        }
        static int War()
        {
            if(Player1.Count <3 || Player2.Count<3)
            {
                isPat = true;
                return 0;
            }
            ToAddFrom1.Enqueue(Player1.Dequeue());
            ToAddFrom1.Enqueue(Player1.Dequeue());
            ToAddFrom1.Enqueue(Player1.Dequeue());
            ToAddFrom2.Enqueue(Player2.Dequeue());
            ToAddFrom2.Enqueue(Player2.Dequeue());
            ToAddFrom2.Enqueue(Player2.Dequeue());
            return Battle();
        }

        static void Round()
        {
            NumOfRounds++;
            ToAddFrom1 = new Queue<int>();
            ToAddFrom2 = new Queue<int>();
            int roundWinner = Battle();
            if(roundWinner==0)
            {
                isEnd = true;
                Console.WriteLine("PAT");
            }
            if (roundWinner == 1)
            {
                while (ToAddFrom1.Count > 0)
                    Player1.Enqueue(ToAddFrom1.Dequeue());
                while (ToAddFrom2.Count > 0)
                    Player1.Enqueue(ToAddFrom2.Dequeue());
            }
            else if(roundWinner == 2)
            {
                while (ToAddFrom1.Count > 0)
                    Player2.Enqueue(ToAddFrom1.Dequeue());
                while (ToAddFrom2.Count > 0)
                    Player2.Enqueue(ToAddFrom2.Dequeue());
            }
            if(Player1.Count == 0 || Player2.Count == 0)
            {
                isEnd = true;
                Console.WriteLine("{0} {1}", roundWinner, NumOfRounds);
            }    
        }

        static int GetNumOfCard(string card)
        {
            card = card.Substring(0,card.Length-1);
            switch (card)
            {
                case "2":
                    return 2;
                case "3":
                    return 3;
                case "4":
                    return 4;
                case "5":
                    return 5;
                case "6":
                    return 6;
                case "7":
                    return 7;
                case "8":
                    return 8;
                case "9":
                    return 9;
                case "10":
                    return 10;
                case "J":
                    return 11;
                case "Q":
                    return 12;
                case "K":
                    return 13;
                case "A":
                    return 14;
            }
            return 0;
        }
    }
}
