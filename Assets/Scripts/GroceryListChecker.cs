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

    [SerializeField] Sprite bakeryIcons, fruitsIcons, legumesIcons, fridgeIcons, fishIcons, perfumeryIcons;

    //List of pending to classify item
    List<string> pendings = new List<string>();
    List<Food> foodPendings = new List<Food>();
    int numItems = 20;
    DropFieldGroceryList[] dropFields = new DropFieldGroceryList[6];

    // Start is called before the first frame update
    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        this.GenerateGroceryListV2();
        dropFields = FindObjectsOfType<DropFieldGroceryList>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool checkClassification()
    {
        bool isCorrect = true;
        //Todo: Check is groceries are correctly classify
        //Check if pending item list is empty
        if(parentList.transform.childCount != 0)
        {
            isCorrect = false;
            Debug.Log("No se ha clasificado todo - " + parentList.transform.childCount);
        }
        else
        {
            //Then check each category, run through every item and check its category propert
            for(int i=0; i<dropFields.Length && isCorrect; i++)
            {
                Debug.Log("Estoy comprobando " + dropFields[i].GetComponent<DropFieldGroceryList>().value);

                foreach (GameObject item in dropFields[i].items)
                {
                    if (item.GetComponent<Food>().category != dropFields[i].GetComponent<DropFieldGroceryList>().value)
                    {
                        isCorrect = false;
                        Debug.Log("Algo mal con "+item.GetComponent<Food>().category);
                    }
                }
            }
        }
        return isCorrect;
    }

    public void OnClickCheck()
    {
        //Check if correct
        if (checkClassification())
        {
            levelLoader.LoadNextLevel("SupermarketMap");
        }
        else
        {
            //Por alguna razon cuando hay algo que esta mal colocado, y se coloca bien, sigue diciendo que esta mal
            Debug.Log("Hay algo mal");
        }
    }

    //Generate Grocery List
    //void GenerateGroceyList()
    //{
    //    //Set num items
    //    FoodResourcesManager fm = Instantiate(prefabFoodManager).GetComponent<FoodResourcesManager>();
    //    fm.InitializeCount();
    //    //for each food category
    //    //rnad num between 0 and num elements categroy
    //    //pick that num of elements from category list
    //    //save those in categroy list in GM
        
    //    //Bakery
    //    int randNum = Random.Range(0, fm.bakeryFoods.Count);
    //    List<Food> foodCopy = fm.bakeryFoods;
    //    for(int i = 0; i < randNum; i++)
    //    {
    //        int rand = Random.Range(0, foodCopy.Count);
    //        GameManager.GetInstance().bakeryFoodList.Add(foodCopy[rand]);
    //        pendings.Add(foodCopy[rand].GetComponent<Food>().foodName);
    //        foodCopy.RemoveAt(rand);
    //    }
    //    numItems -= randNum;
    //    //Fruits
    //    randNum = Random.Range(((numItems - fm.numFoodAccumulative[2])<0)?0: numItems - fm.numFoodAccumulative[2], fm.fruitsFoods.Count);
    //    Debug.Log("Num Frutas "+ randNum);
    //    //Controlar el numero de cada seccion para llegar a ser 20 siempre
    //    foodCopy = fm.fruitsFoods;
    //    for (int i = 0; i < randNum; i++)
    //    {
    //        int rand = Random.Range(0, foodCopy.Count);
    //        Debug.Log("Indice de la fruta: "+rand);
    //        GameManager.GetInstance().fruitFoodList.Add(foodCopy[rand]);
    //        pendings.Add(foodCopy[rand].GetComponent<Food>().foodName);
    //        foodCopy.RemoveAt(rand);
    //    }
    //    numItems -= randNum;
    //    //Legume
    //    randNum = Random.Range(((numItems - fm.numFoodAccumulative[3]) < 0) ? 0 : numItems - fm.numFoodAccumulative[3], fm.legumeFoods.Count);
    //    foodCopy = fm.legumeFoods;
    //    for (int i = 0; i < randNum; i++)
    //    {
    //        int rand = Random.Range(0, foodCopy.Count);
    //        GameManager.GetInstance().legumeFoodList.Add(foodCopy[rand]);
    //        pendings.Add(foodCopy[rand].GetComponent<Food>().foodName);
    //        foodCopy.RemoveAt(rand);
    //    }
    //    numItems -= randNum;
    //    //Fridge
    //    randNum = Random.Range(((numItems - fm.numFoodAccumulative[4]) < 0) ? 0 : numItems - fm.numFoodAccumulative[4], fm.fridgeFoods.Count);
    //    foodCopy = fm.fridgeFoods;
    //    for (int i = 0; i < randNum; i++)
    //    {
    //        int rand = Random.Range(0, foodCopy.Count);
    //        GameManager.GetInstance().fridgeFoodList.Add(foodCopy[rand]);
    //        pendings.Add(foodCopy[rand].GetComponent<Food>().foodName);
    //        foodCopy.RemoveAt(rand);
    //    }
    //    numItems -= randNum;
    //    //Fish
    //    randNum = Random.Range(((numItems - fm.numFoodAccumulative[5]) < 0) ? 0 : numItems - fm.numFoodAccumulative[5], fm.fishFoods.Count);
    //    foodCopy = fm.fishFoods;
    //    for (int i = 0; i < randNum; i++)
    //    {
    //        int rand = Random.Range(0, foodCopy.Count);
    //        GameManager.GetInstance().fishFoodList.Add(foodCopy[rand]);
    //        pendings.Add(foodCopy[rand].GetComponent<Food>().foodName);
    //        foodCopy.RemoveAt(rand);
    //    }
    //    numItems -= randNum;
    //    //Perfumery
    //    randNum = Random.Range(numItems, fm.perfumeryFoods.Count);
    //    foodCopy = fm.perfumeryFoods;
    //    for (int i = 0; i < randNum; i++)
    //    {
    //        int rand = Random.Range(0, foodCopy.Count);
    //        GameManager.GetInstance().perfumeryFoodList.Add(foodCopy[rand]);
    //        pendings.Add(foodCopy[rand].GetComponent<Food>().foodName);
    //        foodCopy.RemoveAt(rand);
    //    }
    //    numItems -= randNum;

    //    Debug.Log("Elementos restantes: " + numItems);

    //    Debug.Log("Num lista compra"+numItems);
    //    this.GenerateClasificationList();
    //}

    void GenerateGroceryListV2()
    {
        FoodResourcesManager fm = Instantiate(prefabFoodManager).GetComponent<FoodResourcesManager>();
        SetAsNotTakenFood(fm.bakeryFoods);
        SetAsNotTakenFood(fm.fruitsFoods);
        SetAsNotTakenFood(fm.legumeFoods);
        SetAsNotTakenFood(fm.fridgeFoods);
        SetAsNotTakenFood(fm.fishFoods);
        SetAsNotTakenFood(fm.perfumeryFoods);
        List<Food> allFoods = fm.bakeryFoods;
        allFoods.AddRange(fm.fruitsFoods);
        allFoods.AddRange(fm.legumeFoods);
        allFoods.AddRange(fm.fridgeFoods);
        allFoods.AddRange(fm.fishFoods);
        allFoods.AddRange(fm.perfumeryFoods);

        int randIndex = 0;
        for(int i=0; i<numItems; i++)
        {
            randIndex = Random.Range(0, allFoods.Count);
            //Meter ese alimento en la lista
            foodPendings.Add(allFoods[randIndex].GetComponent<Food>());
            //pendings.Add(allFoods[randIndex].GetComponent<Food>().foodName);
            //clasificarlo en las listas de tipos de GM
            switch (allFoods[randIndex].GetComponent<Food>().category)
            {
                case Food.Category.bakery:
                    GameManager.GetInstance().bakeryFoodList.Add(allFoods[randIndex]);
                    break;
                case Food.Category.fruit:
                    GameManager.GetInstance().fruitFoodList.Add(allFoods[randIndex]);
                    break;
                case Food.Category.legume:
                    GameManager.GetInstance().legumeFoodList.Add(allFoods[randIndex]);
                    break;
                case Food.Category.fridge:
                    GameManager.GetInstance().fridgeFoodList.Add(allFoods[randIndex]);
                    break;
                case Food.Category.fish:
                    GameManager.GetInstance().fishFoodList.Add(allFoods[randIndex]);
                    break;
                case Food.Category.perfumery:
                    GameManager.GetInstance().perfumeryFoodList.Add(allFoods[randIndex]);
                    break;
                default:
                    break;
            }
            //Eliminarlo del conjunto de todos
            allFoods.RemoveAt(randIndex);
        }
        GenerateClasificationList();
    }

    void GenerateClasificationList()
    {
        for(int i=0; i<foodPendings.Count; i++)
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
            g.GetComponentInChildren<TMP_Text>().text = foodPendings[i].GetComponent<Food>().foodName;
            g.GetComponent<Food>().category = foodPendings[i].category;
            switch (g.GetComponent<Food>().category)
            {
                case Food.Category.bakery:
                    g.transform.Find("Icons").GetComponent<Image>().sprite = bakeryIcons;
                    break;
                case Food.Category.fruit:
                    g.transform.Find("Icons").GetComponent<Image>().sprite = fruitsIcons;
                    break;
                case Food.Category.legume:
                    g.transform.Find("Icons").GetComponent<Image>().sprite = legumesIcons;
                    break;
                case Food.Category.fridge:
                    g.transform.Find("Icons").GetComponent<Image>().sprite = fridgeIcons;
                    break;
                case Food.Category.fish:
                    g.transform.Find("Icons").GetComponent<Image>().sprite = fishIcons;
                    break;
                case Food.Category.perfumery:
                    g.transform.Find("Icons").GetComponent<Image>().sprite = perfumeryIcons;
                    break;
                default:
                    break;
            }
        }
    }

    void SetAsNotTakenFood(List<Food> list)
    {
        foreach (Food f in list){
            f.alreadyTaken = false;
        }
    }
}
