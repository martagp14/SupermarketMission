using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodResourcesManager : MonoBehaviour
{

    public List<Sprite> bakery = new List<Sprite>();
    public List<Sprite> fish = new List<Sprite>();
    public List<Sprite> legume = new List<Sprite>();
    public List<Sprite> fridge = new List<Sprite>();
    public List<Sprite> fruits = new List<Sprite>();
    public List<Sprite> perfumery = new List<Sprite>();

    [Header("Foods")]
    public List<Food> bakeryFoods = new List<Food>();
    public List<Food> fruitsFoods = new List<Food>();
    public List<Food> legumeFoods = new List<Food>();
    public List<Food> fridgeFoods = new List<Food>();
    public List<Food> fishFoods = new List<Food>();
    public List<Food> perfumeryFoods = new List<Food>();

    public int[] numFoodAccumulative = new int[6] { 0, 0, 0, 0, 0, 0 };

    public void InitializeCount()
    {
        numFoodAccumulative[5] = perfumeryFoods.Count;
        numFoodAccumulative[4] = numFoodAccumulative[5] + fishFoods.Count;
        numFoodAccumulative[3] = numFoodAccumulative[4] + fridgeFoods.Count;
        numFoodAccumulative[2] = numFoodAccumulative[3] + legumeFoods.Count;
        numFoodAccumulative[1] = numFoodAccumulative[2] + fruitsFoods.Count;
        numFoodAccumulative[0] = numFoodAccumulative[1] + bakeryFoods.Count;
    }
}
