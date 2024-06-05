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
    private Sprite lightFrame, midFrame, grossFrame;

    [SerializeField]
    private Sprite lightWeight, midWeight, heavyWeight;

    [SerializeField]
    private GameObject newFoodParent;

    [SerializeField]
    private GameObject TrolleyElementPrefab;

    [SerializeField] private GameObject foodResourcesPrefab;

    [SerializeField]
    LevelLoader lvlLoader;

    public GameObject[,] trolley = new GameObject[8,3];

    GameObject foodManager;

    // Start is called before the first frame update
    void Start()
    {
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

        newFoods = GameManager.GetInstance().pickedItems;
        Debug.Log(newFoods.Count);

        foreach (Food foodItem in newFoods)
        {
            //if (foodItem.alreadyTaken)
            //{
            GameObject element = Instantiate(TrolleyElementPrefab);
            element.transform.parent = newFoodParent.transform;
            element.transform.localScale = new Vector3(1f,1f,1f);
            element.GetComponent<TrolleyDragAndDrop>().upperParent = this.gameObject.GetComponent<Canvas>();
            element.GetComponent<TrolleyDragAndDrop>().canvas = this.gameObject.GetComponent<Canvas>();
            element.GetComponent<Food>().CopyFood(foodItem);
            //element.GetComponentInChildren<Image>().sprite = element.GetComponent<Food>().sprite;
            element.transform.Find("FoodImage").GetComponent<Image>().sprite = element.GetComponent<Food>().sprite;
            //Hardness
            if(element.GetComponent<Food>().hardness == Food.hardnessLevel.hard)
                element.transform.Find("FrameImage").GetComponent<Image>().sprite = grossFrame;
            else if (element.GetComponent<Food>().hardness == Food.hardnessLevel.mid)
                element.transform.Find("FrameImage").GetComponent<Image>().sprite = midFrame;
            else if (element.GetComponent<Food>().hardness == Food.hardnessLevel.fragile)
                element.transform.Find("FrameImage").GetComponent<Image>().sprite = lightFrame;
            //Weight
            if (element.GetComponent<Food>().weight == Food.weightLevel.heavy)
                element.transform.Find("WeightImage").GetComponent<Image>().sprite = heavyWeight;
            else if (element.GetComponent<Food>().weight == Food.weightLevel.mid)
                element.transform.Find("WeightImage").GetComponent<Image>().sprite = midWeight;
            else if (element.GetComponent<Food>().weight == Food.weightLevel.light)
                element.transform.Find("WeightImage").GetComponent<Image>().sprite = lightWeight;
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
        int[] index;
        for (int i = 0; i < layer2.transform.childCount; i++)
        {
            index = layer2.transform.GetChild(i).GetComponent<TrolleyDropField>().GetIndexes();
            //Debug.Log(trolleyStatus[index[1], index[0], 0]);
            if (GameManager.GetInstance().trolleyStatus[index[1], index[0]])
            {
                GameObject element = Instantiate(TrolleyElementPrefab);
                element.GetComponent<RectTransform>().position = layer2.transform.GetChild(i).GetComponent<RectTransform>().position;
                element.transform.parent = layer2.transform.GetChild(i);
                element.transform.localScale = new Vector3(1f,1f,1f);
                element.GetComponent<TrolleyDragAndDrop>().upperParent = this.gameObject.GetComponent<Canvas>();
                element.GetComponent<TrolleyDragAndDrop>().canvas = this.gameObject.GetComponent<Canvas>();
                element.GetComponent<Food>().CopyFood(GameManager.GetInstance().trolleyStatus[index[1], index[0]]);
                element.transform.Find("FoodImage").GetComponent<Image>().sprite = element.GetComponent<Food>().sprite;
                //Hardness
                if (element.GetComponent<Food>().hardness == Food.hardnessLevel.hard)
                    element.transform.Find("FrameImage").GetComponent<Image>().sprite = grossFrame;
                else if (element.GetComponent<Food>().hardness == Food.hardnessLevel.mid)
                    element.transform.Find("FrameImage").GetComponent<Image>().sprite = midFrame;
                else if (element.GetComponent<Food>().hardness == Food.hardnessLevel.fragile)
                    element.transform.Find("FrameImage").GetComponent<Image>().sprite = lightFrame;
                //Weight
                if (element.GetComponent<Food>().weight == Food.weightLevel.heavy)
                    element.transform.Find("WeightImage").GetComponent<Image>().sprite = heavyWeight;
                else if (element.GetComponent<Food>().weight == Food.weightLevel.mid)
                    element.transform.Find("WeightImage").GetComponent<Image>().sprite = midWeight;
                else if (element.GetComponent<Food>().weight == Food.weightLevel.light)
                    element.transform.Find("WeightImage").GetComponent<Image>().sprite = lightWeight;
                this.evaluatePosition(index[1], index[0], element);
                trolley[index[1], index[0]] = element;
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

        int[] index;
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

    public void evaluatePosition(int indexI, int indexJ, GameObject element)
    {
        //Comprobar si hay objeto encima
        Food thisFood = element.GetComponent<Food>();
        element.GetComponent<Image>().color = Color.green;
        if (indexJ>0)
        {
            Food aboveFood = GameManager.GetInstance().trolleyStatus[indexI, indexJ - 1];
            if (aboveFood)
            {

                //Si lo hay, comprobar dureza de este objeto
                //Si no es duro, comprobar peso del objeto de encima
                //Poner tinte al alo segun sea su relacion
                if (thisFood.hardness == Food.hardnessLevel.fragile)
                {
                    if (aboveFood.weight == Food.weightLevel.mid)
                    {
                        //Orange
                        element.GetComponent<Image>().color = Color.yellow;
                    }
                    else if (aboveFood.weight == Food.weightLevel.heavy)
                    {
                        //Red
                        element.GetComponent<Image>().color = Color.red;
                    }
                }
                else if (thisFood.hardness == Food.hardnessLevel.mid)
                {
                    if (aboveFood.weight == Food.weightLevel.heavy)
                    {
                        //Orange
                        element.GetComponent<Image>().color = Color.yellow;
                    }
                }
            }
        }
        if (indexJ > 1)
        {
            //Si tiene dos objetos encima, comporbar los dos
            Food aboveFood = GameManager.GetInstance().trolleyStatus[indexI, indexJ - 2];
            if (aboveFood)
            {
                if (thisFood.hardness == Food.hardnessLevel.fragile)
                {
                    if (aboveFood.weight == Food.weightLevel.mid)
                    {
                        element.GetComponent<Image>().color = Color.yellow;
                    }
                    else if (aboveFood.weight == Food.weightLevel.heavy)
                    {
                        element.GetComponent<Image>().color = Color.red;
                    }
                }
                else if (thisFood.hardness == Food.hardnessLevel.mid)
                {
                    if (aboveFood.weight == Food.weightLevel.heavy)
                    {
                        element.GetComponent<Image>().color = Color.yellow;
                    }
                }
            }
        }
    }

    //public void evaluateColumn(int indexJ)
    //{
    //    //El de arriba verde
    //    if (trolley[indexJ, 0])
    //        trolley[indexJ, 0].GetComponent<Image>().color = Color.green;
    //    if (trolley[indexJ, 1]) 
    //        trolley[indexJ, 1].GetComponent<Image>().color = Color.green;
    //    if (trolley[indexJ, 2]) 
    //        trolley[indexJ, 2].GetComponent<Image>().color = Color.green;
    //    //El del medio depende del de arriba
    //    if (trolley[indexJ, 0] && trolley[indexJ, 1] && trolley[indexJ, 0].GetComponent<Food>().weight == Food.weightLevel.mid && trolley[indexJ, 1].GetComponent<Food>().hardness == Food.hardnessLevel.fragile)
    //    {
    //        trolley[indexJ, 1].GetComponent<Image>().color = Color.yellow;
    //    }
    //    else if (trolley[indexJ, 0] && trolley[indexJ, 1] && trolley[indexJ, 0].GetComponent<Food>().weight == Food.weightLevel.heavy && trolley[indexJ, 1].GetComponent<Food>().hardness == Food.hardnessLevel.fragile)
    //    {
    //        trolley[indexJ, 1].GetComponent<Image>().color = Color.red;
    //    }
    //    //El de abajo depende de los dos de arriba
    //    if (trolley[indexJ, 0] && trolley[indexJ, 2] && trolley[indexJ, 0].GetComponent<Food>().weight == Food.weightLevel.heavy && trolley[indexJ, 2].GetComponent<Food>().hardness == Food.hardnessLevel.fragile)
    //    {
    //        trolley[indexJ, 2].GetComponent<Image>().color = Color.red;
    //    }
    //    else
    //    {
    //        if (trolley[indexJ, 1].GetComponent<Food>().weight == Food.weightLevel.heavy && trolley[indexJ, 2].GetComponent<Food>().hardness == Food.hardnessLevel.fragile)
    //        {
    //            trolley[indexJ, 2].GetComponent<Image>().color = Color.red;
    //        }
    //        else
    //        {
    //            if (trolley[indexJ, 0].GetComponent<Food>().weight == Food.weightLevel.mid && trolley[indexJ, 2].GetComponent<Food>().hardness == Food.hardnessLevel.fragile)
    //            {
    //                trolley[indexJ, 2].GetComponent<Image>().color = Color.yellow;
    //            }
    //            else if (trolley[indexJ, 1].GetComponent<Food>().weight == Food.weightLevel.mid && trolley[indexJ, 2].GetComponent<Food>().hardness == Food.hardnessLevel.fragile)
    //            {
    //                trolley[indexJ, 2].GetComponent<Image>().color = Color.yellow;
    //            }
    //        }
    //    }
    //}

    public void evaluateColumn(int indexJ)
    {
        //Si existe el de arriba
        if (trolley[indexJ, 0])
        {
            trolley[indexJ, 0].GetComponent<Image>().color = Color.green;
            trolley[indexJ, 1].GetComponent<Image>().color = Color.green;
            trolley[indexJ, 2].GetComponent<Image>().color = Color.green;
            if (trolley[indexJ, 0].GetComponent<Food>().weight == Food.weightLevel.mid && trolley[indexJ, 1].GetComponent<Food>().hardness == Food.hardnessLevel.fragile)
            {
                trolley[indexJ, 1].GetComponent<Image>().color = Color.yellow;
            } else 
            if (trolley[indexJ, 0].GetComponent<Food>().weight == Food.weightLevel.heavy && trolley[indexJ, 1].GetComponent<Food>().hardness == Food.hardnessLevel.fragile)
            {
                trolley[indexJ, 1].GetComponent<Image>().color = Color.red;
            } else
            if (trolley[indexJ, 0].GetComponent<Food>().weight == Food.weightLevel.heavy && trolley[indexJ, 1].GetComponent<Food>().hardness == Food.hardnessLevel.mid)
            {
                trolley[indexJ, 1].GetComponent<Image>().color = Color.yellow;
            }
            if (trolley[indexJ, 0].GetComponent<Food>().weight == Food.weightLevel.mid && trolley[indexJ, 2].GetComponent<Food>().hardness == Food.hardnessLevel.fragile)
            {
                trolley[indexJ, 2].GetComponent<Image>().color = Color.yellow;
            } else   
            if (trolley[indexJ, 0].GetComponent<Food>().weight == Food.weightLevel.heavy && trolley[indexJ, 2].GetComponent<Food>().hardness == Food.hardnessLevel.fragile)
            {
                trolley[indexJ, 2].GetComponent<Image>().color = Color.red;
            }
            else if (trolley[indexJ, 0].GetComponent<Food>().weight == Food.weightLevel.heavy && trolley[indexJ, 2].GetComponent<Food>().hardness == Food.hardnessLevel.mid)
            {
                trolley[indexJ, 2].GetComponent<Image>().color = Color.yellow;
            }
            Debug.Log("Arriba: "+ trolley[indexJ, 0].GetComponent<Food>().foodName + "Medio: " + trolley[indexJ, 1].GetComponent<Food>().foodName + "Abajo: " + trolley[indexJ, 2].GetComponent<Food>().foodName);
        }
        else
        {
            if(trolley[indexJ, 1])
                trolley[indexJ, 1].GetComponent<Image>().color = Color.green;
            if(trolley[indexJ, 2])
                trolley[indexJ, 2].GetComponent<Image>().color = Color.green;
        }
        //Si existe el del medio
        if (trolley[indexJ, 1] && trolley[indexJ, 2].GetComponent<Image>().color != Color.red) {
            
            if (trolley[indexJ, 1].GetComponent<Food>().weight == Food.weightLevel.mid && trolley[indexJ, 2].GetComponent<Food>().hardness == Food.hardnessLevel.fragile)
            {
                trolley[indexJ, 2].GetComponent<Image>().color = Color.yellow;
            }else
            if (trolley[indexJ, 1].GetComponent<Food>().weight == Food.weightLevel.heavy && trolley[indexJ, 2].GetComponent<Food>().hardness == Food.hardnessLevel.fragile)
            {
                trolley[indexJ, 2].GetComponent<Image>().color = Color.red;
            }else
            if (trolley[indexJ, 1].GetComponent<Food>().weight == Food.weightLevel.heavy && trolley[indexJ, 2].GetComponent<Food>().hardness == Food.hardnessLevel.mid)
            {
                trolley[indexJ, 2].GetComponent<Image>().color = Color.yellow;
            }
            Debug.Log("Medio: " + trolley[indexJ, 1].GetComponent<Food>().foodName + "Abajo: " + trolley[indexJ, 2].GetComponent<Food>().foodName);

        }
        else
        {
            if (trolley[indexJ, 2] && trolley[indexJ, 2].GetComponent<Image>().color != Color.red)
            {
                trolley[indexJ, 2].GetComponent<Image>().color = Color.green;
                Debug.Log("Abajo: " + trolley[indexJ, 2].GetComponent<Food>().foodName);
            }
        }

        //SIN PROBAR
        //Y HAY QUE HACER QUE LOS OBJETOS CAIGAN DE ARRIBA SI NO HAY NADA DEBJAO; SINO ESTA MAL
    }
}
