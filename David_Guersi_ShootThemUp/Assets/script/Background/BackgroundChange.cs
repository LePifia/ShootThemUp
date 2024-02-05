using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
    ScoreKeeper scoreKeeper;

    [SerializeField] float currentWave;

    [SerializeField] GameObject[] backGrounds;

    bool background;

    int backgroundIndex = 0;

    Coroutine ChangeBackgroundCourutine;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
        GameObject first = Instantiate(backGrounds[0], gameObject.transform.position, Quaternion.identity, transform);

        Destroy(first, 150f);

        StartCoroutine(ChangEBackGround());
    }

    // Update is called once per frame
    void Update()
    {
        currentWave =  scoreKeeper.GetWave();
        
    }

    IEnumerator ChangEBackGround()
    {

        if (currentWave % 15 == 0 && currentWave != 0)
        {
           Debug.Log("Changed");

                
           GameObject instance = Instantiate(backGrounds[backgroundIndex], gameObject.transform.position, Quaternion.identity, transform);

           Destroy(instance, 150f);

           backgroundIndex++;

            if (backgroundIndex == backGrounds.Length)
            {
                backgroundIndex = 0;
            }

        }
        yield return new WaitForSeconds(3f);

        StartCoroutine(ChangEBackGround());

    }
}
