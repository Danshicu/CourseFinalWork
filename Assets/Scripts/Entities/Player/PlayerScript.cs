using System.Collections;
using UnityEngine;

namespace Pramchuk
{
    public class PlayerScript : MonoBehaviour
    {
        private Collider _myCollider;
        private bool _isClimbing = true;
        private bool _isJumping=false;
        private Transform _mPlayer;
        private Vector3 _mPosition;
        [SerializeField] private float minimalCoordinateX=-3.5f;
        [SerializeField] private float maximalCoordinateX=3.5f;
        [SerializeField] private float horizontalStep = 2f;
        [SerializeField] private float verticalStep = 0.04f;
        [SerializeField] private float waitForJumpTime = 1f;
        void Awake()
        {
            _myCollider = gameObject.GetComponent<Collider>();
            _mPlayer = gameObject.GetComponent<Transform>();
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
    
        private void SetClimbingStateFor(bool factor)
        {
            _isClimbing = factor;
            _myCollider.enabled = factor;
        }
    
        IEnumerator DisableInputForJump()
        {
            _isJumping = true;
            yield return new WaitForSeconds(waitForJumpTime);
            _isJumping = false;
        }
    
        public void MovePlayerWithAnimationLeft()
        {
            if (_mPlayer.position.x > minimalCoordinateX)
            {
                if (!_isJumping)
                {
                    _mPlayer.position += Vector3.left * horizontalStep;
                    StartCoroutine(DisableInputForJump());
                }
            }
        }


        public void MovePlayerWithAnimationRight()
        {
            if (_mPlayer.position.x < maximalCoordinateX)
            {
                if (!_isJumping)
                {
                    _mPlayer.position += Vector3.right * horizontalStep;
                    StartCoroutine(DisableInputForJump());
                }
            }
        }
        private void MyInput()
        {
            if (_isClimbing)
            {
                if (!_isJumping)
                {
                    _mPlayer.position += Vector3.up * verticalStep;
                }
            }
        }
    }
}

