using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
        [Header("Player settings")]
        [Tooltip("Vitesse de déplacement.")] [Range(1, 10)] [SerializeField] private float _speed;
        [Tooltip("Vitesse de déplacement.")] [SerializeField] private float _rotationSpeed;
        [Tooltip("Gravity multiplier.")] [Range(1, 10)] [SerializeField] private float Weight;
        private CharacterController _controller;
        private float gravityValue = -9.81f;
        private Vector3 playerVelocity;
        private Vector3 _input;

        [Header("Camera settings")] [SerializeField]
        private Transform cameraTransform;
        [Tooltip("Sensibilité de la souris.")]
        [Range(0.1f, 9f)] [SerializeField] private float YCameraSensitivity = 2f;
        [Range(0.1f, 9f)] [SerializeField] private float XCameraSensitivity = 0.5f;
        [Tooltip("Limite de la rotation verticale de la caméra. Ne peut pas dépasser 90.")]
        [Range(0f, 360f)] [SerializeField] float yRotationLimit = 88f;
        Vector2 rotation = Vector2.zero;
        public static float timeSpeed = 1;
        private Animator _animator;
    
        private void Awake() {
            _controller = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
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
            playerVelocity = new Vector3(0, 0, _input.y);
            _animator.SetFloat("Vertical", playerVelocity.z);
        }
    
    
        void RotateCamera() {
            rotation.x += Input.GetAxis("Mouse X") * XCameraSensitivity;
            rotation.y += Input.GetAxis("Mouse Y") * YCameraSensitivity;
            rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
            var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
            var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);
            cameraTransform.localRotation = xQuat * yQuat;
        }

        public void ReadCamera(InputAction.CallbackContext context) {
            rotation = context.ReadValue<Vector2>();
            rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
            rotation.x = Mathf.Clamp(rotation.x, -90, 85);
        }
        
        

}
