using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrolleyDropField : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private int indexI, indexJ;

    public bool isOccupied = false;
    public DragAndDrop element;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Item dropped");
        if (eventData.pointerDrag != null)
        {
            if (this.transform.childCount == 0)
            {
                if (eventData.pointerDrag.GetComponent<TrolleyDragAndDrop>()) {
                    Debug.Log("Mi pos: " + this.transform.position);
                    eventData.pointerDrag.GetComponent<RectTransform>().position = this.GetComponent<RectTransform>().position;
                    eventData.pointerDrag.transform.parent = this.gameObject.transform;
                }
                
            }
            else
            {
                //Mandarlo de vuelta en la pos ini
                eventData.pointerDrag.GetComponent<TrolleyDragAndDrop>().SendBackToIni();
            }
        }
    }

    public int[] GetIndexes()
    {
        return new int[] {indexI, indexJ};
    }
}
