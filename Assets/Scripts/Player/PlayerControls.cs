using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AmongUs2.Player
{
    [RequireComponent(typeof(PlayerCharacter))]
    public class PlayerControls : MonoBehaviour
    {
        private Camera m_Cam;
        private PlayerInputActions m_InputActions;
        private PlayerCharacter m_Character;
        private Vector3 m_Move;
        private Vector2 m_MoveInput;
        private bool m_Jump; 
        private bool m_Sprint;

        private void Awake()
        {
            m_InputActions = new PlayerInputActions();
        }
        private void OnEnable()
        {
            Debug.Log("Enabling control handler");
            m_InputActions.Enable();
            m_InputActions.Player.Jump.performed += OnJump;
            m_InputActions.Player.Jump.canceled += OnJump;
            m_InputActions.Player.Move.performed += OnMove;
            m_InputActions.Player.Move.canceled += OnMove;
            m_InputActions.Player.Sprint.performed += OnSprint;
            m_InputActions.Player.Sprint.canceled += OnSprint;
        }
        private void OnDisable()
        {
            m_InputActions.Player.Jump.performed -= OnJump;
            m_InputActions.Player.Jump.canceled -= OnJump;
            m_InputActions.Player.Move.performed -= OnMove;
            m_InputActions.Player.Move.canceled -= OnMove;
            m_InputActions.Player.Sprint.performed -= OnSprint;
            m_InputActions.Player.Sprint.canceled -= OnSprint;
            m_InputActions.Disable();
        }

        private void OnJump(InputAction.CallbackContext ctx)
        {
            var value = ctx.ReadValue<float>();
            m_Jump = value > 0.5f;
        }

        private void OnSprint(InputAction.CallbackContext ctx)
        {
            var value = ctx.ReadValue<float>();
            m_Sprint = value > 0.5f;
        }

        private void OnMove(InputAction.CallbackContext ctx)
        {
            var value = ctx.ReadValue<Vector2>();
            m_MoveInput = value;
        }

        private void Start()
        {
            m_Cam = Camera.main;
            m_Character = GetComponent<PlayerCharacter>();
        }
        
        private void FixedUpdate()
        {
            RaycastHit hit;
            Ray ray = m_Cam.ScreenPointToRay(new Vector3(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue(), 0f));
            Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow);
            Vector3 MouseLocation = Vector3.zero;
            if (Physics.Raycast(ray, out hit))
            {
                MouseLocation = hit.point;                
            }
            

            // pass all parameters to the character control script
            m_Character.Move(m_MoveInput, m_Jump, m_Sprint, MouseLocation);
            m_Jump = false;
        }
    }

}
