using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmongUs2.Player
{
    public class PlayerCharacter : MonoBehaviour
    {
        Rigidbody m_Rigidbody;

        [SerializeField] float m_MoveSpeed = 4f;
        [SerializeField] float m_JumpHeight = 2f;

        private void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
        }

        //Gets called in FixedUpdate of PlayerControls
        public void Move(Vector2 move, bool jump, bool sprint, Vector3 mouse)
        {
            m_Rigidbody.velocity = new Vector3(move.x, 0, move.y) * m_MoveSpeed;
            if (mouse.sqrMagnitude > 0)
            {
                mouse.y = transform.position.y;
                transform.LookAt(mouse);
            }            
        }
    }

}
