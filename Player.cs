   using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public float Speed;
   public float JumpForce;
   public float DeathJump;
   public static Player call;
   public GameObject cam;

   public bool doubleJump;
   public bool IsJumping;
   public bool boost;
   private bool alive;
   private Rigidbody2D rig;
   private Animator ani;
   private BoxCollider2D bx;
    private float tempo;
    private bool lateralCam;
    private bool horizontalCam;
    private Vector3 aux;




    void Start()
    {
        rig= GetComponent<Rigidbody2D>();
        ani= GetComponent<Animator>();
        bx=GetComponent<BoxCollider2D>();
        alive=true;
        boost = false;
        tempo = 0;
        aux.Set(0,0,-10);
        aux = transform.position;
        cam.transform.position = aux;
      
    }

   
    void Update()
    {
        Move();
        Jump();
        cameraMovement();
       
    }
    void Move()
    {
     if(alive)
      {
      Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f );
      transform.position += movement * Time.deltaTime * Speed;
      if(Input.GetAxis("Horizontal") > 0)
       {
        ani.SetBool("Walk",true);
        transform.eulerAngles = new Vector3 (0f,0f,0f);
       }
      if(Input.GetAxis("Horizontal") < 0)
       {
        ani.SetBool("Walk",true);
        transform.eulerAngles = new Vector3 (0f,180,0f); //invertendo a sprite de lado
       }
      if(Input.GetAxis("Horizontal") == 0)
       { 
        ani.SetBool("Walk",false);
       }

            abilidades();

      }
       
    }

    

    
    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!IsJumping)
            {
          rig.AddForce(new Vector2(0f,JumpForce), ForceMode2D.Impulse);
          doubleJump = true;
          ani.SetBool("Jump",true);
            }
            else
            {
                if(doubleJump)
                {
                     rig.AddForce(new Vector2(0f,JumpForce), ForceMode2D.Impulse);
                     doubleJump = false;
                       
                      ani.SetBool("DoubleJump",true);
                }
            }
        }
    }
       void OnCollisionEnter2D(Collision2D collision)
      {
        if(collision.gameObject.layer == 8)
        {
           IsJumping = false;
            ani.SetBool("Jump",false);
            ani.SetBool("DoubleJump",false);
        }

       
      }
     void OnCollisionExit2D(Collision2D collision)
     {
        if(collision.gameObject.layer == 8)
        {
           IsJumping = true; 
           ani.SetBool("Jump",true);
        }
     }
       
      void OnTriggerEnter2D(Collider2D collider)
      {
      if(collider.gameObject.layer == 10)
      {
          // quando entra em contato com um item com a layer gameover ele mata o personagem, mas o item tem que ser um trigger
               rig.AddForce(new Vector2(0f,DeathJump), ForceMode2D.Impulse);
               alive=false;
               bx.enabled=false;
               GameController.insta.ShowGameOver();
               Destroy(gameObject,2f);
           
          
      }
      if(collider.gameObject.layer == 11)
        {
            lateralCam = false;
        }
      if(collider.gameObject.layer != 11)
        {
            lateralCam = true;
        }
      if(collider.tag=="Cherry")
        {
            Speed=6;
        }
     

      }

   
     
 //void Die()
   //   {
   //            rig.AddForce(new Vector2(0f,DeathJump), ForceMode2D.Impulse);
   //            alive=false;
   //            bx.enabled=false;
   //            GameController.insta.ShowGameOver();
   //            Destroy(gameObject,2f);
   //   }


    void abilidades()
    {
        if (Speed > 5)
        {
            Speed = 10;
            tempo = tempo + Time.deltaTime;
        }
        if (tempo >= 10)
        {
            Speed = 5;
        }
        if(tempo>=10)
        {
            tempo = 0;
            boost = false;
        }
    }
    void ativarBoost()
    {
        boost = true;
    }
    void cameraMovement()
    {
        aux = transform.position;
        aux.y= transform.position.y;
        if (lateralCam == true)
        {
            aux.x = transform.position.x;
        }
        aux.z = aux.z - 10;
        cam.transform.position = aux;
      
    }


}
        
    
 
    
  

