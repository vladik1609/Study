namespace Sokoban
{
    internal struct MoveRecord
    {
        public LevelItem PlayerStart;
        public LevelItem PlayerEnd;
        public LevelItem BoxStart;
        public LevelItem BoxEnd;
        public int MovesCount;
        public int PushesCount;

        public MoveRecord(LevelItem playerStart, LevelItem playerEnd, LevelItem boxStart, LevelItem boxEnd, int movesCount, int pushesCount)
        {
            PlayerStart = playerStart;
            PlayerEnd = playerEnd;
            BoxStart = boxStart;
            BoxEnd = boxEnd;
            MovesCount = movesCount;
            PushesCount = pushesCount;
        }
    }
}