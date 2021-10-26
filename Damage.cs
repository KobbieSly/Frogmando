
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    
    public int health ;
    public GameObject bullet;
    public ParticleSystem playerDamageParticle;

    public AudioSource frogSounds;
    public AudioClip RecieveDamageSound;
    public AudioClip CompleteLevelSound;
    public AudioClip DeathSound;

    private void Start()
    {
        frogSounds = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
      
            TakeDamage();
        Destroy(collision.gameObject);
        
    }

    public void TakeDamage()
    {
        health -= 1;
        frogSounds.PlayOneShot(RecieveDamageSound);
        playerDamageParticle.Play();

        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        frogSounds.PlayOneShot(DeathSound);
        Destroy(gameObject);
        GameManager.FindObjectOfType<GameManager>().GameOver();
    }
}
