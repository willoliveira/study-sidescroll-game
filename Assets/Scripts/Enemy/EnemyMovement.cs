using UnityEngine;
using System.Collections;

namespace Movement
{
    [RequireComponent(typeof(BaseMovement))]
    public class EnemyMovement : MonoBehaviour
    {
        private BaseMovement m_Character;
        private float h = 1f;
        private SpriteRenderer sR; 

        private void Awake()
        {
            m_Character = GetComponent<BaseMovement>();
            sR = GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            // Pass all parameters to the character control script.
            m_Character.Move(h, false, false);
        }

        void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.tag == "Wall")
            {
                h = m_Character.m_FacingRight ? -1f : 1f;
            }
        }        
    }
}