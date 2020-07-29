using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public sealed class AsteroidGameController : MonoBehaviour
{
    public GameObject shipPrefab;
    public List<GameObject> asteroids = new List<GameObject>();
    public Camera mainCamera;
    public Camera gameCamera;
    public GameObject gameText;

    private bool gameActive;
    private GameObject currentShip;
    List<GameObject> gameObjects = new List<GameObject>();

    public static AsteroidGameController Instance;

    IEnumerator SpawnAsteroidsRoutine()
    {
        while (gameActive)
        {
            if(currentShip == null)
                break;

            var position = (Random.insideUnitSphere * 80) + currentShip.transform.position;

            GameObject asteroid = Instantiate(asteroids[Random.Range(0, asteroids.Count)], new Vector3(position.x, position.y, 0), Quaternion.identity);
            var direction = currentShip.transform.position - asteroid.transform.position;
            asteroid.GetComponent<Rigidbody2D>().AddForce(direction.normalized * 20, ForceMode2D.Impulse);
            gameObjects.Add(asteroid);
            yield return new WaitForSeconds(3);
        }
    }

    IEnumerator GameOverRoutine()
    {
        yield return new WaitForSeconds(3);
        
        gameText.SetActive(true);
        mainCamera.enabled = true;
        gameCamera.enabled = false;
        gameActive = false;

        for (int i = 0; i < gameObjects.Count; i++)
        {
            if (gameObjects[i] == null)
                continue;
            
            Destroy(gameObjects[i]);
        }

        gameObjects.Clear();
    }

    void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) && !gameActive)
        {
            StartGame();
        }
    }

    public void AddToGameObjets(GameObject newGameObject)
    {
        gameObjects.Add(newGameObject);
    }

    public void StartGame()
    {
        gameText.SetActive(false);
        mainCamera.enabled = false;
        gameCamera.enabled = true;
        gameActive = true;
        currentShip = Instantiate(shipPrefab, Vector3.zero, Quaternion.identity);
        StartCoroutine(SpawnAsteroidsRoutine());
    }

    public void GameOver()
    {
        StartCoroutine(GameOverRoutine());
    }

    public void SetGameText(bool status)
    {
        gameText.SetActive(status);
    }
}
