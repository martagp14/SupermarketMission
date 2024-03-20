using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("You shall not pass");
        Destroy(other.gameObject);
    }
}
