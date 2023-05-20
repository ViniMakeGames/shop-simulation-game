using UnityEngine;

namespace PlayerComponents
{
    public class InputController : MonoBehaviour
    {
        private bool _movementEnabled = true;

        [SerializeField] private string _movementAxisX;
        [SerializeField] private string _movementAxisY;
        [SerializeField] private string _interactionInput;
    
        private MovementController _movement;
        private InteractionController _interaction;

        private Vector2 _inputAxis;

        private void Awake()
        {
            _movement = GetComponent<MovementController>();
            _interaction = GetComponent<InteractionController>();
        }

        private void Update()
        {
            Movement();
            Interaction();
        }

        private void Movement()
        {
            if (!_movementEnabled) return;
            
            _inputAxis = new Vector2(Input.GetAxis(_movementAxisX), Input.GetAxis(_movementAxisY));

            if (_inputAxis.magnitude == 0) return;

            _inputAxis = _inputAxis.magnitude > 1f ? _inputAxis.normalized : _inputAxis;
        
            _movement.Move(_inputAxis);
            _interaction.ChangeAimAxis(_inputAxis);
        }

        private void Interaction()
        {
            if (!Input.GetButtonDown(_interactionInput)) return;
        
            _interaction.Interact();
        }

        public void EnableMovement(bool enable) => _movementEnabled = enable;
    }
}
