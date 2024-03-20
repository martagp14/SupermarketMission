using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrolleyMovement : MonoBehaviour
{

    private ObstaclesGame miniGameManager;
    // Start is called before the first frame update
    void Start()
    {
        miniGameManager = FindObjectOfType<ObstaclesGame>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Movement of the trolley using arrow or mouse
}
