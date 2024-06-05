using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TrolleyDragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
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

    private TrolleyDragAndDropManager dndManager;


    void Start()
    {
        dndManager = FindObjectOfType<TrolleyDragAndDropManager>();
        rectTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        iniPos = transform.localPosition;
        //initialParent = transform.parent;   //Este que sea la lista de elementos a colocar
        initialParent = GameObject.Find("NewElementsPanel").transform;
        scrollIndex = transform.GetSiblingIndex();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        //Borrar el objecto de la lista cuando se le esta sacando de un drop field
        if (this.transform.parent.GetComponentInParent<TrolleyDropField>())
        {
            Debug.Log("El padre es un drop field " + this.transform.parent);
            dndManager.trolley[this.transform.parent.GetComponentInParent<TrolleyDropField>().GetIndexes()[1], this.transform.parent.GetComponentInParent<TrolleyDropField>().GetIndexes()[0]] = null;
            this.transform.parent.GetComponentInParent<TrolleyDropField>().RelocateColumnElements(this.transform.parent.GetComponentInParent<TrolleyDropField>().GetIndexes()[0]);
            //dndManager.evaluateColumn(this.transform.parent.GetComponentInParent<TrolleyDropField>().GetIndexes()[1]);
            //this.transform.parent.GetComponentInParent<DropFieldGroceryList>().items.Remove(this.gameObject);
        }

        this.transform.parent = upperParent.gameObject.transform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        if (eventData.pointerEnter == null)
        {
            //For the object to come back if it's drag outside the screen
            transform.parent = initialParent;
            //transform.localPosition = iniPos;
            //this.transform.SetSiblingIndex(scrollIndex);
            this.GetComponent<Image>().color = Color.white;
        }
        else
        {
            if (eventData.pointerEnter.GetComponent<TrolleyDropField>() == null)
            {
                //if (eventData.pointerEnter.transform.parent.GetComponent<TrolleyDragAndDrop>() != null)
                //{
                //    Debug.Log("Nombre objeto " + eventData.pointerEnter.gameObject.name);
                //    if (eventData.pointerEnter.gameObject.GetComponentInParent<TrolleyDropField>() != null)
                //    {
                //        GameObject usefulParent = eventData.pointerEnter.gameObject.GetComponentInParent<TrolleyDropField>().gameObject;
                //        //Si se suelta encima de un alimento que ya esta asignado, meterlo en su misma asignacion

                //        Debug.Log("Nombre objeto hihihi " + usefulParent.gameObject.name);

                //        this.GetComponent<RectTransform>().position = usefulParent.GetComponent<RectTransform>().position;
                //        //usefulParent.GetComponent<DropFieldGroceryList>().AddItemToList(this.gameObject);
                //        this.transform.parent = usefulParent.transform.GetChild(0).transform;
                //    }
                //    else
                //    {
                //        transform.parent = initialParent;
                //        transform.localPosition = iniPos;
                //        this.transform.SetSiblingIndex(scrollIndex);
                //    }
                //}
                //else
                //{
                    transform.parent = initialParent;
                    //transform.localPosition = iniPos;
                    //this.transform.SetSiblingIndex(scrollIndex);
                    this.GetComponent<Image>().color = Color.white;
                //}

            }
        }

    }

    public string getValue()
    {
        return this.value;
    }
    public void SendBackToIni()
    {
        //transform.position = iniPos;
        this.GetComponent<Image>().color = Color.white;

    }
}
