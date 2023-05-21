using PlayerComponents;
using UnityEngine;

namespace NpcComponents
{
    public class NpcControllerBase : MonoBehaviour
    {
        public bool interacting;
        public virtual void Interact(InteractionController interactionController)
        {
        
        }
    }
}
