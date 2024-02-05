using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] float speed = 3;
    Rigidbody2D rb;
    [SerializeField]float rotationSpeed = 45;
    Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rotationSpeed = Random.Range(45, 95);

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {

        
        rb.velocity = transform.up * -1 * speed;
        

        if (transform.position.y > 9 || transform.position.y < -9)
        {
            gameObject.SetActive(false);
        }

    }
}
