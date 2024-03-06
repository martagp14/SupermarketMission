using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropField : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private string value;
    [SerializeField]
    private int index;

    [SerializeField]
    private DragAndDropManager dndManager;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Item dropped");
        if(eventData.pointerDrag != null)
        {
            if(eventData.pointerDrag.GetComponent<DragAndDrop>().getValue() == this.value)
            {
                Debug.Log("Correct");
                dndManager.SetResult(index, true);
            }
            else
            {
                Debug.Log("Bad");
                dndManager.SetResult(index, false);
            }
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
        }
    }

    //Hay que ver como marcar como false cuando se quita un elemento bien posicionado y no se coloca otro malo ahi.
}
