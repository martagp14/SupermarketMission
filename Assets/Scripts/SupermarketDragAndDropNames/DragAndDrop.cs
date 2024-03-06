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
    private Canvas canvas;
    [SerializeField]
    private string value;

    void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        iniPos = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("BeginDrag");
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        rectTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Enddrag");
        canvasGroup.blocksRaycasts = true;
        if (eventData.pointerEnter==null)
        {
            //For the object to come back if it's drag outside the screen
            transform.position = iniPos;
        }
        else
        {
            if (eventData.pointerEnter.GetComponent<DropField>() == null)
            {
                transform.position = iniPos;
            }
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Click");
    }

    public string getValue()
    {
        return this.value;
    }
}
