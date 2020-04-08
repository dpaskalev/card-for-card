using System;
using System.Collections.Generic;

namespace CardForCard
{
    public class Engine
    {
        private readonly List<Card> deck;
        private readonly List<Card> player;
        private readonly List<Card> bot;
        private readonly List<Card> ground;
        private int playerPoints;
        private int botPoints;

        public Engine()
        {
            deck = GenerateDeck();
            player = new List<Card>();
            bot = new List<Card>();
            ground = new List<Card>();

            playerPoints = 0;
            botPoints = 0;
        }

        public void GameLoop()
        {
            ShuffleDeck(deck);
            int index = 2;
            for (int i = 0; i < index; i++)
            {
                FillCards(deck, ground, index);
            }

            while (deck.Count > 0)
            {
                index = 3;
                if (player.Count == 0 || bot.Count == 0)
                {
                    for (int i = 0; i < index; i++)
                    {
                        FillCards(deck, player, index);
                        FillCards(deck, bot, index);
                    }
                }
                PlayRound();
            }
            while (player.Count > 0 && bot.Count > 0)
            {
                PlayRound();
            }
            PrintEndGameMessage();
        }
        private void PlayRound()
        {
            Console.Clear();
            PrintCards(ground);
            Console.WriteLine();
            PrintCards(player);
            PrintMessage("");
            string card;
            bool haveError = true;
            while (haveError)
            {
                card = Console.ReadLine();
                foreach (var item in player)
                {
                    if (card.ToUpper() == item.Type)
                    {
                        player.Remove(item);
                        PlayTurn(player, ground, card);
                        haveError = false;
                        break;
                    }
                }
                if (haveError)
                {
                    PrintMessage("You don't have this card!");
                }
            }

            haveError = true;
            foreach (var item in ground)
            {
                foreach (var pice in bot)
                {
                    if (item.Type == pice.Type)
                    {
                        card = pice.Type;
                        bot.Remove(pice);
                        ground.Remove(item);
                        botPoints += 2;
                        haveError = false;
                        break;
                    }
                }
                if (haveError == false)
                {
                    break;
                }
            }
            if (haveError)
            {
                int random = GetRandomNum(0, bot.Count);
                ground.Add(bot[random]);
                bot.RemoveAt(random);
            }
        }

        private void PrintEndGameMessage()
        {
            if (playerPoints > botPoints)
            {
                PrintMessage("You win!");
            }
            else if (playerPoints < botPoints)
            {
                PrintMessage("You lose!");
            }
            else
            {
                PrintMessage("No winner!");
            }
        }

        private void PrintMessage(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine($"Player points: {playerPoints}");
            Console.WriteLine($"Bot points: {botPoints}");
        }

        private void PrintCards(List<Card>deck)
        {
            foreach (var item in deck)
            {
                Console.Write($"{item.Type} ");
            }
            Console.WriteLine();
        }

        private void PlayTurn(List<Card> gamer,List<Card>ground, string card)
        {
            bool haveCard = false;
            foreach (var item in ground)
            {
                if (card.ToUpper() == item.Type)
                {
                    ground.Remove(item);
                    playerPoints += 2;
                    haveCard = true;
                    break;
                }
            }
            if (haveCard == false)
            {
                ground.Add(new Card(card.ToUpper(),CardColor.Clubs));
            }
        }

        private void FillCards(List<Card> masterDeck, List<Card> takerDeck,int index)
        {
            for (int i = 0; i < index; i++)
            {
                if (masterDeck.Count > 0)
                {
                    takerDeck.Add(masterDeck[0]);
                    masterDeck.RemoveAt(0);
                }
            }
        }

        private void ShuffleDeck(List<Card> deck)
        {
            for (int i = 0; i < 100; i++)
            {
                SwapCards(GetRandomNum(0, deck.Count), GetRandomNum(0, deck.Count), deck);
            }
        }

        private void SwapCards(int firstIndex, int secondIndex, List<Card> deck)
        {
            Card holder = deck[firstIndex];
            deck[firstIndex] = deck[secondIndex];
            deck[secondIndex] = holder;
        }

        private List<Card> GenerateDeck()
        {
            var cardDeck = new List<Card>();
            var cardTypes = new string[]
                { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            foreach (var type in cardTypes)
            {
                cardDeck.Add(new Card(type, CardColor.Clubs));
                cardDeck.Add(new Card(type, CardColor.Diamonds));
                cardDeck.Add(new Card(type, CardColor.Hearts));
                cardDeck.Add(new Card(type, CardColor.Spades));
            }

            return cardDeck;
        }

        private int GetRandomNum(int bottom, int top)
        {
            Random r = new Random();
            return r.Next(bottom, top);
        }
    }
}
