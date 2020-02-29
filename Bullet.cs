using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 10f;
    public int bulletDmg = 50;
    public Rigidbody2D rb;
    
	
    
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
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
	
	
}
