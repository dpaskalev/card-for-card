namespace CardForCard
{
    public class Card
    {
        public string Type { get; set; }
        public CardColor Color { get; set; }

        public Card(string type, CardColor color = CardColor.Clubs)
        {
            Type = type;
            Color = color;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !this.Type.Equals(obj.GetType()))
                return false;

            Card otherCard = (Card) obj;
            return Type == otherCard.Type;
        }
    }

    public enum CardColor
    {
        Clubs,
        Spades,
        Hearts,
        Diamonds
    }
}
