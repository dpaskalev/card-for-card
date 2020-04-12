using System;
using System.Collections.Generic;
using System.Text;

namespace CardForCard
{
    public class Deck : IColection
    {
        public Deck()
        {

        }

        public void FillCards(IColection playerDeck, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (Cards.Count > 0)
                {
                    playerDeck.AddToCards(Cards[0]);
                    Cards.RemoveAt(0);
                }
            }
        }

        public void GenerateCards()
        {
            var cardTypes = new string[]
                { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            foreach (var type in cardTypes)
            {
                Cards.Add(new Card(type));
                Cards.Add(new Card(type));
                Cards.Add(new Card(type));
                Cards.Add(new Card(type));
            }
        }

        public void ShuffleDeck()
        {
            for (int i = 0; i < Cards.Count; i++)
            {
                SwapCards(
                    Utilites.GetRandomNum(0, Cards.Count),
                    Utilites.GetRandomNum(0, Cards.Count));
            }
        }

        private void SwapCards(int firstIndex, int secondIndex)
        {
            Card holder = Cards[firstIndex];
            Cards[firstIndex] = Cards[secondIndex];
            Cards[secondIndex] = holder;
        }
    }
}
