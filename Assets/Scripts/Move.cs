using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Move : MonoBehaviour, IBeginDragHandler, IDragHandler
{
   [SerializeField] private PlayerController  playerContr;
    public bool switcher = true;
   
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (switcher)
        {
            if (Mathf.Abs(eventData.delta.x) > (Mathf.Abs(eventData.delta.y)))
            {
                if (eventData.delta.x > 0)
                {
                    playerContr.moveState = MoveState.Right;
                    Debug.Log("Право");
                }
                else
                {
                    playerContr.moveState = MoveState.Left;
                    Debug.Log("Лево");
                }
            }
            else
            {
                if (eventData.delta.y > 0)
                {
                    playerContr.moveState = MoveState.Up;
                    Debug.Log("Вперед");
                }
                else
                {
                    playerContr.moveState = MoveState.Down;
                    Debug.Log("Назад");
                }
            }
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
    }
}
