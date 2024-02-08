using System.Drawing;

namespace Sokoban
{
    internal interface ISkinController
    {
        Image GetItemImage(ItemType itemType, int skinId);
    }
}