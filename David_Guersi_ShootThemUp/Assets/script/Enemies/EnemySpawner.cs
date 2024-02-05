using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }
    public List<WaveConfig> waveConfigs;
    WaveConfig waveConfig;
    [SerializeField] float timeBetweenWaves = 1;

    [SerializeField] bool isLooping;
    
    WaveConfig currentWave;
    ScoreKeeper scoreKeeper;
    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
       StartCoroutine( SpawnEnemyWaves());
    }

    public WaveConfig GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfig wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWayPoint().position, Quaternion.identity, transform);

                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
                
                scoreKeeper.ModifyCurrentWave(1);
            }
        }
        while (isLooping);
    }
}
