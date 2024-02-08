namespace Sokoban
{
    internal interface ISaveController
    {
        void NewGame();
        void AddWinLevel(string levelNumber, string movesCount, string pushesCount);
        void SaveGame(string levelNumber, string movesCount, string pushesCount);
        int GetCompletedLevelsCount();
    }
}