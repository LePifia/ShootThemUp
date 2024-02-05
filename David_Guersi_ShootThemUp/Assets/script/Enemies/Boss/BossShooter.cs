using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooter : MonoBehaviour
{
    [Header("General")]

    [SerializeField] BulletMovement enemyLaser;
    [SerializeField] List<GameObject> lasers;

    private bool isFiring = true;

    [SerializeField] Transform [] shootingPositions;

    Coroutine firingCoroutine;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();

        isFiring = true;
    }

    void Update()
    {
        Firing();
    }

    void Firing()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinualy());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }

    }

    IEnumerator FireContinualy()
    {

        while (true)
        {
            int random = Random.Range(0, shootingPositions.Length);
            GetLaser(random).SetActive(true);
            audioManager.PlayShootingClip();
            
            yield return new WaitForSeconds(0.25f);
        }

    }

    private GameObject GetLaser(int random)
    {
        GameObject bullet = lasers.Find(item => item.activeInHierarchy == false);
        
        bullet.transform.position = shootingPositions[random].position;
        return bullet;
    }

}

