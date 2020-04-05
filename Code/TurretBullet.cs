/*
 * Script for the turret bullet. Holds all functions and variables realative to the turret bullet.
 * 
 * Author: Brandon Harris
 * 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour {

    // other variables
    public float speed = 10f;
    public int bulletDmg = 25;

    // Ref to other scripts
    public Rigidbody2D rb;
    public Controller2D controller;
    public Player playerScript;

    // Use this for initialization
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        Player player = hitInfo.GetComponent<Player>();
        //if an player is hit
        if (player != null)
        {
            player.PlayerTakeDamage(bulletDmg);
        }

        Destroy(gameObject);
    }
}
