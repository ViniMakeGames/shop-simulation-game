using TMPro.EditorUtilities;
using UI.Inventory;
using UnityEngine;

namespace PlayerComponents
{
    public class InputController : MonoBehaviour
    {
        private bool _movementEnabled = true;
        private bool _interactionEnabled = true;

        [SerializeField] private string _movementAxisX;
        [SerializeField] private string _movementAxisY;
        [SerializeField] private string _interactionInput;
        [SerializeField] private KeyCode _inventoryKey;
        [SerializeField] private KeyCode _pauseKey;
    
        private MovementController _movement;
        private InteractionController _interaction;
        private CharacterVisualController _visualController;
        private InventoryUI _inventoryUI;
        private GameObject _pauseMenu;

        private Vector2 _inputAxis;

        private void Awake()
        {
            _movement = GetComponent<MovementController>();
            _interaction = GetComponent<InteractionController>();
            _visualController = transform.GetChild(0).GetComponent<CharacterVisualController>();
            _pauseMenu = GameObject.Find("Canvas").transform.Find("PauseMenu").gameObject;
            _inventoryUI = GameObject.Find("Canvas").transform.Find("InventoryUI").GetComponent<InventoryUI>();

            _inventoryUI.onCloseInventory.AddListener(() => { EnablePlayer(true); });
        }

        private void Update()
        {
            Movement();
            Interaction();
            Inventory();
            PauseMenu();
        }

        private void Movement()
        {
            if (!_movementEnabled) return;
            
            _inputAxis = new Vector2(Input.GetAxis(_movementAxisX), Input.GetAxis(_movementAxisY));

            if (_inputAxis.magnitude == 0)
            {
                _visualController.SetAnimation(0, false);
                return;
            }

            _visualController.SetAnimation(_inputAxis.magnitude > 0);
            _visualController.SetAnimationDirection(_inputAxis.y > 0 ? 0 : _inputAxis.y < 0 ? 2 : _inputAxis.x > 0 ? 1 : 3);
            _inputAxis = _inputAxis.magnitude > 1f ? _inputAxis.normalized : _inputAxis;
        
            _movement.Move(_inputAxis);
            _interaction.ChangeAimAxis(_inputAxis);
        }

        private void Interaction()
        {
            if (!_interactionEnabled || !Input.GetButtonDown(_interactionInput)) return;
        
            _interaction.Interact();
            _visualController.SetAnimation(0, false);
        }
        
        private void Inventory()
        {
            if (!_interactionEnabled || !Input.GetKeyDown(_inventoryKey)) return;
            
            var inventoryGo = _inventoryUI.gameObject;
            
            inventoryGo.SetActive(!inventoryGo.activeSelf);
            EnablePlayer(!inventoryGo.activeSelf);
        }
        
        private void PauseMenu()
        {
            if (!_interactionEnabled || !Input.GetKeyDown(_pauseKey)) return;

            _pauseMenu.SetActive(!_pauseMenu.activeSelf);
            EnablePlayer(!_pauseMenu.activeSelf);
        }

        public void EnableMovement(bool enable)
        {
            _movementEnabled = enable;
            _visualController.SetAnimation(0, false);
        }

        public void EnableInteraction(bool enable) => _interactionEnabled = enable;

        public void EnablePlayer(bool enable)
        {
            EnableInteraction(enable);
            EnableMovement(enable);
        }
    }
}
