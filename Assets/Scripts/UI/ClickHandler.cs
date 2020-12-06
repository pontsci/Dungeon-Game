using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    public abstract void OnPointerClick(PointerEventData eventData);
}
