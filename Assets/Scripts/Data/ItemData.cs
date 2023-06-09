using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Database/New Item", fileName = "NewItem")]
    public class ItemData : ScriptableObject
    {
        public int price;
        public Sprite icon;
        public Color color = Color.white;
        public ItemType type;
        public VisualData visual;
    }

    public enum ItemType
    {
        Hat,
        Glasses,
        Top,
        Pants,
        Shoes,
    }
}
