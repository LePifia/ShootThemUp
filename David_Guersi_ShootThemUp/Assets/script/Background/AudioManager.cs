using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance { get; private set; }
    //shooting
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    //explosions
    [SerializeField] AudioClip casualExplosion;
    [SerializeField] [Range(0f, 1f)] float casualExplosionVolume;

    //PlayerHitted
    [SerializeField] AudioClip playerExplosion;
    [SerializeField] [Range(0f, 1f)] float explosionVolume;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void CasualExplosion()
    {
        PlayClip(casualExplosion, casualExplosionVolume);
    }

    public void PlayerExplosion()
    {
        PlayClip(playerExplosion, explosionVolume);
        
    }

    void PlayClip(AudioClip clip, float volume)
    {
        Vector3 cameraPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
    }
}
