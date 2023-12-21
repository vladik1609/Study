namespace Sokoban
{
    internal class LevelStatistics
    {
        public int LevelNumber { get; private set; }
        public int MovesCount { get; private set; }
        public int PushesCount { get; private set; }

        public LevelStatistics()
        {
            LevelNumber = 0;
            MovesCount = 0;
            PushesCount = 0;
        }

        public void RegisterMove()
        {
            MovesCount++;
        }

        public void RegisterPush()
        {
            PushesCount++;
        }

        public void UndoMove(int movesCount)
        {
            MovesCount = movesCount;
        }

        public void UndoPush(int pushesCount)
        {
            PushesCount = pushesCount;
        }

        public void SetLevelNumber(int levelNumber)
        {
            LevelNumber = levelNumber;
        }
    }
}