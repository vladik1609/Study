using System.Drawing;

namespace Sokoban
{
    internal class LevelRenderer
    {
        private readonly int blockSize;
        private readonly ISkinController skin;

        public LevelRenderer(ISkinController skin, int blockSize)
        {
            this.skin = skin;
            this.blockSize = blockSize;
        }

        public Image RenderLevel(ItemType[,] levelMap, int skinId)
        {
            int width = levelMap.GetLength(0) * blockSize;
            int height = levelMap.GetLength(1) * blockSize;

            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.Transparent);

                for (int i = 0; i < levelMap.GetLength(0); i++)
                {
                    for (int j = 0; j < levelMap.GetLength(1); j++)
                    {
                        ItemType itemType = levelMap[i, j];
                        Image itemImage = skin.GetItemImage(itemType, skinId);
                        DrawCell(graphics, itemImage, i * blockSize, j * blockSize);
                    }
                }
            }
            return bitmap;
        }

        private void DrawCell(Graphics graphics, Image itemImage, int x, int y)
        {
            graphics.DrawImage(itemImage, x, y, blockSize, blockSize);
        }
    }
}