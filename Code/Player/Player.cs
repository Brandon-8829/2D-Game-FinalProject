/*
 * Script that takes player inputs and moves the character accordingly.
 * 
 * 
 * Author: Brandon Harris
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(Controller2D))]
public class Player : MonoBehaviour {


    // float variables that affect player attributes.
    public float jumpVelocity = 20f;
    float moveSpeed = 10f;
    float gravity = -40f;
    float accTimeAir = 0.2f;
    float accTimeGround = 0.15f;
    float velocitySmoothing;

    //final floats
    readonly float RmoveSpeed = 10f;
    readonly float RjumpVelocity = 20f;

    // int variables
    public int maxHealth = 100;
    public int currentHealth;
    public int keyCount;
    
    // boolean variables
    public bool facing = true;
    public bool jumpCheck = false;
    public bool statChangeOne = false;
    public bool statChangeTwo = false;
    
    // references to other scripts.
    public HealthBar healthBar; 
    public Animator animator; 

    Vector3 velocity;

    Controller2D controller;

    private Transform targetEnemy, targetPlayer;

    void Start () {
        controller = GetComponent<Controller2D>(); //initialize our controller
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        keyCount = 0;
        //moveSpeed = 10;

    }

    void Update() {

        animator.SetFloat("speed", Mathf.Abs(velocity.x));
        //slow down the fall spead.
        if (controller.collisions.above || controller.collisions.below) {
            velocity.y = 0;
        }

        //set facing variable
        facing = controller.faceCheck();

        //getting horizontal inputs from the user
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
       
        //jump check -> space bar and player must be on ground.
        if (Input.GetKeyDown(KeyCode.Space) && controller.collisions.below) {
            velocity.y = jumpVelocity;
            jumpCheck = true;
            animator.SetBool("isJumping", jumpCheck);
        }
        else
        {
            jumpCheck = false;
        }

        float targetVelocityX = input.x * moveSpeed;
        
        //smoothing out horizontal movement
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocitySmoothing, (controller.collisions.below) ? accTimeGround : accTimeAir);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //update animator 
        animator.SetFloat("speed", Mathf.Abs(velocity.x));
            //animator.SetBool("isJumping", jumpCheck);

        //CHECK IF PLAYER IS DEAD , DESTROY HIM IF SO!!!!
        if (currentHealth <= 0)
        {
            PlayerDead();
        }
        playerStatChange();
    }

    // This is the take damage function, call this whenever the player is attacked.
    public void PlayerTakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);      
    }

    public void PlayerHeal(int healthGained)
    {
        //currentHealth = currentHealth + healthGained;
        currentHealth = maxHealth;
        healthBar.setHealth(currentHealth);
        playerStatChange();
    }
    
    public void PlayerDead()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Menu");
        Debug.Log("player is dead");
    }

    public void KeyGained()
    {
        keyCount++;
        
    }

    public void playerStatChange()
    {
        if ((statChangeOne == false) && (currentHealth <= 75))
        {
            jumpVelocity = jumpVelocity+5;
            moveSpeed = moveSpeed+5f;
            statChangeOne = true;
        }
        if((statChangeTwo == false)&&(currentHealth <= 50))
        {
            jumpVelocity = jumpVelocity + 5;
            moveSpeed = moveSpeed + 5f;
            statChangeTwo = true;
        }

        if (currentHealth > 75)
        {
            jumpVelocity = RjumpVelocity;
            moveSpeed = RmoveSpeed;
            statChangeOne = false;
            statChangeTwo = false;
        }
        
        
    }
}
