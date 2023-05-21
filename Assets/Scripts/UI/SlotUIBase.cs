using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SlotUIBase : MonoBehaviour
    {
        public Image image;
        public int slotIndex;

        public void SetSlotIndex(int index) => slotIndex = index;
    
        public void UpdateUIContent(Sprite icon, Color iconColor)
        {
            SetIcon(icon);
            SetIconColor(iconColor);
        }
    
        public void SetIcon(Sprite icon) => image.sprite = icon;
        public void SetIconColor(Color color) => image.color = color;

        public virtual void OnClick()
        {
        
        }
    }
}
