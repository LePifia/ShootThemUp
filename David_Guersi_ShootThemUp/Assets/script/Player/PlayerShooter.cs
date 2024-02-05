using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    
    //Laser

    [SerializeField] Transform laserPosition;
    [SerializeField] Transform laserPosition2;

    [SerializeField] float firingDelay = 0.5f;

    [SerializeField] List <GameObject> lasers;

    //BOMB
    [SerializeField] GameObject bombPrefab;
    [SerializeField] float bombDelay = 200f;
    [SerializeField] Transform bombPosition;
    public float bombCountDown;

    [SerializeField] List<GameObject> bombs;

    public bool isFiring;
    public bool isBombing;
    Coroutine bombCoroutine;

    Coroutine firingCoroutine;
    
    AudioManager audioManager;

    private void Awake()
    {
        bombCountDown = bombDelay;
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Update()
    {
        Firing();
        BombFiring();
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

    void BombFiring()
    {
        if (isBombing && bombCoroutine == null)
        {
            bombCoroutine = StartCoroutine(BombCooldown());
        }
        else if (!isBombing && bombCoroutine != null)
        {
            StopCoroutine(bombCoroutine);
            bombCoroutine = null;
        }
    }

    public float GetBombCooldown()
    {
        return bombDelay;
    }
    
    public float GetBombDelayement()
    {
        return bombCountDown;
    }

    IEnumerator FireContinualy()
    {

        while (true)
        {

            if (bombCountDown < bombDelay)
            {
                bombCountDown++;
            }

            GetLaser().SetActive(true);
            GetLaser2().SetActive(true);

            audioManager.PlayShootingClip();

            yield return new WaitForSeconds(firingDelay);
        }

    }

    private GameObject GetLaser()
    {
        GameObject bullet = lasers.Find(item => item.activeInHierarchy == false);
        bullet.transform.position = laserPosition.position;
        return bullet;
    }
    private GameObject GetLaser2()
    {
        GameObject bullet = lasers.Find(item => item.activeInHierarchy == false);
        bullet.transform.position = laserPosition2.position;
        return bullet;
    }

    IEnumerator BombCooldown()
    {
        while (true && bombCountDown >= bombDelay)
        {
            bombCountDown = 0;

            GetBomb().SetActive(true);

            audioManager.CasualExplosion();


            yield return new WaitForSeconds(5);
        }
    }

    private GameObject GetBomb()
    {
        GameObject bomb = bombs.Find(item => item.activeInHierarchy == false);
        bomb.transform.position = bombPosition.position;
        return bomb;
    }
}
