using NpcComponents;
using UnityEngine;

namespace PlayerComponents
{
    public class InteractionController : MonoBehaviour
    {
        [SerializeField] private string[] _layers;
        private LayerMask _layerMask;
        private Vector2 _aimAxis;

        private void Awake()
        {
            _layerMask = LayerMask.GetMask(_layers);
        }

        public void ChangeAimAxis(Vector2 aimAxis)
        {
            _aimAxis = aimAxis;
        }
    
        public void Interact()
        {
            var raycastHits = Physics2D.RaycastAll(transform.position, _aimAxis, 1f, _layerMask);
        
            if (raycastHits.Length == 0) return;

            if (raycastHits[0].transform.CompareTag("NPC"))
            {
                raycastHits[0].transform.GetComponent<NpcControllerBase>().Interact(this);
            }
        }

        private void OnDrawGizmos()
        {
            Debug.DrawRay(transform.position, _aimAxis, Color.red);
        }
    }
}
