using System;

namespace CardForCard
{
    public static class Utilites
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

        public static void PrintPoints(Player colection)
        {
            Console.WriteLine($"{colection.Name} points: {colection.Points}");
        }

        public static void PrintCards(IColection player)
        {
            foreach (var card in player.Cards)
            {
                Console.Write($"{card.Type} ");
            }
            Console.WriteLine();
        }

        public static void DetermenWinner(Player player, Player bot)
        {
            if (player.Points > bot.Points)
            {
                PrintMessage("You win!");
            }
            else if (player.Points < bot.Points)
            {
                PrintMessage("You lose!");
            }
            else
            {
                PrintMessage("No winner!");
            }
        }
    }
}
