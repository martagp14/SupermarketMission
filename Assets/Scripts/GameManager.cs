using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public string playerName;
    public string playerInitial;
    public int playerAge;
    public string playerGender;
    public bool daltonicUser = false;

    public bool[] firstTimeScene = { true, true, true, true, true, true, true };

    public float currentSpentTime = 0f;
    public float groceryListSpentTime = 0f;
    public float SupermarketMapSpentTime = 0f;
    public float trolleySpentTime = 0f;
    public float[] minigamesSpentTime = {0f,0f,0f,0f,0f,0f};

    public int numWrongPickedItems = 0;
    public int numElementsCorrectPositionTrolley = 0;
    public int numElementsModeratePositionTrolley = 0;
    public int numElementsWrongPositionTrolley = 0;

    public Food.Category actualSection;
    public Food.Category[] sectionDistribution = new Food.Category[6];

    public Food[,] trolleyStatus;       //8x3
    //public Food[,,] trolleyStatus;       //4x2x3
    //public GameObject[,,] trolleyStatusGO;

    //SHOPPING LIST
    //public List<string> shoppingList;
    //public List<string> fruitList;
    //public List<string> bakeryList;
    //public List<string> legumeList;
    //public List<string> fridgeList;
    //public List<string> fishList;
    //public List<string> perfumeryList;

    public List<Food> bakeryFoodList;
    public List<Food> fruitFoodList;
    public List<Food> legumeFoodList;
    public List<Food> fridgeFoodList;
    public List<Food> fishFoodList;
    public List<Food> perfumeryFoodList;

    public List<Food> pickedItems;


    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void LoadMain()
    {
        GameObject main = GameObject.Instantiate(Resources.Load("GameManager")) as GameObject;
        GameObject.DontDestroyOnLoad(main);
    }

    void Awake()
    {
        if (instance == null) {
            instance = this;
            this.InitializeGame();
        }
        else
        {
            Destroy(this.gameObject);
        }

        //this.InitializeLists();
    }

    void InitializeGame()
    {
        trolleyStatus = new Food[8, 3];
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void GoToScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void SavePlayerData(string name, int age, string gender)
    {
        playerName = name;
        playerInitial = playerName.Substring(0, 1).ToUpper();
        playerAge = age;
        playerGender = gender;
    }

}
