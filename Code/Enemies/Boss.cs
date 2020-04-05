/*
 * Script for the Boss. Holds all functions and variables realative to the boss.
 * 
 * Author: Brandon Harris
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour {

   
    public int health = 2000;
    

    public bool isFlipped = false;
    public bool movingRight = false;

    public Player playerScript;
    private Transform targetPlayer;
    public HealthBar healthBar;
    public Boss_run boss_run;


    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    /*
     * A function that takes an int and removes that from object health. Updates health bar with new number
     * 
     */
    public void TakeDamage(int dmg)
    {
        health -= dmg;
        healthBar.setHealth(health);
        if (health <= 0)
        {
            Die();
            SceneManager.LoadScene("Win");
        } 
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        SceneManager.LoadScene("Win");
    }

    // Update is called once per frame
    
    /*
     * Flips the object based on where the player is.
     */
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

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerScript.PlayerTakeDamage(50);
        }
    }

}

