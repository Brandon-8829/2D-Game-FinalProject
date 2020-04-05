/*
 * Script for the patrolEnemy. Holds all functions and variables realative to the patrolEnemy.
 * 
 * Author: Brandon Harris
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour {


    public float speed;
    public int health = 200;
    private bool movingRight = true;

    public Player playerScript;
    public Transform groundDetect;
    private Transform targetPlayer;
    
    // Use this for initialization
    void Start () {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right*speed*Time.deltaTime);

        RaycastHit2D ground = Physics2D.Raycast(groundDetect.position, Vector2.down, 2f);
        
        //ground detection
        if (ground.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        //if the enemy is too close to the player, the player takes damage.
        if (Vector2.Distance(transform.position, targetPlayer.position) < 3)
        {
            playerScript.PlayerTakeDamage(5);
        }

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


}
