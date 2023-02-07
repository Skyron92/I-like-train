using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
        [Header("Player settings")]
        [Tooltip("Vitesse de déplacement.")] [Range(1, 10)] [SerializeField] private float _speed;
        [Tooltip("Gravity multiplier.")] [Range(1, 10)] [SerializeField] private float Weight;
        private CharacterController _controller;
        private float gravityValue = -9.81f;
        private Vector3 playerVelocity;
        private Vector3 _input;
        [Header("Camera settings")]
        [Tooltip("Sensibilité de la souris.")]
        [Range(0.1f, 9f)] [SerializeField] private float YCameraSensitivity = 2f;
        [Range(0.1f, 9f)] [SerializeField] private float XCameraSensitivity = 0.5f;
        [Tooltip("Limite de la rotation verticale de la caméra. Ne peut pas dépasser 90.")]
        [Range(0f, 360f)] [SerializeField] float yRotationLimit = 88f;
        Vector2 rotation = Vector2.zero;
        [SerializeField] private Texture2D cursorSprite;
        public static float timeSpeed = 1;
    
        private void Awake() {
            _controller = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
            Cursor.SetCursor(cursorSprite, new Vector2(Screen.width/2, Screen.height/2), CursorMode.ForceSoftware);
        }
    
        void Update() {
            Walk();
            RotateCamera();
        }
    
        void Walk() {
            playerVelocity.y += gravityValue * Weight * Time.deltaTime;
            _controller.Move(playerVelocity * _speed * Time.deltaTime * timeSpeed);
        }

        public void ReadWalk(InputAction.CallbackContext context) {
            _input = context.ReadValue<Vector2>();
            playerVelocity = new Vector3(_input.x, 0, _input.y);
        }
    
    
        void RotateCamera() {
            var xQuat = Quaternion.AngleAxis(rotation.x * XCameraSensitivity * timeSpeed, Vector3.up);
            var yQuat = Quaternion.AngleAxis(rotation.y * YCameraSensitivity * timeSpeed, Vector3.left);
            transform.localRotation = xQuat * yQuat;
        }

        public void ReadCamera(InputAction.CallbackContext context) {
            rotation = context.ReadValue<Vector2>();
            rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
            rotation.x = Mathf.Clamp(rotation.x, -90, 85);
        }
        
        

}
