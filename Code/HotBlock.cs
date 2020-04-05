using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBlock : MonoBehaviour {

    private Player player;

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.PlayerTakeDamage(20);
            //Debug.Log("player taking damage");
        }
    }
}
