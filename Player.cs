/*
 * Script that takes player inputs and moves the character accordingly.
 * 
 * 
 * Author: Brandon Harris
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Controller2D))]
public class Player : MonoBehaviour {



    float jumpVelocity = 10;
    float moveSpeed = 6;
    float gravity = -20;
    float accTimeAir = 0.2f;
    float accTimeGround = 0.1f;
    float velocitySmoothing;
    Vector3 velocity;

    Controller2D controller;

	void Start () {
        controller = GetComponent<Controller2D>(); //initialize our controller
	}

    void Update() {

        //slow down the fall spead.
        if(controller.collisions.above || controller.collisions.below) {
            velocity.y = 0;
        }

        //getting horizontal inputs from the user
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
       
        //jump check -> space bar and player must be on ground.
        if (Input.GetKeyDown(KeyCode.Space) && controller.collisions.below) {
            velocity.y = jumpVelocity;
        }

        float targetVelocityX = input.x * moveSpeed;
        
        //smoothing out horizontal movement
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocitySmoothing, (controller.collisions.below) ? accTimeGround : accTimeAir);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
	

}
