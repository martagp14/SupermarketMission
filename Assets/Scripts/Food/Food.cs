using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    //Supermarket sections
    public enum Category
    {
        fruit,
        bakery,
        legume,
        fridge,
        fish,
        perfumery
    };
    public enum hardnessLevel
    {
        fragile,
        mid,
        hard
    };

    //Food properties
    [SerializeField]
    public string foodName;// { get; private set; }
    [SerializeField]
    public string color; // { get; private set; }
    [SerializeField]
    public int price; // { get; private set; }
    [SerializeField]
    public Category category; // { get; private set; }
    [SerializeField]
    public int height; // { get; private set; }
    [SerializeField]
    public int width; // { get; private set; }
    [SerializeField]

    public int weight; // { get; private set; }
    [SerializeField]
    public hardnessLevel hardness; // { get; private set; }

    GameObject gameObject;

    [SerializeField]
    Sprite sprite;

    public Food()
    {
        this.foodName = "";
        this.color = "";
        this.price = 0;
        this.category = Category.fruit;
        this.height = 1;
        this.width = 1;
        this.weight = 1;
        hardness = hardnessLevel.mid;
    }

    public Food(string foodName, string color, int price, Category category, int height, int width, int weight, hardnessLevel hardnesslevel)
    {
        this.foodName = foodName;
        this.color = color;
        this.price = price;
        this.category = category;
        this.height = height;
        this.width = width;
        this.weight = weight;
        hardness = hardnesslevel;
    }
}
