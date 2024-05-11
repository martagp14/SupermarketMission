using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private RectTransform rectTrans;
    private CanvasGroup canvasGroup;
    private Vector3 iniPos;

    [SerializeField]
    private Transform initialParent;
    
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Food.Category value;

    PointerEventData eData;

    void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        iniPos = transform.position;
        initialParent = this.transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("BeginDrag");
        canvasGroup.blocksRaycasts = false;
        //if (this.transform.parent.GetComponentInParent<DropField>())
        //{
        //    Debug.Log("El padre es un drop field " + this.transform.parent);
        //    this.transform.parent.GetComponentInParent<DropField>().element = null;
        //    this.transform.parent.GetComponentInParent<DropField>().isOccupied = false;

        //}
        transform.parent = initialParent;

        //if (eData != null)
        //{
        //    Debug.Log("Supueto en el que estaba " + eData.pointerEnter);
        //    if (eData.pointerEnter.GetComponentInParent<DropField>())
        //    {
        //        Debug.Log("El padre es un drop field " + eData.pointerEnter);
        //        eData.pointerEnter.GetComponentInParent<DropField>().element = null;
        //        eData.pointerEnter.GetComponentInParent<DropField>().isOccupied = false;
        //        eData = null;
        //    }
        //}
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        rectTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("Enddrag");
        canvasGroup.blocksRaycasts = true;
        
        if (eventData.pointerEnter==null)
        {
            //For the object to come back if it's drag outside the screen
            transform.position = iniPos;
            transform.parent = initialParent;
        }
        else
        {
            if (eventData.pointerEnter.GetComponent<DropField>() == null)
            {
                transform.position = iniPos;
                transform.parent = initialParent;
            }
            else {
                if (!eventData.pointerEnter.GetComponent<DropField>().isOccupied)
                {
                    //eventData.pointerEnter.GetComponent<DropField>().isOccupied = true;
                    //eventData.pointerEnter.GetComponentInParent<DropField>().element = this;
                    //Debug.Log("supuesto receptor"+eventData.pointerEnter);
                    //eData = eventData;
                    //Debug.Log("supuesto receptor" + eventData.pointerEnter);
                    transform.parent = eventData.pointerEnter.gameObject.transform;
                }
                else
                {
                    transform.position = iniPos;
                    transform.parent = initialParent;
                }
            }
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Click");
    }

    public Food.Category getValue()
    {
        return this.value;
    }

    public void SendBackToIni()
    {
        transform.position = iniPos;

    }
}
