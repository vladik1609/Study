using System.Collections.Generic;

namespace Sokoban
{
    internal class GameController : IGameController
    {
        private readonly Level level;
        private LevelItem player;
        private readonly Stack<MoveRecord> moveHistory;
        private readonly LevelStatistics statistics;
        

        public GameController(Level level, LevelStatistics statistics)
        {
            this.level = level;
            moveHistory = new Stack<MoveRecord>();
            InitializePlayerPosition();
            this.statistics = statistics; //Инициализируем статистику уровня
            statistics.SetLevelNumber(level.LevelNumber); //Записываем номер текущего уровня
        }

        public void MovePlayer(MoveDirection direction)
        {
            // Получаем новые координаты для движения игрока
            var (newPlayerX, newPlayerY) = GetNewPlayerCoordinates(player.XPos, player.YPos, direction);
            var targetItem = level.LevelMap[newPlayerX, newPlayerY];
            var behindTargetItem = GetNewPlayerCoordinates(newPlayerX, newPlayerY, direction);

            // Проверяем, что стоит на следующей клетке
            switch (targetItem)
            {
                case ItemType.Floor:
                case ItemType.Goal:
                    // Просто перемещаем игрока
                    MovePlayerTo(newPlayerX, newPlayerY);
                    // Регистрируем перемещение игрока
                    statistics.RegisterMove();
                    break;
                case ItemType.Box:
                case ItemType.BoxOnGoal:
                    // Проверяем, можно ли двигать ящик
                    if (CanMoveBox(behindTargetItem.Item1, behindTargetItem.Item2))
                    {
                        // Сохраняем текущую позицию игрока и ящика для возможного отката
                        var box = new LevelItem(level.LevelMap[newPlayerX, newPlayerY], newPlayerX, newPlayerY);
                        moveHistory.Push(new MoveRecord(player, new LevelItem(targetItem, newPlayerX, newPlayerY), box, 
                            new LevelItem(level.LevelMap[behindTargetItem.Item1, behindTargetItem.Item2], behindTargetItem.Item1, behindTargetItem.Item2),
                            statistics.MovesCount, statistics.PushesCount));
                        // Перемещаем ящик и игрока
                        MoveBox(newPlayerX, newPlayerY, behindTargetItem.Item1, behindTargetItem.Item2);
                        MovePlayerTo(newPlayerX, newPlayerY);

                        // Регистрируем перемещение игрока
                        statistics.RegisterMove();
                        // Регистрируем перемещение ящика
                        statistics.RegisterPush();
                    }
                    break;
            }
        }

        public void Undo()
        {
            if (moveHistory.Count > 0)
            {
                // Берем последнюю запись об изменении и отменяем ее
                var lastMove = moveHistory.Pop();
                MovePlayerTo(lastMove.PlayerStart.XPos, lastMove.PlayerStart.YPos);
                MoveBox(lastMove.BoxEnd.XPos, lastMove.BoxEnd.YPos, lastMove.BoxStart.XPos, lastMove.BoxStart.YPos);
                // Регистрируем отмену хода и толчка
                statistics.UndoMove(lastMove.MovesCount);
                statistics.UndoPush(lastMove.PushesCount);
            }
        }

        public bool CheckVictory()
        {
            int boxesOnGoal = 0;
            for (int x = 0; x < level.Width; x++)
            {
                for (int y = 0; y < level.Height; y++)
                {
                    if (level.LevelMap[x, y] == ItemType.BoxOnGoal)
                    {
                        boxesOnGoal++;
                    }
                }
            }
            return boxesOnGoal == level.CountGoals;
        }

        private void InitializePlayerPosition()
        {
            for (int x = 0; x < level.Width; x++)
            {
                for (int y = 0; y < level.Height; y++)
                {
                    if (level.LevelMap[x, y] == ItemType.Player || level.LevelMap[x, y] == ItemType.PlayerOnGoal)
                    {
                        player = new LevelItem(level.LevelMap[x, y], x, y);
                        return;
                    }
                }
            }
        }

        private void MovePlayerTo(int newPlayerX, int newPlayerY)
        {
            // Если игрок стоит на клетке с целью, то он покидает клетку цели
            if (player.ItemType == ItemType.PlayerOnGoal)
            {
                level.LevelMap[player.XPos, player.YPos] = ItemType.Goal;
            }
            else // Если игрок стоит на обычной клетке пола
            {
                level.LevelMap[player.XPos, player.YPos] = ItemType.Floor;
            }

            // Если игрок перемещается на клетку с целью, меняем тип клетки на PlayerOnGoal
            if (level.LevelMap[newPlayerX, newPlayerY] == ItemType.Goal)
            {
                player = new LevelItem(ItemType.PlayerOnGoal, newPlayerX, newPlayerY);
            }
            else // Игрок перемещается на обычную клетку пола
            {
                player = new LevelItem(ItemType.Player, newPlayerX, newPlayerY);
            }

            level.LevelMap[newPlayerX, newPlayerY] = player.ItemType;
        }

        private bool CanMoveBox(int newBoxX, int newBoxY)
        {
            return level.LevelMap[newBoxX, newBoxY] == ItemType.Floor || level.LevelMap[newBoxX, newBoxY] == ItemType.Goal;
        }

        private void MoveBox(int fromX, int fromY, int toX, int toY)
        {
            // Обновляем типы элементов на карте уровня
            ItemType newItemType = level.LevelMap[toX, toY] == ItemType.Goal ? ItemType.BoxOnGoal : ItemType.Box;
            UpdateLevelItem(fromX, fromY, toX, toY, newItemType, level.LevelMap[fromX, fromY] == ItemType.BoxOnGoal ? ItemType.Goal : ItemType.Floor);
        }

        private void UpdateLevelItem(int fromX, int fromY, int toX, int toY, ItemType newItemType, ItemType oldItemType)
        {
            level.LevelMap[toX, toY] = newItemType;
            level.LevelMap[fromX, fromY] = oldItemType;
        }

        private (int, int) GetNewPlayerCoordinates(int playerX, int playerY, MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Right:
                    playerX++;           
                    break;
                case MoveDirection.Left:
                    playerX--;
                    break;
                case MoveDirection.Up:
                    playerY--;
                    break;
                case MoveDirection.Down:
                    playerY++;
                    break;
            }
            return (playerX, playerY);
        }
    }
}