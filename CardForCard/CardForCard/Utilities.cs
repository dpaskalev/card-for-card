using System;
using System.Collections.Generic;
using System.Text;

namespace CardForCard
{
    public static class Utilities
    {
        public static int GetRandomNum(int bottom, int top)
        {
            Random r = new Random();
            return r.Next(bottom, top);
        }

        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void PrintPoints(string name, int points)
        {
            Console.WriteLine($"{name} points: {points}");
        }
        
        public static void PrintCards(Player player)
        {
            foreach (var card in player.Cards)
            {
                Console.Write($"{card.Type} ");
            }
            Console.WriteLine();
        }
    }
}
