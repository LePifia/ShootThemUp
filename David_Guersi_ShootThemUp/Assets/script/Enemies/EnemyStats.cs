using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] int health = 5;
    int startingHealth;
    [SerializeField] ParticleSystem explotion;
    [SerializeField] int scoreGiven = 5;



    AudioManager audioManager;
    ScoreKeeper scoreKeeper;
    private void Awake()
    {
        startingHealth = health;
        audioManager = FindObjectOfType<AudioManager>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void OnEnable()
    {
        health = startingHealth; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            //take damage

            TakeDamage(damageDealer.GetDamage());
            audioManager.CasualExplosion();
            ExplotionEffect();

            //tell damage dealer that it hitted anything
        }
    }
    public void TakeDamage(int Damage)
    {
        health -= Damage;


        if (health <= 0)
        {
            DIE();
        }
    }

    void ExplotionEffect()
    {
        if (explotion != null)
        {
            ParticleSystem Instance = Instantiate(explotion, transform.position, Quaternion.identity);
            Destroy(Instance.gameObject, Instance.main.duration + Instance.main.startLifetime.constantMax);
        }
    }

    void DIE()
    {

        scoreKeeper.ModifyScore(scoreGiven);

        gameObject.SetActive(false);

        ExplotionEffect();
        audioManager.CasualExplosion();
    }


}