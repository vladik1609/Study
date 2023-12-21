using System.Drawing;

namespace Sokoban
{
    public interface ISokobanGame
    {
        string PlayerName { get; }
        int CurrentLevel { get; }
        int LevelsCount { get; }
        Size LevelSize { get; }
        Image LevelImage { get; }
        int MovesCount { get; }
        int PushesCount { get; }

        void RestartLevel();
        void StartNewGame();
        bool StartNextLevel();
        void MovePlayer(MoveDirection direction);
        void Undo();
        bool CheckVictory();
        void SaveGame();
        int GetCompletedLevelsCount();
    }
}