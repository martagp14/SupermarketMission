using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    //Supermarket sections
    enum Category
    {
        fruit,
        bread
    };
    enum hardnessLevel
    {
        fragile,
        mid,
        hard
    };

    //Food properties
    string foodName;
    string color;
    int price;
    Category category;
    int height;
    int width;
    int weight;
    hardnessLevel hardness;

    GameObject gameObject;

    Food()
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
}
