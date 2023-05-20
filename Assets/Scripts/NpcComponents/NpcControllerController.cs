using PlayerComponents;
using UnityEngine;

namespace NpcComponents
{
    public class NpcControllerController : NpcControllerBase
    {
        public override void Interact(InteractionController interactionController)
        {
            Debug.Log("Hello!");
        }
    }
}
