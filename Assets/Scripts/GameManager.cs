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

    public Food.Category actualSection;
    public Food.Category[] sectionDistribution = new Food.Category[6];

    public Food[,,] trolleyStatus;
    //public GameObject[,,] trolleyStatusGO;

    //SHOPPING LIST
    public List<string> shoppingList;
    public List<string> fruitList;
    public List<string> bakeryList;
    public List<string> legumeList;
    public List<string> fridgeList;
    public List<string> fishList;
    public List<string> perfumeryList;

    public List<Food> bakeryFoodList;
    public List<Food> fruitFoodList;
    public List<Food> legumeFoodList;
    public List<Food> fridgeFoodList;
    public List<Food> fishFoodList;
    public List<Food> perfumeryFoodList;


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
        trolleyStatus = new Food[4, 2, 3];
        //trolleyStatusGO = new GameObject[4, 2, 3];
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
