using UnityEngine;
using UnityEngine.EventSystems;

namespace Pramchuk
{
    public class SwipePanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private PlayerScript player;
        
        private float _firstClickPosX;
        private float _secondClickPosX;
    
        [SerializeField] private float minimalSwipeLength;


        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.pointerCurrentRaycast.gameObject == gameObject)
            {
                _firstClickPosX = Input.touches[0].position.x;
            }
        }
    
        public void OnPointerUp(PointerEventData eventData)
        {
            _secondClickPosX = Input.touches[0].position.x;
            float thisSwipe = CalculateSwipe();
            if (Mathf.Abs(thisSwipe) > minimalSwipeLength)
            {
                if (thisSwipe > 0)
                {
                    player.MovePlayerWithAnimationLeft();
                }
                else
                {
                    player.MovePlayerWithAnimationRight();
                }
            }
        }
    
        private float CalculateSwipe()
        {
            float swipeDelta = _firstClickPosX - _secondClickPosX;
            return swipeDelta;
        }
    }

}
