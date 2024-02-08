using System.Media;

namespace Sokoban
{
    internal class SoundController : ISoundController
    {
        public bool Enabled { get; private set; }
        
        private SoundPlayer sound;

        public SoundController(bool isEnabled)
        {
            Enabled = isEnabled;
            sound = new SoundPlayer();
        }

        public void PlaySound(SoundType type)
        {
            if (Enabled)
            {
                LoadSound(type);
                sound.Play();
            }
        }

        private void LoadSound(SoundType type)
        {
            switch (type)
            {
                case SoundType.Move:
                    sound = new SoundPlayer(Properties.Resources.move);
                    break;

                case SoundType.Undo:
                    sound = new SoundPlayer(Properties.Resources.undo);
                    break;

                case SoundType.LevelVictory:
                    sound = new SoundPlayer(Properties.Resources.levelVictory);
                    break;

                case SoundType.GameVictory:
                    sound = new SoundPlayer(Properties.Resources.gameVictory);
                    break;
            }
            sound.Load();
        }
    }
}