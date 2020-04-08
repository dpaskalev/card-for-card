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
    }

    public enum CardColor
    {
        Clubs,
        Spades,
        Hearts,
        Diamonds
    }
}
