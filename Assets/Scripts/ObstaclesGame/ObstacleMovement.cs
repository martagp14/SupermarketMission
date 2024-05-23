using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    [SerializeField] private float speed=10f;
    private bool stop;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!stop)
            transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    public void SetStop(bool value)
    {
        stop = value;
    }
}
