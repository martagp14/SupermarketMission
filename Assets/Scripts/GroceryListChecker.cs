using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GroceryListChecker : MonoBehaviour
{
    private LevelLoader levelLoader;

    [SerializeField] private GameObject prefabFoodManager;
    [SerializeField] private GameObject prefabFoodItemList;

    [SerializeField] private GameObject parentList;
    [SerializeField] private Canvas canvas;

    //List of pending to classify item
    List<string> pendings = new List<string>();
    int numItems = 20;

    // Start is called before the first frame update
    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        this.GenerateGroceyList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool checkClassification()
    {
        //Todo: Check is groceries are correctly classify
        //Check if pending item list is empty
        //Then check each category, run through every item and check its category propert
        return true;
    }

    void OnClickCheck()
    {
        //Check if correct
        if (checkClassification())
        {
            GameManager.GetInstance().GoToScene("SupermarketMap");
        }
    }

    //Generate Grocery List
    void GenerateGroceyList()
    {
        //Set num items
        FoodResourcesManager fm = Instantiate(prefabFoodManager).GetComponent<FoodResourcesManager>();
        //for each food category
        //Bakery
        int randNum = Random.Range(0, fm.bakeryFoods.Count);
        List<Food> foodCopy = fm.bakeryFoods;
        for(int i = 0; i < randNum; i++)
        {
            int rand = Random.Range(0, foodCopy.Count);
            GameManager.GetInstance().bakeryFoodList.Add(foodCopy[rand]);
            pendings.Add(foodCopy[rand].GetComponent<Food>().foodName);
            foodCopy.RemoveAt(rand);
        }
        numItems -= randNum;
        Debug.Log("Num lista compra"+numItems);
        //rnad num between 0 and num elements categroy
        //pick that num of elements from category list
        //save those in categroy list in GM
        this.GenerateClasificationList();
    }

    void GenerateClasificationList()
    {
        for(int i=0; i<pendings.Count; i++)
        {
            GameObject g = Instantiate(prefabFoodItemList);
            //set parent
            g.transform.SetParent(parentList.transform);
            g.transform.localScale = new Vector3(1f, 1f, 1f);
            g.GetComponent<DragAndDropGroceryList>().canvas = canvas;
            g.GetComponent<DragAndDropGroceryList>().upperParent = canvas;
            //set index
            int rand = Random.Range(0, numItems);
            g.transform.SetSiblingIndex(rand);
            g.GetComponentInChildren<TMP_Text>().text = pendings[i];
        }
    }
}
