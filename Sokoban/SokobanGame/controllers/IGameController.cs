namespace Sokoban
{
    internal interface IGameController
    {
        void MovePlayer(MoveDirection direction);
        void Undo();
        bool CheckVictory();
    }
}