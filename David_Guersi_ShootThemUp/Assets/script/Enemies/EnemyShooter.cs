using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyShooter : MonoBehaviour
{
    [Header("General")]

    [SerializeField] BulletMovement enemyLaser;

    public bool isFiring = true;

    Coroutine firingCoroutine;
    AudioManager audioManager;
    EnemyBulletPool enemyBulletPool;

    private void Awake()
    {
        enemyBulletPool = FindObjectOfType<EnemyBulletPool>();
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
            enemyBulletPool.GetEnemyLaser(transform);
            audioManager.PlayShootingClip();

            yield return new WaitForSeconds(Random.Range(0.5f,2));
        }

    }

}
