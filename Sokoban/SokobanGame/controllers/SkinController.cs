using System.Collections.Generic;
using System.Drawing;
using Sokoban.Properties;

namespace Sokoban
{
    internal class SkinController : ISkinController
    {
        private readonly Dictionary<int, SkinSet> skinSets;

        public SkinController()
        {
            skinSets = new Dictionary<int, SkinSet>
            {
                { 0, new SkinSet(Resources.wall_0, Resources.floor_0, Resources.box_0, Resources.goal_0, Resources.box_goal_0, Resources.player_0, Resources.player_goal_0, Resources.space) },
                { 1, new SkinSet(Resources.wall_1, Resources.floor_1, Resources.box_1, Resources.goal_1, Resources.box_goal_1, Resources.player_1, Resources.player_goal_1, Resources.space) },
                { 2, new SkinSet(Resources.wall_2, Resources.floor_2, Resources.box_2, Resources.goal_2, Resources.box_goal_2, Resources.player_2, Resources.player_goal_2, Resources.space) },
            };
        }

        public Image GetItemImage(ItemType itemType, int skinId)
        {
            if (skinSets.TryGetValue(skinId, out var skinSet))
            {
                return skinSet.GetSkinImage(itemType);
            }

            return null;
        }

        private class SkinSet
        {
            public Image Wall { get; }
            public Image Floor { get; }
            public Image Box { get; }
            public Image Goal { get; }
            public Image BoxOnGoal { get; }
            public Image Player { get; }
            public Image PlayerOnGoal { get; }
            public Image Space { get; }

            public SkinSet(Image wall, Image floor, Image box, Image goal, Image boxOnGoal, Image player, Image playerOnGoal, Image space)
            {
                Wall = wall;
                Floor = floor;
                Box = box;
                Goal = goal;
                BoxOnGoal = boxOnGoal;
                Player = player;
                PlayerOnGoal = playerOnGoal;
                Space = space;
            }

            internal Image GetSkinImage(ItemType itemType)
            {
                switch (itemType)
                {
                    case ItemType.Wall:
                        return Wall;
                    case ItemType.Floor:
                        return Floor;
                    case ItemType.Box:
                        return Box;
                    case ItemType.Goal:
                        return Goal;
                    case ItemType.BoxOnGoal:
                        return BoxOnGoal;
                    case ItemType.Player:
                        return Player;
                    case ItemType.PlayerOnGoal:
                        return PlayerOnGoal;
                    case ItemType.Space:
                        return Space;
                    default:
                        return null;
                }
            }
        }
    }
}