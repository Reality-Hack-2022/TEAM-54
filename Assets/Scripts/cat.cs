using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Normal.Realtime;

public class cat : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    
    private float gravityValue = -9.81f;

    // jump mechanics
    public float maxJumpHeight = 2.0f;
    public float chargeTime = 2.0f;
    private float initialJumpTime;
    private float jumpWithPower = 0.0f;
    private float _jumping;

    // camera
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    private float rotationX = 0;
    public Camera playerCamera;
    
    // cat must be set by spawner
    private GameObject controlledCat;

    // grabbing
    public float grabDistance = 5.0f;
    public LayerMask grabMask;
    private Transform holding;
    private Key key;

    private void Start()
    {
        controller = controlledCat.GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Grab();
        }
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            Release();
        }

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 forward = controlledCat.transform.TransformDirection(Vector3.forward);
        Vector3 right = controlledCat.transform.TransformDirection(Vector3.right);

        Vector3 move = playerSpeed * (
          _currentMove.x * right +
          _currentMove.y * forward
        );

        

        if (_jumping == 0.0f)
        {
            controller.Move(move * Time.deltaTime * playerSpeed);
        }

        // Changes the height position of the player..
        if (jumpWithPower > 0 && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpWithPower * -3.0f * gravityValue);
            jumpWithPower = 0.0f;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        Vector2 result = Mouse.current.delta.ReadValue();

        rotationX += -result.y * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, result.x * lookSpeed, 0);
        controlledCat.transform.rotation *= Quaternion.Euler(0, result.x * lookSpeed, 0);
    }

    private void Grab()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.TransformDirection(Vector3.forward), out hit, grabDistance, grabMask))
        {
            hit.transform.GetComponent<RealtimeTransform>().RequestOwnership();
            if (hit.transform.tag == "Key")
            {
                key = hit.transform.GetComponent<Key>();
                key.Grab(playerCamera.transform);
            }
            else
            {
                hit.transform.parent = playerCamera.transform;
                Debug.Log("grab");
                if (hit.transform.GetComponent<Rigidbody>() != null)
                    hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                holding = hit.transform;
            }
        }
    }

    private void Release()
    {
        if (holding)
        {
            holding.transform.parent = null;
            PCGrabbable properties = holding.transform.GetComponent<PCGrabbable>();
            Rigidbody rb = holding.gameObject.GetComponent<Rigidbody>();
                Debug.Log("drop");
            rb.isKinematic = false;
            rb.useGravity = true;
            holding = null;
        }
        if (key)
        {
            key.Release();
            key = null;
        }
            
    }

    private Vector2 _currentMove;

    public void OnMove(InputAction.CallbackContext context)
    {
        _currentMove = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        bool chargingJump = _jumping > 0;
        _jumping = context.ReadValue<float>();
        if (_jumping > 0 && !chargingJump)
        {
            // begin charging jump
            initialJumpTime = Time.time;
        }
        else if (_jumping == 0 && chargingJump)
        {
            // do jump
            jumpWithPower = Mathf.Lerp(0.0f, maxJumpHeight, (Time.time - initialJumpTime) / chargeTime);
        }
    }

    public void eatTreat()
    {
    }

    public void SetCatModel(GameObject model)
    {
        controlledCat = model;
    }

}
