namespace Sokoban
{
    internal class LevelItem
    {
        private readonly ItemType itemType;
        private readonly int xPos;
        private readonly int yPos;

        public LevelItem(ItemType itemType, int xPos, int yPos)
        {
            this.itemType = itemType;
            this.xPos = xPos;
            this.yPos = yPos;
        }

        public ItemType ItemType
        {
            get { return itemType; }
        }

        public int XPos
        {
            get { return xPos; }
        }

        public int YPos
        {
            get { return yPos; }
        }
    }
}