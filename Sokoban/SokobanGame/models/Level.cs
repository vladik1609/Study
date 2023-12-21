namespace Sokoban
{
    internal class Level
    {
        public ItemType[,] LevelMap { get; set; }
        public int Width { get; }
        public int Height { get; }
        public int CountGoals { get; }
        public int LevelNumber { get; }

        public Level(ItemType[,] levelMap, int width, int height, int countGoals, int levelNumber)
        {
            LevelMap = levelMap;
            Width = width;
            Height = height;
            CountGoals = countGoals;
            LevelNumber = levelNumber;
        }
    }
}