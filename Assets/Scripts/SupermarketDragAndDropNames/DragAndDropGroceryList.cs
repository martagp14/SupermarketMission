using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropGroceryList : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private RectTransform rectTrans;
    private CanvasGroup canvasGroup;
    private Vector3 iniPos;
    private int scrollIndex;

    [SerializeField]
    public Canvas upperParent;
    private Canvas targetParent;
    private Transform initialParent;
    
    [SerializeField]
    public Canvas canvas;
    [SerializeField]
    private string value;


    //Scara como hijo del panel para que no le afecte la mascara al dragear
    //Guardar indice del scroll con transform.GetSiblingIndex() & transform.SetSiblingIndex() posiblemente, pero ni idea
    //En caso de soltar fuera de un dropfield, volver a hacer hijo y volver a darle su posicion
    //Si se suelta dentro de un drop field, pasa a colocarse dentro suyo y a guardarse en la list<> del drop

    void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        iniPos = transform.position;
        initialParent = transform.parent;
        scrollIndex = transform.GetSiblingIndex();

        //Debug.Log("Parent: " + initialParent + " Index: " + scrollIndex);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("BeginDrag");
        canvasGroup.blocksRaycasts = false;

        this.transform.parent = upperParent.gameObject.transform;
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
            //transform.position = iniPos;
            transform.parent = initialParent;
            this.transform.SetSiblingIndex(scrollIndex);
        }
        else
        {
            if (eventData.pointerEnter.GetComponent<DropFieldGroceryList>() == null)
            {
                transform.position = iniPos;
                transform.parent = initialParent;
                this.transform.SetSiblingIndex(scrollIndex);
            }
        }

    }

    public string getValue()
    {
        return this.value;
    }
}
