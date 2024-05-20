using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupermarketMap : MonoBehaviour
{
    [SerializeField]
    private LevelLoader lvlLoader;

    [SerializeField]
    private GameObject groceryListCanvas;

    // Start is called before the first frame update
    void Start()
    {
        lvlLoader = FindObjectOfType<LevelLoader>();
        groceryListCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickSection(string sectionName)
    {
        //establecer section en GM
        Food.Category section;
        switch (sectionName)
        {
            case "Perfumeria":
                section = Food.Category.perfumery;
                break;
            case "Legumbre":
                section = Food.Category.legume;
                break;
            case "Pescaderia":
                section = Food.Category.fish;
                break;
            case "Panaderia":
                section = Food.Category.bakery;
                break;
            case "Fruteria":
                section = Food.Category.fruit;
                break;
            case "Nevera":
                section = Food.Category.fridge;
                break;
            case "Cajas":
                section = Food.Category.cashier;
                GameManager.GetInstance().GoToScene("ObstaclesGame");
                break;
            default:
                section = Food.Category.bakery;
                break;
        }
        GameManager.GetInstance().actualSection = section;
        //ZIr  s escena seccion
        lvlLoader.LoadNextLevel("SupermarketSection");
    }

    public void ShowAndHideList()
    {
        groceryListCanvas.SetActive(!groceryListCanvas.activeSelf);
    }
}
