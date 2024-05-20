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
    private GameObject TrolleyElementPrefab;

    [SerializeField] private GameObject foodResourcesPrefab;

    [SerializeField]
    LevelLoader lvlLoader;

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
        lvlLoader = FindObjectOfType<LevelLoader>();
        //Debug.Log(trolleyStatus.ToString());
    }

    void SetTrolley()
    {
        //Colocar cada alimento dnd esta en e status
        //Para los tres pisos
        //Recorrer los hijos y comprobar si en sus indices hay un aimento
        //Si hay alimento, instanciar el elemento como hijo de ese
        //Poner el sprite del food

        //LAYER 0
        int[] index;
        for(int i=0; i< layer0.transform.childCount; i++)
        {
            index = layer0.transform.GetChild(i).GetComponent<TrolleyDropField>().GetIndexes();
            //Debug.Log(trolleyStatus[index[1], index[0], 0]);
            if(GameManager.GetInstance().trolleyStatus[index[1], index[0], 0])
            {
                GameObject element = Instantiate(TrolleyElementPrefab);
                element.GetComponent<RectTransform>().position = layer0.transform.GetChild(i).GetComponent<RectTransform>().position;
                element.transform.parent = layer0.transform.GetChild(i);
                element.GetComponent<TrolleyDragAndDrop>().upperParent = this.gameObject.GetComponent<Canvas>();
                element.GetComponent<TrolleyDragAndDrop>().canvas = this.gameObject.GetComponent<Canvas>();
                element.GetComponent<Food>().CopyFood(GameManager.GetInstance().trolleyStatus[index[1], index[0], 0]);
                element.GetComponent<Image>().sprite = element.GetComponent<Food>().sprite;
                Debug.Log("Loaded at " + index[0] + "," + index[1]);

            }
        }
    }

    void SaveTrolley()
    {
        //Para cada capa
        //Recorrer los hijos y ver si tienen hijo (aka hay alimento)
        //Si hay hijo, coger sus indices y guardar su compeonet food en el sitio correspondiente de array

        GameObject foodManageer = Instantiate(foodResourcesPrefab);
        //LAYER0
        int[] index;
        for (int i = 0; i < layer0.transform.childCount; i++)
        {
            index = layer0.transform.GetChild(i).GetComponent<TrolleyDropField>().GetIndexes();
            if (layer0.transform.GetChild(i).childCount > 0)
            {
                Debug.Log(layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName);

                switch (layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().category)
                {
                    case Food.Category.bakery:
                        Debug.Log("Index"+ foodManageer.GetComponent<FoodResourcesManager>().bakeryFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName));
                        GameManager.GetInstance().trolleyStatus[index[1], index[0], 0] = foodManageer.GetComponent<FoodResourcesManager>().bakeryFoods[foodManageer.GetComponent<FoodResourcesManager>().bakeryFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
                        break;
                    case Food.Category.fruit:
                        GameManager.GetInstance().trolleyStatus[index[1], index[0], 0] = foodManageer.GetComponent<FoodResourcesManager>().fruitsFoods[foodManageer.GetComponent<FoodResourcesManager>().fruitsFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
                        break;
                    case Food.Category.legume:
                        GameManager.GetInstance().trolleyStatus[index[1], index[0], 0] = foodManageer.GetComponent<FoodResourcesManager>().legumeFoods[foodManageer.GetComponent<FoodResourcesManager>().legumeFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
                        break;
                    case Food.Category.fridge:
                        GameManager.GetInstance().trolleyStatus[index[1], index[0], 0] = foodManageer.GetComponent<FoodResourcesManager>().fridgeFoods[foodManageer.GetComponent<FoodResourcesManager>().fridgeFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
                        break;
                    case Food.Category.fish:
                        GameManager.GetInstance().trolleyStatus[index[1], index[0], 0] = foodManageer.GetComponent<FoodResourcesManager>().fishFoods[foodManageer.GetComponent<FoodResourcesManager>().fishFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
                        break;
                    case Food.Category.perfumery:
                        GameManager.GetInstance().trolleyStatus[index[1], index[0], 0] = foodManageer.GetComponent<FoodResourcesManager>().perfumeryFoods[foodManageer.GetComponent<FoodResourcesManager>().perfumeryFoods.FindIndex(s => s.GetComponent<Food>().foodName == layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>().foodName)];
                        break;
                    default:
                        break;
                }
                //GameManager.GetInstance().trolleyStatus[index[1], index[0], 0] = layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>();
                //GameManager.GetInstance().trolleyStatus[index[1], index[0], 0] = new Food();
                //GameManager.GetInstance().trolleyStatus[index[1], index[0], 0].CopyFood(layer0.transform.GetChild(i).transform.GetChild(0).GetComponent<Food>());
                Debug.Log("elento. "+ GameManager.GetInstance().trolleyStatus[index[1], index[0], 0]);
                Debug.Log("Saved at " + index[0] + "," + index[1]);
            }
            else
            {
                GameManager.GetInstance().trolleyStatus[index[1], index[0], 0] = null;
            }
        }

        //Guardar currentTrolley en GM
        //GameManager.GetInstance().trolleyStatus = this.trolleyStatus;
        //for (int i = 0; i < trolleyStatus.GetLength(0); i++)
        //{
        //    for (int j = 0; j < trolleyStatus.GetLength(1); j++)
        //    {
        //        for (int k = 0; k < trolleyStatus.GetLength(2); k++)
        //        {
        //            if (trolleyStatus[i, j, k] != null)
        //            {
        //                GameManager.GetInstance().trolleyStatus[i, j, k] = trolleyStatus[i, j, k].Clone();
        //            }
        //        }
        //    }
        //}
        //Debug.Log("TS[1,0,0]. " + trolleyStatus[1, 0, 0]);

        ////GameManager.GetInstance().trolleyStatus[1, 0, 0] = new Food();
        //GameManager.GetInstance().trolleyStatus[1, 0, 0].CopyFood(trolleyStatus[1, 0, 0]);

        ////trolleyStatus.CopyTo(GameManager.GetInstance().trolleyStatus,0);
        //Debug.Log("GM. " + GameManager.GetInstance().trolleyStatus[1, 0, 0].foodName);
        ////trolleyStatus[1, 0, 0] = null;
        //Debug.Log("GM. " + GameManager.GetInstance().trolleyStatus[1, 0, 0].foodName);

    }

    public void OnClickReload()
    {
        SaveTrolley();
        lvlLoader.LoadNextLevel("TrolleyScene");
    }
}
