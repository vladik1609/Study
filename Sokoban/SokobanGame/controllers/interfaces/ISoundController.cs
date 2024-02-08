using System.Drawing;

namespace Sokoban
{
    internal interface ISoundController
    {
        bool Enabled { get; }
        void PlaySound(SoundType type);
    }
}