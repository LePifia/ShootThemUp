using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deployment : MonoBehaviour
{
    [SerializeField] List<GameObject> asteroids;
    [SerializeField] float respawn = 1.5f;
    public static Deployment Instance { get; private set; }
    Camera mainCam;
    Vector2 minBounds;
    Vector2 maxBounds;

    void Start()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        Bounds();
        
        StartCoroutine(AsteroidRain());
    }

    void spawnerOfAsteroids()
    {
        
        respawn = (Random.Range(0.75f, 1.5f));
        GetAsteroid().SetActive(true);
        //Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)], new Vector3(Random.Range (minBounds.x + 0.75f, maxBounds.x - 0.75f), 7.5f , 0), Quaternion.identity);
    }

    private GameObject GetAsteroid()
    {
        GameObject asteroid = asteroids.Find(item => item.activeInHierarchy == false);
        asteroid.transform.position = new Vector3( Random.Range(minBounds.x + 0.75f, maxBounds.x - 0.75f), 9, 0);
        return asteroid;
    }

    IEnumerator AsteroidRain()
    {
        spawnerOfAsteroids();

        yield return new WaitForSeconds(respawn);

        StartCoroutine(AsteroidRain());

    }

    void Bounds()
    {
        mainCam = Camera.main;
        minBounds = mainCam.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCam.ViewportToWorldPoint(new Vector2(1, 1));
    }
}
