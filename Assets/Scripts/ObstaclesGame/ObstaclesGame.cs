using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGame : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;

    private Vector3[] spawnPoints = { new Vector3(-4.5f, 3.9000001f, 58.4000015f), new Vector3(0f, 3.9000001f, 58.4000015f), new Vector3(4.5f, 3.9000001f, 58.4000015f) };


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObjects()
    {
        for(int i=0; i<5; i++)
        {
            var index = Random.Range(0, 3);
            yield return new WaitForSeconds(1f);
            var obs = Instantiate(obstacle);
            obs.gameObject.transform.SetPositionAndRotation(spawnPoints[index], new Quaternion(-0.707106829f, 0, 0, 0.707106829f));
        }
    }
}
