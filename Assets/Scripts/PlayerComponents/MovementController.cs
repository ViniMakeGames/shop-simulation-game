using UnityEngine;

namespace PlayerComponents
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;

        public void Move(Vector2 axis)
        {
            transform.Translate(axis * (_moveSpeed * Time.deltaTime));
        }
    }
}
