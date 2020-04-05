/*
 * Script for the Boss animations. Holds all functions and variables realative to the boss animations.
 * 
 * Author: Brandon Harris
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_run : StateMachineBehaviour {


    Transform player;
    Rigidbody2D rb;
    Boss boss;

    public float speed = 80f;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
    }

	 //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        boss.flip();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newLoc = Vector2.MoveTowards(rb.position, target, speed*Time.fixedDeltaTime);
        rb.MovePosition(newLoc);
        if (Vector2.Distance(player.position, rb.position) < 5f)
        {
            animator.SetTrigger("Attack");
        }
    }

	 //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.SetTrigger("Attack");
	}

    public void speedChange()
    {
        speed = 160f;
    }
	
}
