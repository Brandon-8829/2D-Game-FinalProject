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
    public bool isFlipped = false;

    public Player playerScript;
    private Transform targetPlayer;
 

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

    public void flip()
    {
        Vector3 flipp = transform.localScale;
        flipp.z *= -1f;

        if (transform.position.x > targetPlayer.position.x && isFlipped)
        {
            transform.localScale = flipp;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < targetPlayer.position.x && !isFlipped)
        {
            transform.localScale = flipp;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    // Update is called once per frame
    void Update() {
        flip();
        //move to player unless we are at stop distance
        if (Vector2.Distance(transform.position, targetPlayer.position) > 4) {
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, moveSpeed * Time.deltaTime);
        }
        else // take health away
        {
            playerScript.PlayerTakeDamage(2);
        }  
    }

}
