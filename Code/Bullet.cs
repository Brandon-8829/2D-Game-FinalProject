/*
 * Script for the Bullet. Holds all functions and variables realative to the bullet.
 * 
 * Author: Brandon Harris
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    // other variables
    public float speed = 10f;
    public int bulletDmg = 25;

    // Ref to other scripts
    public Rigidbody2D rb;
    public Controller2D controller;
    public Player playerScript;

    // Use this for initialization
    void Start () {
        
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //check to see if bullet has hit an enemy.
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        //if an enemy is hit
        if(enemy != null)
        {
            enemy.TakeDamage(bulletDmg);
        }

        PatrolEnemy penemy = hitInfo.GetComponent<PatrolEnemy>();
        //if an enemy is hit
        if (penemy != null)
        {
            penemy.TakeDamage(bulletDmg);
        }

        Boss boss = hitInfo.GetComponent<Boss>();
        //if an enemy is hit
        if (boss != null)
        {
            boss.TakeDamage(bulletDmg);
        }

        Player player = hitInfo.GetComponent<Player>();
        //if an player is hit
        /*if (player != null)
        {
            player.PlayerTakeDamage(bulletDmg);
        }
        */
        Destroy(gameObject);
    }
	
	
}
