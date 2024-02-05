using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] int health = 5;
    [SerializeField] ParticleSystem explotion;

    [SerializeField] ScreenShaker cameraShake;

    [SerializeField] int scoreRested = -10;

    //scoreManagement
    [SerializeField] GameObject Scorer;
    ScoreKeeper scoreKeeper;
    MainMenu mainMenu;

    //Audio
    AudioManager audioManager;

    private void Awake()
    {
        mainMenu = FindObjectOfType<MainMenu>();

        audioManager = FindObjectOfType<AudioManager>();

        scoreKeeper = FindObjectOfType<ScoreKeeper>();

        cameraShake = Camera.main.GetComponent<ScreenShaker>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            DIE();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            //take damage

            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();

            ExplotionEffect();

            audioManager.PlayerExplosion();

            scoreKeeper.ModifyScore(scoreRested);

            //tell damage dealer that it hitted anything
            cameraShake.Play();
        }
    }
    void TakeDamage (int Damage)
    {
        health -= Damage;

        if (health <= 0)
        {
            
            DIE();
        }
    }

    void DIE()
    {
        gameObject.SetActive(false);
        ExplotionEffect();
        audioManager.PlayerExplosion();

        

        mainMenu.HighScoresLoader();
    }

    void ExplotionEffect()
    {
        if (explotion != null)
        {
            ParticleSystem Instance = Instantiate(explotion, transform.position, Quaternion.identity);
            Destroy(Instance.gameObject, Instance.main.duration + Instance.main.startLifetime.constantMax);
        }
    }

    public int GetHealth()
    {
        return health;
    }

    
}
