/*
 * Script that takes player inputs and moves the character accordingly.
 * 
 * 
 * Author: Brandon Harris
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class Controller2D : MonoBehaviour {
    public LayerMask collisionMask;

    const float skinWidth= .015f;

    public int hRayCount = 4;
    public int vRayCount = 4;

    float hRaySpacing;
    float vRaySpacing;

    BoxCollider2D collider;
    RaycastOrigins raycastOrigins;
    public CollisionDetect collisions;

    void Start() {
        collider = GetComponent<BoxCollider2D>();
        CalculateRaySpacing();
    }

    /*
     * Code to handle player movement
     * 
     */
    public void Move(Vector3 velocity) {
        UpdateRaycastOrigins();
        collisions.Reset();

        if(velocity.x != 0)
        {
            HorizontalCollisions(ref velocity);
        }
        if(velocity.y != 0)
        {
            VerticalCollisions(ref velocity);
        }
        
        transform.Translate (velocity);
    }

    void VerticalCollisions(ref Vector3 velocity)
    {
        float directionY = Mathf.Sign(velocity.y);
        float rayLength = Mathf.Abs(velocity.y) + skinWidth;

        for (int i = 0; i < vRayCount; i++)
        {
            Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
            rayOrigin += Vector2.right * (vRaySpacing * i + velocity.x);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);

            Debug.DrawRay(rayOrigin, Vector2.up * directionY * rayLength, Color.red);

            if (hit)//Set the y velocity == to the amount we have to move to get from current position to the point at which they ray intercepted with a obstacle.
            {
                velocity.y = (hit.distance - skinWidth) * directionY;
                rayLength = hit.distance;
                //set new vertical collisons
                collisions.below = directionY == -1;
                collisions.above = directionY == 1;
            }
        }
    }
    
    void HorizontalCollisions(ref Vector3 velocity)
    {
        float directionX = Mathf.Sign(velocity.x);
        float rayLength = Mathf.Abs(velocity.x) + skinWidth;

        for (int i = 0; i < hRayCount; i++)
        {
            //if moving right, start bottomleft, else start bottomright
            Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
            rayOrigin += Vector2.up * (hRaySpacing * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);

            

            if (hit)//Set the x velocity == to the amount we have to move to get from current position to the point at which they ray intercepted with a obstacle.
            {
      
                velocity.x = (hit.distance - skinWidth) * directionX;
                rayLength = hit.distance;
                //set new horizontal collisoins
                collisions.left = directionX == -1;
                collisions.right = directionX == 1;

            }
        }
    }

    /*
     * To handle collision data
     * 
     */
    void UpdateRaycastOrigins() {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth*-2); //shrink on all sides

        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    void CalculateRaySpacing() {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth * -2);

        hRayCount = Mathf.Clamp(hRayCount, 2, int.MaxValue);
        vRayCount = Mathf.Clamp(vRayCount, 2, int.MaxValue);

        hRaySpacing = bounds.size.y / (hRayCount - 1);
        vRaySpacing = bounds.size.x / (vRayCount - 1);

    }

    //Store positions of box colliders, will store vectors.
    struct RaycastOrigins {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }



    /*
     * 
     * 
     */

    public struct CollisionDetect
    {
        public bool above, below;
        public bool right, left;

        public void Reset()
        {
            above = below = false;
            left = right = false;
        }

    }
}



