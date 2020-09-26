using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    public float health = 100;
    public int worth = 50;
    [HideInInspector]
    public float speed;
    public float baseSpeed = 10f;
    public GameObject deathEffect;


    private void Start()
    {
        speed = baseSpeed;
    }
    public void takeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        PlayerStats.Money += worth;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }

    public void Slow(float slowPct)
    {
        speed = baseSpeed *  (1 -slowPct);
    }

}
