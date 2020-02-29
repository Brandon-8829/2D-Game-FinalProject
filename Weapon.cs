using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletPrefab;
	
	// Update is called once per frame
	void Update () {
        //get input
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        //all shooting logic goes here.
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
