using System;
using System.Collections.Generic;


namespace CardForCard
{
    public class Player
    {
        public IList<Card> Cards { get; } = new List<Card>();
        public int Points { get; private set; } = 0;
        public string Name { get; private set; }
        private string card;

        public Player(string name)
        {
            Name = name;
        }

        public void AddPoints(int points)
        {
            Points += points;
        }

        public void AddToCards(Card card)
        {
            Cards.Add(card);
        }

        public void AddToCards(IList<Card> cards)
        {
            foreach (var card in cards)
            {
                Cards.Add(card);
            }
        }

        public int GetIndexOf(string cardType)
        {
            int result = -1;
            for (int i = 0; i < Cards.Count; i++)
            {
                if (Cards[i].Type == cardType.ToUpper())
                {
                    result = i;
                }
            }
            return result;
        }

        public bool GetIfContainsCardType(string cardType)
        {
            bool result = false;
            foreach (Card card in Cards)
            {
                if (card.Type == cardType.ToUpper())
                {
                    result = true;
                }
            }
            return result;
        }

        public void RemoveCardAt(int index)
        {
            Cards.RemoveAt(index);
        }

        public void PlayRound(Player ground)
        {
            while (true)
            {
                card = Console.ReadLine();
                if (GetIfContainsCardType(card))
                {
                    Cards.RemoveAt(GetIndexOf(card));
                    Points += 2;
                    if (ground.GetIfContainsCardType(card))
                    {
                        ground.RemoveCardAt(GetIndexOf(card));
                    }
                    else
                    {
                        ground.AddToCards(Cards[GetIndexOf(card)]);
                    }
                    break;
                }
                else
                {
                    Utilities.PrintMessage("You don't have this card!");
                }
            }
        }

        public void PlayAuthomaticRound(Player ground)
        {
            foreach (Card card in Cards)
            {
                if (ground.GetIfContainsCardType(card.Type))
                {
                    ground.RemoveCardAt(GetIndexOf(card.Type));
                    Cards.Remove(card);
                    Points += 2;
                    break;
                }
                else
                {
                    Cards.Remove(card);
                    ground.AddToCards(card);
                }
            }
        }
    }
}
