using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnlargeButtonOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text text;
    public int sizeInc = 10;

    public void OnPointerEnter(PointerEventData eventData) {
        text.fontSize += sizeInc;
    }

    public void OnPointerExit(PointerEventData eventData) {
        text.fontSize -= sizeInc;
    }
}
