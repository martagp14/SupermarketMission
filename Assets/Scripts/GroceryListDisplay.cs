using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GroceryListDisplay : MonoBehaviour
{
    [SerializeField] private GameObject prefabFoodItemList;
    [SerializeField] private GameObject bakeryScroll;
    [SerializeField] private GameObject fruitsScroll;
    [SerializeField] private GameObject legumesScroll;
    [SerializeField] private GameObject fridgeScroll;
    [SerializeField] private GameObject fishScroll;
    [SerializeField] private GameObject perfumeryScroll;

    // Start is called before the first frame update
    void Start()
    {
        DisplayGroceyList();
    }

    void DisplayGroceyList()
    {
        //Coger lista del GM
        List<Food> foodList = GameManager.GetInstance().bakeryFoodList;
        //Por cada lista, ir creando los eleemntos de la lista
        for (int i=0; i< foodList.Count; i++)
        {
            GameObject g = Instantiate(prefabFoodItemList);
            //Poner como padre la lista correspondiente
            g.transform.SetParent(bakeryScroll.transform);
            g.transform.localScale = new Vector3(1f, 1f, 1f);
            //Comprobar si el elemento ya ha sido cogido para tachar el texto
            g.GetComponentInChildren<TMP_Text>().text = foodList[i].foodName;
            if(foodList[i].alreadyTaken)
                g.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Strikethrough;
            //Quitar drag and drop script
            g.GetComponent<DragAndDropGroceryList>().enabled = false;
        }

        //Coger lista del GM
        foodList = GameManager.GetInstance().fruitFoodList;
        //Por cada lista, ir creando los eleemntos de la lista
        for (int i = 0; i < foodList.Count; i++)
        {
            GameObject g = Instantiate(prefabFoodItemList);
            //Poner como padre la lista correspondiente
            g.transform.SetParent(fruitsScroll.transform);
            g.transform.localScale = new Vector3(1f, 1f, 1f);
            //Comprobar si el elemento ya ha sido cogido para tachar el texto
            g.GetComponentInChildren<TMP_Text>().text = foodList[i].foodName;
            if (foodList[i].alreadyTaken) 
                g.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Strikethrough;
            //Quitar drag and drop script
            g.GetComponent<DragAndDropGroceryList>().enabled = false;
        }

        //Coger lista del GM
        foodList = GameManager.GetInstance().legumeFoodList;
        //Por cada lista, ir creando los eleemntos de la lista
        for (int i = 0; i < foodList.Count; i++)
        {
            GameObject g = Instantiate(prefabFoodItemList);
            //Poner como padre la lista correspondiente
            g.transform.SetParent(legumesScroll.transform);
            g.transform.localScale = new Vector3(1f, 1f, 1f);
            //Comprobar si el elemento ya ha sido cogido para tachar el texto
            g.GetComponentInChildren<TMP_Text>().text = foodList[i].foodName;
            if (foodList[i].alreadyTaken) 
                g.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Strikethrough;
            //Quitar drag and drop script
            g.GetComponent<DragAndDropGroceryList>().enabled = false;
        }

        //Coger lista del GM
        foodList = GameManager.GetInstance().fridgeFoodList;
        //Por cada lista, ir creando los eleemntos de la lista
        for (int i = 0; i < foodList.Count; i++)
        {
            GameObject g = Instantiate(prefabFoodItemList);
            //Poner como padre la lista correspondiente
            g.transform.SetParent(fridgeScroll.transform);
            g.transform.localScale = new Vector3(1f, 1f, 1f);
            //Comprobar si el elemento ya ha sido cogido para tachar el texto
            g.GetComponentInChildren<TMP_Text>().text = foodList[i].foodName;
            if (foodList[i].alreadyTaken) 
                g.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Strikethrough;
            //Quitar drag and drop script
            g.GetComponent<DragAndDropGroceryList>().enabled = false;
        }

        //Coger lista del GM
        foodList = GameManager.GetInstance().fishFoodList;
        //Por cada lista, ir creando los eleemntos de la lista
        for (int i = 0; i < foodList.Count; i++)
        {
            GameObject g = Instantiate(prefabFoodItemList);
            //Poner como padre la lista correspondiente
            g.transform.SetParent(fishScroll.transform);
            g.transform.localScale = new Vector3(1f, 1f, 1f);
            //Comprobar si el elemento ya ha sido cogido para tachar el texto
            g.GetComponentInChildren<TMP_Text>().text = foodList[i].foodName;
            if (foodList[i].alreadyTaken) 
                g.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Strikethrough;
            //Quitar drag and drop script
            g.GetComponent<DragAndDropGroceryList>().enabled = false;
        }

        //Coger lista del GM
        foodList = GameManager.GetInstance().perfumeryFoodList;
        //Por cada lista, ir creando los eleemntos de la lista
        for (int i = 0; i < foodList.Count; i++)
        {
            GameObject g = Instantiate(prefabFoodItemList);
            //Poner como padre la lista correspondiente
            g.transform.SetParent(perfumeryScroll.transform);
            g.transform.localScale = new Vector3(1f, 1f, 1f);
            //Comprobar si el elemento ya ha sido cogido para tachar el texto
            g.GetComponentInChildren<TMP_Text>().text = foodList[i].foodName;
            if (foodList[i].alreadyTaken) 
                g.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Strikethrough;
            //Quitar drag and drop script
            g.GetComponent<DragAndDropGroceryList>().enabled = false;
        }
    }
}
