using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShaker : MonoBehaviour
{
    [SerializeField] float shakeDuration = 0.75f;
    [SerializeField] float shakeMagnitude = 0.5f;

    Vector3 initialPos;
    void Start()
    {
        initialPos = transform.position;
    }


    public void Play()
    {
        StartCoroutine(StartShake());
    }
   
    IEnumerator StartShake()
    {
        float elapsedTime = 0;
        while (elapsedTime < shakeDuration)
        {
            transform.position = initialPos + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }


        transform.position = initialPos;
    }
}
