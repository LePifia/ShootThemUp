using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] Transform pathPrefab;

    public GameObject[] DifferentAliens;
    public List<GameObject> enemyPrefabs;
    

    [SerializeField] float enemyMoveSpeed = 5f;

    [SerializeField] float timeBetweenEnemySpawn = 0.5f;
    [SerializeField] float spawnTimeVariant = 0;
    [SerializeField] float minimunSpawnTime = 0.2f;

    
    public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> wayPoints = new List<Transform>();
        foreach(Transform child in pathPrefab)
        {
            wayPoints.Add(child);
        }
        return wayPoints;
    }
    public float GetSpeed()
    {
        return enemyMoveSpeed;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawn - spawnTimeVariant, timeBetweenEnemySpawn + spawnTimeVariant);
        return Mathf.Clamp(spawnTime, minimunSpawnTime, float.MaxValue);
    }
}
