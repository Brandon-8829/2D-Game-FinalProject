/*
 * Script for the Weapon. Holds all functions and variables realative to the Weapon.
 * 
 * Author: Brandon Harris
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletPrefabRight, bulletPrefabLeft;
    public Player playerScript;
    public Animator animator;

    // Update is called once per frame.
    void Update () {
        //get input
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("isShooting", true);
            if (playerScript.facing == true) // call back to player script and see which way the player is currently facing (left or right).
            {
                ShootRight();
            }
            else
            {
                ShootLeft();
            }
            
        }

        animator.SetBool("isShooting", false);
    }


    /*
     * The funcitons below are used to create the bullets depending on which way your character is facing.
     * 
     */

    void ShootRight()
    {
        //all shooting logic goes here.

        Instantiate(bulletPrefabRight, firePoint.position, firePoint.rotation);
    }

    void ShootLeft()
    {
        //all shooting logic goes here.

        Instantiate(bulletPrefabLeft, firePoint.position, firePoint.rotation);
    }
}
