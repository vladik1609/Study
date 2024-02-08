using System.Collections;
using System.IO;

namespace Sokoban
{
    // Класс для управления уровнями
    internal class LevelController
    {
        private ArrayList levels = new ArrayList();

        public int LevelsCount
        {
            get { return levels.Count; }
        }

        public Level this[int index]
        {
            get { return (Level)levels[index]; }
        }

        public void LoadLevels(string directoryPath)
        {
            int levelNumber = 1;

            string[] levelsFile = Directory.GetFiles(directoryPath, "Level*.lvl");

            foreach (var filePath in levelsFile)
            {
                string[] rowsArray = File.ReadAllLines(filePath);
                LoadLevel(rowsArray, levelNumber);
                levelNumber++;
            }
        }

        private void LoadLevel(string[] levelInfo, int levelNumber)
        {
            int levelWidth = levelInfo[0].Length;
            int levelHeight = levelInfo.Length;
            int countGoals = 0;

            for (int i = 0; i < levelHeight; i++)
            {
                if (levelInfo[i].Length > levelWidth)
                {
                    levelWidth = levelInfo[i].Length;
                }
            }

            ItemType[,] levelMap = new ItemType[levelWidth, levelHeight];

            for (int i = 0; i < levelHeight; i++)
            {
                string line = levelInfo[i];

                for (int j = 0; j < levelWidth; j++)
                {
                    if (j >= line.Length)
                    {
                        levelMap[j, i] = ItemType.Space;
                    }
                    else
                    {
                        switch (line[j].ToString())
                        {
                            case " ":
                                levelMap[j, i] = ItemType.Floor;
                                break;
                            case "#":
                                levelMap[j, i] = ItemType.Wall;
                                break;
                            case "$":
                                levelMap[j, i] = ItemType.Box;
                                break;
                            case ".":
                                levelMap[j, i] = ItemType.Goal;
                                countGoals++;
                                break;
                            case "@":
                                levelMap[j, i] = ItemType.Player;
                                break;
                            case "*":
                                levelMap[j, i] = ItemType.BoxOnGoal;
                                countGoals++;
                                break;
                            case "+":
                                levelMap[j, i] = ItemType.PlayerOnGoal;
                                countGoals++;
                                break;
                            case "!":
                                levelMap[j, i] = ItemType.Space;
                                break;
                        }
                    }
                }
            }
            levels.Add(new Level(levelMap, levelWidth, levelHeight, countGoals, levelNumber));
        }
    }
}