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
    public List<Food> fishFoods = new List<Food>();
    public List<Food> legumeFoods = new List<Food>();
    public List<Food> fridgeFoods = new List<Food>();
    public List<Food> fruitsFoods = new List<Food>();
    public List<Food> perfumeryFoods = new List<Food>();
}
