using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Movement
{
    [RequireComponent(typeof(BaseMovement))]
    public class PlayerMovement : MonoBehaviour
    {
        private BaseMovement m_Character;
        private bool m_Jump;
        private bool m_DoubleJump;

        [HideInInspector]
        public bool canMove = true;

        private void Awake()
        {
            m_Character = GetComponent<BaseMovement>();
        }

        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
                //if (m_Character.canDoubleJump)
                //{
                //    Debug.Log("entra aqui");
                //    m_Character.m_DoubleJump = true;
                //}
                //Debug.Log(m_Character.canDoubleJump);
            }
        }

        private void FixedUpdate()
        {
            if (canMove)
            {
                // Read the inputs.
                //bool crouch = Input.GetKey(KeyCode.LeftControl);
                float h = CrossPlatformInputManager.GetAxis("Horizontal");
                // Pass all parameters to the character control script.
                m_Character.Move(h, false, m_Jump);
                m_Jump = false;
            }
        }
    }
}
