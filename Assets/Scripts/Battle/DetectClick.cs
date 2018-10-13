using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetectClick : MonoBehaviour,IPointerClickHandler {

    public Card card;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            card.use();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            card.discard();
        }
    }
}
