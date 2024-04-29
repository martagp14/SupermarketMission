using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SectionGenerator : MonoBehaviour
{

    [SerializeField] private GameObject sectionPanel;
    [SerializeField] private GameObject foodElement;
    [SerializeField] private GameObject foodResourcesPrefab;


    // Start is called before the first frame update
    void Start()
    {
        PopulateSection();
    }

    void PopulateSection()
    {
        GameObject foodResources = Instantiate(foodResourcesPrefab);
        //Get actual section del GM
        //Get lista de alimentos de la seccion
        List<String> elements = new List<String>();
        List<Sprite> foodSprites = new List<Sprite>();
        //switch (GameManager.GetInstance().actualSection)
        switch (Food.Category.bakery)
        {
            case Food.Category.bakery:
                elements.AddRange(GameManager.GetInstance().bakeryList);
                foodSprites.AddRange(foodResources.GetComponent<FoodResourcesManager>().bakery);
                break;
            case Food.Category.fish:
                elements = GameManager.GetInstance().fishList;
                foodSprites = foodResources.GetComponent<FoodResourcesManager>().fish;
                break;
            case Food.Category.fridge:
                elements = GameManager.GetInstance().fridgeList;
                foodSprites = foodResources.GetComponent<FoodResourcesManager>().fridge;
                break;
            case Food.Category.fruit:
                elements = GameManager.GetInstance().fruitList;
                foodSprites = foodResources.GetComponent<FoodResourcesManager>().fruits;
                break;
            case Food.Category.legume:
                elements = GameManager.GetInstance().legumeList;
                foodSprites = foodResources.GetComponent<FoodResourcesManager>().legume;
                break;
            case Food.Category.perfumery:
                elements = GameManager.GetInstance().perfumeryList;
                foodSprites = foodResources.GetComponent<FoodResourcesManager>().perfumery;
                break;
            default:
                elements = new List<string>();
                foodSprites = new List<Sprite>();
                break;
        }

        //NUmero aleatorio de elementos (entre 3 y size list)
        var numElements = Random.Range(elements.Count, foodSprites.Count);
        Debug.Log("numelements: " + numElements);
        //Crear toggles
        //Instanciar los elemntos de la lista de la compra y guardar su referencia
        GameObject[] toBuyElements = new GameObject[elements.Count];
        Debug.Log("Lista GM: " + GameManager.GetInstance().bakeryList.Count);
        Debug.Log("Num obligatorios: " + elements.Count);
        Debug.Log("Num sprites: " + foodSprites.Count);
        for (int i = 0; i< elements.Count; i++)
        {
            int index = foodSprites.FindIndex(s => s.name == elements[i].ToString());
            //TO DO
            GameObject element = Instantiate(foodElement);
            element.transform.parent = sectionPanel.transform;
            Sprite s = foodSprites[index];
            element.transform.Find("Background").GetComponent<Image>().sprite = s;
            element.transform.Find("Background").Find("Checkmark").GetComponent<Image>().sprite = s;
            foodSprites.RemoveAt(index);
            toBuyElements[i] = element;
        }
        //Instanciar elementos de relleno
        for(int i = 0; i<numElements - elements.Count; i++)
        {
            GameObject element = Instantiate(foodElement);
            element.transform.parent = sectionPanel.transform;
            //Asignar imagenes aleatorias de la seccion a los toogles
            var rand = Random.Range(0, foodSprites.Count);
            Sprite s = foodSprites[rand];
            element.transform.Find("Background").GetComponent<Image>().sprite = s;
            element.transform.Find("Background").Find("Checkmark").GetComponent<Image>().sprite = s;
            foodSprites.RemoveAt(rand);
            Debug.Log("randFoodIndex: " + rand + "-- count food remaining " + foodSprites.Count);
        }
        // Dar una posicion aleatoria entre los hijos a los elemtos iniciales
        for (int i = 0; i < elements.Count; i++)
        {
            var rand = Random.Range(0, numElements);
            toBuyElements[i].transform.SetSiblingIndex(rand);
        }
    }

    //public void OnClickedCheckThings()
    //{
    //    Debug.Log("Lista GM: " + GameManager.GetInstance().bakeryList.Count);
    //}
}
