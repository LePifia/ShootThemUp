using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPool : MonoBehaviour
{
    [SerializeField] List<GameObject> lasers;

    public GameObject GetEnemyLaser(Transform shootingPoint)
    {
        GameObject bullet = lasers.Find(item => item.activeInHierarchy == false);
        bullet.transform.position = shootingPoint.position;
        bullet.SetActive(true);
        return bullet;
    }
}
