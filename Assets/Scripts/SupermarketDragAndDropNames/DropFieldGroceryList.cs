using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropFieldGroceryList : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private Food.Category value;
    [SerializeField]
    private int index;
    [SerializeField]
    private bool isCorrect = false;

    [SerializeField]
    private DragAndDropManagerGroceryList dndManager;
    [SerializeField]
    private Transform panelList;

    private List<GameObject> items = new List<GameObject>();

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Item dropped");
        if(eventData.pointerDrag != null)
        {
            if(eventData.pointerDrag.GetComponent<Food>().category == this.value)
            {
                Debug.Log("Correct");
                this.isCorrect = true;
                dndManager.SetResult(index, true);
            }
            else
            {
                Debug.Log("Bad");
                this.isCorrect = false;
                dndManager.SetResult(index, false);
            }
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
            items.Add(eventData.pointerDrag);
            eventData.pointerDrag.transform.parent = panelList;
        }
    }

    //Hay que ver como marcar como false cuando se quita un elemento bien posicionado y no se coloca otro malo ahi.

    void checkContentCorrect()
    {
        for(int i=0; i < items.Count; i++) { 
            
        }
    }

    public void AddItemToList(GameObject newItem)
    {
        items.Add(newItem);
    }
}
