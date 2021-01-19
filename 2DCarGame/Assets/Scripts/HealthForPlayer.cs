using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthForPlayer : MonoBehaviour
{

    [SerializeField] int health = 100;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;
    [SerializeField] AudioClip enemyDeathSound;
    [SerializeField] [Range(0, 1)] float enemyDeathSoundVolume = 0.75f;

    [SerializeField] AudioClip playerHRSound;
    [SerializeField] [Range(0, 1)] float playerHRVolume = 0.5f;

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();

        health -= dmgDealer.GetDamage();

        if (health <= 0)
        {
            Die();
            FindObjectOfType<Level>().LoadGameOver();
        }
    }

    public int GetHealth()
    {
        return health;
    }

    private void Die()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);

        AudioSource.PlayClipAtPoint(enemyDeathSound, Camera.main.transform.position, enemyDeathSoundVolume);
        AudioSource.PlayClipAtPoint(playerHRSound, Camera.main.transform.position, playerHRVolume);

        Destroy(explosion, explosionDuration);
    }
}