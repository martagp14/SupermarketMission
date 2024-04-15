using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstaclesGame : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;

    private Vector3[] spawnPoints = { new Vector3(-4.5f, 3.9000001f, 58.4000015f), new Vector3(0f, 3.9000001f, 58.4000015f), new Vector3(4.5f, 3.9000001f, 58.4000015f) };

    private int playerLifes;
    private bool isGameOver;
    private int numObstacles;

    [SerializeField] private List<Image> hearts = new List<Image>(3);

    // Start is called before the first frame update
    void Start()
    {
        numObstacles = 0;
        isGameOver = false;
        playerLifes = hearts.Count;
        StartCoroutine(SpawnObjects());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObjects()
    {
        while(!isGameOver)
        {
            var index = Random.Range(0, 3);
            yield return new WaitForSeconds(1f);
            var obs = Instantiate(obstacle);
            obs.gameObject.transform.SetPositionAndRotation(spawnPoints[index], new Quaternion(-0.707106829f, 0, 0, 0.707106829f));
        }
    }

    public void DamagePlayer()
    {
        Debug.Log("AUCH");
        hearts[playerLifes].gameObject.SetActive(false);
        playerLifes--;
        if (playerLifes == 0)
        {
            this.GameOver();
        }
    }

    public void ObstacleReachedTheEnd()
    {
        this.numObstacles++;
    }

    private void GameOver()
    {
        //Pausar carrito y obstaculos
        //Mostrar canvas de GameOver para pasar a la siguiente escena
    }
}
