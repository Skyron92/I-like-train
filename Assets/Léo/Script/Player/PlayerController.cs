using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Player settings")] public float moveSpeed = 5.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float mouseSensitivity = 2.0f;
    [Range(0, 90)] public float clamp;

    [SerializeField] private GameObject firstWagon;
    [SerializeField] private GameObject train;

    private CharacterController _controller;
    private Vector3 moveDirection = Vector3.zero;
    private float verticalRotation = 0.0f;
    private float horizontalRotation = 0.0f;
    private CinemachineVirtualCamera _camera;
    private Animator _animator;

    private bool IsNextToDoor => Doors.Exists(x => Vector3.Distance(transform.position, x.transform.position) <= Range);
    private Animator _doorAnimator;
    public float Range = 1;
    [SerializeField] private GameObject image;
    public List<Door> Doors;

    private void Awake()
    {
        _camera = GetComponentInChildren<CinemachineVirtualCamera>();
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Walk();
        if (IsNextToDoor)
        {
            image.SetActive(true);
            if (Input.GetKey(KeyCode.E)) OpenDoor();
        }
        else
        {
            image.SetActive(false);
        }
    }

    void Walk()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        _animator.SetFloat("Horizontal", horizontalInput);

        // Calculate the movement direction based on the input axes
        Vector3 forward = transform.forward * verticalInput;
        Vector3 right = transform.right * horizontalInput;
        moveDirection = forward + right;

        // Apply move speed to movement direction
        moveDirection *= moveSpeed;

        _controller.Move(moveDirection * Time.deltaTime);

        // Get the mouse input and rotate the camera's view accordingly
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the player object horizontally based on the mouse input
        transform.Rotate(0.0f, mouseX, 0.0f);

        // Rotate the camera around the x-axis (up and down) based on the mouse input
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -clamp, clamp);
        _camera.transform.localRotation = Quaternion.Euler(verticalRotation, 0.0f, 0.0f);
    }

    private void OpenDoor() {
        foreach (var door in Doors) {
            if (Vector3.Distance(transform.position, door.transform.position) <= Range) {
                door.gameObject.GetComponent<Animator>().enabled = true;
                image.SetActive(false);
                return;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SwitchTrain")) {
            firstWagon.SetActive(false);
            train.SetActive(true);
            train.transform.localPosition = Vector3.zero;
        }
    }
}
