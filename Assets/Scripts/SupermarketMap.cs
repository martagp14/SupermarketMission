using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupermarketMap : MonoBehaviour
{
    [SerializeField]
    private LevelLoader lvlLoader;
    private ExplanationCanvas explanationCanvas;

    [SerializeField]
    private GameObject groceryListCanvas;

    [SerializeField] GameObject[] sections = new GameObject[7];
    [SerializeField] private Sprite[] sectionImages = new Sprite[6];

    // Start is called before the first frame update
    void Start()
    {
        lvlLoader = FindObjectOfType<LevelLoader>();
        explanationCanvas = FindObjectOfType<ExplanationCanvas>();
        explanationCanvas.SetTextChecking(2,"Ya es hora de entrar en acción. Elige en este mapa que sección quieres visitar. \nRecuerda consultar la lista de objetivos pulsando el botón " +
                    "en la esquina de la izquierda para ver que nos queda pendiente.");

        groceryListCanvas.SetActive(false);
        MapGeneration();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickSection(Food.Category category)
    {
        ////establecer section en GM
        //Food.Category section;
        //switch (sectionName)
        //{
        //    case "Perfumeria":
        //        section = Food.Category.perfumery;
        //        break;
        //    case "Legumbre":
        //        section = Food.Category.legume;
        //        break;
        //    case "Pescaderia":
        //        section = Food.Category.fish;
        //        break;
        //    case "Panaderia":
        //        section = Food.Category.bakery;
        //        break;
        //    case "Fruteria":
        //        section = Food.Category.fruit;
        //        break;
        //    case "Nevera":
        //        section = Food.Category.fridge;
        //        break;
        //    case "Cajas":
        //        section = Food.Category.cashier;
        //        GameManager.GetInstance().GoToScene("ObstaclesGame");
        //        break;
        //    default:
        //        section = Food.Category.bakery;
        //        break;
        //}

        GameManager.GetInstance().actualSection = category;
        if(category == Food.Category.cashier)
            GameManager.GetInstance().GoToScene("ObstaclesGame");

        //ZIr  s escena seccion
        lvlLoader.LoadNextLevel("SupermarketSection");
    }

    public void ShowAndHideList()
    {
        groceryListCanvas.SetActive(!groceryListCanvas.activeSelf);
    }

    void MapGeneration()
    {
        //Recorrer las sections
        //Asignar un aaleatoria de la lista de secciones y quitarla de la lista
        //Ponerle la imagen correspondiente
        //Ponerle el valor correspodiente al dropfield
        Food.Category[] order = GameManager.GetInstance().sectionDistribution;

        for (int i = 0; i < order.Length; i++)
        {
            Debug.Log(order.Length);

            switch (order[i])
            {
                case Food.Category.bakery:
                    sections[i].GetComponent<Image>().sprite = sectionImages[0];
                    sections[i].GetComponent<Button>().onClick.AddListener(delegate { OnClickSection(Food.Category.bakery); });
                    break;
                case Food.Category.fruit:
                    sections[i].GetComponent<Image>().sprite = sectionImages[1];
                    sections[i].GetComponent<Button>().onClick.AddListener(delegate { OnClickSection(Food.Category.fruit); });
                    break;
                case Food.Category.legume:
                    sections[i].GetComponent<Image>().sprite = sectionImages[2];
                    sections[i].GetComponent<Button>().onClick.AddListener(delegate { OnClickSection(Food.Category.legume); });
                    break;
                case Food.Category.fridge:
                    sections[i].GetComponent<Image>().sprite = sectionImages[3];
                    sections[i].GetComponent<Button>().onClick.AddListener(delegate { OnClickSection(Food.Category.fridge); });
                    break;
                case Food.Category.fish:
                    sections[i].GetComponent<Image>().sprite = sectionImages[4];
                    sections[i].GetComponent<Button>().onClick.AddListener(delegate { OnClickSection(Food.Category.fish); });
                    break;
                case Food.Category.perfumery:
                    sections[i].GetComponent<Image>().sprite = sectionImages[5];
                    sections[i].GetComponent<Button>().onClick.AddListener(delegate { OnClickSection(Food.Category.perfumery); });
                    break;
                default:
                    Debug.Log("No existe esa categoria: " + order[i]);
                    break;
            }
            
        }
        sections[6].GetComponent<Button>().onClick.AddListener(delegate { OnClickSection(Food.Category.cashier); });

    }
}
