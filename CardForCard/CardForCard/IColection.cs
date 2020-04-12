using System;
using System.Collections.Generic;
using System.Text;

namespace CardForCard
{
    public abstract class IColection
    {
        public IList<Card> Cards { get; } = new List<Card>();

        public void AddToCards(Card card)
        {
            Cards.Add(card);
        }

        public bool GetContains(Card otherCard)
        {
            bool result = false;
            foreach (Card card in Cards)
            {
                if (otherCard.Type.ToUpper() == card.Type)
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

        public int GetIndexOf(Card card, IColection colection)
        {
            int result = -1;
            for (int i = 0; i < colection.Cards.Count; i++)
            {
                if (colection.Cards[i].Type == card.Type.ToUpper())
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
    }
}
