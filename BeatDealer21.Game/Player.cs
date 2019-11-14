using BeatDealer21.Game.Infrastructrue;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeatDealer21.Game
{
    public class Player
    {
        public Player()
        {
            Id = Guid.NewGuid();
            Score = 0;
            Cards = new Queue<Card>();
        }

        public void ClearData()
        {
            Score = 0;
            Cards.Clear();
        }

        public bool IsBlackJack()
        {
            return Score == 21;
        }

        public void AddCard(Card card)
        {
            Cards.Enqueue(card);
            Score = GetTotalScore();
        }

        private int GetTotalScore()
        {
            Score = Cards.Sum(s => s.GetRank());

            return Score;
        }

        public List<Card> GetPlayersCard()
        {
            return Cards.ToList();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Score { get; private set; }

        private Queue<Card> Cards { get; }
    }
}
