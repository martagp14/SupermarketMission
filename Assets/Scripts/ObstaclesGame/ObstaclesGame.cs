using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstaclesGame : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject sideObstacle;
    [SerializeField] private GameObject stand;
    [SerializeField] private GameObject GameOverPanel;

    private Vector3[] spawnPoints = { new Vector3(-4.5f, 1.883278f, 58.4000015f), new Vector3(0f, 1.883278f, 58.4000015f), new Vector3(4.5f, 1.883278f, 58.4000015f) };
    private Vector3[] standSpawnPoints = { new Vector3(11.0100002f, 3.72000003f, 63.7299995f), new Vector3(-10.79f, 3.72000003f, 63.7299995f) };
    //private Vector3[] standSpawnPoints = { new Vector3(-11.5100002f, 2.99039865f, 63.8699989f), new Vector3(11.7370729f, 2.99039841f, 63.8699989f) };

    private int playerLifes;
    private bool isGameOver;
    private int numObstacles;

    [SerializeField] private List<Image> hearts = new List<Image>(3);

    [SerializeField] private LevelLoader introLoader;


    // Start is called before the first frame update
    void Start()
    {
        this.GameOverPanel.SetActive(false);
        introLoader = FindObjectOfType<LevelLoader>();

        numObstacles = 0;
        isGameOver = false;
        playerLifes = hearts.Count-1;
        StartCoroutine(SpawnObjects());
        StartCoroutine(SpawnStands());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObjects()
    {
        while(!isGameOver&&numObstacles<50)
        {
            var index = Random.Range(0, 3);
            yield return new WaitForSeconds(1f);
            if(index != 1)
            {
                var rand = Random.Range(0, 2);
                if(rand == 0)
                {
                    var obs = Instantiate(sideObstacle);
                    obs.gameObject.transform.SetPositionAndRotation(spawnPoints[index], new Quaternion(-0.707106829f, 0, 0, 0.707106829f));
                }
                else
                {
                    var obs = Instantiate(obstacle);
                    obs.gameObject.transform.SetPositionAndRotation(spawnPoints[index], new Quaternion(-0.707106829f, 0, 0, 0.707106829f));
                }
            }
            else
            {
                var obs = Instantiate(obstacle);
                obs.gameObject.transform.SetPositionAndRotation(spawnPoints[index], new Quaternion(-0.707106829f, 0, 0, 0.707106829f));
            }
        }
        isGameOver = true;
        GameOver();
    }

    IEnumerator SpawnStands()
    {
        while (!isGameOver && numObstacles < 50)
        {
            yield return new WaitForSeconds(1.2f);
            var obs = Instantiate(stand);
            var obs2 = Instantiate(stand);
            obs.gameObject.transform.SetPositionAndRotation(standSpawnPoints[0], new Quaternion(-0.707106829f, 0f, 0f, 0.707106709f));
            obs2.gameObject.transform.SetPositionAndRotation(standSpawnPoints[1], new Quaternion(0f, 0.70723021f, 0.706983387f, 0f));
            obs2.GetComponent<ObstacleMovement>().speed *= -1;
        }
    }

    public void DamagePlayer()
    {
        if (!isGameOver)
        {
            Debug.Log("AUCH");
            hearts[playerLifes].gameObject.SetActive(false);
            playerLifes--;
            if (playerLifes < 0)
            {
                this.GameOver();
            }
        }
    }

    public void ObstacleReachedTheEnd()
    {
        this.numObstacles++;
        Debug.Log(numObstacles);
    }

    private void GameOver()
    {
        ObstacleMovement[] elements = FindObjectsOfType<ObstacleMovement>();
        foreach(ObstacleMovement elem in elements)
        {
            elem.SetStop(true);
        }
        Debug.Log("GameOver");
        this.isGameOver = true;
        //Pausar carrito y obstaculos
        //Mostrar canvas de GameOver para pasar a la siguiente escena
        this.GameOverPanel.SetActive(true);
    }

    public void OnClickedContinue()
    {
        introLoader.LoadNextLevel("FinalCinematic");
    }
}
