using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwingPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private PlayerScript player;

    public bool pressed = false;

    private float firstClickPosX;
    private float secondClickPosX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed)
        {
            if (Input.touchCount > 0)
            {
                
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == this.gameObject)
        {
            pressed = true;
            firstClickPosX = Input.touches[0].position.x;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
        secondClickPosX = Input.touches[0].position.x;
        if (CalculateSwipe() > 0)
        {
            player.MovePlayerWithAnimationLeft();
        }
        else
        {
            player.MovePlayerWithAnimationRight();
        };
    }

    private float CalculateSwipe()
    {
        float swipeDelta = firstClickPosX - secondClickPosX;
        return swipeDelta;
    }
}
