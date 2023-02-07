using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipePanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private PlayerScript player;
    

    private float firstClickPosX;
    private float secondClickPosX;

    [SerializeField] private float minimalSwipeLength; 
    

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == this.gameObject)
        {
            firstClickPosX = Input.touches[0].position.x;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        secondClickPosX = Input.touches[0].position.x;
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
        float swipeDelta = firstClickPosX - secondClickPosX;
        return swipeDelta;
    }
}
