using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Left : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
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
    public bool LeftClick()
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
