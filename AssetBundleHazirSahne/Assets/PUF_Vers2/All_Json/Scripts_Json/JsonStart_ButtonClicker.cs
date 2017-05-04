using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JsonStart_ButtonClicker : MonoBehaviour, IPointerClickHandler
{
    public ProjectFiller pFiller;
    public string url;

    public void OnPointerClick(PointerEventData eventData)
    {
        // Button Clicked
        pFiller.jsonPath = url;
        pFiller.Execute("1");
    }
}
