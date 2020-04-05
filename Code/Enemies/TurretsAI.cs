/*
 * Script for the turretAI. Holds all functions and variables realative to the turretAi.
 * 
 * Author: Brandon Harris
 * 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretsAI : MonoBehaviour
{

    public float speed = -10f;
    public float time = 3f;
    private float timeStore = 3f;

    public int bulletDmg = 25;

    public Player playerScript;
    public Transform firePoint;
    public GameObject bulletPrefab;


    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            Shoot(); //shoot every 3 seconds
            time = timeStore;
        }
        //Shoot();
    }

    //all shooting logic goes here.
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}