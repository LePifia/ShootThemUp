using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;

    //Borders
    private float paddingLeft;
    private float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    Vector2 minBounds;
    Vector2 maxBounds;

    Camera mainCam;

    [SerializeField] float moveSpeed;

    //shooter
    PlayerShooter shooter;


    private void Awake()
    {

        shooter = gameObject.GetComponent<PlayerShooter>();


        Bounds();
        paddingRight = gameObject.GetComponent<SpriteRenderer>().size.x / 8;
        paddingLeft = paddingRight;
        
    }
    void Update()
    {
        Movement();
    }
    void OnMove(InputValue value)
    {
       rawInput =  value.Get<Vector2>();
    }

    void Movement()
    {
        Vector2 delta = rawInput * Time.deltaTime * moveSpeed;

        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);

        transform.position = newPos;
    }

    void Bounds()
    {
        mainCam = Camera.main;
        minBounds = mainCam.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCam.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }

    void OnBomb(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isBombing = value.isPressed;
        }
        
    }
}
