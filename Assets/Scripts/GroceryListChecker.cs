using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroceryListChecker : MonoBehaviour
{
    private LevelLoader levelLoader;

    //List of pending to classify item
    List<Food> pendings;

    // Start is called before the first frame update
    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
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
}
