using System.Collections.Generic;

namespace CardForCard
{
    public class Deck
    {
        public IList<Card> Cards { get; private set; } = new List<Card>();

        public Deck()
        {
            GenerateCards();
            ShuffleDeck();
        }

        public void FillCards(Player playerDeck, int count)
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

        private void GenerateCards()
        {
            var cardTypes = new string[]
                { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            foreach (var type in cardTypes)
            {
                Cards.Add(new Card(type, CardColor.Clubs));
                Cards.Add(new Card(type, CardColor.Diamonds));
                Cards.Add(new Card(type, CardColor.Hearts));
                Cards.Add(new Card(type, CardColor.Spades));
            }
        }

        private void ShuffleDeck()
        {
            for (int i = 0; i < 100; i++)
            {
                SwapCards(
                    Utilities.GetRandomNum(0, Cards.Count),
                    Utilities.GetRandomNum(0, Cards.Count));
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
