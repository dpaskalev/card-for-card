using System;
using System.Collections.Generic;

namespace CardForCard
{
    public class Engine
    {
        private readonly Deck deck = new Deck();
        private readonly Player player = new Player("Player");
        private readonly Player bot = new Player("Bot");
        private readonly Player ground = new Player("Ground");

        public Engine()
        {

        }

        public void GameLoop()
        {
            deck.FillCards(ground, 4);
            
            do
            {
                if (player.Cards.Count == 0)
                {
                    deck.FillCards(player, 9);
                    deck.FillCards(bot, 9);
                }

                player.PlayRound(ground);
                bot.PlayAuthomaticRound(ground);

            } while (deck.Cards.Count > 0);


        }
    }
}
