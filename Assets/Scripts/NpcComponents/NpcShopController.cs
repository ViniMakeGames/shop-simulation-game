using PlayerComponents;
using UnityEngine;

namespace NpcComponents
{
    public class NpcShopController : NpcControllerBase
    {
        public override void Interact(InteractionController interactionController)
        {
            Debug.Log("Open Shop");
        }
    }
}
