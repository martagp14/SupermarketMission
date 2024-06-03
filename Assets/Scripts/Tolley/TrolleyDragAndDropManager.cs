using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrolleyDragAndDropManager : MonoBehaviour
{
    //[SerializeField]
    //private Food[,,] trolleyStatus;// = new Food[4, 2, 3];

    [SerializeField]
    private GameObject layer2, layer1, layer0;

    [SerializeField]
    private GameObject newFoodParent;

    [SerializeField]
    private GameObject TrolleyElementPrefab;

    [SerializeField] private GameObject foodResourcesPrefab;

    [SerializeField]
    LevelLoader lvlLoader;

    GameObject foodManager;

    // Start is called before the first frame update
    void Start()
    {
        //Array.Copy(GameManager.GetInstance().trolleyStatus, trolleyStatus, GameManager.GetInstance().trolleyStatus.Length);
        //Muestra null aunque se supone que lo guarda bien
        //if (GameManager.GetInstance().trolleyStatus[1, 0, 0])
        //Debug.Log("TS. " + GameManager.GetInstance().trolleyStatus[1, 0, 0].foodName);

        // Carga los valores del GameManager
        //trolleyStatus = GameManager.GetInstance().trolleyStatus;

        // Verifica si los datos se han cargado correctamente
        //if (trolleyStatus == null)
        //{
        //    Debug.LogError("trolleyStatus es null en Start.");
        //}
        //else
        //{
        //    Debug.Log("TS en Start: " + (trolleyStatus[1, 0, 0] != null ? trolleyStatus[1, 0, 0].ToString() : "null"));
        //}

        SetTrolley();
        SetItemsToOrganize();
        lvlLoader = FindObjectOfType<LevelLoader>();
        foodManager = Instantiate(foodResourcesPrefab);
        //Debug.Log(trolleyStatus.ToString());
    }

    void SetItemsToOrganize()
    {
        //Mostrar los alimentos que se traen nuevos de la seccion
        //Ver cual es la seccion actual
        //Listar los alimentos obligatorios de esa seccion (y que esten marcados por el isTaken)
        //Comprobar que isTaken este definido como marcado cuando se cogen en la seccion que no lo se
        //Craer el prefab con esos alimentos
        //Ponerles como padre el canvas
        List<Food> newFoods = new List<Food>();
        Debug.Log("Actual section: " + GameManager.GetInstance().actualSection);
        //switch (GameManager.GetInstance().actualSection)
        //{
        //    case Food.Category.bakery:
        //        newFoods = GameManager.GetInstance().bakeryFoodList;
        //        Debug.Log(newFoods.Count);
        //        break;
        //    case Food.Category.fruit:
        //        newFoods = GameManager.GetInstance().fruitFoodList; 
        //        break;
        //    case Food.Category.legume:
        //        newFoods = GameManager.GetInstance().legumeFoodList; 
        //        break;
        //    case Food.Category.fridge:
        //        newFoods = GameManager.GetInstance().fridgeFoodList; 
        //        break;
        //    case Food.Category.fish:
        //        newFoods = GameManager.GetInstance().fishFoodList; 
        //        break;
        //    case Food.Category.perfumery:
        //        newFoods = GameManager.GetInstance().perfumeryFoodList;
        //        break;
        //    default:
        //        break;
        //}

        newFoods = GameManager.GetInstance().pickedItems;
        Debug.Log(newFoods.Count);

        foreach (Food foodItem in newFoods)
        {
            //if (foodItem.alreadyTaken)
            //{
                GameObject element = Instantiate(TrolleyElementPrefab);
                element.transform.parent = newFoodParent.transform;
                element.GetComponent<TrolleyDragAndDrop>().upperParent = this.gameObject.GetComponent<Canvas>();
                element.GetComponent<TrolleyDragAndDrop>().canvas = this.gameObject.GetComponent<Canvas>();
                element.GetComponent<Food>().CopyFood(foodItem);
                //element.GetComponentInChildren<Image>().sprite = element.GetComponent<Food>().sprite;
                element.transform.GetChild(0).GetComponent<Image>().sprite = element.GetComponent<Food>().sprite;

            //}
        }
    }

    //void SetTrolley()
    //{
    //    //Colocar cada alimento dnd esta en e status
    //    //Para los tres pisos
    //    //Recorrer los hijos y comprobar si en sus indices hay un aimento
    //    //Si hay alimento, instanciar el elemento como hijo de ese
    //    //Poner el sprite del food

    //    //LAYER 0
    //    int[] index;
    //    for(int i=0; i< layer0.transform.childCount; i++)
    //    {
    //        index = layer0.transform.GetChild(i).GetComponent<TrolleyDropField>().GetIndexes();
    //        //Debug.Log(trolleyStatus[index[1], index[0], 0]);
    //        if(GameManager.GetInstance().trolleyStatus[index[1], index[0], 0])
    //        {
    //            GameObject element = Instantiate(TrolleyElementPrefab);
    //            element.GetComponent<RectTransform>().position = layer0.transform.GetChild(i).GetComponent<RectTransform>().position;
    //            element.transform.parent = layer0.transform.GetChild(i);
    //            element.GetComponent<TrolleyDragAndDrop>().upperParent = this.gameObject.GetComponent<Canvas>();
    //            element.GetComponent<TrolleyDragAndDrop>().canvas = this.gameObject.GetComponent<Canvas>();
    //            element.GetComponent<Food>().CopyFood(GameManager.GetInstance().trolleyStatus[index[1], index[0], 0]);
    //            element.GetComponent<Image>().sprite = element.GetComponent<Food>().sprite;
    //            Debug.Log("Loaded at " + index[0] + "," + index[1]);
    //        }
    //    }
    //    for (int i = 0; i < layer1.transform.childCount; i++)
    //    {
    //        index = layer1.transform.GetChild(i).GetComponent<TrolleyDropField>().GetIndexes();
    //        //Debug.Log(trolleyStatus[index[1], index[0], 0]);
    //        if (GameManager.GetInstance().trolleyStatus[index[1], index[0], 1])
    //        {
    //            GameObject element = Instantiate(TrolleyElementPrefab);
    //            element.GetComponent<RectTransform>().position = layer1.transform.GetChild(i).GetComponent<RectTransform>().position;
    //            element.transform.parent = layer1.transform.GetChild(i);
    //            element.GetComponent<TrolleyDragAndDrop>().upperParent = this.gameObject.GetComponent<Canvas>();
    //            element.GetComponent<TrolleyDragAndDrop>().canvas = this.gameObject.GetComponent<Canvas>();
    //            element.GetComponent<Food>().CopyFood(GameManager.GetInstance().trolleyStatus[index[1], index[0], 1]);
    //            element.GetComponent<Image>().sprite = element.GetComponent<Food>().sprite;
    //        }
    //    }
    //    for (int i = 0; i < layer2.transform.childCount; i++)
    //    {
    //        index = layer2.transform.GetChild(i).GetComponent<TrolleyDropField>().GetIndexes();
    //        //Debug.Log(trolleyStatus[index[1], index[0], 0]);
    //        if (GameManager.GetInstance().trolleyStatus[index[1], index[0], 2])
    //        {
    //            GameObject element = Instantiate(TrolleyElementPrefab);
    //            element.GetComponent<RectTransform>().position = layer2.transform.GetChild(i).GetComponent<RectTransform>().position;
    //            element.transform.parent = layer2.transform.GetChild(i);
    //            element.GetComponent<TrolleyDragAndDrop>().upperParent = this.gameObject.GetComponent<Canvas>();
    //            element.GetComponent<TrolleyDragAndDrop>().canvas = this.gameObject.GetComponent<Canvas>();
    //            element.GetComponent<Food>().CopyFood(GameManager.GetInstance().trolleyStatus[index[1], index[0], 2]);
    //            element.GetComponent<Image>().sprite = element.GetComponent<Food>().sprite;
    //        }
    //    }
    //}

    void SetTrolley()
    {
        //Colocar cada alimento dnd esta en e status
        //Para los tres pisos
        //Recorrer los hijos y comprobar si en sus indices hay un aimento
        //Si hay alimento, instanciar el elemento como hijo de ese
        //Poner el sprite del food

        //LAYER 0
        int[] index;
        //for (int i = 0; i < layer0.transform.childCount; i++)
        //{
        //    index = layer0.transform.GetChild(i).GetComponent<TrolleyDropField>().GetIndexes();
        //    //Debug.Log(trolleyStatus[index[1], index[0], 0]);
        //    if (GameManager.GetInstance().trolleyStatus[index[1], 0])
        //    {
        //        GameObject element = Instantiate(TrolleyElementPrefab);
        //        element.GetComponent<RectTransform>().position = layer0.transform.GetChild(i).GetComponent<RectTransform>().position;
        //        element.transform.parent = layer0.transform.GetChild(i);
        //        element.GetComponent<TrolleyDragAndDrop>().upperParent = this.gameObject.GetComponent<Canvas>();
        //        element.GetComponent<TrolleyDragAndDrop>().canvas = this.gameObject.GetComponent<Canvas>();
        //        element.GetComponent<Food>().CopyFood(GameManager.GetInstance().trolleyStatus[index[1], 0]);
        //        element.GetComponent<Image>().sprite = element.GetComponent<Food>().sprite;
        //        Debug.Log("Loaded at " + index[0] + "," + index[1]);
        //    }
        //}
        //for (int i = 0; i < layer1.transform.childCount; i++)
        //{
        //    index = layer1.transform.GetChild(i).GetComponent<TrolleyDropField>().GetIndexes();
        //    //Debug.Log(trolleyStatus[index[1], index[0], 0]);
        //    if (GameManager.GetInstance().trolleyStatus[index[1], 1])
        //    {
        //        GameObject element = Instantiate(TrolleyElementPrefab);
        //        element.GetComponent<RectTransform>().position = layer1.transform.GetChild(i).GetComponent<RectTransform>().position;
        //        element.transform.parent = layer1.transform.GetChild(i);
        //        element.GetComponent<TrolleyDragAndDrop>().upperParent = this.gameObject.GetComponent<Canvas>();
        //        element.GetComponent<TrolleyDragAndDrop>().canvas = this.gameObject.GetComponent<Canvas>();
        //        element.GetComponent<Food>().CopyFood(GameManager.GetInstance().trolleyStatus[index[1], 1]);
        //        element.GetComponent<Image>().sprite = element.GetComponent<Food>().sprite;
        //    }
        //}
        for (int i = 0; i < layer2.transform.childCount; i++)
        {
            index = layer2.transform.GetChild(i).GetComponent<TrolleyDropField>().GetIndexes();
            //Debug.Log(trolleyStatus[index[1], index[0], 0]);
            if (GameManager.GetInstance().trolleyStatus[index[1], index[0]])
            {
                GameObject element = Instantiate(TrolleyElementPrefab);
                element.GetComponent<RectTransform>().position = layer2.transform.GetChild(i).GetComponent<RectTransform>().position;
                element.transform.parent = layer2.transform.GetChild(i);
                element.GetComponent<TrolleyDragAndDrop>().upperParent = this.gameObject.GetComponent<Canvas>();
                element.GetComponent<TrolleyDragAndDrop>().canvas = this.gameObject.GetComponent<Canvas>();
                element.GetComponent<Food>().CopyFood(GameManager.GetInstance().trolleyStatus[index[1], index[0]]);
                element.transform.GetChild(0).GetComponent<Image>().sprite = element.GetComponent<Food>().sprite;
            }
        }
    }

    //void SaveTrolley()
    //{
    //    //Para cada capa
    //    //Recorrer los hijos y ver si tienen hijo (aka hay alimento)
    //    //Si hay hijo, coger sus indices y guardar su compeonet food en el sitio correspondiente de array

    //    //LAYER0
    //    int[] index;
    //    for (int i = 0; i < layer0.transform.childCount; i++)
    //    {
    //        index = layer0.transform.GetChild(i).GetComponent<TrolleyDropField>().GetIndexes();
    //        if (layer0.transform.GetChild(i).childCount > 0)
    //        {
    //            Debug.Log(layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName);

    //            switch (layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().category)
    //            {
    //                case Food.Category.bakery:
    //                    Debug.Log("Index"+ foodManager.GetComponent<FoodResourcesManager>().bakeryFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName));
    //                    GameManager.GetInstance().trolleyStatus[index[1], index[0], 0] = foodManager.GetComponent<FoodResourcesManager>().bakeryFoods[foodManager.GetComponent<FoodResourcesManager>().bakeryFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
    //                    break;
    //                case Food.Category.fruit:
    //                    GameManager.GetInstance().trolleyStatus[index[1], index[0], 0] = foodManager.GetComponent<FoodResourcesManager>().fruitsFoods[foodManager.GetComponent<FoodResourcesManager>().fruitsFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
    //                    break;
    //                case Food.Category.legume:
    //                    GameManager.GetInstance().trolleyStatus[index[1], index[0], 0] = foodManager.GetComponent<FoodResourcesManager>().legumeFoods[foodManager.GetComponent<FoodResourcesManager>().legumeFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
    //                    break;
    //                case Food.Category.fridge:
    //                    GameManager.GetInstance().trolleyStatus[index[1], index[0], 0] = foodManager.GetComponent<FoodResourcesManager>().fridgeFoods[foodManager.GetComponent<FoodResourcesManager>().fridgeFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
    //                    break;
    //                case Food.Category.fish:
    //                    GameManager.GetInstance().trolleyStatus[index[1], index[0], 0] = foodManager.GetComponent<FoodResourcesManager>().fishFoods[foodManager.GetComponent<FoodResourcesManager>().fishFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
    //                    break;
    //                case Food.Category.perfumery:
    //                    GameManager.GetInstance().trolleyStatus[index[1], index[0], 0] = foodManager.GetComponent<FoodResourcesManager>().perfumeryFoods[foodManager.GetComponent<FoodResourcesManager>().perfumeryFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
    //                    break;
    //                default:
    //                    break;
    //            }
    //            //GameManager.GetInstance().trolleyStatus[index[1], index[0], 0] = layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>();
    //            //GameManager.GetInstance().trolleyStatus[index[1], index[0], 0] = new Food();
    //            //GameManager.GetInstance().trolleyStatus[index[1], index[0], 0].CopyFood(layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>());
    //            Debug.Log("elento. "+ GameManager.GetInstance().trolleyStatus[index[1], index[0], 0]);
    //            Debug.Log("Saved at " + index[0] + "," + index[1]);
    //        }
    //        else
    //        {
    //            GameManager.GetInstance().trolleyStatus[index[1], index[0], 0] = null;
    //        }
    //    }

    //    for (int i = 0; i < layer1.transform.childCount; i++)
    //    {
    //        index = layer1.transform.GetChild(i).GetComponent<TrolleyDropField>().GetIndexes();
    //        if (layer1.transform.GetChild(i).childCount > 0)
    //        {
    //            Debug.Log(layer1.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName);

    //            switch (layer1.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().category)
    //            {
    //                case Food.Category.bakery:
    //                    GameManager.GetInstance().trolleyStatus[index[1], index[0], 1] = foodManager.GetComponent<FoodResourcesManager>().bakeryFoods[foodManager.GetComponent<FoodResourcesManager>().bakeryFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer1.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
    //                    break;
    //                case Food.Category.fruit:
    //                    GameManager.GetInstance().trolleyStatus[index[1], index[0], 1] = foodManager.GetComponent<FoodResourcesManager>().fruitsFoods[foodManager.GetComponent<FoodResourcesManager>().fruitsFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer1.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
    //                    break;
    //                case Food.Category.legume:
    //                    GameManager.GetInstance().trolleyStatus[index[1], index[0], 1] = foodManager.GetComponent<FoodResourcesManager>().legumeFoods[foodManager.GetComponent<FoodResourcesManager>().legumeFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer1.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
    //                    break;
    //                case Food.Category.fridge:
    //                    GameManager.GetInstance().trolleyStatus[index[1], index[0], 1] = foodManager.GetComponent<FoodResourcesManager>().fridgeFoods[foodManager.GetComponent<FoodResourcesManager>().fridgeFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer1.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
    //                    break;
    //                case Food.Category.fish:
    //                    GameManager.GetInstance().trolleyStatus[index[1], index[0], 1] = foodManager.GetComponent<FoodResourcesManager>().fishFoods[foodManager.GetComponent<FoodResourcesManager>().fishFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer1.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
    //                    break;
    //                case Food.Category.perfumery:
    //                    GameManager.GetInstance().trolleyStatus[index[1], index[0], 1] = foodManager.GetComponent<FoodResourcesManager>().perfumeryFoods[foodManager.GetComponent<FoodResourcesManager>().perfumeryFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer1.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
    //                    break;
    //                default:
    //                    break;
    //            }
    //        }
    //        else
    //        {
    //            GameManager.GetInstance().trolleyStatus[index[1], index[0], 1] = null;
    //        }
    //    }

    //    for (int i = 0; i < layer2.transform.childCount; i++)
    //    {
    //        index = layer2.transform.GetChild(i).GetComponent<TrolleyDropField>().GetIndexes();
    //        if (layer2.transform.GetChild(i).childCount > 0)
    //        {
    //            Debug.Log(layer2.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName);

    //            switch (layer2.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().category)
    //            {
    //                case Food.Category.bakery:
    //                    GameManager.GetInstance().trolleyStatus[index[1], index[0], 2] = foodManager.GetComponent<FoodResourcesManager>().bakeryFoods[foodManager.GetComponent<FoodResourcesManager>().bakeryFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer2.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
    //                    break;
    //                case Food.Category.fruit:
    //                    GameManager.GetInstance().trolleyStatus[index[1], index[0], 2] = foodManager.GetComponent<FoodResourcesManager>().fruitsFoods[foodManager.GetComponent<FoodResourcesManager>().fruitsFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer2.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
    //                    break;
    //                case Food.Category.legume:
    //                    GameManager.GetInstance().trolleyStatus[index[1], index[0], 2] = foodManager.GetComponent<FoodResourcesManager>().legumeFoods[foodManager.GetComponent<FoodResourcesManager>().legumeFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer2.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
    //                    break;
    //                case Food.Category.fridge:
    //                    GameManager.GetInstance().trolleyStatus[index[1], index[0], 2] = foodManager.GetComponent<FoodResourcesManager>().fridgeFoods[foodManager.GetComponent<FoodResourcesManager>().fridgeFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer2.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
    //                    break;
    //                case Food.Category.fish:
    //                    GameManager.GetInstance().trolleyStatus[index[1], index[0], 2] = foodManager.GetComponent<FoodResourcesManager>().fishFoods[foodManager.GetComponent<FoodResourcesManager>().fishFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer2.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
    //                    break;
    //                case Food.Category.perfumery:
    //                    GameManager.GetInstance().trolleyStatus[index[1], index[0], 2] = foodManager.GetComponent<FoodResourcesManager>().perfumeryFoods[foodManager.GetComponent<FoodResourcesManager>().perfumeryFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer2.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
    //                    break;
    //                default:
    //                    break;
    //            }
    //        }
    //        else
    //        {
    //            GameManager.GetInstance().trolleyStatus[index[1], index[0], 2] = null;
    //        }
    //    }
    //}

    void SaveTrolley()
    {
        //Para cada capa
        //Recorrer los hijos y ver si tienen hijo (aka hay alimento)
        //Si hay hijo, coger sus indices y guardar su compeonet food en el sitio correspondiente de array

        //LAYER0
        int[] index;
        //for (int i = 0; i < layer0.transform.childCount; i++)
        //{
        //    index = layer0.transform.GetChild(i).GetComponent<TrolleyDropField>().GetIndexes();
        //    if (layer0.transform.GetChild(i).childCount > 0)
        //    {
        //        Debug.Log(layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName);

        //        switch (layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().category)
        //        {
        //            case Food.Category.bakery:
        //                Debug.Log("Index" + foodManager.GetComponent<FoodResourcesManager>().bakeryFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName));
        //                GameManager.GetInstance().trolleyStatus[index[1], 0] = foodManager.GetComponent<FoodResourcesManager>().bakeryFoods[foodManager.GetComponent<FoodResourcesManager>().bakeryFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
        //                break;
        //            case Food.Category.fruit:
        //                GameManager.GetInstance().trolleyStatus[index[1], 0] = foodManager.GetComponent<FoodResourcesManager>().fruitsFoods[foodManager.GetComponent<FoodResourcesManager>().fruitsFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
        //                break;
        //            case Food.Category.legume:
        //                GameManager.GetInstance().trolleyStatus[index[1], 0] = foodManager.GetComponent<FoodResourcesManager>().legumeFoods[foodManager.GetComponent<FoodResourcesManager>().legumeFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
        //                break;
        //            case Food.Category.fridge:
        //                GameManager.GetInstance().trolleyStatus[index[1], 0] = foodManager.GetComponent<FoodResourcesManager>().fridgeFoods[foodManager.GetComponent<FoodResourcesManager>().fridgeFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
        //                break;
        //            case Food.Category.fish:
        //                GameManager.GetInstance().trolleyStatus[index[1], 0] = foodManager.GetComponent<FoodResourcesManager>().fishFoods[foodManager.GetComponent<FoodResourcesManager>().fishFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
        //                break;
        //            case Food.Category.perfumery:
        //                GameManager.GetInstance().trolleyStatus[index[1], 0] = foodManager.GetComponent<FoodResourcesManager>().perfumeryFoods[foodManager.GetComponent<FoodResourcesManager>().perfumeryFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        GameManager.GetInstance().trolleyStatus[index[1], 0] = null;
        //    }
        //}

        //for (int i = 0; i < layer1.transform.childCount; i++)
        //{
        //    index = layer1.transform.GetChild(i).GetComponent<TrolleyDropField>().GetIndexes();
        //    if (layer1.transform.GetChild(i).childCount > 0)
        //    {
        //        Debug.Log(layer1.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName);

        //        switch (layer1.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().category)
        //        {
        //            case Food.Category.bakery:
        //                GameManager.GetInstance().trolleyStatus[index[1], 1] = foodManager.GetComponent<FoodResourcesManager>().bakeryFoods[foodManager.GetComponent<FoodResourcesManager>().bakeryFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer1.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
        //                break;
        //            case Food.Category.fruit:
        //                GameManager.GetInstance().trolleyStatus[index[1], 1] = foodManager.GetComponent<FoodResourcesManager>().fruitsFoods[foodManager.GetComponent<FoodResourcesManager>().fruitsFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer1.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
        //                break;
        //            case Food.Category.legume:
        //                GameManager.GetInstance().trolleyStatus[index[1], 1] = foodManager.GetComponent<FoodResourcesManager>().legumeFoods[foodManager.GetComponent<FoodResourcesManager>().legumeFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer1.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
        //                break;
        //            case Food.Category.fridge:
        //                GameManager.GetInstance().trolleyStatus[index[1], 1] = foodManager.GetComponent<FoodResourcesManager>().fridgeFoods[foodManager.GetComponent<FoodResourcesManager>().fridgeFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer1.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
        //                break;
        //            case Food.Category.fish:
        //                GameManager.GetInstance().trolleyStatus[index[1], 1] = foodManager.GetComponent<FoodResourcesManager>().fishFoods[foodManager.GetComponent<FoodResourcesManager>().fishFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer1.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
        //                break;
        //            case Food.Category.perfumery:
        //                GameManager.GetInstance().trolleyStatus[index[1], 1] = foodManager.GetComponent<FoodResourcesManager>().perfumeryFoods[foodManager.GetComponent<FoodResourcesManager>().perfumeryFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer1.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        GameManager.GetInstance().trolleyStatus[index[1], 1] = null;
        //    }
        //}

        for (int i = 0; i < layer2.transform.childCount; i++)
        {
            index = layer2.transform.GetChild(i).GetComponent<TrolleyDropField>().GetIndexes();
            if (layer2.transform.GetChild(i).childCount > 0)
            {
                Debug.Log(layer2.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName);

                switch (layer2.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().category)
                {
                    case Food.Category.bakery:
                        GameManager.GetInstance().trolleyStatus[index[1], index[0]] = foodManager.GetComponent<FoodResourcesManager>().bakeryFoods[foodManager.GetComponent<FoodResourcesManager>().bakeryFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer2.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
                        break;
                    case Food.Category.fruit:
                        GameManager.GetInstance().trolleyStatus[index[1], index[0]] = foodManager.GetComponent<FoodResourcesManager>().fruitsFoods[foodManager.GetComponent<FoodResourcesManager>().fruitsFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer2.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
                        break;
                    case Food.Category.legume:
                        GameManager.GetInstance().trolleyStatus[index[1], index[0]] = foodManager.GetComponent<FoodResourcesManager>().legumeFoods[foodManager.GetComponent<FoodResourcesManager>().legumeFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer2.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
                        break;
                    case Food.Category.fridge:
                        GameManager.GetInstance().trolleyStatus[index[1], index[0]] = foodManager.GetComponent<FoodResourcesManager>().fridgeFoods[foodManager.GetComponent<FoodResourcesManager>().fridgeFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer2.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
                        break;
                    case Food.Category.fish:
                        GameManager.GetInstance().trolleyStatus[index[1], index[0]] = foodManager.GetComponent<FoodResourcesManager>().fishFoods[foodManager.GetComponent<FoodResourcesManager>().fishFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer2.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
                        break;
                    case Food.Category.perfumery:
                        GameManager.GetInstance().trolleyStatus[index[1], index[0]] = foodManager.GetComponent<FoodResourcesManager>().perfumeryFoods[foodManager.GetComponent<FoodResourcesManager>().perfumeryFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer2.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
                        break;
                    default:
                        break;
                }
            }
            else
            {
                GameManager.GetInstance().trolleyStatus[index[1], index[0]] = null;
            }
        }
    }

    public void OnClickReload()
    {
        if (newFoodParent.transform.childCount==0)
        {
            SaveTrolley();
            GameManager.GetInstance().pickedItems = new List<Food>();
            lvlLoader.LoadNextLevel("SupermarketMapSelection");
        }
        
    }
}
