/*
 * A script for the enemy
 * 
 * Author: Brandon Harris
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {

    public float moveSpeed = 4;
    public float stopDist = 3;
    public int health = 100;

    private Transform targetPlayer;
    //public GameObject deathEffect;

    void Start() {
        //find the player
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update() {
        //move to player unless we are at stop distance
        if (Vector2.Distance(transform.position, targetPlayer.position) > 2) {
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, moveSpeed * Time.deltaTime);
            // take health away
        }
        
    }

}
