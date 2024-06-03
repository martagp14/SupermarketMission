using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SectionGenerator : MonoBehaviour
{
    [SerializeField] private LevelLoader lvlLoader;

    [SerializeField] private GameObject sectionPanel;
    [SerializeField] private GameObject foodElement;
    [SerializeField] private GameObject foodResourcesPrefab;
    [SerializeField] private Image backgroungSection;
    [SerializeField] private Sprite[] backgrounds = new Sprite[6];

    private Toggle[] toggles;

    [SerializeField] List<Food> listElements = new List<Food>();

    [SerializeField] Canvas groceryListCanvas;

    // Start is called before the first frame update
    void Start()
    {
        lvlLoader = FindObjectOfType<LevelLoader>();
        PopulateSection();
        toggles = FindObjectsOfType<Toggle>();
        groceryListCanvas.gameObject.SetActive(false);
    }

    void PopulateSection()
    {
        GameObject foodResources = Instantiate(foodResourcesPrefab);
        //Get actual section del GM
        //Get lista de alimentos de la seccion
        //List<String> elements = new List<String>();
        List<Food> allSectionFoods = new List<Food>();
        //List<Sprite> foodSprites = new List<Sprite>();
        Debug.Log("Creamdo seccion de " + GameManager.GetInstance().actualSection);

        switch (GameManager.GetInstance().actualSection)
        //switch (Food.Category.bakery)
        {
            case Food.Category.bakery:
                backgroungSection.sprite = backgrounds[0];
                listElements.AddRange(GameManager.GetInstance().bakeryFoodList);
                allSectionFoods.AddRange(foodResources.GetComponent<FoodResourcesManager>().bakeryFoods);
                //foodSprites.AddRange(foodResources.GetComponent<FoodResourcesManager>().bakery);
                break;
            case Food.Category.fruit:
                backgroungSection.sprite = backgrounds[1];
                listElements = GameManager.GetInstance().fruitFoodList;
                allSectionFoods = foodResources.GetComponent<FoodResourcesManager>().fruitsFoods;
                break;
            case Food.Category.legume:
                backgroungSection.sprite = backgrounds[2];
                listElements = GameManager.GetInstance().legumeFoodList;
                allSectionFoods = foodResources.GetComponent<FoodResourcesManager>().legumeFoods;
                break;
            case Food.Category.fridge:
                backgroungSection.sprite = backgrounds[3];
                listElements = GameManager.GetInstance().fridgeFoodList;
                allSectionFoods = foodResources.GetComponent<FoodResourcesManager>().fridgeFoods;
                break;
            case Food.Category.fish:
                backgroungSection.sprite = backgrounds[4];
                listElements = GameManager.GetInstance().fishFoodList;
                allSectionFoods = foodResources.GetComponent<FoodResourcesManager>().fishFoods;
                break;
            case Food.Category.perfumery:
                backgroungSection.sprite = backgrounds[5];
                listElements = GameManager.GetInstance().perfumeryFoodList;
                allSectionFoods = foodResources.GetComponent<FoodResourcesManager>().perfumeryFoods;
                break;
            default:
                listElements = new List<Food>();
                //foodSprites = new List<Sprite>();
                allSectionFoods = new List<Food>();
                break;
        }

        //NUmero aleatorio de elementos (entre 3 y size list)
        var numElements = Random.Range(listElements.Count, allSectionFoods.Count);
        Debug.Log("numelements: " + numElements);
        //Crear toggles
        //Instanciar los elemntos de la lista de la compra y guardar su referencia
        GameObject[] toBuyElements = new GameObject[listElements.Count];
        Debug.Log("Num obligatorios: " + listElements.Count);
        Debug.Log("Num sprites: " + allSectionFoods.Count);
        for (int i = 0; i < listElements.Count; i++)
        {
            //VIGILAR SI ESTA BIEN CON NAME O TIENE QUE SER FOOD NAME
            int index = allSectionFoods.FindIndex(s => s.name == listElements[i].GetComponent<Food>().name);
            //int index = foodSprites.FindIndex(s => s.name == elements[i].ToString());
            //TO DO
            GameObject element = Instantiate(foodElement);
            element.transform.parent = sectionPanel.transform;
            Sprite s = allSectionFoods[index].sprite;
            element.transform.Find("Background").GetComponent<Image>().sprite = s;
            element.transform.Find("Background").Find("Checkmark").GetComponent<Image>().sprite = s;
            element.GetComponent<Food>().CopyFood(listElements[i].GetComponent<Food>());
            allSectionFoods.RemoveAt(index);
            toBuyElements[i] = element;
        }
        //Instanciar elementos de relleno
        for (int i = 0; i < numElements - listElements.Count; i++)
        {
            GameObject element = Instantiate(foodElement);
            element.transform.parent = sectionPanel.transform;
            //Asignar imagenes aleatorias de la seccion a los toogles
            var rand = Random.Range(0, allSectionFoods.Count);
            Sprite s = allSectionFoods[rand].sprite;
            element.transform.Find("Background").GetComponent<Image>().sprite = s;
            element.transform.Find("Background").Find("Checkmark").GetComponent<Image>().sprite = s;
            element.GetComponent<Food>().CopyFood(allSectionFoods[rand].GetComponent<Food>());
            allSectionFoods.RemoveAt(rand);
            Debug.Log("randFoodIndex: " + rand + "-- count food remaining " + allSectionFoods.Count);
        }
        // Dar una posicion aleatoria entre los hijos a los elemtos iniciales
        for (int i = 0; i < listElements.Count; i++)
        {
            var rand = Random.Range(0, numElements);
            toBuyElements[i].transform.SetSiblingIndex(rand);
        }
    }

    //public void OnClickedCheckThings()
    //{
    //    Debug.Log("Lista GM: " + GameManager.GetInstance().bakeryList.Count);
    //}

    public void CheckSelection()
    {
        int correct = 0, wrong = 0;
        //Recorrer todos los toogles
        Debug.Log(toggles.Length);
        foreach (Toggle t in toggles)
        {
            Debug.Log(listElements.Exists(s => s.GetComponent<Food>().foodName == t.GetComponent<Food>().foodName));

            //Si esta selccionado, comprobar si esta enla lista
            if (t.isOn)
            {
                //Si esta en la lista, esta bine
                if (listElements.Exists(s => s.GetComponent<Food>().foodName == t.GetComponent<Food>().foodName))
                {
                    correct++;
                    Debug.Log("Encendido y bien");
                    switch (GameManager.GetInstance().actualSection)
                    {
                        case Food.Category.bakery:
                            int index = GameManager.GetInstance().bakeryFoodList.FindIndex(s => s.GetComponent<Food>().foodName == t.GetComponent<Food>().foodName);
                            GameManager.GetInstance().bakeryFoodList[index].alreadyTaken = true;
                            break;
                        case Food.Category.fruit:
                            index = GameManager.GetInstance().fruitFoodList.FindIndex(s => s.GetComponent<Food>().foodName == t.GetComponent<Food>().foodName);
                            GameManager.GetInstance().fruitFoodList[index].alreadyTaken = true;
                            break;
                        case Food.Category.legume:
                            index = GameManager.GetInstance().legumeFoodList.FindIndex(s => s.GetComponent<Food>().foodName == t.GetComponent<Food>().foodName);
                            GameManager.GetInstance().legumeFoodList[index].alreadyTaken = true;
                            break;
                        case Food.Category.fridge:
                            index = GameManager.GetInstance().fridgeFoodList.FindIndex(s => s.GetComponent<Food>().foodName == t.GetComponent<Food>().foodName);
                            GameManager.GetInstance().fridgeFoodList[index].alreadyTaken = true;
                            break;
                        case Food.Category.fish:
                            index = GameManager.GetInstance().fishFoodList.FindIndex(s => s.GetComponent<Food>().foodName == t.GetComponent<Food>().foodName);
                            GameManager.GetInstance().fishFoodList[index].alreadyTaken = true;
                            break;
                        case Food.Category.perfumery:
                            index = GameManager.GetInstance().perfumeryFoodList.FindIndex(s => s.GetComponent<Food>().foodName == t.GetComponent<Food>().foodName);
                            GameManager.GetInstance().perfumeryFoodList[index].alreadyTaken = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    //Si no esta mal
                    wrong++;
                    Debug.Log("Encendido pero mal");
                }

            }
            else
            {
                //Si esta en la lista, esta mal
                if (listElements.Exists(s => s.GetComponent<Food>().foodName == t.GetComponent<Food>().foodName))
                {
                    wrong++;
                    Debug.Log("Apagado pero mal");
                }
                else
                {
                    //Sino esta bien
                    correct++;
                    Debug.Log("Apagado y bien");
                }

            }
        }
        //Debug de cuantos estan bien y cuantos estan mal
        Debug.Log("Bien: " + correct + ", Mal: " + wrong);

        if (correct == toggles.Length)
            lvlLoader.LoadNextLevel("TrolleyScene 1");
    }

    public void OnClickGroceryList()
    {
        groceryListCanvas.gameObject.SetActive(!groceryListCanvas.gameObject.activeSelf);
    }
}
