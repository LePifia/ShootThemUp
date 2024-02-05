using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] Transform [] moovingPositions;
    [SerializeField] float bossMoveSpeed = 5f;
    Transform targetPosition;
    private void OnEnable()
    {
        targetPosition = moovingPositions[GetRandomPos()];
    }
    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {

        float delta = bossMoveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition.position, delta);
        
        if(transform.position == targetPosition.position)
        {
            targetPosition = moovingPositions[GetRandomPos()];
        }
    }

    private int GetRandomPos()
    {
        
        int random = Random.Range(0, moovingPositions.Length);
        
        return random;
    }
}
