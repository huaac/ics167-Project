using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public float speed;
   public Rigidbody2D rb;

   private Vector3 movement;     //(x,y,0) vector
   private float move_x;               //x coordinate of player
   //private float move_y;               //y coordinate of player
   private bool facing_right;

   void Start()
   {
       speed = 7f;
       movement = new Vector3(0.0f, 0.0f, 0.0f);
       facing_right = true;
   }

   void Update()
   {
       move_x = Input.GetAxisRaw("Horizontal"); //returns a -1/0/1
       //move_y = Input.GetAxisRaw("Vertical");

       movement = new Vector3(move_x, 0.0f, 0.0f);
       movement = movement.normalized;
   }

   void FixedUpdate()
   {
       if(movement != Vector3.zero) //if no input, then don't move
       {
           rb.MovePosition(transform.position + speed * movement * Time.deltaTime); //physically moves Nuvi in the direction
           //transform.rotation = Quaternion.LookRotation(transform.forward, -movement); //for facing the direction its moving
           //-movement bc otherwise it will face the opposite direction since transform is facing downwards
       }
       if(move_x > 0 && !facing_right)
       {
           flip();
       }
       if(move_x < 0 && facing_right)
       {
           flip();
       }
   }

    void flip()
    {
        Vector3 scale = gameObject.transform.localScale;
        scale.x *= -1;
        facing_right = !facing_right;
        gameObject.transform.localScale = scale;
    }

}
