using System;
using System.Collections.Generic;
using System.Linq;

namespace BeatDealer21.Game
{
    public class TwoPlayerBlackJackGame
    {
        private readonly Player _playerOne;
        private readonly Random _randomGenerator;
        private List<Card> _cardDeck;

        public virtual Player DealerPlayer { get; }

        public TwoPlayerBlackJackGame(Player playerOne)
        {
            _playerOne = playerOne;
            DealerPlayer = new Player
            {
                Name = "Dealer"
            };
            _randomGenerator = new Random();
            _cardDeck = new List<Card>();
        }

        public virtual void StartGame()
        {
            _playerOne.ClearData();
            DealerPlayer.ClearData();

            Console.WriteLine("Welcome to the 'Beat the Dealer at 21' game.");
            Console.WriteLine("Shuffling card deck.");

            AddCardAndShuffleDeck();

            _playerOne.AddCard(GetNextRandomCard());
            _playerOne.AddCard(GetNextRandomCard());

            DealerPlayer.AddCard(GetNextRandomCard());
            DealerPlayer.AddCard(GetNextRandomCard());

            if (!IsAnyPlayerHasBalckJack())
            {
                while (_playerOne.Score < 17)
                    _playerOne.AddCard(GetNextRandomCard());

                if(_playerOne.Score > 21)
                {
                    Console.WriteLine($"{_playerOne.Name} score is {_playerOne.Score} which exceeded 21 and he lost the game");
                }
                else
                {
                    while (DealerPlayer.Score <= _playerOne.Score)
                        DealerPlayer.AddCard(GetNextRandomCard());

                    if (DealerPlayer.Score > 21)
                    {
                        Console.WriteLine($"{DealerPlayer.Name} score {DealerPlayer.Score} which exceeded 21 and he lost the game");
                    }
                    else
                    {
                        Console.WriteLine($"{DealerPlayer.Name} score is {DealerPlayer.Score} and {_playerOne.Name} score is {_playerOne.Score} and neither won the game.");
                    }
                }
            }
        }

        private void AddCardAndShuffleDeck()
        {
            _cardDeck.Add(Card.One);
            _cardDeck.Add(Card.Two);
            _cardDeck.Add(Card.Three);
            _cardDeck.Add(Card.Four);
            _cardDeck.Add(Card.Five);
            _cardDeck.Add(Card.Six);
            _cardDeck.Add(Card.Seven);
            _cardDeck.Add(Card.Eight);
            _cardDeck.Add(Card.Nine);
            _cardDeck.Add(Card.Jack);
            _cardDeck.Add(Card.Queen);
            _cardDeck.Add(Card.King);
            _cardDeck.Add(Card.Ace);

            _cardDeck = _cardDeck.Randomnize();
        }

        private Card GetNextRandomCard()
        {
            var randomNumber = _randomGenerator.Next(0, _cardDeck.Count);
            var cardToReturn = _cardDeck[randomNumber];

            // Remove card from the deck so we donot use it next time in the same game.
            _cardDeck.Remove(cardToReturn);

            return cardToReturn;
        }

        private bool IsAnyPlayerHasBalckJack()
        {
            bool isBlackJacked = false;
            if (_playerOne.IsBlackJack())
            {
                Console.WriteLine($"{_playerOne.Name} has blackjack and wins the game.");
                isBlackJacked = true;
            }
            else if (DealerPlayer.IsBlackJack())
            {
                Console.WriteLine($"{DealerPlayer.Name} has blackjack and wins the game.");
                isBlackJacked = true;
            }

            return isBlackJacked;
        }
    }
}
