namespace Sokoban
{
    internal interface ISaveManager
    {
        void NewGame();
        void AddWinLevel(string levelNumber, string movesCount, string pushesCount);
        void SaveGame(string levelNumber, string movesCount, string pushesCount);
        int GetCompletedLevelsCount();
    }
}