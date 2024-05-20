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
        perfumery,
        cashier
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
    public Sprite sprite;

    [SerializeField]
    public bool alreadyTaken;

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
        this.alreadyTaken = false;
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
        this.alreadyTaken = false;

    }

    public Food(Food food)
    {
        this.foodName = food.foodName;
        this.color = food.color;
        this.price = food.price;
        this.category = food.category;
        this.height = food.height;
        this.width = food.width;
        this.weight = food.weight;
        hardness = food.hardness;
        this.alreadyTaken = false;

    }

    public void CopyFood(Food food)
    {
        this.foodName = food.foodName;
        this.color = food.color;
        this.price = food.price;
        this.category = food.category;
        this.height = food.height;
        this.width = food.width;
        this.weight = food.weight;
        hardness = food.hardness;
        this.sprite = food.sprite;
        this.alreadyTaken = false;
    }

    public Food Clone()
    {
        Food clone = new Food
        {
            foodName = this.foodName,
            color = this.color,
            price = this.price,
            category = this.category,
            height = this.height,
            width = this.width,
            weight = this.weight,
            hardness = this.hardness,
            sprite = this.sprite,
            alreadyTaken = this.alreadyTaken
        };

        return clone;
    }
}
