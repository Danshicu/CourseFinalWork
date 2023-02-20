using System.Collections;
using UnityEngine;

namespace Pramchuk
{
    public class PlayerScript : MonoBehaviour
    {
        private Collider myCollider;
        private bool IsClimbing = true;
        private bool IsJumping=false;
        private Transform m_player;
        private Vector3 m_position;
        [SerializeField] private float horizontal_step;
        [SerializeField] private float vertical_step;
        [SerializeField] private float WaitForJumpTime;
        void Awake()
        {
            myCollider = gameObject.GetComponent<Collider>();
            m_player = gameObject.GetComponent<Transform>();
        }
    
        void FixedUpdate()
        {
            MyInput();
            if (Input.GetMouseButtonDown(0))
            {
                SetClimbingStateFor(false);
            }
    
            if (Input.GetMouseButtonUp(0))
            {
                SetClimbingStateFor(true);
            }
        }
    
        public void SetClimbingStateFor(bool factor)
        {
            IsClimbing = factor;
            myCollider.enabled = factor;
        }
    
        IEnumerator DisableInputForJump()
        {
            IsJumping = true;
            yield return new WaitForSeconds(WaitForJumpTime);
            IsJumping = false;
        }
    
        public void MovePlayerWithAnimationLeft()
        {
            if (!IsJumping)
            {
                m_player.position += Vector3.left * horizontal_step;
                StartCoroutine(DisableInputForJump());
            }
        }
    
        
        public void MovePlayerWithAnimationRight()
        {
            if (!IsJumping)
            {
                m_player.position += Vector3.right * horizontal_step;
                StartCoroutine(DisableInputForJump());
            }
        }
        void MyInput()
        {
            if (IsClimbing)
            {
                if (!IsJumping)
                {
                    m_player.position += Vector3.up * vertical_step;
                }
            }
        }
    }
}

