using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BombGrow : MonoBehaviour
{
    float lightgrow;
    float originalLightFloat;
    float delay = 0.5f;
    [SerializeField]GameObject Light;
    LayerMask enemyLayer;
    [SerializeField] ParticleSystem explotion;
    [SerializeField] int bombDamage = 10;

    private void Awake()
    {
        originalLightFloat = Light.GetComponent<Light2D>().pointLightOuterRadius;
        lightgrow = Light.GetComponent<Light2D>().pointLightOuterRadius;
        enemyLayer = LayerMask.GetMask("Enemy");
    }


    private void OnEnable()
    {
        StartCoroutine(LightGrow());
    }

    private void Update()
    {    
        lightgrow = Light.GetComponent<Light2D>().pointLightOuterRadius;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, lightgrow);
    }


    IEnumerator LightGrow()
    {
        yield return new WaitForSeconds(delay);
        lightgrow++;
        Debug.Log("explotion");
        Collider2D[] enemyhitted = Physics2D.OverlapCircleAll(gameObject.transform.position, lightgrow, enemyLayer);
        Light.GetComponent<Light2D>().pointLightOuterRadius = lightgrow;

        ExplotionEffect();

        //DamageEnemies
        foreach (Collider2D enemy in enemyhitted)
        {
            enemy.GetComponent<EnemyStats>().TakeDamage(bombDamage);
        }
        StartCoroutine(LightDecrease());
    }

    IEnumerator LightDecrease()
    {
        yield return new WaitForSeconds(delay);
        lightgrow = originalLightFloat;
        Light.GetComponent<Light2D>().pointLightOuterRadius = lightgrow;

        StartCoroutine(LightGrow());
    }

    void ExplotionEffect()
    {
        if (explotion != null)
        {
            ParticleSystem Instance = Instantiate(explotion, transform.position, Quaternion.identity);
            Destroy(Instance.gameObject, Instance.main.duration + Instance.main.startLifetime.constantMax);
        }
    }
}
