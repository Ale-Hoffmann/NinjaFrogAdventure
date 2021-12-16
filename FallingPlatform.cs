using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
   public float timeFall;
   private TargetJoint2D ta;
   private Animator anim;
    void Start()
    {
        ta=GetComponent<TargetJoint2D>();
        anim=GetComponent<Animator>();
    }

    
    
    //void Contact()
    //{
      void OnCollisionEnter2D(Collision2D collision)
     {
        if(collision.gameObject.tag == "Player")
        {
           Invoke("Fall",timeFall);
        }
         if(collision.gameObject.layer==9)
        {
            Destroy(gameObject);
        }
     }
        void Fall()
        {
            ta.enabled = false;
            anim.SetBool("Caiu",true);
          
        }
     
    //}
}
