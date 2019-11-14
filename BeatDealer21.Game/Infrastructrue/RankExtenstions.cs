namespace BeatDealer21.Game.Infrastructrue
{
    public static class RankExtenstions
    {
        public static int GetRank(this Card card)
        {
            if (card >= Card.One && card <= Card.Nine) return (int)card;
            if (card >= Card.Jack && card <= Card.King) return 10;

            return 11;
        }
    }
}
