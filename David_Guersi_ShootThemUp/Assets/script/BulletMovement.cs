using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 10;

    [SerializeField] bool playerBullet = true;
    Rigidbody2D rb;


    private void Awake()
    {
       gameObject.GetComponent<PlayerShooter>();
       rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       

        if (playerBullet == true)
        {
            rb.velocity = transform.up * projectileSpeed;
        }
        else
        {
            rb.velocity = transform.up * -1 * projectileSpeed;
        }

        if (transform.position.y > 9 || transform.position.y < -9)
        {
            gameObject.SetActive(false);
        }
        
    }


}
