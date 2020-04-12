using System;
using System.Collections.Generic;
using System.Text;

namespace CardForCard
{
    public class Player : IColection
    {
        public int Points { get; private set; } = 0;
        public string Name { get; private set; }

        public Player(string name)
        {
            Name = name;
        }

        public void AddToCards(IList<Card> cards)
        {
            foreach (var card in cards)
            {
                Cards.Add(card);
            }
        }

        public void AddPoints(int points)
        {
            Points += points;
        }

        public void PlayRound(Deck ground)
        {
            Console.Clear();

            Utilites.PrintCards(ground);
            Utilites.PrintCards(this);

            Card card;
            while (true)
            {
                card = new Card(Console.ReadLine().ToUpper());
                if (GetContains(card))
                {
                    RemoveCardAt(GetIndexOf(card, this));
                    break;
                }
                else
                {
                    Utilites.PrintMessage("You don't have this card!");
                }
            }

            if (ground.GetContains(card))
            {
                ground.RemoveCardAt(GetIndexOf(card, ground));
                AddPoints(2);
            }
            else
            {
                ground.AddToCards(card);
            }

            Console.WriteLine();
        }

        public void PlayRound(Deck ground, Player bot)
        {
            for (int i = 0; i < bot.Cards.Count; i++)
            {
                if (ground.GetContains(bot.Cards[i]))
                {
                    ground.RemoveCardAt(GetIndexOf(bot.Cards[i], ground));
                    bot.RemoveCardAt(i);
                    bot.AddPoints(2);
                    return;
                }
            }
            int random = Utilites.GetRandomNum(0, bot.Cards.Count);
            ground.AddToCards(bot.Cards[random]);
            bot.RemoveCardAt(random);
        }

    }
}
