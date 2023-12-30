using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Right : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    private bool clicked;
    public void OnPointerDown(PointerEventData eventData)
    {
       clicked = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
     clicked= false;
    }
    public bool rightClick()
    {
        if(clicked)
        {
            return true;
        }
        else
        {
            return false;
        }
       
    }
}
