using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public string playerName;
    public string playerInitial;

    public Food.Category actualSection;

    //SHOPPING LIST
    public List<string> shoppingList;
    public List<string> fruitList;
    public List<string> bakeryList;
    public List<string> legumeList;
    public List<string> fridgeList;
    public List<string> fishList;
    public List<string> perfumeryList;

    public List<Food> bakeryFoodList;


    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void LoadMain()
    {
        GameObject main = GameObject.Instantiate(Resources.Load("GameManager")) as GameObject;
        GameObject.DontDestroyOnLoad(main);
    }

    void Awake()
    {
        if (instance == null)
            instance = this;

        this.InitializeLists();
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void GoToScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    private void InitializeLists()
    {
        //bakeryList = new List<string> { "Barra Pan Perfil", "Pastas de Te Perfil" };
        //shoppingList = new List<string> { "Barra Pan Perfil", "Pastas de Te Perfil" };
        //fruitList = new List<string> { "Barra Pan Perfil", "Pastas de Te Perfil" };
        //legumeList = new List<string> { "Barra Pan Perfil", "Pastas de Te Perfil" };
        //fridgeList = new List<string> { "Barra Pan Perfil", "Pastas de Te Perfil" };
        //fishList = new List<string> { "Barra Pan Perfil", "Pastas de Te Perfil" };
        //perfumeryList = new List<string> { "Barra Pan Perfil", "Pastas de Te Perfil" };
    }
}
