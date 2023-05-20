using PlayerComponents;
using UnityEngine;

namespace NpcComponents
{
    public class NpcControllerShopController : NpcControllerBase
    {
        public override void Interact(InteractionController interactionController)
        {
            Debug.Log("Open Shop");
        }
    }
}
