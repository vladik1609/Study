using System.Drawing;

namespace Sokoban
{
    // Основной класс, представляющий игру Sokoban
    public class SokobanGame : ISokobanGame, ISokobanRecords
    {
        // Приватные поля для различных контроллеров и настроек
        private IGameController gameController;
        private LevelController levelController;
        private LevelRenderer levelRenderer;
        private LevelStatistics levelStatistics;
        private ISaveController saveController;
        private ISoundController soundController;
        private ISkinController skinController;
        private readonly RegistrySettings registrySettings = new RegistrySettings();
        private ItemType[,] levelMap;

        // Приватные поля, связанные с состоянием игры
        private int blockSize = 60;
        private int currentLevel;
        private bool isLevelFinished = false;

        // Публичные свойства для информации об игре
        public string PlayerName { get; private set; }
        public int LevelsCount { get; private set; }
        public int CurrentLevel
        {
            get { return currentLevel + 1; }
            private set { currentLevel = value; }
        }
        public Size LevelSize { get; private set; }
        public Image LevelImage { get; private set; }
        public int MovesCount { get; private set; }
        public int PushesCount { get; private set; }

        // Конструктор для начала новой игры
        public SokobanGame(string playerName)
        {
            currentLevel = 0;
            levelController = new LevelController();
            levelController.LoadLevels(FilePathsConstants.LEVEL_FILES_DIRECTORY);
            saveController = new SaveController(FilePathsConstants.SAVE_FILES_DIRECTORY, playerName + ".save");
            saveController.NewGame();
            Initialize(playerName);
        }

        // Конструктор для загрузки сохраненной игры
        public SokobanGame(string saveFilePath, string playerName)
        {
            // Создать SaveController с указанным путем к файлу сохранения
            saveController = new SaveController(saveFilePath);       
            // Загрузить текущий уровень из сохраненной игры
            currentLevel = GetCompletedLevelsCount();
            // Инициализировать игру с указанным именем игрока
            Initialize(playerName);   
        }

        // Конструктор для работы с рекордами
        public SokobanGame()
        {
            
        }

        // Приватный метод инициализации, используемый обоими конструкторами
        private void Initialize(string playerName)
        {
            // Если имя игрока равно null или пусто, установить его как "Игрок"
            if (string.IsNullOrEmpty(playerName))
            {
                playerName = "Player";
            }
            PlayerName = playerName;

            // Создать SkinController для обработки логики скина игры
            skinController = new SkinController();
            // Создать LevelController для управления уровнями игры
            levelController = new LevelController();
            // Загрузить уровни игры из указанной директории
            levelController.LoadLevels(FilePathsConstants.LEVEL_FILES_DIRECTORY);

            InitializeGame();
        }

        // Приватный метод для инициализации состояния игры
        private bool InitializeGame()
        {
            // Сбросить флаг завершения уровня
            isLevelFinished = false;

            // Проверить, загружены ли какие-либо уровни
            if (levelController.LevelsCount > 0)
            {
                // Создать LevelRenderer для отображения игрового уровня
                levelRenderer = new LevelRenderer(skinController, blockSize);
                // Получить карту уровня для текущего уровня
                levelMap = levelController[currentLevel].LevelMap;
                // Создать LevelStatistics для отслеживания статистики игры
                levelStatistics = new LevelStatistics();
                // Создать SoundController с указанными настройками звука
                soundController = new SoundController(registrySettings.SoundIsEnabled);
                // Создать GameController для управления игровым процессом
                gameController = new GameController(levelController[currentLevel], levelStatistics);

                // Установить свойства для отображения информации об уровне
                LevelsCount = levelController.LevelsCount;
                LevelSize = new Size(levelController[currentLevel].Width * blockSize, levelController[currentLevel].Height * blockSize);
                LevelImage = levelRenderer.RenderLevel(levelMap, registrySettings.SkinId);
                MovesCount = levelStatistics.MovesCount;
                PushesCount = levelStatistics.PushesCount;

                return true;
            }

            return false;
        }

        public void StartNewGame()
        {
            currentLevel = 0;
            levelController = new LevelController();
            levelController.LoadLevels(FilePathsConstants.LEVEL_FILES_DIRECTORY);
            saveController = new SaveController(FilePathsConstants.SAVE_FILES_DIRECTORY, PlayerName + ".save");
            saveController.NewGame();
            InitializeGame();
        }

        public void RestartLevel()
        {
            levelController = new LevelController();
            levelController.LoadLevels(FilePathsConstants.LEVEL_FILES_DIRECTORY);
            InitializeGame();
        }

        public bool StartNextLevel()
        {
            if (CheckVictory() && CurrentLevel < LevelsCount)
            {
                currentLevel++;
                InitializeGame();
                return true;
            }

            return false;
        }

        public void MovePlayer(MoveDirection direction)
        {
            if (!CheckVictory())
            {
                gameController.MovePlayer(direction);
                MovesCount = levelStatistics.MovesCount;
                PushesCount = levelStatistics.PushesCount;
                LevelImage = levelRenderer.RenderLevel(levelMap, registrySettings.SkinId);
                soundController.PlaySound(SoundType.Move);
            }

            if (gameController.CheckVictory())
            {
                isLevelFinished = true;
                SaveGame();

                if (CurrentLevel < LevelsCount)
                {
                    soundController.PlaySound(SoundType.LevelVictory);
                } 
                else if (CurrentLevel == LevelsCount)
                {
                    soundController.PlaySound(SoundType.GameVictory);
                }
            }
        }

        public void Undo()
        {
            if (!CheckVictory())
            {
                gameController.Undo();
                MovesCount = levelStatistics.MovesCount;
                PushesCount = levelStatistics.PushesCount;
                LevelImage = levelRenderer.RenderLevel(levelMap, registrySettings.SkinId);
                soundController.PlaySound(SoundType.Undo);
            }
        }

        public bool CheckVictory()
        {
            return isLevelFinished;
        }

        public int GetCompletedLevelsCount()
        {
            return saveController.GetCompletedLevelsCount();
        }

        public int GetCompletedLevelsCount(string pathFile)
        {
            saveController = new SaveController(pathFile);
            return saveController.GetCompletedLevelsCount();
        }

        public void SaveGame()
        {
            saveController.SaveGame(CurrentLevel.ToString(), MovesCount.ToString(), PushesCount.ToString());
        }
    }
}