using System;
using System.Collections.Generic;
using System.Text;

namespace CardForCard
{
    public class Engine
    {
        private readonly Deck deck = new Deck();
        private readonly Deck ground = new Deck();
        private readonly Player player = new Player("Player");
        private readonly Player bot = new Player("Bot");

        public Engine()
        {
            deck.GenerateCards();
            deck.ShuffleDeck();
        }

        public void GameLoop()
        {
            deck.FillCards(ground, 4);

            do
            {
                if (deck.Cards.Count > 12 && player.Cards.Count == 0)
                {
                    deck.FillCards(player, 9);
                    deck.FillCards(bot, 9);
                }
                else if (player.Cards.Count == 0)
                {
                    deck.FillCards(player, 6);
                    deck.FillCards(bot, 6);
                }

                while (player.Cards.Count > 0)
                {
                    player.PlayRound(ground);
                    bot.PlayRound(ground, bot);
                }

            } while (deck.Cards.Count > 0);

            Utilites.PrintPoints(player);
            Utilites.PrintPoints(bot);
            Utilites.DetermenWinner(player, bot);
        }
    }
}
