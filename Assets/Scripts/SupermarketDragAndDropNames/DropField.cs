using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropField : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private Food.Category value;
    [SerializeField]
    private int index;

    public bool isOccupied = false;
    public DragAndDrop element;

    [SerializeField]
    private DragAndDropManager dndManager;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Item dropped");
        if(eventData.pointerDrag != null)
        {
            if (!isOccupied)
            {
                if (eventData.pointerDrag.GetComponent<DragAndDrop>().getValue() == this.value)
                {
                    Debug.Log("Correct");
                    //dndManager.SetResult(index, true);
                }
                else
                {
                    Debug.Log("Bad");
                    //dndManager.SetResult(index, false);
                }
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
            }
        }
    }

    public Food.Category getValue()
    {
        return this.value;
    }
    //Hay que ver como marcar como false cuando se quita un elemento bien posicionado y no se coloca otro malo ahi.
}
